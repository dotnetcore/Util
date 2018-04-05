////============== 单文件上传======================
////Copyright 2018 何镇汐
////Licensed under the MIT license
////================================================
//import { Component, EventEmitter, Input } from '@angular/core';
//import { MessageConfig } from '../config/message-config';
//import { FileInfo,FileType } from '../core/file-info';

///**
// * 单文件上传
// */
//@Component({
//    selector: 'single-file-upload',
//    template:`
//        <prime-file-upload #fileUpload [url]="url" mode="basic" [auto]="true" (onUpload)="upload($event)"></prime-file-upload>
//        <ng-container [ngSwitch]="file&&file.type">
//            <p-lightbox *ngSwitchCase="1" [images]="images"></p-lightbox>
//            <a *ngSwitchCase="2" target="_blank" href="{{file?.url}}">下载</a>
//        </ng-container>
//        <mat-progress-bar mode="determinate"[value]="fileUpload.progress" *ngIf="fileUpload.hasFiles()"></mat-progress-bar>
//    `
//})
//export class SingleFileUploadComponent {
//    /**
//     * 上传地址
//     */
//    @Input() url: string;

//    images: any[];

//    file:FileInfo;

//    constructor() {
//        this.images = new Array();
//    }

//    upload(result) {
//        this.file = JSON.parse(result.xhr.responseText);
//        this.file.type = FileType.Image;
//        this.images = new Array();
//        this.images.push({ source: `${this.file.url}`, thumbnail: `${this.file.url}`, title: this.file.fileName });
//    }
//}