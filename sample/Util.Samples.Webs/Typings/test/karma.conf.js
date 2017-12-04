const webpack = require('webpack');

module.exports = function (config) {
    config.set({
        basePath: '.',
        frameworks: ['jasmine'],
        files: [
            '../../wwwroot/dist/polyfills.js',
            '../../wwwroot/dist/vendor.js',
            '../../wwwroot/dist/util.js',
            './karma_main.ts'
        ],
        preprocessors: {
            './karma_main.ts':['webpack']
        },
        reporters: ['progress'],
        port: 9876,
        colors: true,
        logLevel: config.LOG_INFO,
        autoWatch: true,
        browsers: ['PhantomJS'],
        mime: { 'application/javascript': ['ts'] },
        singleRun: false,
        webpack: {
            resolve: {
                extensions: ['.js', '.ts']
            },
            module: {
                rules: [
                    { test: /\.ts$/, include: /Typings/, use: ['awesome-typescript-loader?silent=true'] }
                ]
            },
            plugins: [
                new webpack.DllReferencePlugin({
                    manifest: require('../../wwwroot/dist/polyfills-manifest.json')
                }),
                new webpack.DllReferencePlugin({
                    manifest: require('../../wwwroot/dist/vendor-manifest.json')
                }),
                new webpack.DllReferencePlugin({
                    manifest: require('../../wwwroot/dist/util-manifest.json')
                })
            ]
        },
        webpackMiddleware: { stats: 'errors-only' }
    });
}
