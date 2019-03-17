import 'reflect-metadata';
import 'zone.js';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from "./app/app.module";

if (module.hot) {
    module.hot.accept();
} else {
    enableProdMode();
}
platformBrowserDynamic().bootstrapModule( AppModule ).catch( ex => console.log( ex ) );