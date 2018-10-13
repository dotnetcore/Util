import { Component, Injector } from '@angular/core';
import { EditComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';
import { env } from '../../env';
import { NgForm } from '@angular/forms';
/**
 * 应用程序编辑页
 */
@Component({
    selector: 'application-edit',
    templateUrl: env.prod() ? './html/application-edit.component.html' : '/view/systems/application/edit'
})
export class ApplicationEditComponent extends EditComponentBase<ApplicationViewModel> {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 创建视图模型
     */
    protected createModel() {
        var model = new ApplicationViewModel();
        model.registerEnabled = true;
        model.enabled = true;
        return model;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "application";
    }

    /**
     * 通过标识加载
     */
    protected loadById(id = null) {
        id = id || this.util.router.getParam("id");
        if (!id)
            return;
        this.util.webapi.get<ApplicationViewModel>(this.getByIdUrl(id)).handle({
            handler: result => {
                setTimeout(() => {
                    this.model = result;
                    this.registerValueChanges();
                    this.loadAfter(result);
                }, 100);
            }
        });
    }

    /**
     * 提交表单
     * @param form 表单
     * @param button 按钮
     */
    submit(form?: NgForm, button?) {
        this.util.form.submit({
            url: this.getSubmitUrl(),
            data: this.model,
            form: form,
            button: button,
            handler: () => {
                this.util.router.navigate(['systems','application']);
            }
        });
    }
}