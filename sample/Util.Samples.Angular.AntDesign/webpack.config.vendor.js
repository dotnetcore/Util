const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");
const OptimizeCssnano = require('@intervolga/optimize-cssnano-plugin');

//第三方Js库
const jsModules = [
    'reflect-metadata',
    'zone.js',
    'rxjs',
    'rxjs-compat',
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
    '@antv/data-set',
    '@antv/g2',
    'viser-ng',
    '@delon/theme',
    '@delon/abc',
    '@delon/acl',
    '@delon/auth',
    '@delon/util'
];

//第三方Css库
const cssModules = [
    'ng-zorro-antd/ng-zorro-antd.css',
    '@delon/theme/styles/ng-alain.css'
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
            })
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
                { test: /\.css$/, use: extractCss.extract({ use: 'css-loader' }) },
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
        ].concat(isDev ? [] : new OptimizeCssnano({
            cssnanoOptions: { preset: ['default', { discardComments: { removeAll: true } }] }
        }))
    }
    return isDev ? [vendorJs, vendorCss] : [vendorCss];
}