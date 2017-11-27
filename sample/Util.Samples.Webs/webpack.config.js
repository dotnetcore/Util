const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");

module.exports = (env) => {
    //是否开发环境
    const isDev = !(env && env.production);

    //将css提取到单独文件中
    const extractCss = new Extract("app.css");

    //获取路径
    function getPath(path) {
        return pathPlugin.join(__dirname, path);
    }

    //打包js
    let jsConfig = {
        entry: { app: getPath("Typings/app/main.ts") },
        output: {
            publicPath: 'dist/',
            path: getPath("wwwroot/dist"),
            filename: "[name].js"
        },
        resolve: {
            extensions: ['.js', '.ts']
        },
        devtool: "source-map",
        module: {
            rules: [
                { test: /\.ts$/, use: ['awesome-typescript-loader?silent=true'] }
            ]
        },
        plugins: [
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            }),
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/util-manifest.json')
            }),
            new webpack.optimize.ModuleConcatenationPlugin()
        ].concat(isDev ? [] : [
            new webpack.optimize.UglifyJsPlugin()
        ])
    }

    //打包css
    let cssConfig = {
        entry: { app: getPath("wwwroot/css/main.scss") },
        output: {
            publicPath: './',
            path: getPath("wwwroot/dist"),
            filename: "[name].css"
        },
        resolve: {
            modules: ['wwwroot']
        },
        devtool: "source-map",
        module: {
            rules: [
                {
                    test: /\.scss$/, use: extractCss.extract({
                        use: isDev ? ['css-loader', { loader: 'postcss-loader', options: { plugins: [require('autoprefixer')] } }, 'sass-loader']
                            : ['css-loader?minimize', { loader: 'postcss-loader', options: { plugins: [require('autoprefixer')] } }, 'sass-loader']
                    })
                },
                {
                    test: /\.(png|jpg|woff|woff2|eot|ttf|svg)(\?|$)/, use: {
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

    //打包测试
    let testConfig = {
        entry: { test: getPath("Typings/test/main.ts") },
        output: {
            publicPath: 'test/',
            path: getPath("wwwroot/test"),
            filename: "[name].js"
        },
        resolve: {
            extensions: ['.js', '.ts']
        },
        module: {
            rules: [
                { test: /\.ts$/, use: ['awesome-typescript-loader?silent=true'] }
            ]
        },
        plugins: [
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            }),
            new webpack.optimize.ModuleConcatenationPlugin()
        ]
    }
    return [jsConfig, cssConfig,testConfig];
}