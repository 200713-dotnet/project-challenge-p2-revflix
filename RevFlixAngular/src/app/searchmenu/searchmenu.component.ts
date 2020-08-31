import { Component, OnInit } from '@angular/core';
import { QUICKSEARCH } from '../list-quicksearch';

@Component({
  selector: 'app-searchmenu',
  templateUrl: './searchmenu.component.html',
  styleUrls: ['./searchmenu.component.css']
})
export class SearchmenuComponent implements OnInit {

  searchedtitle: string;
  searches = QUICKSEARCH;

  constructor() { }

  ngOnInit(): void {
  }

}
