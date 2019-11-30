import { Component, OnInit,forwardRef, Self, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BeersService } from 'src/app/services/beer.service';
import { FormGroup, FormBuilder, ControlValueAccessor, NG_VALUE_ACCESSOR, NgControl } from '@angular/forms';
import { MatInput } from '@angular/material';
import { Beer } from 'src/app/shared/models/beer';

export interface LoginReadyEvent {
    form: FormGroup;
}

@Component({
    selector: 'new',
    templateUrl: './new.component.html',
    styleUrls: ['./new.component.scss']
})
export class NewComponent implements OnInit {
    form: FormGroup;

    @Output()
    formReady = new EventEmitter<LoginReadyEvent>();

    constructor(private fb: FormBuilder, private route: ActivatedRoute, private service: BeersService, private router: Router) {}

    public static BuildCreateForm(fb: FormBuilder) {
        return fb.group({
            company: fb.control(''),
            name: fb.control(''),
            style: fb.control(''),
            abv: fb.control(0),
            suggestedGlass: fb.control(''),
            description: fb.control(''),
            imageURL: fb.control(''),
        });
    }

    ngOnInit() {
        this.form = NewComponent.BuildCreateForm(this.fb);
        this.formReady.emit({ form: this.form });
        setTimeout(() => {
          (window.document.getElementById('company') as HTMLElement).focus();
        }, 200);
    }

    addBeer() {
        this.form.disable();
        const beer = this.form.getRawValue() as Beer;
        beer.avgRating = 0;
        beer.createdByUser = "user";
        beer.createdDate = new Date();

        this.service.addBeer(beer).subscribe(res => {
            if (!res) {
                alert('An Error happened');
                this.form.enable();
            } else{
                console.log(res);
                this.router.navigate(['/beer/' + res.id]);
            }
        });
    }

    onFormReady(event: LoginReadyEvent) {
        this.form = event.form;
    }
}
