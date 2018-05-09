using Newtonsoft.Json;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsInput.Native;
using XMap.Common;

namespace XMap.Core
{
    [XmlRoot]
    public class Mapping
    {
        [XmlElement(ElementName = "Macro")]
        public List<Macro>  Macros { get; set; }
    }

    [XmlInclude(typeof(KeyAction))]
    public class Macro
    {
        [XmlAttribute]
        public string OnKeyDown { get; set; }

        [XmlAttribute]
        public int? HoldTime { get; set; }

        [XmlElement(ElementName = "Action")]
        public List<BaseAction> Actions { get; set; }
    }

    public interface IAction
    {
        void Execute();
    }

    public class BaseAction : IAction
    {
        [XmlAttribute]
        public ActionType Type { get; set; }

        public virtual void Execute()
        {
        }
    }

    public class KeyAction : BaseAction
    {
        [XmlAttribute]
        public string Modifier { get; set; }

        [XmlAttribute]
        public string Key { get; set; }

        public override void Execute()
        {
            VirtualKeyCode key;
            if (Enum.TryParse<VirtualKeyCode>(this.Key, out key))
            {
                InputManager manager = new InputManager();
                manager.KeyDown(key);
            }
            else
            {
                throw new InvalidOperationException();
            }

        }
    }

}
