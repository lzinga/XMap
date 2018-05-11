﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using XMap.Core.Actions;
using XMap.Core.Conditions;

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
    [XmlInclude(typeof(ButtonsPressed))]
    public class Macro
    {

        [XmlAttribute]
        public string OnKeyDown { get; set; }

        [XmlAttribute]
        public string ActiveProcess { get; set; }

        [XmlAttribute]
        public int HoldTime { get; set; }

        [XmlArrayItem("Condition")]
        public List<BaseCondition> Conditions { get; set; }

        [XmlArrayItem("Action")]
        public List<BaseAction> Actions { get; set; }

        public override string ToString()
        {
            if(HoldTime != 0)
            {
                return $"\"{this.OnKeyDown}\" was held down for {this.HoldTime} seconds, trying to execute {this.Actions.Count()} macro actions.";
            }

            return $"\"{this.OnKeyDown}\" was pressed, trying to execute {this.Actions.Count()} macro actions.";
        }
    }
}
