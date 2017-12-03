import { Http } from '@angular/http'
import { Injectable } from '@angular/core'

@Injectable()
export class HttpHelper {

    constructor(private http: Http) { }

    public get(url: string) {
        return this.http.get(url);
    }
}