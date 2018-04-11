using System;
using System.Text;
using Util.Helpers;

namespace Util.Randoms {
    /// <summary>
    /// 随机数生成器
    /// </summary>
    public class RandomBuilder : IRandomBuilder {
        /// <summary>
        /// 初始化随机数生成器
        /// </summary>
        /// <param name="generator">随机数字生成器</param>
        public RandomBuilder( IRandomNumberGenerator generator = null ) {
            _random = generator ?? new RandomNumberGenerator();
        }

        /// <summary>
        /// 随机数字生成器
        /// </summary>
        private readonly IRandomNumberGenerator _random;

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        /// <param name="text">如果传入该参数，则从该文本中随机抽取</param>
        public string GenerateString( int maxLength, string text = null ) {
            if( text == null )
                text = Const.Letters + Const.Numbers;
            var result = new StringBuilder();
            var length = GetRandomLength( maxLength );
            for( int i = 0; i < length; i++ )
                result.Append( GetRandomChar( text ) );
            return result.ToString();
        }

        /// <summary>
        /// 获取随机长度
        /// </summary>
        private int GetRandomLength( int maxLength ) {
            return _random.Generate( 1, maxLength );
        }

        /// <summary>
        /// 获取随机字符
        /// </summary>
        private string GetRandomChar( string text ) {
            return text[_random.Generate( 1, text.Length )].ToString();
        }

        /// <summary>
        /// 生成随机字母
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        public string GenerateLetters( int maxLength ) {
            return GenerateString( maxLength, Const.Letters );
        }

        /// <summary>
        /// 生成随机汉字
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        public string GenerateChinese( int maxLength ) {
            return GenerateString( maxLength, Const.SimplifiedChinese );
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        public string GenerateNumbers( int maxLength ) {
            return GenerateString( maxLength, Const.Numbers );
        }

        /// <summary>
        /// 生成随机布尔值
        /// </summary>
        public bool GenerateBool() {
            var random = _random.Generate( 1, 100 );
            if( random % 2 == 0 )
                return false;
            return true;
        }

        /// <summary>
        /// 生成随机整数
        /// </summary>
        /// <param name="maxValue">最大值</param>
        public int GenerateInt( int maxValue ) {
            return _random.Generate( 0, maxValue + 1 );
        }

        /// <summary>
        /// 生成随机日期
        /// </summary>
        /// <param name="beginYear">起始年份</param>
        /// <param name="endYear">结束年份</param>
        public DateTime GenerateDate( int beginYear = 1980, int endYear = 2080 ) {
            var year = _random.Generate( beginYear, endYear );
            var month = _random.Generate( 1, 13 );
            var day = _random.Generate( 1, 29 );
            var hour = _random.Generate( 1, 24 );
            var minute = _random.Generate( 1, 60 );
            var second = _random.Generate( 1, 60 );
            return new DateTime( year, month, day, hour, minute, second );
        }

        /// <summary>
        /// 生成随机枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public TEnum GenerateEnum<TEnum>() {
            var list = Util.Helpers.Enum.GetItems<TEnum>();
            int index = _random.Generate( 0, list.Count );
            return Util.Helpers.Enum.Parse<TEnum>( list[index].Value );
        }
    }
}
