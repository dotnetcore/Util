//============== 文件上传=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, NgZone } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { FileUpload, DomHandler } from 'primeng/primeng';
import { MessageConfig } from '../config/message-config';

/**
 * 文件上传组件，基于Prime文件上传
 */
@Component({
    selector: 'prime-fileUpload',
    template: `
        <div [ngClass]="'ui-fileupload ui-widget'" [ngStyle]="style" [class]="styleClass" *ngIf="mode === 'advanced'">
            <div class="ui-fileupload-buttonbar ui-widget-header ui-corner-top">
                <button class="ui-fileupload-choose" type="button" mat-icon-button [matTooltip]="chooseLabel">
                    <mat-icon class="fa-2x">add</mat-icon>
                    <input #advancedfileinput type="file" (change)="onFileSelect($event)" [multiple]="multiple" [accept]="accept" [disabled]="disabled" (focus)="onFocus()" (blur)="onBlur()">
                </button>

                <button *ngIf="!auto&&showUploadButton" type="button" (click)="upload()" [disabled]="!hasFiles()" mat-icon-button [matTooltip]="uploadLabel">
                    <mat-icon class="fa-2x">cloud_upload</mat-icon>
                </button>
                <button *ngIf="!auto&&showCancelButton" type="button" (click)="clear()" [disabled]="!hasFiles()" mat-icon-button [matTooltip]="cancelLabel">
                    <mat-icon class="fa-2x">clear</mat-icon>
                </button>
            
                <p-templateLoader [template]="toolbarTemplate"></p-templateLoader>
            </div>
            <div #content [ngClass]="{'ui-fileupload-content ui-widget-content ui-corner-bottom':true}" 
                (dragenter)="onDragEnter($event)" (dragleave)="onDragLeave($event)" (drop)="onDrop($event)">
                <p-progressBar [value]="progress" [showValue]="false" *ngIf="hasFiles()"></p-progressBar>
                
                <p-messages [value]="msgs"></p-messages>
                
                <div class="ui-fileupload-files" *ngIf="hasFiles()">
                    <div *ngIf="!fileTemplate">
                        <div class="ui-fileupload-row" *ngFor="let file of files; let i = index;">
                            <div><img [src]="file.objectURL" *ngIf="isImage(file)" [width]="previewWidth" /></div>
                            <div>{{file.name}}</div>
                            <div>{{formatSize(file.size)}}</div>
                            <div>
                                <button type="button" (click)="remove($event,i)" mat-icon-button [matTooltip]="cancelLabel">
                                    <mat-icon class="fa-2x">remove</mat-icon>
                                </button>
                            </div>
                        </div>
                    </div>
                    <div *ngIf="fileTemplate">
                        <ng-template ngFor [ngForOf]="files" [ngForTemplate]="fileTemplate"></ng-template>
                    </div>
                </div>
                <p-templateLoader [template]="contentTemplate"></p-templateLoader>
            </div>
        </div>
        <span class="ui-button ui-fileupload-choose ui-widget ui-state-default ui-corner-all ui-button-text-icon-left" *ngIf="mode === 'basic'" 
        (mouseup)="onSimpleUploaderClick($event)"
        [ngClass]="{'ui-fileupload-choose-selected': hasFiles(),'ui-state-focus': focus}">
            <span class="ui-button-icon-left fa" [ngClass]="{'fa-plus': !hasFiles()||auto, 'fa-upload': hasFiles()&&!auto}"></span>
            <span class="ui-button-text ui-clickable">{{auto ? chooseLabel : hasFiles() ? files[0].name : chooseLabel}}</span>
            <input #basicfileinput type="file" [accept]="accept" [multiple]="multiple" [disabled]="disabled"
                (change)="onFileSelect($event)" *ngIf="!hasFiles()" (focus)="onFocus()" (blur)="onBlur()">
        </span>
    `,
    providers: [DomHandler]
})
export class FileUploadComponent extends FileUpload {
    /**
     * 初始化文件上传
     */
    constructor(domHandler: DomHandler, sanitizer: DomSanitizer, zone: NgZone) {
        super(domHandler, sanitizer, zone);
        this.chooseLabel = MessageConfig.chooseFile;
        this.uploadLabel = MessageConfig.upload;
        this.cancelLabel = MessageConfig.cancel;
    }
}