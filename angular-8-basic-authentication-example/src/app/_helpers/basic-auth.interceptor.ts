import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';


import { AuthenticationService } from '@app/_services';

@Injectable()
export class BasicAuthInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with basic auth credentials if available
        const currentUser = this.authenticationService.currentUserValue;
        
        if (currentUser ) {
            if( currentUser.autenticated){

                request = request.clone({
                    setHeaders: { 
                        Authorization: `Bearer ${currentUser.accessToken}`
                    }
                });
            }else{
                return throwError({ status: 401, error: { message: 'Unauthorised' } });
            }

            return next.handle(request);
           
        }
        
        return next.handle(request);
        
    }
}