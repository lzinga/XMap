using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMap.Core
{
    //
    // Summary:
    //     The list of VirtualKeyCodes (see: http://msdn.microsoft.com/en-us/library/ms645540(VS.85).aspx)
    public enum VirtualKeyCode
    {
        //
        // Summary:
        //     Left mouse button
        LBUTTON = 1,
        //
        // Summary:
        //     Right mouse button
        RBUTTON = 2,
        //
        // Summary:
        //     Middle mouse button (three-button mouse) - NOT contiguous with LBUTTON and RBUTTON
        MBUTTON = 4,
        //
        // Summary:
        //     ENTER key
        RETURN = 13,
        //
        // Summary:
        //     SHIFT key
        SHIFT = 16,
        //
        // Summary:
        //     CTRL key
        CONTROL = 17,
        //
        // Summary:
        //     ALT key
        MENU = 18,
        //
        // Summary:
        //     CAPS LOCK key
        CAPITAL = 20,
        //
        // Summary:
        //     ESC key
        ESCAPE = 27,
        //
        // Summary:
        //     SPACEBAR
        SPACE = 32,
        //
        // Summary:
        //     LEFT ARROW key
        LEFT = 37,
        //
        // Summary:
        //     UP ARROW key
        UP = 38,
        //
        // Summary:
        //     RIGHT ARROW key
        RIGHT = 39,
        //
        // Summary:
        //     DOWN ARROW key
        DOWN = 40,
        //
        // Summary:
        //     SELECT key
        SELECT = 41,
        //
        // Summary:
        //     EXECUTE key
        EXECUTE = 43,
        //
        // Summary:
        //     0 key
        VK_0 = 48,
        //
        // Summary:
        //     1 key
        VK_1 = 49,
        //
        // Summary:
        //     2 key
        VK_2 = 50,
        //
        // Summary:
        //     3 key
        VK_3 = 51,
        //
        // Summary:
        //     4 key
        VK_4 = 52,
        //
        // Summary:
        //     5 key
        VK_5 = 53,
        //
        // Summary:
        //     6 key
        VK_6 = 54,
        //
        // Summary:
        //     7 key
        VK_7 = 55,
        //
        // Summary:
        //     8 key
        VK_8 = 56,
        //
        // Summary:
        //     9 key
        VK_9 = 57,
        //
        // Summary:
        //     A key
        VK_A = 65,
        //
        // Summary:
        //     B key
        VK_B = 66,
        //
        // Summary:
        //     C key
        VK_C = 67,
        //
        // Summary:
        //     D key
        VK_D = 68,
        //
        // Summary:
        //     E key
        VK_E = 69,
        //
        // Summary:
        //     F key
        VK_F = 70,
        //
        // Summary:
        //     G key
        VK_G = 71,
        //
        // Summary:
        //     H key
        VK_H = 72,
        //
        // Summary:
        //     I key
        VK_I = 73,
        //
        // Summary:
        //     J key
        VK_J = 74,
        //
        // Summary:
        //     K key
        VK_K = 75,
        //
        // Summary:
        //     L key
        VK_L = 76,
        //
        // Summary:
        //     M key
        VK_M = 77,
        //
        // Summary:
        //     N key
        VK_N = 78,
        //
        // Summary:
        //     O key
        VK_O = 79,
        //
        // Summary:
        //     P key
        VK_P = 80,
        //
        // Summary:
        //     Q key
        VK_Q = 81,
        //
        // Summary:
        //     R key
        VK_R = 82,
        //
        // Summary:
        //     S key
        VK_S = 83,
        //
        // Summary:
        //     T key
        VK_T = 84,
        //
        // Summary:
        //     U key
        VK_U = 85,
        //
        // Summary:
        //     V key
        VK_V = 86,
        //
        // Summary:
        //     W key
        VK_W = 87,
        //
        // Summary:
        //     X key
        VK_X = 88,
        //
        // Summary:
        //     Y key
        VK_Y = 89,
        //
        // Summary:
        //     Z key
        VK_Z = 90,
        //
        // Summary:
        //     Left Windows key (Microsoft Natural keyboard)
        LWIN = 91,
        //
        // Summary:
        //     Right Windows key (Natural keyboard)
        RWIN = 92,
        //
        // Summary:
        //     Numeric keypad 0 key
        NUMPAD0 = 96,
        //
        // Summary:
        //     Numeric keypad 1 key
        NUMPAD1 = 97,
        //
        // Summary:
        //     Numeric keypad 2 key
        NUMPAD2 = 98,
        //
        // Summary:
        //     Numeric keypad 3 key
        NUMPAD3 = 99,
        //
        // Summary:
        //     Numeric keypad 4 key
        NUMPAD4 = 100,
        //
        // Summary:
        //     Numeric keypad 5 key
        NUMPAD5 = 101,
        //
        // Summary:
        //     Numeric keypad 6 key
        NUMPAD6 = 102,
        //
        // Summary:
        //     Numeric keypad 7 key
        NUMPAD7 = 103,
        //
        // Summary:
        //     Numeric keypad 8 key
        NUMPAD8 = 104,
        //
        // Summary:
        //     Numeric keypad 9 key
        NUMPAD9 = 105,
        //
        // Summary:
        //     Multiply key
        MULTIPLY = 106,
        //
        // Summary:
        //     Add key
        ADD = 107,
        //
        // Summary:
        //     Separator key
        SEPARATOR = 108,
        //
        // Summary:
        //     Subtract key
        SUBTRACT = 109,
        //
        // Summary:
        //     Decimal key
        DECIMAL = 110,
        //
        // Summary:
        //     Divide key
        DIVIDE = 111,
        //
        // Summary:
        //     F1 key
        F1 = 112,
        //
        // Summary:
        //     F2 key
        F2 = 113,
        //
        // Summary:
        //     F3 key
        F3 = 114,
        //
        // Summary:
        //     F4 key
        F4 = 115,
        //
        // Summary:
        //     F5 key
        F5 = 116,
        //
        // Summary:
        //     F6 key
        F6 = 117,
        //
        // Summary:
        //     F7 key
        F7 = 118,
        //
        // Summary:
        //     F8 key
        F8 = 119,
        //
        // Summary:
        //     F9 key
        F9 = 120,
        //
        // Summary:
        //     F10 key
        F10 = 121,
        //
        // Summary:
        //     F11 key
        F11 = 122,
        //
        // Summary:
        //     F12 key
        F12 = 123,
        //
        // Summary:
        //     F13 key
        F13 = 124,
        //
        // Summary:
        //     F14 key
        F14 = 125,
        //
        // Summary:
        //     F15 key
        F15 = 126,
        //
        // Summary:
        //     F16 key
        F16 = 127,
        //
        // Summary:
        //     F17 key
        F17 = 128,
        //
        // Summary:
        //     F18 key
        F18 = 129,
        //
        // Summary:
        //     F19 key
        F19 = 130,
        //
        // Summary:
        //     F20 key
        F20 = 131,
        //
        // Summary:
        //     F21 key
        F21 = 132,
        //
        // Summary:
        //     F22 key
        F22 = 133,
        //
        // Summary:
        //     F23 key
        F23 = 134,
        //
        // Summary:
        //     F24 key
        F24 = 135,
        //
        // Summary:
        //     Left SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        LSHIFT = 160,
        //
        // Summary:
        //     Right SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        RSHIFT = 161,
        //
        // Summary:
        //     Left CONTROL key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        LCONTROL = 162,
        //
        // Summary:
        //     Right CONTROL key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        RCONTROL = 163,

        //
        // Summary:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the ';:' key
        OEM_1 = 186,
        //
        // Summary:
        //     Windows 2000/XP: For any country/region, the '+' key
        OEM_PLUS = 187,
        //
        // Summary:
        //     Windows 2000/XP: For any country/region, the ',' key
        OEM_COMMA = 188,
        //
        // Summary:
        //     Windows 2000/XP: For any country/region, the '-' key
        OEM_MINUS = 189,
        //
        // Summary:
        //     Windows 2000/XP: For any country/region, the '.' key
        OEM_PERIOD = 190,
    }
}
