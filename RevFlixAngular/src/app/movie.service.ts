import { Injectable } from '@angular/core';
import { Movie } from './movie';
import { Details } from './details';
import { Locations } from './locations';
import { MOVIES } from './mock-movies';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private moviesUrl;        // URL to the desired web api
  private hostWebApi = 'http://localhost:5002/movie/';

  constructor(private http: HttpClient) { }

  getMovies(type: string, title: string): Observable<Movie[]> {
    switch (type) {
      case '1':
        this.moviesUrl = this.hostWebApi + 'imdbi/' + title;
        break;
      default:
        this.moviesUrl = this.hostWebApi + 'imdbs/' + type + '/dummy';
        break;
    }
    return this.http.get<Movie[]>(this.moviesUrl)
      .pipe(
          catchError(this.handleError<Movie[]>('getMovies', []))
      );
  }

  getMovie(id: string): Observable<Movie> {
    return of(MOVIES.find(movie => movie.imdb_id === id));
  }

  getDetails(imdbId: string): Observable<Details> {
    this.moviesUrl = this.hostWebApi + 'imdbs/1/' + imdbId;
    return this.http.get<Details>(this.moviesUrl)
    .pipe(
        catchError(this.handleError<Details>('getDetails', ))
    );
  }

  getLocations(imdbId: string): Observable<Locations[]> {
    this.moviesUrl = this.hostWebApi + 'u/imdb/' + imdbId;
    return this.http.get<Locations[]>(this.moviesUrl)
    .pipe(
        catchError(this.handleError<Locations[]>('getLocations', ))
    );
  }

  // Handle Http operation that failed.
  // Let the app continue.
  // @param operation - name of the operation that failed
  // @param result - optional value to return as the observable result

  private handleError<T>(operation = 'operation', result?: T): any {
    return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // Let the app keep running by returning an empty result.
    return of(result as T);
    };
  }
}
