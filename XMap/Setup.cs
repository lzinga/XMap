using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMap.Core;

namespace XMap
{
    public class Setup
    {
        public List<Mapping> Mappings { get; private set; }
        public XInputController Controller { get; private set; } = new XInputController();

        public Setup()
        {
            var json = File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Configs", "map.json"));
            var mappings = JsonConvert.DeserializeObject<List<Mapping>>(json);
        }

        private bool IsKeyPressed(ConsoleKey key)
        {
            return Console.KeyAvailable && Console.ReadKey(true).Key == key;
        }

        public Setup Execute()
        {
            Controller.OnButtonPressed += Controller_OnButtonPressed;
            Controller.Poll(() =>
            {
                if (IsKeyPressed(ConsoleKey.Escape))
                {
                    Controller.IsPolling = false;
                }
            });

            return this;
        }

        private void Controller_OnButtonPressed(SharpDX.XInput.GamepadButtonFlags buttons)
        {
            Console.WriteLine(buttons);
            if(buttons == SharpDX.XInput.GamepadButtonFlags.A)
            {
                InputManager input = new InputManager();
                input.SendKey("A: IM STILL CALLING YOU GAY");

            }
            else if (buttons == SharpDX.XInput.GamepadButtonFlags.B)
            {
                InputManager input = new InputManager();
                input.SendKey("B: It is okay janooba, B is here for you.");

            }

        }
    }
}
