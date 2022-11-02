using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Configs;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 表达式加载器
    /// </summary>
    public abstract class ExpressionLoaderBase : IExpressionLoader {
        /// <inheritdoc />
        public virtual void Load( Config config, string expressionPropertyName = "for" ) {
            if ( config == null )
                return;
            if ( config.Contains( expressionPropertyName ) == false )
                return;
            var info = ResolveModelExpression( config, expressionPropertyName );
            Load( config, info );
        }

        /// <summary>
        /// 解析模型表达式
        /// </summary>
        protected virtual ModelExpressionInfo ResolveModelExpression( Config config, string expressionPropertyName ) {
            var expression = config.GetValue<ModelExpression>( expressionPropertyName );
            var resolver = CreateExpressionResolver( config );
            return resolver.Resolve( expression );
        }

        /// <summary>
        /// 创建模型表达式解析器
        /// </summary>
        /// <param name="config">配置</param>
        protected virtual IExpressionResolver CreateExpressionResolver( Config config ) {
            return new ExpressionResolver();
        }

        /// <summary>
        /// 加载模型信息
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="info">模型表达式信息</param>
        protected virtual void Load( Config config, ModelExpressionInfo info ) {
        }
    }
}
