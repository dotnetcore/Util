import { Component } from '@angular/core';
import { env } from '../../env';

@Component( {
    selector: 'app-basic-form',
    templateUrl: !env.dev() ? './html/basic-form.component.html' : '/View/Demo/Forms/BasicForm',
} )
export class BasicFormComponent {
}
