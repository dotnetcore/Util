import { Component, ViewChild } from "@angular/core"
import { util, QueryParameter, TableWrapperComponent, HttpContentType } from "../../util";

@Component({
    selector: 'demo',
    templateUrl: '/Home/a'
})
export class DemoComponent {
    queryParam: CustomerQueryModel;
    isloading: Boolean = true;
    sidenavOpen: Boolean = true;
    sidenavMode: string = 'side';

    @ViewChild('grid') grid: TableWrapperComponent<any>;




    constructor() {
        this.queryParam = new CustomerQueryModel();
    }

    showSuccess() {
        util.message.error("出错了","你好");
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