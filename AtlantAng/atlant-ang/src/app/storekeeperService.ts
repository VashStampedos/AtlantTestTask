import { HttpClient, HttpContext, HttpHandler } from "@angular/common/http";
import { Observable, catchError } from "rxjs";
import { ApiResult } from "./DTO/ApiResult";
import { Storekeeper } from "./entityModels/Storekeeper";
import { Injectable } from "@angular/core";

@Injectable()
export class StorekeeperService{
    constructor(private http:HttpClient){

    }

    getStorekeepers():Observable<ApiResult<Storekeeper[]>>{
        return this.http.get<ApiResult<Storekeeper[]>>('https://localhost:7289/Store/GetStoreKeepers').pipe(
            catchError(error => {
                console.log(error)
                error.message
                return [];
            })
        );
    }
    addStorekeeper(fio:string){
        return this.http.post('https://localhost:7289/Store/CreateStoreKeeper', {FIO:fio});
    }
    deleteStorekeeper(id:number){
        return this.http.delete(`https://localhost:7289/Store/DeleteStoreKeeper?id=${id}`);
    }
}