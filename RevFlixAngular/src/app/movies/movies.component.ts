import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie';
import { MovieService } from '../movie.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { QUICKSEARCH } from '../list-quicksearch';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  movies: Movie[];
  srchType: string;
  
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

    switch(type) {
      case '1':
        this.srchType = `Search by Title = "${title}"`;
        break;
      case '2':
      case '3':
      case '4': 
        this.srchType = QUICKSEARCH[+type-2].name;
        break;
      default:
        break;
    }
   
    this.movieService.getMovies(type, title).subscribe(movies => this.movies = movies);
  }
  
  goBack(): void {
    this.location.back();
  }
}
