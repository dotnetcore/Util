import { Component, AfterViewInit, Input, ElementRef, OnDestroy, forwardRef, NgZone } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

import { uuid, isTextarea, bindHandlers, mergePlugins } from '../utils/Utils';
import { getTinymce } from '../TinyMCE';
import { Events } from './Events';

const EDITOR_COMPONENT_VALUE_ACCESSOR = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => EditorComponent),
    multi: true
};

@Component({
    selector: 'tinymce-editor',
    template: '<ng-template></ng-template>',
    styles: [':host { display: block; }'],
    providers: [EDITOR_COMPONENT_VALUE_ACCESSOR]
})
export class EditorComponent extends Events implements AfterViewInit, ControlValueAccessor, OnDestroy {
    private elementRef: ElementRef;
    private element: Element | undefined = undefined;
    private editor: any;

    ngZone: NgZone;

    @Input() init: { [key: string]: any } | undefined;
    @Input() id = '';
    @Input() initialValue: string | undefined;
    @Input() inline: boolean | undefined;
    @Input() tagName: string | undefined;
    @Input() plugins: string | undefined;
    @Input() toolbar: string | string[] | null = null;

    private onTouchedCallback = () => { };
    private onChangeCallback = (x: any) => { };

    constructor(elementRef: ElementRef, ngZone: NgZone) {
        super();
        this.elementRef = elementRef;
        this.ngZone = ngZone;
        this.initialise = this.initialise.bind(this);
    }

    writeValue(value: string | null): void {
        this.initialValue = value || this.initialValue;

        if (this.editor && this.editor.initialized && typeof value === 'string') {
            this.editor.setContent(value);
        }
    }

    registerOnChange(fn: (_: any) => void): void {
        this.onChangeCallback = fn;
    }

    registerOnTouched(fn: any): void {
        this.onTouchedCallback = fn;
    }

    setDisabledState(isDisabled: boolean) {
        if (this.editor) {
            this.editor.setMode(isDisabled ? 'readonly' : 'design');
        } else if (isDisabled) {
            this.init = { ...this.init, readonly: true };
        }
    }

    ngAfterViewInit() {
        this.id = this.id || uuid('tiny-react');
        this.inline = typeof this.inline !== 'undefined' ? this.inline : this.init && this.init.inline;
        this.createElement();
        if (getTinymce() !== null) {
            this.initialise();
        }
    }

    ngOnDestroy() {
        getTinymce().remove(this.editor);
    }

    createElement() {
        const tagName = typeof this.tagName === 'string' ? this.tagName : 'div';
        this.element = document.createElement(this.inline ? tagName : 'textarea');
        if (this.element) {
            this.element.id = this.id;
            if (isTextarea(this.element)) {
                this.element.style.visibility = 'hidden';
            }
            this.elementRef.nativeElement.appendChild(this.element);
        }
    }

    initialise() {
        const finalInit = {
            ...this.init,
            selector: `#${this.id}`,
            inline: this.inline,
            plugins: mergePlugins(this.init && this.init.plugins, this.plugins),
            toolbar: this.toolbar || (this.init && this.init.toolbar),
            setup: (editor: any) => {
                this.editor = editor;
                editor.on('init', (e: Event) => {
                    this.initEditor(e, editor);
                });

                if (this.init && typeof this.init.setup === 'function') {
                    this.init.setup(editor);
                }
            }
        };

        if (isTextarea(this.element)) {
            this.element.style.visibility = '';
        }

        this.ngZone.runOutsideAngular(() => {
            let ce = getTinymce();
            ce.init(finalInit);
        });
    }

    private initEditor(initEvent: Event, editor: any) {
        if (typeof this.initialValue === 'string') {
            this.ngZone.run(() => editor.setContent(this.initialValue));
        }
        editor.once('blur', () => this.ngZone.run(() => this.onTouchedCallback()));
        editor.on(
            'setcontent',
            ({ content, format }: any) => format === 'html' && content && this.ngZone.run(() => this.onChangeCallback(content))
        );
        editor.on('change keyup', () => this.ngZone.run(() => this.onChangeCallback(editor.getContent())));
        bindHandlers(this, editor, initEvent);
    }
}
