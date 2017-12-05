import { Component } from "@angular/core"
import { util } from "../util";

@Component({
    selector: 'app',
    templateUrl: '/home/a'
})
export class AppComponent {
    target;
    constructor() {
        util.http.get("/home/b").handle(response => {
            this.target = response.text();
        });
    }
}