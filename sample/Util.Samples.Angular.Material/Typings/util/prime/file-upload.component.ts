////============== 文件上传=========================
////Copyright 2018 何镇汐
////Licensed under the MIT license
////================================================
//import { Component, NgZone, ElementRef } from '@angular/core';
//import { DomSanitizer } from '@angular/platform-browser';
//import { FileUpload, DomHandler } from 'primeng/primeng';
//import { MessageConfig } from '../config/message-config';

///**
// * 文件上传，基于Prime文件上传组件
// */
//@Component({
//    selector: 'prime-file-upload',
//    template:`
//        <div [ngClass]="'ui-fileupload ui-widget'" [ngStyle]="style" [class]="styleClass" *ngIf="mode === 'advanced'">
//            <div class="ui-fileupload-buttonbar ui-widget-header ui-corner-top">
//                <button class="ui-fileupload-choose" type="button" mat-icon-button [matTooltip]="chooseLabel">
//                    <mat-icon class="fa-2x">add</mat-icon>
//                    <input #advancedfileinput type="file" (change)="onFileSelect($event)" [multiple]="true" [accept]="accept" [disabled]="disabled" (focus)="onFocus()" (blur)="onBlur()">
//                </button>

//                <button *ngIf="!auto&&showUploadButton" type="button" (click)="upload()" [disabled]="!hasFiles()" mat-icon-button [matTooltip]="uploadLabel">
//                    <mat-icon class="fa-2x">cloud_upload</mat-icon>
//                </button>
//                <button *ngIf="!auto&&showCancelButton" type="button" (click)="clear()" [disabled]="!hasFiles()" mat-icon-button [matTooltip]="cancelLabel">
//                    <mat-icon class="fa-2x">clear</mat-icon>
//                </button>
            
//                <ng-container *ngTemplateOutlet="toolbarTemplate"></ng-container>
//            </div>
//            <div #content [ngClass]="{'ui-fileupload-content ui-widget-content ui-corner-bottom':true}" 
//                (dragenter)="onDragEnter($event)" (dragleave)="onDragLeave($event)" (drop)="onDrop($event)">
//                <mat-progress-bar mode="determinate"[value]="progress" *ngIf="hasFiles()" [ngStyle]="getProgressStyles()"></mat-progress-bar>
                
//                <p-messages [value]="msgs"></p-messages>
                
//                <div class="ui-fileupload-files" *ngIf="hasFiles()">
//                    <div *ngIf="!fileTemplate">
//                        <div class="ui-fileupload-row" *ngFor="let file of files; let i = index;">
//                            <div><img [src]="file.objectURL" *ngIf="isImage(file)" [width]="previewWidth" /></div>
//                            <div>{{file.name}}</div>
//                            <div>{{formatSize(file.size)}}</div>
//                            <div>
//                                <button type="button" (click)="remove($event,i)" mat-icon-button [matTooltip]="cancelLabel">
//                                    <mat-icon>clear</mat-icon>
//                                </button>
//                            </div>
//                        </div>
//                    </div>
//                    <div *ngIf="fileTemplate">
//                        <ng-template ngFor [ngForOf]="files" [ngForTemplate]="fileTemplate"></ng-template>
//                    </div>
//                </div>
//                <ng-container *ngTemplateOutlet="contentTemplate"></ng-container>
//            </div>
//        </div>
//        <button *ngIf="mode === 'basic'"  class="ui-fileupload-choose" type="button" mat-icon-button [matTooltip]="uploadLabel" (mouseup)="onSimpleUploaderClick($event)">
//            <mat-icon class="fa-2x">cloud_upload</mat-icon>
//            <input #basicfileinput type="file" [accept]="accept" [multiple]="false" [disabled]="disabled"
//                   (change)="onFileSelect($event)" *ngIf="!hasFiles()" (focus)="onFocus()" (blur)="onBlur()">
//        </button>
//    `,
//    styles: [`
//        .mat-progress-bar{
//            height:2px;
//        }
//    `],
//    providers: [DomHandler]
//})
//export class FileUploadComponent extends FileUpload {
//    /**
//     * 初始化文件上传
//     */
//    constructor(el: ElementRef, domHandler: DomHandler, sanitizer: DomSanitizer, zone: NgZone) {
//        super(el, domHandler, sanitizer, zone);
//        this.chooseLabel = MessageConfig.chooseFile;
//        this.uploadLabel = MessageConfig.upload;
//        this.cancelLabel = MessageConfig.cancel;
//    }

//    /**
//     * 获取进度条样式
//     */
//    getProgressStyles() {
//        return {
//            'position': 'absolute',
//            'top': '0px',
//            'left': '0px'
//        };
//    }
//}