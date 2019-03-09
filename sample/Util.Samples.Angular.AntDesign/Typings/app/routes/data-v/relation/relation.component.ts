import { Component, OnDestroy, ViewEncapsulation, OnInit } from '@angular/core';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-data-v-relation',
  templateUrl: './relation.component.html',
  styleUrls: ['./relation.component.less'],
})
export class RelationComponent implements OnInit, OnDestroy {
  ecIntance: any;

  options: any = {
    title: {
      text: 'User Releaction',
    },
    tooltip: {},
    animationDurationUpdate: 1500,
    animationEasingUpdate: 'quinticInOut',
    series: [
      {
        type: 'graph',
        layout: 'force',
        symbolSize: 60,
        focusNodeAdjacency: true,
        roam: true,
        categories: [
          {
            name: 'User',
          },
        ],
        label: {
          normal: {
            show: true,
            textStyle: {
              fontSize: 12,
            },
          },
        },
        force: {
          repulsion: 2000,
          gravity: 0.3,
        },
        edgeSymbol: ['circle', 'arrow'],
        edgeSymbolSize: [4, 10],
        draggable: true,
        tooltip: {
          triggerOn: 'click',
          formatter: item => {
            if (item.dataType === 'node')
              return `${item.data.name}：${item.data.arg}`;
            return item.name;
          },
        },
        data: Array(20)
          .fill({})
          .map((v, i) => {
            return {
              name: 'User' + i,
              arg: i + 10,
              category: 0,
            };
          }),
        links: [
          {
            source: 'User0',
            target: 'User1',
          },
          {
            source: 'User0',
            target: 'User2',
          },
          {
            source: 'User0',
            target: 'User3',
          },
          {
            source: 'User1',
            target: 'User4',
          },
          {
            source: 'User2',
            target: 'User5',
          },
          {
            source: 'User3',
            target: 'User6',
          },
          {
            source: 'User4',
            target: 'User7',
          },
          {
            source: 'User5',
            target: 'User8',
          },
          {
            source: 'User6',
            target: 'User9',
          },
          {
            source: 'User1',
            target: 'User10',
          },
          {
            source: 'User1',
            target: 'User11',
          },
          {
            source: 'User11',
            target: 'User12',
          },
          {
            source: 'User11',
            target: 'User13',
          },
          {
            source: 'User11',
            target: 'User14',
          },
          {
            source: 'User11',
            target: 'User15',
          },
          {
            source: 'User11',
            target: 'User16',
          },
          {
            source: 'User11',
            target: 'User17',
          },
          {
            source: 'User11',
            target: 'User18',
          },
          {
            source: 'User11',
            target: 'User19',
          },
        ],
        lineStyle: {
          normal: {
            opacity: 0.7,
            width: 1,
            curveness: 0.1,
          },
        },
      },
    ],
  };

  constructor(private http: _HttpClient) {}

  chartInit(ec) {
    this.ecIntance = ec;
  }

  ngOnInit() {
    window.addEventListener('resize', () => this.resize);
  }

  private resize() {
    if (this.ecIntance) this.ecIntance.resize();
  }

  ngOnDestroy(): void {
    window.removeEventListener('resize', () => this.resize);
  }
}
