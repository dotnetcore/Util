//============== Viser图表包装器基类 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Input, OnInit } from '@angular/core';
import { DataSet } from '@antv/data-set';
import { util } from "../../index";
import { Model } from "./../data/model";

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
                if ( result )
                    this.data = this.toData( result );
            }
        } );
    }

    /**
     * 转换数据
     */
    toData( model: Model ) {
        let dataView = new DataSet.View().source( model.data );
        dataView.transform( {
            type: "fold",
            fields: model.columns,
            key: "key",
            value: "value",
        } );
        return dataView.rows;
    }
}