import { Component } from "@angular/core"
import { util } from "../../util";

@Component({
    selector:"a",
    template: `我是A：{{target}}`
})
export class AComponent {
    target;
    constructor() {
        util.http.get("/home/b").handle(response => {
            this.target = response.text();
        });
    }
}