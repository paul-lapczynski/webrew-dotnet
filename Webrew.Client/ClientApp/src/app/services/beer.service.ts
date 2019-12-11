import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Beer } from '../shared/models/beer';
import { Review } from '../shared/models/review';

@Injectable()
export class BeersService {
    constructor(private http: HttpClient, @Inject('API_BASE_URL') private baseUrl: string) {}
    fetchBeers(): Observable<Beer[]> {
        return this.http.get<Beer[]>(this.baseUrl + 'Home');
    }
    fetchBeer(beerId: string): Observable<Beer> {
        return this.http.get<Beer>(this.baseUrl + 'Beer/' + beerId);
    }
    fetchReviews(beerId: string): Observable<Review[]> {
        return this.http.get<Review[]>(this.baseUrl + 'Review/' + beerId);
    }
    addReview(review: Review) {
        return this.http.post<any>(this.baseUrl + 'Review/add', review);
    }
    addBeer(beer: Beer) {
        return this.http.post<any>(this.baseUrl + 'Home/', beer);
    }
}
