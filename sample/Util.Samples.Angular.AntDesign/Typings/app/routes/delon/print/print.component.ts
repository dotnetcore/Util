import { Component } from '@angular/core';
import { NzMessageService, NzNotificationService } from 'ng-zorro-antd';
import { Lodop, LodopService } from '@delon/abc';

@Component({
  selector: 'app-print',
  templateUrl: './print.component.html',
})
export class PrintComponent {
  cog: any = {
    url: 'https://localhost:8443/CLodopfuncs.js',
    printer: '',
    paper: '',
    html: `
      <h1>Title</h1>
      <p>这~！@#￥%……&*（）——sdilfjnvn</p>
      <p>这~！@#￥%……&*（）——sdilfjnvn</p>
      <p>这~！@#￥%……&*（）——sdilfjnvn</p>
      <p>这~！@#￥%……&*（）——sdilfjnvn</p>
      <p>这~！@#￥%……&*（）——sdilfjnvn</p>
    `,
  };
  error = false;
  lodop: Lodop = null;
  pinters: any[] = [];
  papers: string[] = [];
  constructor(
    public lodopSrv: LodopService,
    private msg: NzMessageService,
    private notify: NzNotificationService,
  ) {
    this.lodopSrv.lodop.subscribe(({ lodop, ok }) => {
      if (!ok) {
        this.error = true;
        return;
      }
      this.error = false;
      this.msg.success(`打印机加载成功`);
      this.lodop = lodop;
      this.pinters = this.lodopSrv.printer;
    });
  }

  reload(options: any = { url: 'https://localhost:8443/CLodopfuncs.js' }) {
    this.pinters = [];
    this.papers = [];
    this.cog.printer = '';
    this.cog.paper = '';

    this.lodopSrv.cog = Object.assign({}, this.cog, options);
    this.error = false;
    if (options === null) this.lodopSrv.reset();
  }

  changePinter(name: string) {
    this.papers = this.lodop.GET_PAGESIZES_LIST(name, '\n').split('\n');
  }

  printing = false;
  print(isPrivew = false) {
    const LODOP = this.lodop;
    LODOP.PRINT_INITA(10, 20, 810, 610, '测试C-Lodop远程打印四步骤');
    LODOP.SET_PRINTER_INDEXA(this.cog.printer);
    LODOP.SET_PRINT_PAGESIZE(0, 0, 0, this.cog.paper);
    LODOP.ADD_PRINT_TEXT(
      1,
      1,
      300,
      200,
      '下面输出的是本页源代码及其展现效果：',
    );
    LODOP.ADD_PRINT_TEXT(20, 10, '90%', '95%', this.cog.html);
    LODOP.SET_PRINT_STYLEA(0, 'ItemType', 4);
    LODOP.NewPageA();
    LODOP.ADD_PRINT_HTM(20, 10, '90%', '95%', this.cog.html);
    if (isPrivew) LODOP.PREVIEW();
    else LODOP.PRINT();
  }
}
