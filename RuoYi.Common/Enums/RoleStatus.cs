using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Common.Enums
{
    public enum RoleStatus
    {
        [Description("正常")]
        Normal = 0,

        [Description("停用")]
        Disabled = 1
    }
}
