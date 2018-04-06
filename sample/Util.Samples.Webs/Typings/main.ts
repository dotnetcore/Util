//import 'es6-shim';
//import 'core-js/es6/symbol';
//import 'core-js/es6/object';
//import 'core-js/es6/function';
//import 'core-js/es6/parse-int';
//import 'core-js/es6/parse-float';
//import 'core-js/es6/number';
//import 'core-js/es6/math';
//import 'core-js/es6/string';
//import 'core-js/es6/date';
//import 'core-js/es6/array';
//import 'core-js/es6/regexp';
//import 'core-js/es6/map';
//import 'core-js/es6/weak-map';
//import 'core-js/es6/set';
//import 'core-js/es6/reflect';
//import 'core-js/es7/reflect';
import 'zone.js';
import 'hammerjs';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from "./app/app.module";

if (module.hot) {
    module.hot.accept();
} else {
    enableProdMode();
}
platformBrowserDynamic().bootstrapModule(AppModule).catch(ex => console.log(ex));