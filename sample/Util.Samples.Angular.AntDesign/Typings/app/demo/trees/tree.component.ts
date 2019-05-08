import { Component, Injector } from '@angular/core';
import { ComponentBase } from '../../../util';
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



    listOfMapData = [
        {
            key: 1,
            name: 'a',
            age: 60,
            address: 'New York No. 1 Lake Park',
            children: [
                {
                    key: 11,
                    name: 'a1',
                    age: 42,
                    address: 'New York No. 2 Lake Park'
                },
                {
                    key: 12,
                    name: 'a2',
                    age: 30,
                    address: 'New York No. 3 Lake Park',
                    children: [
                        
                    ]
                },
                {
                    key: 13,
                    name: 'a3',
                    age: 72,
                    address: 'London No. 1 Lake Park',
                    children: [
                        {
                            key: 131,
                            name: 'a31',
                            age: 42,
                            address: 'London No. 2 Lake Park',
                            children: [
                                {
                                    key: 1311,
                                    name: 'a311',
                                    age: 25,
                                    address: 'London No. 3 Lake Park'
                                },
                                {
                                    key: 1312,
                                    name: 'a312',
                                    age: 18,
                                    address: 'London No. 4 Lake Park'
                                }
                            ]
                        }
                    ]
                }
            ]
        },
        {
            key: 2,
            name: 'b',
            age: 32,
            address: 'Sidney No. 1 Lake Park'
        }
    ];
    list = [];
    mapOfExpandedData: { [key: string]: any[] } = {};

    collapse( array: TreeNodeInterface[], data: TreeNodeInterface, $event: boolean ): void {
        if ( data.key === 12 ) {
            this.add( data );
            return;
        }
        if ( $event === false ) {
            if ( data.children ) {
                data.children.forEach( d => {
                    const target = array.find( a => a.key === d.key )!;
                    target.expand = false;
                    this.collapse( array, target, false );
                } );
            } else {
                return;
            }
        }
    }

    convertTreeToList( root: object ): TreeNodeInterface[] {
        const stack: any[] = [];
        const array: any[] = [];
        const hashMap = {};
        stack.push( { ...root, level: 0, expand: false } );

        while ( stack.length !== 0 ) {
            const node = stack.pop();
            this.visitNode( node, hashMap, array );
            if ( node.children ) {
                for ( let i = node.children.length - 1; i >= 0; i-- ) {
                    stack.push( { ...node.children[i], level: node.level + 1, expand: false, parent: node } );
                }
            }
        }

        return array;
    }

    visitNode( node: TreeNodeInterface, hashMap: { [key: string]: any }, array: TreeNodeInterface[] ): void {
        if ( !hashMap[node.key] ) {
            hashMap[node.key] = true;
            array.push( node );
        }
    }

    ngOnInit(): void {
        //this.util.webapi.get( "/api/roleTable" ).handle( {
        //    ok: ( result: any ) => {
        //        debugger 
        //        this.list = result.data;
        //    }
        //} );

        //this.listOfMapData.forEach( item => {
        //    this.mapOfExpandedData[item.key] = this.convertTreeToList( item );
        //} );

    }

    add( data: TreeNodeInterface ) {
        
        let node: TreeNodeInterface = {
            key: 121,
            level:3,
            name: 'a21',
            expand:true,
            age: 16 ,
            address: 'New York No. 3 Lake Park'
        };
        let a: TreeNodeInterface[] = this.mapOfExpandedData[1];
        let b = this.util.helper.insert( a , node , a.findIndex( t => t.key === 12 )+1 );
        this.mapOfExpandedData[1] = [...b];
    }
}

export interface TreeNodeInterface {
    key: number;
    name: string;
    age: number;
    level: number;
    expand: boolean;
    address: string;
    children?: TreeNodeInterface[];
}
