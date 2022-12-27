namespace Util.Templates.Razor.Tests.Samples.Models {
    /// <summary>
    /// 测试模型
    /// </summary>
    public class TestModel {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 模型2
        /// </summary>
        public TestModel2 Model2 { get; set; }
    }

    /// <summary>
    /// 测试模型2
    /// </summary>
    public class TestModel2 {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 模型3
        /// </summary>
        public TestModel3 Model3 { get; set; }
    }

    /// <summary>
    /// 测试模型3
    /// </summary>
    public class TestModel3 {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 测试模型扩展
    /// </summary>
    public static class TestModelExtensions {
        /// <summary>
        /// 获取名称
        /// </summary>
        public static string GetName( this TestModel model ) {
            return model.Name;
        }
    }
}
