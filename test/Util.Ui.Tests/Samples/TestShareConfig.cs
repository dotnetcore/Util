namespace Util.Ui.Tests.Samples {
    /// <summary>
    /// 测试共享配置
    /// </summary>
    public class TestShareConfig {
        /// <summary>
        /// 初始化测试共享配置
        /// </summary>
        /// <param name="id">标识</param>
        public TestShareConfig( string id ) {
            Id = id;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
    }
}