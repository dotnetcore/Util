namespace Util.Helpers;

/// <summary>
/// 标识生成器
/// </summary>
public static partial class Id {
    /// <summary>
    /// 使用 Nanoid 创建标识,返回 21 个字符的标识.
    /// </summary>
    public static string CreateNanoid() {
        return CreateNanoid( 21 );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识,返回 21 个字符的标识.
    /// </summary>
    public static async Task<string> CreateNanoidAsync() {
        return await CreateNanoidAsync( 21 );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识
    /// </summary>
    /// <param name="size">字符数</param>
    public static string CreateNanoid( int size ) {
        return CreateNanoid( null, size );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识
    /// </summary>
    /// <param name="size">字符数</param>
    public static async Task<string> CreateNanoidAsync( int size ) {
        return await CreateNanoidAsync( null, size );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识
    /// </summary>
    /// <param name="alphabet">可选字符,范例 abcd</param>
    public static string CreateNanoid( string alphabet ) {
        return CreateNanoid( alphabet, 21 );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识
    /// </summary>
    /// <param name="alphabet">可选字符,范例 abcd</param>
    public static async Task<string> CreateNanoidAsync( string alphabet ) {
        return await CreateNanoidAsync( alphabet, 21 );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识
    /// </summary>
    /// <param name="alphabet">可选字符,范例 abcd</param>
    /// <param name="size">字符数</param>
    public static string CreateNanoid( string alphabet, int size ) {
        if( string.IsNullOrEmpty( _id.Value ) == false )
            return _id.Value;
        if( string.IsNullOrEmpty( alphabet ) )
            return Nanoid.Generate( size: size );
        return Nanoid.Generate( alphabet, size );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识
    /// </summary>
    /// <param name="alphabet">可选字符,范例 abcd</param>
    /// <param name="size">字符数</param>
    public static async Task<string> CreateNanoidAsync( string alphabet, int size ) {
        if( string.IsNullOrEmpty( _id.Value ) == false )
            return _id.Value;
        if( string.IsNullOrEmpty( alphabet ) )
            return await Nanoid.GenerateAsync( size: size );
        return await Nanoid.GenerateAsync( alphabet, size );
    }

    /// <summary>
    /// 使用 Nanoid 创建标识
    /// </summary>
    /// <param name="random">随机数</param>
    /// <param name="alphabet">可选字符,范例 abcd</param>
    /// <param name="size">字符数</param>
    public static string CreateNanoid( System.Random random, string alphabet = "_-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", int size = 21 ) {
        if( string.IsNullOrEmpty( _id.Value ) == false )
            return _id.Value;
        return Nanoid.Generate( random, alphabet, size );
    }
}