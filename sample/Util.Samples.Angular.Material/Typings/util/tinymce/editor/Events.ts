import { Output, EventEmitter } from '@angular/core';

export interface EventObj<T> {
  event: T;
  editor: any;
}

export class Events {
  @Output() onBeforePaste: EventEmitter<EventObj<ClipboardEvent>> = new EventEmitter();
  @Output() onBlur: EventEmitter<EventObj<FocusEvent>> = new EventEmitter();
  @Output() onClick: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onContextMenu: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onCopy: EventEmitter<EventObj<ClipboardEvent>> = new EventEmitter();
  @Output() onCut: EventEmitter<EventObj<ClipboardEvent>> = new EventEmitter();
  @Output() onDblclick: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onDrag: EventEmitter<EventObj<DragEvent>> = new EventEmitter();
  @Output() onDragDrop: EventEmitter<EventObj<DragEvent>> = new EventEmitter();
  @Output() onDragEnd: EventEmitter<EventObj<DragEvent>> = new EventEmitter();
  @Output() onDragGesture: EventEmitter<EventObj<DragEvent>> = new EventEmitter();
  @Output() onDragOver: EventEmitter<EventObj<DragEvent>> = new EventEmitter();
  @Output() onDrop: EventEmitter<EventObj<DragEvent>> = new EventEmitter();
  @Output() onFocus: EventEmitter<EventObj<FocusEvent>> = new EventEmitter();
  @Output() onFocusIn: EventEmitter<EventObj<FocusEvent>> = new EventEmitter();
  @Output() onFocusOut: EventEmitter<EventObj<FocusEvent>> = new EventEmitter();
  @Output() onKeyDown: EventEmitter<EventObj<KeyboardEvent>> = new EventEmitter();
  @Output() onKeyPress: EventEmitter<EventObj<KeyboardEvent>> = new EventEmitter();
  @Output() onKeyUp: EventEmitter<EventObj<KeyboardEvent>> = new EventEmitter();
  @Output() onMouseDown: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onMouseEnter: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onMouseLeave: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onMouseMove: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onMouseOut: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onMouseOver: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onMouseUp: EventEmitter<EventObj<MouseEvent>> = new EventEmitter();
  @Output() onPaste: EventEmitter<EventObj<ClipboardEvent>> = new EventEmitter();
  @Output() onSelectionChange: EventEmitter<EventObj<Event>> = new EventEmitter();
  @Output() onActivate: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onAddUndo: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onBeforeAddUndo: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onBeforeExecCommand: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onBeforeGetContent: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onBeforeRenderUI: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onBeforeSetContent: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onChange: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onClearUndos: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onDeactivate: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onDirty: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onExecCommand: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onGetContent: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onHide: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onInit: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onLoadContent: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onNodeChange: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onPostProcess: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onPostRender: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onPreInit: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onPreProcess: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onProgressState: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onRedo: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onRemove: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onReset: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onSaveContent: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onSetAttrib: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onObjectResizeStart: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onObjectResized: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onObjectSelected: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onSetContent: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onShow: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onSubmit: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onUndo: EventEmitter<EventObj<any>> = new EventEmitter();
  @Output() onVisualAid: EventEmitter<EventObj<any>> = new EventEmitter();
}

export const validEvents: (keyof Events)[] = [
  'onActivate',
  'onAddUndo',
  'onBeforeAddUndo',
  'onBeforeExecCommand',
  'onBeforeGetContent',
  'onBeforeRenderUI',
  'onBeforeSetContent',
  'onBeforePaste',
  'onBlur',
  'onChange',
  'onClearUndos',
  'onClick',
  'onContextMenu',
  'onCopy',
  'onCut',
  'onDblclick',
  'onDeactivate',
  'onDirty',
  'onDrag',
  'onDragDrop',
  'onDragEnd',
  'onDragGesture',
  'onDragOver',
  'onDrop',
  'onExecCommand',
  'onFocus',
  'onFocusIn',
  'onFocusOut',
  'onGetContent',
  'onHide',
  'onInit',
  'onKeyDown',
  'onKeyPress',
  'onKeyUp',
  'onLoadContent',
  'onMouseDown',
  'onMouseEnter',
  'onMouseLeave',
  'onMouseMove',
  'onMouseOut',
  'onMouseOver',
  'onMouseUp',
  'onNodeChange',
  'onObjectResizeStart',
  'onObjectResized',
  'onObjectSelected',
  'onPaste',
  'onPostProcess',
  'onPostRender',
  'onPreProcess',
  'onProgressState',
  'onRedo',
  'onRemove',
  'onReset',
  'onSaveContent',
  'onSelectionChange',
  'onSetAttrib',
  'onSetContent',
  'onShow',
  'onSubmit',
  'onUndo',
  'onVisualAid'
];
