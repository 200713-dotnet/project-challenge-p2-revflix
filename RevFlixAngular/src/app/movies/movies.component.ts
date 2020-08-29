import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie';
import { MOVIES } from '../mock-movies';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  // movie: Movie = {
  //   imdb_id: "tt2935510",
  //   title: "Ad Astra",
  //   year: 2019
  // }
  movies = MOVIES;
  selectedMovie: Movie;
  // onSelect(movie: Movie): void {
  //   this.selectedMovie = movie;
  // }
  
  constructor() {
    this.movies.forEach(movie => {
      movie.titleyear = movie.title + ' (' + movie.year + ')';      
    });
   }

  ngOnInit(): void {
  }
  
  onSelect(movie: Movie): void {
    this.selectedMovie = movie;
  }
}
