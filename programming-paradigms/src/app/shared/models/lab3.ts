export class Automat{
    StartState:number;
    FinalStates:number[];
    Transitions:Transition[]
    constructor(){
        this.FinalStates = [];
        this.Transitions = [];
    }
}

class Transition{
    CurrentState:number;
    Symbol:string;
    NextState:number;
}