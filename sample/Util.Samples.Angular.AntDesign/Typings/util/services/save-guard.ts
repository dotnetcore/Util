//============== 表单保存提醒服务 ================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injectable } from "@angular/core";
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { util } from '../index';
import { MessageConfig } from '../config/message-config';

/**
 * 表单修改状态
 */
export interface IFormChange {
    /**
     * 是否已修改
     */
    isChange: () => Observable<boolean> | Promise<boolean> | boolean;
}

/**
 * 表单保存提醒服务
 */
@Injectable()
export class SaveGuard implements CanDeactivate<IFormChange> {
    /**
     * 是否允许离开当前页
     */
    canDeactivate(component: IFormChange, route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (component && component.isChange && component.isChange())
            return util.message.confirmAsync(MessageConfig.saveGuardConfirm);
        return true;
    }
}