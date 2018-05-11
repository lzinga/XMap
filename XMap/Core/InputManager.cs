using System;
using System.Runtime.InteropServices;
using System.Text;
using WindowsInput;
using WindowsInput.Native;
using XMap.Common;

namespace XMap.Core
{
    public class InputManager
    {


        #region Private Fields
        InputSimulator input;
        #endregion



        public InputManager()
        {
            input = new InputSimulator();
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


    }
}
