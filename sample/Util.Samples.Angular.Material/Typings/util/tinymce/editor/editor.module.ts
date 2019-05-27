import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EditorComponent } from './editor.component';

@NgModule({
  imports: [CommonModule, FormsModule],
  declarations: [EditorComponent],
  exports: [EditorComponent]
})
export class EditorModule {}
