import { Component } from '@angular/core';
import { Appointment } from '../models/appointment';
import { OnInit } from '@angular/core';
import { HttpService } from "../http.service";

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})

export class AppointmentListComponent implements OnInit {
  newAppointmentName : string = "";
  newAppointmentDate : Date = new Date();

  appointments: Appointment[] = [];

  constructor(private httpService: HttpService) {
  }

  ngOnInit() {
    this.refreshAppointments();
  }

  addAppointment(){
    if(this.newAppointmentName.trim().length && this.newAppointmentDate){
      let newAppointment: Appointment = {
        name: this.newAppointmentName,
        date: this.newAppointmentDate
      };

      this.httpService.createAppointment(newAppointment).subscribe(() => {
        this.newAppointmentName = "";
        this.newAppointmentDate = new Date();
        this.refreshAppointments();
      });
    }
  }

  deleteAppointment(index: number){
    this.appointments.splice(index, 1)
  }

  refreshAppointments() {
    this.httpService.getAppointments().subscribe(appointments => {
      this.appointments = appointments;
    });
  }
}
