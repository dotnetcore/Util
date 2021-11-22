using System;
using System.Linq.Expressions;
using Util.Data.EntityFrameworkCore.Models;

namespace Util.Data.EntityFrameworkCore.Conditions {
    /// <summary>
    /// 产品名称查询条件
    /// </summary>
    public class ProductNameCondition : ICondition<Product> {
        /// <summary>
        /// 产品名称
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// 初始化产品名称查询条件
        /// </summary>
        /// <param name="name">产品名称</param>
        public ProductNameCondition( string name ) {
            _name = name;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public Expression<Func<Product, bool>> GetCondition() {
            return t => t.Name == _name;
        }
    }
}
