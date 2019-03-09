import { Component, OnInit } from '@angular/core';
import { ZipService } from '@delon/abc';
import * as JSZip from 'jszip';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-zip',
  templateUrl: './zip.component.html',
})
export class ZipComponent {
  constructor(private zip: ZipService, private msg: NzMessageService) {
    this.zip.create().then(ret => (this.instance = ret));
  }

  // region: read

  list: any;
  private format(data: any) {
    const files = data.files;
    this.list = Object.keys(files).map(key => {
      return {
        name: key,
        dir: files[key].dir,
        date: files[key].date,
      };
    });
  }

  url() {
    this.zip.read(`./assets/tmp/demo.zip`).then(res => this.format(res));
  }

  change(e: Event) {
    const file = (e.target as HTMLInputElement).files[0];
    this.zip.read(file).then(res => this.format(res));
  }

  // endregion

  // region: write

  instance: JSZip = null;
  data: { path: string; url: string }[] = [
    { path: 'demo.docx', url: 'https://ng-alain.com/assets/demo.docx' },
    {
      path: '小程序标志.zip',
      url: 'https://wximg.gtimg.com/shake_tv/mina/standard_logo.zip',
    },
  ];

  download() {
    const promises: Promise<any>[] = [];
    this.data.forEach(item => {
      promises.push(this.zip.pushUrl(this.instance, item.path, item.url));
    });
    Promise.all(promises).then(
      () => {
        this.zip.save(this.instance).then(() => {
          this.msg.success('download success');
          this.data = [];
        });
      },
      (error: any) => {
        console.warn(error);
        this.msg.error(JSON.stringify(error));
      },
    );
  }

  // endregion
}
