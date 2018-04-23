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
    }
}
