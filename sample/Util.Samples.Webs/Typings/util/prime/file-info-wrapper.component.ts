//============== 下拉列表包装器===================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FileInfo } from "../core/file-info";

/**
 * Mat下拉列表包装器
 */
@Component({
    selector: 'file-info-wrapper',
    template: `
        <ng-container *ngIf="module === 1">
            <p-lightbox styleClass="lbox" [images]="images"></p-lightbox>
        </ng-container>
        <ng-container *ngIf="module === 2">
            <a target="_blank" href="{{fileInfo.url}}"><span>下载</span></a>
        </ng-container>
        <ng-container *ngIf="module === 3">
            <a target="_blank" href="{{fileInfo.url}}"><span>下载</span></a>
        </ng-container>
        <ng-container *ngIf="module === 0">
            <span>未上传</span>
        </ng-container>
    `,
    styles: [`
        
    `]
})
export class FileInfoWrapperComponent implements OnInit {

	 //资源地址
    _fileInfo: FileInfo;
    @Input()
    set fileInfo(fileInfo: FileInfo) {
        this._fileInfo = fileInfo;
		this.ngAfterContentInit();
    }
    get fileInfo(): FileInfo {
        return this._fileInfo;
    }

    images: any[];

    //1图片//2视频//3其他文件//0错误
    module: FileInfoModule;

	@Input() imgHeight;

    /**
     * 初始化Mat下拉列表包装器
     */
    constructor() {
	    this.imgHeight = 40;
    }

    ngOnInit() {

    }

    ngAfterContentInit() {
        if (!this.fileInfo || !this.fileInfo.url) {
            this.module = FileInfoModule.none;
        } else {
            let extension = this.fileInfo.extension;
            switch (extension) {
                case undefined:
                case "":
                case null:
                    this.module = FileInfoModule.none;
                    break;
                case ".jpg":
                case ".png":
                case ".gif":
                    this.module = FileInfoModule.image;
                    this.images = [];
                    this.images.push({ source: `${this.fileInfo.url}`, thumbnail: `${this.fileInfo.url}`, title: this.fileInfo.fileName });
                    break;
                case ".mp4":
                case ".flv":
                    this.module = FileInfoModule.video;
                    break;
                default:
                    this.module = FileInfoModule.other;
                    break;
            }
        }
    }

    imgPreview() {

    }
}

export enum FileInfoModule {

    none = 0,

    image = 1,

    video = 2,

    other = 3
}