import { NgModule } from '@angular/core';
import { FrameworkModule } from "../framework.module";
import { DemoComponent } from "./demo.component";
import { DemoRoutingModule } from "./demo.routing.module";

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