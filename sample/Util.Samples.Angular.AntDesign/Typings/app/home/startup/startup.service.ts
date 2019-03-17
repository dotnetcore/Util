import { Injectable } from '@angular/core';
import { MenuService, SettingsService, TitleService } from '@delon/theme';
import { NzIconService } from 'ng-zorro-antd';
import { ICONS_AUTO } from './style-icons-auto';
import { ICONS } from './style-icons';
import { util } from '../../../util';

/**
 * 启动服务
 */
@Injectable()
export class StartupService {
    /**
     * 初始化启动服务
     * @param iconService 图标服务
     * @param menuService 菜单服务
     * @param settingService 设置服务
     * @param titleService 标题服务
     */
    constructor( iconService: NzIconService, private menuService: MenuService, private settingService: SettingsService, private titleService: TitleService ) {
        iconService.addIcon( ...ICONS_AUTO, ...ICONS );
    }

    /**
     * 加载系统配置
     */
    load() {
        return util.webapi.get( '/api/menu' ).handleAsync( {
            ok: ( result: any ) => {
                this.settingService.setApp( result.app );
                this.settingService.setUser( result.user );
                this.menuService.add( result.menu );
                this.titleService.suffix = result.app.name;
            }
        } );
    }
}
