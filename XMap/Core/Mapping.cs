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
using XMap.Core.Actions;

namespace XMap.Core
{
    [XmlRoot]
    public class Mapping
    {
        [XmlElement(ElementName = "Macro")]
        public List<Macro>  Macros { get; set; }
    }

    [XmlInclude(typeof(TextAction))]
    [XmlInclude(typeof(KeyAction))]
    public class Macro
    {
        [XmlAttribute]
        public string OnKeyDown { get; set; }

        [XmlAttribute]
        public int HoldTime { get; set; }

        [XmlElement(ElementName = "Action")]
        public List<BaseAction> Actions { get; set; }

        public override string ToString()
        {
            if(HoldTime != 0)
            {
                return $"\"{this.OnKeyDown}\" was held down for {this.HoldTime} seconds, executing {this.Actions.Count()} macro actions.";
            }

            return $"\"{this.OnKeyDown}\" was pressed, executing {this.Actions.Count()} macro actions.";
        }
    }
}
