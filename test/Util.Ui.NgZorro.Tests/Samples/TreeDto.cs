using Util.Applications.Trees;

namespace Util.Ui.NgZorro.Tests.Samples {
    /// <summary>
    /// 树形参数
    /// </summary>
    public class TreeDto : TreeDtoBase<TreeDto> {
        public string Text { get; set; }

        public override string GetText() {
            return Text;
        }
    }
}
