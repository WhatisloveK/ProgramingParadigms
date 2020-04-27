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

  automatForm : FormGroup;
  constructor(private service:Lab3Service) { }

  ngOnInit() {
    this.title="Lab 3";
    this.result = "";

    this.automatForm = new FormGroup({
      "StartState": new FormControl("", [Validators.required]),
      "FinalStates": new FormControl("", [Validators.required]),
      "Transitions": new FormArray([
          new FormControl("", Validators.required)
      ])
    });
  }

  addTransition(){
    (<FormArray>this.automatForm.controls["Transitions"]).push(new FormControl("", Validators.required));
  }

  deleteTransition(){
    let length = (<FormArray>this.automatForm.controls["Transitions"]).length;
    if(length>1){
      (<FormArray>this.automatForm.controls["Transitions"]).removeAt(length-1);
    }
    else{
      alert("Must be at least one transition!");
    }
  }

  findResult(){
    let automat = this.getAutomat();
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

    let startState:string = this.automatForm.value["StartState"];
    automat.StartState = parseInt(startState);

    let finalStates:string= this.automatForm.value["FinalStates"];
    let finalStatesArr =  finalStates.split(",");
    finalStatesArr.forEach(elem=>{
      automat.FinalStates.push(parseInt(elem));
    });

    let transitionStrings:string[] = this.automatForm.value["Transitions"];

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
