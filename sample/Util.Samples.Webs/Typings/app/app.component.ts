import { Component, ViewChild } from "@angular/core"

@Component({
    selector: 'app',
    templateUrl: '/Home/admin'
})
export class AppComponent {
    isloading: Boolean = true;
    sidenavOpen: Boolean = true;
    sidenavMode: string = 'side';

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