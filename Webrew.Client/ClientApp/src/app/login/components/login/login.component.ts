import { Component, OnInit, forwardRef, Self, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../../services/login.service';
import { FormGroup, FormBuilder, ControlValueAccessor, NG_VALUE_ACCESSOR, NgControl } from '@angular/forms';
import { MatInput } from '@angular/material';
import { UserLogin } from '../../models/user-login';

export interface LoginReadyEvent {
    form: FormGroup;
}

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    form: FormGroup;

    @Output()
    formReady = new EventEmitter<LoginReadyEvent>();

    constructor(private fb: FormBuilder, private route: ActivatedRoute, private service: LoginService, private router: Router) {}

    public static BuildCreateForm(fb: FormBuilder) {
        return fb.group({
          username: fb.control(''),
          password: fb.control('')
        });
    }

    ngOnInit() {
        this.form = LoginComponent.BuildCreateForm(this.fb);
        this.formReady.emit({ form: this.form });
        setTimeout(() => {
          (window.document.getElementById('username') as HTMLElement).focus();
        }, 200);
    }

    submitLogin() {
        this.form.disable();
        const userLogin = this.form.getRawValue() as UserLogin;

        this.service.loginAccount(userLogin).subscribe(res => {
            if (!res) {
                alert('An Error happened');
                this.form.enable();
            } else{
                console.log(res);
            }
        });
      }

    submitCreate() {
        this.form.disable();
        this.router.navigate(['/login/new']);
    }

    onFormReady(event: LoginReadyEvent) {
        this.form = event.form;
    }
}
