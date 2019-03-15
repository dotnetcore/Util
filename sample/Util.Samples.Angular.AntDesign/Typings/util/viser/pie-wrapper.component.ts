//============== Viser饼图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input } from '@angular/core';
import { ComponentBase } from "./base/component-base";
import { DataSet } from '@antv/data-set';
import { Model } from "./data/model";

/**
 * Viser饼图包装器
 */
@Component( {
    selector: 'x-pie',
    template: `
        <v-view [data]="data" [scale]="scale">
            <v-pie position="percent" color="name" [style]="style" [label]="labelConfig"></v-pie>            
        </v-view>
        <v-legend dataKey="name"></v-legend>
    `
} )
export class PieWrapperComponent extends ComponentBase {
    /**
     * 饼图样式
     */
    @Input() style?;
    /**
     * 标签配置
     */
    @Input() labelConfig;
    /**
     * 数据比例尺
     */
    @Input() scale;
    
    /**
     * 初始化饼图包装器
     */
    constructor() {
        super();
        this.initStyle();
        this.initLabelConfig();
        this.initScale();
    }

    /**
     * 初始化样式
     */
    private initStyle() {
        this.style = { stroke: "#fff", lineWidth: 1 };
    }

    /**
     * 初始化标签配置
     */
    private initLabelConfig() {
        this.labelConfig = ['percent', {
            offset: -40,
            textStyle: {
                rotate: 0,
                textAlign: 'center',
                shadowBlur: 2,
                shadowColor: 'rgba(0, 0, 0, .45)'
            }
        }];
    }

    /**
     * 初始化数据比例尺
     */
    private initScale() {
        this.scale = [{
            dataKey: 'percent',
            min: 0,
            formatter: '.0%',
        }];
    }

    /**
     * 转换数据
     */
    toData( model: Model ) {
        let dataView = new DataSet.View().source( model.data );
        dataView.transform( {
            type: "percent",
            fields: model.columns,
            dimension: 'name',
            as: 'percent'
        } );
        return dataView.rows;
    }
}