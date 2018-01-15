//Angular模块
import { NgModule, Injector } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//框架模块
import { PerfectScrollbarModule, PerfectScrollbarConfigInterface, PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { FrameworkModule } from './framework.module';
import { util } from '../util';

//根组件
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing.module';

//demo
import { BrandComponent } from "./admin/brand/brand.component";
import { SidenavComponent } from "./admin/sidenav/sidenav.component";
import { ItemComponent } from './admin/sidenav/item/item.component';
import { HeaderComponent } from "./admin/header/header.component";
import { FooterComponent } from "./admin/footer/footer.component";
import { ToolbarNotificationComponent } from './admin/header/notification/notification.component';
import { ToolbarUserComponent } from './admin/header/user/user.component';
import { SearchMenuComponent } from './public/searchMenu';
import { SidenavService } from './admin/sidenav/sidenav.service';

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