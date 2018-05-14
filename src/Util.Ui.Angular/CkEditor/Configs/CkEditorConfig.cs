using Newtonsoft.Json;

namespace Util.Ui.CkEditor.Configs {
    /// <summary>
    /// CkEditor配置
    /// </summary>
    public class CkEditorConfig {
        /// <summary>
        /// 上传地址
        /// </summary>
        [JsonProperty( "filebrowserUploadUrl",NullValueHandling = NullValueHandling.Ignore)]
        public string FileBrowserUploadUrl { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        [JsonProperty( "height", NullValueHandling = NullValueHandling.Ignore )]
        public string Height { get; set; }
        /// <summary>
        /// 允许编辑源码修改内容，不进行过滤
        /// </summary>
        [JsonProperty( "allowedContent", NullValueHandling = NullValueHandling.Ignore )]
        public bool? AllowedContent { get; set; }
    }
}
