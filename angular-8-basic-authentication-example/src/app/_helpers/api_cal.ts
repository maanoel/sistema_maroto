import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from '@app/_models/user';
import { Observable } from 'rxjs';

const API = "http://localhost:5000/";


export class ApiServices{

    constructor(private http: HttpClient){
        this.http = http;
    }

    public Login(user: User): Observable<User[]>{ 
       return this.http.get<User[]>(API + "api/Login/v1");
    }

}