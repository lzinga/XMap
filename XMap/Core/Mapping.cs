using System.Collections.Generic;
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

    public class Macro
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArrayItem("Condition")]
        public List<BaseCondition> Conditions { get; set; }

        [XmlArrayItem("Action")]
        public List<BaseAction> Actions { get; set; }

        [XmlIgnore]
        public bool IsRunning { get; set; }

        [XmlIgnore]
        public bool HasHoldCondition
        {
            get
            {
                return this.Conditions.Any(i => i.GetType() == typeof(HoldCondition));
            }
        }
    }
}
