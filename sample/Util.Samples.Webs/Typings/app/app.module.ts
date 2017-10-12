import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule, MatButtonModule, MatProgressBarModule, MatIconModule, MatDatepickerModule, MatNativeDateModule } from '@angular/material';
import { AppComponent } from "./app.component"

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule, BrowserAnimationsModule, MatInputModule, MatButtonModule, MatProgressBarModule, MatIconModule, MatDatepickerModule, MatNativeDateModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}