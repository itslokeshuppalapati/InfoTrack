import { Component, OnInit, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { SearchService } from 'src/app/core/services/search.service';

@Component({
  selector: 'app-search-dashboard',
  templateUrl: './search-dashboard.component.html',
  styleUrls: ['./search-dashboard.component.css']
})
export class SearchDashboardComponent implements OnInit, OnDestroy, OnChanges {

  searchForm!: FormGroup;
  searchEngines: any[] = [];
  loadedSearch: boolean = false;
  rankings: any[] = [];
  searched: boolean = false;
  private $destroyed = new Subject<void>();

  constructor(private searchService: SearchService) { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      searchText: new FormControl('', [Validators.required]),
      searchEngineId: new FormControl('')
    });

    this.getAllSearchEngines();
  }

  getAllSearchEngines() : any {
    return this.searchService.getSearchEngines().subscribe(result => {
      this.searchEngines = Object.values(result.searchEngines);
      const selectedSearchEngine = this.searchEngines.find(e => e.title === 'Google');
      this.searchEngineId.setValue(selectedSearchEngine.id, {onlySelf: true});
    });
  }

  getRankings() {
    this.searchService.getRankings(this.searchText.value, this.searchEngineId.value).subscribe(result => {
      this.rankings = result.searchRankings;
      this.searched = true;
    });
  }

  getCurrentSearchEngineTitle() {
    if (this.searchEngineId.value >= 0 && this.searchEngines.length > 0) {
      var searchEngines = this.searchEngines;
      return searchEngines.find(e => e.id.toString() === this.searchEngineId.value)?.title;
    }
  }

  searchTextChanged(event: any) : any {
      this.resetResults();
  }

  searchEngineChanged(event: any) : any {
    // this.resetResults();
}

  resetResults() {
    this.searched = false;
    this.rankings = [];
  }

  get searchText() : any {
    return this.searchForm.get('searchText');
  }

  get searchEngineId() : any {
    return this.searchForm.get('searchEngineId');
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.loadedSearch) {
      this.setSearchForm();
    } else {
      this.resetSearchForm();
    }
  }

  ngOnDestroy(): void {
    this.$destroyed.next();
  }

  private setSearchForm(): void {    
    this.searchForm.patchValue({
      searchText: '',
      searchEngineId: 2
    });
  }

  private resetSearchForm(): void {
    this.searchForm?.reset();
  }
}
