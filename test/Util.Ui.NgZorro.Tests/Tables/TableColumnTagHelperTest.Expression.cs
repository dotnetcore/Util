using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格单元格测试 - 表达式解析
    /// </summary>
    public partial class TableColumnTagHelperTest {
        /// <summary>
        /// 测试属性表达式
        /// </summary>
        [Fact]
        public void TestFor() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置表达式
            _wrapper.SetExpression( UiConst.For, t => t.Code );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>code</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>{{row.code}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 布尔类型
        /// </summary>
        [Fact]
        public void TestFor_2() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置表达式
            _wrapper.SetExpression( UiConst.For, t => t.Enabled );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>启用</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>{{row.enabled?'是':'否'}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 布尔类型 - 多语言
        /// </summary>
        [Fact]
        public void TestFor_3() {
            //启用多语言
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );

            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置表达式
            _wrapper.SetExpression( UiConst.For, t => t.Enabled );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>{{'启用'|i18n}}</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>{{(row.enabled?'util.yes':'util.no')|i18n}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 枚举类型
        /// </summary>
        [Fact]
        public void TestFor_4() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置表达式
            _wrapper.SetExpression( UiConst.For, t => t.Gender );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>性别</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"row.gender===1\">util.female</ng-container>" );
            result.Append( "<ng-container *ngIf=\"row.gender===2\">util.male</ng-container>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 枚举类型 - 多语言
        /// </summary>
        [Fact]
        public void TestFor_5() {
            //启用多语言
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );

            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置表达式
            _wrapper.SetExpression( UiConst.For, t => t.Gender );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>{{'性别'|i18n}}</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"row.gender===1\">{{'util.female'|i18n}}</ng-container>" );
            result.Append( "<ng-container *ngIf=\"row.gender===2\">{{'util.male'|i18n}}</ng-container>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }
    }
}