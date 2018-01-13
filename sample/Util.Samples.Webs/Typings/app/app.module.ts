import { NgModule, Injector } from '@angular/core';
//Angular模块
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FrameworkModule } from './framework.module';
import { AppRoutingModule } from './app.routing.module';
import { util } from '../util';
import { AppComponent } from './app.component';

import { BrandComponent } from "./admin/brand/brand.component";
import { SidenavComponent } from "./admin/sidenav/sidenav.component";
import { ItemComponent } from './admin/sidenav/item/item.component';

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { HeaderComponent } from "./admin/header/header.component";
import { FooterComponent } from "./admin/footer/footer.component";
import { ToolbarNotificationComponent } from './admin/header/notification/notification.component';
import { ToolbarUserComponent } from './admin/header/user/user.component';

import { SearchMenuComponent } from './public/searchMenu';



import { SidenavService } from './admin/sidenav/sidenav.service';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    suppressScrollX: true
};
/**
 * 应用根模块
 */
@NgModule({
    declarations: [
        AppComponent
        , BrandComponent, SidenavComponent, ItemComponent, HeaderComponent, ToolbarNotificationComponent, ToolbarUserComponent, FooterComponent,  SearchMenuComponent
    ],
    imports: [
        BrowserAnimationsModule,FrameworkModule, AppRoutingModule, PerfectScrollbarModule
    ],
    bootstrap: [AppComponent],
    providers: [
        { provide: 'sidenavService', useClass: SidenavService },
        {
            provide: PERFECT_SCROLLBAR_CONFIG,
            useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
        }
    ]
})
export class AppModule {
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.injector = injector;
    }
}