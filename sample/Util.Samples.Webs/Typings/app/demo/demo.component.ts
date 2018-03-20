import { Component, ViewChild, OnInit, Injector } from "@angular/core"
import { NgForm } from "@angular/forms"
import { ComponentBase, ViewModel, QueryParameter, TableWrapperComponent, util } from "../../util";
import { DialogComponent } from "./dialog.component"
import { env } from "../env"

@Component({
    selector: 'demo',
    templateUrl: env.prod ? './demo.html' : '/Home/demo'
})
export class DemoComponent extends ComponentBase implements OnInit {
    queryParam: CustomerQueryModel;

    @ViewChild('grid') grid: TableWrapperComponent<CustomerViewModel>;

    model: CustomerViewModel;
    id:string;

    delete() {
        this.grid.delete();
    }

    constructor(injector: Injector) {
        super(injector);
        this.queryParam = new CustomerQueryModel();
        this.model = new CustomerViewModel();
    }

    query() {
        this.grid.query();
    }

    onChange() {
        util.dialog.open({
            dialogComponent: DialogComponent,
            minWidth: 800,
            beforeClose: result => util.message.success(result),
        });
        
    }

    onClose() {
        util.message.confirm({
            message: "您确定删除选中的记录吗?",
            ok: () => {
                util.message.success("成功");
            }
        });
    }

    onSubmit(form: NgForm) {
        this.util.form.submit({
            form: form,
            url: '/api/customers',
            data: this.model,
        });
    }

    ngOnInit() {
        this.model.isGender = true;
    }

    options = ['1'];
    options2 = [{ text: 'a', value: '1' }, { text: 'b', value: '2' }];
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
    isGender: boolean;
    lastModificationTime;
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
@Component({
    selector: 'co',
    template: 'This is the routed body of the sunny tab.333333333333',
})
export class C1 { }

@Component({
    selector: 'do',
    template: 'This is the routed body of the sunny tab.444444444444',
})
export class D1 { }