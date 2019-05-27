import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { TitleService } from '@delon/theme';
import { NzModalService } from 'ng-zorro-antd';

/**
 * 应用根组件
 */
@Component( {
    selector: 'app',
    template: `<router-outlet></router-outlet>`,
} )
export class AppComponent implements OnInit {
    /**
     * 初始化
     */
    constructor( private router: Router, private titleSrv: TitleService, private modalSrv: NzModalService ) {
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.router.events
            .pipe( filter( evt => evt instanceof NavigationEnd ) )
            .subscribe( () => {
                this.titleSrv.setTitle();
                this.modalSrv.closeAll();
            } );
    }
}