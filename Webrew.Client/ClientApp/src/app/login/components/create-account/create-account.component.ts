import { Component, OnInit, forwardRef, Self, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../../services/login.service';
import { FormGroup, FormBuilder, ControlValueAccessor, NG_VALUE_ACCESSOR, NgControl } from '@angular/forms';
import { MatInput } from '@angular/material';
import { User } from '../../models/user';

export interface CreateReadyEvent {
  form: FormGroup;
}

@Component({
  selector: 'create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.scss']
})
export class CreateAccountComponent implements OnInit {
  form: FormGroup;

  @Output()
  formReady = new EventEmitter<CreateReadyEvent>();

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private service: LoginService, private router: Router) {}

  public static BuildCreateForm(fb: FormBuilder) {
    return fb.group({
      email: fb.control(''),
      username: fb.control(''),
      password: fb.control('')
    });
  }

  ngOnInit() {
    this.form = CreateAccountComponent.BuildCreateForm(this.fb);
    this.formReady.emit({ form: this.form });
    setTimeout(() => {
      (window.document.getElementById('email') as HTMLElement).focus();
    }, 200);
  }

  submitCreate() {
    this.form.disable();
    const user = this.form.getRawValue() as User;

    this.service.createAccount(user).subscribe(res => {
        if (!res) {
            alert('An Error happened');
            this.form.enable();
        } else{
            this.router.navigate(['home']);
        }
    });
  }

  onFormReady(event: CreateReadyEvent) {
      this.form = event.form;
  }
}
