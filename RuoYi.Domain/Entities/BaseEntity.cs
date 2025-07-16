using System;
using System.ComponentModel.DataAnnotations;

namespace RuoYi.Domain.Entities
{
        /// <summary>
        /// 所有实体的基类
        /// </summary>
        public abstract class BaseEntity
        {
            /// <summary>
            /// 实体唯一标识
            /// </summary>
            public long Id { get; protected set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime CreatedTime { get; protected set; }

            /// <summary>
            /// 创建者ID
            /// </summary>
            public long? CreatedBy { get; protected set; }

            /// <summary>
            /// 最后修改时间
            /// </summary>
            public DateTime? LastModifiedTime { get; protected set; }

            /// <summary>
            /// 最后修改者ID
            /// </summary>
            public long? LastModifiedBy { get; protected set; }

            /// <summary>
            /// 是否删除（软删除标记）
            /// </summary>
            public bool IsDeleted { get; protected set; } = false;

            /// <summary>
            /// 删除时间
            /// </summary>
            public DateTime? DeletedTime { get; protected set; }

            /// <summary>
            /// 删除者ID
            /// </summary>
            public long? DeletedBy { get; protected set; }

            /// <summary>
            /// 版本号（用于乐观并发控制）
            /// </summary>
            public int Version { get; protected set; }

            protected BaseEntity()
            {
                CreatedTime = DateTime.UtcNow;
                Version = 1;
            }

            /// <summary>
            /// 标记实体为已删除
            /// </summary>
            /// <param name="deletedBy">删除者ID</param>
            public virtual void MarkAsDeleted(long? deletedBy = null)
            {
                IsDeleted = true;
                DeletedTime = DateTime.UtcNow;
                DeletedBy = deletedBy;
                IncrementVersion();
            }

            /// <summary>
            /// 更新实体修改信息
            /// </summary>
            /// <param name="modifiedBy">修改者ID</param>
            public virtual void UpdateModificationInfo(long? modifiedBy = null)
            {
                LastModifiedTime = DateTime.UtcNow;
                LastModifiedBy = modifiedBy;
                IncrementVersion();
            }

            /// <summary>
            /// 增加版本号
            /// </summary>
            protected void IncrementVersion()
            {
                Version++;
            }
        }
    }