module.exports = {
    //入口文件，__dirname表示webpack.config.js所在目录
    entry: __dirname + "/Typings/main.js",
    output: {
        //输出路径
        path: __dirname + "/wwwroot/js",
        //输出文件名
        filename: "site.js"
    }
}