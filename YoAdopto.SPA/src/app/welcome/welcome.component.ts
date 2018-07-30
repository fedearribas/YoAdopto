import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  currentYear: number;
  constructor() { }

  ngOnInit() {
    this.currentYear = new Date().getFullYear();
  }

}
