import { Component } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { Storekeeper } from '../entityModels/Storekeeper';
import { StorekeeperService } from '../storekeeperService';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StrKeeperViewModel } from '../StrKeeperViewModel';
import { ApiResult } from '../DTO/ApiResult';

@Component({
  selector: 'app-storekeeper',
  standalone: true,
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule],
  providers:[StorekeeperService, HttpClient, FormBuilder],
  templateUrl: './storekeeper.component.html',
  styleUrl: './storekeeper.component.css'
})
export class StorekeeperComponent {
    
  storeKeepers?: Storekeeper[];
  storeKeepersViewModel?: StrKeeperViewModel[] = [];
  addStrKeeperForm!:FormGroup;
 

  constructor(private strKeeperService:StorekeeperService, private formBuilder: FormBuilder){
  
  }

  ngOnInit(){
      this.strKeeperService.getStorekeepers().subscribe(x=>{
        this.storeKeepers = x.data;
        this.storeKeepers?.forEach(elem =>{
          this.storeKeepersViewModel?.push(new StrKeeperViewModel(elem));
          
        })
      });
      this.addStrKeeperForm = this.formBuilder.group(
        {
          fio:['',[Validators.required,Validators.nullValidator, Validators.minLength(1)]],
        }
      )

  }

  AddStoreKeeper(){
    var fio = this.addStrKeeperForm.get('fio')?.value;
    console.log("fio is:" + fio);
    this.strKeeperService.addStorekeeper(fio).subscribe(error=>{
      console.log(error)
      window.location.reload();
    }
    
    )
  } 

  DeleteStoreKeeper(id:number){
    
    this.strKeeperService.deleteStorekeeper(id).subscribe(error=>{
      console.log(error)
      window.location.reload();
    }
    
    )
  } 
      
}
