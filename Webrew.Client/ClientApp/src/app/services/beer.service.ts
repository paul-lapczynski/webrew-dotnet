import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Beer } from '../shared/models/beer';
import { Review } from '../shared/models/review';

@Injectable()
export class BeersService {
    constructor(private http: HttpClient) {}
    fetchBeers(): Observable<Beer[]> {
        return this.http.get<Beer[]>('/api/Home/');
    }
    fetchBeer(beerId): Observable<Beer[]> {
        return this.http.get<Beer[]>('/api/Beer?id=' + beerId);
    }
    fetchReviews(beerId): Observable<Review[]> {
        return this.http.get<Review[]>('/api/Review?beerId=' + beerId);
    }
}
