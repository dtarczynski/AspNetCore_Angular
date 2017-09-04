import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];

  vehicle: any = {};
  
  constructor(private makeService: MakeService){ }

  ngOnInit(){
    this.makeService.getMakes().subscribe(makes => {
      this.makes = makes;
      console.log("MAKES", this.makes); // przyklad logowania dla asynchronicznego odwolania: czekamy na rezultat i dopiero robimy console.log
    });    
  }

  onMakeChange(){
    var selectedMake = this.makes.find(m=> m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];       
  }
}
