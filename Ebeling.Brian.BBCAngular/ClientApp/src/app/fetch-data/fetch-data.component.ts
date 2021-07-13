import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public feed: IFeedItem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IFeedItem[]>(baseUrl + 'feed').subscribe(result => {
      this.feed = result;
    }, error => console.error(error));
  }
}

interface IFeedItem {
  title: string;
  description: number;
}
