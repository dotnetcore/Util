//============== Viser南丁格尔玫瑰图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input, OnInit } from '@angular/core';
import { ComponentBase } from "./base/component-base";
import { Model } from "./data/model";
import { ChartContext } from "viser-ng/es/chartService";

/**
 * Viser南丁格尔玫瑰图包装器
 */
@Component( {
    selector: 'x-rose-pie',
    template: `
        <v-view [data]="data">
            <v-sector position="name*value" [style]="style" color="name"></v-sector>
            <v-coord type="polar" [innerRadius]="innerRadius"></v-coord>
        </v-view>
        <v-legend dataKey="name" [position]="legendPosition" [offsetX]="legendOffsetX"></v-legend>
    `
} )
export class RosePieWrapperComponent extends ComponentBase implements OnInit {
    /**
     * 是否环状图，默认为 false
     */
    @Input() isDonut?: boolean;
    /**
     * 样式
     */
    @Input() style?;
    /**
     * 设置坐标系空心圆的半径，值范围为 0 至 1
     */
    @Input() innerRadius?: number;
    /**
     * 图例位置，默认为 right
     */
    @Input() legendPosition?: string;
    /**
     * 图例 x 方向的偏移值，数值类型，数值单位为 'px'，默认值为 -140。
     */
    @Input() legendOffsetX?: number;

    /**
     * 初始化南丁格尔玫瑰图包装器
     * @param context 图表上下文
     */
    constructor( public context: ChartContext ) {
        super( context );
        this.initStyle();
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.initCoord();
        super.ngOnInit();
    }

    /**
     * 初始化样式
     */
    private initStyle() {
        this.legendPosition = "right";
        this.legendOffsetX = -140;
        this.style = { stroke: "#fff", lineWidth: 1 };
    }

    /**
     * 初始化坐标系
     */
    private initCoord() {
        if ( !this.isDonut )
            return;
        if ( !this.innerRadius )
            this.innerRadius = 0.2;
    }

    /**
     * 转换数据
     */
    toData( model: Model ) {
        return model.data;
    }
}