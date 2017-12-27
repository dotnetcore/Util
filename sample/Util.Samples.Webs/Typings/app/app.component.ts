import { Component, ViewChild } from "@angular/core"
import { util, QueryParameter, TableWrapperComponent, HttpContentType } from "../util";
@Component({
    selector: 'app',
    templateUrl: '/Home/a'
})
export class AppComponent {
    queryParam: CustomerQueryModel;

    @ViewChild('grid') grid: TableWrapperComponent<any>;

    constructor() {
        this.queryParam = new CustomerQueryModel();
    }

    query() {
        this.grid.query();
    }

    checkAll(checkBox) {
        for (var i = 0; i < this.grid.dataSource.data.length; i++) {
            this.grid.dataSource.data[i]["checked"] = checkBox.checked;
        }
    }
}


class CustomerQueryModel extends QueryParameter {
    public name: string;
}