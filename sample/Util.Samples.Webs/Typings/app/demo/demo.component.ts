import { Component, ViewChild, OnInit, Injector } from "@angular/core"
import { MatSnackBar} from "@angular/material"
import { NgForm } from "@angular/forms"
import { ComponentBase,ViewModel,QueryParameter, TableWrapperComponent, HttpContentType } from "../../util";

@Component({
    selector: 'demo',
    templateUrl: '/Home/Demo'
})
export class DemoComponent extends ComponentBase implements OnInit {
    queryParam: CustomerQueryModel;

    @ViewChild('grid') grid: TableWrapperComponent<CustomerViewModel>;

    model: CustomerViewModel;
    id:string;

    delete() {
        this.grid.delete();
    }

    constructor(injector: Injector, public snackBar: MatSnackBar) {
        super(injector);
        this.queryParam = new CustomerQueryModel();
        this.model = new CustomerViewModel();
    }

    query() {
        this.grid.query();
    }

    onChange(form: NgForm, event) {
        this.util.form.submit({
            form: form,
            url: '/api/customers',
            data:this.model
        });
    }

    ngOnInit() {
        
    }
}


class CustomerQueryModel extends QueryParameter {
    public name: string;
}

class CustomerViewModel extends ViewModel {
    name: string;
    value: string;
    nation;
    hide: boolean;
    num: number;
    date: Date;
    creationTime;
    isGender:boolean;
}