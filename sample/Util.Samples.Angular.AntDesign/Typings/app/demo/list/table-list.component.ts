import { Component, OnInit } from '@angular/core';
import { env } from '../../env';

@Component({
    selector: 'app-table-list',
    templateUrl: !env.dev() ? './html/basic-form.component.html' : '/View/Demo/List/TableList',
})
export class TableListComponent implements OnInit {
    model;

    constructor() {
        this.model = {};
    }

    ngOnInit() {
    }
}
