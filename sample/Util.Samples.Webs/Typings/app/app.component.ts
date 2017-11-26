import { Component } from "@angular/core"
import { AppService } from "./app.service"

@Component({
    selector: 'hello-world',
    template: `<h1>Hello,{{this.target | a}}</h1>`
})
export class AppComponent {
    target: string;
    constructor(private service: AppService) {
        this.target = "ABC";
    }
}