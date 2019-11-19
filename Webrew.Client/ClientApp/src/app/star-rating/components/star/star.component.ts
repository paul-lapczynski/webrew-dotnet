import {
    Component,
    OnInit,
    Input,
    OnChanges,
    SimpleChanges,
    Output,
    EventEmitter,
    HostListener,
    ChangeDetectorRef,
    ChangeDetectionStrategy
} from '@angular/core';
import { StarFill } from '../../models/StarFill';
import { Observable, BehaviorSubject } from 'rxjs';

type StarIcon = 'star_border' | 'star_half' | 'star';

@Component({
    selector: 'star',
    templateUrl: './star.component.html',
    styleUrls: ['./star.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class StarComponent implements OnInit, OnChanges {
    @Input()
    fill: StarFill;

    @Input()
    position: number;

    @Output()
    starMouseOut = new EventEmitter();

    @Output()
    starMouseOver = new EventEmitter<number>();

    @Output()
    ratingSet = new EventEmitter<number>();

    @Input()
    starSize = 24;

    icon$: BehaviorSubject<StarIcon> = new BehaviorSubject<StarIcon>('star_border');

    constructor(private cd: ChangeDetectorRef) {}

    ngOnInit() {}

    @HostListener('mousemove')
    mouseEnter() {
        this.cd.detectChanges();
    }
    ngOnChanges(changes: SimpleChanges): void {
        if (changes && changes.fill && changes.fill.currentValue !== null) {
            this.changeIcon(changes.fill.currentValue);
        }
    }

    changeIcon(fill: StarFill) {
        switch (fill) {
            case StarFill.empty:
                this.icon$.next('star_border');
                return;
            case StarFill.full:
                this.icon$.next('star');
                return;
            case StarFill.half:
                this.icon$.next('star_half');
                return;
            default:
                return;
        }
    }

    onMouseOver(position: number) {
        this.starMouseOver.emit(position);
    }

    onClick(value: number) {
        this.ratingSet.emit(value);
    }
}
