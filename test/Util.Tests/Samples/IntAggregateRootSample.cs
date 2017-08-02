using Util.Domains;

namespace Util.Tests.Samples {
    /// <summary>
    /// int聚合根测试样例
    /// </summary>
    public class IntAggregateRootSample : AggregateRoot<IntAggregateRootSample, int> {
        /// <summary>
        /// 初始化int聚合根测试样例
        /// </summary>
        public IntAggregateRootSample()
            : this( 0 ) {
        }

        /// <summary>
        /// 初始化int聚合根测试样例
        /// </summary>
        /// <param name="id">标识</param>
        public IntAggregateRootSample( int id )
            : base( id ) {
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "Id:" + Id + "," );
            AddDescription( "姓名", Name );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( IntAggregateRootSample other ) {
            AddChange( "Name", "IntSampleName", Name, other.Name );
        }
    }
}
