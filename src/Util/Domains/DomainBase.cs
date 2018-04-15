using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Util.Helpers;
using Util.Validations;

namespace Util.Domains {
    /// <summary>
    /// 领域层顶级基类
    /// </summary>
    public abstract class DomainBase<T> : IDomainObject, ICompareChange<T> where T : IDomainObject {

        #region 字段

        /// <summary>
        /// 描述
        /// </summary>
        private StringBuilder _description;
        /// <summary>
        /// 验证规则集合
        /// </summary>
        private readonly List<IValidationRule> _rules;
        /// <summary>
        /// 验证处理器
        /// </summary>
        private IValidationHandler _handler;
        /// <summary>
        /// 变更值集合
        /// </summary>
        private ChangeValueCollection _changeValues;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化领域层顶级基类
        /// </summary>
        protected DomainBase() {
            _rules = new List<IValidationRule>();
            _handler = new ThrowHandler();
        }

        #endregion        

        #region SetValidationHandler(设置验证处理器)

        /// <summary>
        /// 设置验证处理器
        /// </summary>
        /// <param name="handler">验证处理器</param>
        public void SetValidationHandler( IValidationHandler handler ) {
            if( handler == null )
                return;
            _handler = handler;
        }

        #endregion

        #region AddValidationRules(添加验证规则列表)

        /// <summary>
        /// 添加验证规则列表
        /// </summary>
        /// <param name="rules">验证规则列表</param>
        public void AddValidationRules( IEnumerable<IValidationRule> rules ) {
            if( rules == null )
                return;
            foreach( var rule in rules )
                AddValidationRule( rule );
        }

        #endregion

        #region AddValidationRule(添加验证规则)

        /// <summary>
        /// 添加验证规则
        /// </summary>
        /// <param name="rule">验证规则</param>
        public void AddValidationRule( IValidationRule rule ) {
            if( rule == null )
                return;
            _rules.Add( rule );
        }

        #endregion

        #region Validate(验证)

        /// <summary>
        /// 验证
        /// </summary>
        public virtual ValidationResultCollection Validate() {
            var result = GetValidationResults();
            HandleValidationResults( result );
            return result;
        }

        /// <summary>
        /// 获取验证结果
        /// </summary>
        private ValidationResultCollection GetValidationResults() {
            var result = DataAnnotationValidation.Validate( this );
            Validate( result );
            foreach( var rule in _rules )
                result.Add( rule.Validate() );
            return result;
        }

        /// <summary>
        /// 验证并添加到验证结果集合
        /// </summary>
        /// <param name="results">验证结果集合</param>
        protected virtual void Validate( ValidationResultCollection results ) {
        }

        /// <summary>
        /// 处理验证结果
        /// </summary>
        private void HandleValidationResults( ValidationResultCollection results ) {
            if( results.IsValid )
                return;
            _handler.Handle( results );
        }

        #endregion

        #region GetChanges(获取变更属性)

        /// <summary>
        /// 获取变更属性
        /// </summary>
        /// <param name="newEntity">新对象</param>
        public ChangeValueCollection GetChanges( T newEntity ) {
            _changeValues = new ChangeValueCollection();
            if( Equals( newEntity, null ) )
                return _changeValues;
            AddChanges( newEntity );
            return _changeValues;
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        /// <param name="newEntity">新对象</param>
        protected virtual void AddChanges( T newEntity ) {
        }

        /// <summary>
        /// 添加变更
        /// </summary>
        /// <param name="expression">属性表达式,范例：t => t.Name</param>
        /// <param name="newValue">新值,范例：newEntity.Name</param>
        protected void AddChange<TProperty, TValue>( Expression<Func<T, TProperty>> expression, TValue newValue ) {
            var member = Util.Helpers.Lambda.GetMemberExpression( expression );
            var name = Util.Helpers.Lambda.GetMemberName( member );
            var description = Util.Helpers.Reflection.GetDisplayNameOrDescription( member.Member );
            var value = member.Member.GetPropertyValue( this );
            AddChange( name, description, Util.Helpers.Convert.To<TValue>( value ), newValue );
        }

        /// <summary>
        /// 添加变更
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="description">描述</param>
        /// <param name="oldValue">旧值,范例：this.Name</param>
        /// <param name="newValue">新值,范例：newEntity.Name</param>
        protected void AddChange<TValue>( string propertyName, string description, TValue oldValue, TValue newValue ) {
            if( Equals( oldValue, newValue ) )
                return;
            string oldValueString = oldValue.SafeString().ToLower().Trim();
            string newValueString = newValue.SafeString().ToLower().Trim();
            if( oldValueString == newValueString )
                return;
            _changeValues.Add( propertyName, description, oldValueString, newValueString );
        }

        /// <summary>
        /// 添加变更
        /// </summary>
        /// <param name="oldObject">旧对象</param>
        /// <param name="newObject">新对象</param>
        protected void AddChange<TDomainObject>( ICompareChange<TDomainObject> oldObject, TDomainObject newObject ) where TDomainObject : IDomainObject {
            if( Equals( oldObject, null ) )
                return;
            if( Equals( newObject, null ) )
                return;
            _changeValues.AddRange( oldObject.GetChanges( newObject ) );
        }

        /// <summary>
        /// 添加变更
        /// </summary>
        /// <param name="oldObjects">旧对象列表</param>
        /// <param name="newObjects">新对象列表</param>
        protected void AddChange<TDomainObject>( IEnumerable<ICompareChange<TDomainObject>> oldObjects, IEnumerable<TDomainObject> newObjects ) where TDomainObject : IDomainObject {
            if( Equals( oldObjects, null ) )
                return;
            if( Equals( newObjects, null ) )
                return;
            var oldList = oldObjects.ToList();
            var newList = newObjects.ToList();
            for( int i = 0; i < oldList.Count; i++ ) {
                if( newList.Count <= i )
                    return;
                AddChange( oldList[i], newList[i] );
            }
        }

        #endregion

        #region AddDescriptions(添加描述)

        /// <summary>
        /// 添加描述
        /// </summary>
        protected virtual void AddDescriptions() {
        }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected void AddDescription( string description ) {
            if( string.IsNullOrWhiteSpace( description ) )
                return;
            _description.Append( description );
        }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected void AddDescription<TValue>( string name, TValue value ) {
            if( string.IsNullOrWhiteSpace( value.SafeString() ) )
                return;
            _description.AppendFormat( "{0}:{1},", name, value );
        }

        /// <summary>
        /// 添加描述
        /// </summary>
        /// <param name="expression">属性表达式,范例：t => t.Name</param>
        protected void AddDescription<TProperty>( Expression<Func<T, TProperty>> expression ) {
            var member = Util.Helpers.Lambda.GetMember( expression );
            var description = Util.Helpers.Reflection.GetDisplayNameOrDescription( member );
            var value = member.GetPropertyValue( this );
            if ( Reflection.IsBool( member ) )
                value = Util.Helpers.Convert.ToBool( value ).Description();
            AddDescription( description, value );
        }

        #endregion

        #region ToString(输出对象状态)

        /// <summary>
        /// 输出对象状态
        /// </summary>
        public override string ToString() {
            _description = new StringBuilder();
            AddDescriptions();
            return _description.ToString().TrimEnd().TrimEnd( ',' );
        }

        #endregion
    }
}