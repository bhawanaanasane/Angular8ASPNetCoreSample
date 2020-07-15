import { catchError, tap, map } from 'rxjs/operators';
import { HttpErrorResponse, HttpHeaders, HttpClient,HttpResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { UserLogin } from '../ViewModel/UserLogin';
import { Injectable } from '@angular/core';
@Injectable({ providedIn: 'root' })
export class LoginService {

  public token: string;
  constructor(private http: HttpClient) {
  }
  private apiUrl ="http://132.148.19.41:8055/api/Login/authenticateWeb";

  
  login(loginmodel: UserLogin) {

    localStorage.removeItem('currentUser');
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.http.post<any>(this.apiUrl, { username: loginmodel.userName, password: loginmodel.password })
      .pipe(map(user => {
        localStorage.setItem('currentUser', JSON.stringify(user));
       
        return user;
      }));

  }
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError('Something bad happened; please try again later.');
  };
}
