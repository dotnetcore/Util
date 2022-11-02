using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Forms.Helpers {
    /// <summary>
    /// 表单共享服务
    /// </summary>
    public class FormShareService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表单共享配置
        /// </summary>
        private readonly FormShareConfig _shareConfig;

        /// <summary>
        /// 初始化表单共享服务
        /// </summary>
        /// <param name="config">配置</param>
        public FormShareService( Config config ) {
            _config = config;
            _shareConfig = new FormShareConfig();
        }

        /// <summary>
        /// 初始化表单共享配置
        /// </summary>
        public void Init() {
            InitFormShareConfig();
            SetAlign();
            SetBindAlign();
            SetGutter();
            SetJustify();
            SetBindJustify();
            SetAutoLabelFor();
            SetLabelSpan();
            SetLabelOffset();
            SetLabelOrder();
            SetLabelPull();
            SetLabelPush();
            SetLabelFlex();
            SetLabelXs();
            SetLabelXsSpan();
            SetLabelXsOffset();
            SetLabelXsOrder();
            SetLabelXsPull();
            SetLabelXsPush();
            SetLabelSm();
            SetLabelSmSpan();
            SetLabelSmOffset();
            SetLabelSmOrder();
            SetLabelSmPull();
            SetLabelSmPush();
            SetLabelMd();
            SetLabelMdSpan();
            SetLabelMdOffset();
            SetLabelMdOrder();
            SetLabelMdPull();
            SetLabelMdPush();
            SetLabelLg();
            SetLabelLgSpan();
            SetLabelLgOffset();
            SetLabelLgOrder();
            SetLabelLgPull();
            SetLabelLgPush();
            SetLabelXl();
            SetLabelXlSpan();
            SetLabelXlOffset();
            SetLabelXlOrder();
            SetLabelXlPull();
            SetLabelXlPush();
            SetLabelXxl();
            SetLabelXxlSpan();
            SetLabelXxlOffset();
            SetLabelXxlOrder();
            SetLabelXxlPull();
            SetLabelXxlPush();
            SetControlSpan();
            SetControlOffset();
            SetControlOrder();
            SetControlPull();
            SetControlPush();
            SetControlFlex();
            SetControlXs();
            SetControlXsSpan();
            SetControlXsOffset();
            SetControlXsOrder();
            SetControlXsPull();
            SetControlXsPush();
            SetControlSm();
            SetControlSmSpan();
            SetControlSmOffset();
            SetControlSmOrder();
            SetControlSmPull();
            SetControlSmPush();
            SetControlMd();
            SetControlMdSpan();
            SetControlMdOffset();
            SetControlMdOrder();
            SetControlMdPull();
            SetControlMdPush();
            SetControlLg();
            SetControlLgSpan();
            SetControlLgOffset();
            SetControlLgOrder();
            SetControlLgPull();
            SetControlLgPush();
            SetControlXl();
            SetControlXlSpan();
            SetControlXlOffset();
            SetControlXlOrder();
            SetControlXlPull();
            SetControlXlPush();
            SetControlXxl();
            SetControlXxlSpan();
            SetControlXxlOffset();
            SetControlXxlOrder();
            SetControlXxlPull();
            SetControlXxlPush();
        }

        /// <summary>
        /// 初始化表单共享配置
        /// </summary>
        private void InitFormShareConfig() {
            var shareConfig = _config.GetValueFromItems<FormShareConfig>();
            if ( shareConfig != null )
                shareConfig.MapTo( _shareConfig );
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 设置垂直对齐方式
        /// </summary>
        private void SetAlign() {
            var value = _config.GetValue<Align?>( UiConst.Align );
            if ( value == null )
                return;
            _shareConfig.Align = value.SafeValue();
        }

        /// <summary>
        /// 设置垂直对齐方式
        /// </summary>
        private void SetBindAlign() {
            var value = _config.GetValue( AngularConst.BindAlign );
            if ( value.IsEmpty() )
                return;
            _shareConfig.BindAlign = value;
        }

        /// <summary>
        /// 设置栅格间隔
        /// </summary>
        private void SetGutter() {
            var value = _config.GetValue( UiConst.Gutter );
            if ( value.IsEmpty() )
                return;
            _shareConfig.Gutter = value;
        }

        /// <summary>
        /// 设置水平排列方式
        /// </summary>
        private void SetJustify() {
            var value = _config.GetValue<Justify?>( UiConst.Justify );
            if ( value == null )
                return;
            _shareConfig.Justify = value.SafeValue();
        }

        /// <summary>
        /// 设置水平排列方式
        /// </summary>
        private void SetBindJustify() {
            var value = _config.GetValue( AngularConst.BindJustify );
            if ( value.IsEmpty() )
                return;
            _shareConfig.BindJustify = value;
        }

        /// <summary>
        /// 设置自动设置表单标签 nzFor 属性
        /// </summary>
        private void SetAutoLabelFor() {
            var value = _config.GetValue<bool?>( UiConst.AutoLabelFor );
            if ( value == null )
                return;
            _shareConfig.AutoLabelFor = value.SafeValue();
        }

        /// <summary>
        /// 设置表单标签跨度
        /// </summary>
        private void SetLabelSpan() {
            var value = _config.GetValue( UiConst.LabelSpan );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelSpan = value;
        }

        /// <summary>
        /// 设置表单标签偏移量
        /// </summary>
        private void SetLabelOffset() {
            var value = _config.GetValue( UiConst.LabelOffset );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelOffset = value;
        }

        /// <summary>
        /// 设置表单标签栅格顺序
        /// </summary>
        private void SetLabelOrder() {
            var value = _config.GetValue( UiConst.LabelOrder );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelOrder = value;
        }

        /// <summary>
        /// 设置表单标签栅格左移
        /// </summary>
        private void SetLabelPull() {
            var value = _config.GetValue( UiConst.LabelPull );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelPull = value;
        }

        /// <summary>
        /// 设置表单标签栅格右移
        /// </summary>
        private void SetLabelPush() {
            var value = _config.GetValue( UiConst.LabelPush );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelPush = value;
        }

        /// <summary>
        /// 设置表单标签Flex布局
        /// </summary>
        private void SetLabelFlex() {
            var value = _config.GetValue( UiConst.LabelFlex );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelFlex = value;
        }

        /// <summary>
        /// 设置表单标签超窄尺寸响应式栅格
        /// </summary>
        private void SetLabelXs() {
            var value = _config.GetValue( UiConst.LabelXs );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelXs = value;
        }

        /// <summary>
        /// 设置表单标签超窄尺寸响应式栅格跨度
        /// </summary>
        private void SetLabelXsSpan() {
            var value = _config.GetValue<int?>( UiConst.LabelXsSpan );
            if ( value == null )
                return;
            _shareConfig.LabelXsSpan = value;
        }

        /// <summary>
        /// 设置表单标签超窄尺寸响应式栅格偏移量
        /// </summary>
        private void SetLabelXsOffset() {
            var value = _config.GetValue<int?>( UiConst.LabelXsOffset );
            if ( value == null )
                return;
            _shareConfig.LabelXsOffset = value;
        }

        /// <summary>
        /// 设置表单标签超窄尺寸响应式栅格顺序
        /// </summary>
        private void SetLabelXsOrder() {
            var value = _config.GetValue<int?>( UiConst.LabelXsOrder );
            if ( value == null )
                return;
            _shareConfig.LabelXsOrder = value;
        }

        /// <summary>
        /// 设置表单标签超窄尺寸响应式栅格左移
        /// </summary>
        private void SetLabelXsPull() {
            var value = _config.GetValue<int?>( UiConst.LabelXsPull );
            if ( value == null )
                return;
            _shareConfig.LabelXsPull = value;
        }

        /// <summary>
        /// 设置表单标签超窄尺寸响应式栅格右移
        /// </summary>
        private void SetLabelXsPush() {
            var value = _config.GetValue<int?>( UiConst.LabelXsPush );
            if ( value == null )
                return;
            _shareConfig.LabelXsPush = value;
        }

        /// <summary>
        /// 设置表单标签窄尺寸响应式栅格
        /// </summary>
        private void SetLabelSm() {
            var value = _config.GetValue( UiConst.LabelSm );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelSm = value;
        }

        /// <summary>
        /// 设置表单标签窄尺寸响应式栅格跨度
        /// </summary>
        private void SetLabelSmSpan() {
            var value = _config.GetValue<int?>( UiConst.LabelSmSpan );
            if ( value == null )
                return;
            _shareConfig.LabelSmSpan = value;
        }

        /// <summary>
        /// 设置表单标签窄尺寸响应式栅格偏移量
        /// </summary>
        private void SetLabelSmOffset() {
            var value = _config.GetValue<int?>( UiConst.LabelSmOffset );
            if ( value == null )
                return;
            _shareConfig.LabelSmOffset = value;
        }

        /// <summary>
        /// 设置表单标签窄尺寸响应式栅格顺序
        /// </summary>
        private void SetLabelSmOrder() {
            var value = _config.GetValue<int?>( UiConst.LabelSmOrder );
            if ( value == null )
                return;
            _shareConfig.LabelSmOrder = value;
        }

        /// <summary>
        /// 设置表单标签窄尺寸响应式栅格左移
        /// </summary>
        private void SetLabelSmPull() {
            var value = _config.GetValue<int?>( UiConst.LabelSmPull );
            if ( value == null )
                return;
            _shareConfig.LabelSmPull = value;
        }

        /// <summary>
        /// 设置表单标签窄尺寸响应式栅格右移
        /// </summary>
        private void SetLabelSmPush() {
            var value = _config.GetValue<int?>( UiConst.LabelSmPush );
            if ( value == null )
                return;
            _shareConfig.LabelSmPush = value;
        }

        /// <summary>
        /// 设置表单标签中尺寸响应式栅格
        /// </summary>
        private void SetLabelMd() {
            var value = _config.GetValue( UiConst.LabelMd );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelMd = value;
        }

        /// <summary>
        /// 设置表单标签中尺寸响应式栅格跨度
        /// </summary>
        private void SetLabelMdSpan() {
            var value = _config.GetValue<int?>( UiConst.LabelMdSpan );
            if ( value == null )
                return;
            _shareConfig.LabelMdSpan = value;
        }

        /// <summary>
        /// 设置表单标签中尺寸响应式栅格偏移量
        /// </summary>
        private void SetLabelMdOffset() {
            var value = _config.GetValue<int?>( UiConst.LabelMdOffset );
            if ( value == null )
                return;
            _shareConfig.LabelMdOffset = value;
        }

        /// <summary>
        /// 设置表单标签中尺寸响应式栅格顺序
        /// </summary>
        private void SetLabelMdOrder() {
            var value = _config.GetValue<int?>( UiConst.LabelMdOrder );
            if ( value == null )
                return;
            _shareConfig.LabelMdOrder = value;
        }

        /// <summary>
        /// 设置表单标签中尺寸响应式栅格左移
        /// </summary>
        private void SetLabelMdPull() {
            var value = _config.GetValue<int?>( UiConst.LabelMdPull );
            if ( value == null )
                return;
            _shareConfig.LabelMdPull = value;
        }

        /// <summary>
        /// 设置表单标签中尺寸响应式栅格右移
        /// </summary>
        private void SetLabelMdPush() {
            var value = _config.GetValue<int?>( UiConst.LabelMdPush );
            if ( value == null )
                return;
            _shareConfig.LabelMdPush = value;
        }

        /// <summary>
        /// 设置表单标签宽尺寸响应式栅格
        /// </summary>
        private void SetLabelLg() {
            var value = _config.GetValue( UiConst.LabelLg );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelLg = value;
        }

        /// <summary>
        /// 设置表单标签宽尺寸响应式栅格跨度
        /// </summary>
        private void SetLabelLgSpan() {
            var value = _config.GetValue<int?>( UiConst.LabelLgSpan );
            if ( value == null )
                return;
            _shareConfig.LabelLgSpan = value;
        }

        /// <summary>
        /// 设置表单标签宽尺寸响应式栅格偏移量
        /// </summary>
        private void SetLabelLgOffset() {
            var value = _config.GetValue<int?>( UiConst.LabelLgOffset );
            if ( value == null )
                return;
            _shareConfig.LabelLgOffset = value;
        }

        /// <summary>
        /// 设置表单标签宽尺寸响应式栅格顺序
        /// </summary>
        private void SetLabelLgOrder() {
            var value = _config.GetValue<int?>( UiConst.LabelLgOrder );
            if ( value == null )
                return;
            _shareConfig.LabelLgOrder = value;
        }

        /// <summary>
        /// 设置表单标签宽尺寸响应式栅格左移
        /// </summary>
        private void SetLabelLgPull() {
            var value = _config.GetValue<int?>( UiConst.LabelLgPull );
            if ( value == null )
                return;
            _shareConfig.LabelLgPull = value;
        }

        /// <summary>
        /// 设置表单标签宽尺寸响应式栅格右移
        /// </summary>
        private void SetLabelLgPush() {
            var value = _config.GetValue<int?>( UiConst.LabelLgPush );
            if ( value == null )
                return;
            _shareConfig.LabelLgPush = value;
        }

        /// <summary>
        /// 设置表单标签超宽尺寸响应式栅格
        /// </summary>
        private void SetLabelXl() {
            var value = _config.GetValue( UiConst.LabelXl );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelXl = value;
        }

        /// <summary>
        /// 设置表单标签超宽尺寸响应式栅格跨度
        /// </summary>
        private void SetLabelXlSpan() {
            var value = _config.GetValue<int?>( UiConst.LabelXlSpan );
            if ( value == null )
                return;
            _shareConfig.LabelXlSpan = value;
        }

        /// <summary>
        /// 设置表单标签超宽尺寸响应式栅格偏移量
        /// </summary>
        private void SetLabelXlOffset() {
            var value = _config.GetValue<int?>( UiConst.LabelXlOffset );
            if ( value == null )
                return;
            _shareConfig.LabelXlOffset = value;
        }

        /// <summary>
        /// 设置表单标签超宽尺寸响应式栅格顺序
        /// </summary>
        private void SetLabelXlOrder() {
            var value = _config.GetValue<int?>( UiConst.LabelXlOrder );
            if ( value == null )
                return;
            _shareConfig.LabelXlOrder = value;
        }

        /// <summary>
        /// 设置表单标签超宽尺寸响应式栅格左移
        /// </summary>
        private void SetLabelXlPull() {
            var value = _config.GetValue<int?>( UiConst.LabelXlPull );
            if ( value == null )
                return;
            _shareConfig.LabelXlPull = value;
        }

        /// <summary>
        /// 设置表单标签超宽尺寸响应式栅格右移
        /// </summary>
        private void SetLabelXlPush() {
            var value = _config.GetValue<int?>( UiConst.LabelXlPush );
            if ( value == null )
                return;
            _shareConfig.LabelXlPush = value;
        }

        /// <summary>
        /// 设置表单标签极宽尺寸响应式栅格
        /// </summary>
        private void SetLabelXxl() {
            var value = _config.GetValue( UiConst.LabelXxl );
            if ( value.IsEmpty() )
                return;
            _shareConfig.LabelXxl = value;
        }

        /// <summary>
        /// 设置表单标签极宽尺寸响应式栅格跨度
        /// </summary>
        private void SetLabelXxlSpan() {
            var value = _config.GetValue<int?>( UiConst.LabelXxlSpan );
            if ( value == null )
                return;
            _shareConfig.LabelXxlSpan = value;
        }

        /// <summary>
        /// 设置表单标签极宽尺寸响应式栅格偏移量
        /// </summary>
        private void SetLabelXxlOffset() {
            var value = _config.GetValue<int?>( UiConst.LabelXxlOffset );
            if ( value == null )
                return;
            _shareConfig.LabelXxlOffset = value;
        }

        /// <summary>
        /// 设置表单标签极宽尺寸响应式栅格顺序
        /// </summary>
        private void SetLabelXxlOrder() {
            var value = _config.GetValue<int?>( UiConst.LabelXxlOrder );
            if ( value == null )
                return;
            _shareConfig.LabelXxlOrder = value;
        }

        /// <summary>
        /// 设置表单标签极宽尺寸响应式栅格左移
        /// </summary>
        private void SetLabelXxlPull() {
            var value = _config.GetValue<int?>( UiConst.LabelXxlPull );
            if ( value == null )
                return;
            _shareConfig.LabelXxlPull = value;
        }

        /// <summary>
        /// 设置表单标签极宽尺寸响应式栅格右移
        /// </summary>
        private void SetLabelXxlPush() {
            var value = _config.GetValue<int?>( UiConst.LabelXxlPush );
            if ( value == null )
                return;
            _shareConfig.LabelXxlPush = value;
        }

        /// <summary>
        /// 设置表单控件跨度
        /// </summary>
        private void SetControlSpan() {
            var value = _config.GetValue( UiConst.ControlSpan );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlSpan = value;
        }

        /// <summary>
        /// 设置表单控件偏移量
        /// </summary>
        private void SetControlOffset() {
            var value = _config.GetValue( UiConst.ControlOffset );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlOffset = value;
        }

        /// <summary>
        /// 设置表单控件栅格顺序
        /// </summary>
        private void SetControlOrder() {
            var value = _config.GetValue( UiConst.ControlOrder );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlOrder = value;
        }

        /// <summary>
        /// 设置表单控件栅格左移
        /// </summary>
        private void SetControlPull() {
            var value = _config.GetValue( UiConst.ControlPull );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlPull = value;
        }

        /// <summary>
        /// 设置表单控件栅格右移
        /// </summary>
        private void SetControlPush() {
            var value = _config.GetValue( UiConst.ControlPush );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlPush = value;
        }

        /// <summary>
        /// 设置表单控件Flex布局
        /// </summary>
        private void SetControlFlex() {
            var value = _config.GetValue( UiConst.ControlFlex );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlFlex = value;
        }

        /// <summary>
        /// 设置表单控件超窄尺寸响应式栅格
        /// </summary>
        private void SetControlXs() {
            var value = _config.GetValue( UiConst.ControlXs );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlXs = value;
        }

        /// <summary>
        /// 设置表单控件超窄尺寸响应式栅格跨度
        /// </summary>
        private void SetControlXsSpan() {
            var value = _config.GetValue<int?>( UiConst.ControlXsSpan );
            if ( value == null )
                return;
            _shareConfig.ControlXsSpan = value;
        }

        /// <summary>
        /// 设置表单控件超窄尺寸响应式栅格偏移量
        /// </summary>
        private void SetControlXsOffset() {
            var value = _config.GetValue<int?>( UiConst.ControlXsOffset );
            if ( value == null )
                return;
            _shareConfig.ControlXsOffset = value;
        }

        /// <summary>
        /// 设置表单控件超窄尺寸响应式栅格顺序
        /// </summary>
        private void SetControlXsOrder() {
            var value = _config.GetValue<int?>( UiConst.ControlXsOrder );
            if ( value == null )
                return;
            _shareConfig.ControlXsOrder = value;
        }

        /// <summary>
        /// 设置表单控件超窄尺寸响应式栅格左移
        /// </summary>
        private void SetControlXsPull() {
            var value = _config.GetValue<int?>( UiConst.ControlXsPull );
            if ( value == null )
                return;
            _shareConfig.ControlXsPull = value;
        }

        /// <summary>
        /// 设置表单控件超窄尺寸响应式栅格右移
        /// </summary>
        private void SetControlXsPush() {
            var value = _config.GetValue<int?>( UiConst.ControlXsPush );
            if ( value == null )
                return;
            _shareConfig.ControlXsPush = value;
        }

        /// <summary>
        /// 设置表单控件窄尺寸响应式栅格
        /// </summary>
        private void SetControlSm() {
            var value = _config.GetValue( UiConst.ControlSm );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlSm = value;
        }

        /// <summary>
        /// 设置表单控件窄尺寸响应式栅格跨度
        /// </summary>
        private void SetControlSmSpan() {
            var value = _config.GetValue<int?>( UiConst.ControlSmSpan );
            if ( value == null )
                return;
            _shareConfig.ControlSmSpan = value;
        }

        /// <summary>
        /// 设置表单控件窄尺寸响应式栅格偏移量
        /// </summary>
        private void SetControlSmOffset() {
            var value = _config.GetValue<int?>( UiConst.ControlSmOffset );
            if ( value == null )
                return;
            _shareConfig.ControlSmOffset = value;
        }

        /// <summary>
        /// 设置表单控件窄尺寸响应式栅格顺序
        /// </summary>
        private void SetControlSmOrder() {
            var value = _config.GetValue<int?>( UiConst.ControlSmOrder );
            if ( value == null )
                return;
            _shareConfig.ControlSmOrder = value;
        }

        /// <summary>
        /// 设置表单控件窄尺寸响应式栅格左移
        /// </summary>
        private void SetControlSmPull() {
            var value = _config.GetValue<int?>( UiConst.ControlSmPull );
            if ( value == null )
                return;
            _shareConfig.ControlSmPull = value;
        }

        /// <summary>
        /// 设置表单控件窄尺寸响应式栅格右移
        /// </summary>
        private void SetControlSmPush() {
            var value = _config.GetValue<int?>( UiConst.ControlSmPush );
            if ( value == null )
                return;
            _shareConfig.ControlSmPush = value;
        }

        /// <summary>
        /// 设置表单控件中尺寸响应式栅格
        /// </summary>
        private void SetControlMd() {
            var value = _config.GetValue( UiConst.ControlMd );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlMd = value;
        }

        /// <summary>
        /// 设置表单控件中尺寸响应式栅格跨度
        /// </summary>
        private void SetControlMdSpan() {
            var value = _config.GetValue<int?>( UiConst.ControlMdSpan );
            if ( value == null )
                return;
            _shareConfig.ControlMdSpan = value;
        }

        /// <summary>
        /// 设置表单控件中尺寸响应式栅格偏移量
        /// </summary>
        private void SetControlMdOffset() {
            var value = _config.GetValue<int?>( UiConst.ControlMdOffset );
            if ( value == null )
                return;
            _shareConfig.ControlMdOffset = value;
        }

        /// <summary>
        /// 设置表单控件中尺寸响应式栅格顺序
        /// </summary>
        private void SetControlMdOrder() {
            var value = _config.GetValue<int?>( UiConst.ControlMdOrder );
            if ( value == null )
                return;
            _shareConfig.ControlMdOrder = value;
        }

        /// <summary>
        /// 设置表单控件中尺寸响应式栅格左移
        /// </summary>
        private void SetControlMdPull() {
            var value = _config.GetValue<int?>( UiConst.ControlMdPull );
            if ( value == null )
                return;
            _shareConfig.ControlMdPull = value;
        }

        /// <summary>
        /// 设置表单控件中尺寸响应式栅格右移
        /// </summary>
        private void SetControlMdPush() {
            var value = _config.GetValue<int?>( UiConst.ControlMdPush );
            if ( value == null )
                return;
            _shareConfig.ControlMdPush = value;
        }

        /// <summary>
        /// 设置表单控件宽尺寸响应式栅格
        /// </summary>
        private void SetControlLg() {
            var value = _config.GetValue( UiConst.ControlLg );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlLg = value;
        }

        /// <summary>
        /// 设置表单控件宽尺寸响应式栅格跨度
        /// </summary>
        private void SetControlLgSpan() {
            var value = _config.GetValue<int?>( UiConst.ControlLgSpan );
            if ( value == null )
                return;
            _shareConfig.ControlLgSpan = value;
        }

        /// <summary>
        /// 设置表单控件宽尺寸响应式栅格偏移量
        /// </summary>
        private void SetControlLgOffset() {
            var value = _config.GetValue<int?>( UiConst.ControlLgOffset );
            if ( value == null )
                return;
            _shareConfig.ControlLgOffset = value;
        }

        /// <summary>
        /// 设置表单控件宽尺寸响应式栅格顺序
        /// </summary>
        private void SetControlLgOrder() {
            var value = _config.GetValue<int?>( UiConst.ControlLgOrder );
            if ( value == null )
                return;
            _shareConfig.ControlLgOrder = value;
        }

        /// <summary>
        /// 设置表单控件宽尺寸响应式栅格左移
        /// </summary>
        private void SetControlLgPull() {
            var value = _config.GetValue<int?>( UiConst.ControlLgPull );
            if ( value == null )
                return;
            _shareConfig.ControlLgPull = value;
        }

        /// <summary>
        /// 设置表单控件宽尺寸响应式栅格右移
        /// </summary>
        private void SetControlLgPush() {
            var value = _config.GetValue<int?>( UiConst.ControlLgPush );
            if ( value == null )
                return;
            _shareConfig.ControlLgPush = value;
        }

        /// <summary>
        /// 设置表单控件超宽尺寸响应式栅格
        /// </summary>
        private void SetControlXl() {
            var value = _config.GetValue( UiConst.ControlXl );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlXl = value;
        }

        /// <summary>
        /// 设置表单控件超宽尺寸响应式栅格跨度
        /// </summary>
        private void SetControlXlSpan() {
            var value = _config.GetValue<int?>( UiConst.ControlXlSpan );
            if ( value == null )
                return;
            _shareConfig.ControlXlSpan = value;
        }

        /// <summary>
        /// 设置表单控件超宽尺寸响应式栅格偏移量
        /// </summary>
        private void SetControlXlOffset() {
            var value = _config.GetValue<int?>( UiConst.ControlXlOffset );
            if ( value == null )
                return;
            _shareConfig.ControlXlOffset = value;
        }

        /// <summary>
        /// 设置表单控件超宽尺寸响应式栅格顺序
        /// </summary>
        private void SetControlXlOrder() {
            var value = _config.GetValue<int?>( UiConst.ControlXlOrder );
            if ( value == null )
                return;
            _shareConfig.ControlXlOrder = value;
        }

        /// <summary>
        /// 设置表单控件超宽尺寸响应式栅格左移
        /// </summary>
        private void SetControlXlPull() {
            var value = _config.GetValue<int?>( UiConst.ControlXlPull );
            if ( value == null )
                return;
            _shareConfig.ControlXlPull = value;
        }

        /// <summary>
        /// 设置表单控件超宽尺寸响应式栅格右移
        /// </summary>
        private void SetControlXlPush() {
            var value = _config.GetValue<int?>( UiConst.ControlXlPush );
            if ( value == null )
                return;
            _shareConfig.ControlXlPush = value;
        }

        /// <summary>
        /// 设置表单控件极宽尺寸响应式栅格
        /// </summary>
        private void SetControlXxl() {
            var value = _config.GetValue( UiConst.ControlXxl );
            if ( value.IsEmpty() )
                return;
            _shareConfig.ControlXxl = value;
        }

        /// <summary>
        /// 设置表单控件极宽尺寸响应式栅格跨度
        /// </summary>
        private void SetControlXxlSpan() {
            var value = _config.GetValue<int?>( UiConst.ControlXxlSpan );
            if ( value == null )
                return;
            _shareConfig.ControlXxlSpan = value;
        }

        /// <summary>
        /// 设置表单控件极宽尺寸响应式栅格偏移量
        /// </summary>
        private void SetControlXxlOffset() {
            var value = _config.GetValue<int?>( UiConst.ControlXxlOffset );
            if ( value == null )
                return;
            _shareConfig.ControlXxlOffset = value;
        }

        /// <summary>
        /// 设置表单控件极宽尺寸响应式栅格顺序
        /// </summary>
        private void SetControlXxlOrder() {
            var value = _config.GetValue<int?>( UiConst.ControlXxlOrder );
            if ( value == null )
                return;
            _shareConfig.ControlXxlOrder = value;
        }

        /// <summary>
        /// 设置表单控件极宽尺寸响应式栅格左移
        /// </summary>
        private void SetControlXxlPull() {
            var value = _config.GetValue<int?>( UiConst.ControlXxlPull );
            if ( value == null )
                return;
            _shareConfig.ControlXxlPull = value;
        }

        /// <summary>
        /// 设置表单控件极宽尺寸响应式栅格右移
        /// </summary>
        private void SetControlXxlPush() {
            var value = _config.GetValue<int?>( UiConst.ControlXxlPush );
            if ( value == null )
                return;
            _shareConfig.ControlXxlPush = value;
        }
    }
}
