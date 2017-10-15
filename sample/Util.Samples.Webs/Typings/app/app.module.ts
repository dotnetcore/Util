import { NgModule } from '@angular/core'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { MaterialModule } from "./material.module";
import { AppComponent } from "./app.component"
import { AppService, AppService2} from './app.service'

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserAnimationsModule, CommonModule, FormsModule,MaterialModule
    ],
    providers: [
        { provide: AppService, useClass: AppService, deps: [AppService2] },
        AppService2
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}