using System;

namespace Util.Ui {
    /// <summary>
    /// 模型绑定
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public class ModelAttribute : Attribute {
        /// <summary>
        /// 初始化模型绑定
        /// </summary>
        /// <param name="model">模型</param>
        public ModelAttribute( string model ) {
            Model = model;
        }

        /// <summary>
        /// 模型
        /// </summary>
        public string Model { get; set; }
    }
}
