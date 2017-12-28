/**
 * @author stbui <https://github.com/stbui>
 */
import { Component, OnInit, Input, Inject, HostBinding, ViewEncapsulation } from '@angular/core';
import { SidenavItem } from './item.module';

@Component({
  selector: 'sidenav-item',
  templateUrl: './home/item',
  encapsulation: ViewEncapsulation.None
})
export class ItemComponent implements OnInit {

  @Input() item: SidenavItem;

  @HostBinding('class.open')
  get isOpen() {
    return this.service.isOpen(this.item);
  }

  constructor( @Inject('sidenavService') private service) {
  }

  ngOnInit() {
  }

  /**
   *  菜单展开开关
   */
  toggleDropdown(): void {
    if (this.item.hasSubItems()) {
      this.service.toggleCurrentlyOpen(this.item);
    }
  }

  /**
   * 获取子菜单高度
   * @returns {string}
   */
  getSubItemsHeight() {
    if (this.item.hasSubItems()) {
      return (this.getOpenSubItemsCount(this.item) * 48) + 'px';
    }
  }

  /**
   * 计算子菜单高度
   * @param item {SidenavItem} 菜单项
   * @returns {number} 子菜单总数
   */
  getOpenSubItemsCount(item: SidenavItem): number {
    let count = 0;
    if (item.hasSubItems() && this.service.isOpen(item)) {
      count += item.subItems.length;
      item.subItems.forEach((subItem) => {
        count += this.getOpenSubItemsCount(subItem);
      });
    }
    return count;
  }
}
