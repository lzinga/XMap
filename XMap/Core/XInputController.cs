using SharpDX;
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
        public bool Connected
        {
            get
            {
                return this.controller.IsConnected;
            }
        }
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
            CheckForController();
        }

        public bool CheckForController()
        {
            // If the controller is not connected, wait for it to be.
            if (!controller.IsConnected)
            {
                Log.WriteAction(LogMarker.Info, $"Waiting for controller. Will check every 3 seconds.");
                while (!controller.IsConnected)
                {
                    Thread.Sleep(3000);
                }
            }
            Log.WriteAction(LogMarker.Info, $"Controller Found");
            return true;
        }

        public void Stop()
        {
            this.IsPolling = false;
            Log.WriteAction(LogMarker.Config, $"Polling Stopped.");
        }

        
        public void Poll(Action func)
        {
            Log.WriteAction(LogMarker.Config, $"Polling Started.");
            IsPolling = true;

            previousState = controller.GetState();
            while (this.IsPolling)
            {
                func();
                State currentState;
                try
                {
                    currentState = controller.GetState();
                }
                catch (SharpDXException ex)
                {
                    CheckForController();
                    continue;
                }
                
                if (previousState.PacketNumber != currentState.PacketNumber)
                {
                    this.HoldingButtons = false;
                    CheckButtonPressed(this.GetState());
                    holdButtonStart = null;
                }
                else if(previousState.PacketNumber == currentState.PacketNumber)
                {
                    // If triggers are being used with no buttons, or only buttons are being pressed and no triggers, check for hold.
                    if(((currentState.Gamepad.LeftTrigger > 0 || currentState.Gamepad.RightTrigger > 0) && currentState.Gamepad.Buttons == GamepadButtonFlags.None) ||
                        currentState.Gamepad.Buttons != GamepadButtonFlags.None)
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

                        this.HoldingButtons = true;
                        CheckButtonHeld(this.GetState());
                    }

                }

               Thread.Sleep(30);
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
            if (OnButtonHold != null && OnButtonHold.Invoke(this.GetState()))
            {
                this.HoldingButtons = false;
                holdButtonStart = null;
            }
        }

    }
}
