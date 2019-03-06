const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");

//第三方Js库
const jsModules = [
    'zone.js',
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
    '@angular/router'
];

//第三方Css库
const cssModules = [
    'material-design-icons/iconfont/material-icons.css',
    'font-awesome/css/font-awesome.css'
];

module.exports = (env) => {
    //环境
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
            path: getPath("wwwroot/dist"),
            filename: "vendor.js"
        },
        resolve: {
            extensions: ['.js']
        },
        devtool: "source-map",
        plugins: [
            new webpack.DllPlugin({
                path: getPath("wwwroot/dist/[name]-manifest.json"),
                name: "[name]"
            })
        ]
    }

    //打包css
    let vendorCss = {
        mode: mode,
        entry: { vendor: cssModules },
        output: {
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
    return isDev ? [vendorJs, vendorCss] : [vendorCss];
}