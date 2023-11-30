import { HttpStatusCode } from "@angular/common/http";

export class ApiResult<T>{
    succeeded?:boolean;
    messages?:string[];
    code?: HttpStatusCode;
    data?:T;
}