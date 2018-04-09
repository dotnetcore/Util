import { Component, Injector } from '@angular/core';
import { CrudIndexComponentBase } from '../../../util';
import { ApplicationQuery } from './application-query';
import { ApplicationViewModel } from './application-view-model';
import { env } from '../../env';
import {TreeNode} from "primeng/primeng"

/**
 * 应用程序首页
 */
@Component({
    selector: 'application-index',
    templateUrl: env.prod() ? './application-index.component.html' : '/view/systems/application'
})
export class ApplicationIndexComponent extends CrudIndexComponentBase<ApplicationViewModel, ApplicationQuery>  {
    /**
     * 初始化应用程序首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
        this.files = <TreeNode[]>this.value.data;
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new ApplicationQuery();
    }

    files: TreeNode[];
    selectedFiles: TreeNode[];

    value2 = {
        "data":
            [
                {
                    "data": {
                        "name": "Documents",
                        "size": "75kb",
                        "type": "Folder"
                    },
                    "children": [
                        {
                            "data": {
                                "name": "Work",
                                "size": "55kb",
                                "type": "Folder"
                            },
                            "children": [
                                {
                                    "data": {
                                        "name": "Expenses.doc",
                                        "size": "30kb",
                                        "type": "Document"
                                    }
                                },
                                {
                                    "data": {
                                        "name": "Resume.doc",
                                        "size": "25kb",
                                        "type": "Resume"
                                    }
                                }
                            ]
                        }
                    ]
                }
            ]
    };

    value = {
        "data":
            [
                {
                    "data": {
                        "name": "Documents",
                        "size": "75kb",
                        "type": "Folder"
                    },
                    "children": [
                        {
                            "data": {
                                "name": "Work",
                                "size": "55kb",
                                "type": "Folder"
                            },
                            "children": [
                                {
                                    "data": {
                                        "name": "Expenses.doc",
                                        "size": "30kb",
                                        "type": "Document"
                                    }
                                },
                                {
                                    "data": {
                                        "name": "Resume.doc",
                                        "size": "25kb",
                                        "type": "Resume"
                                    }
                                }
                            ]
                        },
                        {
                            "data": {
                                "name": "Home",
                                "size": "20kb",
                                "type": "Folder"
                            },
                            "children": [
                                {
                                    "data": {
                                        "name": "Invoices",
                                        "size": "20kb",
                                        "type": "Text"
                                    }
                                }
                            ]
                        }
                    ]
                },
                {
                    "data": {
                        "name": "Pictures",
                        "size": "150kb",
                        "type": "Folder"
                    },
                    "children": [
                        {
                            "data": {
                                "name": "barcelona.jpg",
                                "size": "90kb",
                                "type": "Picture"
                            }
                        },
                        {
                            "data": {
                                "name": "primeui.png",
                                "size": "30kb",
                                "type": "Picture"
                            }
                        },
                        {
                            "data": {
                                "name": "optimus.jpg",
                                "size": "30kb",
                                "type": "Picture"
                            }
                        }
                    ]
                }
            ]
    };
}