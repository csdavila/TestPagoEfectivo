import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { GenerateRequest } from "../models/generate";
import { ApiPromoCodeService } from "../services/apipromocode.service";

@Component({
    selector: 'app-generate',
    templateUrl: './generate.component.html',
    styleUrls: ['./generate.component.scss']
})
export class GenerateComponent implements OnInit {
    public name: string = "";
    public email: string = "";
    public code: string = "";
    public message: string = "";

    constructor(
        private api: ApiPromoCodeService,
        public dialog: MatDialog,
        public snackBar: MatSnackBar,
    ) {

    }
    ngOnInit(): void {
    }

    clean() {
        this.name = "";
        this.email = "";
        this.code = "";
        this.message = "";
    }

    register(){
        const request: GenerateRequest = { fullname: this.name, email: this.email }
        this.api.generate(request).subscribe(response =>{
            if(response){
                this.message = "El código generado es:";
                this.code = response.code;
                this.snackBar.open(response.message, '',{duration: 2000});
            }
        })
        this.clean();
    }
}