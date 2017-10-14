import { Injectable } from '@angular/core'

@Injectable()
export class AppService {

    constructor(private service: AppService2) {
    }

    public login(userName: string, password: string): boolean {
        return this.service.login(userName, password);
    }
}

@Injectable()
export class AppService2 {
    public login(userName: string, password: string): boolean {
        if (userName === "a") {
            return true;
        }
        return false;
    }
}