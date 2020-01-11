import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { User } from '@app/_models';
const API = "http://localhost:5000/";


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
  
        const httpHeaders = new HttpHeaders ({
            'Content-Type': 'application/json',

          });

       
        var user = { login: username, accessKey:password };

        const json = JSON.stringify(user); 
       
        return this.http.post<any>(API+ 'api/Login/v1', json, {headers: httpHeaders})
            .pipe(map(user => {
            
                // store user details and basic auth credentials in local storage to keep user logged in between page refreshes
                localStorage.setItem('username', username);
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('username');
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}