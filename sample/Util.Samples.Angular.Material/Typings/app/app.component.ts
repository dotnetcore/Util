import { Component } from "@angular/core"
import { env } from './env';

/**
 * 根组件
 */
@Component({
    selector: 'app',
    templateUrl: env.prod() ? './app.component.html' : '/home/main'
})
export class AppComponent {
}