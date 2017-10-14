import 'reflect-metadata'
import 'zone.js';
import 'es6-shim'
import 'hammerjs'
import 'css/style.css'
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'
import { AppModule } from "./app/app.module"

if (module.hot) {
    module.hot.accept();
} else {
    enableProdMode();
}
platformBrowserDynamic().bootstrapModule(AppModule)