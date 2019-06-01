const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");
const AngularCompiler = require('@ngtools/webpack').AngularCompilerPlugin;

module.exports = (env) => {
    //环境
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
        optimization: {
            noEmitOnErrors: true
        },
        resolve: {
            extensions: ['.js', '.ts','.less','.css']
        },
        devtool: "source-map",
        module: {
            rules: [
                { test: /\.ts$/, use: isDev ? ['awesome-typescript-loader?silent=true', 'angular2-template-loader', 'angular-router-loader'] : ['@ngtools/webpack'] },
                { test: /\.html$/, use: 'html-loader?minimize=false' },
                {
                    test: /\.less$/,
                    use: [{
                        loader: 'to-string-loader'
                    }, {
                        loader: "css-loader"
                    }, {
                        loader: "less-loader",
                        options: {
                            javascriptEnabled: true
                        }
                    }]
                },
                {
                    test: /\.css$/, use: [{
                        loader: 'to-string-loader'
                    }, {
                        loader: "css-loader"
                    }]
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
        ] : new AngularCompiler({
            tsConfigPath: 'tsconfig.json',
            entryModule: "Typings/app/app.module#AppModule"
        }))
    }
    return [jsConfig];
}