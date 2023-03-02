import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Company } from '../_models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { }

  getCompanies(): Observable<Company>{
    return this.http.get<Company>(environment.url+'companies').pipe(
      map(dto => ({
        name: dto.name,
        pictureUrl: dto.pictureUrl,
        members: dto.members,
      }))
      );
    }
  }

