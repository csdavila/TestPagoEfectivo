import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ApiPromoCodeService } from "../services/apipromocode.service";

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    public lst: any[] = [];
    public columnas: string[] = ['id', 'name', 'email', 'code', 'status'];
    readonly witdh: string = '300';
   
    constructor(
        private api: ApiPromoCodeService,
        public dialog: MatDialog,
        public snackBar: MatSnackBar,
    ) {

    }

    ngOnInit(): void {
        this.getAll();
    }

    getAll() {
        this.api.getAll().subscribe(response => {
            console.log(response);
            response.forEach(x=>{
                if(x.Status == 1){
                    x.Status = "Generado";
                }else if(x.Status == 2){
                    x.Status = "Canjeado";
                }
            })
            this.lst = response;
        })
    }

}