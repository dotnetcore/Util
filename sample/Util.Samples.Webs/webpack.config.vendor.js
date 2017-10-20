const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");

//第三方Js库
const jsModules = [
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
    'es6-promise',
    'es6-shim',
    'reflect-metadata',
    'zone.js',
    'hammerjs',
    '@angular/material'
];

//第三方Css库
const cssModules = [
    '@angular/material/prebuilt-themes/indigo-pink.css',
    'material-design-icons/iconfont/material-icons.css',
    'font-awesome/css/font-awesome.css'
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

    let jsConfig =  {
        //输入
        entry: { vendor: jsModules },
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
        plugins: [
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

    //打包css
    let cssConfig = {
        //输入
        entry: { vendor: cssModules },
        //输出
        output: {
            publicPath: './',
            path: getPath("wwwroot/dist"),
            filename: "[name].css"
        },
        devtool: "source-map",
        module: {
            rules: [
                { test: /\.css$/, use: extractCss.extract({ use: isDev ? 'css-loader' : 'css-loader?minimize' }) },
                {
                    test: /\.(png|jpg|woff|woff2|eot|ttf|svg)(\?|$)/, use: {
                        loader: 'url-loader',
                        options: {
                            limit: 80000,
                            name: "[name].[ext]",
                            outputPath: "images/"
                        }
                    }
                }
            ]
        },
        plugins: [
            extractCss
        ]
    }
    return [jsConfig, cssConfig];
}