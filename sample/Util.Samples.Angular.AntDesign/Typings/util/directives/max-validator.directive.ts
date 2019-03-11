//============== 最大值验证器指令 ================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Directive, forwardRef, OnChanges, Input, SimpleChanges } from '@angular/core';
import { Validator, NG_VALIDATORS, ValidatorFn, AbstractControl, ValidationErrors, Validators } from "@angular/forms";

/**
 * 最大值验证器指令
 */
@Directive({
    selector: '[max][formControlName],[max][formControl],[max][ngModel]',
    providers: [{
        provide: NG_VALIDATORS,
        useExisting: forwardRef(() => MaxValidator),
        multi: true
    }],
    host: { '[attr.max]': 'max ? max : null' }
})
export class MaxValidator implements Validator, OnChanges {
    /**
     * 验证器
     */
    private validator: ValidatorFn;
    /**
     * 变更事件
     */
    private onChange: () => void;
    /**
     * 最大值
     */
    @Input() max: number;

    /**
     * 变更事件
     */
    ngOnChanges(changes: SimpleChanges) {
        if ('max' in changes) {
            this.createValidator();
            this.onChange && this.onChange();
        }
    }

    /**
     * 创建验证器
     */
    private createValidator() {
        this.validator = Validators.max(this.max);
    }

    /**
     * 验证
     */
    validate(control: AbstractControl): ValidationErrors | null {
        return this.validator && this.validator(control);
    }

    /**
     * 注册变更事件
     */
    registerOnValidatorChange(fn: () => void) {
        this.onChange = fn;
    }
}