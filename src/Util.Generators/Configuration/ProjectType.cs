namespace Util.Generators.Configuration {
    /// <summary>
    /// 项目类型
    /// </summary>
    public enum ProjectType {
        /// <summary>
        /// 生成Web API相关的项目,不生成UI
        /// </summary>
        WebApi,
        /// <summary>
        /// 生成UI,包含Web API项目
        /// </summary>
        Ui
    }
}
