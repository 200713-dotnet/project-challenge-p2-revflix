import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../movie';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { MovieService } from '../movie.service';
import { Details } from '../details';
import { Locations } from '../locations';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  
  @Input() movie: Movie;
  details: Details;
  locations: Locations[];

  // imdbId: string = "";
  
  constructor(
    private route: ActivatedRoute,
    private movieService: MovieService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getDetails();
    // this.getLocations();
  }
  
  getMovie(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.movieService.getMovie(id)
      .subscribe(movie => this.movie = movie);
  }

  getDetails(): void {
    const imdb_id = this.route.snapshot.paramMap.get('id');
    this.movieService.getDetails(imdb_id)
      .subscribe(details => this.details = details);
    this.movieService.getLocations(imdb_id)
      .subscribe(locations => this.locations = locations);
  }
  
  // getLocations(): void {
  //   // const imdb_id = this.route.snapshot.paramMap.get('id');
  //   this.movieService.getLocations(this.imdbId)
  //     .subscribe(locations => this.locations = locations);
  // }

  goBack(): void {
    this.location.back();
  }

}
