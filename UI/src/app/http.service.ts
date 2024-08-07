import { HttpClient } from  '@angular/common/http';
import { Injectable } from  '@angular/core';
import {Appointment} from "./models/appointment";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class HttpService {
  private url = 'https://localhost:44355/api';

  constructor(private http: HttpClient) { }

  getAppointments() : Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.url}/appointment`);
  }

  getAppointment(id: number) : Observable<Appointment> {
    return this.http.get<Appointment>(`${this.url}/appointment?id=${id}`);
  }

  createAppointment(appointment: Appointment) : Observable<any> {
    return this.http.post(`${this.url}/appointment`, appointment);
  }
}
