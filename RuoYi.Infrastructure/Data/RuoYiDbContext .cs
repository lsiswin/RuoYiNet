using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RuoYi.Domain.Entities.Auth;
using RuoYi.Domain.Entities.System;

namespace RuoYi.Infrastructure.Data
{
    public class RuoYiDbContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>,
    UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public RuoYiDbContext(DbContextOptions<RuoYiDbContext> options) : base(options)
        {
        }

        // 业务实体
        //public DbSet<Menu> Menus { get; set; }
        public DbSet<Dept> Depts { get; set; }
        //public DbSet<Dict> Dicts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<RoleDept> RoleDepts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 应用所有配置
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // 自定义表名
            ConfigureIdentityTableNames(builder);
        }

        private static void ConfigureIdentityTableNames(ModelBuilder builder)
        {
            // 自定义Identity表名，符合若依命名规范
            builder.Entity<User>().ToTable("sys_user");
            builder.Entity<Role>().ToTable("sys_role");
            builder.Entity<UserRole>().ToTable("sys_user_role");
            builder.Entity<IdentityUserClaim<long>>().ToTable("sys_user_claims");
            builder.Entity<IdentityUserLogin<long>>().ToTable("sys_user_logins");
            builder.Entity<IdentityUserToken<long>>().ToTable("sys_user_tokens");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("sys_role_claims");
        }
    }
}
