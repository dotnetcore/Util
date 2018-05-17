//============== Util公共操作测试=================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { util } from "../../../util"

describe("util.helper", () => {
    it("isEmpty", () => {
        expect(util.helper.isEmpty(undefined)).toBeTruthy("undefined");
        expect(util.helper.isEmpty(null)).toBeTruthy("null");
        expect(util.helper.isEmpty({})).toBeTruthy("{}");
        expect(util.helper.isEmpty("")).toBeTruthy("''");
        expect(util.helper.isEmpty("  ")).toBeTruthy("'  '");
        expect(util.helper.isEmpty(0)).toBeFalsy("0");
        expect(util.helper.isEmpty("0")).toBeFalsy("'0'");
        expect(util.helper.isEmpty("00000000-0000-0000-0000-000000000000")).toBeTruthy("00000000-0000-0000-0000-000000000000");
        expect(util.helper.isEmpty("4ABCA27E-EAFC-4DEE-B809-8DD2ABDFDA1C")).toBeFalsy("4ABCA27E-EAFC-4DEE-B809-8DD2ABDFDA1C");
        expect(util.helper.isEmpty("6")).toBeFalsy("'6'");
        expect(util.helper.isEmpty(6)).toBeFalsy("6");
        expect(util.helper.isEmpty("a6")).toBeFalsy("a6");
    });
    it("isNumber", () => {
        expect(util.helper.isNumber(1)).toBeTruthy("1");
        expect(util.helper.isNumber("1")).toBeTruthy("'1'");
        expect(util.helper.isNumber("")).toBeFalsy("''");
        expect(util.helper.isNumber("a")).toBeFalsy("'a'");
    });
    it("toNumber", () => {
        expect(util.helper.toNumber("a")).toEqual(0, "a");
        expect(util.helper.toNumber("0")).toEqual(0, "0");
        expect(util.helper.toNumber("1")).toEqual(1, "1");
        expect(util.helper.toNumber("1.5")).toEqual(1.5, "1.5");
        expect(util.helper.toNumber("1.5", 0)).toEqual(2, "1.5,0");
        expect(util.helper.toNumber("1.5", 0, true)).toEqual(1, "1.5,0,true");
        expect(util.helper.toNumber("8.99999999999999999", 0)).toEqual(9);
        expect(util.helper.isNumber(util.helper.toNumber("8.99999999999999999", 0))).toBeTruthy();
        expect(util.helper.toNumber("8.99999999999999999", 2, true)).toEqual(8.99);
        expect(util.helper.toNumber(1.567, 1, true)).toEqual(1.5);
        expect(util.helper.isNumber(util.helper.toNumber("8.99999999999999999", 2, true))).toBeTruthy();
    });
    it("toBool", () => {
        expect(util.helper.toBool(true)).toBeTruthy(1);        
        expect(util.helper.toBool("true")).toBeTruthy(2);
        expect(util.helper.toBool("TRUE")).toBeTruthy(3);
        expect(util.helper.toBool(1)).toBeTruthy(4);
        expect(util.helper.toBool("1")).toBeTruthy(5);
        expect(util.helper.toBool("yes")).toBeTruthy(6);
        expect(util.helper.toBool("YES")).toBeTruthy(7);
        expect(util.helper.toBool("ok")).toBeTruthy(8);
        expect(util.helper.toBool("OK")).toBeTruthy(9);
        expect(util.helper.toBool("是")).toBeTruthy(10);
        expect(util.helper.toBool(undefined)).toBeFalsy(11);
        expect(util.helper.toBool(null)).toBeFalsy(12);
        expect(util.helper.toBool("")).toBeFalsy(13);
        expect(util.helper.toBool(0)).toBeFalsy(14);        
        expect(util.helper.toBool("0")).toBeFalsy(15);
        expect(util.helper.toBool(false)).toBeFalsy(16);
        expect(util.helper.toBool("false")).toBeFalsy(17);
        expect(util.helper.toBool("FALSE")).toBeFalsy(18);        
        expect(util.helper.toBool("a")).toBeFalsy(19);
    });
    it("isEmptyArray", () => {
        expect(util.helper.isEmptyArray(undefined)).toBeFalsy();
        expect(util.helper.isEmptyArray(null)).toBeFalsy();
        expect(util.helper.isEmptyArray([])).toBeTruthy();
        expect(util.helper.isEmptyArray([1])).toBeFalsy();
    });
    it("isValidDate", () => {
        expect(util.helper.isValidDate("1999-09-09")).toBeTruthy();
        expect(util.helper.isValidDate("1999-9-9")).toBeTruthy();
    });
    it("toDate", () => {
        expect(util.helper.isValidDate(util.helper.toDate("1999-09-09"))).toBeTruthy();
        expect(util.helper.toDate("1999-09-09").getFullYear()).toBe(1999);
        expect(util.helper.toDate("1999-09-09").getMonth()).toBe(8);
        expect(util.helper.toDate("1999-09-09").getDate()).toBe(9);
        expect(util.helper.isValidDate(util.helper.toDate("1999-9-9"))).toBeTruthy();
        expect(util.helper.toDate("1999-9-9 1:2:3").getFullYear()).toBe(1999);
        expect(util.helper.toDate("1999-9-9 1:2:3").getMonth()).toBe(8);
        expect(util.helper.toDate("1999-9-9 1:2:3").getDate()).toBe(9);
        expect(util.helper.toDate("1999-9-9 1:2:3").getHours()).toBe(1);
        expect(util.helper.toDate("1999-9-9 1:2:3").getMinutes()).toBe(2);
        expect(util.helper.toDate("1999-9-9 1:2:3").getSeconds()).toBe(3);
    });
    it("formatDate", () => {
        var date = new Date(2014, 11, 30, 1, 20, 15, 285);
        expect(util.helper.formatDate(date, "YYYY-MM-DD HH:mm:ss:SSS")).toBe("2014-12-30 01:20:15:285");
        expect(util.helper.formatDate(date, "YYYY年MM月DD日 HH:mm:ss")).toBe("2014年12月30日 01:20:15");

        expect(util.helper.formatDate("1999-09-09", "YYYY年MM月DD日")).toBe("1999年09月09日");
        expect(util.helper.formatDate("1999-9-9", "YYYY年MM月DD日")).toBe("1999年09月09日");
    });
    it("getValidDate", () => {
        expect(util.helper.getValidDate("1999-09-09")).toBe("1999-09-09");
        expect(util.helper.getValidDate("1999-9-9")).toBe("1999-09-09");
        expect(util.helper.getValidDate("1999-9-9 1:2")).toBe("1999-09-09 01:02");
        expect(util.helper.getValidDate("1999-9-9 1:2:3")).toBe("1999-09-09 01:02:03");
    });
    it("toObjectFromJson", () => {
        let obj = new Test();
        obj.name = "a";
        let json = util.helper.toJson(obj);
        let result = util.helper.toObjectFromJson<Test>(json);
        expect(result.name).toBe("a");
    });
    it("clone", () => {
        let obj = new Test();
        obj.name = "a";
        obj.test = new Test();
        obj.test.name = 'b';
        let result = util.helper.clone<Test>(obj);
        expect(result.name).toBe("a");
        expect(result.test.name).toBe("b");
        expect(result).not.toEqual(obj);
        expect(result.test).not.toEqual(obj.test);
    });
    it("remove", () => {
        let list = new Array<Test>();

        let a = new Test();
        a.name = "a";
        list.push(a);

        let b = new Test();
        b.name = "b";
        list.push(b);

        let c = new Test();
        c.name = "c";
        list.push(c);

        util.helper.remove(list, t => ["a", "b"].some(name => name === t.name) );
        expect(list.length).toBe(1);
        expect(list[0].name).toBe("c");
    });
    it("toList", () => {
        let input = "a,,b";
        let result = util.helper.toList<string>(input);
        expect(result.length).toBe(2);
        expect(result[0]).toBe("a");
        expect(result[1]).toBe("b");
    });
    it("first", () => {
        let input = ['a','b','c'];
        let result = util.helper.first(input);
        expect(result).toBe('a');
    });
    it("except_1", () => {
        let source = ['a', 'b'];
        let target = ['a', 'c'];
        let result = util.helper.except(source, target);
        expect(result.length).toBe(1);
        expect(result[0]).toBe('b');
    });
    it("except_2", () => {
        let source = new Array<Test>();
        source.push(new Test(1,"a"), new Test(2,"b"));
        let target = new Array<Test>();
        target.push(new Test(1, "a"), new Test(3, "c"));
        let result = util.helper.except(source, target, t => t.id);
        expect(result.length).toBe(1);
        expect(result[0].id).toBe(2);
        expect(result[0].name).toBe("b");
    });
    it("groupBy_1", () => {
        let source = new Array<Test>();
        source.push(new Test(1, "a"), new Test(1, "b"), new Test(2, "c"), new Test(2, "d"));
        let result = util.helper.groupBy(source, t => t.id);
        expect(result.size).toBe(2);
        expect(result.get("1")[0].id).toBe(1);
        expect(result.get("2")[0].id).toBe(2);
        expect(result.get("1")[0].name).toBe("a");
        expect(result.get("1")[1].name).toBe("b");
        expect(result.get("2")[0].name).toBe("c");
        expect(result.get("2")[1].name).toBe("d");
    });
    it("groupBy_2", () => {
        let source = new Array<Test>();
        source.push(new Test(1, "a"), new Test(1, "b"), new Test("", "c"), new Test("", "d"));
        let result = util.helper.groupBy(source, t => t.id);
        expect(result.size).toBe(1);
    });
});

class Test {
    constructor(public id?: number|string,public name?: string) {
    }
    test: Test;
}