import { HttpRequest } from '@angular/common/http';
import { MockRequest } from '@delon/mock';

const list = [];

for (let i = 0; i < 46; i += 1) {
  list.push({
    key: i,
    disabled: i % 6 === 0,
    href: 'https://ant.design',
    avatar: [
      'https://gw.alipayobjects.com/zos/rmsportal/eeHMaZBwmTvLdIwMfBpg.png',
      'https://gw.alipayobjects.com/zos/rmsportal/udxAbMEhpwthVVcjLXik.png',
    ][i % 2],
    no: `TradeCode ${i}`,
    title: `一个任务名称 ${i}`,
    owner: '曲丽丽',
    description: '这是一段描述',
    callNo: Math.floor(Math.random() * 1000),
    status: Math.floor(Math.random() * 10) % 4,
    updatedAt: new Date(`2017-07-${i < 18 ? '0'+(Math.floor(i / 2) + 1) : (Math.floor(i / 2) + 1)}`),
    createdAt: new Date(`2017-07-${i < 18 ? '0'+(Math.floor(i / 2) + 1) : (Math.floor(i / 2) + 1)}`),
    progress: Math.ceil(Math.random() * 100),
  });
}

function getRule(params: any) {
  let ret = [...list];
  if (params.sorter) {
    const s = params.sorter.split('_');
    ret = ret.sort((prev, next) => {
      if (s[1] === 'descend') {
        return next[s[0]] - prev[s[0]];
      }
      return prev[s[0]] - next[s[0]];
    });
  }
  if (params.statusList && params.statusList.length > 0) {
    ret = ret.filter(data => params.statusList.indexOf(data.status) > -1);
  }
  if (params.no) {
    ret = ret.filter(data => data.no.indexOf(params.no) > -1);
  }
  return ret;
}

function removeRule(nos: string): boolean {
  nos.split(',').forEach(no => {
    const idx = list.findIndex(w => w.no === no);
    if (idx !== -1) list.splice(idx, 1);
  });
  return true;
}

function saveRule(description: string) {
  const i = Math.ceil(Math.random() * 10000);
  list.unshift({
    key: i,
    href: 'https://ant.design',
    avatar: [
      'https://gw.alipayobjects.com/zos/rmsportal/eeHMaZBwmTvLdIwMfBpg.png',
      'https://gw.alipayobjects.com/zos/rmsportal/udxAbMEhpwthVVcjLXik.png',
    ][i % 2],
    no: `TradeCode ${i}`,
    title: `一个任务名称 ${i}`,
    owner: '曲丽丽',
    description,
    callNo: Math.floor(Math.random() * 1000),
    status: Math.floor(Math.random() * 10) % 2,
    updatedAt: new Date(),
    createdAt: new Date(),
    progress: Math.ceil(Math.random() * 100),
  });
}

export const RULES = {
  '/rule': (req: MockRequest) => getRule(req.queryString),
  'DELETE /rule': (req: MockRequest) => removeRule(req.queryString.nos),
  'POST /rule': (req: MockRequest) => saveRule(req.body.description),
};
