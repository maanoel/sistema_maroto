import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@app/_services';
import { UserService } from '@app/_services';

@Component({ templateUrl: 'reparo.component.html' })
export class ReparoComponent  {

    constructor(private userService: UserService) 
    { 
        
    }

    titulo;
    descricao;
    diaIncidente;
    diaConserto;
    possuiDebito;

    ngOnInit() 
    {
        let username = localStorage.getItem('username');

        if(username == null){
            location.href="/";
            return false;
        }

    }

    reparo(){

        const reparo = {
            titulo : this.titulo,
            descricao: this.descricao,
            diaIncidente: this.diaIncidente,
            diaConserto: this.diaConserto,
            possuiDebito : this.possuiDebito

        }

        this.userService.postReparo(reparo).subscribe(reparo => {

            this.titulo = null;
            this.descricao = null;
            this.diaIncidente = null;
            this.diaConserto = null;
            this.possuiDebito = null;

            alert("Solicitação enviada com sucesso");

        });

    }

}
