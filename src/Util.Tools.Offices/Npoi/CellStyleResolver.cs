using NPOI.SS.UserModel;
using Util.Helpers;

namespace Util.Tools.Offices.Npoi {
    /// <summary>
    /// 单元格样式解析器
    /// </summary>
    public class CellStyleResolver {
        /// <summary>
        /// 初始化单元格样式解析器
        /// </summary>
        /// <param name="workbook">工作薄</param>
        /// <param name="style">单元格样式</param>
        private CellStyleResolver( IWorkbook workbook,CellStyle style ) {
            _workbook = workbook;
            _style = style;
        }

        /// <summary>
        /// 工作薄
        /// </summary>
        private readonly IWorkbook _workbook;
        /// <summary>
        /// 单元格样式
        /// </summary>
        private readonly CellStyle _style;
        /// <summary>
        /// 单元格样式
        /// </summary>
        private ICellStyle _result;

        /// <summary>
        /// 解析为Npoi单元格样式
        /// </summary>
        public ICellStyle Resolve() {
            _result = _workbook.CreateCellStyle();
            _result.Alignment = GetHorizontalAlignment();
            _result.VerticalAlignment = GetVerticalAlignment();
            SetBackgroundColor();
            SetFillPattern();
            SetBorderColor();
            SetFont();
            _result.WrapText = _style.IsWrap;
            return _result;
        }

        /// <summary>
        /// 获取水平对齐
        /// </summary>
        private NPOI.SS.UserModel.HorizontalAlignment GetHorizontalAlignment() {
            if ( _style.Alignment == Core.HorizontalAlignment.Left )
                return HorizontalAlignment.Left;
            if ( _style.Alignment == Core.HorizontalAlignment.Right )
                return HorizontalAlignment.Right;
            return HorizontalAlignment.Center;
        }

        /// <summary>
        /// 获取垂直对齐
        /// </summary>
        private VerticalAlignment GetVerticalAlignment() {
            if ( _style.VerticalAlignment == Core.VerticalAlignment.Top )
                return VerticalAlignment.Top;
            if ( _style.VerticalAlignment == Core.VerticalAlignment.Bottom )
                return VerticalAlignment.Bottom;
            return VerticalAlignment.Center;
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        private void SetBackgroundColor() {
            _result.FillForegroundColor = ColorResolver.Resolve( _style.BackgroundColor );
        }

        /// <summary>
        /// 设置填充模式
        /// </summary>
        private void SetFillPattern() {
            _result.FillPattern = Enum.Parse<FillPattern>( _style.FillPattern );
        }

        /// <summary>
        /// 设置边框颜色
        /// </summary>
        private void SetBorderColor() {
            _result.BorderTop = BorderStyle.Thin;
            _result.BorderRight = BorderStyle.Thin;
            _result.BorderBottom = BorderStyle.Thin;
            _result.BorderLeft = BorderStyle.Thin;
            _result.TopBorderColor = ColorResolver.Resolve( _style.BorderColor );
            _result.RightBorderColor = ColorResolver.Resolve( _style.BorderColor );
            _result.BottomBorderColor = ColorResolver.Resolve( _style.BorderColor );
            _result.LeftBorderColor = ColorResolver.Resolve( _style.BorderColor );
        }

        /// <summary>
        /// 设置字体
        /// </summary>
        private void SetFont() {
            var font = _workbook.CreateFont();
            font.FontHeightInPoints = _style.FontSize;
            font.Color = ColorResolver.Resolve( _style.FontColor );
            font.Boldweight = _style.FontBoldWeight;
            _result.SetFont( font );
        }

        /// <summary>
        /// 解析单元格样式
        /// </summary>
        /// <param name="workbook">工作薄</param>
        /// <param name="style">单元格样式</param>
        public static ICellStyle Resolve( IWorkbook workbook,CellStyle style ) {
            return new CellStyleResolver( workbook, style ).Resolve();
        }
    }
}
