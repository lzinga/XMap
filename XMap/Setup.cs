using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XMap.Core;
using SharpDX.XInput;
using XMap.Common;
using XMap.Core.Conditions;
using XMap.Core.Actions;

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
#if DEBUG
                configFile = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Configs", "map.xml"));
#else
                configFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Configs", "map.xml");
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

            List<Type> subClasses = new List<Type>();
            subClasses.AddRange(Utilities.FindSubClassesOf<BaseCondition>());
            subClasses.AddRange(Utilities.FindSubClassesOf<BaseAction>());
            config = xml.Deserialize<Mapping>(subClasses.ToArray());

            Log.WriteAction(LogMarker.Config, $"Loaded Config \"{file}\"");
            Log.WriteAction(LogMarker.Config, $"{this.config.Macros.Count()} macro with {this.config.Macros.Sum(i => i.Actions.Count())} actions.");
        }

        private void ConfigFile_Changed(object sender, FileSystemEventArgs e)
        {
            this.LoadFile(e.FullPath);
        }

        private bool ControllerEvent(XInputControllerState state)
        {
            // Get all macros with the ones with the highest condition count, these should execute first.
            var item = config.Macros.OrderByDescending(i => i.Conditions.Count);

            var running = config.Macros.SingleOrDefault(i => i.IsRunning);
            if (running != null)
            {

                // If the user stops holding the buttons stop the action.
                if (!state.HoldingButtons)
                {
                    running.IsRunning = false;
                    return false;
                }


                // Check if its conditions are met again.
                bool allConditionsMet = true;
                foreach (var condition in running.Conditions)
                {
                    bool currentConditionPassed = condition.Validate(state, windowManager);
                    if (!currentConditionPassed)
                    {
                        allConditionsMet = false;
                    }
                }

                if (allConditionsMet)
                {
                    RunMacro(state, running);
                    running.IsRunning = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Find macros that match the current state and try to ignore others.
            foreach (var macro in item)
            {
                //// Is any macro already running, just execute it again since its already been validated.
                //var running = config.Macros.SingleOrDefault(i => i.IsRunning);
                //if (running != null)
                //{
                //    return RunMacro(state, running);
                //}

                bool allconditionsPassed = true;
                foreach (var condition in macro.Conditions)
                {
                    bool currentConditionPassed = condition.Validate(state, windowManager);
                    if (condition.GetType() == typeof(HoldCondition))
                    {
                        // If the current condition is a hold condition, ignore validating it for now.
                    }
                    else if(!currentConditionPassed)
                    {
                        allconditionsPassed = false;
                    }
                }

                
                // If all other conditions passed other than hold, lets mark it as running and check it again later.
                if (allconditionsPassed && macro.HasHoldCondition)
                {
                    macro.IsRunning = true;
                    return false;
                }


                // If all conditions passed and it doesn't have a hold condition, lets execute it.
                if(allconditionsPassed)
                {
                    RunMacro(state, macro);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="macro"></param>
        /// <returns></returns>
        private void RunMacro(XInputControllerState state, Macro macro)
        {
            Log.WriteLineColor("================================================================", ConsoleColor.DarkGray);
            Log.WriteAction(LogMarker.Macro, $"{macro.Name} macro conditions passed, executing {macro.Actions.Count} actions.");
            //foreach (var conLog in conditionChecks)
            //{
            //    Log.WriteAction(LogMarker.Condtn, conLog);
            //}

            for (int i = 0; i < macro.Actions.Count; i++)
            {
                var action = macro.Actions[i];
                Log.WriteAction(LogMarker.Action, $"\t {i + 1}. {action.ToString()}");
                action.Execute();
            }
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
