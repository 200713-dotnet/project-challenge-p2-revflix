import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../movie';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { MovieService } from '../movie.service';
import { Details } from '../details';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  
  @Input() movie: Movie;
  details: Details;
  
  // yturl = "https://www.youtube.com/watch?v=" + this.details.youtube_Trailer_Key;

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
    const imdb_id = this.route.snapshot.paramMap.get('id');
    this.movieService.getDetails(imdb_id)
      .subscribe(details => this.details = details);
  }
  
  goBack(): void {
    this.location.back();
  }
}
