import {
    Component,
    OnInit,
    HostListener,
    ElementRef,
    Renderer2,
    ChangeDetectorRef,
    Provider,
    forwardRef
} from '@angular/core';
import { StarFill } from '../../models/StarFill';
import { BehaviorSubject } from 'rxjs';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { MAT_CHECKBOX_CONTROL_VALUE_ACCESSOR } from '@angular/material';

@Component({
    selector: 'star-rating',
    templateUrl: './star-rating.component.html',
    styleUrls: ['./star-rating.component.scss'],
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => StarRatingComponent), multi: true }]
})
export class StarRatingComponent implements OnInit, ControlValueAccessor {
    fill = StarFill;
    stars = [1, 2, 3, 4, 5];
    rating = 0;
    hoverRating: number | null = 0;
    hovering = false;

    onChange: (obj: any) => void;
    onTouched: () => void;

    constructor() {}

    ngOnInit() {}

    setValue(value: number) {
        this.rating = value;

        if (this.onChange) {
            this.onChange(this.rating);
        }
    }

    @HostListener('mousemove')
    onMouseEnter() {
        console.log('entering rating');

        if (!this.hovering) {
            this.hoverRating = 0;
        }
        this.hovering = true;
    }

    @HostListener('mouseleave')
    onMouseOut() {
        this.hovering = false;
        this.hoverRating = null;
    }

    onStarMouseOver(position: number) {
        this.hovering = true;
        this.hoverRating = position;
    }

    getStartFill(star: number) {
        const currentRating = this.hovering ? this.hoverRating : this.rating;
        // if (!this.hovering) {
        //     const actualyGt = star > this.rating;
        //     return actualyGt ? this.fill.empty : this.fill.full;
        // }

        const gt = star > currentRating;
        if (gt) {
            if (star - 0.5 === currentRating) {
                return this.fill.half;
            }

            return this.fill.empty;
        } else {
            return this.fill.full;
        }
    }

    /**
     * Control Value Accessor
     */
    writeValue(obj: any): void {
        this.setValue(Math.round(obj * 2) / 2);
    }
    registerOnChange(fn: any): void {
        this.onChange = fn;
    }
    registerOnTouched(fn: any): void {
        this.onTouched = fn;
    }
    setDisabledState?(isDisabled: boolean): void {}
}
