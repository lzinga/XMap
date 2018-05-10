using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Actions
{
    public class KeyAction : BaseAction
    {
        [XmlAttribute]
        public string Modifier { get; set; }

        [XmlAttribute]
        public Keys Key { get; set; }

        public override void Execute()
        {
            this.input.KeyDown(this.Key);
        }

        public override string ToString()
        {
            return $"\"{this.Key}\" pressed with modifier of \"{this.Modifier}\"";
        }
    }
}
