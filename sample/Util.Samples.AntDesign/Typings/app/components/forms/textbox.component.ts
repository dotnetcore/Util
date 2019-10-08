import { Component } from '@angular/core';
import { env } from '../../env';
import { util } from '../../../util';

@Component( {
    selector: 'app-components-textbox',
    templateUrl: !env.dev() ? './html/text-box.component.html' : '/View/Components/Forms/TextBox',
} )
export class TextBoxComponent {
}
