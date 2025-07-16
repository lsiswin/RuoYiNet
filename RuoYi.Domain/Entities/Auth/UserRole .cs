using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RuoYi.Domain.Entities.Auth
{
    public class UserRole : IdentityUserRole<long>
    {
        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
