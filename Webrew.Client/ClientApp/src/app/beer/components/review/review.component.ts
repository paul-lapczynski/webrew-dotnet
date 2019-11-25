import { Component, OnInit, forwardRef, Self, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, ControlValueAccessor, NG_VALUE_ACCESSOR, NgControl } from '@angular/forms';
import { MatInput } from '@angular/material';

export interface ReviewReadyEvent {
    form: FormGroup;
}

@Component({
    selector: 'review',
    templateUrl: './review.component.html',
    styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {
    form: FormGroup;

    @Output()
    formReady = new EventEmitter<ReviewReadyEvent>();

    constructor(private fb: FormBuilder) {}

    public static BuildReviewForm(fb: FormBuilder) {
        return fb.group({
            beerId: fb.control(''),
            summary: fb.control(''),
            look: fb.control(0),
            smell: fb.control(0),
            taste: fb.control(0),
            feel: fb.control(0),
            overall: fb.control(0),
            createdDate: fb.control(''),
            createdByUser: fb.control(''),
            id: fb.control('')
        });
    }

    ngOnInit() {
        this.form = ReviewComponent.BuildReviewForm(this.fb);
        this.formReady.emit({ form: this.form });
    }
}
