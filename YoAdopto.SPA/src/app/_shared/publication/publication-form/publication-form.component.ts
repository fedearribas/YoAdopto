import { PublicationPhoto } from './../../../_models/publicationPhoto';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Publication } from '../../../_models/publication';
import { PublicationService } from '../../../_services/publication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../_services/auth.service';

@Component({
  selector: 'app-publication-form',
  templateUrl: './publication-form.component.html',
  styleUrls: ['./publication-form.component.css']
})
export class PublicationFormComponent implements OnInit {

  title: string;
  publicationForm: FormGroup;
  publication: Publication;
  publicationTypeId: number;
  id: number;
  imageUrl = '';
  imageSelected = false;
  editMode = false;
  urls = new Array<string>();
  imageFiles = new Array<File>();
  isSaving = false;

  constructor(private publicationService: PublicationService,
              private router: Router,
              private authService: AuthService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.title = 'Nueva Publicación de Perdidos';
    this.initForm();
  }

  private initForm() {
    this.publicationForm = new FormGroup({
      'title': new FormControl(null, Validators.required),
      'description': new FormControl(null, Validators.required),
      'state': new FormControl(null, Validators.required),
      'city': new FormControl(null, Validators.required),
      'contactPhone': new FormControl(null),
      'contactEmail': new FormControl(null, [Validators.email])
    });
  }

  detectFiles(event) {
    this.urls = [];
    const files = event.target.files;
    if (files) {
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.urls.push(e.target.result);
          this.imageSelected = true;
          this.imageFiles.push(file);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  onClearSelectedImage() {
    this.urls = [];
    this.imageFiles = [];
    this.imageSelected = false;
  }

  onSubmit() {
    this.publication = Object.assign({}, this.publicationForm.value);
    this.publication.publicationType = 1;

    for(let photo of this.imageFiles) {
      let file: PublicationPhoto = {
        file: photo
      };
      this.publication.photos = [];
      this.publication.photos.push(file);
    }

    this.isSaving = true;

    if (this.editMode) {
   //   this.publicationService.updatePublication(this.publication);
    } else {
      const userId = this.authService.currentUser.id;
      this.publication.userId = userId;
      this.publicationService.insertPublication(this.publication);
    }
  }
}
