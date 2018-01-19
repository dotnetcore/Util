//============== 文件上传=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, NgZone, EventEmitter, Input,ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { FileUpload, DomHandler } from 'primeng/primeng';
import { MessageConfig } from '../config/message-config';
import { FileInfo } from "../core/file-info";
import { FileUploadComponent } from "./fileUpload.component";
/**
 * 文件上传组件，基于Prime文件上传
 */
@Component({
    selector: 'prime-single-fileUpload',
    template:`
        <prime-fileUpload #fileUpload [url]="url" mode="basic" [auto]="true" (onUpload)="onUpload($event)"></prime-fileUpload>
        <file-info-wrapper [fileInfo]="file"></file-info-wrapper>
        <mat-progress-bar mode="determinate"[value]="fileUpload.progress" *ngIf="fileUpload.hasFiles()"></mat-progress-bar>
    `,
    providers: [DomHandler]
})
export class SingleFileUploadComponent {

    @Input() url: string;

    @Input() id: string;

    @ViewChild("fileUpload") fileUpload: FileUploadComponent;

    file: FileInfo;

    /**
     * 初始化文件上传
     */
    constructor() {

    }

    onUpload(result) {
        this.file = JSON.parse(result.xhr.responseText);
    }

    getFileInfo() {
        //通过id获图片信息
        //util.webapi.get
    }

    initData() {
    }
}