namespace Util.ObjectMapping {
    /// <summary>
    /// 对象映射器
    /// </summary>
    public interface IObjectMapper {
        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        TDestination Map<TSource, TDestination>( TSource source );
        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="destination">目标对象</param>
        TDestination Map<TSource, TDestination>( TSource source, TDestination destination );
    }
}
