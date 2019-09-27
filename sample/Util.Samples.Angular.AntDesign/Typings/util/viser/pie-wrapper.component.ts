//============== Viser饼图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input, OnInit } from '@angular/core';
import { ComponentBase } from "./base/component-base";
import { DataSet } from '@antv/data-set';
import { Model } from "./data/model";
import { ChartContext } from "viser-ng/es/chartService";

/**
 * Viser饼图包装器
 */
@Component( {
    selector: 'x-pie',
    template: `
        <v-view [data]="data" [scale]="scale">
            <v-pie position="percent" color="name" [style]="style" [label]="labelConfig"></v-pie>
            <v-coord type="theta" [radius]="radius" [innerRadius]="innerRadius"></v-coord>
        </v-view>
        <v-legend dataKey="name"></v-legend>
    `
} )
export class PieWrapperComponent extends ComponentBase implements OnInit {
    /**
     * 是否环状图，默认为 false
     */
    @Input() isDonut?: boolean;
    /**
     * 数据比例尺
     */
    @Input() scale?;
    /**
     * 饼图样式
     */
    @Input() style?;
    /**
     * 标签配置
     */
    @Input() labelConfig?;
    /**
     * 是否在内部显示标签,默认值为 false
     */
    @Input() isInnerLabel?: boolean;
    /**
     * 设置坐标系半径，值范围为 0 至 1
     */
    @Input() radius?: number;
    /**
     * 设置坐标系空心圆的半径，值范围为 0 至 1
     */
    @Input() innerRadius?: number;

    /**
     * 初始化饼图包装器
     * @param context 图表上下文
     */
    constructor( public context: ChartContext ) {
        super( context );
        this.initScale();
        this.initStyle();
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.initCoord();
        this.initLabelConfig();
        super.ngOnInit();
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
     * 初始化样式
     */
    private initStyle() {
        this.style = { stroke: "#fff", lineWidth: 1 };
    }

    /**
     * 初始化标签配置
     */
    private initLabelConfig() {
        if ( this.labelConfig )
            return;
        if ( this.isInnerLabel ) {
            this.labelConfig = this.getInnerLabelConfig();
            return;
        }
        this.labelConfig = this.getOutLabelConfig();
    }

    /**
     * 获取外部标签配置
     */
    private getOutLabelConfig() {
        return ['percent', {
            formatter: ( value, item ) => {
                return item.point.name + ': ' + value;
            },
        }];
    }

    /**
     * 获取内部标签配置
     */
    private getInnerLabelConfig() {
        return ['percent', {
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
     * 初始化坐标系
     */
    private initCoord() {
        if ( !this.isDonut )
            return;
        if ( !this.radius )
            this.radius = 0.75;
        if ( !this.innerRadius )
            this.innerRadius = 0.6;
    }

    /**
     * 转换数据
     */
    toData(model: Model) {
        let dataView = new DataSet.View().source(model.data);
        if (model.columns.length === 0)
            return dataView.rows;
        if (model.columns.length === 1) {
            dataView.transform({
                type: "percent",
                field: model.columns[0],
                dimension: 'name',
                as: 'percent'
            });
            return dataView.rows;
        }
        dataView.transform({
            type: "percent",
            fields: model.columns,
            dimension: 'name',
            as: 'percent'
        });
        return dataView.rows;
    }
}