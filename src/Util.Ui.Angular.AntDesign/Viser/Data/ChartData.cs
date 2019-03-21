using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Util.Ui.Viser.Data {
    /// <summary>
    /// 图表数据
    /// </summary>
    public class ChartData {
        /// <summary>
        /// Json项集合
        /// </summary>
        private readonly List<ChartItem> _items;

        /// <summary>
        /// 初始化图表数据
        /// </summary>
        public ChartData() {
            _items = new List<ChartItem>();
        }

        /// <summary>
        /// 是否排序
        /// </summary>
        public bool IsOrder { get; set; } = true;

        /// <summary>
        /// 集合数目限制，默认值： 100
        /// </summary>
        public int Limit { get; set; } = 100;

        /// <summary>
        /// 添加图表项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public ChartData Add<TValue>( string name, TValue value ) {
            if( name.IsEmpty() )
                return this;
            _items.Add( new ChartItem( name, value ) );
            return this;
        }

        /// <summary>
        /// 添加图表项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="points">点列表</param>
        public ChartData Add( string name, params Point[] points ) {
            if( name.IsEmpty() || points == null )
                return this;
            var item = new ChartItem( name, points );
            _items.Add( item );
            return this;
        }

        /// <summary>
        /// 添加图表项列表
        /// </summary>
        /// <param name="items">图表项列表</param>
        public ChartData Add( params ChartItem[] items ) {
            if( items == null )
                return this;
            _items.AddRange( items );
            return this;
        }

        /// <summary>
        /// 添加图表项列表
        /// </summary>
        /// <param name="items">图表项列表</param>
        public ChartData Add( IEnumerable<ChartItem> items ) {
            if( items == null )
                return this;
            _items.AddRange( items );
            return this;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public JObject ToResult() {
            return new JObject {
                CreateColumns(),
                CreateData()
            };
        }

        /// <summary>
        /// 创建列集合属性
        /// </summary>
        private JProperty CreateColumns() {
            return new JProperty( "columns", _items.SelectMany( t => t.Points.Select( p => p.Name ) ).Distinct().ToList() );
        }

        /// <summary>
        /// 创建数据属性
        /// </summary>
        protected virtual JProperty CreateData() {
            var jArray = new JArray();
            GetItems().ForEach( item => jArray.Add( item.ToJObject() ) );
            return new JProperty( "data", jArray );
        }

        /// <summary>
        /// 获取项列表
        /// </summary>
        protected virtual List<ChartItem> GetItems() {
            var list = _items.Where( t => t.Points.Any() );
            if( IsOrder )
                return list.OrderBy( t => t.Points[0].Value.SafeString().ToDecimal() ).Take( Limit ).ToList();
            return list.Take( Limit ).ToList();
        }

        /// <summary>
        /// 获取柱状图结果
        /// </summary>
        public JObject ToColumnResult() {
            return new JObject {
                CreateColumnColumns(),
                CreateColumnData()
            };
        }

        /// <summary>
        /// 创建柱状图列集合属性
        /// </summary>
        private JProperty CreateColumnColumns() {
            return new JProperty( "columns", _items.Select( t => t.Name ).Distinct().ToList() );
        }

        /// <summary>
        /// 创建柱状图数据属性
        /// </summary>
        private JProperty CreateColumnData() {
            var jArray = new JArray();
            var groups = _items.SelectMany( t => t.Points ).GroupBy( t => t.Name ).ToList();
            foreach( var @group in groups ) {
                var jObject = new JObject { { "name", @group.Key } };
                GetPoints( @group ).ForEach( t => jObject.Add( t.ToColumnJProperty() ) );
                jArray.Add( jObject );
            }
            return new JProperty( "data", jArray );
        }

        /// <summary>
        /// 获取点列表
        /// </summary>
        protected virtual List<Point> GetPoints( IGrouping<string, Point> grouping ) {
            var list = grouping.ToList();
            if( IsOrder )
                return list.OrderBy( t => t.Value.SafeString().ToDecimal() ).Take( Limit ).ToList();
            return list.Take( Limit ).ToList();
        }
    }
}
