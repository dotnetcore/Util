import { Component } from "@angular/core"
import { env } from '../env';

/**
 * 404 - 未找到页面
 */
@Component({
    selector: 'not-found',
    templateUrl: env.prod() ? './not-found.component.html' : '/Home/NotFoundPage'
})
export class NotFoundComponent {
}