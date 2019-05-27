//============== 事件操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================

/**
 * 事件操作
 */
export class EventHelper {
    /**
     * 获取事件传递的值
     * @param event 事件
     */
    static getValue<TResult>(event): TResult {
        if (event && event.target )
            return event.target.value;
        return event;
    }
}