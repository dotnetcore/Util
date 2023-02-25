using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SixLabors.Fonts;

namespace Util.Images {
    /// <summary>
    /// 头像服务
    /// </summary>
    public class AvatarManager : IAvatarManager {

        #region 字段

        /// <summary>
        /// 背景色
        /// </summary>
        private string _backgroundColor;
        /// <summary>
        /// 头像大小
        /// </summary>
        private int _size;
        /// <summary>
        /// 字体名称
        /// </summary>
        private string _fontName;
        /// <summary>
        /// 字体大小
        /// </summary>
        private double _fontSize;
        /// <summary>
        /// 字体颜色
        /// </summary>
        private string _fontColor;
        /// <summary>
        /// 字体是否粗体
        /// </summary>
        private bool _isBold;
        /// <summary>
        /// 字体是否斜体
        /// </summary>
        private bool _isItalic;
        /// <summary>
        /// 字体是否大写
        /// </summary>
        private bool _isUppercase;
        /// <summary>
        /// 文本
        /// </summary>
        private string _text;
        /// <summary>
        /// 文本长度
        /// </summary>
        private int _length;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化头像服务
        /// </summary>
        /// <param name="imageManager">图片服务</param>
        public AvatarManager( IImageManager imageManager ) {
            ImageManager = imageManager ?? throw new ArgumentNullException( nameof( imageManager ) );
            _backgroundColor = "5d005d";
            _size = 64;
            _fontSize = 0.5;
            _fontColor = "ffffff";
            _isUppercase = true;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 图片服务
        /// </summary>
        protected IImageManager ImageManager { get; }

        #endregion

        #region BackgroundColor

        /// <inheritdoc />
        public IAvatarManager BackgroundColor( string color ) {
            _backgroundColor = color;
            return this;
        }

        #endregion

        #region Size

        /// <inheritdoc />
        public IAvatarManager Size( int size ) {
            _size = size;
            return this;
        }

        #endregion

        #region Font

        /// <inheritdoc />
        public IAvatarManager Font( string fontName ) {
            _fontName = fontName;
            return this;
        }

        #endregion

        #region FontSize

        /// <inheritdoc />
        public IAvatarManager FontSize( double size ) {
            _fontSize = size;
            return this;
        }

        #endregion

        #region FontColor

        /// <inheritdoc />
        public IAvatarManager FontColor( string color ) {
            _fontColor = color;
            return this;
        }

        #endregion

        #region Bold

        /// <inheritdoc />
        public IAvatarManager Bold( bool isBold = true ) {
            _isBold = isBold;
            return this;
        }

        #endregion

        #region Italic

        /// <inheritdoc />
        public IAvatarManager Italic( bool isItalic = true ) {
            _isItalic = isItalic;
            return this;
        }

        #endregion

        #region Uppercase

        /// <inheritdoc />
        public IAvatarManager Uppercase( bool isUppercase = true ) {
            _isUppercase = isUppercase;
            return this;
        }

        #endregion

        #region Text

        /// <inheritdoc />
        public IAvatarManager Text( string text, int length = 1 ) {
            _text = text;
            _length = length;
            return this;
        }

        #endregion

        #region SaveAsync

        /// <inheritdoc />
        public virtual async Task SaveAsync( string path, CancellationToken cancellationToken = default ) {
            if ( _text.IsEmpty() )
                return;
            var imageWrapper = GetImageWrapper();
            await imageWrapper.SaveAsync( path, cancellationToken );
        }

        /// <summary>
        /// 获取图片包装器
        /// </summary>
        private IImageWrapper GetImageWrapper() {
            return ImageManager.CreateImage( GetSize(), GetSize(), _backgroundColor )
                .Font( GetFontSize(), GetFontStyle(), _fontName )
                .TextCenter( GetText(), _fontColor );
        }

        /// <summary>
        /// 获取头像大小
        /// </summary>
        private int GetSize() {
            if ( _size < 16 )
                return 16;
            if ( _size > 512 )
                return 512;
            return _size;
        }

        /// <summary>
        /// 获取字体大小
        /// </summary>
        private float GetFontSize() {
            if ( _fontSize is >= 0.1 and <= 1 )
                return _size * (float)_fontSize;
            if ( _fontSize < 16 )
                return 16;
            if ( _fontSize > _size )
                return _size * 0.5f;
            return (float)_fontSize;
        }

        /// <summary>
        /// 获取字体样式
        /// </summary>
        private FontStyle GetFontStyle() {
            if ( _isBold && _isItalic )
                return FontStyle.BoldItalic;
            if ( _isBold )
                return FontStyle.Bold;
            if ( _isItalic )
                return FontStyle.Italic;
            return FontStyle.Regular;
        }

        /// <summary>
        /// 获取文本
        /// </summary>
        private string GetText() {
            if ( _text.IsEmpty() )
                return null;
            _text = GetPlusSeparatedText();
            if ( _isUppercase )
                _text = _text.ToUpperInvariant();
            if ( _text.Length > _length )
                return _text.Substring( 0, _length );
            return _text;
        }

        /// <summary>
        /// 获取加号分隔文本
        /// </summary>
        private string GetPlusSeparatedText() {
            if ( _text.Contains( "+" ) == false )
                return _text;
            _length = 3;
            return _text.Split( "+" ).Where( t => t.IsEmpty() == false ).Select( t => t.Trim().Substring( 0, 1 ) ).Join( separator: "" );
        }

        #endregion

        #region ToStreamAsync

        /// <summary>
        /// 转换为图片流
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<byte[]> ToStreamAsync( CancellationToken cancellationToken = default ) {
            if ( _text.IsEmpty() )
                return null;
            var imageWrapper = GetImageWrapper();
            return await imageWrapper.ToStreamAsync( cancellationToken );
        }

        #endregion

        #region ToBase64

        /// <inheritdoc />
        public string ToBase64() {
            if ( _text.IsEmpty() )
                return null;
            var imageWrapper = GetImageWrapper();
            return imageWrapper.ToBase64();
        }

        #endregion
    }
}
