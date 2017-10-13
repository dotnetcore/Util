import { Component } from "@angular/core"

@Component({
    selector: 'hello-world',
    templateUrl: "/home/a"
})
export class AppComponent {
    name;
    public fun() {
        this.name = "4";
    }
}