//============== 表单操作 ========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { NgForm } from '@angular/forms';
import { FailResult } from '../core/result';
import { HttpMethod } from '../angular/http-helper';
import { WebApi } from './webapi';
import { RouterHelper } from '../angular/router-helper';
import { Message } from './message';
import { MessageConfig } from '../config/message-config';
import { Dialog } from './dialog';

/**
 * 表单操作
 */
export class Form {
    /**
     * 提交表单
     * @param options 表单提交参数
     */
    submit( options: IFormSubmitOption ): void {
        if ( !this.validateSubmit( options ) )
            return;
        if ( !options.confirm ) {
            this.submitForm( options );
            return;
        }
        Message.confirm( {
            title: options.confirmTitle,
            message: options.confirm,
            ok: () => this.submitForm( options ),
            cancel: options.complete
        } );
    }

    /**
     * 提交表单验证
     */
    private validateSubmit( options: IFormSubmitOption ) {
        if ( !options ) {
            Message.error( "表单参数 options: FormSubmitOptions 未设置" );
            return false;
        }
        if ( options.form && !options.form.valid )
            return false;
        if ( !options.url ) {
            Message.error( "表单url未设置" );
            return false;
        }
        if ( !options.data ) {
            Message.error( "表单数据未设置" );
            return false;
        }
        return true;
    }

    /**
     * 提交表单
     */
    private submitForm( options: IFormSubmitOption ) {
        this.initHttpMethod( options );
        WebApi.send( options.url, options.httpMethod, options.data )
            .header( options.header )
            .button( options.button )
            .loading( options.loading || false )
            .handle( {
                before: () => {
                    return options.before && options.before( options.data );
                },
                ok: result => {
                    this.okHandler( options, result );
                },
                fail: result => {
                    this.failHandler( options, result );
                },
                complete: options.complete
            } );
    }

    /**
     * 初始化Http方法
     * @param options
     */
    private initHttpMethod( options: IFormSubmitOption ) {
        if ( options.httpMethod )
            return;
        options.httpMethod = options.data.id ? HttpMethod.Put : HttpMethod.Post;
    }

    /**
     * 失败处理函数
     */
    private failHandler( options: IFormSubmitOption, result ) {
        if ( options.form)
            ( options.form as { submitted: boolean } ).submitted = false;
        options.fail && options.fail( result );
        if ( options.showErrorMessage !== false )
            Message.error( result.message );
    }

    /**
     * 成功处理函数
     */
    private okHandler( options: IFormSubmitOption, result ) {
        options.ok && options.ok( result );
        if ( options.showMessage !== false )
            Message.success( options.message || MessageConfig.successed );
        if ( options.back )
            RouterHelper.back();
        if ( options.closeDialog ) {
            result = result || "ok";
            Dialog.close( result );
        }
    }
}

/**
 * 表单提交参数
 */
export interface IFormSubmitOption {
    /**
     * 服务端地址
     */
    url: string;
    /**
     * 数据
     */
    data;
    /**
     * Http头
     */
    header?: { name: string, value }[];
    /**
     * Http方法
     */
    httpMethod?: HttpMethod;
    /**
     * 确认消息,设置该项则提交前需要确认
     */
    confirm?: string;
    /**
     * 确认标题
     */
    confirmTitle?: string;
    /**
     * 表单
     */
    form?: NgForm;
    /**
     * 按钮实例，在请求期间禁用该按钮
     */
    button?,
    /**
     * 请求时显示进度条，默认为false
     */
    loading?: boolean,
    /**
     * 提交失败是否显示错误提示，默认为true
     */
    showErrorMessage?: boolean;
    /**
     * 提交成功后是否显示成功提示，默认为true
     */
    showMessage?: boolean;
    /**
     * 提交成功后显示的提示消息，默认为"操作成功"
     */
    message?: string;
    /**
     * 提交成功后是否返回上一个视图，默认为false
     */
    back?: boolean;
    /**
     * 提交成功后关闭弹出层，当在弹出层中编辑时使用，默认为false
     */
    closeDialog?: boolean;
    /**
     * 提交前处理函数，返回false则取消提交
     * @param data 数据
     */
    before?: ( data ) => boolean;
    /**
     * 提交成功处理函数
     * @param result 结果
     */
    ok?: ( result ) => void;
    /**
     * 提交失败处理函数
     */
    fail?: ( result: FailResult ) => void;
    /**
     * 操作完成处理函数，注意：该函数在任意情况下都会执行
     */
    complete?: () => void;
}