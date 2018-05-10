using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using XMap.Common;

namespace XMap.Core
{
    public class InputManager
    {
        #region Imports
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        #endregion

        #region Private Fields
        InputSimulator input;
        #endregion



        public InputManager()
        {
            input = new InputSimulator();
        }

        private IntPtr CurrentWindow()
        {
            return GetForegroundWindow();
        }


        public void KeyDown(Keys key)
        {
            var vKey = this.ToVKey(key);
            input.Keyboard.KeyDown(vKey);
        }

        public void Text(string str)
        {
            input.Keyboard.TextEntry(str);
        }


        private VirtualKeyCode ToVKey(Keys key)
        {
            return (VirtualKeyCode)((int)key);
        }

        public string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }

            return null;
        }
    }
}
