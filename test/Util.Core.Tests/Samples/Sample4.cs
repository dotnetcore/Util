namespace Util.Tests.Samples {
    /// <summary>
    /// 测试样例4
    /// </summary>
    public class Sample4 {
        /// <summary>
        /// string值
        /// </summary>
        public string StringValue { get; set; }

        /// <summary>
        /// 输出空字符串
        /// </summary>
        public override string ToString() {
            return "";
        }

        /// <summary>
        /// 获取副本
        /// </summary>
        public object GetClone() {
            return MemberwiseClone();
        }
    }
}
