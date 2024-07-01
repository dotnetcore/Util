using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Mentions.Builders; 

/// <summary>
/// 提及标签生成器
/// </summary>
public class MentionBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化提及标签生成器
    /// </summary>
    public MentionBuilder( Config config ) : base( config,"nz-mention" ) {
        _config = config;
    }

    /// <summary>
    /// 配置建议内容
    /// </summary>
    public MentionBuilder Suggestions() {
        AttributeIfNotEmpty( "[nzSuggestions]", _config.GetValue( UiConst.Suggestions ) );
        return this;
    }

    /// <summary>
    /// 配置加载状态
    /// </summary>
    public MentionBuilder Loading() {
        AttributeIfNotEmpty( "[nzLoading]", _config.GetValue( UiConst.Loading ) );
        return this;
    }

    /// <summary>
    /// 配置取值函数
    /// </summary>
    public MentionBuilder ValueWith() {
        AttributeIfNotEmpty( "[nzValueWith]", _config.GetValue( UiConst.ValueWith ) );
        return this;
    }

    /// <summary>
    /// 配置触发前缀
    /// </summary>
    public MentionBuilder Prefix() {
        AttributeIfNotEmpty( "[nzPrefix]", _config.GetValue( UiConst.Prefix ) );
        return this;
    }

    /// <summary>
    /// 配置建议框位置
    /// </summary>
    public MentionBuilder Placement() {
        AttributeIfNotEmpty( "nzPlacement", _config.GetValue<MentionPlacement?>( UiConst.Placement )?.Description() );
        AttributeIfNotEmpty( "[nzPlacement]", _config.GetValue( AngularConst.BindPlacement ) );
        return this;
    }

    /// <summary>
    /// 配置空建议默认内容
    /// </summary>
    public MentionBuilder NotFoundContent() {
        AttributeIfNotEmpty( "nzNotFoundContent", _config.GetValue( UiConst.NotFoundContent ) );
        AttributeIfNotEmpty( "[nzNotFoundContent]", _config.GetValue( AngularConst.BindNotFoundContent ) );
        return this;
    }

    /// <summary>
    /// 配置指定提及的触发元素
    /// </summary>
    public MentionBuilder MentionTrigger() {
        AttributeIfNotEmpty( "[nzMentionTrigger]", _config.GetValue( UiConst.MentionTrigger ) );
        return this;
    }

    /// <summary>
    /// 配置自定义建议渲染模板
    /// </summary>
    public MentionBuilder MentionSuggestion() {
        AttributeIfNotEmpty( "[nzMentionSuggestion]", _config.GetValue( UiConst.MentionSuggestion ) );
        return this;
    }

    /// <summary>
    /// 配置校验状态
    /// </summary>
    public MentionBuilder Status() {
        AttributeIfNotEmpty( "nzStatus", _config.GetValue<FormControlStatus?>( UiConst.Status )?.Description() );
        AttributeIfNotEmpty( "[nzStatus]", _config.GetValue( AngularConst.BindStatus ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public MentionBuilder Events() {
        AttributeIfNotEmpty( "(nzOnSelect)", _config.GetValue( UiConst.OnSelect ) );
        AttributeIfNotEmpty( "(nzOnSearchChange)", _config.GetValue( UiConst.OnSearchChange ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        Suggestions().Loading().ValueWith().Prefix().Placement()
            .NotFoundContent().MentionTrigger().MentionSuggestion()
            .Status()
            .Events();
    }
}