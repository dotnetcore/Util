using System;
using Newtonsoft.Json.Linq;

namespace Util.Ui.Viser.Data {
    /// <summary>
    /// 图表中的点
    /// </summary>
    public class Point {
        /// <summary>
        /// 图表项
        /// </summary>
        private ChartItem _item;

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
        /// 设置图表项
        /// </summary>
        /// <param name="item">图表项</param>
        public void SetChartItem( ChartItem item ) {
            _item = item;
        }

        /// <summary>
        /// 转换为Json属性
        /// </summary>
        public JProperty ToJProperty() {
            return new JProperty( Name,Util.Helpers.Convert.ToDoubleOrNull( Value ) );
        }

        /// <summary>
        /// 转换为柱状图Json属性
        /// </summary>
        public JProperty ToColumnJProperty() {
            if( _item == null )
                throw new ArgumentNullException();
            return new JProperty( _item.Name, Util.Helpers.Convert.ToDoubleOrNull( Value ) );
        }
    }
}
