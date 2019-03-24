import { Component } from '@angular/core';
import { env } from '../../env';

@Component( {
    selector: 'app-components-textbox',
    templateUrl: !env.dev() ? './html/textbox.component.html' : '/View/Components/Forms/TextBox',
} )
export class TextBoxComponent {
}
