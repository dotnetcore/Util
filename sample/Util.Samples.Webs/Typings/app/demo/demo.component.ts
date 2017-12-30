import { Component, ViewChild } from "@angular/core"
import { util, ViewModel,QueryParameter, TableWrapperComponent, HttpContentType } from "../../util";

@Component({
    selector: 'demo',
    templateUrl: '/Home/a'
})
export class DemoComponent {
    queryParam: CustomerQueryModel;
    isloading: Boolean = true;
    sidenavOpen: Boolean = true;
    sidenavMode: string = 'side';

    @ViewChild('grid') grid: TableWrapperComponent<CustomerViewModel>;


    delete() {
        this.grid.delete();
    }

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


    showloading(val) {
        val = val * 1000;
        this.isloading = false;
        var self = this;
        setTimeout(function () {
            self.isloading = true;
        }, val);
    }

    sidenavOpens(agreed: boolean) {

        this.sidenavMode = (agreed) ? 'over' : 'side';
        this.sidenavOpen = !agreed;
    }
}


class CustomerQueryModel extends QueryParameter {
    public name: string;
}

class CustomerViewModel extends ViewModel {
    public name: string;
}