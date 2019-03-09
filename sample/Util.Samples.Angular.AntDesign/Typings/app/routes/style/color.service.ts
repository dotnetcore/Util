import { Injectable } from '@angular/core';

@Injectable()
export class ColorService {
  APP_COLORS = {
    primary: '#1890ff',
    success: '#52c41a',
    error: '#f5222d',
    warning: '#fadb14',
    red: '#f5222d',
    volcano: '#fa541c',
    orange: '#fa8c16',
    gold: '#faad14',
    yellow: '#fadb14',
    lime: '#a0d911',
    green: '#52c41a',
    cyan: '#13c2c2',
    blue: '#1890ff',
    geekblue: '#2f54eb',
    purple: '#722ed1',
    magenta: '#eb2f96',
  };

  get names() {
    return Object.keys(this.APP_COLORS).filter((name, index) => index > 3);
  }

  get brands() {
    return ['primary', 'success', 'error', 'warning'];
  }
}
