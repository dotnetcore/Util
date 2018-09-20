const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");

//第三方Js库
const jsModules = [
    'reflect-metadata',
    'zone.js',
    'moment',
    '@angular/animations',
    '@angular/common',
    '@angular/common/http',
    '@angular/compiler',
    '@angular/core',
    '@angular/forms',
    '@angular/elements',
    '@angular/platform-browser',
    '@angular/platform-browser/animations',
    '@angular/platform-browser-dynamic',
    '@angular/router',
    '@angular/cdk/esm5/collections.es5',
    '@angular/flex-layout',
    '@angular/material',
    'primeng/primeng',
    'lodash',
    "echarts-ng2"
];

//第三方Css库
const cssModules = [
    '@angular/material/prebuilt-themes/indigo-pink.css',
    'material-design-icons/iconfont/material-icons.css',
    'font-awesome/css/font-awesome.css',
    'primeicons/primeicons.css',
    'primeng/resources/themes/omega/theme.css',
    'primeng/resources/primeng.min.css'
];

module.exports = (env) => {
    //是否开发环境
    const isDev = !(env && env.prod);
    const mode = isDev ? "development" : "production";

    //将css提取到单独文件中
    const extractCss = new Extract("vendor.css");

    //获取路径
    function getPath(path) {
        return pathPlugin.join(__dirname, path);
    }

    //打包第三方Js库
    let vendorJs = {
        mode: mode,
        entry: { vendor: jsModules },
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
            new webpack.ContextReplacementPlugin(/\@angular\b.*\b(bundles|linker)/, getPath('./Typings')),
            new webpack.ContextReplacementPlugin(/angular(\\|\/)core(\\|\/)@angular/, getPath('./Typings')),
            new webpack.IgnorePlugin(/^vertx$/)
        ]
    }

    //打包css
    let vendorCss = {
        mode: mode,
        entry: { vendor: cssModules },
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
                    test: /\.(png|jpg|gif|woff|woff2|eot|ttf|svg)(\?|$)/, use: {
                        loader: 'url-loader',
                        options: {
                            limit: 20000,
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
    return isDev ? [ vendorJs, vendorCss] : [vendorCss];
}