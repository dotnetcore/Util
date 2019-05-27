//============== Viser柱状图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input } from '@angular/core';
import { ComponentBase } from "./base/component-base";
import { ChartContext } from "viser-ng/es/chartService";

/**
 * Viser柱状图包装器
 */
@Component( {
    selector: 'x-column',
    template: `
        <v-view [data]="data">
            <v-bar *ngIf="!isStack" position="key*value" color="name" [adjust]="adjust"></v-bar>
            <v-stack-bar *ngIf="isStack" position="key*value" color="name"></v-stack-bar>
        </v-view>
    `
} )
export class ColumnWrapperComponent extends ComponentBase {
    /**
     * 设置数据调整方式，支持的调整类型包括： 'stack', 'dodge', 'jitter', 'symmetric'
     */
    @Input() adjust;
    /**
     * 是否堆叠，默认为 false
     */
    @Input() isStack: boolean;

    /**
     * 初始化柱状图包装器
     * @param context 图表上下文
     */
    constructor( public context: ChartContext ) {
        super( context );
        this.adjust = [{ type: 'dodge', marginRatio: 1 / 32 }];
    }
}