using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Util.Ui.Viser.Data {
    /// <summary>
    /// 图表项
    /// </summary>
    public class ChartItem {
        /// <summary>
        /// 点列表
        /// </summary>
        private readonly List<Point> _points;

        /// <summary>
        /// 初始化图表项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public ChartItem( string name, object value ) {
            Name = name;
            _points = new List<Point>();
            AddPoint( "value", value );
        }

        /// <summary>
        /// 初始化图表项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="points">点列表</param>
        public ChartItem( string name, params Point[] points ) {
            Name = name;
            _points = new List<Point>();
            AddPoint( points );
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 点列表
        /// </summary>
        public IReadOnlyList<Point> Points => _points;

        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public ChartItem AddPoint( string name, object value ) {
            if( name.IsEmpty() || value.SafeString().IsEmpty() )
                return this;
            return AddPoint( new Point( name, value ) );
        }

        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="point">点</param>
        public ChartItem AddPoint( Point point ) {
            if( point == null )
                return this;
            point.SetChartItem( this );
            _points.Add( point );
            return this;
        }

        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="points">点列表</param>
        public ChartItem AddPoint( IEnumerable<Point> points ) {
            if( points == null )
                return this;
            foreach ( var point in points )
                AddPoint( point );
            return this;
        }

        /// <summary>
        /// 转换为JObject
        /// </summary>
        public JObject ToJObject() {
            var result = new JObject();
            var item = new JProperty( "name", Name );
            result.Add( item );
            GetValueProperties().ForEach( result.Add );
            return result;
        }

        /// <summary>
        /// 获取值Json属性集合
        /// </summary>
        private List<JProperty> GetValueProperties() {
            var result = new List<JProperty>();
            result.AddRange( Points.Select( t => t.ToJProperty() ) );
            return result;
        }
    }
}
