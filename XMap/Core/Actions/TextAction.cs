﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsInput.Native;

namespace XMap.Core.Actions
{
    [XmlType(TypeName = "Text")]
    public class TextAction : BaseAction
    {
        [XmlAttribute]
        public string Key { get; set; }

        public override void Execute(XInputController controller)
        {
            this.input.Text(this.Key);
        }

        public override string ToString()
        {
            return $"Writing \"{this.Key}\".";
        }
    }
}
