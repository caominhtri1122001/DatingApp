import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AppUser } from './_models/app-user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  name = 'Cao Minh Tri';
  users: AppUser[] = [];
  constructor(
    private httpClient: HttpClient,
    private accountService: AccountService) 
  { }

  ngOnInit(): void {
    this.accountService.relogin();
    this.httpClient.get<AppUser[]>('https://localhost:7299/api/Auth')
      .subscribe(
        response => this.users = response,
        error => console.log(error)
      )
  }
}
