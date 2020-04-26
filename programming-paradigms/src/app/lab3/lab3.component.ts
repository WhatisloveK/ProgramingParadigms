import { Component, OnInit } from '@angular/core';
import { Automat } from '../shared/models/lab3';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ArrayType } from '@angular/compiler';
import { parse } from 'querystring';
import { Lab3Service } from '../shared/services/lab3.service';

@Component({
  selector: 'app-lab3',
  templateUrl: './lab3.component.html',
  styleUrls: ['./lab3.component.css']
})
export class Lab3Component implements OnInit {
  title:string;
  result:string;

  myForm : FormGroup;
  constructor(private service:Lab3Service) { }

  ngOnInit() {
    this.title="Lab 3";
    this.result = "";

    this.myForm = new FormGroup({
      "StartState": new FormControl("", [Validators.required]),
      "FinalStates": new FormControl("", [Validators.required]),
      "Transitions": new FormArray([
          new FormControl("", Validators.required)
      ])
    });
  }

  addTransition(){
    (<FormArray>this.myForm.controls["Transitions"]).push(new FormControl("", Validators.required));
  }

  deleteTransition(){
    let length = (<FormArray>this.myForm.controls["Transitions"]).length;
    if(length>1){
      (<FormArray>this.myForm.controls["Transitions"]).removeAt(length-1);
    }
    else{
      alert("Must be at least one transition!");
    }
  }

  findResult(){
    let automat = this.getAutomat();
    let lengthString:string = this.myForm.value["Length"]; 
    let length = parseInt(lengthString);

    this.service.findResult(automat).subscribe((key:string)=>{
      this.service.getResult(key).subscribe((data:string)=>{
        this.result = data;
      },
      error=>console.error(error)
      )
    },
    error=>{
      console.error(error);
      this.result = error["error"];
    })
  }

  private getAutomat():Automat{
    let automat:Automat = new Automat();

    let startStateString:string = this.myForm.value["StartState"];
    automat.StartState = parseInt(startStateString);

    let finalStatesString:string= this.myForm.value["FinalStates"];
    let finalStatesArr =  finalStatesString.split(",");
    finalStatesArr.forEach(elem=>{
      automat.FinalStates.push(parseInt(elem));
    });

    let transitionStrings:string[] = this.myForm.value["Transitions"];

    transitionStrings.forEach(elem=>{
      let transition = elem.split(",");
      if(transition.length!=3){
        throw "Incorrect transition";
      }
      automat.Transitions.push({
        CurrentState:parseInt(transition[0]),
        Symbol:transition[1],
        NextState:parseInt(transition[2])
      });
    });

    return automat;
  }
}
