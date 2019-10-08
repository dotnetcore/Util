//============== Util列表操作测试=================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import {Select,SelectItem} from '../../../util/core/select';

describe("select", () => {
    it("toOptions_1", () => {
        let data: SelectItem[] = [{text:"a",value:"1"}];
        let select = new Select(data);
        let result = select.toOptions();
        expect(result.length).toBe(1);
        expect(result[0].text).toBe("a");
        expect(result[0].value).toBe("1");
    });
    it("toOptions_2", () => {
        let data: SelectItem[] = [{ text: "a", value: "1" }, { text: "b", value: "2",disabled:true }];
        let select = new Select(data);
        let result = select.toOptions();
        expect(result.length).toBe(2);
        expect(result[0].text).toBe("a");
        expect(result[0].value).toBe("1");
        expect(result[0].disabled).toBeFalsy();
        expect(result[1].text).toBe("b");
        expect(result[1].value).toBe("2");
        expect(result[1].disabled).toBeTruthy();
    });
    it("toGroups_1", () => {
        let data: SelectItem[] = [{ text: "a", value: "1", group: "group" }, { text: "b", value: "2", disabled: true, group: "group"}];
        let select = new Select(data);
        let result = select.toGroups();
        expect(result.length).toBe(1);
        expect(result[0].text).toBe("group");
        let value = result[0].value;
        expect(value && value[0].text).toBe("a");
        expect(value && value[0].value).toBe("1");
        expect(value && value[1].text).toBe("b");
        expect(value && value[1].value).toBe("2");
    });
    it("toGroups_2", () => {
        let data: SelectItem[] = [{ text: "a", value: "1", group: "group", sortId: 3 },
            { text: "b", value: "2", group: "group", sortId: 1 },
            { text: "c", value: "3", group: "group", sortId: 2 }];
        let select = new Select(data);
        let result = select.toGroups();
        expect(result.length).toBe(1);
        expect(result[0].text).toBe("group");
        let value = result[0].value;
        expect(value && value[0].text).toBe("b");
        expect(value && value[0].value).toBe("2");
        expect(value && value[1].text).toBe("c");
        expect(value && value[1].value).toBe("3");
        expect(value && value[2].text).toBe("a");
        expect(value && value[2].value).toBe("1");
    });
    it("toGroups_3", () => {
        let data: SelectItem[] = [{ text: "a", value: "1", group: "group", sortId: 3 },
            { text: "b", value: "2", group: "group", sortId: 2 },
            { text: "c", value: "3", group: "group2", sortId: 4 },
            { text: "d", value: "4", group: "group2", sortId: 1 }];
        let select = new Select(data);
        let result = select.toGroups();
        expect(result.length).toBe(2);
        expect(result[0].text).toBe("group2");
        expect(result[1].text).toBe("group");
        let group1 = result[0].value;
        expect(group1 && group1[0].text).toBe("d");
        expect(group1 && group1[0].value).toBe("4");
        expect(group1 && group1[1].text).toBe("c");
        expect(group1 && group1[1].value).toBe("3");
        let group2 = result[1].value;
        expect(group2 && group2[0].text).toBe("b");
        expect(group2 && group2[0].value).toBe("2");
        expect(group2 && group2[1].text).toBe("a");
        expect(group2 && group2[1].value).toBe("1");
    });
    it("isGroup_1", () => {
        let data: SelectItem[] = [{ text: "a", value: "1" }, { text: "b", value: "2", disabled: true }];
        let select = new Select(data);
        expect(select.isGroup()).toBeFalsy();
    });
    it("isGroup_2", () => {
        let data: SelectItem[] = [{ text: "a", value: "1",group:"a" }, { text: "b", value: "2", disabled: true }];
        let select = new Select(data);
        expect(select.isGroup()).toBeFalsy();
    });
    it("isGroup_3", () => {
        let data: SelectItem[] = [{ text: "a", value: "1", group: "a" }, { text: "b", value: "2", disabled: true, group: "a" }];
        let select = new Select(data);
        expect(select.isGroup()).toBeTruthy();
    });
});