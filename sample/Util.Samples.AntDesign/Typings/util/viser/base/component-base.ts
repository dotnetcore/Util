//============== Viser图表包装器基类 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Input, OnInit } from '@angular/core';
import { DataSet } from '@antv/data-set';
import { util } from "../../index";
import { Model } from "./../data/model";
import { ChartContext } from "viser-ng/es/chartService";

/**
 * Viser图表包装器基类
 */
export class ComponentBase implements OnInit {
    /**
     * 数据源，JSON 对象的数组或者 DataSet.View 对象
     */
    @Input() data?;
    /**
     * 数据源地址
     */
    @Input() url?: string;
    /**
     * 查询参数
     */
    @Input() queryParam;

    /**
     * 初始化图表包装器
     * @param context 图表上下文
     */
    constructor( public context: ChartContext ) {
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
     * @param param 查询参数
     */
    load( url?: string, param = null ) {
        url = url || this.url;
        if ( !url )
            return;
        param = param || this.queryParam;
        this.sendRequest( url, param );
    }

    /**
     * 发送请求
     */
    sendRequest( url, param ) {
        util.webapi.get<Model>( url ).param( param ).handle( {
            ok: result => {
                if ( !result )
                    return;
                this.data = this.toData( result );
                if ( !this.hasData() )
                    this.clear();
            }
        } );
    }

    /**
     * 转换数据
     */
    toData( model: Model ) {
        if ( !model.data )
            return [];
        let dataView = new DataSet.View().source( model.data );
        dataView.transform( {
            type: "fold",
            fields: model.columns,
            key: "key",
            value: "value",
        } );
        return dataView.rows;
    }

    /**
     * 是否包含数据
     */
    hasData() {
        return this.data && this.data.length > 0;
    }

    /**
     * 清空并初始化
     */
    clear() {
        this.context.chartDivElement.innerHTML = null;
        this.context.chart = null;
    }
}