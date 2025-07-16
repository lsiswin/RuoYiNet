using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Common.Enums;

namespace RuoYi.Domain.Entities.Auth
{
    public class UserProfile : BaseEntity
    {
        public long UserId { get; set; }
        public string? RealName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        // 导航属性
        public virtual User User { get; set; } = null!;
    }
}
