import { Publication } from './../../../_models/publication';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { AuthService } from '../../../_services/auth.service';

@Component({
  selector: 'app-publication-detail',
  templateUrl: './publication-detail.component.html',
  styleUrls: ['./publication-detail.component.css']
})
export class PublicationDetailComponent implements OnInit {
  publication: Publication;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private route: ActivatedRoute, public authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.publication = data['publication'];
    });

    this.galleryOptions = [
      {
          width: '100%',
          imagePercent: 100,
          thumbnailsColumns: 5,
          imageAnimation: NgxGalleryAnimation.Slide
      },
       // max-width 800
      {
          breakpoint: 767,
          width: '100%',
          height: '600px',
          imagePercent: 80,
          thumbnailsPercent: 20,
          thumbnailsMargin: 20,
          thumbnailMargin: 20
      },
      // max-width 400
      {
          breakpoint: 400,
          preview: false
      }
    ];

    this.galleryImages = this.getImages();
  }

  getImages() {
    const images = [];
    for (let i = 0; i < this.publication.photoUrls.length; i++) {
      images.push({
        small: this.publication.photoUrls[i],
        medium: this.publication.photoUrls[i],
        big: this.publication.photoUrls[i]
      });
    }
    return images;
  }

}
