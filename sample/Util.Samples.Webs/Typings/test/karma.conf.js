module.exports = function(config) {
    config.set({
        basePath: '',
        frameworks: ['jasmine'],
        files: [
            '../../wwwroot/test/test.js'
        ],
        exclude: [
        ],
        preprocessors: {
        },
        reporters: ['progress'],
        port: 9876,
        colors: true,
        logLevel: config.LOG_INFO,
        autoWatch: true,
        browsers: ['PhantomJS'],
        mime: { 'application/javascript': ['ts'] },
        singleRun: false,
        webpack: require('../../webpack.config.js')().filter(config => config.target !== 'node'),
        webpackMiddleware: { stats: 'errors-only' }
    });
}
