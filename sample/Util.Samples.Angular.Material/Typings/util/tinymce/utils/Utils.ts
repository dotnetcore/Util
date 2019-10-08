/**
 * Copyright (c) 2017-present, Ephox, Inc.
 *
 * This source code is licensed under the Apache 2 license found in the
 * LICENSE file in the root directory of this source tree.
 *
 */

import { EventEmitter } from '@angular/core';
import { EditorComponent } from '../editor/editor.component';
import { validEvents } from '../editor/Events';
import { UUID } from '../../common/internal/uuid';

export const bindHandlers = (ctx: EditorComponent, editor: any, initEvent: Event): void => {
    validEvents.forEach((eventName) => {
        const eventEmitter: EventEmitter<any> = ctx[eventName];
        if (eventEmitter.observers.length > 0) {
            if (eventName === 'onInit') {
                ctx.ngZone.run(() => eventEmitter.emit({ event: initEvent, editor }));
            } else {
                editor.on(eventName.substring(2), ctx.ngZone.run(() => (event: any) => eventEmitter.emit({ event, editor })));
            }
        }
    });
};

export const uuid = (prefix: string): string => {
    return prefix + '_' + UUID.UUID();
};

export const isTextarea = (element?: Element): element is HTMLTextAreaElement => {
    return typeof element !== 'undefined' && element.tagName.toLowerCase() === 'textarea';
};

const normalizePluginArray = (plugins?: string | string[]): string[] => {
    if (typeof plugins === 'undefined' || plugins === '') {
        return [];
    }

    return Array.isArray(plugins) ? plugins : plugins.split(' ');
};

export const mergePlugins = (initPlugins: string | string[], inputPlugins?: string | string[]) =>
    normalizePluginArray(initPlugins).concat(normalizePluginArray(inputPlugins));
