import { Component, Input } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '@app/_models';
import { UserService } from '@app/_services';
import { Router, ActivatedRoute } from '@angular/router';


@Component({ templateUrl: 'boleto.component.html' })
export class BoletoComponent {


    constructor(private userService: UserService) { }

    private router: Router;

    loading = false;
    boleto = null;

    @Input() Nome = '';
    @Input() Endereco = '';
    
    imoveis = [];

    reparo(){
        
    }
    
    ngOnInit() {

        this.loading = true;
        
        let username = localStorage.getItem('username');

        if(username == null){
            location.href="/";
            return false;
        }

        this.userService.getImoveisByUserId(username).pipe(first()).subscribe(imovel => {
            
            this.imoveis = imovel;
            
            this.loading = false;
        });
    }

    retrieve(userId: string){

        this.loading = true;
    

        this.userService.getBoletoByImovelId(userId).pipe(first()).subscribe(boleto => {
            debugger
            this.boleto = boleto;
            
            this.loading = false;
        });

    }
}