import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { SearchHistoryService } from 'src/app/core/services/search-history.service';

@Component({
  selector: 'app-search-history',
  templateUrl: './search-history.component.html',
  styleUrls: ['./search-history.component.css']
})
export class SearchHistoryComponent implements OnChanges  {
  public searchHistories: any = [];

  constructor(private searchHistoryService: SearchHistoryService) { }
  ngOnChanges(changes: SimpleChanges): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
    this.getSearchHistory();
  }

  getSearchHistory() : any {
    return this.searchHistoryService.getAllSearchHistories().subscribe(result => {
      this.searchHistories = Object.values(result.searchHistories);
    }, error => console.error(error));;
  }
}

