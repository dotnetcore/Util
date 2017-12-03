import { NgModule } from "@angular/core";
import { HttpModule, Http } from "@angular/http";
import {HttpHelper} from "./angular/http-helper";
import {Util} from "./index";

/**
 * Util公共操作模块
 */
@NgModule({
    imports: [HttpModule],
    providers: [
        { provide: HttpHelper, useClass: HttpHelper, deps: [Http] },
        { provide: Util, useClass: Util, deps: [HttpHelper] }
    ]
})
export class UtilModule {
}