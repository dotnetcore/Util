import { Component, Injector,ViewChild,forwardRef } from '@angular/core';
import { ComponentBase,Tree } from '../../../util';
import { env } from '../../env';
import { RoleQuery } from './model/role-query';

@Component({
    selector: 'app-table-list',
    templateUrl: !env.dev() ? './html/tree.component.html' : '/View/Demo/Trees/Tree',
})
export class TreeComponent extends ComponentBase {
    /**
     * 查询参数
     */
    queryParam: RoleQuery;

    /**
     * 初始化
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new RoleQuery();
    }

    //add( data ) {
    //    let node = {
    //        key: 121,
    //        level:3,
    //        name: 'a21',
    //        expand:true,
    //        age: 16 ,
    //        address: 'New York No. 3 Lake Park'
    //    };
    //    let a: any[] = this.mapOfExpandedData[1];
    //    let b = this.util.helper.insert( a , node , a.findIndex( t => t.key === 12 )+1 );
    //    this.mapOfExpandedData[1] = [...b];
    //}
}