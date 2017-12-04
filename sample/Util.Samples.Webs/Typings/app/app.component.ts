import { Component } from "@angular/core"
import { AppService } from "./app.service"
import {Util} from "../util";
import { Http, Response } from '@angular/http'

@Component({
    selector: 'hello-world',
    templateUrl: '/home/a'
})
export class AppComponent {
    target;
    constructor(private util: Util) {
    }
}