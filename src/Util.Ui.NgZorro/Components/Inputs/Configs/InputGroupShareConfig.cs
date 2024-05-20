using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Inputs.Configs; 

/// <summary>
/// 输入框组合共享配置
/// </summary>
public class InputGroupShareConfig {
    /// <summary>
    /// 是否已创建 nz-input-group
    /// </summary>
    public bool InputGroupCreated { get; set; }
    /// <summary>
    /// 自动创建nz-input-group
    /// </summary>
    public bool? AutoCreateInputGroup { get; set; }
    /// <summary>
    /// 设置前置标签
    /// </summary>
    public string AddOnBefore { get; set; }
    /// <summary>
    /// 设置前置标签
    /// </summary>
    public string BindAddOnBefore { get; set; }
    /// <summary>
    /// 设置后置标签
    /// </summary>
    public string AddOnAfter { get; set; }
    /// <summary>
    /// 设置后置标签
    /// </summary>
    public string BindAddOnAfter { get; set; }
    /// <summary>
    /// 设置前置图标
    /// </summary>
    public AntDesignIcon? AddOnBeforeIcon { get; set; }
    /// <summary>
    /// 设置前置图标
    /// </summary>
    public string BindAddOnBeforeIcon { get; set; }
    /// <summary>
    /// 设置后置图标
    /// </summary>
    public AntDesignIcon? AddOnAfterIcon { get; set; }
    /// <summary>
    /// 设置后置图标
    /// </summary>
    public string BindAddOnAfterIcon { get; set; }
    /// <summary>
    /// 设置前缀
    /// </summary>
    public string Prefix { get; set; }
    /// <summary>
    /// 设置前缀
    /// </summary>
    public string BindPrefix { get; set; }
    /// <summary>
    /// 设置后缀
    /// </summary>
    public string Suffix { get; set; }
    /// <summary>
    /// 设置后缀
    /// </summary>
    public string BindSuffix { get; set; }
    /// <summary>
    /// 设置前缀图标
    /// </summary>
    public AntDesignIcon? PrefixIcon { get; set; }
    /// <summary>
    /// 设置前缀图标
    /// </summary>
    public string BindPrefixIcon { get; set; }
    /// <summary>
    /// 设置后缀图标
    /// </summary>
    public AntDesignIcon? SuffixIcon { get; set; }
    /// <summary>
    /// 设置后缀图标
    /// </summary>
    public string BindSuffixIcon { get; set; }
    /// <summary>
    /// 尺寸
    /// </summary>
    public InputSize? Size { get; set; }
    /// <summary>
    /// 尺寸
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// 检验状态
    /// </summary>
    public InputStatus? Status { get; set; }
    /// <summary>
    /// 检验状态
    /// </summary>
    public string BindStatus { get; set; }
    /// <summary>
    /// 是否允许清除内容
    /// </summary>
    public bool AllowClear { get; set; }
    /// <summary>
    /// 是否密码框
    /// </summary>
    public bool IsPassword { get; set; }
    /// <summary>
    /// 输入框标识
    /// </summary>
    public string InputId { get; set; }
    /// <summary>
    /// 样式类
    /// </summary>
    public string Class { get; set; }
    /// <summary>
    /// ngIf*
    /// </summary>
    public string NgIf { get; set; }
}