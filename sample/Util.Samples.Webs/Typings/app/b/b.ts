import { Component } from "@angular/core"
import { util } from "../../util";

@Component({
    selector: "b",
    template: `我是B：{{target}}`
})
export class BComponent {
    target;
    constructor() {
        util.http.get("/home/b").handle(response => {
            this.target = response.text();
        });
    }
}