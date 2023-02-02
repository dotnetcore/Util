namespace Util.Templates.Razor.Helpers {
    /// <summary>
    /// HtmlHelper
    /// </summary>
    public class HtmlHelper {
        /// <summary>
        /// Razor模板引擎
        /// </summary>
        private readonly ITemplateEngine _engine;

        /// <summary>
        /// 初始化HtmlHelper
        /// </summary>
        /// <param name="engine">Razor模板引擎</param>
        public HtmlHelper( ITemplateEngine engine ) {
            _engine = engine;
        }

        /// <summary>
        /// 引用部分视图
        /// </summary>
        public string Partial( string partialViewName, object model ) {
            var path = Util.Helpers.Common.GetPhysicalPath( partialViewName );
            return _engine.RenderByPath( path, model );
        }

        /// <summary>
        /// 引用部分视图
        /// </summary>
        public string PartialAsync( string partialViewName, object model ) {
            return Partial( partialViewName, model );
        }
    }
}
