using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XMap.Common;

namespace XMap.Core
{
    public class XInputController
    {
        #region Public Properties
        public int deadband = 2500;
        public bool Connected { get; set; } = false;
        public bool IsPolling { get; private set; }
        #endregion

        #region Events
        public event ButtonPressed OnButtonPressed;
        public delegate void ButtonPressed(GamepadButtonFlags buttons);
        #endregion

        #region Private Fields
        Controller controller;
        State previousState;
        #endregion

        Mapping map;

        public XInputController()
        {
            controller = new Controller(UserIndex.One);
            Connected = controller.IsConnected;
            map = new Mapping()
            {
                Macros = new List<Macro>()
                {
                    new Macro()
                    {
                        OnKeyDown = "A",
                        Actions = new List<BaseAction>()
                        {
                            new KeyAction()
                            {
                                Type = ActionType.OnKeyDown,
                                Key = "VK_E",
                            }
                        }
                    }
                }
            };
        }

        public void Stop()
        {
            this.IsPolling = false;
        }
        

        public void Poll(System.Action func)
        {
            IsPolling = true;

            previousState = controller.GetState();
            while (this.Connected && this.IsPolling)
            {
                func();
                var currentState = controller.GetState();
                if (previousState.PacketNumber != currentState.PacketNumber)
                {
                    InputCheck(currentState.Gamepad);
                }

                Thread.Sleep(10);
                previousState = currentState;
            }
        }

        private void InputCheck(Gamepad state)
        {
            if (state.Buttons != GamepadButtonFlags.None)
            {
                OnButtonPressed?.Invoke(state.Buttons);
            }
        }
    }
}
