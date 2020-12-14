import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-WeatherForecast',
  templateUrl: './WeatherForecast.component.html',
  styleUrls: ['./WeatherForecast.component.scss'],
})
export class WeatherForecastComponent implements OnInit {
  values: any;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.GetWeather();
  }

  GetWeather() {
    this.http.get('http://localhost:5000/WeatherForecast').subscribe(
      (myresponse) => {
        this.values = myresponse;
      },
      (myerror) => console.log(myerror)
    );
  }
}
