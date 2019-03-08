import 'zone.js';
import 'reflect-metadata';
import { Component, enableProdMode, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ViserModule } from 'viser-ng';
import { data, scale } from './data'
const DataSet = require('@antv/data-set');

const ds: any = new DataSet();
const dv = ds.createView().source(data);
dv.transform({
  type: 'percent',
  field: 'value',
  dimension: 'country',
  groupBy: ['year'],
  as: 'percent'
});

const filter = [{
  dataKey: 'country',
  callback: (ev) => {
    return ev === 'Europe';
  }
}];

@Component({
  selector: 'app',
  template: `
  <div>
    <v-chart [forceFit]="forceFit" [height]="height" [data]="data" [scale]="scale"
      renderer="svg" [filter]="filter">
      <v-tooltip [onShow]="onTooltipShow" [onHide]="onTooltipHide" [onChange]="onTooltipChange"></v-tooltip>
      <v-axis></v-axis>
      <v-stack-bar position='year*percent' color='country' [style]="{ stroke: '#fff', lineWidth: 1 }" ></v-stack-bar>
    </v-chart>
  </div>
  `
})
class AppComponent {
  forceFit: boolean= true;
  height: number = 400;
  data = dv.rows;
  scale = scale;
  fields = ['cut', 'clarity'];
  filter = filter;
  onTooltipShow = () => { console.log('show'); };
  onTooltipHide = () => { console.log('hide'); };
  onTooltipChange = () => { console.log('change'); };
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    ViserModule
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule {}
