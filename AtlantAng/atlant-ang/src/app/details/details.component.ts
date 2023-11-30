import { Component } from '@angular/core';
import { CommonModule, DatePipe, NgFor, NgIf } from '@angular/common';
import { DetailService } from '../detailsService';
import { Detail } from '../entityModels/Detail';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Storekeeper } from '../entityModels/Storekeeper';
import { StorekeeperService } from '../storekeeperService';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule, NgIf],
  providers:[DetailService, StorekeeperService, HttpClient, FormBuilder, Location, DatePipe],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  details?:Detail[];
  storekeepers?:Storekeeper[];
  addDetailForm:FormGroup = new FormGroup({
      "nomenclCode":  new FormControl('', Validators.required),
      "detailName": new FormControl('', Validators.required),
      "detailCount": new FormControl('', Validators.required),
      "storekeeperid": new FormControl('', Validators.required),
      "dateOfCreation": new FormControl('', Validators.required),

  }
  );
    constructor(private detailService:DetailService, private strKeeperService: StorekeeperService , private formBuilder:FormBuilder){

    }

    ngOnInit(){
      this.detailService.getDetails().subscribe(x =>{this.details = x.data; console.log(x.data?.length)});
      this.strKeeperService.getStorekeepers().subscribe(x => {this.storekeepers = x.data});
      // this.addDetailForm = this.formBuilder.group({
      //   nomenclCode:['', Validators.required],
      //   detailName:['', Validators.required],
      //   detailCount:['', Validators.required],
      //   storekeeperid:['', Validators.required],
      //   dateOfCreation:['', Validators.required],

      // });
    }

    AddDetail(){
      var nomenclCode = this.addDetailForm.get('nomenclCode')?.value;
      var detailName = this.addDetailForm.get('detailName')?.value;
      var detailCount = this.addDetailForm.get('detailCount')?.value;
      var storekeeperid = this.addDetailForm.get('storekeeperid')?.value;
      var dateOfCreation = this.addDetailForm.get('dateOfCreation')?.value;
  
      this.detailService.addDetail(nomenclCode, detailName, detailCount, storekeeperid, dateOfCreation).subscribe(error=>{
        console.log(error)
        window.location.reload();
      }
      
      )
    } 
  
    DeleteDetail(id:number){
      let dateOfRemoving:Date = new Date();
      this.detailService.deleteDetail(id, dateOfRemoving).subscribe(error=>{
        console.log(error)
        window.location.reload();
      }
      
      )
    } 
}
