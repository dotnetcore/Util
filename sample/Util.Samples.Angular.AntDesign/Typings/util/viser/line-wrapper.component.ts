//============== Viser折线图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { util } from "../index";
import { Model } from "./data/model";
import { DataSet } from '@antv/data-set';

/**
 * Viser折线图包装器
 */
@Component( {
    selector: 'x-line',
    template: `
        <v-chart [forceFit]="forceFit" [height]="height" [width]="width" [data]="data" [scale]="scale">
            <v-tooltip></v-tooltip>
            <v-axis></v-axis>
            <v-legend></v-legend>
            <v-line position="name*value" color="dataViewKey"></v-line>
            <v-point position="name*value" color="dataViewKey" shape="circle"></v-point>
        </v-chart>
    `
} )
export class LineWrapperComponent implements OnInit {
    /**
     * 高度，单位为 'px',默认值为 400
     */
    @Input() height?: number;
    /**
     * 宽度，默认单位为 'px'，当 forceFit: true 时宽度不生效
     */
    @Input() width?: number;
    /**
     * 宽度自适应开关，默认为 true，设置为 true 时表示自动取容器的宽度
     */
    @Input() forceFit?: boolean;
    /**
     * 数据比例尺
     */
    @Input() scale?;
    /**
     * 数据源，JSON 对象的数组或者 DataSet.View 对象
     */
    @Input() data?;
    /**
     * 数据源地址
     */
    @Input() url?: string;
    /**
     * 单击事件
     */
    @Output() onClick = new EventEmitter<any>();

    /**
     * 初始化Viser折线图包装器
     */
    constructor() {
        this.forceFit = true;
        this.height = 400;
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.load();
    }

    /**
     * 加载图表数据
     * @param url 数据源地址
     */
    load( url?: string ) {
        url = url || this.url;
        if ( !url ) {
            console.log( "图表url未设置" );
            return;
        }
        util.webapi.get<Model>( url ).handle( {
            ok: result => {
                this.data = this.toData( result );
            }
        } );
    }

    /**
     * 转成数据集
     */
    private toData( model: Model ) {
        if ( model == null )
            return null;
        let dataView = new DataSet.View().source( model.data );
        dataView.transform( {
            type: 'fold',
            fields: model.columns,
            key: 'dataViewKey',
            value: 'value',
        } );
        return dataView.rows;
    }
}