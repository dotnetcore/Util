namespace Util.Samples.Domain.Models {
    /// <summary>
    /// 角色
    /// </summary>
    public partial class Role {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            IsAdmin = false;
            NormalizedName = Name;
            InitPinYin();
        }

        /// <summary>
        /// 初始化拼音简码
        /// </summary>
        public void InitPinYin() {
            PinYin = Util.Helpers.String.PinYin( Name );
        }
    }
}