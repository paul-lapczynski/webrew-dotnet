import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class BeersService {
    constructor(private http: HttpClient) { }
    fetchBeers(): Observable<Object> {
        return this.http.get('/api/Home/');
    }
}
