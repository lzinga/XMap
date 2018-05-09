using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMap.Common
{
    public enum ActionType
    {
        OnKeyDown,
    }

    [Flags]
    public enum GamepadButtons : int
    {
        Dpad_Up = 0x0001,
        Dpad_Down = 0x0002,
        Dpad_Left = 0x0004,
        Dpad_Right = 0x0008,
        Start = 0x0010,
        Back = 0x0020,
        LeftStick = 0x0040,
        RightStick = 0x0080,
        LBumper = 0x0100,
        RBumper = 0x0200,
        A = 0x1000,
        B = 0x2000,
        X = 0x4000,
        Y = 0x8000,
    };
}
