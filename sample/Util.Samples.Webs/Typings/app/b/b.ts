import { Component } from "@angular/core"
import { util } from "../../util";

@Component({
    selector: "b",
    template: `我是B：{{target|json}}`
})
export class BComponent {
    target;
    constructor() {
        let test = new Test();
        test.a = "aaa";
        test.b = "bbb";
        util.http.post<Test>("/home/b").header("a", "a1").header("b", "b1").body(test).handle(t => {
            this.target = `${t.a},${t.b},${t.c}`;
        });
    }
}

class Test {
    public a: string;
    public b: string;
    public c: string;
}
