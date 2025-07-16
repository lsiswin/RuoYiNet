using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Common.Enums
{
    /// <summary>
    /// 部门状态枚举
    /// </summary>
    public enum DeptStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,

        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Disabled = 1
    }
}
