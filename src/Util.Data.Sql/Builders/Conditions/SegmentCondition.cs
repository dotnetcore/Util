using System;
using System.Text;
using Util.Data.Queries;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders.Conditions {
    /// <summary>
    /// 范围过滤条件
    /// </summary>
    public class SegmentCondition : ISqlCondition {
        /// <summary>
        /// Sql参数管理器
        /// </summary>
        protected readonly IParameterManager ParameterManager;
        /// <summary>
        /// 列名
        /// </summary>
        protected readonly string Column;
        /// <summary>
        /// 最小值
        /// </summary>
        protected readonly object MinValue;
        /// <summary>
        /// 最大值
        /// </summary>
        protected readonly object MaxValue;
        /// <summary>
        /// 包含边界
        /// </summary>
        protected Boundary Boundary;
        /// <summary>
        /// 是否参数化
        /// </summary>
        protected readonly bool IsParameterization;

        /// <summary>
        /// 初始化范围过滤条件
        /// </summary>
        /// <param name="parameterManager">Sql参数管理器</param>
        /// <param name="column">列名</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <param name="boundary">包含边界</param>
        /// <param name="isParameterization">是否参数化</param>
        public SegmentCondition( IParameterManager parameterManager, string column, object minValue, object maxValue, Boundary boundary, bool isParameterization ) {
            ParameterManager = parameterManager ?? throw new ArgumentNullException( nameof( parameterManager ) );
            if( string.IsNullOrWhiteSpace( column ) )
                throw new ArgumentNullException( nameof( column ) );
            Column = column;
            MinValue = minValue;
            MaxValue = maxValue;
            Boundary = boundary;
            IsParameterization = isParameterization;
        }

        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        public void AppendTo( StringBuilder builder ) {
            new AndCondition( CreateLeftCondition(), CreateRightCondition() ).AppendTo( builder );
        }

        /// <summary>
        /// 创建左条件
        /// </summary>
        private ISqlCondition CreateLeftCondition() {
            if( string.IsNullOrWhiteSpace( MinValue.SafeString() ) )
                return NullCondition.Instance;
            switch( Boundary ) {
                case Boundary.Left:
                    return new GreaterEqualCondition( ParameterManager, Column, MinValue, IsParameterization );
                case Boundary.Both:
                    return new GreaterEqualCondition( ParameterManager, Column, MinValue, IsParameterization );
                default:
                    return new GreaterCondition( ParameterManager, Column, MinValue, IsParameterization );
            }
        }

        /// <summary>
        /// 创建右条件
        /// </summary>
        private ISqlCondition CreateRightCondition() {
            if( string.IsNullOrWhiteSpace( MaxValue.SafeString() ) )
                return NullCondition.Instance;
            switch( Boundary ) {
                case Boundary.Right:
                    return new LessEqualCondition( ParameterManager, Column, MaxValue, IsParameterization );
                case Boundary.Both:
                    return new LessEqualCondition( ParameterManager, Column, MaxValue, IsParameterization );
                default:
                    return new LessCondition( ParameterManager, Column, MaxValue, IsParameterization );
            }
        }
    }
}
