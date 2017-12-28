import { Injectable } from '@angular/core';
import { SidenavItem } from './item/item.module';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class SidenavService {

    private _itemsSubject: BehaviorSubject<SidenavItem[]> = new BehaviorSubject<SidenavItem[]>([]);
    private _items: SidenavItem[] = [];
    items$: Observable<SidenavItem[]> = this._itemsSubject.asObservable();

    private _currentlyOpenSubject: BehaviorSubject<SidenavItem[]> = new BehaviorSubject<SidenavItem[]>([]);
    private _currentlyOpen: SidenavItem[] = [];
    currentlyOpen$: Observable<SidenavItem[]> = this._currentlyOpenSubject.asObservable();

    private mysidenav = [{
        name: '主页', icon: 'home', route: '', position: 1, subItems: []
    },
    {
        name: '拓展组件', icon: 'bubble_chart', route: null, position: 1, subItems: [
            { name: '登录', icon: 'airplanemode_active', route: 'login', position: 1 }]
    }, {
        name: '公共组件', icon: 'flare', route: null, position: 1, subItems: [
            { name: '搜索', icon: 'search', route: 'searchmenu', position: 1 }]
    }];

    constructor() {
        for (var mycount in this.mysidenav) {
            const item = this.mysidenav[mycount];
            if (item) {
                const news = this.addItem(item.name, item.icon, item.route, item.position);
                if (item.subItems.length > 0) {
                    for (var count in item.subItems) {
                        this.addSubItem(news, item.subItems[count].name, item.subItems[count].icon, item.subItems[count].route, item.subItems[count].position);
                    }
                }
            }
        }
    }

    addMenu() {

    }

    addItem(name: string, icon: string, route: any, position: number) {
        const item = new SidenavItem({
            name: name,
            icon: icon,
            route: route,
            subItems: [],
            position: position || 99
        });

        this._items.push(item);
        this._itemsSubject.next(this._items);

        return item;
    }

    addSubItem(parent: SidenavItem, name: string, icon: string, route: any, position: number) {
        const item = new SidenavItem({
            name: name,
            icon: icon,
            route: route,
            parent: parent,
            subItems: [],
            position: position || 99
        });

        parent.subItems.push(item);
        this._itemsSubject.next(this._items);

        return item;
    }

    isOpen(item: SidenavItem) {
        return (this._currentlyOpen.indexOf(item) !== -1);
    }

    toggleCurrentlyOpen(item: SidenavItem) {
        let currentlyOpen = this._currentlyOpen;
        if (this.isOpen(item)) {
            if (currentlyOpen.length > 1) {
                currentlyOpen.length = this._currentlyOpen.indexOf(item);
            } else {
                currentlyOpen = [];
            }
        } else {
            currentlyOpen = this.getAllParents(item);
        }

        this._currentlyOpen = currentlyOpen;
        this._currentlyOpenSubject.next(currentlyOpen);
    }

    getAllParents(item: SidenavItem, currentlyOpen: SidenavItem[] = []) {
        currentlyOpen.unshift(item);

        if (item.hasParent()) {
            return this.getAllParents(item.parent, currentlyOpen);
        } else {
            return currentlyOpen;
        }
    }

    nextCurrentlyOpen(currentlyOpen: SidenavItem[]) {
        this._currentlyOpen = currentlyOpen;
        this._currentlyOpenSubject.next(currentlyOpen);
    }

    nextCurrentlyOpenByRoute(route: string) {
        const currentlyOpen = [];

        const item = this.findByRouteRecursive(route, this._items);

        // if (item && item.hasParent()) {
        //   currentlyOpen = this.getAllParents(item);
        // } else if (item) {
        //   currentlyOpen = [item];
        // }
        //
        // this.nextCurrentlyOpen(currentlyOpen);
    }

    findByRouteRecursive(route: string, collection: SidenavItem[]) {
        let result = collection.filter((item) => {
            if (item.route === route) {
                return item;
            }
        });


        if (!result) {
            collection.forEach((item) => {
                if (item.hasSubItems()) {
                    const found = this.findByRouteRecursive(route, item.subItems);

                    if (found) {
                        result = found;
                        return false;
                    }
                }
            });
        }

        return result;
    }

    get currentlyOpen() {
        return this._currentlyOpen;
    }

    getSidenavItemByRoute(route) {
        return this.findByRouteRecursive(route, this._items);
    }

}
