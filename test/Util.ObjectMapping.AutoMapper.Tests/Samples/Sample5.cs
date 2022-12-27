namespace Util.ObjectMapping.AutoMapper.Tests.Samples {
    /// <summary>
    /// 样例5
    /// </summary>
    public class Sample5 {
        public string Name { get; set; }
        public Sample6 Sample61 { get; set; }
    }

    /// <summary>
    /// 样例转换5
    /// </summary>
    public class Sample5to {
        public string Name { get; set; }
        public Sample6to Sample61 { get; set; }
    }
}