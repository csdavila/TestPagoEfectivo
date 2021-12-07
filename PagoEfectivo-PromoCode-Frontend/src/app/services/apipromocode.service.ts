import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { GenerateRequest, GenerateResponse } from '../models/generate';
import { PromoCode } from '../models/promo-code';
import { RedeemRequest, RedeemResponse } from '../models/redeem';

const httpOptions = {
    headers: new HttpHeaders({
        'Contend-Type': 'application/json'
    })
};
const base_url = environment.Urlapi;

@Injectable({
    providedIn: 'root'
})
export class ApiPromoCodeService {

    constructor(
        private _http: HttpClient
    ) { }

    getAll(): Observable<PromoCode[]> {
        return this._http.get<PromoCode[]>(`${base_url}/promo-code/all`);
    }

    generate(request: GenerateRequest): Observable<GenerateResponse> {
        return this._http.post<GenerateResponse>(`${base_url}/promo-code/generate`,request, httpOptions);
    }

    redeem(request: RedeemRequest): Observable<RedeemResponse> {
        return this._http.post<RedeemResponse>(`${base_url}/promo-code/redeem`,request, httpOptions);
    }
}
