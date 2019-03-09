import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TransferService } from './transfer.service';

@Component({
  selector: 'app-step1',
  templateUrl: './step1.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Step1Component implements OnInit {
  form: FormGroup;

  constructor(private fb: FormBuilder, public item: TransferService) {}

  ngOnInit() {
    this.form = this.fb.group({
      pay_account: [
        null,
        Validators.compose([Validators.required, Validators.email]),
      ],
      receiver_type: [null, [Validators.required]],
      receiver_account: [null, [Validators.required]],
      receiver_name: [
        null,
        Validators.compose([Validators.required, Validators.minLength(2)]),
      ],
      amount: [
        null,
        Validators.compose([
          Validators.required,
          Validators.pattern(`[0-9]+`),
          Validators.min(1),
          Validators.max(10000 * 100),
        ]),
      ],
    });
    this.form.patchValue(this.item);
  }

  //#region get form fields
  get pay_account() {
    return this.form.controls['pay_account'];
  }
  get receiver_type() {
    return this.form.controls['receiver_type'];
  }
  get receiver_account() {
    return this.form.controls['receiver_account'];
  }
  get receiver_name() {
    return this.form.controls['receiver_name'];
  }
  get amount() {
    return this.form.controls['amount'];
  }
  //#endregion

  _submitForm() {
    this.item = Object.assign(this.item, this.form.value);
    ++this.item.step;
  }
}
