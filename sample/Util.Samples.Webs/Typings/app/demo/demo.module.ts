import { NgModule } from '@angular/core';
import { FrameworkModule } from "../framework.module";
import { DemoRoutingModule } from "./demo.routing.module";
import { DemoComponent, A1, B1, C1, D1 } from "./demo.component";

@NgModule({
    declarations: [
        DemoComponent, A1, B1, C1, D1
    ],
    imports: [
        FrameworkModule,DemoRoutingModule
    ],
    exports: [
        DemoComponent, A1, B1, C1, D1
    ]
})
export class DemoModule {
}