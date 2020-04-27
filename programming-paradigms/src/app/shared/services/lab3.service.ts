import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Automat } from '../models/lab3';


@Injectable()
export class Lab3Service{
    constructor(private http:HttpClient){}

    findResult(automat: Automat){
        const body = {
            Transitions: automat.Transitions,
            StartState: automat.StartState,
            FinalStates: automat.FinalStates            
        }
        debugger
        let headers=new HttpHeaders({
            "Content-Type": "text/json"
        });

        let options={headers:headers};
        return this.http.post(environment.lab3.findResult, body, options);
    }

    getResult(key:string):Observable<string>{
        let url = environment.lab3.getResult+"/"+key;
        return this.http.get<string>(url);
    }
}