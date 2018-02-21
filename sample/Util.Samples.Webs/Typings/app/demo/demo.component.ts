import { Component, ViewChild, OnInit, Injector } from "@angular/core"
import { MatSnackBar} from "@angular/material"
import { NgForm } from "@angular/forms"
import { ComponentBase, ViewModel, QueryParameter, TableWrapperComponent, HttpContentType } from "../../util";

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
        this.navLinks = [{ label: '哈哈', path: "a" }, { label: '嘿嘿', path: "b" }];
    }

    query() {
        this.grid.query();
    }

    onChange(form: NgForm, event) {
        this.util.message.error("a");
        this.util.form.submit({
            form: form,
            url: '/api/customers',
            data: this.model,
        });
    }

    ngOnInit() {
        this.model.isGender = true;
    }

    navLinks:any[];
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
    creationTime:Date;
    isGender:boolean;
}


@Component({
    selector: 'ao',
    template: 'This is the routed body of the sunny tab.1111111111',
})
export class A1 { }

@Component({
    selector: 'bo',
    template: 'This is the routed body of the sunny tab.2222222222',
})
export class B1 { }