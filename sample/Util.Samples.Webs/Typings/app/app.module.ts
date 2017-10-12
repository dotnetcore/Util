import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { MaterialModule } from './material.module';
import { AppComponent } from "./app.component"

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule, MaterialModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}