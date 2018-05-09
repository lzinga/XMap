using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMap.Core;
using SharpDX.XInput;
using XMap.Common;

namespace XMap
{
    public class Setup
    {
        public Mapping map { get; private set; }
        public XInputController Controller { get; private set; } = new XInputController();

        public Setup()
        {
            var content = File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Configs", "map.xml"));
            map = content.Deserialize<Mapping>();
            Controller.OnButtonPressed += Controller_OnButtonPressed;
        }

        private void Controller_OnButtonPressed(GamepadButtonFlags buttons)
        {
            var macros = map.Macros.Where(i => buttons.ToString().Equals(i.OnKeyDown, StringComparison.OrdinalIgnoreCase));

            foreach(var macro in macros)
            {
                macro.HoldTime
            }
            foreach (var action in actions)
            {
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
