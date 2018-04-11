using System;

namespace Util.Randoms {
    /// <summary>
    /// 随机数生成器
    /// </summary>
    public interface IRandomBuilder {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        /// <param name="text">如果传入该参数，则从该文本中随机抽取</param>
        string GenerateString( int maxLength, string text = null );
        /// <summary>
        /// 生成随机字母
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        string GenerateLetters( int maxLength );
        /// <summary>
        /// 生成随机汉字
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        string GenerateChinese( int maxLength );
        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        string GenerateNumbers( int maxLength );
        /// <summary>
        /// 生成随机布尔值
        /// </summary>
        bool GenerateBool();
        /// <summary>
        /// 生成随机整数
        /// </summary>
        /// <param name="maxValue">最大值</param>
        int GenerateInt( int maxValue );
        /// <summary>
        /// 生成随机日期
        /// </summary>
        /// <param name="beginYear">起始年份</param>
        /// <param name="endYear">结束年份</param>
        DateTime GenerateDate( int beginYear = 1980, int endYear = 2080 );
        /// <summary>
        /// 生成随机枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        TEnum GenerateEnum<TEnum>();
    }
}
