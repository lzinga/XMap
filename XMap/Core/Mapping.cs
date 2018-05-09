using Newtonsoft.Json;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMap.Core
{
    public class Mapping
    {
        [JsonProperty("input")]
        public GamepadButtonFlags Input { get; set; }

        [JsonProperty("macro")]
        public Macro Macro { get; set; }

        [JsonProperty("hold")]
        public TimeSpan? Hold { get; set; }
    }

    public class Macro
    {

    }
}
