//============== Viser面积图包装器 =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input } from '@angular/core';
import { ComponentBase } from "./base/component-base";
import { ChartContext } from "viser-ng/es/chartService";

/**
 * Viser面积图包装器
 */
@Component( {
    selector: 'x-area',
    template: `
        <v-view [data]="data">
            <v-line *ngIf="showLine" position="name*value" color="key" [size]="lineSize"></v-line>
            <v-area position="name*value" color="key" ></v-area>
        </v-view>
    `
} )
export class AreaWrapperComponent extends ComponentBase {
    /**
     * 是否显示折线
     */
    @Input() showLine?;
    /**
     * 折线尺寸
     */
    @Input() lineSize?: number;

    /**
     * 初始化面积图包装器
     * @param context 图表上下文
     */
    constructor( public context: ChartContext ) {
        super( context );
        this.showLine = true;
        this.lineSize = 2;
    }
}