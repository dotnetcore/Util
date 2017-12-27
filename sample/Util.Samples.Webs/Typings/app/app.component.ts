import { Component, ViewChild } from "@angular/core"
import { util, QueryParameter, TableWrapperComponent, HttpContentType } from "../util";
import { Message } from 'primeng/components/common/api';
import { MessageService } from 'primeng/components/common/messageservice';
@Component({
    selector: 'app',
    templateUrl: '/Home/a'
})
export class AppComponent {
    queryParam: CustomerQueryModel;

    @ViewChild('grid') grid: TableWrapperComponent<any>;

    msgs: Message[] = [];


    constructor(private messageService: MessageService) {
        this.queryParam = new CustomerQueryModel();
    }

    showSuccess() {
        this.msgs = [];
        this.msgs.push({ severity: 'success', summary: 'Success Message', detail: 'Order submitted' });
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