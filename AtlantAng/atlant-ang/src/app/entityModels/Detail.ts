import { Storekeeper } from "./Storekeeper";

export class Detail{
    id?:number;
    nomenclCode?:string;
    detailName?:string;
    detailCount?:number;
    storekeeperId?:number;
    dateOfCreation?:Date;
    dateOfRemoving?:Date;

    storekeeper?:Storekeeper;

}