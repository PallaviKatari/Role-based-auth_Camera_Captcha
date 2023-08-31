using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Role_based_auth.Models
{
    public class RECaptcha
    {
        public string Key = "6LeeTesnAAAAAGllQtdAYuld_StcjTuQbbgvNrsT";

        public string Secret = "6LeeTesnAAAAAEABxStL8kQKOhvrE3Ymi5Uz_xLF";
        public string Response { get; set; }
    }
}