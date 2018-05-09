using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XMap.Core
{
    public class XInputController
    {
        #region Public Properties
        public int deadband = 2500;
        public bool Connected { get; set; } = false;
        public bool IsPolling { get; set; }
        #endregion

        #region Events
        public event ButtonPressed OnButtonPressed;
        public delegate void ButtonPressed(GamepadButtonFlags buttons);
        #endregion

        #region Private Fields
        Controller controller;
        #endregion

        public XInputController()
        {
            controller = new Controller(UserIndex.One);
            Connected = controller.IsConnected;
        }
        
        public void Poll(Action func)
        {
            IsPolling = true;

            var previousState = controller.GetState();
            while (this.Connected && this.IsPolling)
            {
                func();
                var state = controller.GetState();
                if (previousState.PacketNumber != state.PacketNumber)
                {
                    InputCheck(state.Gamepad);
                }

                Thread.Sleep(10);
                previousState = state;
            }
        }

        private void InputCheck(Gamepad state)
        {
            if(state.Buttons != GamepadButtonFlags.None)
            {
                OnButtonPressed?.Invoke(state.Buttons);
            }
        }
    }
}
