namespace Util.Webs {
    /// <summary>
    /// Html转义字符
    /// </summary>
    public static class HtmlEscape {
        /// <summary>
        /// 双引号,值为 &amp;quot;
        /// </summary>
        public const string Quote = "&quot;";
        /// <summary>
        /// 双引号,值为 &amp;#34;
        /// </summary>
        public const string Quote34 = "&#34;";
        /// <summary>
        /// 双引号,值为 &amp;#x22;
        /// </summary>
        public const string Quote22 = "&#x22;";
        /// <summary>
        /// 单引号,值为 &amp;apos;
        /// </summary>
        public const string SingleQuote = "&apos;";
        /// <summary>
        /// 单引号,值为 &amp;#x27;
        /// </summary>
        public const string SingleQuote27 = "&#x27;";
        /// <summary>
        /// 单引号,值为 &amp;#39;
        /// </summary>
        public const string SingleQuote39 = "&#39;";
    }
}