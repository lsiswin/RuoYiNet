using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RuoYi.Common.Enums;
using RuoYi.Domain.Entities.System;

namespace RuoYi.Domain.Entities.Auth
{
    /// <summary>
    /// 用户聚合根
    /// </summary>
    public class User : IdentityUser<long>, IAggregateRoot
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public long? CreatedBy { get; private set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifiedTime { get; private set; }

        /// <summary>
        /// 最后修改者ID
        /// </summary>
        public long? LastModifiedBy { get; private set; }

        /// <summary>
        /// 是否删除（软删除标记）
        /// </summary>
        public bool IsDeleted { get; private set; } = false;

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletedTime { get; private set; }

        /// <summary>
        /// 删除者ID
        /// </summary>
        public long? DeletedBy { get; private set; }

        /// <summary>
        /// 版本号（用于乐观并发控制）
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// 用户的业务属性
        /// </summary>
        public string FullName { get; private set; }
        public string Avatar { get; private set; }
        public string Department { get; private set; }
        public string Position { get; private set; }
        public int Sex { get; private set; }
        public int Status { get; private set; }
        public DateTime? LastLoginTime { get; private set; }
        public string LastLoginIp { get; private set; }
        public string Remark { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public User()
        {
            CreatedTime = DateTime.UtcNow;
            Version = 1;
        }

        /// <summary>
        /// 创建用户的工厂方法
        /// </summary>
        public static User Create(
            string userName,
            string email,
            string fullName,
            string phoneNumber = null,
            string department = null,
            string position = null,
            int sex = 0,
            string avatar = null,
            string remark = null)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("用户名不能为空", nameof(userName));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("邮箱不能为空", nameof(email));

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("姓名不能为空", nameof(fullName));

            return new User
            {
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = false,
                FullName = fullName,
                PhoneNumber = phoneNumber,
                PhoneNumberConfirmed = !string.IsNullOrWhiteSpace(phoneNumber),
                Department = department,
                Position = position,
                Sex = sex,
                Status = 0, // 默认正常状态
                Avatar = avatar,
                Remark = remark,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
        }

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        public void UpdateBasicInfo(
            string fullName,
            string phoneNumber,
            string email,
            string department,
            string position,
            int sex,
            string avatar,
            string remark,
            long? modifiedBy = null)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("姓名不能为空", nameof(fullName));

            FullName = fullName;

            if (!string.IsNullOrWhiteSpace(phoneNumber) && PhoneNumber != phoneNumber)
            {
                PhoneNumber = phoneNumber;
                PhoneNumberConfirmed = false;
            }

            if (!string.IsNullOrWhiteSpace(email) && Email != email)
            {
                Email = email;
                NormalizedEmail = email.ToUpper();
                EmailConfirmed = false;
            }

            Department = department;
            Position = position;
            Sex = sex;
            Avatar = avatar;
            Remark = remark;

            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        public void Enable(long? modifiedBy = null)
        {
            Status = 0;
            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        public void Disable(long? modifiedBy = null)
        {
            Status = 1;
            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 记录登录信息
        /// </summary>
        public void RecordLogin(string ip)
        {
            LastLoginTime = DateTime.UtcNow;
            LastLoginIp = ip;
            UpdateModificationInfo();
        }

        /// <summary>
        /// 标记实体为已删除
        /// </summary>
        public void MarkAsDeleted(long? deletedBy = null)
        {
            IsDeleted = true;
            DeletedTime = DateTime.UtcNow;
            DeletedBy = deletedBy;
            IncrementVersion();
        }

        /// <summary>
        /// 更新实体修改信息
        /// </summary>
        public void UpdateModificationInfo(long? modifiedBy = null)
        {
            LastModifiedTime = DateTime.UtcNow;
            LastModifiedBy = modifiedBy;
            IncrementVersion();
        }

        /// <summary>
        /// 增加版本号
        /// </summary>
        private void IncrementVersion()
        {
            Version++;
        }
    }
}
