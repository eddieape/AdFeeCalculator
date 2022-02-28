import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-adcalculator',
  templateUrl: './adcalculator.component.html',
  styleUrls: ['./adcalculator.component.css']
})
export class AdcalculatorComponent implements OnInit {

    public AdParams: any;
    public AdFeeResult: any;

    AdTimeLen: number;
    InvalidateAdTime: boolean;
    MediaType: string;
    InvalidateMediaType: boolean;
    TotalFee: string;
    Stations: string[] = [];
    InvalidateStations: boolean;


    constructor(private service: SharedService) {
        this.service.getAdParam().subscribe(data => {
            this.AdParams = data;
        })
    }

    ngOnInit(): void {
        this.TotalFee = "0.0";
        this.InvalidateAdTime = false;
        this.InvalidateMediaType = false;
        this.InvalidateStations = false;
    }

    validateTimeFn() {
        var AdTimeLen = this.AdTimeLen;
        if (AdTimeLen < 5 || AdTimeLen > 300) {
            this.InvalidateAdTime = true;
        } else {
            this.InvalidateAdTime = false;
        }

        this.TotalFee = "0.0";
    }

    changeMediaType(event) {
        if (event.target.value == "Video") {
            this.Stations = [];
        }

        this.TotalFee = "0.0";
    }

    updateStations(event) {
        if (event.target.checked) {
            this.Stations.push(event.target.value);
            console.log(event.target.value);
        } else {
            this.Stations = this.Stations.filter(item => item != event.target.value);
            console.log(event.target.value);
        }

        this.TotalFee = "0.0";
    }

    getAdFee() {
        if (this.AdTimeLen < 5 || this.AdTimeLen > 300) {
            this.InvalidateAdTime = true;
            return;
        } else {
            this.InvalidateAdTime = false;
        }

        if (this.MediaType == "--Select--") {
            this.InvalidateMediaType = true;
            return;
        } else {
            this.InvalidateMediaType = false;
        }

        if (this.MediaType == "Radio" && this.Stations.length == 0) {
            this.InvalidateStations = true;
            return;
        } else {
            this.InvalidateStations = false;
        }

        var val = {
            AdTimeLen: this.AdTimeLen,
            MediaType: this.MediaType,
            Stations: this.Stations
        };

        this.service.getAdFee(val).subscribe(data => {
            this.AdFeeResult = data;
            this.TotalFee = (this.AdFeeResult.totalFee / 100).toFixed(2);

        });
    }

}
