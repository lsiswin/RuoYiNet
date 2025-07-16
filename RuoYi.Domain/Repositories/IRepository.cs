using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities;

namespace RuoYi.Domain.Repositories
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
        /// <summary>
        /// 获取工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <returns>实体</returns>
        Task<T> GetByIdAsync(long id);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体集合</returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>实体集合</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task AddAsync(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// 根据ID删除实体
        /// </summary>
        /// <param name="id">实体ID</param>
        Task DeleteAsync(long id);

        /// <summary>
        /// 检查是否存在满足条件的实体
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>是否存在</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取满足条件的实体数量
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>实体数量</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
