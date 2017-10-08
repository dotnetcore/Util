//根目录,__dirname表示webpack.config.js所在目录
const rootPath = __dirname;
const webpack = require('webpack');

module.exports = () => {
    return {
        //入口文件
        entry: {
            "main": rootPath + "/Typings/main.ts"
        },
        output: {
            //输出路径
            path: rootPath + "/wwwroot/dist",
            //输出文件名
            filename: "main.js"
        },
        //待处理文件扩展名
        resolve: {
            extensions: ['.ts', '.js', '.css'],
            modules: [
                rootPath + '/Typings/',
                'node_modules'
            ]
        },
        //生成source map文件
        devtool: "source-map",
        module: {
            //将ts编译为js
            rules: [{ test: /\.ts$/, loader: "ts-loader" },{ test: /\.css$/, use: ['style-loader', 'css-loader'] }]
        },
        plugins: [
            //优化生成结构
            //new webpack.optimize.ModuleConcatenationPlugin(),
            //压缩js
            //new webpack.optimize.UglifyJsPlugin()
        ]
    }
}