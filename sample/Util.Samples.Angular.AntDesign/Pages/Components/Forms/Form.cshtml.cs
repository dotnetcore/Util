using System.ComponentModel.DataAnnotations;
using Util.Ui.Pages;

namespace Util.Samples.Pages.Components.Forms {
    ///// <summary>
    ///// 基础表单
    ///// </summary>
    //public class FormModel : PageModel {
    //    /// <summary>
    //    /// 姓名
    //    /// </summary>
    //    [Required( ErrorMessage = "名称不能为空" )]
    //    public string Name { get; set; }
    //}

    [HtmlPath("/Typings/app/components/forms/html/form_1.component.html")]
    public class FormDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
    }
}
