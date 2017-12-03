import { NgModule } from '@angular/core'
import { FrameworkModule } from "./framework.module";
import { AppComponent } from "./app.component"
import { AppService, AppService2 } from './app.service'
import { UtilModule } from "../util";

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        FrameworkModule,UtilModule
    ],
    providers: [
        { provide: AppService, useClass: AppService, deps: [AppService2] },
        AppService2
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}