/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 * 配置文档：https://docs.ckeditor.com/ckeditor4/latest/api/CKEDITOR_config.html
 */

CKEDITOR.editorConfig = function( config ) {
    //皮肤
    config.skin = 'moono-lisa';

    //颜色
    config.uiColor = '#ffffff';

    //移除上传图片的高级选项卡
    config.removeDialogTabs = 'image:advanced;link:advanced';
    config.image_previewText = ' ';
};
