import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { RedeemRequest } from "../models/redeem";
import { ApiPromoCodeService } from "../services/apipromocode.service";

@Component({
    selector: 'app-redeem',
    templateUrl: './redeem.component.html',
    styleUrls: ['./redeem.component.scss']
})
export class RedeemComponent implements OnInit {
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
        this.email = "";
        this.code = "";
        this.message = "";
    }

    redeem(){
        const request: RedeemRequest = { code: this.code }
        this.api.redeem(request).subscribe(response =>{
            if(response.success){
                this.message = "Felicidades. Se canjeó el código promocional.";
                this.code = this.code;
                this.snackBar.open(response.message, '',{duration: 2000});
            }else{
                this.snackBar.open(response.message, '',{duration: 2000});
            }
        })
        this.clean();
    }
}