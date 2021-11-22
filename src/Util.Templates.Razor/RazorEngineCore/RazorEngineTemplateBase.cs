using System.Text;
using System.Threading.Tasks;
using Util.Templates.Razor.Helpers;

namespace RazorEngineCore
{
    public abstract class RazorEngineTemplateBase : IRazorEngineTemplate
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        private string attributeSuffix = null;

        public dynamic Model { get; set; }

        public HtmlHelper Html { get; set; }

        public virtual void WriteLiteral(string literal = null)
        {
            this.stringBuilder.Append(literal);
        }

        public virtual void Write(object obj = null)
        {
            this.stringBuilder.Append(obj);
        }

        public virtual void BeginWriteAttribute(string name, string prefix, int prefixOffset, string suffix, int suffixOffset, int attributeValuesCount)
        {
            this.attributeSuffix = suffix;
            this.stringBuilder.Append(prefix);
        }

        public virtual void WriteAttributeValue(string prefix, int prefixOffset, object value, int valueOffset, int valueLength, bool isLiteral)
        {
            this.stringBuilder.Append(prefix);
            this.stringBuilder.Append(value);
        }

        public virtual void EndWriteAttribute()
        {
            this.stringBuilder.Append(this.attributeSuffix);
            this.attributeSuffix = null;
        }

        public virtual Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }

        public virtual string Result()
        {
            return this.stringBuilder.ToString();
        }
    }
}