// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var prefix="https://localhost:44309/api/";

export const environment = {
  production: false,
  lab1:{
    findResult1: prefix + "lab1/task1",
    getResult1: prefix + "lab1/get1",
    findResult2: prefix + "lab1/task2",
    getResult2: prefix + "lab1/get2"
  },
  lab2:{
    findResult:prefix + "lab2/task",
    getResult:prefix + "lab2/get"
  },
  lab3:{
    findResult: prefix + "lab3/task",
    getResult: prefix + "lab3/get"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
