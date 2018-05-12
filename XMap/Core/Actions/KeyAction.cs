using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Actions
{
    [XmlType(TypeName = "Key")]
    public class KeyAction : BaseAction
    {
        [XmlAttribute]
        public string Modifier { get; set; }

        [XmlAttribute]
        public string Key { get; set; }

        public override void Execute(XInputController controller)
        {

            List<ModifierKeys> modifiers = new List<ModifierKeys>();
            var elements = Modifier.Split(',');
            foreach(var modifier in elements)
            {
                ModifierKeys result;
                if (Enum.TryParse(modifier, out result))
                {
                    modifiers.Add(result);
                }
            }

            List<Keys> keys = new List<Keys>();
            var elements2 = Key.Split(',');
            foreach (var key in elements2)
            {
                Keys result;
                if (Enum.TryParse(key, out result))
                {
                    keys.Add(result);
                }
            }

            this.input.KeyDownWithModifier(modifiers, keys);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Modifier))
            {
                return $"\"{this.Key}\" pressed.";
            }


            return $"\"{this.Key}\" pressed with modifier of \"{this.Modifier}\".";
        }
    }
}
