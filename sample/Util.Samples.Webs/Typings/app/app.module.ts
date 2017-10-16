import { NgModule } from '@angular/core'
import { FrameworkModule } from "./framework";
import { AppComponent } from "./app.component"
import { AppService, AppService2 } from './app.service'

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        FrameworkModule
    ],
    providers: [
        { provide: AppService, useClass: AppService, deps: [AppService2] },
        AppService2
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}