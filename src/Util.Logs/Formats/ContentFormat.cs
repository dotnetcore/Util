using System.Collections.Generic;
using System.Text;
using Util.Helpers;
using Util.Logs.Core;
using Util.Logs.Formats.Lines;

namespace Util.Logs.Formats {
    /// <summary>
    /// 内容格式化器
    /// </summary>
    public class ContentFormat : ILogFormat {
        /// <summary>
        /// 行号
        /// </summary>
        private int _line;

        /// <summary>
        /// 初始化内容格式化器
        /// </summary>
        public ContentFormat() {
            InitLine();
        }

        /// <summary>
        /// 初始化行号
        /// </summary>
        private void InitLine() {
            _line = 1;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="logContent">日志内容</param>
        public string Format( ILogContent logContent ) {
            var content = logContent as Content;
            if( content == null )
                return string.Empty;
            return Format( content );
        }

        /// <summary>
        /// 格式化
        /// </summary>
        private string Format( Content content ) {
            StringBuilder result = new StringBuilder();
            GetFormats().ForEach( t => {
                result.AppendFormat( "{0}. ", _line++ );
                t.Format( result, content );
                result.Append( Common.Line );
            } );
            Finish( result );
            return result.ToString();
        }

        /// <summary>
        /// 获取格式化器集合
        /// </summary>
        private List<FormatBase> GetFormats() {
            return new List<FormatBase> {
                new TitleFormat()
            };
        }

        /// <summary>
        /// 结束
        /// </summary>
        private void Finish( StringBuilder result ) {
            for( int i = 0; i < 125; i++ )
                result.Append( "-" );
            InitLine();
        }
    }
}
