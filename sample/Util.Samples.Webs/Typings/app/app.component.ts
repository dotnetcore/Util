import { Component } from "@angular/core"
import { AppService } from "./app.service";

@Component({
    selector: 'hello-world',
    templateUrl: "/home/a"
})
export class AppComponent {
    userName;
    password;

    public state;
    constructor( private service:AppService) {
    }

    public login(): void {
        let result = this.service.login(this.userName, this.password);
        if (result) {
            this.state = "登陆成功";
            return;
        }
        this.state = "登陆失败";
    }
}