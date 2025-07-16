using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Common.Enums
{
    public enum DataScope
    {
        [Description("全部数据权限")]
        All = 1,

        [Description("自定数据权限")]
        Custom = 2,

        [Description("部门数据权限")]
        Dept = 3,

        [Description("部门及以下数据权限")]
        DeptAndBelow = 4,

        [Description("仅本人数据权限")]
        Self = 5
    }
}
