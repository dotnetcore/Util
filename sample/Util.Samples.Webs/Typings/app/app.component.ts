import { Component, ViewChild } from "@angular/core"
import { util, Pager,TableWrapperComponent } from "../util";
@Component({
    selector: 'app',
    templateUrl: '/Home/a',
    styles: [`
.example-header {
  min-height: 64px;
  display: flex;
  align-items: center;
  padding-left: 24px;
  font-size: 20px;
}

.example-table {
  overflow: auto;
  min-height: 300px;
}


/* Column Widths */
.mat-column-number,
.mat-column-state {
  max-width: 64px;
}

.mat-column-created {
  max-width: 124px;
}
`]
})
export class AppComponent {

    queryParam: CustomerQueryModel;

    @ViewChild('grid') grid: TableWrapperComponent<any>

    constructor() {
        this.queryParam = new CustomerQueryModel();
    }

    query() {
        this.grid.query();
    }
}


class CustomerQueryModel extends Pager {
    public name: string;
}