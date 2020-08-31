import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie';
// import { MOVIES } from '../mock-movies';
import { MovieService } from '../movie.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  movies: Movie[];
  // selectedMovie: Movie;
  
  constructor(
    private route: ActivatedRoute,
    private movieService: MovieService,
    private location: Location
    ) {}

  ngOnInit(): void {
    this.getMovies();
  }
  
  getMovies(): void {
    const type = this.route.snapshot.paramMap.get('searchType');
    const title = this.route.snapshot.paramMap.get('searchTitle');
    this.movieService.getMovies(type, title).subscribe(movies => this.movies = movies);
  }
  
  goBack(): void {
    this.location.back();
  }
}
