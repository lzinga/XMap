using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMap.Core
{
    public struct XInputControllerState
    {
        public State State { get; set; }
        public bool HoldingButtons { get; set; }
        public TimeSpan CurrentHoldTime { get; set; }
    }
}
