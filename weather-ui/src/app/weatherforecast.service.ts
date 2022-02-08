import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherForecast } from './weatherforecast';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WeatherforecastService {
  private apiServerUrl = environment.apiServerUrl;

  constructor(private http: HttpClient) {}

  public getAllWeatherForecasts(): Observable<WeatherForecast[]> {
    return this.http.get<WeatherForecast[]>(
      `${this.apiServerUrl}/api/WeatherForecast`
    );
  }
}
