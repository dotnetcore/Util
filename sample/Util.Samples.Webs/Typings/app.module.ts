import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { AppComponent } from "./app.component"
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatProgressBarModule } from '@angular/material';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,  MatButtonModule, MatProgressBarModule
    ],
    exports: [BrowserModule,  MatButtonModule, MatProgressBarModule],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}