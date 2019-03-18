using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 列表图标，该标签应放到 util-list-item 中
    /// </summary>
    [HtmlTargetElement( "util-list-icon", TagStructure = TagStructure.WithoutEndTag )]
    public class ListIconTagHelper : NavListIconTagHelper {
    }
}