import { Component } from "@angular/core"
import { AppService } from "./app.service"
import {Util} from "../util";
import { Http, Response } from '@angular/http'

@Component({
    selector: 'hello-world',
    template: `<h1>Hello,{{this.target}}</h1>`
})
export class AppComponent {
    target;
    constructor(private util: Util) {
        util.http.get("/home/a").subscribe((res: Response) => {
            console.log(res);
            this.target = res.text();
        });
        
    }
}