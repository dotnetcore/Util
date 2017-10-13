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

    return {
        //输入
        entry: { app: getPath("Typings/main.ts")},
        //输出
        output: {
            publicPath: 'dist/',
            path: getPath("wwwroot/dist"),
            filename: "[name].js"
        },
        resolve: {
            extensions: ['.js', '.ts'],
            modules: ['node_modules','wwwroot']
        },
        devtool: "source-map",
        module: {
            rules: [
                { test: /\.ts$/, use: ['awesome-typescript-loader?silent=true'] },
                { test: /\.css$/, use: extractCss.extract({ use: isDev ? 'css-loader' : 'css-loader?minimize' }) },
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
            extractCss,
            new webpack.DllReferencePlugin({
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            }),
            new webpack.optimize.ModuleConcatenationPlugin()
        ].concat(isDev ? [] : [
            new webpack.optimize.UglifyJsPlugin()
        ])
    }
}