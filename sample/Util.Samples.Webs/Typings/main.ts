import 'reflect-metadata'
import 'zone.js';
import 'es6-shim'

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'
import { AppModule } from "./app/app.module"

platformBrowserDynamic().bootstrapModule(AppModule).catch(ex => console.error(ex));