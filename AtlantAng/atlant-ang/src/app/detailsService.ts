import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Detail } from "./entityModels/Detail";
import { ApiResult } from "./DTO/ApiResult";
import { Injectable } from "@angular/core";

@Injectable()
export class DetailService{
    constructor(private http:HttpClient ){

    }

    getDetails():Observable<ApiResult<Detail[]>>{
        return this.http.get<ApiResult<Detail[]>>('https://localhost:7289/Details/Details');
    }
    addDetail(nomenclCode:string, detailName:string, detailCount:number, storekeeperId:number, dateOfCreation:Date){
        return this.http.post('https://localhost:7289/Details/CreateDetail', {NomenclCode:nomenclCode, DetailName:detailName, 
                                                                            DetailCount:detailCount, StorekeeperId:storekeeperId, 
                                                                            DateOfCreation:dateOfCreation});
    }
    deleteDetail(id:number, dateOfRemoving: Date){
        return this.http.post('https://localhost:7289/Details/DeleteDetail?id', {Id:id, DateOfRemoving:dateOfRemoving});
    }
}