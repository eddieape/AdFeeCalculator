import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class SharedService {

    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
        this.baseUrl = _baseUrl;
    }

    getAdParam(): Observable<any> {
        return this.http.get<any>(this.baseUrl + 'api/adprice');
    }

    getAdFee(val: any) {
        return this.http.post(this.baseUrl + 'api/adprice', val);
    }
}
