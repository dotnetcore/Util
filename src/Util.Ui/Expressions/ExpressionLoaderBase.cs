using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Configs;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 表达式加载器
    /// </summary>
    public abstract class ExpressionLoaderBase : IExpressionLoader {
        /// <summary>
        /// 表达式解析器
        /// </summary>
        private readonly IExpressionResolver _resolver;

        /// <summary>
        /// 初始化表达式加载器
        /// </summary>
        /// <param name="resolver">表达式解析器</param>
        protected ExpressionLoaderBase( IExpressionResolver resolver ) {
            _resolver = resolver;
        }

        /// <inheritdoc />
        public void Load( Config config, string expressionPropertyName = "for" ) {
            if ( config == null )
                return;
            if ( config.Contains( expressionPropertyName ) == false )
                return;
            var expression = config.GetValue<ModelExpression>( expressionPropertyName );
            var info =  _resolver.Resolve( expression );
            LoadName( config, info );
        }

        /// <summary>
        /// 加载属性名
        /// </summary>
        protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Name,info.Name );
        }
    }
}
