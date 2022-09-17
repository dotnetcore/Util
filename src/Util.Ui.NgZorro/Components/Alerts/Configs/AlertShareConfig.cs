using Util.Helpers;

namespace Util.Ui.NgZorro.Components.Alerts.Configs {
    /// <summary>
    /// 警告提示共享配置
    /// </summary>
    public class AlertShareConfig {
        /// <summary>
        /// 标识
        /// </summary>
        private readonly string _id;

        /// <summary>
        /// 初始化警告提示共享配置
        /// </summary>
        /// <param name="id">标识</param>
        public AlertShareConfig( string id ) {
            _id = id.IsEmpty() ? Id.Create() : id;
        }

        /// <summary>
        /// 是否自动创建ng-template
        /// </summary>
        public bool? IsAutoCreateTemplate { get; set; }

        /// <summary>
        /// 模板标识
        /// </summary>
        public string TemplateId => $"t_{_id}";
    }
}
