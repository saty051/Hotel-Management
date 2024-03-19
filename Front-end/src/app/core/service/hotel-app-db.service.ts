import { Injectable } from '@angular/core';
import  { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/Customer';
import { AddCustomer } from '../models/Add-Customer';
import { Employee } from '../models/Employee';
import { AddEmployee } from '../models/Add-Employee';
import { Reservation } from '../models/Reservation';
import { AddReservation } from '../models/Add-Reservation';
import { Hotel } from '../models/Hotel';
import { Room } from '../models/Room';
import { AddRoom } from '../models/Add-Room';
import { AddHotel } from '../models/Add-Hotel';

@Injectable({
  providedIn: 'root'
})
export class HotelAppDBService {

  constructor(private http : HttpClient) { }

  baseURL : string = "https://localhost:7055/api/";

  //for customers
  getAllCustomers() : Observable<Customer[]>
  {
    return this.http.get<Customer[]>(this.baseURL + "Customer/All");
  }
  
  deleteCustomerById(id:number) : Observable<void>
  {
    return this.http.delete<void>(this.baseURL + "Customer/"+id);
  }

  addCustomer(customer : AddCustomer) : Observable<void>
  {
    return this.http.post<void>(this.baseURL + "Customer/Create",customer);
  }

  getCustomerById(id:number) : Observable<Customer>
  {
    return this.http.get<Customer>(this.baseURL + "Customer/"+id);
  }

  updateCustomer(customer : Customer) : Observable<void>
  {
    return this.http.put<void>(this.baseURL + "Customer/Update",customer);
  }


  //for employees
  getAllEmployees() : Observable<Employee[]>
  {
    return this.http.get<Employee[]>(this.baseURL + "Employee/All");
  }
  
  deleteEmployeeById(id:number) : Observable<void>
  {
    return this.http.delete<void>(this.baseURL + "Employee/"+id);
  }

  addEmployee(employee : AddEmployee) : Observable<void>
  {
    return this.http.post<void>(this.baseURL + "Employee/Create",employee);
  }

  getEmployeeById(id:number) : Observable<Employee>
  {
    return this.http.get<Employee>(this.baseURL + "Employee/"+id);
  }

  updateEmployee(employee : Employee) : Observable<void>
  {
    return this.http.put<void>(this.baseURL + "Employee/Update",employee);
  }


  // for reservation
  getAllReservations() : Observable<Reservation[]>
  {
    return this.http.get<Reservation[]>(this.baseURL + "Reservation/All");
  }
  
  deleteReservationById(id:number) : Observable<void>
  {
    return this.http.delete<void>(this.baseURL + "Reservation/"+id);
  }

  addReservation(reservation: AddReservation) : Observable<void>
  {
    return this.http.post<void>(this.baseURL + "Reservation/Create",reservation);
  }

  getReservationById(id:number) : Observable<Reservation>
  {
    return this.http.get<Reservation>(this.baseURL + "Reservation/"+id);
  }

  updateReservation(reservation : Reservation) : Observable<void>
  {
    return this.http.put<void>(this.baseURL + "Reservation/Update",reservation);
  }

  // for hotel
  getAllHotels() : Observable<Hotel[]>
  {
    return this.http.get<Hotel[]>(this.baseURL + "Hotel/All");
  }
  
  deleteHotelById(id:number) : Observable<void>
  {
    return this.http.delete<void>(this.baseURL + "Hotel/"+id);
  }

  addHotel(hotel : AddHotel) : Observable<void>
  {
    return this.http.post<void>(this.baseURL + "Hotel/Create",hotel);
  }

  getHotelById(id:number) : Observable<Hotel>
  {
    return this.http.get<Hotel>(this.baseURL + "Hotel/"+id);
  }
  
  updateHotel(hotel : Hotel) : Observable<void>
  {
    return this.http.put<void>(this.baseURL + "Hotel/Update",hotel);
  }

  // for room
  getAllRooms() : Observable<Room[]>
  {
    return this.http.get<Room[]>(this.baseURL + "Room/All");
  }
  
  deleteRoomById(id:number) : Observable<void>
  {
    return this.http.delete<void>(this.baseURL + "Room/"+id);
  }

  addRoom(room : AddRoom) : Observable<void> 
  {
    return this.http.post<void>(this.baseURL + "Room/Create",room);
  }

  getRoomById(id:number) : Observable<Room>
  {
    return this.http.get<Room>(this.baseURL + "Room/"+id);
  }
  
  updateRoom(room : Room) : Observable<void>
  {
    return this.http.put<void>(this.baseURL + "Room/Update",room);
  }
  
}
