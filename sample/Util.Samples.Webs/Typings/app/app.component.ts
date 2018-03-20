import { Component } from "@angular/core"
import { util } from "../util";
import {env} from "./env"

/**
 * 根组件
 */
@Component({
    selector: 'app',
    templateUrl: env.prod ? './app.component.html':'/home/main'
})
export class AppComponent {
}