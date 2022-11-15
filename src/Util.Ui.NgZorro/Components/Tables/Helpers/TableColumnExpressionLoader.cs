﻿using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表达式加载器
    /// </summary>
    public class TableColumnExpressionLoader : ExpressionLoaderBase {
        /// <summary>
        /// 加载模型信息
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="info">模型表达式信息</param>
        protected override void Load( Config config, ModelExpressionInfo info ) {
            LoadName( config, info );
            LoadDisplayName( config, info );
            LoadType( config, info );
        }

        /// <summary>
        /// 加载属性名
        /// </summary>
        protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Column, info.PropertyName );
        }

        /// <summary>
        /// 加载显示名称
        /// </summary>
        protected virtual void LoadDisplayName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Title, info.DisplayName );
        }

        /// <summary>
        /// 加载类型
        /// </summary>
        protected virtual void LoadType( Config config, ModelExpressionInfo info ) {
            if ( info.IsBool ) {
                config.SetAttribute( UiConst.Type, TableColumnType.Bool );
                return;
            }
        }
    }
}
