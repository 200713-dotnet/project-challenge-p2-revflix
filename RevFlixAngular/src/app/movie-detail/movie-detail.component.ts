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

  constructor(
    private route: ActivatedRoute,
    private movieService: MovieService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getDetails();
  }

  getMovie(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.movieService.getMovie(id)
      .subscribe(movie => this.movie = movie);
  }

  getDetails(): void {
    const imdbId = this.route.snapshot.paramMap.get('id');
    this.movieService.getDetails(imdbId)
      .subscribe(details => this.details = details);
    this.movieService.getLocations(imdbId)
      .subscribe(locations => this.locations = locations);
  }

  goBack(): void {
    this.location.back();
  }

}
