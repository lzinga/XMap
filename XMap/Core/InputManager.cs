using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

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


        private IntPtr CurrentWindow()
        {
            return GetForegroundWindow();
        }


        public void SendKey(string text)
        {
            var sim = new InputSimulator();
            sim.Keyboard.TextEntry(text);
            sim.Keyboard.KeyDown(VirtualKeyCode.RETURN);

        }

        public string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                Console.WriteLine(Buff.ToString());
                return Buff.ToString();
            }
            return null;
        }
    }
}
