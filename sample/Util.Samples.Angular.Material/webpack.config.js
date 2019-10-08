const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");
const AngularCompilerPlugin = require('@ngtools/webpack').AngularCompilerPlugin;

module.exports = (env) => {
    //是否开发环境
    const isDev = !(env && env.prod);
    const mode = isDev ? "development" : "production";

    //将css提取到单独文件中
    const extractCss = new Extract("app.css");

    //获取路径
    function getPath(path) {
        return pathPlugin.join(__dirname, path);
    }

    //打包js
    let jsConfig = {
        mode: mode,
        entry: { app: getPath("Typings/main.ts") },
        output: {
            publicPath: 'dist/',
            path: getPath("wwwroot/dist"),
            filename: "[name].js",
            chunkFilename: '[id].chunk.js'
        },
        resolve: {
            extensions: ['.js', '.ts']
        },
        devtool: "source-map",
        module: {
            rules: [
                { test: /\.ts$/, use: isDev ? ['awesome-typescript-loader?silent=true', 'angular-router-loader'] : ['@ngtools/webpack'] },
                { test: /\.js$/, loader: '@angular-devkit/build-optimizer/webpack-loader', options: { sourceMap: false } },
                { test: /\.html$/, use: 'html-loader?minimize=false' }
            ]
        },
        plugins: [
            new webpack.DefinePlugin({
                'process.env': { NODE_ENV: isDev ? JSON.stringify("dev") : JSON.stringify("prod") }
            })
        ].concat(isDev ? [
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            }),
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/util-manifest.json')
            })
        ] : [
                new AngularCompilerPlugin({
                    tsConfigPath: 'tsconfig.json',
                    entryModule: "Typings/app/app.module#AppModule"
                })
            ])
    }

    //打包css
    let cssConfig = {
        mode: mode,
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
    return [jsConfig, cssConfig];
}