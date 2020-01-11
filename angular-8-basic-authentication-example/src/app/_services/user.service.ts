import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { 

    }

    getPersonById(id : string ) {
        return this.http.get<any>(`${environment.apiUrl}/api/pessoa/v1/` + id);
    }

    getImoveisByUserId(id : string ) {
        return this.http.get<any>(`${environment.apiUrl}/api/imovel/v1/` + id);
    }

    getBoletoByImovelId(id : string ) {
        return this.http.get<any>(`${environment.apiUrl}/api/boleto/v1/` + id);
    }
    postReparo(solicitacaoReparo : any) {
        return this.http.post<any>(`${environment.apiUrl}/api/reparo/v1/`, solicitacaoReparo);
    }

    getReparo() {
        return this.http.get<any>(`${environment.apiUrl}/api/reparo/v1/`);
    }

    getBase64Image(file: File) {
        let headers = new HttpHeaders({ "content-type": "image/png", "Accept": "image/png" });
        return this.http.post<any>(`${environment.apiUrl}/api/reparo/v1/PostBase64`, file, {headers: headers});
    }
}