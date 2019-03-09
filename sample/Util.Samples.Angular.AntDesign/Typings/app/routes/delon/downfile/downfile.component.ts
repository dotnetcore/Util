import { Component } from '@angular/core';

@Component({
  selector: 'app-down-file',
  templateUrl: './downfile.component.html',
})
export class DownFileComponent {
  fileTypes = ['.xlsx', '.docx', '.pptx', '.pdf'];

  data = {
    otherdata: 1,
    time: new Date(),
  };
}
