const pathPlugin = require('path');
const webpack = require('webpack');
var Extract = require("extract-text-webpack-plugin");

module.exports = (env) => {
    //是否开发环境
    const isDev = !(env && env.production);

    //获取路径
    function getPath(path) {
        return pathPlugin.join(__dirname, path);
    }
    return {
        //输入
        entry: getPath("Typings/main.ts"),
        //输出
        output: {
            path: getPath("wwwroot/dist"),
            filename: "app.js"
        },
        resolve: {
            extensions: ['.js', '.ts']
        },
        devtool: "source-map",
        module: {
            rules: [{ test: /\.ts$/, use: "ts-loader" },{ test: /\.css$/, use: ['style-loader', 'css-loader'] }]
        },
        plugins: [
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            }),
            new webpack.optimize.ModuleConcatenationPlugin()
        ]
    }
}