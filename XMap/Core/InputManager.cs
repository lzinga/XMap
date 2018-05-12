using System;
using System.Collections.Generic;
using System.Linq;
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
            var vKey = ToVKey(key);
            input.Keyboard.KeyDown(vKey);
        }

        public void KeyDownWithModifier(IEnumerable<ModifierKeys> modifier, IEnumerable<Keys> keys)
        {
            var mod = modifier.Select(i => ToVKey(i));
            var key = keys.Select(i => ToVKey(i));

            input.Keyboard.ModifiedKeyStroke(mod, key);
        }

        public void Text(string str)
        {
            input.Keyboard.TextEntry(str);
        }

        public static VirtualKeyCode ToVKey(Keys key)
        {
            return (VirtualKeyCode)((int)key);
        }

        public static VirtualKeyCode ToVKey(ModifierKeys key)
        {
            return (VirtualKeyCode)((int)key);
        }


    }
}
