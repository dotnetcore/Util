//============== Viser折线图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input, OnInit } from '@angular/core';
import { util } from "../index";
import { Model } from "./data/model";
import { DataSet } from '@antv/data-set';
import { ChartContext } from "viser-ng/es/chartService";

/**
 * Viser折线图包装器
 */
@Component( {
    selector: 'x-line',
    template: `
        <v-line position="name*value" color="dataViewKey"></v-line>
        <v-point position="name*value" color="dataViewKey" shape="circle"></v-point>
    `
} )
export class LineWrapperComponent implements OnInit {
    /**
     * 数据源，JSON 对象的数组或者 DataSet.View 对象
     */
    @Input() data?;
    /**
     * 数据源地址
     */
    @Input() url?: string;

    /**
     * 初始化Viser折线图包装器
     * @param context 图表上下文
     */
    constructor( private context: ChartContext) {
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
                this.context.config.data = this.toData( result );
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