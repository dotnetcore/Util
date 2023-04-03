using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Properties;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 模型表达式解析器
    /// </summary>
    public class ExpressionResolver : IExpressionResolver {
        /// <inheritdoc />
        public ModelExpressionInfo Resolve( ModelExpression expression ) {
            var result = new ModelExpressionInfo();
            if ( expression == null )
                return result;
            result.ModelType = expression.Metadata.ModelType;
            result.OriginalPropertyName = expression.Name;
            result.PropertyName = GetPropertyName( expression.Name );
            result.ModelName = GetModelName( expression.ModelExplorer );
            var property = GetProperty( expression.Metadata );
            if ( property == null )
                return result;
            result.Property = property;
            result.LastPropertyName = GetLastPropertyName( property );
            result.DisplayName = GetDisplayName( property );
            result.IsPassword = GetIsPassword( property );
            result.IsBool = GetIsBool( property );
            result.IsEnum = GetIsEnum( property );
            result.IsDate = GetIsDate( property );
            result.IsInt = GetIsInt( property );
            result.IsNumber = GetIsNumber( property );
            ValidateRequired( result, property );
            ValidateLength( result, property );
            ValidateRange( result, property );
            ValidateEmail( result, property );
            ValidatePhone( result, property );
            ValidateIdCard( result, property );
            ValidateUrl( result, property );
            ValidateRegularExpression( result, property );
            return result;
        }

        /// <summary>
        /// 获取属性信息
        /// </summary>
        protected virtual MemberInfo GetProperty( ModelMetadata metadata ) {
            if ( metadata == null )
                return null;
            if ( metadata.ContainerType == null )
                return null;
            var members = metadata.ContainerType.GetMember( metadata.PropertyName );
            return members.Length == 0 ? null : members[0];
        }

        /// <summary>
        /// 获取属性名
        /// </summary>
        protected virtual string GetPropertyName( string originalPropertyName ) {
            if ( originalPropertyName.IsEmpty() )
                return null;
            var array = originalPropertyName.Split( '.' );
            return array.Select( ModelExpressionHelper.ConvertName ).Join( separator: "." );
        }

        /// <summary>
        /// 获取模型名称
        /// </summary>
        protected virtual string GetModelName( ModelExplorer explorer ) {
            var result = GetDefaultModel();
            if ( explorer == null )
                return result;
            if ( explorer.Container == null )
                return result;
            if ( explorer.Container.ModelType == null )
                return result;
            var modelAttribute = explorer.Container.ModelType.GetCustomAttribute<ModelAttribute>();
            if ( modelAttribute == null )
                return result;
            return modelAttribute.Model;
        }

        /// <summary>
        /// 获取默认模型名称
        /// </summary>
        protected virtual string GetDefaultModel() {
            return "model";
        }

        /// <summary>
        /// 获取最后一级属性名
        /// </summary>
        protected virtual string GetLastPropertyName( MemberInfo property ) {
            return ModelExpressionHelper.ConvertName( property.Name );
        }

        /// <summary>
        /// 获取显示名称
        /// </summary>
        protected virtual string GetDisplayName( MemberInfo property ) {
            return Util.Helpers.Reflection.GetDisplayNameOrDescription( property );
        }

        /// <summary>
        /// 获取是否密码类型
        /// </summary>
        protected virtual bool GetIsPassword( MemberInfo property ) {
            var attribute = property.GetCustomAttribute<DataTypeAttribute>();
            if ( attribute == null )
                return false;
            if ( attribute.DataType == DataType.Password )
                return true;
            return false;
        }

        /// <summary>
        /// 获取是否布尔类型
        /// </summary>
        protected virtual bool GetIsBool( MemberInfo property ) {
            return Util.Helpers.Reflection.IsBool( property );
        }

        /// <summary>
        /// 获取是否枚举类型
        /// </summary>
        protected virtual bool GetIsEnum( MemberInfo property ) {
            return Util.Helpers.Reflection.IsEnum( property );
        }

        /// <summary>
        /// 获取是否日期类型
        /// </summary>
        protected virtual bool GetIsDate( MemberInfo property ) {
            return Util.Helpers.Reflection.IsDate( property );
        }

        /// <summary>
        /// 获取是否整型
        /// </summary>
        protected virtual bool GetIsInt( MemberInfo property ) {
            return Util.Helpers.Reflection.IsInt( property );
        }

        /// <summary>
        /// 获取是否数值类型
        /// </summary>
        protected virtual bool GetIsNumber( MemberInfo property ) {
            return Util.Helpers.Reflection.IsNumber( property );
        }

        /// <summary>
        /// 验证必填项
        /// </summary>
        protected virtual void ValidateRequired( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<RequiredAttribute>();
            if ( attribute == null )
                return;
            result.IsRequired = true;
            result.RequiredMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证长度
        /// </summary>
        protected virtual void ValidateLength( ModelExpressionInfo result, MemberInfo property ) {
            ValidateStringLength( result, property );
            ValidateMaxLength( result, property );
            ValidateMinLength( result, property );
        }

        /// <summary>
        /// 验证StringLengthAttribute特性
        /// </summary>
        protected virtual void ValidateStringLength( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<StringLengthAttribute>();
            if ( attribute == null )
                return;
            if ( attribute.MaximumLength > 0 ) {
                result.MaxLength = attribute.MaximumLength;
                result.MaxLengthMessage = attribute.ErrorMessage;
            }
            if ( attribute.MinimumLength > 0 ) {
                result.MinLength = attribute.MinimumLength;
                result.MinLengthMessage = attribute.ErrorMessage;
            }
        }

        /// <summary>
        /// 验证MaxLengthAttribute特性
        /// </summary>
        protected virtual void ValidateMaxLength( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<MaxLengthAttribute>();
            if ( attribute == null )
                return;
            result.MaxLength = attribute.Length;
            result.MaxLengthMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证MinLengthAttribute特性
        /// </summary>
        protected virtual void ValidateMinLength( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<MinLengthAttribute>();
            if ( attribute == null )
                return;
            result.MinLength = attribute.Length;
            result.MinLengthMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证RangeAttribute特性
        /// </summary>
        protected virtual void ValidateRange( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<RangeAttribute>();
            if ( attribute == null )
                return;
            result.Min = attribute.Minimum;
            result.Max = attribute.Maximum;
            result.MinMessage = attribute.ErrorMessage;
            result.MaxMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证EmailAddressAttribute特性
        /// </summary>
        protected virtual void ValidateEmail( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<EmailAddressAttribute>();
            if ( attribute == null )
                return;
            result.IsEmail = true;
            if ( attribute.ErrorMessage != null && attribute.ErrorMessage.Contains( "field is not a valid e-mail address" ) )
                return;
            result.EmailMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证PhoneAttribute特性
        /// </summary>
        protected virtual void ValidatePhone( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<PhoneAttribute>();
            if ( attribute == null )
                return;
            result.IsPhone = true;
            if ( attribute.ErrorMessage != null && attribute.ErrorMessage.Contains( "field is not a valid phone number" ) )
                return;
            result.PhoneMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证IdCardAttribute特性
        /// </summary>
        protected virtual void ValidateIdCard( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<IdCardAttribute>();
            if ( attribute == null )
                return;
            result.IsIdCard = true;
            if ( attribute.ErrorMessage == R.InvalidIdCard )
                return;
            result.IdCardMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证UrlAttribute特性
        /// </summary>
        protected virtual void ValidateUrl( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<UrlAttribute>();
            if ( attribute == null )
                return;
            result.IsUrl = true;
            if ( attribute.ErrorMessage != null && attribute.ErrorMessage.Contains( "field is not a valid fully-qualified http, https, or ftp URL" ) )
                return;
            result.UrlMessage = attribute.ErrorMessage;
        }

        /// <summary>
        /// 验证RegularExpressionAttribute特性
        /// </summary>
        protected virtual void ValidateRegularExpression( ModelExpressionInfo result, MemberInfo property ) {
            var attribute = property.GetCustomAttribute<RegularExpressionAttribute>();
            if ( attribute == null )
                return;
            result.IsRegularExpression = true;
            result.Pattern = attribute.Pattern;
            result.RegularExpressionMessage = attribute.ErrorMessage;
        }
    }
}
