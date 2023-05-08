import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  // @Input() userFromHomeComponent:any;
  @Output() cancelRegister=new EventEmitter();
  model:any={}
  constructor(private accountService:AccountService) {}
  ngOnInit():void{

  }
  register(){
    this.accountService.register(this.model).subscribe({
      next:response=>{
        
        this.cancel();
      },
      error:error=>console.log(error)
    })
    
  }
  cancel(){
    this.cancelRegister.emit(false);
  }

}
