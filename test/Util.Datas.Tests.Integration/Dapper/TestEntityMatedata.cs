using System;
using Util.Datas.Matedatas;

namespace Util.Datas.Tests.Dapper {
    /// <summary>
    /// 测试实体元数据
    /// </summary>
    public class TestEntityMatedata : IEntityMatedata {
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetTable( Type entity ) {
            return $"as_{entity.GetType()}";
        }

        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetSchema( Type entity ) {
            return "";
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <param name="property">属性名</param>
        public string GetColumn( Type entity, string property ) {
            if ( property == "DecimalValue" )
                return property;
            return $"t_{property}";
        }
    }
}
