using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.System;

namespace RuoYi.Domain.Repositories
{
    /// <summary>
    /// 部门仓储接口
    /// </summary>
    public interface IDeptRepository : IRepository<Dept>
    {
        /// <summary>
        /// 根据部门编码获取部门
        /// </summary>
        /// <param name="code">部门编码</param>
        /// <returns>部门</returns>
        Task<Dept> GetByCodeAsync(string code);

        /// <summary>
        /// 获取子部门
        /// </summary>
        /// <param name="parentId">父部门ID</param>
        /// <returns>子部门集合</returns>
        Task<IEnumerable<Dept>> GetChildrenAsync(long parentId);

        /// <summary>
        /// 获取部门树
        /// </summary>
        /// <param name="parentId">父部门ID，默认为根部门</param>
        /// <returns>部门树</returns>
        Task<IEnumerable<Dept>> GetDeptTreeAsync(long? parentId = null);

        /// <summary>
        /// 获取用户的数据权限部门
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>部门ID集合</returns>
        Task<IEnumerable<long>> GetUserDataScopeDeptIdsAsync(long userId);
    }
}
