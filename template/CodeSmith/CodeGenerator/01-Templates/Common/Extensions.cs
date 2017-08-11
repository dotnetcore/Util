using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeSmith.Engine;

namespace SchemaMapper
{
    public enum CodeLanguage
    {
        CSharp,
        VisualBasic
    }

    public static class Extensions
    {
        private static readonly HashSet<string> _csharpKeywords;
        private static readonly HashSet<string> _visualBasicKeywords;
        private static readonly Dictionary<string, string> _csharpTypeAlias;

        static Extensions()
        {
            _csharpKeywords = new HashSet<string>(StringComparer.Ordinal)
            {
                "as", "do", "if", "in", "is",
                "for", "int", "new", "out", "ref", "try",
                "base", "bool", "byte", "case", "char", "else", "enum", "goto", "lock", "long", "null", "this", "true", "uint", "void",
                "break", "catch", "class", "const", "event", "false", "fixed", "float", "sbyte", "short", "throw", "ulong", "using", "while",
                "double", "extern", "object", "params", "public", "return", "sealed", "sizeof", "static", "string", "struct", "switch", "typeof", "unsafe", "ushort",
                "checked", "decimal", "default", "finally", "foreach", "private", "virtual",
                "abstract", "continue", "delegate", "explicit", "implicit", "internal", "operator", "override", "readonly", "volatile",
                "__arglist", "__makeref", "__reftype", "interface", "namespace", "protected", "unchecked",
                "__refvalue", "stackalloc"
            };

            _visualBasicKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "as", "do", "if", "in", "is", "me", "of", "on", "or", "to",
                "and", "dim", "end", "for", "get", "let", "lib", "mod", "new", "not", "rem", "set", "sub", "try", "xor",
                "ansi", "auto", "byte", "call", "case", "cdbl", "cdec", "char", "cint", "clng", "cobj", "csng", "cstr", "date", "each", "else", 
                "enum", "exit", "goto", "like", "long", "loop", "next", "step", "stop", "then", "true", "wend", "when", "with",
                "alias", "byref", "byval", "catch", "cbool", "cbyte", "cchar", "cdate", "class", "const", "ctype", "cuint", "culng", "endif", "erase", "error", 
                "event", "false", "gosub", "isnot", "redim", "sbyte", "short", "throw", "ulong", "until", "using", "while",
                "csbyte", "cshort", "double", "elseif", "friend", "global", "module", "mybase", "object", "option", "orelse", "public", "resume", "return", "select", "shared", 
                "single", "static", "string", "typeof", "ushort",
                "andalso", "boolean", "cushort", "decimal", "declare", "default", "finally", "gettype", "handles", "imports", "integer", "myclass", "nothing", "partial", "private", "shadows", 
                "trycast", "unicode", "variant",
                "assembly", "continue", "delegate", "function", "inherits", "operator", "optional", "preserve", "property", "readonly", "synclock", "uinteger", "widening",
                "addressof", "interface", "namespace", "narrowing", "overloads", "overrides", "protected", "structure", "writeonly",
                "addhandler", "directcast", "implements", "paramarray", "raiseevent", "withevents",
                "mustinherit", "overridable",
                "mustoverride",
                "removehandler",
                "class_finalize", "notinheritable", "notoverridable",
                "class_initialize"
            };

            _csharpTypeAlias = new Dictionary<string, string>(16)
            {
                {"System.Int16", "short"},
                {"System.Int32", "int"},
                {"System.Int64", "long"},
                {"System.String", "string"},
                {"System.Object", "object"},
                {"System.Boolean", "bool"},
                {"System.Void", "void"},
                {"System.Char", "char"},
                {"System.Byte", "byte"},
                {"System.UInt16", "ushort"},
                {"System.UInt32", "uint"},
                {"System.UInt64", "ulong"},
                {"System.SByte", "sbyte"},
                {"System.Single", "float"},
                {"System.Double", "double"},
                {"System.Decimal", "decimal"}
            };
        }

        public static string ToCamelCase(this string name)
        {
            return StringUtil.ToCamelCase(name);
        }

        public static string ToPascalCase(this string name)
        {
            return StringUtil.ToPascalCase(name);
        }

        public static string ToPlural( this string name ) {
            return StringUtil.ToPlural( name );
        }

        public static string ToSingular(this string name) {
            return StringUtil.ToSingular( name );
        }

        public static string ToFieldName(this string name)
        {
            return "_" + StringUtil.ToCamelCase(name);
        }

        public static string MakeUnique(this string name, Func<string, bool> exists)
        {
            string uniqueName = name;
            int count = 1;

            while (exists(uniqueName))
                uniqueName = string.Concat(name, count++);

            return uniqueName;
        }

        public static bool IsKeyword(this string text, CodeLanguage language = CodeLanguage.CSharp)
        {
            return language == CodeLanguage.VisualBasic
              ? _visualBasicKeywords.Contains(text)
              : _csharpKeywords.Contains(text);
        }

        public static string ToSafeName(this string name, CodeLanguage language = CodeLanguage.CSharp)
        {
            if (!name.IsKeyword(language))
                return name;

            return language == CodeLanguage.VisualBasic
              ? string.Format("[{0}]", name)
              : "@" + name;
        }

        public static string ToType(this Type type, CodeLanguage language = CodeLanguage.CSharp)
        {
            return ToType(type.FullName, language);
        }

        public static string ToType(this string type, CodeLanguage language = CodeLanguage.CSharp)
        {
            if (type == "System.Xml.XmlDocument")
                type = "System.String";

            string t;
            if (language == CodeLanguage.CSharp && _csharpTypeAlias.TryGetValue(type, out t))
                return t;


            return type;
        }

        public static string ToNullableType(this Type type, bool isNullable = false, CodeLanguage language = CodeLanguage.CSharp)
        {
            return ToNullableType(type.FullName, isNullable, language);
        }

        public static string ToNullableType(this string type, bool isNullable = false, CodeLanguage language = CodeLanguage.CSharp)
        {
            bool isValueType = type.IsValueType();

            type = type.ToType(language);
            type = type.Replace("System.", "");

            if (!isValueType || !isNullable)
                return type;

            return language == CodeLanguage.VisualBasic
              ? string.Format("Nullable(Of {0})", type)
              : type + "?";
        }

        public static bool IsValueType(this string type)
        {
            if (!type.StartsWith("System."))
                return false;

            var t = Type.GetType(type, false);
            return t != null && t.IsValueType;
        }

        public static string ToDelimitedString(this IEnumerable<string> values, string delimiter, string format = null)
        {
            var sb = new StringBuilder();
            foreach (var i in values)
            {
                if (sb.Length > 0)
                    sb.Append(delimiter);

                if (string.IsNullOrEmpty(format))
                    sb.Append(i);
                else
                    sb.AppendFormat(format, i);
            }

            return sb.ToString();
        }

    }
}
