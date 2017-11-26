//============== Util公共操作库测试===============
//Copyright 2017 何镇汐
//Licensed under the MIT license
//================================================

import * as util from "../../util/core"

describe("util.helper", () => {
    it("isEmpty", () => {
        expect(util.helper.isEmpty(undefined)).toBeTruthy("undefined");
        expect(util.helper.isEmpty(null)).toBeTruthy("null");
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
        expect(util.helper.isNumber(util.helper.toNumber("8.99999999999999999", 2, true))).toBeTruthy();
    });
    it("isEmptyArray", () => {
        expect(util.helper.isEmptyArray(undefined)).toBeFalsy();
        expect(util.helper.isEmptyArray(null)).toBeFalsy();
        expect(util.helper.isEmptyArray([])).toBeTruthy();
        expect(util.helper.isEmptyArray([1])).toBeFalsy();
    });
});
