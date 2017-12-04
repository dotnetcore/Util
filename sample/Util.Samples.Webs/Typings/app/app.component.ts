import { Component } from "@angular/core"
import { AppService } from "./app.service"
import * as util from "../util";

@Component({
    selector: 'hello-world',
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