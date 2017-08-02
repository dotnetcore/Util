namespace Util.Domains {
    /// <summary>
    /// 空对象
    /// </summary>
    public abstract class NullObject : INullObject{
        /// <summary>
        /// 是否空对象
        /// </summary>
        public virtual bool IsNull() {
            return true;
        }
    }
}
