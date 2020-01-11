import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@app/_services';
import { UserService } from '@app/_services';

@Component({ templateUrl: 'reparo_solicitado.component.html' })
export class ReparoSolicitadoComponent  {

    constructor(private userService: UserService) 
    { 
        
    }

    items = [];

    ngOnInit() 
    {
        let username = localStorage.getItem('username');

        if(username == null){
            location.href="/";
            return false;
        }

        this.userService.getReparo().subscribe(reparoList => {

            this.items = reparoList;

         });
 

    }

  

}
