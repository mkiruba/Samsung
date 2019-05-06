import { Component, Inject } from '@angular/core';
import { FetchDataService } from './fetch-data.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public products: Product[];

  constructor(private fetchDataService: FetchDataService) {
    this.fetchDataService.getProducts().subscribe(result => {
      console.log(result);
      this.products = result;
    }, error => console.error(error));
  }
}
