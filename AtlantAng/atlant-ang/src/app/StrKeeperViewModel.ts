import { Storekeeper } from "./entityModels/Storekeeper";


export class StrKeeperViewModel{

    strKeeperModel?:Storekeeper;
    countOfDetails:number = 0;

    constructor(storeKeeper: Storekeeper){
        this.strKeeperModel = storeKeeper;
        console.log("in viewModelconstructor:")
        if(storeKeeper.details != (null || undefined))
        storeKeeper.details.forEach(element => {
            if(element.dateOfRemoving== (null || undefined))
            this.countOfDetails += element.detailCount!;
           
        }); 
        console.log("countOfDetails:" + this.countOfDetails)
    }
}