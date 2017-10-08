import './polyfills'
import 'reflect-metadata'
import 'zone.js'
import "@angular/material/prebuilt-themes/indigo-pink.css"


import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'
import { AppModule } from "./app.module"

platformBrowserDynamic().bootstrapModule(AppModule).catch(ex => console.error(ex));