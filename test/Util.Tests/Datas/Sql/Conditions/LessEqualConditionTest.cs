﻿using Util.Datas.Sql.Queries.Builders.Conditions;
using Xunit;

namespace Util.Tests.Datas.Sql.Conditions {
    /// <summary>
    /// Sql小于等于查询条件测试
    /// </summary>
    public class LessEqualConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test() {
            var condition = new LessEqualCondition( "Age", "@Age" );
            Assert.Equal( "Age<=@Age", condition.GetCondition() );
        }
    }
}