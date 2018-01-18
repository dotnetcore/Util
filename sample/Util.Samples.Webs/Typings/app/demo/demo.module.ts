import { NgModule } from '@angular/core';
import { FrameworkModule } from "../framework.module";
import { DemoRoutingModule } from "./demo.routing.module";
import { DemoComponent } from "./demo.component";

@NgModule({
    declarations: [
        DemoComponent
    ],
    imports: [
        FrameworkModule,DemoRoutingModule
    ],
    exports: [
        DemoComponent
    ]
})
export class DemoModule {
}