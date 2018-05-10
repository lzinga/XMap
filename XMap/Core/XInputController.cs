using SharpDX.XInput;
using System;
using System.Threading;

namespace XMap.Core
{
    public class XInputController
    {
        #region Public Properties
        public int deadband = 2500;
        public bool Connected { get; set; } = false;
        public bool IsPolling { get; private set; }
        public bool HoldingButtons { get; private set; }
        public TimeSpan CurrentHoldTime { get; private set; }
        #endregion

        #region Events
        public event ButtonPressed OnButtonPressed;
        public delegate void ButtonPressed(GamepadButtonFlags buttons);

        public event ButtonHold OnButtonHold;
        public delegate bool ButtonHold(GamepadButtonFlags buttons, TimeSpan duration);
        #endregion

        #region Private Fields
        Controller controller;
        State previousState;
        #endregion

        Mapping map;
        private DateTime? holdButtonStart = null;

        public XInputController()
        {
            controller = new Controller(UserIndex.One);
            Connected = controller.IsConnected;
        }

        public void Stop()
        {
            this.IsPolling = false;
        }

        
        public void Poll(Action func)
        {
            IsPolling = true;

            previousState = controller.GetState();
            while (this.Connected && this.IsPolling)
            {
                func();
                var currentState = controller.GetState();
                if (previousState.PacketNumber != currentState.PacketNumber)
                {
                    this.HoldingButtons = false;
                    CheckButtonPressed(currentState.Gamepad);
                    holdButtonStart = null;
                }
                else if(previousState.PacketNumber == currentState.PacketNumber && currentState.Gamepad.Buttons != GamepadButtonFlags.None)
                {
                    if (!holdButtonStart.HasValue)
                    {
                        holdButtonStart = DateTime.Now;
                        this.CurrentHoldTime = new TimeSpan(0, 0, 0);
                    }
                    else
                    {
                        this.CurrentHoldTime = DateTime.Now - holdButtonStart.Value;
                    }

                    CheckButtonHeld(currentState.Gamepad, this.CurrentHoldTime);
                }

                
                Thread.Sleep(10);
                previousState = currentState;
            }
        }

        private void CheckButtonPressed(Gamepad state)
        {
            if (state.Buttons != GamepadButtonFlags.None)
            {
                OnButtonPressed?.Invoke(state.Buttons);
            }
        }

        private void CheckButtonHeld(Gamepad state, TimeSpan duration)
        {
            if (state.Buttons != GamepadButtonFlags.None)
            {
                if (OnButtonHold != null)
                {
                    if(OnButtonHold.Invoke(state.Buttons, duration))
                    {
                        holdButtonStart = null;
                    }
                }
            }
        }

    }
}
