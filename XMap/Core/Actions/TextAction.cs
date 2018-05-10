using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsInput.Native;

namespace XMap.Core.Actions
{
    public class TextAction : BaseAction
    {
        [XmlAttribute]
        public string Text { get; set; }

        public override void Execute()
        {
            this.input.Text(this.Text);
        }

        public override string ToString()
        {
            return $"Writing \"{this.Text}\".";
        }
    }
}
