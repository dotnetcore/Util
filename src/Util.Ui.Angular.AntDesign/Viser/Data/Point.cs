using Newtonsoft.Json.Linq;

namespace Util.Ui.Viser.Data {
    /// <summary>
    /// 图表中的点
    /// </summary>
    public class Point {
        /// <summary>
        /// 初始化图表中的点
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public Point( string name, object value ) {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// 转换为Json属性
        /// </summary>
        public JProperty ToJProperty() {
            return new JProperty( Name, Value );
        }
    }
}
