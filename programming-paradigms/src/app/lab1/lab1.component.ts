import { Component, OnInit } from '@angular/core';
import { lab1 } from '../shared/models/lab1';
import { Lab1Service } from '../shared/services/lab1.service';
import { error } from 'util';

@Component({
  selector: 'app-lab1',
  templateUrl: './lab1.component.html',
  styleUrls: ['./lab1.component.css']
})
export class Lab1Component implements OnInit {
  data:lab1 = new lab1();
  data2:string;

  result1:string;
  result2:string;

  constructor(private service:Lab1Service) { }

  ngOnInit() {
    this.result1="";
    this.result2="";
  }

  findResult1(){
    this.service.findResult1(this.data).subscribe((key:string)=>{
      this.service.getResult1(key).subscribe((data:string)=>{
        this.result1 = data;
      },
      error=>console.log(error))
    },
    error=>{
      console.log(error);
      this.result1 = error["error"];
    })
  };

  findResult2(){
    this.service.findResult2(this.data2).subscribe((key:string)=>{
      this.service.getResult2(key).subscribe((data:string)=>{
        this.result2 = data;
        console.log(data);
      },
      error=>console.log(error))
    },
    error=>{
      console.log(error);
      this.result2 = error["error"];
    })
  };
}
