import { Component, ViewChild,OnInit } from "@angular/core"
import { util, ViewModel,QueryParameter, TableWrapperComponent, HttpContentType } from "../../util";

@Component({
    selector: 'demo',
    templateUrl: '/Home/Demo'
})
export class DemoComponent implements OnInit {
    queryParam: CustomerQueryModel;

    @ViewChild('grid') grid: TableWrapperComponent<CustomerViewModel>;

    model: CustomerViewModel;

    delete() {
        this.grid.delete();
    }

    constructor() {
        this.queryParam = new CustomerQueryModel();
        this.model = new CustomerViewModel();
        
    }

    query() {
        this.grid.query();
    }

    onChange() {
        this.model.hide = !this.model.hide;
        util.message.info("现在是："+this.model.nation.toString());
    }

    ngOnInit() {
        this.model.nation = 30;
        this.model.num = 10;
        this.model.date = util.helper.toDate("1990-10-18");
    }

    getDate() {
        return util.helper.formatDate(this.model.creationTime, "YYYY年MM月DD日");
    }
}


class CustomerQueryModel extends QueryParameter {
    public name: string;
}

class CustomerViewModel extends ViewModel {
    public name: string;
    public value: string;
    public nation;
    public hide: boolean;
    public num: number;
    public date: Date;
    public creationTime;
}