namespace XMap.Common
{
    public enum LogMarker
    {
        Macro,
        Condtn,
        Action,
        Config,
        Error,
        Info,
    }

    public enum ModifierKeys
    {
        /// <summary>
        /// Shift Key
        /// </summary>
        Shift = 16,

        /// <summary>
        /// CTRL Key
        /// </summary>
        Control = 17,

        /// <summary>
        /// ALT Key
        /// </summary>
        Alt = 18,

        /// <summary>
        /// Left Control
        /// </summary>
        ControlLeft = 162,

        /// <summary>
        /// Right CONTROL key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        ControlRight = 163,

        /// <summary>
        /// Left MENU key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        AltLeft = 164,

        /// <summary>
        /// Right MENU key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        /// </summary>
        AltRight = 165,

        /// <summary>
        /// Left Windows key (Natural keyboard)
        /// </summary>
        WindowsLeft = 91,

        /// <summary>
        /// Right Windows key (Natural keyboard)
        /// </summary>
        WindowsRight = 92,
    }

    public enum Keys
    {
        /// <summary>
        /// Left Mouse Button
        /// </summary>
        MouseLeft = 1,

        /// <summary>
        /// Right Mouse Button
        /// </summary>
        MouseRight = 2,

        /// <summary>
        /// Middle Mouse Button
        /// </summary>
        MouseMiddle = 4,

        /// <summary>
        /// Backspace Key
        /// </summary>
        Backspace = 8,

        /// <summary>
        /// TAB Key
        /// </summary>
        Tab = 9,

        /// <summary>
        /// Enter Key
        /// </summary>
        Return = 13,

        /// <summary>
        /// ESC Key
        /// </summary>
        Escape = 27,

        /// <summary>
        /// Spacebar Key
        /// </summary>
        SpaceBar = 32,

        /// <summary>
        /// Left Arrow Key
        /// </summary>
        Left = 37,

        /// <summary>
        /// Up Arrow Key
        /// </summary>
        ArrowUp = 38,

        /// <summary>
        /// Right Arrow Key
        /// </summary>
        ArrowRight = 39,

        /// <summary>
        /// Down Arrow Key
        /// </summary>
        ArrowDown = 40,

        /// <summary>
        /// Delete key
        /// </summary>
        Delete = 46,

        /// <summary>
        /// Z key
        /// </summary>
        HELP = 47,

        /// <summary>
        /// 0 key
        /// </summary>
        Num_0 = 48,

        /// <summary>
        /// 1 key
        /// </summary>
        Num_1 = 49,

        /// <summary>
        /// 2 key
        /// </summary>
        Num_2 = 50,

        /// <summary>
        /// 3 key
        /// </summary>
        Num_3 = 51,

        /// <summary>
        /// 4 key
        /// </summary>
        Num_4 = 52,

        /// <summary>
        /// 5 key
        /// </summary>
        Num_5 = 53,

        /// <summary>
        /// 6 key
        /// </summary>
        Num_6 = 54,

        /// <summary>
        /// 7 key
        /// </summary>
        Num_7 = 55,

        /// <summary>
        /// 8 key
        /// </summary>
        Num_8 = 56,

        /// <summary>
        /// 9 key
        /// </summary>
        Num_9 = 57,

        /// <summary>
        /// A key
        /// </summary>
        A = 65,

        /// <summary>
        /// B key
        /// </summary>
        B = 66,

        /// <summary>
        /// C key
        /// </summary>
        C = 67,

        /// <summary>
        /// D key
        /// </summary>
        D = 68,

        /// <summary>
        /// E key
        /// </summary>
        E = 69,

        /// <summary>
        /// F key
        /// </summary>
        F = 70,

        /// <summary>
        /// G key
        /// </summary>
        G = 71,

        /// <summary>
        /// H key
        /// </summary>
        H = 72,

        /// <summary>
        /// I key
        /// </summary>
        I = 73,

        /// <summary>
        /// J key
        /// </summary>
        J = 74,

        /// <summary>
        /// K key
        /// </summary>
        K = 75,

        /// <summary>
        /// L key
        /// </summary>
        L = 76,

        /// <summary>
        /// M key
        /// </summary>
        M = 77,

        /// <summary>
        /// N key
        /// </summary>
        N = 78,

        /// <summary>
        /// O key
        /// </summary>
        O = 79,

        /// <summary>
        /// P key
        /// </summary>
        P = 80,

        /// <summary>
        /// Q key
        /// </summary>
        Q = 81,

        /// <summary>
        /// R key
        /// </summary>
        R = 82,

        /// <summary>
        /// S key
        /// </summary>
        S = 83,

        /// <summary>
        /// T key
        /// </summary>
        T = 84,

        /// <summary>
        /// U key
        /// </summary>
        U = 85,

        /// <summary>
        /// V key
        /// </summary>
        V = 86,

        /// <summary>
        /// W key
        /// </summary>
        W = 87,

        /// <summary>
        /// X key
        /// </summary>
        X = 88,

        /// <summary>
        /// Y key
        /// </summary>
        Y = 89,

        /// <summary>
        /// Z key
        /// </summary>
        Z = 90,

        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        NumPad_0 = 96,

        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        NumPad_1 = 97,

        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        NumPad_2 = 98,

        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        NumPad_3 = 99,

        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        NumPad_4 = 100,

        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        NumPad_5 = 101,

        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        NumPad_6 = 102,

        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        NumPad_7 = 103,

        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        NumPad_8 = 104,

        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        NumPad_9 = 105,

        /// <summary>
        /// Multiply key
        /// </summary>
        MULTIPLY = 106,


        /// <summary>
        /// Add key
        /// </summary>
        ADD = 107,

        /// <summary>
        /// Subtract key
        /// </summary>
        Subtract = 109,

        /// <summary>
        /// Decimal key
        /// </summary>
        Decimal = 110,

        /// <summary>
        /// Divide key
        /// </summary>
        Divide = 111,

        /// <summary>
        /// F1 key
        /// </summary>
        F1 = 112,

        /// <summary>
        /// F2 key
        /// </summary>
        F2 = 113,

        /// <summary>
        /// F3 key
        /// </summary>
        F3 = 114,

        /// <summary>
        /// F4 key
        /// </summary>
        F4 = 115,

        /// <summary>
        /// F5 key
        /// </summary>
        F5 = 116,

        /// <summary>
        /// F6 key
        /// </summary>
        F6 = 117,

        /// <summary>
        /// F7 key
        /// </summary>
        F7 = 118,

        /// <summary>
        /// F8 key
        /// </summary>
        F8 = 119,

        /// <summary>
        /// F9 key
        /// </summary>
        F9 = 120,

        /// <summary>
        /// F10 key
        /// </summary>
        F10 = 121,

        /// <summary>
        /// F11 key
        /// </summary>
        F11 = 122,

        /// <summary>
        /// F12 key
        /// </summary>
        F12 = 123,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '+' key
        /// </summary>
        Plus = 187,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the ',' key
        /// </summary>
        Comma = 188,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '-' key
        /// </summary>
        Minus = 189,

        /// <summary>
        /// Windows 2000/XP: For any country/region, the '.' key
        /// </summary>
        Period = 190,
    }
}
