import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from './weatherforecast';
import { WeatherforecastService } from './weatherforecast.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  public weatherforecasts: WeatherForecast[] = [];

  constructor(private weatherForecastService: WeatherforecastService) {}

  ngOnInit(): void {
    this.getAllWeatherForecasts();
  }

  public getAllWeatherForecasts(): void {
    this.weatherForecastService
      .getAllWeatherForecasts()
      .subscribe((response: WeatherForecast[]) => {
        this.weatherforecasts = response;
      });
  }
}
