﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XMap.Core;
using SharpDX.XInput;
using XMap.Common;

namespace XMap
{
    public class Setup
    {
        public Mapping config { get; private set; }
        public XInputController Controller { get; private set; } = new XInputController();
        public WindowManager windowManager = new WindowManager();
        public Setup(string configFile = "")
        {
            if (string.IsNullOrEmpty(configFile))
            {
#if RELEASE
                configFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Configs", "map.xml");
#endif
#if DEBUG
                configFile = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Configs", "map.xml"));
#endif
            }

            this.LoadFile(configFile);

            FileSystemWatcher configWatcher = new FileSystemWatcher(Path.GetDirectoryName(configFile), Path.GetFileName(configFile));
#if DEBUG
            // This is needed for debug to load the file next to visual studio and not for the build
            // FileSystemWatcher fails to track a file edited by visual studio since it seems to
            // save the contents to a new file with a temp name then deletes the original file and renames
            // the temp one with the expected file name. (https://stackoverflow.com/questions/680698/why-doesnt-filesystemwatcher-detect-changes-from-visual-studio)
            configWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
            | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.DirectoryName;
#endif
            configWatcher.Changed += ConfigFile_Changed;
            configWatcher.EnableRaisingEvents = true;
            Controller.OnButtonPressed += ControllerEvent;
            Controller.OnButtonHold += ControllerEvent;
        }

        private void LoadFile(string file)
        {
            if (!File.Exists(file))
            {
                Log.WriteAction(LogMarker.Error, $"Failed to load config \"{file}\".");
            }

            string xml = File.ReadAllText(file);
            config = xml.Deserialize<Mapping>();

            Log.WriteAction(LogMarker.Config, $"Loaded Config \"{file}\"");
            Log.WriteAction(LogMarker.Config, $"{this.config.Macros.Count()} macro with {this.config.Macros.Sum(i => i.Actions.Count())} actions.");
        }

        private void ConfigFile_Changed(object sender, FileSystemEventArgs e)
        {
            this.LoadFile(e.FullPath);
        }

        private bool ControllerEvent(XInputControllerState state)
        {
            return RunMacros(state);
        }

        private bool RunMacros(XInputControllerState state)
        {
            bool anyExecuted = false;
            foreach (var macro in config.Macros)
            {
                bool conditionsMet = true;
                List<string> conditionChecks = new List<string>();
                foreach(var condition in macro.Conditions)
                {
                    var passed = condition.Validate(state, windowManager);
                    if (!passed)
                    {
                        conditionsMet = false;
                    }

                    conditionChecks.Add($"{condition.ToString()} Did it pass? {passed}");
                }

                if (!conditionsMet)
                {
                    continue;
                }

                Log.WriteLineColor("================================================================", ConsoleColor.DarkGray);
                Log.WriteAction(LogMarker.Macro, $"{macro.Name} macro conditions passed, executing {macro.Actions.Count} actions.");
                foreach(var conLog in conditionChecks)
                {
                    Log.WriteAction(LogMarker.Condtn, conLog);
                }

                for (int i = 0; i < macro.Actions.Count; i++)
                {
                    var action = macro.Actions[i];
                    Log.WriteAction(LogMarker.Action, $"\t {i + 1}. {action.ToString()}");
                    action.Execute();
                    anyExecuted = true;
                }
            }

            return anyExecuted;
        }

        private bool IsKeyPressed(ConsoleKey key)
        {
            return Console.KeyAvailable && Console.ReadKey(true).Key == key;
        }

        public Setup Execute()
        {
            Controller.Poll(() =>
            {
                if (IsKeyPressed(ConsoleKey.Escape))
                {
                    Controller.Stop();
                }
            });

            return this;
        }
    }
}
