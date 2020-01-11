import { Component, Input } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '@app/_models';
import { UserService } from '@app/_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {

    Nome : string = 'teste';
    @Input() Sobrenome = '';
    @Input() DtNasc = '';
    @Input() Endereco = '';
    @Input() Complemento = '';
    @Input() Telefone = '';
    @Input() Celular = '';

    loading = false;
    user: User;

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.loading = true;
        
     
        var currentUser = JSON.parse( localStorage.getItem('currentUser'));
        var username = localStorage.getItem('username');

        this.userService.getPersonById(username).pipe(first()).subscribe(user => {
          
            this.loading = false;
            this.user = user;
            this.Nome = user.nome;
            this.DtNasc = user.dtNasc;
            this.Sobrenome = user.sobrenome;
            this.Endereco = user.endereco;
            this.Telefone = user.telefone;
            this.Celular = user.celular;
        });
    }
}