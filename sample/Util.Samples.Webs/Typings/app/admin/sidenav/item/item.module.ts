export class SidenavItem {
  name: string;
  icon: string;
  route: any;
  parent: SidenavItem;
  subItems: any;//子栏目数组（subItems: SidenavItem[]）
  position: number;//位置

  constructor(model: any = null) {
    if (model) {
      this.name = model.name;
      this.icon = model.icon;
      this.route = model.route;
      this.parent = model.parent;
      this.subItems = this.mapSubItems(model.subItems);
      this.position = model.position;
    }
  }

  hasSubItems() {
    if (this.subItems) {
      return this.subItems.length > 0;
    }
    return false;
  }

  hasParent() {
    return !!this.parent;
  }

  mapSubItems(list: SidenavItem[]) {
    if (list) {
      list.forEach((item, index) => {
        list[index] = new SidenavItem(item);
      });

      return list;
    }
  }

  isRouteString() {
    return this.route instanceof String || typeof this.route === 'string';
  }
}
