import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'; 
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';

@Injectable({   //services are injectable
  providedIn: 'root' 
})
export class AccountService {

  //make request to api
  baseUrl = 'https://localhost:5001/api/';  //services are singleton, the data we stored nothing get destroyed 
                                            //as aplication closed down 
  //Create Observable to user in
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable(); //currenUser$ is observable

  constructor(private http: HttpClient) { }

  //Create method
  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map(( response: User) => {
        const user = response;
        if(user) {
          localStorage.setItem('user' , JSON.stringify(user));
          this.currentUserSource.next(user); //set current user to replaysubject and get back from api
        }
        return user;
      })
    )
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((user: User) => {
        if(user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
