//============== Viser条形图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input } from '@angular/core';
import { ComponentBase } from "./base/component-base";
import { ChartContext } from "viser-ng/es/chartService";

/**
 * Viser条形图包装器
 */
@Component( {
    selector: 'x-bar',
    template: `
        <v-view [data]="data">
            <v-axis *ngIf="!isStack" dataKey="value" position="right"></v-axis>
            <v-axis dataKey="name"></v-axis>
            <v-bar *ngIf="!isStack" position="name*value" color="key" [adjust]="adjust"></v-bar>
            <v-stack-bar *ngIf="isStack" position="name*value" color="key"></v-stack-bar>
        </v-view>
    `
} )
export class BarWrapperComponent extends ComponentBase {
    /**
     * 设置数据调整方式，支持的调整类型包括： 'stack', 'dodge', 'jitter', 'symmetric'
     */
    @Input() adjust;
    /**
     * 是否堆叠，默认为 false
     */
    @Input() isStack: boolean;

    /**
     * 初始化条形图包装器
     * @param context 图表上下文
     */
    constructor( public context: ChartContext ) {
        super( context );
        this.adjust = [{ type: 'dodge', marginRatio: 1 / 32 }];
    }
}