import { Component } from "@angular/core"
import { env } from '../../env';

/**
 * 404 - 未找到页面
 */
@Component({
    selector: 'not-found',
    templateUrl: env.prod() ? './not-found.component.html' : '/View/Home/NotFound'
})
export class NotFoundComponent {
}