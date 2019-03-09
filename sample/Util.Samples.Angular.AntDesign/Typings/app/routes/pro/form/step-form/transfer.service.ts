import { Injectable } from '@angular/core';

@Injectable()
export class TransferService {
  step: 0 | 1 | 2 = 1;

  /**
   * 付款账户
   */
  pay_account: string;

  /**
   * 收款账户类型
   */
  receiver_type: 'alipay' | 'bank';

  get receiver_type_str() {
    return this.receiver_type === 'alipay' ? '支付宝' : '银行';
  }

  /**
   * 收款账户
   */
  receiver_account: string;

  /**
   * 收款姓名
   */
  receiver_name: string;

  /**
   * 金额
   */
  amount: number;

  /**
   * 支付密码
   */
  password = '123456';

  again() {
    this.step = 0;
    this.pay_account = 'ant-design@alipay.com';
    this.receiver_type = 'alipay';
    this.receiver_account = 'test@example.com';
    this.receiver_name = 'asdf';
    this.amount = 500;
  }

  constructor() {
    this.again();
  }
}
