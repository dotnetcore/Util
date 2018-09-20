const pathPlugin = require('path');
const webpack = require('webpack');

module.exports = (env) => {
    //是否开发环境
    const isDev = !(env && env.prod);
    const mode = isDev ? "development" : "production";

    //获取路径
    function getPath(path) {
        return pathPlugin.join(__dirname, path);
    }

    //打包util脚本库
    return {
        mode: mode,
        entry: { util: [getPath("Typings/util/index.ts")] },
        output: {
            publicPath: 'dist/',
            path: getPath("wwwroot/dist"),
            filename: "[name].js",
            library: '[name]'
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
            new webpack.DllPlugin({
                path: getPath("wwwroot/dist/[name]-manifest.json"),
                name: "[name]"
            })
        ]
    }
}