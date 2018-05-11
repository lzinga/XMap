using SharpDX.XInput;
using System;
using System.Threading;
using XMap.Common;

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
        public Gamepad Gamepad { get; private set; }
        #endregion

        #region Events
        public event ButtonPressed OnButtonPressed;
        public delegate bool ButtonPressed(XInputControllerState state);

        public event ButtonHold OnButtonHold;
        public delegate bool ButtonHold(XInputControllerState state);
        #endregion

        #region Private Fields
        Controller controller;
        State previousState;
        #endregion

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
                    CheckButtonPressed(this.GetState());
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

                    CheckButtonHeld(this.GetState());
                }

                Thread.Sleep(10);
                previousState = currentState;
            }
        }

        public XInputControllerState GetState()
        {
            return new XInputControllerState()
            {
                State = this.controller.GetState(),
                CurrentHoldTime = this.CurrentHoldTime,
                HoldingButtons = this.HoldingButtons
            };
        }

        private void CheckButtonPressed(XInputControllerState state)
        {
            if (state.State.Gamepad.Buttons != GamepadButtonFlags.None)
            {
                OnButtonPressed?.Invoke(state);
            }
        }

        private void CheckButtonHeld(XInputControllerState state)
        {
            if (state.State.Gamepad.Buttons != GamepadButtonFlags.None)
            {
                if (OnButtonHold != null && OnButtonHold.Invoke(this.GetState()))
                {
                    holdButtonStart = null;
                }
            }
        }

    }
}
