const pathPlugin = require('path');
const webpack = require('webpack');

module.exports = (env) => {
    //环境
    const isDev = !(env && env.prod);
    const mode = isDev ? "development" : "production";

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
                { test: /\.ts$/, use: isDev ? ['awesome-typescript-loader?silent=true', 'angular-router-loader'] : [] }
            ]
        },
        plugins: [
            new webpack.DefinePlugin({
                'process.env': { NODE_ENV: isDev ? JSON.stringify("dev") : JSON.stringify("prod") }
            })
        ].concat(isDev ? [
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ] : [
        ])
    }
    return [jsConfig];
}