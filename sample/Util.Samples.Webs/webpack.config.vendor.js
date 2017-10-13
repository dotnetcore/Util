const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");

//第三方库
const vendorModules = [
    'es6-shim',
    'reflect-metadata',
    'zone.js',
    '@angular/animations',
    '@angular/common',
    '@angular/compiler',
    '@angular/core',
    '@angular/forms',
    '@angular/http',
    '@angular/platform-browser',
    '@angular/platform-browser/animations',
    '@angular/platform-browser-dynamic',
    '@angular/router',
    '@angular/material',
    '@angular/material/prebuilt-themes/indigo-pink.css',
    'material-design-icons/iconfont/material-icons.css'
];

//env代表环境变量，如果传入env.production表示正式生产环境
module.exports = (env) => {
    //是否开发环境
    const isDev = !(env && env.production);

    //将css提取到单独文件中
    const extractCss = new Extract("vendor.css");

    //获取路径
    function getPath(path) {
        return pathPlugin.join(__dirname, path);
    }

    return  {
        //输入
        entry: { vendor: vendorModules },
        //输出
        output: {
            publicPath: 'dist/',
            path: getPath("wwwroot/dist"),
            filename: "[name].js",
            library: '[name]'
        },
        resolve: {
            extensions: ['.js']
        },
        devtool: "source-map",
        module: {
            rules: [
                //提取css文件
                { test: /\.css$/, use: extractCss.extract({ use: isDev ? 'css-loader' : 'css-loader?minimize' }) },
                //80K以内的图片直接序列化到css文件中，大于80K的复制到images目录
                {
                    test: /\.(png|jpg|woff|woff2|eot|ttf|svg)(\?|$)/, use: {
                        loader: 'url-loader',
                        options: {
                            limit: 81920,
                            name: "[name].[ext]",
                            outputPath: "images/"
                        }
                    }
                }
            ]
        },
        plugins: [
            extractCss,
            new webpack.DllPlugin({
                path: getPath("wwwroot/dist/[name]-manifest.json"),
                name: "[name]"
            }),
            new webpack.optimize.ModuleConcatenationPlugin(),
            new webpack.ContextReplacementPlugin(/\@angular\b.*\b(bundles|linker)/, getPath('./Typings')),
            new webpack.ContextReplacementPlugin(/angular(\\|\/)core(\\|\/)@angular/, getPath('./Typings')),
            new webpack.IgnorePlugin(/^vertx$/)
        ].concat(isDev ? [] : [new webpack.optimize.UglifyJsPlugin()])
    }
}