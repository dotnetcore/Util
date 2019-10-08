(function () {
var mobile = (function () {
  'use strict';

  var noop = function () {
    var x = [];
    for (var _i = 0; _i < arguments.length; _i++) {
      x[_i] = arguments[_i];
    }
  };
  var noarg = function (f) {
    return function () {
      var x = [];
      for (var _i = 0; _i < arguments.length; _i++) {
        x[_i] = arguments[_i];
      }
      return f();
    };
  };
  var compose = function (fa, fb) {
    return function () {
      var x = [];
      for (var _i = 0; _i < arguments.length; _i++) {
        x[_i] = arguments[_i];
      }
      return fa(fb.apply(null, arguments));
    };
  };
  var constant = function (value) {
    return function () {
      return value;
    };
  };
  var identity = function (x) {
    return x;
  };
  var tripleEquals = function (a, b) {
    return a === b;
  };
  var curry = function (f) {
    var x = [];
    for (var _i = 1; _i < arguments.length; _i++) {
      x[_i - 1] = arguments[_i];
    }
    var args = new Array(arguments.length - 1);
    for (var i = 1; i < arguments.length; i++)
      args[i - 1] = arguments[i];
    return function () {
      var x = [];
      for (var _i = 0; _i < arguments.length; _i++) {
        x[_i] = arguments[_i];
      }
      var newArgs = new Array(arguments.length);
      for (var j = 0; j < newArgs.length; j++)
        newArgs[j] = arguments[j];
      var all = args.concat(newArgs);
      return f.apply(null, all);
    };
  };
  var not = function (f) {
    return function () {
      var x = [];
      for (var _i = 0; _i < arguments.length; _i++) {
        x[_i] = arguments[_i];
      }
      return !f.apply(null, arguments);
    };
  };
  var die = function (msg) {
    return function () {
      throw new Error(msg);
    };
  };
  var apply = function (f) {
    return f();
  };
  var call = function (f) {
    f();
  };
  var never = constant(false);
  var always = constant(true);
  var $_2vokfcwwjfuw8tb4 = {
    noop: noop,
    noarg: noarg,
    compose: compose,
    constant: constant,
    identity: identity,
    tripleEquals: tripleEquals,
    curry: curry,
    not: not,
    die: die,
    apply: apply,
    call: call,
    never: never,
    always: always
  };

  var typeOf = function (x) {
    if (x === null)
      return 'null';
    var t = typeof x;
    if (t === 'object' && Array.prototype.isPrototypeOf(x))
      return 'array';
    if (t === 'object' && String.prototype.isPrototypeOf(x))
      return 'string';
    return t;
  };
  var isType = function (type) {
    return function (value) {
      return typeOf(value) === type;
    };
  };
  var $_8aqeo3wyjfuw8tb8 = {
    isString: isType('string'),
    isObject: isType('object'),
    isArray: isType('array'),
    isNull: isType('null'),
    isBoolean: isType('boolean'),
    isUndefined: isType('undefined'),
    isFunction: isType('function'),
    isNumber: isType('number')
  };

  var shallow = function (old, nu) {
    return nu;
  };
  var deep = function (old, nu) {
    var bothObjects = $_8aqeo3wyjfuw8tb8.isObject(old) && $_8aqeo3wyjfuw8tb8.isObject(nu);
    return bothObjects ? deepMerge(old, nu) : nu;
  };
  var baseMerge = function (merger) {
    return function () {
      var objects = new Array(arguments.length);
      for (var i = 0; i < objects.length; i++)
        objects[i] = arguments[i];
      if (objects.length === 0)
        throw new Error('Can\'t merge zero objects');
      var ret = {};
      for (var j = 0; j < objects.length; j++) {
        var curObject = objects[j];
        for (var key in curObject)
          if (curObject.hasOwnProperty(key)) {
            ret[key] = merger(ret[key], curObject[key]);
          }
      }
      return ret;
    };
  };
  var deepMerge = baseMerge(deep);
  var merge = baseMerge(shallow);
  var $_3jctjywxjfuw8tb6 = {
    deepMerge: deepMerge,
    merge: merge
  };

  var never$1 = $_2vokfcwwjfuw8tb4.never;
  var always$1 = $_2vokfcwwjfuw8tb4.always;
  var none = function () {
    return NONE;
  };
  var NONE = function () {
    var eq = function (o) {
      return o.isNone();
    };
    var call = function (thunk) {
      return thunk();
    };
    var id = function (n) {
      return n;
    };
    var noop = function () {
    };
    var me = {
      fold: function (n, s) {
        return n();
      },
      is: never$1,
      isSome: never$1,
      isNone: always$1,
      getOr: id,
      getOrThunk: call,
      getOrDie: function (msg) {
        throw new Error(msg || 'error: getOrDie called on none.');
      },
      or: id,
      orThunk: call,
      map: none,
      ap: none,
      each: noop,
      bind: none,
      flatten: none,
      exists: never$1,
      forall: always$1,
      filter: none,
      equals: eq,
      equals_: eq,
      toArray: function () {
        return [];
      },
      toString: $_2vokfcwwjfuw8tb4.constant('none()')
    };
    if (Object.freeze)
      Object.freeze(me);
    return me;
  }();
  var some = function (a) {
    var constant_a = function () {
      return a;
    };
    var self = function () {
      return me;
    };
    var map = function (f) {
      return some(f(a));
    };
    var bind = function (f) {
      return f(a);
    };
    var me = {
      fold: function (n, s) {
        return s(a);
      },
      is: function (v) {
        return a === v;
      },
      isSome: always$1,
      isNone: never$1,
      getOr: constant_a,
      getOrThunk: constant_a,
      getOrDie: constant_a,
      or: self,
      orThunk: self,
      map: map,
      ap: function (optfab) {
        return optfab.fold(none, function (fab) {
          return some(fab(a));
        });
      },
      each: function (f) {
        f(a);
      },
      bind: bind,
      flatten: constant_a,
      exists: bind,
      forall: bind,
      filter: function (f) {
        return f(a) ? me : NONE;
      },
      equals: function (o) {
        return o.is(a);
      },
      equals_: function (o, elementEq) {
        return o.fold(never$1, function (b) {
          return elementEq(a, b);
        });
      },
      toArray: function () {
        return [a];
      },
      toString: function () {
        return 'some(' + a + ')';
      }
    };
    return me;
  };
  var from = function (value) {
    return value === null || value === undefined ? NONE : some(value);
  };
  var Option = {
    some: some,
    none: none,
    from: from
  };

  var keys = function () {
    var fastKeys = Object.keys;
    var slowKeys = function (o) {
      var r = [];
      for (var i in o) {
        if (o.hasOwnProperty(i)) {
          r.push(i);
        }
      }
      return r;
    };
    return fastKeys === undefined ? slowKeys : fastKeys;
  }();
  var each = function (obj, f) {
    var props = keys(obj);
    for (var k = 0, len = props.length; k < len; k++) {
      var i = props[k];
      var x = obj[i];
      f(x, i, obj);
    }
  };
  var objectMap = function (obj, f) {
    return tupleMap(obj, function (x, i, obj) {
      return {
        k: i,
        v: f(x, i, obj)
      };
    });
  };
  var tupleMap = function (obj, f) {
    var r = {};
    each(obj, function (x, i) {
      var tuple = f(x, i, obj);
      r[tuple.k] = tuple.v;
    });
    return r;
  };
  var bifilter = function (obj, pred) {
    var t = {};
    var f = {};
    each(obj, function (x, i) {
      var branch = pred(x, i) ? t : f;
      branch[i] = x;
    });
    return {
      t: t,
      f: f
    };
  };
  var mapToArray = function (obj, f) {
    var r = [];
    each(obj, function (value, name) {
      r.push(f(value, name));
    });
    return r;
  };
  var find = function (obj, pred) {
    var props = keys(obj);
    for (var k = 0, len = props.length; k < len; k++) {
      var i = props[k];
      var x = obj[i];
      if (pred(x, i, obj)) {
        return Option.some(x);
      }
    }
    return Option.none();
  };
  var values = function (obj) {
    return mapToArray(obj, function (v) {
      return v;
    });
  };
  var size = function (obj) {
    return values(obj).length;
  };
  var $_8qu224wzjfuw8tb9 = {
    bifilter: bifilter,
    each: each,
    map: objectMap,
    mapToArray: mapToArray,
    tupleMap: tupleMap,
    find: find,
    keys: keys,
    values: values,
    size: size
  };

  var contextmenu = $_2vokfcwwjfuw8tb4.constant('contextmenu');
  var touchstart = $_2vokfcwwjfuw8tb4.constant('touchstart');
  var touchmove = $_2vokfcwwjfuw8tb4.constant('touchmove');
  var touchend = $_2vokfcwwjfuw8tb4.constant('touchend');
  var gesturestart = $_2vokfcwwjfuw8tb4.constant('gesturestart');
  var mousedown = $_2vokfcwwjfuw8tb4.constant('mousedown');
  var mousemove = $_2vokfcwwjfuw8tb4.constant('mousemove');
  var mouseout = $_2vokfcwwjfuw8tb4.constant('mouseout');
  var mouseup = $_2vokfcwwjfuw8tb4.constant('mouseup');
  var mouseover = $_2vokfcwwjfuw8tb4.constant('mouseover');
  var focusin = $_2vokfcwwjfuw8tb4.constant('focusin');
  var keydown = $_2vokfcwwjfuw8tb4.constant('keydown');
  var input = $_2vokfcwwjfuw8tb4.constant('input');
  var change = $_2vokfcwwjfuw8tb4.constant('change');
  var focus = $_2vokfcwwjfuw8tb4.constant('focus');
  var click = $_2vokfcwwjfuw8tb4.constant('click');
  var transitionend = $_2vokfcwwjfuw8tb4.constant('transitionend');
  var selectstart = $_2vokfcwwjfuw8tb4.constant('selectstart');

  var cached = function (f) {
    var called = false;
    var r;
    return function () {
      if (!called) {
        called = true;
        r = f.apply(null, arguments);
      }
      return r;
    };
  };
  var $_ctj1zwx4jfuw8tbw = { cached: cached };

  var firstMatch = function (regexes, s) {
    for (var i = 0; i < regexes.length; i++) {
      var x = regexes[i];
      if (x.test(s))
        return x;
    }
    return undefined;
  };
  var find$1 = function (regexes, agent) {
    var r = firstMatch(regexes, agent);
    if (!r)
      return {
        major: 0,
        minor: 0
      };
    var group = function (i) {
      return Number(agent.replace(r, '$' + i));
    };
    return nu(group(1), group(2));
  };
  var detect = function (versionRegexes, agent) {
    var cleanedAgent = String(agent).toLowerCase();
    if (versionRegexes.length === 0)
      return unknown();
    return find$1(versionRegexes, cleanedAgent);
  };
  var unknown = function () {
    return nu(0, 0);
  };
  var nu = function (major, minor) {
    return {
      major: major,
      minor: minor
    };
  };
  var $_f9maalx7jfuw8tc7 = {
    nu: nu,
    detect: detect,
    unknown: unknown
  };

  var edge = 'Edge';
  var chrome = 'Chrome';
  var ie = 'IE';
  var opera = 'Opera';
  var firefox = 'Firefox';
  var safari = 'Safari';
  var isBrowser = function (name, current) {
    return function () {
      return current === name;
    };
  };
  var unknown$1 = function () {
    return nu$1({
      current: undefined,
      version: $_f9maalx7jfuw8tc7.unknown()
    });
  };
  var nu$1 = function (info) {
    var current = info.current;
    var version = info.version;
    return {
      current: current,
      version: version,
      isEdge: isBrowser(edge, current),
      isChrome: isBrowser(chrome, current),
      isIE: isBrowser(ie, current),
      isOpera: isBrowser(opera, current),
      isFirefox: isBrowser(firefox, current),
      isSafari: isBrowser(safari, current)
    };
  };
  var $_3i1kz1x6jfuw8tc4 = {
    unknown: unknown$1,
    nu: nu$1,
    edge: $_2vokfcwwjfuw8tb4.constant(edge),
    chrome: $_2vokfcwwjfuw8tb4.constant(chrome),
    ie: $_2vokfcwwjfuw8tb4.constant(ie),
    opera: $_2vokfcwwjfuw8tb4.constant(opera),
    firefox: $_2vokfcwwjfuw8tb4.constant(firefox),
    safari: $_2vokfcwwjfuw8tb4.constant(safari)
  };

  var windows = 'Windows';
  var ios = 'iOS';
  var android = 'Android';
  var linux = 'Linux';
  var osx = 'OSX';
  var solaris = 'Solaris';
  var freebsd = 'FreeBSD';
  var isOS = function (name, current) {
    return function () {
      return current === name;
    };
  };
  var unknown$2 = function () {
    return nu$2({
      current: undefined,
      version: $_f9maalx7jfuw8tc7.unknown()
    });
  };
  var nu$2 = function (info) {
    var current = info.current;
    var version = info.version;
    return {
      current: current,
      version: version,
      isWindows: isOS(windows, current),
      isiOS: isOS(ios, current),
      isAndroid: isOS(android, current),
      isOSX: isOS(osx, current),
      isLinux: isOS(linux, current),
      isSolaris: isOS(solaris, current),
      isFreeBSD: isOS(freebsd, current)
    };
  };
  var $_5birgjx8jfuw8tc9 = {
    unknown: unknown$2,
    nu: nu$2,
    windows: $_2vokfcwwjfuw8tb4.constant(windows),
    ios: $_2vokfcwwjfuw8tb4.constant(ios),
    android: $_2vokfcwwjfuw8tb4.constant(android),
    linux: $_2vokfcwwjfuw8tb4.constant(linux),
    osx: $_2vokfcwwjfuw8tb4.constant(osx),
    solaris: $_2vokfcwwjfuw8tb4.constant(solaris),
    freebsd: $_2vokfcwwjfuw8tb4.constant(freebsd)
  };

  function DeviceType (os, browser, userAgent) {
    var isiPad = os.isiOS() && /ipad/i.test(userAgent) === true;
    var isiPhone = os.isiOS() && !isiPad;
    var isAndroid3 = os.isAndroid() && os.version.major === 3;
    var isAndroid4 = os.isAndroid() && os.version.major === 4;
    var isTablet = isiPad || isAndroid3 || isAndroid4 && /mobile/i.test(userAgent) === true;
    var isTouch = os.isiOS() || os.isAndroid();
    var isPhone = isTouch && !isTablet;
    var iOSwebview = browser.isSafari() && os.isiOS() && /safari/i.test(userAgent) === false;
    return {
      isiPad: $_2vokfcwwjfuw8tb4.constant(isiPad),
      isiPhone: $_2vokfcwwjfuw8tb4.constant(isiPhone),
      isTablet: $_2vokfcwwjfuw8tb4.constant(isTablet),
      isPhone: $_2vokfcwwjfuw8tb4.constant(isPhone),
      isTouch: $_2vokfcwwjfuw8tb4.constant(isTouch),
      isAndroid: os.isAndroid,
      isiOS: os.isiOS,
      isWebView: $_2vokfcwwjfuw8tb4.constant(iOSwebview)
    };
  }

  var rawIndexOf = function () {
    var pIndexOf = Array.prototype.indexOf;
    var fastIndex = function (xs, x) {
      return pIndexOf.call(xs, x);
    };
    var slowIndex = function (xs, x) {
      return slowIndexOf(xs, x);
    };
    return pIndexOf === undefined ? slowIndex : fastIndex;
  }();
  var indexOf = function (xs, x) {
    var r = rawIndexOf(xs, x);
    return r === -1 ? Option.none() : Option.some(r);
  };
  var contains = function (xs, x) {
    return rawIndexOf(xs, x) > -1;
  };
  var exists = function (xs, pred) {
    return findIndex(xs, pred).isSome();
  };
  var range = function (num, f) {
    var r = [];
    for (var i = 0; i < num; i++) {
      r.push(f(i));
    }
    return r;
  };
  var chunk = function (array, size) {
    var r = [];
    for (var i = 0; i < array.length; i += size) {
      var s = array.slice(i, i + size);
      r.push(s);
    }
    return r;
  };
  var map = function (xs, f) {
    var len = xs.length;
    var r = new Array(len);
    for (var i = 0; i < len; i++) {
      var x = xs[i];
      r[i] = f(x, i, xs);
    }
    return r;
  };
  var each$1 = function (xs, f) {
    for (var i = 0, len = xs.length; i < len; i++) {
      var x = xs[i];
      f(x, i, xs);
    }
  };
  var eachr = function (xs, f) {
    for (var i = xs.length - 1; i >= 0; i--) {
      var x = xs[i];
      f(x, i, xs);
    }
  };
  var partition = function (xs, pred) {
    var pass = [];
    var fail = [];
    for (var i = 0, len = xs.length; i < len; i++) {
      var x = xs[i];
      var arr = pred(x, i, xs) ? pass : fail;
      arr.push(x);
    }
    return {
      pass: pass,
      fail: fail
    };
  };
  var filter = function (xs, pred) {
    var r = [];
    for (var i = 0, len = xs.length; i < len; i++) {
      var x = xs[i];
      if (pred(x, i, xs)) {
        r.push(x);
      }
    }
    return r;
  };
  var groupBy = function (xs, f) {
    if (xs.length === 0) {
      return [];
    } else {
      var wasType = f(xs[0]);
      var r = [];
      var group = [];
      for (var i = 0, len = xs.length; i < len; i++) {
        var x = xs[i];
        var type = f(x);
        if (type !== wasType) {
          r.push(group);
          group = [];
        }
        wasType = type;
        group.push(x);
      }
      if (group.length !== 0) {
        r.push(group);
      }
      return r;
    }
  };
  var foldr = function (xs, f, acc) {
    eachr(xs, function (x) {
      acc = f(acc, x);
    });
    return acc;
  };
  var foldl = function (xs, f, acc) {
    each$1(xs, function (x) {
      acc = f(acc, x);
    });
    return acc;
  };
  var find$2 = function (xs, pred) {
    for (var i = 0, len = xs.length; i < len; i++) {
      var x = xs[i];
      if (pred(x, i, xs)) {
        return Option.some(x);
      }
    }
    return Option.none();
  };
  var findIndex = function (xs, pred) {
    for (var i = 0, len = xs.length; i < len; i++) {
      var x = xs[i];
      if (pred(x, i, xs)) {
        return Option.some(i);
      }
    }
    return Option.none();
  };
  var slowIndexOf = function (xs, x) {
    for (var i = 0, len = xs.length; i < len; ++i) {
      if (xs[i] === x) {
        return i;
      }
    }
    return -1;
  };
  var push = Array.prototype.push;
  var flatten = function (xs) {
    var r = [];
    for (var i = 0, len = xs.length; i < len; ++i) {
      if (!Array.prototype.isPrototypeOf(xs[i]))
        throw new Error('Arr.flatten item ' + i + ' was not an array, input: ' + xs);
      push.apply(r, xs[i]);
    }
    return r;
  };
  var bind = function (xs, f) {
    var output = map(xs, f);
    return flatten(output);
  };
  var forall = function (xs, pred) {
    for (var i = 0, len = xs.length; i < len; ++i) {
      var x = xs[i];
      if (pred(x, i, xs) !== true) {
        return false;
      }
    }
    return true;
  };
  var equal = function (a1, a2) {
    return a1.length === a2.length && forall(a1, function (x, i) {
      return x === a2[i];
    });
  };
  var slice = Array.prototype.slice;
  var reverse = function (xs) {
    var r = slice.call(xs, 0);
    r.reverse();
    return r;
  };
  var difference = function (a1, a2) {
    return filter(a1, function (x) {
      return !contains(a2, x);
    });
  };
  var mapToObject = function (xs, f) {
    var r = {};
    for (var i = 0, len = xs.length; i < len; i++) {
      var x = xs[i];
      r[String(x)] = f(x, i);
    }
    return r;
  };
  var pure = function (x) {
    return [x];
  };
  var sort = function (xs, comparator) {
    var copy = slice.call(xs, 0);
    copy.sort(comparator);
    return copy;
  };
  var head = function (xs) {
    return xs.length === 0 ? Option.none() : Option.some(xs[0]);
  };
  var last = function (xs) {
    return xs.length === 0 ? Option.none() : Option.some(xs[xs.length - 1]);
  };
  var from$1 = $_8aqeo3wyjfuw8tb8.isFunction(Array.from) ? Array.from : function (x) {
    return slice.call(x);
  };
  var $_efmt4zxbjfuw8tcj = {
    map: map,
    each: each$1,
    eachr: eachr,
    partition: partition,
    filter: filter,
    groupBy: groupBy,
    indexOf: indexOf,
    foldr: foldr,
    foldl: foldl,
    find: find$2,
    findIndex: findIndex,
    flatten: flatten,
    bind: bind,
    forall: forall,
    exists: exists,
    contains: contains,
    equal: equal,
    reverse: reverse,
    chunk: chunk,
    difference: difference,
    mapToObject: mapToObject,
    pure: pure,
    sort: sort,
    range: range,
    head: head,
    last: last,
    from: from$1
  };

  var detect$1 = function (candidates, userAgent) {
    var agent = String(userAgent).toLowerCase();
    return $_efmt4zxbjfuw8tcj.find(candidates, function (candidate) {
      return candidate.search(agent);
    });
  };
  var detectBrowser = function (browsers, userAgent) {
    return detect$1(browsers, userAgent).map(function (browser) {
      var version = $_f9maalx7jfuw8tc7.detect(browser.versionRegexes, userAgent);
      return {
        current: browser.name,
        version: version
      };
    });
  };
  var detectOs = function (oses, userAgent) {
    return detect$1(oses, userAgent).map(function (os) {
      var version = $_f9maalx7jfuw8tc7.detect(os.versionRegexes, userAgent);
      return {
        current: os.name,
        version: version
      };
    });
  };
  var $_890032xajfuw8tcf = {
    detectBrowser: detectBrowser,
    detectOs: detectOs
  };

  var addToStart = function (str, prefix) {
    return prefix + str;
  };
  var addToEnd = function (str, suffix) {
    return str + suffix;
  };
  var removeFromStart = function (str, numChars) {
    return str.substring(numChars);
  };
  var removeFromEnd = function (str, numChars) {
    return str.substring(0, str.length - numChars);
  };
  var $_frzopdxejfuw8tcx = {
    addToStart: addToStart,
    addToEnd: addToEnd,
    removeFromStart: removeFromStart,
    removeFromEnd: removeFromEnd
  };

  var first = function (str, count) {
    return str.substr(0, count);
  };
  var last$1 = function (str, count) {
    return str.substr(str.length - count, str.length);
  };
  var head$1 = function (str) {
    return str === '' ? Option.none() : Option.some(str.substr(0, 1));
  };
  var tail = function (str) {
    return str === '' ? Option.none() : Option.some(str.substring(1));
  };
  var $_g4g7dwxfjfuw8tcy = {
    first: first,
    last: last$1,
    head: head$1,
    tail: tail
  };

  var checkRange = function (str, substr, start) {
    if (substr === '')
      return true;
    if (str.length < substr.length)
      return false;
    var x = str.substr(start, start + substr.length);
    return x === substr;
  };
  var supplant = function (str, obj) {
    var isStringOrNumber = function (a) {
      var t = typeof a;
      return t === 'string' || t === 'number';
    };
    return str.replace(/\${([^{}]*)}/g, function (a, b) {
      var value = obj[b];
      return isStringOrNumber(value) ? value : a;
    });
  };
  var removeLeading = function (str, prefix) {
    return startsWith(str, prefix) ? $_frzopdxejfuw8tcx.removeFromStart(str, prefix.length) : str;
  };
  var removeTrailing = function (str, prefix) {
    return endsWith(str, prefix) ? $_frzopdxejfuw8tcx.removeFromEnd(str, prefix.length) : str;
  };
  var ensureLeading = function (str, prefix) {
    return startsWith(str, prefix) ? str : $_frzopdxejfuw8tcx.addToStart(str, prefix);
  };
  var ensureTrailing = function (str, prefix) {
    return endsWith(str, prefix) ? str : $_frzopdxejfuw8tcx.addToEnd(str, prefix);
  };
  var contains$1 = function (str, substr) {
    return str.indexOf(substr) !== -1;
  };
  var capitalize = function (str) {
    return $_g4g7dwxfjfuw8tcy.head(str).bind(function (head) {
      return $_g4g7dwxfjfuw8tcy.tail(str).map(function (tail) {
        return head.toUpperCase() + tail;
      });
    }).getOr(str);
  };
  var startsWith = function (str, prefix) {
    return checkRange(str, prefix, 0);
  };
  var endsWith = function (str, suffix) {
    return checkRange(str, suffix, str.length - suffix.length);
  };
  var trim = function (str) {
    return str.replace(/^\s+|\s+$/g, '');
  };
  var lTrim = function (str) {
    return str.replace(/^\s+/g, '');
  };
  var rTrim = function (str) {
    return str.replace(/\s+$/g, '');
  };
  var $_b463kaxdjfuw8tcv = {
    supplant: supplant,
    startsWith: startsWith,
    removeLeading: removeLeading,
    removeTrailing: removeTrailing,
    ensureLeading: ensureLeading,
    ensureTrailing: ensureTrailing,
    endsWith: endsWith,
    contains: contains$1,
    trim: trim,
    lTrim: lTrim,
    rTrim: rTrim,
    capitalize: capitalize
  };

  var normalVersionRegex = /.*?version\/\ ?([0-9]+)\.([0-9]+).*/;
  var checkContains = function (target) {
    return function (uastring) {
      return $_b463kaxdjfuw8tcv.contains(uastring, target);
    };
  };
  var browsers = [
    {
      name: 'Edge',
      versionRegexes: [/.*?edge\/ ?([0-9]+)\.([0-9]+)$/],
      search: function (uastring) {
        var monstrosity = $_b463kaxdjfuw8tcv.contains(uastring, 'edge/') && $_b463kaxdjfuw8tcv.contains(uastring, 'chrome') && $_b463kaxdjfuw8tcv.contains(uastring, 'safari') && $_b463kaxdjfuw8tcv.contains(uastring, 'applewebkit');
        return monstrosity;
      }
    },
    {
      name: 'Chrome',
      versionRegexes: [
        /.*?chrome\/([0-9]+)\.([0-9]+).*/,
        normalVersionRegex
      ],
      search: function (uastring) {
        return $_b463kaxdjfuw8tcv.contains(uastring, 'chrome') && !$_b463kaxdjfuw8tcv.contains(uastring, 'chromeframe');
      }
    },
    {
      name: 'IE',
      versionRegexes: [
        /.*?msie\ ?([0-9]+)\.([0-9]+).*/,
        /.*?rv:([0-9]+)\.([0-9]+).*/
      ],
      search: function (uastring) {
        return $_b463kaxdjfuw8tcv.contains(uastring, 'msie') || $_b463kaxdjfuw8tcv.contains(uastring, 'trident');
      }
    },
    {
      name: 'Opera',
      versionRegexes: [
        normalVersionRegex,
        /.*?opera\/([0-9]+)\.([0-9]+).*/
      ],
      search: checkContains('opera')
    },
    {
      name: 'Firefox',
      versionRegexes: [/.*?firefox\/\ ?([0-9]+)\.([0-9]+).*/],
      search: checkContains('firefox')
    },
    {
      name: 'Safari',
      versionRegexes: [
        normalVersionRegex,
        /.*?cpu os ([0-9]+)_([0-9]+).*/
      ],
      search: function (uastring) {
        return ($_b463kaxdjfuw8tcv.contains(uastring, 'safari') || $_b463kaxdjfuw8tcv.contains(uastring, 'mobile/')) && $_b463kaxdjfuw8tcv.contains(uastring, 'applewebkit');
      }
    }
  ];
  var oses = [
    {
      name: 'Windows',
      search: checkContains('win'),
      versionRegexes: [/.*?windows\ nt\ ?([0-9]+)\.([0-9]+).*/]
    },
    {
      name: 'iOS',
      search: function (uastring) {
        return $_b463kaxdjfuw8tcv.contains(uastring, 'iphone') || $_b463kaxdjfuw8tcv.contains(uastring, 'ipad');
      },
      versionRegexes: [
        /.*?version\/\ ?([0-9]+)\.([0-9]+).*/,
        /.*cpu os ([0-9]+)_([0-9]+).*/,
        /.*cpu iphone os ([0-9]+)_([0-9]+).*/
      ]
    },
    {
      name: 'Android',
      search: checkContains('android'),
      versionRegexes: [/.*?android\ ?([0-9]+)\.([0-9]+).*/]
    },
    {
      name: 'OSX',
      search: checkContains('os x'),
      versionRegexes: [/.*?os\ x\ ?([0-9]+)_([0-9]+).*/]
    },
    {
      name: 'Linux',
      search: checkContains('linux'),
      versionRegexes: []
    },
    {
      name: 'Solaris',
      search: checkContains('sunos'),
      versionRegexes: []
    },
    {
      name: 'FreeBSD',
      search: checkContains('freebsd'),
      versionRegexes: []
    }
  ];
  var $_dv3nc1xcjfuw8tcp = {
    browsers: $_2vokfcwwjfuw8tb4.constant(browsers),
    oses: $_2vokfcwwjfuw8tb4.constant(oses)
  };

  var detect$2 = function (userAgent) {
    var browsers = $_dv3nc1xcjfuw8tcp.browsers();
    var oses = $_dv3nc1xcjfuw8tcp.oses();
    var browser = $_890032xajfuw8tcf.detectBrowser(browsers, userAgent).fold($_3i1kz1x6jfuw8tc4.unknown, $_3i1kz1x6jfuw8tc4.nu);
    var os = $_890032xajfuw8tcf.detectOs(oses, userAgent).fold($_5birgjx8jfuw8tc9.unknown, $_5birgjx8jfuw8tc9.nu);
    var deviceType = DeviceType(os, browser, userAgent);
    return {
      browser: browser,
      os: os,
      deviceType: deviceType
    };
  };
  var $_d4qyxjx5jfuw8tc3 = { detect: detect$2 };

  var detect$3 = $_ctj1zwx4jfuw8tbw.cached(function () {
    var userAgent = navigator.userAgent;
    return $_d4qyxjx5jfuw8tc3.detect(userAgent);
  });
  var $_5reqwox3jfuw8tbu = { detect: detect$3 };

  var alloy = { tap: $_2vokfcwwjfuw8tb4.constant('alloy.tap') };
  var focus$1 = $_2vokfcwwjfuw8tb4.constant('alloy.focus');
  var postBlur = $_2vokfcwwjfuw8tb4.constant('alloy.blur.post');
  var receive = $_2vokfcwwjfuw8tb4.constant('alloy.receive');
  var execute = $_2vokfcwwjfuw8tb4.constant('alloy.execute');
  var focusItem = $_2vokfcwwjfuw8tb4.constant('alloy.focus.item');
  var tap = alloy.tap;
  var tapOrClick = $_5reqwox3jfuw8tbu.detect().deviceType.isTouch() ? alloy.tap : click;
  var longpress = $_2vokfcwwjfuw8tb4.constant('alloy.longpress');
  var sandboxClose = $_2vokfcwwjfuw8tb4.constant('alloy.sandbox.close');
  var systemInit = $_2vokfcwwjfuw8tb4.constant('alloy.system.init');
  var windowScroll = $_2vokfcwwjfuw8tb4.constant('alloy.system.scroll');
  var attachedToDom = $_2vokfcwwjfuw8tb4.constant('alloy.system.attached');
  var detachedFromDom = $_2vokfcwwjfuw8tb4.constant('alloy.system.detached');
  var changeTab = $_2vokfcwwjfuw8tb4.constant('alloy.change.tab');
  var dismissTab = $_2vokfcwwjfuw8tb4.constant('alloy.dismiss.tab');

  var emit = function (component, event) {
    dispatchWith(component, component.element(), event, {});
  };
  var emitWith = function (component, event, properties) {
    dispatchWith(component, component.element(), event, properties);
  };
  var emitExecute = function (component) {
    emit(component, execute());
  };
  var dispatch = function (component, target, event) {
    dispatchWith(component, target, event, {});
  };
  var dispatchWith = function (component, target, event, properties) {
    var data = $_3jctjywxjfuw8tb6.deepMerge({ target: target }, properties);
    component.getSystem().triggerEvent(event, target, $_8qu224wzjfuw8tb9.map(data, $_2vokfcwwjfuw8tb4.constant));
  };
  var dispatchEvent = function (component, target, event, simulatedEvent) {
    component.getSystem().triggerEvent(event, target, simulatedEvent.event());
  };
  var dispatchFocus = function (component, target) {
    component.getSystem().triggerFocus(target, component.element());
  };

  var fromHtml = function (html, scope) {
    var doc = scope || document;
    var div = doc.createElement('div');
    div.innerHTML = html;
    if (!div.hasChildNodes() || div.childNodes.length > 1) {
      console.error('HTML does not have a single root node', html);
      throw 'HTML must have a single root node';
    }
    return fromDom(div.childNodes[0]);
  };
  var fromTag = function (tag, scope) {
    var doc = scope || document;
    var node = doc.createElement(tag);
    return fromDom(node);
  };
  var fromText = function (text, scope) {
    var doc = scope || document;
    var node = doc.createTextNode(text);
    return fromDom(node);
  };
  var fromDom = function (node) {
    if (node === null || node === undefined)
      throw new Error('Node cannot be null or undefined');
    return { dom: $_2vokfcwwjfuw8tb4.constant(node) };
  };
  var fromPoint = function (doc, x, y) {
    return Option.from(doc.dom().elementFromPoint(x, y)).map(fromDom);
  };
  var $_bwdnu0xijfuw8tdo = {
    fromHtml: fromHtml,
    fromTag: fromTag,
    fromText: fromText,
    fromDom: fromDom,
    fromPoint: fromPoint
  };

  var $_dh9i2rxkjfuw8tdu = {
    ATTRIBUTE: 2,
    CDATA_SECTION: 4,
    COMMENT: 8,
    DOCUMENT: 9,
    DOCUMENT_TYPE: 10,
    DOCUMENT_FRAGMENT: 11,
    ELEMENT: 1,
    TEXT: 3,
    PROCESSING_INSTRUCTION: 7,
    ENTITY_REFERENCE: 5,
    ENTITY: 6,
    NOTATION: 12
  };

  var name = function (element) {
    var r = element.dom().nodeName;
    return r.toLowerCase();
  };
  var type = function (element) {
    return element.dom().nodeType;
  };
  var value = function (element) {
    return element.dom().nodeValue;
  };
  var isType$1 = function (t) {
    return function (element) {
      return type(element) === t;
    };
  };
  var isComment = function (element) {
    return type(element) === $_dh9i2rxkjfuw8tdu.COMMENT || name(element) === '#comment';
  };
  var isElement = isType$1($_dh9i2rxkjfuw8tdu.ELEMENT);
  var isText = isType$1($_dh9i2rxkjfuw8tdu.TEXT);
  var isDocument = isType$1($_dh9i2rxkjfuw8tdu.DOCUMENT);
  var $_74lhjaxjjfuw8tdt = {
    name: name,
    type: type,
    value: value,
    isElement: isElement,
    isText: isText,
    isDocument: isDocument,
    isComment: isComment
  };

  var inBody = function (element) {
    var dom = $_74lhjaxjjfuw8tdt.isText(element) ? element.dom().parentNode : element.dom();
    return dom !== undefined && dom !== null && dom.ownerDocument.body.contains(dom);
  };
  var body = $_ctj1zwx4jfuw8tbw.cached(function () {
    return getBody($_bwdnu0xijfuw8tdo.fromDom(document));
  });
  var getBody = function (doc) {
    var body = doc.dom().body;
    if (body === null || body === undefined)
      throw 'Body is not available yet';
    return $_bwdnu0xijfuw8tdo.fromDom(body);
  };
  var $_8634tqxhjfuw8tdl = {
    body: body,
    getBody: getBody,
    inBody: inBody
  };

  function Immutable () {
    var fields = [];
    for (var _i = 0; _i < arguments.length; _i++) {
      fields[_i] = arguments[_i];
    }
    return function () {
      var values = [];
      for (var _i = 0; _i < arguments.length; _i++) {
        values[_i] = arguments[_i];
      }
      if (fields.length !== values.length) {
        throw new Error('Wrong number of arguments to struct. Expected "[' + fields.length + ']", got ' + values.length + ' arguments');
      }
      var struct = {};
      $_efmt4zxbjfuw8tcj.each(fields, function (name, i) {
        struct[name] = $_2vokfcwwjfuw8tb4.constant(values[i]);
      });
      return struct;
    };
  }

  var sort$1 = function (arr) {
    return arr.slice(0).sort();
  };
  var reqMessage = function (required, keys) {
    throw new Error('All required keys (' + sort$1(required).join(', ') + ') were not specified. Specified keys were: ' + sort$1(keys).join(', ') + '.');
  };
  var unsuppMessage = function (unsupported) {
    throw new Error('Unsupported keys for object: ' + sort$1(unsupported).join(', '));
  };
  var validateStrArr = function (label, array) {
    if (!$_8aqeo3wyjfuw8tb8.isArray(array))
      throw new Error('The ' + label + ' fields must be an array. Was: ' + array + '.');
    $_efmt4zxbjfuw8tcj.each(array, function (a) {
      if (!$_8aqeo3wyjfuw8tb8.isString(a))
        throw new Error('The value ' + a + ' in the ' + label + ' fields was not a string.');
    });
  };
  var invalidTypeMessage = function (incorrect, type) {
    throw new Error('All values need to be of type: ' + type + '. Keys (' + sort$1(incorrect).join(', ') + ') were not.');
  };
  var checkDupes = function (everything) {
    var sorted = sort$1(everything);
    var dupe = $_efmt4zxbjfuw8tcj.find(sorted, function (s, i) {
      return i < sorted.length - 1 && s === sorted[i + 1];
    });
    dupe.each(function (d) {
      throw new Error('The field: ' + d + ' occurs more than once in the combined fields: [' + sorted.join(', ') + '].');
    });
  };
  var $_fpmdlsxqjfuw8teg = {
    sort: sort$1,
    reqMessage: reqMessage,
    unsuppMessage: unsuppMessage,
    validateStrArr: validateStrArr,
    invalidTypeMessage: invalidTypeMessage,
    checkDupes: checkDupes
  };

  function MixedBag (required, optional) {
    var everything = required.concat(optional);
    if (everything.length === 0)
      throw new Error('You must specify at least one required or optional field.');
    $_fpmdlsxqjfuw8teg.validateStrArr('required', required);
    $_fpmdlsxqjfuw8teg.validateStrArr('optional', optional);
    $_fpmdlsxqjfuw8teg.checkDupes(everything);
    return function (obj) {
      var keys = $_8qu224wzjfuw8tb9.keys(obj);
      var allReqd = $_efmt4zxbjfuw8tcj.forall(required, function (req) {
        return $_efmt4zxbjfuw8tcj.contains(keys, req);
      });
      if (!allReqd)
        $_fpmdlsxqjfuw8teg.reqMessage(required, keys);
      var unsupported = $_efmt4zxbjfuw8tcj.filter(keys, function (key) {
        return !$_efmt4zxbjfuw8tcj.contains(everything, key);
      });
      if (unsupported.length > 0)
        $_fpmdlsxqjfuw8teg.unsuppMessage(unsupported);
      var r = {};
      $_efmt4zxbjfuw8tcj.each(required, function (req) {
        r[req] = $_2vokfcwwjfuw8tb4.constant(obj[req]);
      });
      $_efmt4zxbjfuw8tcj.each(optional, function (opt) {
        r[opt] = $_2vokfcwwjfuw8tb4.constant(Object.prototype.hasOwnProperty.call(obj, opt) ? Option.some(obj[opt]) : Option.none());
      });
      return r;
    };
  }

  var $_4xhupwxnjfuw8tea = {
    immutable: Immutable,
    immutableBag: MixedBag
  };

  var toArray = function (target, f) {
    var r = [];
    var recurse = function (e) {
      r.push(e);
      return f(e);
    };
    var cur = f(target);
    do {
      cur = cur.bind(recurse);
    } while (cur.isSome());
    return r;
  };
  var $_e6izy8xrjfuw8tei = { toArray: toArray };

  var global = typeof window !== 'undefined' ? window : Function('return this;')();

  var path = function (parts, scope) {
    var o = scope !== undefined && scope !== null ? scope : global;
    for (var i = 0; i < parts.length && o !== undefined && o !== null; ++i)
      o = o[parts[i]];
    return o;
  };
  var resolve = function (p, scope) {
    var parts = p.split('.');
    return path(parts, scope);
  };
  var step = function (o, part) {
    if (o[part] === undefined || o[part] === null)
      o[part] = {};
    return o[part];
  };
  var forge = function (parts, target) {
    var o = target !== undefined ? target : global;
    for (var i = 0; i < parts.length; ++i)
      o = step(o, parts[i]);
    return o;
  };
  var namespace = function (name, target) {
    var parts = name.split('.');
    return forge(parts, target);
  };
  var $_15p0q3xvjfuw8tew = {
    path: path,
    resolve: resolve,
    forge: forge,
    namespace: namespace
  };

  var unsafe = function (name, scope) {
    return $_15p0q3xvjfuw8tew.resolve(name, scope);
  };
  var getOrDie = function (name, scope) {
    var actual = unsafe(name, scope);
    if (actual === undefined || actual === null)
      throw name + ' not available on this browser';
    return actual;
  };
  var $_dxyj33xujfuw8tet = { getOrDie: getOrDie };

  var node = function () {
    var f = $_dxyj33xujfuw8tet.getOrDie('Node');
    return f;
  };
  var compareDocumentPosition = function (a, b, match) {
    return (a.compareDocumentPosition(b) & match) !== 0;
  };
  var documentPositionPreceding = function (a, b) {
    return compareDocumentPosition(a, b, node().DOCUMENT_POSITION_PRECEDING);
  };
  var documentPositionContainedBy = function (a, b) {
    return compareDocumentPosition(a, b, node().DOCUMENT_POSITION_CONTAINED_BY);
  };
  var $_c0dwknxtjfuw8tes = {
    documentPositionPreceding: documentPositionPreceding,
    documentPositionContainedBy: documentPositionContainedBy
  };

  var ELEMENT = $_dh9i2rxkjfuw8tdu.ELEMENT;
  var DOCUMENT = $_dh9i2rxkjfuw8tdu.DOCUMENT;
  var is = function (element, selector) {
    var elem = element.dom();
    if (elem.nodeType !== ELEMENT)
      return false;
    else if (elem.matches !== undefined)
      return elem.matches(selector);
    else if (elem.msMatchesSelector !== undefined)
      return elem.msMatchesSelector(selector);
    else if (elem.webkitMatchesSelector !== undefined)
      return elem.webkitMatchesSelector(selector);
    else if (elem.mozMatchesSelector !== undefined)
      return elem.mozMatchesSelector(selector);
    else
      throw new Error('Browser lacks native selectors');
  };
  var bypassSelector = function (dom) {
    return dom.nodeType !== ELEMENT && dom.nodeType !== DOCUMENT || dom.childElementCount === 0;
  };
  var all = function (selector, scope) {
    var base = scope === undefined ? document : scope.dom();
    return bypassSelector(base) ? [] : $_efmt4zxbjfuw8tcj.map(base.querySelectorAll(selector), $_bwdnu0xijfuw8tdo.fromDom);
  };
  var one = function (selector, scope) {
    var base = scope === undefined ? document : scope.dom();
    return bypassSelector(base) ? Option.none() : Option.from(base.querySelector(selector)).map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var $_gem9gixxjfuw8tey = {
    all: all,
    is: is,
    one: one
  };

  var eq = function (e1, e2) {
    return e1.dom() === e2.dom();
  };
  var isEqualNode = function (e1, e2) {
    return e1.dom().isEqualNode(e2.dom());
  };
  var member = function (element, elements) {
    return $_efmt4zxbjfuw8tcj.exists(elements, $_2vokfcwwjfuw8tb4.curry(eq, element));
  };
  var regularContains = function (e1, e2) {
    var d1 = e1.dom(), d2 = e2.dom();
    return d1 === d2 ? false : d1.contains(d2);
  };
  var ieContains = function (e1, e2) {
    return $_c0dwknxtjfuw8tes.documentPositionContainedBy(e1.dom(), e2.dom());
  };
  var browser = $_5reqwox3jfuw8tbu.detect().browser;
  var contains$2 = browser.isIE() ? ieContains : regularContains;
  var $_4867a0xsjfuw8tej = {
    eq: eq,
    isEqualNode: isEqualNode,
    member: member,
    contains: contains$2,
    is: $_gem9gixxjfuw8tey.is
  };

  var owner = function (element) {
    return $_bwdnu0xijfuw8tdo.fromDom(element.dom().ownerDocument);
  };
  var documentElement = function (element) {
    var doc = owner(element);
    return $_bwdnu0xijfuw8tdo.fromDom(doc.dom().documentElement);
  };
  var defaultView = function (element) {
    var el = element.dom();
    var defaultView = el.ownerDocument.defaultView;
    return $_bwdnu0xijfuw8tdo.fromDom(defaultView);
  };
  var parent = function (element) {
    var dom = element.dom();
    return Option.from(dom.parentNode).map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var findIndex$1 = function (element) {
    return parent(element).bind(function (p) {
      var kin = children(p);
      return $_efmt4zxbjfuw8tcj.findIndex(kin, function (elem) {
        return $_4867a0xsjfuw8tej.eq(element, elem);
      });
    });
  };
  var parents = function (element, isRoot) {
    var stop = $_8aqeo3wyjfuw8tb8.isFunction(isRoot) ? isRoot : $_2vokfcwwjfuw8tb4.constant(false);
    var dom = element.dom();
    var ret = [];
    while (dom.parentNode !== null && dom.parentNode !== undefined) {
      var rawParent = dom.parentNode;
      var parent = $_bwdnu0xijfuw8tdo.fromDom(rawParent);
      ret.push(parent);
      if (stop(parent) === true)
        break;
      else
        dom = rawParent;
    }
    return ret;
  };
  var siblings = function (element) {
    var filterSelf = function (elements) {
      return $_efmt4zxbjfuw8tcj.filter(elements, function (x) {
        return !$_4867a0xsjfuw8tej.eq(element, x);
      });
    };
    return parent(element).map(children).map(filterSelf).getOr([]);
  };
  var offsetParent = function (element) {
    var dom = element.dom();
    return Option.from(dom.offsetParent).map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var prevSibling = function (element) {
    var dom = element.dom();
    return Option.from(dom.previousSibling).map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var nextSibling = function (element) {
    var dom = element.dom();
    return Option.from(dom.nextSibling).map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var prevSiblings = function (element) {
    return $_efmt4zxbjfuw8tcj.reverse($_e6izy8xrjfuw8tei.toArray(element, prevSibling));
  };
  var nextSiblings = function (element) {
    return $_e6izy8xrjfuw8tei.toArray(element, nextSibling);
  };
  var children = function (element) {
    var dom = element.dom();
    return $_efmt4zxbjfuw8tcj.map(dom.childNodes, $_bwdnu0xijfuw8tdo.fromDom);
  };
  var child = function (element, index) {
    var children = element.dom().childNodes;
    return Option.from(children[index]).map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var firstChild = function (element) {
    return child(element, 0);
  };
  var lastChild = function (element) {
    return child(element, element.dom().childNodes.length - 1);
  };
  var childNodesCount = function (element) {
    return element.dom().childNodes.length;
  };
  var hasChildNodes = function (element) {
    return element.dom().hasChildNodes();
  };
  var spot = $_4xhupwxnjfuw8tea.immutable('element', 'offset');
  var leaf = function (element, offset) {
    var cs = children(element);
    return cs.length > 0 && offset < cs.length ? spot(cs[offset], 0) : spot(element, offset);
  };
  var $_aff64dxmjfuw8tdx = {
    owner: owner,
    defaultView: defaultView,
    documentElement: documentElement,
    parent: parent,
    findIndex: findIndex$1,
    parents: parents,
    siblings: siblings,
    prevSibling: prevSibling,
    offsetParent: offsetParent,
    prevSiblings: prevSiblings,
    nextSibling: nextSibling,
    nextSiblings: nextSiblings,
    children: children,
    child: child,
    firstChild: firstChild,
    lastChild: lastChild,
    childNodesCount: childNodesCount,
    hasChildNodes: hasChildNodes,
    leaf: leaf
  };

  var before = function (marker, element) {
    var parent = $_aff64dxmjfuw8tdx.parent(marker);
    parent.each(function (v) {
      v.dom().insertBefore(element.dom(), marker.dom());
    });
  };
  var after = function (marker, element) {
    var sibling = $_aff64dxmjfuw8tdx.nextSibling(marker);
    sibling.fold(function () {
      var parent = $_aff64dxmjfuw8tdx.parent(marker);
      parent.each(function (v) {
        append(v, element);
      });
    }, function (v) {
      before(v, element);
    });
  };
  var prepend = function (parent, element) {
    var firstChild = $_aff64dxmjfuw8tdx.firstChild(parent);
    firstChild.fold(function () {
      append(parent, element);
    }, function (v) {
      parent.dom().insertBefore(element.dom(), v.dom());
    });
  };
  var append = function (parent, element) {
    parent.dom().appendChild(element.dom());
  };
  var appendAt = function (parent, element, index) {
    $_aff64dxmjfuw8tdx.child(parent, index).fold(function () {
      append(parent, element);
    }, function (v) {
      before(v, element);
    });
  };
  var wrap = function (element, wrapper) {
    before(element, wrapper);
    append(wrapper, element);
  };
  var $_cwa5ncxljfuw8tdv = {
    before: before,
    after: after,
    prepend: prepend,
    append: append,
    appendAt: appendAt,
    wrap: wrap
  };

  var before$1 = function (marker, elements) {
    $_efmt4zxbjfuw8tcj.each(elements, function (x) {
      $_cwa5ncxljfuw8tdv.before(marker, x);
    });
  };
  var after$1 = function (marker, elements) {
    $_efmt4zxbjfuw8tcj.each(elements, function (x, i) {
      var e = i === 0 ? marker : elements[i - 1];
      $_cwa5ncxljfuw8tdv.after(e, x);
    });
  };
  var prepend$1 = function (parent, elements) {
    $_efmt4zxbjfuw8tcj.each(elements.slice().reverse(), function (x) {
      $_cwa5ncxljfuw8tdv.prepend(parent, x);
    });
  };
  var append$1 = function (parent, elements) {
    $_efmt4zxbjfuw8tcj.each(elements, function (x) {
      $_cwa5ncxljfuw8tdv.append(parent, x);
    });
  };
  var $_g8n2ewxzjfuw8tf7 = {
    before: before$1,
    after: after$1,
    prepend: prepend$1,
    append: append$1
  };

  var empty = function (element) {
    element.dom().textContent = '';
    $_efmt4zxbjfuw8tcj.each($_aff64dxmjfuw8tdx.children(element), function (rogue) {
      remove(rogue);
    });
  };
  var remove = function (element) {
    var dom = element.dom();
    if (dom.parentNode !== null)
      dom.parentNode.removeChild(dom);
  };
  var unwrap = function (wrapper) {
    var children = $_aff64dxmjfuw8tdx.children(wrapper);
    if (children.length > 0)
      $_g8n2ewxzjfuw8tf7.before(wrapper, children);
    remove(wrapper);
  };
  var $_138z6jxyjfuw8tf4 = {
    empty: empty,
    remove: remove,
    unwrap: unwrap
  };

  var fireDetaching = function (component) {
    emit(component, detachedFromDom());
    var children = component.components();
    $_efmt4zxbjfuw8tcj.each(children, fireDetaching);
  };
  var fireAttaching = function (component) {
    var children = component.components();
    $_efmt4zxbjfuw8tcj.each(children, fireAttaching);
    emit(component, attachedToDom());
  };
  var attach = function (parent, child) {
    attachWith(parent, child, $_cwa5ncxljfuw8tdv.append);
  };
  var attachWith = function (parent, child, insertion) {
    parent.getSystem().addToWorld(child);
    insertion(parent.element(), child.element());
    if ($_8634tqxhjfuw8tdl.inBody(parent.element())) {
      fireAttaching(child);
    }
    parent.syncComponents();
  };
  var doDetach = function (component) {
    fireDetaching(component);
    $_138z6jxyjfuw8tf4.remove(component.element());
    component.getSystem().removeFromWorld(component);
  };
  var detach = function (component) {
    var parent = $_aff64dxmjfuw8tdx.parent(component.element()).bind(function (p) {
      return component.getSystem().getByDom(p).fold(Option.none, Option.some);
    });
    doDetach(component);
    parent.each(function (p) {
      p.syncComponents();
    });
  };
  var detachChildren = function (component) {
    var subs = component.components();
    $_efmt4zxbjfuw8tcj.each(subs, doDetach);
    $_138z6jxyjfuw8tf4.empty(component.element());
    component.syncComponents();
  };
  var attachSystem = function (element, guiSystem) {
    $_cwa5ncxljfuw8tdv.append(element, guiSystem.element());
    var children = $_aff64dxmjfuw8tdx.children(guiSystem.element());
    $_efmt4zxbjfuw8tcj.each(children, function (child) {
      guiSystem.getByDom(child).each(fireAttaching);
    });
  };

  var value$1 = function (o) {
    var is = function (v) {
      return o === v;
    };
    var or = function (opt) {
      return value$1(o);
    };
    var orThunk = function (f) {
      return value$1(o);
    };
    var map = function (f) {
      return value$1(f(o));
    };
    var each = function (f) {
      f(o);
    };
    var bind = function (f) {
      return f(o);
    };
    var fold = function (_, onValue) {
      return onValue(o);
    };
    var exists = function (f) {
      return f(o);
    };
    var forall = function (f) {
      return f(o);
    };
    var toOption = function () {
      return Option.some(o);
    };
    return {
      is: is,
      isValue: $_2vokfcwwjfuw8tb4.always,
      isError: $_2vokfcwwjfuw8tb4.never,
      getOr: $_2vokfcwwjfuw8tb4.constant(o),
      getOrThunk: $_2vokfcwwjfuw8tb4.constant(o),
      getOrDie: $_2vokfcwwjfuw8tb4.constant(o),
      or: or,
      orThunk: orThunk,
      fold: fold,
      map: map,
      each: each,
      bind: bind,
      exists: exists,
      forall: forall,
      toOption: toOption
    };
  };
  var error = function (message) {
    var getOrThunk = function (f) {
      return f();
    };
    var getOrDie = function () {
      return $_2vokfcwwjfuw8tb4.die(String(message))();
    };
    var or = function (opt) {
      return opt;
    };
    var orThunk = function (f) {
      return f();
    };
    var map = function (f) {
      return error(message);
    };
    var bind = function (f) {
      return error(message);
    };
    var fold = function (onError, _) {
      return onError(message);
    };
    return {
      is: $_2vokfcwwjfuw8tb4.never,
      isValue: $_2vokfcwwjfuw8tb4.never,
      isError: $_2vokfcwwjfuw8tb4.always,
      getOr: $_2vokfcwwjfuw8tb4.identity,
      getOrThunk: getOrThunk,
      getOrDie: getOrDie,
      or: or,
      orThunk: orThunk,
      fold: fold,
      map: map,
      each: $_2vokfcwwjfuw8tb4.noop,
      bind: bind,
      exists: $_2vokfcwwjfuw8tb4.never,
      forall: $_2vokfcwwjfuw8tb4.always,
      toOption: Option.none
    };
  };
  var Result = {
    value: value$1,
    error: error
  };

  var generate = function (cases) {
    if (!$_8aqeo3wyjfuw8tb8.isArray(cases)) {
      throw new Error('cases must be an array');
    }
    if (cases.length === 0) {
      throw new Error('there must be at least one case');
    }
    var constructors = [];
    var adt = {};
    $_efmt4zxbjfuw8tcj.each(cases, function (acase, count) {
      var keys = $_8qu224wzjfuw8tb9.keys(acase);
      if (keys.length !== 1) {
        throw new Error('one and only one name per case');
      }
      var key = keys[0];
      var value = acase[key];
      if (adt[key] !== undefined) {
        throw new Error('duplicate key detected:' + key);
      } else if (key === 'cata') {
        throw new Error('cannot have a case named cata (sorry)');
      } else if (!$_8aqeo3wyjfuw8tb8.isArray(value)) {
        throw new Error('case arguments must be an array');
      }
      constructors.push(key);
      adt[key] = function () {
        var argLength = arguments.length;
        if (argLength !== value.length) {
          throw new Error('Wrong number of arguments to case ' + key + '. Expected ' + value.length + ' (' + value + '), got ' + argLength);
        }
        var args = new Array(argLength);
        for (var i = 0; i < args.length; i++)
          args[i] = arguments[i];
        var match = function (branches) {
          var branchKeys = $_8qu224wzjfuw8tb9.keys(branches);
          if (constructors.length !== branchKeys.length) {
            throw new Error('Wrong number of arguments to match. Expected: ' + constructors.join(',') + '\nActual: ' + branchKeys.join(','));
          }
          var allReqd = $_efmt4zxbjfuw8tcj.forall(constructors, function (reqKey) {
            return $_efmt4zxbjfuw8tcj.contains(branchKeys, reqKey);
          });
          if (!allReqd)
            throw new Error('Not all branches were specified when using match. Specified: ' + branchKeys.join(', ') + '\nRequired: ' + constructors.join(', '));
          return branches[key].apply(null, args);
        };
        return {
          fold: function () {
            if (arguments.length !== cases.length) {
              throw new Error('Wrong number of arguments to fold. Expected ' + cases.length + ', got ' + arguments.length);
            }
            var target = arguments[count];
            return target.apply(null, args);
          },
          match: match,
          log: function (label) {
            console.log(label, {
              constructors: constructors,
              constructor: key,
              params: args
            });
          }
        };
      };
    });
    return adt;
  };
  var $_dldkf4y5jfuw8tgp = { generate: generate };

  var adt = $_dldkf4y5jfuw8tgp.generate([
    { strict: [] },
    { defaultedThunk: ['fallbackThunk'] },
    { asOption: [] },
    { asDefaultedOptionThunk: ['fallbackThunk'] },
    { mergeWithThunk: ['baseThunk'] }
  ]);
  var defaulted = function (fallback) {
    return adt.defaultedThunk($_2vokfcwwjfuw8tb4.constant(fallback));
  };
  var mergeWith = function (base) {
    return adt.mergeWithThunk($_2vokfcwwjfuw8tb4.constant(base));
  };
  var strict = adt.strict;
  var asOption = adt.asOption;
  var defaultedThunk = adt.defaultedThunk;
  var asDefaultedOptionThunk = adt.asDefaultedOptionThunk;
  var mergeWithThunk = adt.mergeWithThunk;

  var comparison = $_dldkf4y5jfuw8tgp.generate([
    {
      bothErrors: [
        'error1',
        'error2'
      ]
    },
    {
      firstError: [
        'error1',
        'value2'
      ]
    },
    {
      secondError: [
        'value1',
        'error2'
      ]
    },
    {
      bothValues: [
        'value1',
        'value2'
      ]
    }
  ]);
  var partition$1 = function (results) {
    var errors = [];
    var values = [];
    $_efmt4zxbjfuw8tcj.each(results, function (result) {
      result.fold(function (err) {
        errors.push(err);
      }, function (value) {
        values.push(value);
      });
    });
    return {
      errors: errors,
      values: values
    };
  };
  var compare = function (result1, result2) {
    return result1.fold(function (err1) {
      return result2.fold(function (err2) {
        return comparison.bothErrors(err1, err2);
      }, function (val2) {
        return comparison.firstError(err1, val2);
      });
    }, function (val1) {
      return result2.fold(function (err2) {
        return comparison.secondError(val1, err2);
      }, function (val2) {
        return comparison.bothValues(val1, val2);
      });
    });
  };
  var $_7v02bqy9jfuw8thf = {
    partition: partition$1,
    compare: compare
  };

  var mergeValues = function (values, base) {
    return Result.value($_3jctjywxjfuw8tb6.deepMerge.apply(undefined, [base].concat(values)));
  };
  var mergeErrors = function (errors) {
    return $_2vokfcwwjfuw8tb4.compose(Result.error, $_efmt4zxbjfuw8tcj.flatten)(errors);
  };
  var consolidateObj = function (objects, base) {
    var partitions = $_7v02bqy9jfuw8thf.partition(objects);
    return partitions.errors.length > 0 ? mergeErrors(partitions.errors) : mergeValues(partitions.values, base);
  };
  var consolidateArr = function (objects) {
    var partitions = $_7v02bqy9jfuw8thf.partition(objects);
    return partitions.errors.length > 0 ? mergeErrors(partitions.errors) : Result.value(partitions.values);
  };
  var ResultCombine = {
    consolidateObj: consolidateObj,
    consolidateArr: consolidateArr
  };

  var narrow = function (obj, fields) {
    var r = {};
    $_efmt4zxbjfuw8tcj.each(fields, function (field) {
      if (obj[field] !== undefined && obj.hasOwnProperty(field)) {
        r[field] = obj[field];
      }
    });
    return r;
  };
  var exclude = function (obj, fields) {
    var r = {};
    $_8qu224wzjfuw8tb9.each(obj, function (v, k) {
      if (!$_efmt4zxbjfuw8tcj.contains(fields, k)) {
        r[k] = v;
      }
    });
    return r;
  };

  var readOpt = function (key) {
    return function (obj) {
      return obj.hasOwnProperty(key) ? Option.from(obj[key]) : Option.none();
    };
  };
  var readOr = function (key, fallback) {
    return function (obj) {
      return readOpt(key)(obj).getOr(fallback);
    };
  };
  var readOptFrom = function (obj, key) {
    return readOpt(key)(obj);
  };
  var hasKey = function (obj, key) {
    return obj.hasOwnProperty(key) && obj[key] !== undefined && obj[key] !== null;
  };

  var wrap$1 = function (key, value) {
    var r = {};
    r[key] = value;
    return r;
  };
  var wrapAll = function (keyvalues) {
    var r = {};
    $_efmt4zxbjfuw8tcj.each(keyvalues, function (kv) {
      r[kv.key] = kv.value;
    });
    return r;
  };

  var narrow$1 = function (obj, fields) {
    return narrow(obj, fields);
  };
  var exclude$1 = function (obj, fields) {
    return exclude(obj, fields);
  };
  var readOpt$1 = function (key) {
    return readOpt(key);
  };
  var readOr$1 = function (key, fallback) {
    return readOr(key, fallback);
  };
  var readOptFrom$1 = function (obj, key) {
    return readOptFrom(obj, key);
  };
  var wrap$2 = function (key, value) {
    return wrap$1(key, value);
  };
  var wrapAll$1 = function (keyvalues) {
    return wrapAll(keyvalues);
  };
  var consolidate = function (objs, base) {
    return ResultCombine.consolidateObj(objs, base);
  };
  var hasKey$1 = function (obj, key) {
    return hasKey(obj, key);
  };

  var typeAdt = $_dldkf4y5jfuw8tgp.generate([
    {
      setOf: [
        'validator',
        'valueType'
      ]
    },
    { arrOf: ['valueType'] },
    { objOf: ['fields'] },
    { itemOf: ['validator'] },
    {
      choiceOf: [
        'key',
        'branches'
      ]
    },
    { thunk: ['description'] },
    {
      func: [
        'args',
        'outputSchema'
      ]
    }
  ]);
  var fieldAdt = $_dldkf4y5jfuw8tgp.generate([
    {
      field: [
        'name',
        'presence',
        'type'
      ]
    },
    { state: ['name'] }
  ]);

  var json = function () {
    return $_dxyj33xujfuw8tet.getOrDie('JSON');
  };
  var parse = function (obj) {
    return json().parse(obj);
  };
  var stringify = function (obj, replacer, space) {
    return json().stringify(obj, replacer, space);
  };
  var $_6s9vvgygjfuw8ti8 = {
    parse: parse,
    stringify: stringify
  };

  var formatObj = function (input) {
    return $_8aqeo3wyjfuw8tb8.isObject(input) && $_8qu224wzjfuw8tb9.keys(input).length > 100 ? ' removed due to size' : $_6s9vvgygjfuw8ti8.stringify(input, null, 2);
  };
  var formatErrors = function (errors) {
    var es = errors.length > 10 ? errors.slice(0, 10).concat([{
        path: [],
        getErrorInfo: function () {
          return '... (only showing first ten failures)';
        }
      }]) : errors;
    return $_efmt4zxbjfuw8tcj.map(es, function (e) {
      return 'Failed path: (' + e.path.join(' > ') + ')\n' + e.getErrorInfo();
    });
  };

  var nu$3 = function (path, getErrorInfo) {
    return Result.error([{
        path: path,
        getErrorInfo: getErrorInfo
      }]);
  };
  var missingStrict = function (path, key, obj) {
    return nu$3(path, function () {
      return 'Could not find valid *strict* value for "' + key + '" in ' + formatObj(obj);
    });
  };
  var missingKey = function (path, key) {
    return nu$3(path, function () {
      return 'Choice schema did not contain choice key: "' + key + '"';
    });
  };
  var missingBranch = function (path, branches, branch) {
    return nu$3(path, function () {
      return 'The chosen schema: "' + branch + '" did not exist in branches: ' + formatObj(branches);
    });
  };
  var unsupportedFields = function (path, unsupported) {
    return nu$3(path, function () {
      return 'There are unsupported fields: [' + unsupported.join(', ') + '] specified';
    });
  };
  var custom = function (path, err) {
    return nu$3(path, function () {
      return err;
    });
  };

  var adt$1 = $_dldkf4y5jfuw8tgp.generate([
    {
      field: [
        'key',
        'okey',
        'presence',
        'prop'
      ]
    },
    {
      state: [
        'okey',
        'instantiator'
      ]
    }
  ]);
  var strictAccess = function (path, obj, key) {
    return readOptFrom(obj, key).fold(function () {
      return missingStrict(path, key, obj);
    }, Result.value);
  };
  var fallbackAccess = function (obj, key, fallbackThunk) {
    var v = readOptFrom(obj, key).fold(function () {
      return fallbackThunk(obj);
    }, $_2vokfcwwjfuw8tb4.identity);
    return Result.value(v);
  };
  var optionAccess = function (obj, key) {
    return Result.value(readOptFrom(obj, key));
  };
  var optionDefaultedAccess = function (obj, key, fallback) {
    var opt = readOptFrom(obj, key).map(function (val) {
      return val === true ? fallback(obj) : val;
    });
    return Result.value(opt);
  };
  var cExtractOne = function (path, obj, field, strength) {
    return field.fold(function (key, okey, presence, prop) {
      var bundle = function (av) {
        return prop.extract(path.concat([key]), strength, av).map(function (res) {
          return wrap$1(okey, strength(res));
        });
      };
      var bundleAsOption = function (optValue) {
        return optValue.fold(function () {
          var outcome = wrap$1(okey, strength(Option.none()));
          return Result.value(outcome);
        }, function (ov) {
          return prop.extract(path.concat([key]), strength, ov).map(function (res) {
            return wrap$1(okey, strength(Option.some(res)));
          });
        });
      };
      return function () {
        return presence.fold(function () {
          return strictAccess(path, obj, key).bind(bundle);
        }, function (fallbackThunk) {
          return fallbackAccess(obj, key, fallbackThunk).bind(bundle);
        }, function () {
          return optionAccess(obj, key).bind(bundleAsOption);
        }, function (fallbackThunk) {
          return optionDefaultedAccess(obj, key, fallbackThunk).bind(bundleAsOption);
        }, function (baseThunk) {
          var base = baseThunk(obj);
          return fallbackAccess(obj, key, $_2vokfcwwjfuw8tb4.constant({})).map(function (v) {
            return $_3jctjywxjfuw8tb6.deepMerge(base, v);
          }).bind(bundle);
        });
      }();
    }, function (okey, instantiator) {
      var state = instantiator(obj);
      return Result.value(wrap$1(okey, strength(state)));
    });
  };
  var cExtract = function (path, obj, fields, strength) {
    var results = $_efmt4zxbjfuw8tcj.map(fields, function (field) {
      return cExtractOne(path, obj, field, strength);
    });
    return ResultCombine.consolidateObj(results, {});
  };
  var value$2 = function (validator) {
    var extract = function (path, strength, val) {
      return validator(val, strength).fold(function (err) {
        return custom(path, err);
      }, Result.value);
    };
    var toString$$1 = function () {
      return 'val';
    };
    var toDsl = function () {
      return typeAdt.itemOf(validator);
    };
    return {
      extract: extract,
      toString: toString$$1,
      toDsl: toDsl
    };
  };
  var getSetKeys = function (obj) {
    var keys = $_8qu224wzjfuw8tb9.keys(obj);
    return $_efmt4zxbjfuw8tcj.filter(keys, function (k) {
      return hasKey$1(obj, k);
    });
  };
  var objOfOnly = function (fields) {
    var delegate = objOf(fields);
    var fieldNames = $_efmt4zxbjfuw8tcj.foldr(fields, function (acc, f) {
      return f.fold(function (key) {
        return $_3jctjywxjfuw8tb6.deepMerge(acc, wrap$2(key, true));
      }, $_2vokfcwwjfuw8tb4.constant(acc));
    }, {});
    var extract = function (path, strength, o) {
      var keys = $_8aqeo3wyjfuw8tb8.isBoolean(o) ? [] : getSetKeys(o);
      var extra = $_efmt4zxbjfuw8tcj.filter(keys, function (k) {
        return !hasKey$1(fieldNames, k);
      });
      return extra.length === 0 ? delegate.extract(path, strength, o) : unsupportedFields(path, extra);
    };
    return {
      extract: extract,
      toString: delegate.toString,
      toDsl: delegate.toDsl
    };
  };
  var objOf = function (fields) {
    var extract = function (path, strength, o) {
      return cExtract(path, o, fields, strength);
    };
    var toString$$1 = function () {
      var fieldStrings = $_efmt4zxbjfuw8tcj.map(fields, function (field) {
        return field.fold(function (key, okey, presence, prop) {
          return key + ' -> ' + prop.toString();
        }, function (okey, instantiator) {
          return 'state(' + okey + ')';
        });
      });
      return 'obj{\n' + fieldStrings.join('\n') + '}';
    };
    var toDsl = function () {
      return typeAdt.objOf($_efmt4zxbjfuw8tcj.map(fields, function (f) {
        return f.fold(function (key, okey, presence, prop) {
          return fieldAdt.field(key, presence, prop);
        }, function (okey, instantiator) {
          return fieldAdt.state(okey);
        });
      }));
    };
    return {
      extract: extract,
      toString: toString$$1,
      toDsl: toDsl
    };
  };
  var arrOf = function (prop) {
    var extract = function (path, strength, array) {
      var results = $_efmt4zxbjfuw8tcj.map(array, function (a, i) {
        return prop.extract(path.concat(['[' + i + ']']), strength, a);
      });
      return ResultCombine.consolidateArr(results);
    };
    var toString$$1 = function () {
      return 'array(' + prop.toString() + ')';
    };
    var toDsl = function () {
      return typeAdt.arrOf(prop);
    };
    return {
      extract: extract,
      toString: toString$$1,
      toDsl: toDsl
    };
  };
  var setOf = function (validator, prop) {
    var validateKeys = function (path, keys) {
      return arrOf(value$2(validator)).extract(path, $_2vokfcwwjfuw8tb4.identity, keys);
    };
    var extract = function (path, strength, o) {
      var keys = $_8qu224wzjfuw8tb9.keys(o);
      return validateKeys(path, keys).bind(function (validKeys) {
        var schema = $_efmt4zxbjfuw8tcj.map(validKeys, function (vk) {
          return adt$1.field(vk, vk, strict(), prop);
        });
        return objOf(schema).extract(path, strength, o);
      });
    };
    var toString$$1 = function () {
      return 'setOf(' + prop.toString() + ')';
    };
    var toDsl = function () {
      return typeAdt.setOf(validator, prop);
    };
    return {
      extract: extract,
      toString: toString$$1,
      toDsl: toDsl
    };
  };
  var anyValue = $_2vokfcwwjfuw8tb4.constant(value$2(Result.value));
  var arrOfObj = $_2vokfcwwjfuw8tb4.compose(arrOf, objOf);
  var state = adt$1.state;
  var field = adt$1.field;

  var strict$1 = function (key) {
    return field(key, key, strict(), anyValue());
  };
  var strictOf = function (key, schema) {
    return field(key, key, strict(), schema);
  };
  var strictFunction = function (key) {
    return field(key, key, strict(), value$2(function (f) {
      return $_8aqeo3wyjfuw8tb8.isFunction(f) ? Result.value(f) : Result.error('Not a function');
    }));
  };
  var forbid = function (key, message) {
    return field(key, key, asOption(), value$2(function (v) {
      return Result.error('The field: ' + key + ' is forbidden. ' + message);
    }));
  };
  var strictObjOf = function (key, objSchema) {
    return field(key, key, strict(), objOf(objSchema));
  };
  var option = function (key) {
    return field(key, key, asOption(), anyValue());
  };
  var optionOf = function (key, schema) {
    return field(key, key, asOption(), schema);
  };
  var optionObjOf = function (key, objSchema) {
    return field(key, key, asOption(), objOf(objSchema));
  };
  var optionObjOfOnly = function (key, objSchema) {
    return field(key, key, asOption(), objOfOnly(objSchema));
  };
  var defaulted$1 = function (key, fallback) {
    return field(key, key, defaulted(fallback), anyValue());
  };
  var defaultedOf = function (key, fallback, schema) {
    return field(key, key, defaulted(fallback), schema);
  };
  var defaultedObjOf = function (key, fallback, objSchema) {
    return field(key, key, defaulted(fallback), objOf(objSchema));
  };
  var state$1 = function (okey, instantiator) {
    return state(okey, instantiator);
  };

  var chooseFrom = function (path, strength, input, branches, ch) {
    var fields = readOptFrom$1(branches, ch);
    return fields.fold(function () {
      return missingBranch(path, branches, ch);
    }, function (fs) {
      return objOf(fs).extract(path.concat(['branch: ' + ch]), strength, input);
    });
  };
  var choose = function (key, branches) {
    var extract = function (path, strength, input) {
      var choice = readOptFrom$1(input, key);
      return choice.fold(function () {
        return missingKey(path, key);
      }, function (chosen) {
        return chooseFrom(path, strength, input, branches, chosen);
      });
    };
    var toString$$1 = function () {
      return 'chooseOn(' + key + '). Possible values: ' + $_8qu224wzjfuw8tb9.keys(branches);
    };
    var toDsl = function () {
      return typeAdt.choiceOf(key, branches);
    };
    return {
      extract: extract,
      toString: toString$$1,
      toDsl: toDsl
    };
  };

  var _anyValue = value$2(Result.value);
  var valueOf = function (validator) {
    return value$2(function (v) {
      return validator(v);
    });
  };
  var extract = function (label, prop, strength, obj) {
    return prop.extract([label], strength, obj).fold(function (errs) {
      return Result.error({
        input: obj,
        errors: errs
      });
    }, Result.value);
  };
  var asStruct = function (label, prop, obj) {
    return extract(label, prop, $_2vokfcwwjfuw8tb4.constant, obj);
  };
  var asRaw = function (label, prop, obj) {
    return extract(label, prop, $_2vokfcwwjfuw8tb4.identity, obj);
  };
  var getOrDie$1 = function (extraction) {
    return extraction.fold(function (errInfo) {
      throw new Error(formatError(errInfo));
    }, $_2vokfcwwjfuw8tb4.identity);
  };
  var asRawOrDie = function (label, prop, obj) {
    return getOrDie$1(asRaw(label, prop, obj));
  };
  var asStructOrDie = function (label, prop, obj) {
    return getOrDie$1(asStruct(label, prop, obj));
  };
  var formatError = function (errInfo) {
    return 'Errors: \n' + formatErrors(errInfo.errors) + '\n\nInput object: ' + formatObj(errInfo.input);
  };
  var choose$1 = function (key, branches) {
    return choose(key, branches);
  };
  var anyValue$1 = $_2vokfcwwjfuw8tb4.constant(_anyValue);

  var isSource = function (component, simulatedEvent) {
    return $_4867a0xsjfuw8tej.eq(component.element(), simulatedEvent.event().target());
  };

  var nu$4 = function (parts) {
    if (!hasKey$1(parts, 'can') && !hasKey$1(parts, 'abort') && !hasKey$1(parts, 'run')) {
      throw new Error('EventHandler defined by: ' + $_6s9vvgygjfuw8ti8.stringify(parts, null, 2) + ' does not have can, abort, or run!');
    }
    return asRawOrDie('Extracting event.handler', objOfOnly([
      defaulted$1('can', $_2vokfcwwjfuw8tb4.constant(true)),
      defaulted$1('abort', $_2vokfcwwjfuw8tb4.constant(false)),
      defaulted$1('run', $_2vokfcwwjfuw8tb4.noop)
    ]), parts);
  };
  var all$1 = function (handlers, f) {
    return function () {
      var args = Array.prototype.slice.call(arguments, 0);
      return $_efmt4zxbjfuw8tcj.foldl(handlers, function (acc, handler) {
        return acc && f(handler).apply(undefined, args);
      }, true);
    };
  };
  var any = function (handlers, f) {
    return function () {
      var args = Array.prototype.slice.call(arguments, 0);
      return $_efmt4zxbjfuw8tcj.foldl(handlers, function (acc, handler) {
        return acc || f(handler).apply(undefined, args);
      }, false);
    };
  };
  var read = function (handler) {
    return $_8aqeo3wyjfuw8tb8.isFunction(handler) ? {
      can: $_2vokfcwwjfuw8tb4.constant(true),
      abort: $_2vokfcwwjfuw8tb4.constant(false),
      run: handler
    } : handler;
  };
  var fuse = function (handlers) {
    var can = all$1(handlers, function (handler) {
      return handler.can;
    });
    var abort = any(handlers, function (handler) {
      return handler.abort;
    });
    var run = function () {
      var args = Array.prototype.slice.call(arguments, 0);
      $_efmt4zxbjfuw8tcj.each(handlers, function (handler) {
        handler.run.apply(undefined, args);
      });
    };
    return nu$4({
      can: can,
      abort: abort,
      run: run
    });
  };

  var derive = wrapAll$1;
  var abort = function (name, predicate) {
    return {
      key: name,
      value: nu$4({ abort: predicate })
    };
  };
  var can = function (name, predicate) {
    return {
      key: name,
      value: nu$4({ can: predicate })
    };
  };
  var run = function (name, handler) {
    return {
      key: name,
      value: nu$4({ run: handler })
    };
  };
  var runActionExtra = function (name, action, extra) {
    return {
      key: name,
      value: nu$4({
        run: function (component) {
          action.apply(undefined, [component].concat(extra));
        }
      })
    };
  };
  var runOnName = function (name) {
    return function (handler) {
      return run(name, handler);
    };
  };
  var runOnSourceName = function (name) {
    return function (handler) {
      return {
        key: name,
        value: nu$4({
          run: function (component, simulatedEvent) {
            if (isSource(component, simulatedEvent)) {
              handler(component, simulatedEvent);
            }
          }
        })
      };
    };
  };
  var redirectToUid = function (name, uid) {
    return run(name, function (component, simulatedEvent) {
      component.getSystem().getByUid(uid).each(function (redirectee) {
        dispatchEvent(redirectee, redirectee.element(), name, simulatedEvent);
      });
    });
  };
  var redirectToPart = function (name, detail, partName) {
    var uid = detail.partUids()[partName];
    return redirectToUid(name, uid);
  };
  var runWithTarget = function (name, f) {
    return run(name, function (component, simulatedEvent) {
      component.getSystem().getByDom(simulatedEvent.event().target()).each(function (target) {
        f(component, target, simulatedEvent);
      });
    });
  };
  var cutter = function (name) {
    return run(name, function (component, simulatedEvent) {
      simulatedEvent.cut();
    });
  };
  var stopper = function (name) {
    return run(name, function (component, simulatedEvent) {
      simulatedEvent.stop();
    });
  };
  var runOnAttached = runOnSourceName(attachedToDom());
  var runOnDetached = runOnSourceName(detachedFromDom());
  var runOnInit = runOnSourceName(systemInit());
  var runOnExecute = runOnName(execute());

  var markAsBehaviourApi = function (f, apiName, apiFunction) {
    return f;
  };
  var markAsExtraApi = function (f, extraName) {
    return f;
  };
  var markAsSketchApi = function (f, apiFunction) {
    return f;
  };

  var nu$5 = $_4xhupwxnjfuw8tea.immutableBag(['tag'], [
    'classes',
    'attributes',
    'styles',
    'value',
    'innerHtml',
    'domChildren',
    'defChildren'
  ]);
  var defToStr = function (defn) {
    var raw = defToRaw(defn);
    return $_6s9vvgygjfuw8ti8.stringify(raw, null, 2);
  };
  var defToRaw = function (defn) {
    return {
      tag: defn.tag(),
      classes: defn.classes().getOr([]),
      attributes: defn.attributes().getOr({}),
      styles: defn.styles().getOr({}),
      value: defn.value().getOr('<none>'),
      innerHtml: defn.innerHtml().getOr('<none>'),
      defChildren: defn.defChildren().getOr('<none>'),
      domChildren: defn.domChildren().fold(function () {
        return '<none>';
      }, function (children) {
        return children.length === 0 ? '0 children, but still specified' : String(children.length);
      })
    };
  };

  var fields = [
    'classes',
    'attributes',
    'styles',
    'value',
    'innerHtml',
    'defChildren',
    'domChildren'
  ];
  var nu$6 = $_4xhupwxnjfuw8tea.immutableBag([], fields);
  var clashingOptArrays = function (key, oArr1, oArr2) {
    return oArr1.fold(function () {
      return oArr2.fold(function () {
        return {};
      }, function (arr2) {
        return wrap$2(key, arr2);
      });
    }, function (arr1) {
      return oArr2.fold(function () {
        return wrap$2(key, arr1);
      }, function (arr2) {
        return wrap$2(key, arr2);
      });
    });
  };
  var merge$1 = function (defnA, mod) {
    var raw = $_3jctjywxjfuw8tb6.deepMerge({
      tag: defnA.tag(),
      classes: mod.classes().getOr([]).concat(defnA.classes().getOr([])),
      attributes: $_3jctjywxjfuw8tb6.merge(defnA.attributes().getOr({}), mod.attributes().getOr({})),
      styles: $_3jctjywxjfuw8tb6.merge(defnA.styles().getOr({}), mod.styles().getOr({}))
    }, mod.innerHtml().or(defnA.innerHtml()).map(function (innerHtml) {
      return wrap$2('innerHtml', innerHtml);
    }).getOr({}), clashingOptArrays('domChildren', mod.domChildren(), defnA.domChildren()), clashingOptArrays('defChildren', mod.defChildren(), defnA.defChildren()), mod.value().or(defnA.value()).map(function (value) {
      return wrap$2('value', value);
    }).getOr({}));
    return nu$5(raw);
  };

  var executeEvent = function (bConfig, bState, executor) {
    return runOnExecute(function (component) {
      executor(component, bConfig, bState);
    });
  };
  var loadEvent = function (bConfig, bState, f) {
    return runOnInit(function (component, simulatedEvent) {
      f(component, bConfig, bState);
    });
  };
  var create = function (schema, name, active, apis, extra, state) {
    var configSchema = objOfOnly(schema);
    var schemaSchema = optionObjOf(name, [optionObjOfOnly('config', schema)]);
    return doCreate(configSchema, schemaSchema, name, active, apis, extra, state);
  };
  var createModes = function (modes, name, active, apis, extra, state) {
    var configSchema = modes;
    var schemaSchema = optionObjOf(name, [optionOf('config', modes)]);
    return doCreate(configSchema, schemaSchema, name, active, apis, extra, state);
  };
  var wrapApi = function (bName, apiFunction, apiName) {
    var f = function (component) {
      var args = arguments;
      return component.config({ name: $_2vokfcwwjfuw8tb4.constant(bName) }).fold(function () {
        throw new Error('We could not find any behaviour configuration for: ' + bName + '. Using API: ' + apiName);
      }, function (info) {
        var rest = Array.prototype.slice.call(args, 1);
        return apiFunction.apply(undefined, [
          component,
          info.config,
          info.state
        ].concat(rest));
      });
    };
    return markAsBehaviourApi(f, apiName, apiFunction);
  };
  var revokeBehaviour = function (name) {
    return {
      key: name,
      value: undefined
    };
  };
  var doCreate = function (configSchema, schemaSchema, name, active, apis, extra, state) {
    var getConfig = function (info) {
      return hasKey$1(info, name) ? info[name]() : Option.none();
    };
    var wrappedApis = $_8qu224wzjfuw8tb9.map(apis, function (apiF, apiName) {
      return wrapApi(name, apiF, apiName);
    });
    var wrappedExtra = $_8qu224wzjfuw8tb9.map(extra, function (extraF, extraName) {
      return markAsExtraApi(extraF, extraName);
    });
    var me = $_3jctjywxjfuw8tb6.deepMerge(wrappedExtra, wrappedApis, {
      revoke: $_2vokfcwwjfuw8tb4.curry(revokeBehaviour, name),
      config: function (spec) {
        var prepared = asStructOrDie(name + '-config', configSchema, spec);
        return {
          key: name,
          value: {
            config: prepared,
            me: me,
            configAsRaw: $_ctj1zwx4jfuw8tbw.cached(function () {
              return asRawOrDie(name + '-config', configSchema, spec);
            }),
            initialConfig: spec,
            state: state
          }
        };
      },
      schema: function () {
        return schemaSchema;
      },
      exhibit: function (info, base) {
        return getConfig(info).bind(function (behaviourInfo) {
          return readOptFrom$1(active, 'exhibit').map(function (exhibitor) {
            return exhibitor(base, behaviourInfo.config, behaviourInfo.state);
          });
        }).getOr(nu$6({}));
      },
      name: function () {
        return name;
      },
      handlers: function (info) {
        return getConfig(info).bind(function (behaviourInfo) {
          return readOptFrom$1(active, 'events').map(function (events) {
            return events(behaviourInfo.config, behaviourInfo.state);
          });
        }).getOr({});
      }
    });
    return me;
  };

  var base = function (handleUnsupported, required) {
    return baseWith(handleUnsupported, required, {
      validate: $_8aqeo3wyjfuw8tb8.isFunction,
      label: 'function'
    });
  };
  var baseWith = function (handleUnsupported, required, pred) {
    if (required.length === 0)
      throw new Error('You must specify at least one required field.');
    $_fpmdlsxqjfuw8teg.validateStrArr('required', required);
    $_fpmdlsxqjfuw8teg.checkDupes(required);
    return function (obj) {
      var keys = $_8qu224wzjfuw8tb9.keys(obj);
      var allReqd = $_efmt4zxbjfuw8tcj.forall(required, function (req) {
        return $_efmt4zxbjfuw8tcj.contains(keys, req);
      });
      if (!allReqd)
        $_fpmdlsxqjfuw8teg.reqMessage(required, keys);
      handleUnsupported(required, keys);
      var invalidKeys = $_efmt4zxbjfuw8tcj.filter(required, function (key) {
        return !pred.validate(obj[key], key);
      });
      if (invalidKeys.length > 0)
        $_fpmdlsxqjfuw8teg.invalidTypeMessage(invalidKeys, pred.label);
      return obj;
    };
  };
  var handleExact = function (required, keys) {
    var unsupported = $_efmt4zxbjfuw8tcj.filter(keys, function (key) {
      return !$_efmt4zxbjfuw8tcj.contains(required, key);
    });
    if (unsupported.length > 0)
      $_fpmdlsxqjfuw8teg.unsuppMessage(unsupported);
  };
  var allowExtra = $_2vokfcwwjfuw8tb4.noop;
  var $_2cliu2ysjfuw8tkr = {
    exactly: $_2vokfcwwjfuw8tb4.curry(base, handleExact),
    ensure: $_2vokfcwwjfuw8tb4.curry(base, allowExtra),
    ensureWith: $_2vokfcwwjfuw8tb4.curry(baseWith, allowExtra)
  };

  var BehaviourState = $_2cliu2ysjfuw8tkr.ensure(['readState']);

  var init = function () {
    return BehaviourState({
      readState: function () {
        return 'No State required';
      }
    });
  };


  var NoState = Object.freeze({
  	init: init
  });

  var derive$2 = function (capabilities) {
    return wrapAll$1(capabilities);
  };
  var simpleSchema = objOfOnly([
    strict$1('fields'),
    strict$1('name'),
    defaulted$1('active', {}),
    defaulted$1('apis', {}),
    defaulted$1('extra', {}),
    defaulted$1('state', NoState)
  ]);
  var create$1 = function (data) {
    var value = asRawOrDie('Creating behaviour: ' + data.name, simpleSchema, data);
    return create(value.fields, value.name, value.active, value.apis, value.extra, value.state);
  };
  var modeSchema = objOfOnly([
    strict$1('branchKey'),
    strict$1('branches'),
    strict$1('name'),
    defaulted$1('active', {}),
    defaulted$1('apis', {}),
    defaulted$1('extra', {}),
    defaulted$1('state', NoState)
  ]);
  var createModes$1 = function (data) {
    var value = asRawOrDie('Creating behaviour: ' + data.name, modeSchema, data);
    return createModes(choose$1(value.branchKey, value.branches), value.name, value.active, value.apis, value.extra, value.state);
  };
  var revoke = $_2vokfcwwjfuw8tb4.constant(undefined);
  var noActive = $_2vokfcwwjfuw8tb4.constant({});
  var noApis = $_2vokfcwwjfuw8tb4.constant({});
  var noExtra = $_2vokfcwwjfuw8tb4.constant({});
  var noState = $_2vokfcwwjfuw8tb4.constant(NoState);

  function Toggler (turnOff, turnOn, initial) {
    var active = initial || false;
    var on = function () {
      turnOn();
      active = true;
    };
    var off = function () {
      turnOff();
      active = false;
    };
    var toggle = function () {
      var f = active ? off : on;
      f();
    };
    var isOn = function () {
      return active;
    };
    return {
      on: on,
      off: off,
      toggle: toggle,
      isOn: isOn
    };
  }

  var rawSet = function (dom, key, value) {
    if ($_8aqeo3wyjfuw8tb8.isString(value) || $_8aqeo3wyjfuw8tb8.isBoolean(value) || $_8aqeo3wyjfuw8tb8.isNumber(value)) {
      dom.setAttribute(key, value + '');
    } else {
      console.error('Invalid call to Attr.set. Key ', key, ':: Value ', value, ':: Element ', dom);
      throw new Error('Attribute value was not simple');
    }
  };
  var set = function (element, key, value) {
    rawSet(element.dom(), key, value);
  };
  var setAll = function (element, attrs) {
    var dom = element.dom();
    $_8qu224wzjfuw8tb9.each(attrs, function (v, k) {
      rawSet(dom, k, v);
    });
  };
  var get = function (element, key) {
    var v = element.dom().getAttribute(key);
    return v === null ? undefined : v;
  };
  var has = function (element, key) {
    var dom = element.dom();
    return dom && dom.hasAttribute ? dom.hasAttribute(key) : false;
  };
  var remove$1 = function (element, key) {
    element.dom().removeAttribute(key);
  };
  var hasNone = function (element) {
    var attrs = element.dom().attributes;
    return attrs === undefined || attrs === null || attrs.length === 0;
  };
  var clone = function (element) {
    return $_efmt4zxbjfuw8tcj.foldl(element.dom().attributes, function (acc, attr) {
      acc[attr.name] = attr.value;
      return acc;
    }, {});
  };
  var transferOne = function (source, destination, attr) {
    if (has(source, attr) && !has(destination, attr))
      set(destination, attr, get(source, attr));
  };
  var transfer = function (source, destination, attrs) {
    if (!$_74lhjaxjjfuw8tdt.isElement(source) || !$_74lhjaxjjfuw8tdt.isElement(destination))
      return;
    $_efmt4zxbjfuw8tcj.each(attrs, function (attr) {
      transferOne(source, destination, attr);
    });
  };
  var $_47adx7ywjfuw8tl3 = {
    clone: clone,
    set: set,
    setAll: setAll,
    get: get,
    has: has,
    remove: remove$1,
    hasNone: hasNone,
    transfer: transfer
  };

  var read$1 = function (element, attr) {
    var value = $_47adx7ywjfuw8tl3.get(element, attr);
    return value === undefined || value === '' ? [] : value.split(' ');
  };
  var add = function (element, attr, id) {
    var old = read$1(element, attr);
    var nu = old.concat([id]);
    $_47adx7ywjfuw8tl3.set(element, attr, nu.join(' '));
  };
  var remove$2 = function (element, attr, id) {
    var nu = $_efmt4zxbjfuw8tcj.filter(read$1(element, attr), function (v) {
      return v !== id;
    });
    if (nu.length > 0)
      $_47adx7ywjfuw8tl3.set(element, attr, nu.join(' '));
    else
      $_47adx7ywjfuw8tl3.remove(element, attr);
  };
  var $_2ym1c3yyjfuw8tlg = {
    read: read$1,
    add: add,
    remove: remove$2
  };

  var supports = function (element) {
    return element.dom().classList !== undefined;
  };
  var get$1 = function (element) {
    return $_2ym1c3yyjfuw8tlg.read(element, 'class');
  };
  var add$1 = function (element, clazz) {
    return $_2ym1c3yyjfuw8tlg.add(element, 'class', clazz);
  };
  var remove$3 = function (element, clazz) {
    return $_2ym1c3yyjfuw8tlg.remove(element, 'class', clazz);
  };
  var toggle = function (element, clazz) {
    if ($_efmt4zxbjfuw8tcj.contains(get$1(element), clazz)) {
      remove$3(element, clazz);
    } else {
      add$1(element, clazz);
    }
  };
  var $_bxqp80yxjfuw8tlc = {
    get: get$1,
    add: add$1,
    remove: remove$3,
    toggle: toggle,
    supports: supports
  };

  var add$2 = function (element, clazz) {
    if ($_bxqp80yxjfuw8tlc.supports(element))
      element.dom().classList.add(clazz);
    else
      $_bxqp80yxjfuw8tlc.add(element, clazz);
  };
  var cleanClass = function (element) {
    var classList = $_bxqp80yxjfuw8tlc.supports(element) ? element.dom().classList : $_bxqp80yxjfuw8tlc.get(element);
    if (classList.length === 0) {
      $_47adx7ywjfuw8tl3.remove(element, 'class');
    }
  };
  var remove$4 = function (element, clazz) {
    if ($_bxqp80yxjfuw8tlc.supports(element)) {
      var classList = element.dom().classList;
      classList.remove(clazz);
    } else
      $_bxqp80yxjfuw8tlc.remove(element, clazz);
    cleanClass(element);
  };
  var toggle$1 = function (element, clazz) {
    return $_bxqp80yxjfuw8tlc.supports(element) ? element.dom().classList.toggle(clazz) : $_bxqp80yxjfuw8tlc.toggle(element, clazz);
  };
  var toggler = function (element, clazz) {
    var hasClasslist = $_bxqp80yxjfuw8tlc.supports(element);
    var classList = element.dom().classList;
    var off = function () {
      if (hasClasslist)
        classList.remove(clazz);
      else
        $_bxqp80yxjfuw8tlc.remove(element, clazz);
    };
    var on = function () {
      if (hasClasslist)
        classList.add(clazz);
      else
        $_bxqp80yxjfuw8tlc.add(element, clazz);
    };
    return Toggler(off, on, has$1(element, clazz));
  };
  var has$1 = function (element, clazz) {
    return $_bxqp80yxjfuw8tlc.supports(element) && element.dom().classList.contains(clazz);
  };
  var $_6po7jxyujfuw8tl0 = {
    add: add$2,
    remove: remove$4,
    toggle: toggle$1,
    toggler: toggler,
    has: has$1
  };

  var swap = function (element, addCls, removeCls) {
    $_6po7jxyujfuw8tl0.remove(element, removeCls);
    $_6po7jxyujfuw8tl0.add(element, addCls);
  };
  var toAlpha = function (component, swapConfig, swapState) {
    swap(component.element(), swapConfig.alpha(), swapConfig.omega());
  };
  var toOmega = function (component, swapConfig, swapState) {
    swap(component.element(), swapConfig.omega(), swapConfig.alpha());
  };
  var clear = function (component, swapConfig, swapState) {
    $_6po7jxyujfuw8tl0.remove(component.element(), swapConfig.alpha());
    $_6po7jxyujfuw8tl0.remove(component.element(), swapConfig.omega());
  };
  var isAlpha = function (component, swapConfig, swapState) {
    return $_6po7jxyujfuw8tl0.has(component.element(), swapConfig.alpha());
  };
  var isOmega = function (component, swapConfig, swapState) {
    return $_6po7jxyujfuw8tl0.has(component.element(), swapConfig.omega());
  };


  var SwapApis = Object.freeze({
  	toAlpha: toAlpha,
  	toOmega: toOmega,
  	isAlpha: isAlpha,
  	isOmega: isOmega,
  	clear: clear
  });

  var SwapSchema = [
    strict$1('alpha'),
    strict$1('omega')
  ];

  var Swapping = create$1({
    fields: SwapSchema,
    name: 'swapping',
    apis: SwapApis
  });

  var Cell = function (initial) {
    var value = initial;
    var get = function () {
      return value;
    };
    var set = function (v) {
      value = v;
    };
    var clone = function () {
      return Cell(get());
    };
    return {
      get: get,
      set: set,
      clone: clone
    };
  };

  function ClosestOrAncestor (is, ancestor, scope, a, isRoot) {
    return is(scope, a) ? Option.some(scope) : $_8aqeo3wyjfuw8tb8.isFunction(isRoot) && isRoot(scope) ? Option.none() : ancestor(scope, a, isRoot);
  }

  var first$1 = function (predicate) {
    return descendant($_8634tqxhjfuw8tdl.body(), predicate);
  };
  var ancestor = function (scope, predicate, isRoot) {
    var element = scope.dom();
    var stop = $_8aqeo3wyjfuw8tb8.isFunction(isRoot) ? isRoot : $_2vokfcwwjfuw8tb4.constant(false);
    while (element.parentNode) {
      element = element.parentNode;
      var el = $_bwdnu0xijfuw8tdo.fromDom(element);
      if (predicate(el))
        return Option.some(el);
      else if (stop(el))
        break;
    }
    return Option.none();
  };
  var closest = function (scope, predicate, isRoot) {
    var is = function (scope) {
      return predicate(scope);
    };
    return ClosestOrAncestor(is, ancestor, scope, predicate, isRoot);
  };
  var sibling = function (scope, predicate) {
    var element = scope.dom();
    if (!element.parentNode)
      return Option.none();
    return child$1($_bwdnu0xijfuw8tdo.fromDom(element.parentNode), function (x) {
      return !$_4867a0xsjfuw8tej.eq(scope, x) && predicate(x);
    });
  };
  var child$1 = function (scope, predicate) {
    var result = $_efmt4zxbjfuw8tcj.find(scope.dom().childNodes, $_2vokfcwwjfuw8tb4.compose(predicate, $_bwdnu0xijfuw8tdo.fromDom));
    return result.map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var descendant = function (scope, predicate) {
    var descend = function (element) {
      for (var i = 0; i < element.childNodes.length; i++) {
        if (predicate($_bwdnu0xijfuw8tdo.fromDom(element.childNodes[i])))
          return Option.some($_bwdnu0xijfuw8tdo.fromDom(element.childNodes[i]));
        var res = descend(element.childNodes[i]);
        if (res.isSome())
          return res;
      }
      return Option.none();
    };
    return descend(scope.dom());
  };
  var $_d0h9pzz3jfuw8tlv = {
    first: first$1,
    ancestor: ancestor,
    closest: closest,
    sibling: sibling,
    child: child$1,
    descendant: descendant
  };

  var any$1 = function (predicate) {
    return $_d0h9pzz3jfuw8tlv.first(predicate).isSome();
  };
  var ancestor$1 = function (scope, predicate, isRoot) {
    return $_d0h9pzz3jfuw8tlv.ancestor(scope, predicate, isRoot).isSome();
  };
  var closest$1 = function (scope, predicate, isRoot) {
    return $_d0h9pzz3jfuw8tlv.closest(scope, predicate, isRoot).isSome();
  };
  var sibling$1 = function (scope, predicate) {
    return $_d0h9pzz3jfuw8tlv.sibling(scope, predicate).isSome();
  };
  var child$2 = function (scope, predicate) {
    return $_d0h9pzz3jfuw8tlv.child(scope, predicate).isSome();
  };
  var descendant$1 = function (scope, predicate) {
    return $_d0h9pzz3jfuw8tlv.descendant(scope, predicate).isSome();
  };
  var $_baqdvvz2jfuw8tlu = {
    any: any$1,
    ancestor: ancestor$1,
    closest: closest$1,
    sibling: sibling$1,
    child: child$2,
    descendant: descendant$1
  };

  var focus$2 = function (element) {
    element.dom().focus();
  };
  var blur = function (element) {
    element.dom().blur();
  };
  var hasFocus = function (element) {
    var doc = $_aff64dxmjfuw8tdx.owner(element).dom();
    return element.dom() === doc.activeElement;
  };
  var active = function (_doc) {
    var doc = _doc !== undefined ? _doc.dom() : document;
    return Option.from(doc.activeElement).map($_bwdnu0xijfuw8tdo.fromDom);
  };
  var focusInside = function (element) {
    var doc = $_aff64dxmjfuw8tdx.owner(element);
    var inside = active(doc).filter(function (a) {
      return $_baqdvvz2jfuw8tlu.closest(a, $_2vokfcwwjfuw8tb4.curry($_4867a0xsjfuw8tej.eq, element));
    });
    inside.fold(function () {
      focus$2(element);
    }, $_2vokfcwwjfuw8tb4.noop);
  };
  var search = function (element) {
    return active($_aff64dxmjfuw8tdx.owner(element)).filter(function (e) {
      return element.dom().contains(e.dom());
    });
  };
  var $_f15fvwz1jfuw8tlo = {
    hasFocus: hasFocus,
    focus: focus$2,
    blur: blur,
    active: active,
    search: search,
    focusInside: focusInside
  };

  var global$1 = tinymce.util.Tools.resolve('tinymce.dom.DOMUtils');

  var global$2 = tinymce.util.Tools.resolve('tinymce.ThemeManager');

  var openLink = function (target) {
    var link = document.createElement('a');
    link.target = '_blank';
    link.href = target.href;
    link.rel = 'noreferrer noopener';
    var nuEvt = document.createEvent('MouseEvents');
    nuEvt.initMouseEvent('click', true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
    document.body.appendChild(link);
    link.dispatchEvent(nuEvt);
    document.body.removeChild(link);
  };
  var $_5567t9z7jfuw8tmd = { openLink: openLink };

  var isSkinDisabled = function (editor) {
    return editor.settings.skin === false;
  };
  var readOnlyOnInit = function (editor) {
    return false;
  };

  var formatChanged = 'formatChanged';
  var orientationChanged = 'orientationChanged';
  var dropupDismissed = 'dropupDismissed';
  var $_9e19stz9jfuw8tmf = {
    formatChanged: $_2vokfcwwjfuw8tb4.constant(formatChanged),
    orientationChanged: $_2vokfcwwjfuw8tb4.constant(orientationChanged),
    dropupDismissed: $_2vokfcwwjfuw8tb4.constant(dropupDismissed)
  };

  var fromHtml$1 = function (html, scope) {
    var doc = scope || document;
    var div = doc.createElement('div');
    div.innerHTML = html;
    return $_aff64dxmjfuw8tdx.children($_bwdnu0xijfuw8tdo.fromDom(div));
  };
  var fromTags = function (tags, scope) {
    return $_efmt4zxbjfuw8tcj.map(tags, function (x) {
      return $_bwdnu0xijfuw8tdo.fromTag(x, scope);
    });
  };
  var fromText$1 = function (texts, scope) {
    return $_efmt4zxbjfuw8tcj.map(texts, function (x) {
      return $_bwdnu0xijfuw8tdo.fromText(x, scope);
    });
  };
  var fromDom$1 = function (nodes) {
    return $_efmt4zxbjfuw8tcj.map(nodes, $_bwdnu0xijfuw8tdo.fromDom);
  };
  var $_g5aj5lzgjfuw8tnm = {
    fromHtml: fromHtml$1,
    fromTags: fromTags,
    fromText: fromText$1,
    fromDom: fromDom$1
  };

  var get$2 = function (element) {
    return element.dom().innerHTML;
  };
  var set$1 = function (element, content) {
    var owner = $_aff64dxmjfuw8tdx.owner(element);
    var docDom = owner.dom();
    var fragment = $_bwdnu0xijfuw8tdo.fromDom(docDom.createDocumentFragment());
    var contentElements = $_g5aj5lzgjfuw8tnm.fromHtml(content, docDom);
    $_g8n2ewxzjfuw8tf7.append(fragment, contentElements);
    $_138z6jxyjfuw8tf4.empty(element);
    $_cwa5ncxljfuw8tdv.append(element, fragment);
  };
  var getOuter = function (element) {
    var container = $_bwdnu0xijfuw8tdo.fromTag('div');
    var clone = $_bwdnu0xijfuw8tdo.fromDom(element.dom().cloneNode(true));
    $_cwa5ncxljfuw8tdv.append(container, clone);
    return get$2(container);
  };
  var $_2dunqqzfjfuw8tnk = {
    get: get$2,
    set: set$1,
    getOuter: getOuter
  };

  var clone$1 = function (original, deep) {
    return $_bwdnu0xijfuw8tdo.fromDom(original.dom().cloneNode(deep));
  };
  var shallow$1 = function (original) {
    return clone$1(original, false);
  };
  var deep$1 = function (original) {
    return clone$1(original, true);
  };
  var shallowAs = function (original, tag) {
    var nu = $_bwdnu0xijfuw8tdo.fromTag(tag);
    var attributes = $_47adx7ywjfuw8tl3.clone(original);
    $_47adx7ywjfuw8tl3.setAll(nu, attributes);
    return nu;
  };
  var copy = function (original, tag) {
    var nu = shallowAs(original, tag);
    var cloneChildren = $_aff64dxmjfuw8tdx.children(deep$1(original));
    $_g8n2ewxzjfuw8tf7.append(nu, cloneChildren);
    return nu;
  };
  var mutate = function (original, tag) {
    var nu = shallowAs(original, tag);
    $_cwa5ncxljfuw8tdv.before(original, nu);
    var children = $_aff64dxmjfuw8tdx.children(original);
    $_g8n2ewxzjfuw8tf7.append(nu, children);
    $_138z6jxyjfuw8tf4.remove(original);
    return nu;
  };
  var $_2mjfk7zhjfuw8tnq = {
    shallow: shallow$1,
    shallowAs: shallowAs,
    deep: deep$1,
    copy: copy,
    mutate: mutate
  };

  var getHtml = function (element) {
    var clone = $_2mjfk7zhjfuw8tnq.shallow(element);
    return $_2dunqqzfjfuw8tnk.getOuter(clone);
  };

  var element = function (elem) {
    return getHtml(elem);
  };

  var chooseChannels = function (channels, message) {
    return message.universal() ? channels : $_efmt4zxbjfuw8tcj.filter(channels, function (ch) {
      return $_efmt4zxbjfuw8tcj.contains(message.channels(), ch);
    });
  };
  var events = function (receiveConfig) {
    return derive([run(receive(), function (component, message) {
        var channelMap = receiveConfig.channels();
        var channels = $_8qu224wzjfuw8tb9.keys(channelMap);
        var targetChannels = chooseChannels(channels, message);
        $_efmt4zxbjfuw8tcj.each(targetChannels, function (ch) {
          var channelInfo = channelMap[ch]();
          var channelSchema = channelInfo.schema();
          var data = asStructOrDie('channel[' + ch + '] data\nReceiver: ' + element(component.element()), channelSchema, message.data());
          channelInfo.onReceive()(component, data);
        });
      })]);
  };


  var ActiveReceiving = Object.freeze({
  	events: events
  });

  var cat = function (arr) {
    var r = [];
    var push = function (x) {
      r.push(x);
    };
    for (var i = 0; i < arr.length; i++) {
      arr[i].each(push);
    }
    return r;
  };
  var findMap = function (arr, f) {
    for (var i = 0; i < arr.length; i++) {
      var r = f(arr[i], i);
      if (r.isSome()) {
        return r;
      }
    }
    return Option.none();
  };
  var liftN = function (arr, f) {
    var r = [];
    for (var i = 0; i < arr.length; i++) {
      var x = arr[i];
      if (x.isSome()) {
        r.push(x.getOrDie());
      } else {
        return Option.none();
      }
    }
    return Option.some(f.apply(null, r));
  };
  var $_e8fwikzljfuw8tp3 = {
    cat: cat,
    findMap: findMap,
    liftN: liftN
  };

  var unknown$3 = 'unknown';
  var debugging = true;
  var eventsMonitored = [];
  var path$1 = [
    'alloy/data/Fields',
    'alloy/debugging/Debugging'
  ];
  var getTrace = function () {
    if (debugging === false) {
      return unknown$3;
    }
    var err = new Error();
    if (err.stack !== undefined) {
      var lines = err.stack.split('\n');
      return $_efmt4zxbjfuw8tcj.find(lines, function (line) {
        return line.indexOf('alloy') > 0 && !$_efmt4zxbjfuw8tcj.exists(path$1, function (p) {
          return line.indexOf(p) > -1;
        });
      }).getOr(unknown$3);
    } else {
      return unknown$3;
    }
  };
  var ignoreEvent = {
    logEventCut: $_2vokfcwwjfuw8tb4.noop,
    logEventStopped: $_2vokfcwwjfuw8tb4.noop,
    logNoParent: $_2vokfcwwjfuw8tb4.noop,
    logEventNoHandlers: $_2vokfcwwjfuw8tb4.noop,
    logEventResponse: $_2vokfcwwjfuw8tb4.noop,
    write: $_2vokfcwwjfuw8tb4.noop
  };
  var monitorEvent = function (eventName, initialTarget, f) {
    var logger = debugging && (eventsMonitored === '*' || $_efmt4zxbjfuw8tcj.contains(eventsMonitored, eventName)) ? function () {
      var sequence = [];
      return {
        logEventCut: function (name, target, purpose) {
          sequence.push({
            outcome: 'cut',
            target: target,
            purpose: purpose
          });
        },
        logEventStopped: function (name, target, purpose) {
          sequence.push({
            outcome: 'stopped',
            target: target,
            purpose: purpose
          });
        },
        logNoParent: function (name, target, purpose) {
          sequence.push({
            outcome: 'no-parent',
            target: target,
            purpose: purpose
          });
        },
        logEventNoHandlers: function (name, target) {
          sequence.push({
            outcome: 'no-handlers-left',
            target: target
          });
        },
        logEventResponse: function (name, target, purpose) {
          sequence.push({
            outcome: 'response',
            purpose: purpose,
            target: target
          });
        },
        write: function () {
          if ($_efmt4zxbjfuw8tcj.contains([
              'mousemove',
              'mouseover',
              'mouseout',
              systemInit()
            ], eventName)) {
            return;
          }
          console.log(eventName, {
            event: eventName,
            target: initialTarget.dom(),
            sequence: $_efmt4zxbjfuw8tcj.map(sequence, function (s) {
              if (!$_efmt4zxbjfuw8tcj.contains([
                  'cut',
                  'stopped',
                  'response'
                ], s.outcome)) {
                return s.outcome;
              } else {
                return '{' + s.purpose + '} ' + s.outcome + ' at (' + element(s.target) + ')';
              }
            })
          });
        }
      };
    }() : ignoreEvent;
    var output = f(logger);
    logger.write();
    return output;
  };
  var noLogger = $_2vokfcwwjfuw8tb4.constant(ignoreEvent);
  var isDebugging = $_2vokfcwwjfuw8tb4.constant(debugging);

  var menuFields = $_2vokfcwwjfuw8tb4.constant([
    strict$1('menu'),
    strict$1('selectedMenu')
  ]);
  var itemFields = $_2vokfcwwjfuw8tb4.constant([
    strict$1('item'),
    strict$1('selectedItem')
  ]);
  var schema = $_2vokfcwwjfuw8tb4.constant(objOfOnly(itemFields().concat(menuFields())));
  var itemSchema = $_2vokfcwwjfuw8tb4.constant(objOfOnly(itemFields()));

  var _initSize = strictObjOf('initSize', [
    strict$1('numColumns'),
    strict$1('numRows')
  ]);
  var itemMarkers = function () {
    return strictOf('markers', itemSchema());
  };
  var tieredMenuMarkers = function () {
    return strictObjOf('markers', [strict$1('backgroundMenu')].concat(menuFields()).concat(itemFields()));
  };
  var markers = function (required) {
    return strictObjOf('markers', $_efmt4zxbjfuw8tcj.map(required, strict$1));
  };
  var onPresenceHandler = function (label, fieldName, presence) {
    var trace = getTrace();
    return field(fieldName, fieldName, presence, valueOf(function (f) {
      return Result.value(function () {
        return f.apply(undefined, arguments);
      });
    }));
  };
  var onHandler = function (fieldName) {
    return onPresenceHandler('onHandler', fieldName, defaulted($_2vokfcwwjfuw8tb4.noop));
  };
  var onKeyboardHandler = function (fieldName) {
    return onPresenceHandler('onKeyboardHandler', fieldName, defaulted(Option.none));
  };
  var onStrictHandler = function (fieldName) {
    return onPresenceHandler('onHandler', fieldName, strict());
  };
  var onStrictKeyboardHandler = function (fieldName) {
    return onPresenceHandler('onKeyboardHandler', fieldName, strict());
  };
  var output$1 = function (name, value) {
    return state$1(name, $_2vokfcwwjfuw8tb4.constant(value));
  };
  var snapshot$1 = function (name) {
    return state$1(name, $_2vokfcwwjfuw8tb4.identity);
  };
  var initSize = $_2vokfcwwjfuw8tb4.constant(_initSize);

  var ReceivingSchema = [strictOf('channels', setOf(Result.value, objOfOnly([
      onStrictHandler('onReceive'),
      defaulted$1('schema', anyValue$1())
    ])))];

  var Receiving = create$1({
    fields: ReceivingSchema,
    name: 'receiving',
    active: ActiveReceiving
  });

  var updateAriaState = function (component, toggleConfig) {
    var pressed = isOn(component, toggleConfig);
    var ariaInfo = toggleConfig.aria();
    ariaInfo.update()(component, ariaInfo, pressed);
  };
  var toggle$2 = function (component, toggleConfig, toggleState) {
    $_6po7jxyujfuw8tl0.toggle(component.element(), toggleConfig.toggleClass());
    updateAriaState(component, toggleConfig);
  };
  var on = function (component, toggleConfig, toggleState) {
    $_6po7jxyujfuw8tl0.add(component.element(), toggleConfig.toggleClass());
    updateAriaState(component, toggleConfig);
  };
  var off = function (component, toggleConfig, toggleState) {
    $_6po7jxyujfuw8tl0.remove(component.element(), toggleConfig.toggleClass());
    updateAriaState(component, toggleConfig);
  };
  var isOn = function (component, toggleConfig) {
    return $_6po7jxyujfuw8tl0.has(component.element(), toggleConfig.toggleClass());
  };
  var onLoad = function (component, toggleConfig, toggleState) {
    var api = toggleConfig.selected() ? on : off;
    api(component, toggleConfig, toggleState);
  };


  var ToggleApis = Object.freeze({
  	onLoad: onLoad,
  	toggle: toggle$2,
  	isOn: isOn,
  	on: on,
  	off: off
  });

  var exhibit = function (base, toggleConfig, toggleState) {
    return nu$6({});
  };
  var events$1 = function (toggleConfig, toggleState) {
    var execute = executeEvent(toggleConfig, toggleState, toggle$2);
    var load = loadEvent(toggleConfig, toggleState, onLoad);
    return derive($_efmt4zxbjfuw8tcj.flatten([
      toggleConfig.toggleOnExecute() ? [execute] : [],
      [load]
    ]));
  };


  var ActiveToggle = Object.freeze({
  	exhibit: exhibit,
  	events: events$1
  });

  var updatePressed = function (component, ariaInfo, status) {
    $_47adx7ywjfuw8tl3.set(component.element(), 'aria-pressed', status);
    if (ariaInfo.syncWithExpanded()) {
      updateExpanded(component, ariaInfo, status);
    }
  };
  var updateSelected = function (component, ariaInfo, status) {
    $_47adx7ywjfuw8tl3.set(component.element(), 'aria-selected', status);
  };
  var updateChecked = function (component, ariaInfo, status) {
    $_47adx7ywjfuw8tl3.set(component.element(), 'aria-checked', status);
  };
  var updateExpanded = function (component, ariaInfo, status) {
    $_47adx7ywjfuw8tl3.set(component.element(), 'aria-expanded', status);
  };

  var ToggleSchema = [
    defaulted$1('selected', false),
    strict$1('toggleClass'),
    defaulted$1('toggleOnExecute', true),
    defaultedOf('aria', { mode: 'none' }, choose$1('mode', {
      pressed: [
        defaulted$1('syncWithExpanded', false),
        output$1('update', updatePressed)
      ],
      checked: [output$1('update', updateChecked)],
      expanded: [output$1('update', updateExpanded)],
      selected: [output$1('update', updateSelected)],
      none: [output$1('update', $_2vokfcwwjfuw8tb4.noop)]
    }))
  ];

  var Toggling = create$1({
    fields: ToggleSchema,
    name: 'toggling',
    active: ActiveToggle,
    apis: ToggleApis
  });

  var format = function (command, update) {
    return Receiving.config({
      channels: wrap$2($_9e19stz9jfuw8tmf.formatChanged(), {
        onReceive: function (button, data) {
          if (data.command === command) {
            update(button, data.state);
          }
        }
      })
    });
  };
  var orientation = function (onReceive) {
    return Receiving.config({ channels: wrap$2($_9e19stz9jfuw8tmf.orientationChanged(), { onReceive: onReceive }) });
  };
  var receive$1 = function (channel, onReceive) {
    return {
      key: channel,
      value: { onReceive: onReceive }
    };
  };
  var $_9de9iyzsjfuw8tqa = {
    format: format,
    orientation: orientation,
    receive: receive$1
  };

  var prefix = 'tinymce-mobile';
  var resolve$1 = function (p) {
    return prefix + '-' + p;
  };
  var $_2fp9skztjfuw8tqe = {
    resolve: resolve$1,
    prefix: $_2vokfcwwjfuw8tb4.constant(prefix)
  };

  var events$2 = function (optAction) {
    var executeHandler = function (action) {
      return run(execute(), function (component, simulatedEvent) {
        action(component);
        simulatedEvent.stop();
      });
    };
    var onClick = function (component, simulatedEvent) {
      simulatedEvent.stop();
      emitExecute(component);
    };
    var onMousedown = function (component, simulatedEvent) {
      simulatedEvent.cut();
    };
    var pointerEvents = $_5reqwox3jfuw8tbu.detect().deviceType.isTouch() ? [run(tap(), onClick)] : [
      run(click(), onClick),
      run(mousedown(), onMousedown)
    ];
    return derive($_efmt4zxbjfuw8tcj.flatten([
      optAction.map(executeHandler).toArray(),
      pointerEvents
    ]));
  };

  var focus$3 = function (component, focusConfig) {
    if (!focusConfig.ignore()) {
      $_f15fvwz1jfuw8tlo.focus(component.element());
      focusConfig.onFocus()(component);
    }
  };
  var blur$1 = function (component, focusConfig) {
    if (!focusConfig.ignore()) {
      $_f15fvwz1jfuw8tlo.blur(component.element());
    }
  };
  var isFocused = function (component) {
    return $_f15fvwz1jfuw8tlo.hasFocus(component.element());
  };


  var FocusApis = Object.freeze({
  	focus: focus$3,
  	blur: blur$1,
  	isFocused: isFocused
  });

  var exhibit$1 = function (base, focusConfig) {
    if (focusConfig.ignore()) {
      return nu$6({});
    } else {
      return nu$6({ attributes: { tabindex: '-1' } });
    }
  };
  var events$3 = function (focusConfig) {
    return derive([run(focus$1(), function (component, simulatedEvent) {
        focus$3(component, focusConfig);
        simulatedEvent.stop();
      })]);
  };


  var ActiveFocus = Object.freeze({
  	exhibit: exhibit$1,
  	events: events$3
  });

  var FocusSchema = [
    onHandler('onFocus'),
    defaulted$1('ignore', false)
  ];

  var Focusing = create$1({
    fields: FocusSchema,
    name: 'focusing',
    active: ActiveFocus,
    apis: FocusApis
  });

  var isSupported = function (dom) {
    return dom.style !== undefined;
  };
  var $_9wm1ea107jfuw8tss = { isSupported: isSupported };

  var internalSet = function (dom, property, value) {
    if (!$_8aqeo3wyjfuw8tb8.isString(value)) {
      console.error('Invalid call to CSS.set. Property ', property, ':: Value ', value, ':: Element ', dom);
      throw new Error('CSS value must be a string: ' + value);
    }
    if ($_9wm1ea107jfuw8tss.isSupported(dom))
      dom.style.setProperty(property, value);
  };
  var internalRemove = function (dom, property) {
    if ($_9wm1ea107jfuw8tss.isSupported(dom))
      dom.style.removeProperty(property);
  };
  var set$2 = function (element, property, value) {
    var dom = element.dom();
    internalSet(dom, property, value);
  };
  var setAll$1 = function (element, css) {
    var dom = element.dom();
    $_8qu224wzjfuw8tb9.each(css, function (v, k) {
      internalSet(dom, k, v);
    });
  };
  var setOptions = function (element, css) {
    var dom = element.dom();
    $_8qu224wzjfuw8tb9.each(css, function (v, k) {
      v.fold(function () {
        internalRemove(dom, k);
      }, function (value) {
        internalSet(dom, k, value);
      });
    });
  };
  var get$3 = function (element, property) {
    var dom = element.dom();
    var styles = window.getComputedStyle(dom);
    var r = styles.getPropertyValue(property);
    var v = r === '' && !$_8634tqxhjfuw8tdl.inBody(element) ? getUnsafeProperty(dom, property) : r;
    return v === null ? undefined : v;
  };
  var getUnsafeProperty = function (dom, property) {
    return $_9wm1ea107jfuw8tss.isSupported(dom) ? dom.style.getPropertyValue(property) : '';
  };
  var getRaw = function (element, property) {
    var dom = element.dom();
    var raw = getUnsafeProperty(dom, property);
    return Option.from(raw).filter(function (r) {
      return r.length > 0;
    });
  };
  var getAllRaw = function (element) {
    var css = {};
    var dom = element.dom();
    if ($_9wm1ea107jfuw8tss.isSupported(dom)) {
      for (var i = 0; i < dom.style.length; i++) {
        var ruleName = dom.style.item(i);
        css[ruleName] = dom.style[ruleName];
      }
    }
    return css;
  };
  var isValidValue = function (tag, property, value) {
    var element = $_bwdnu0xijfuw8tdo.fromTag(tag);
    set$2(element, property, value);
    var style = getRaw(element, property);
    return style.isSome();
  };
  var remove$5 = function (element, property) {
    var dom = element.dom();
    internalRemove(dom, property);
    if ($_47adx7ywjfuw8tl3.has(element, 'style') && $_b463kaxdjfuw8tcv.trim($_47adx7ywjfuw8tl3.get(element, 'style')) === '') {
      $_47adx7ywjfuw8tl3.remove(element, 'style');
    }
  };
  var preserve = function (element, f) {
    var oldStyles = $_47adx7ywjfuw8tl3.get(element, 'style');
    var result = f(element);
    var restore = oldStyles === undefined ? $_47adx7ywjfuw8tl3.remove : $_47adx7ywjfuw8tl3.set;
    restore(element, 'style', oldStyles);
    return result;
  };
  var copy$1 = function (source, target) {
    var sourceDom = source.dom();
    var targetDom = target.dom();
    if ($_9wm1ea107jfuw8tss.isSupported(sourceDom) && $_9wm1ea107jfuw8tss.isSupported(targetDom)) {
      targetDom.style.cssText = sourceDom.style.cssText;
    }
  };
  var reflow = function (e) {
    return e.dom().offsetWidth;
  };
  var transferOne$1 = function (source, destination, style) {
    getRaw(source, style).each(function (value) {
      if (getRaw(destination, style).isNone())
        set$2(destination, style, value);
    });
  };
  var transfer$1 = function (source, destination, styles) {
    if (!$_74lhjaxjjfuw8tdt.isElement(source) || !$_74lhjaxjjfuw8tdt.isElement(destination))
      return;
    $_efmt4zxbjfuw8tcj.each(styles, function (style) {
      transferOne$1(source, destination, style);
    });
  };
  var $_aag5ti106jfuw8tse = {
    copy: copy$1,
    set: set$2,
    preserve: preserve,
    setAll: setAll$1,
    setOptions: setOptions,
    remove: remove$5,
    get: get$3,
    getRaw: getRaw,
    getAllRaw: getAllRaw,
    isValidValue: isValidValue,
    reflow: reflow,
    transfer: transfer$1
  };

  function Dimension (name, getOffset) {
    var set = function (element, h) {
      if (!$_8aqeo3wyjfuw8tb8.isNumber(h) && !h.match(/^[0-9]+$/))
        throw name + '.set accepts only positive integer values. Value was ' + h;
      var dom = element.dom();
      if ($_9wm1ea107jfuw8tss.isSupported(dom))
        dom.style[name] = h + 'px';
    };
    var get = function (element) {
      var r = getOffset(element);
      if (r <= 0 || r === null) {
        var css = $_aag5ti106jfuw8tse.get(element, name);
        return parseFloat(css) || 0;
      }
      return r;
    };
    var getOuter = get;
    var aggregate = function (element, properties) {
      return $_efmt4zxbjfuw8tcj.foldl(properties, function (acc, property) {
        var val = $_aag5ti106jfuw8tse.get(element, property);
        var value = val === undefined ? 0 : parseInt(val, 10);
        return isNaN(value) ? acc : acc + value;
      }, 0);
    };
    var max = function (element, value, properties) {
      var cumulativeInclusions = aggregate(element, properties);
      var absoluteMax = value > cumulativeInclusions ? value - cumulativeInclusions : 0;
      return absoluteMax;
    };
    return {
      set: set,
      get: get,
      getOuter: getOuter,
      aggregate: aggregate,
      max: max
    };
  }

  var api = Dimension('height', function (element) {
    return $_8634tqxhjfuw8tdl.inBody(element) ? element.dom().getBoundingClientRect().height : element.dom().offsetHeight;
  });
  var set$3 = function (element, h) {
    api.set(element, h);
  };
  var get$4 = function (element) {
    return api.get(element);
  };
  var getOuter$1 = function (element) {
    return api.getOuter(element);
  };
  var setMax = function (element, value) {
    var inclusions = [
      'margin-top',
      'border-top-width',
      'padding-top',
      'padding-bottom',
      'border-bottom-width',
      'margin-bottom'
    ];
    var absMax = api.max(element, value, inclusions);
    $_aag5ti106jfuw8tse.set(element, 'max-height', absMax + 'px');
  };
  var $_sgteu105jfuw8tsc = {
    set: set$3,
    get: get$4,
    getOuter: getOuter$1,
    setMax: setMax
  };

  var all$2 = function (predicate) {
    return descendants($_8634tqxhjfuw8tdl.body(), predicate);
  };
  var ancestors = function (scope, predicate, isRoot) {
    return $_efmt4zxbjfuw8tcj.filter($_aff64dxmjfuw8tdx.parents(scope, isRoot), predicate);
  };
  var siblings$1 = function (scope, predicate) {
    return $_efmt4zxbjfuw8tcj.filter($_aff64dxmjfuw8tdx.siblings(scope), predicate);
  };
  var children$1 = function (scope, predicate) {
    return $_efmt4zxbjfuw8tcj.filter($_aff64dxmjfuw8tdx.children(scope), predicate);
  };
  var descendants = function (scope, predicate) {
    var result = [];
    $_efmt4zxbjfuw8tcj.each($_aff64dxmjfuw8tdx.children(scope), function (x) {
      if (predicate(x)) {
        result = result.concat([x]);
      }
      result = result.concat(descendants(x, predicate));
    });
    return result;
  };
  var $_94lmux10ajfuw8tt4 = {
    all: all$2,
    ancestors: ancestors,
    siblings: siblings$1,
    children: children$1,
    descendants: descendants
  };

  var all$3 = function (selector) {
    return $_gem9gixxjfuw8tey.all(selector);
  };
  var ancestors$1 = function (scope, selector, isRoot) {
    return $_94lmux10ajfuw8tt4.ancestors(scope, function (e) {
      return $_gem9gixxjfuw8tey.is(e, selector);
    }, isRoot);
  };
  var siblings$2 = function (scope, selector) {
    return $_94lmux10ajfuw8tt4.siblings(scope, function (e) {
      return $_gem9gixxjfuw8tey.is(e, selector);
    });
  };
  var children$2 = function (scope, selector) {
    return $_94lmux10ajfuw8tt4.children(scope, function (e) {
      return $_gem9gixxjfuw8tey.is(e, selector);
    });
  };
  var descendants$1 = function (scope, selector) {
    return $_gem9gixxjfuw8tey.all(selector, scope);
  };
  var $_951f03109jfuw8tt3 = {
    all: all$3,
    ancestors: ancestors$1,
    siblings: siblings$2,
    children: children$2,
    descendants: descendants$1
  };

  var first$2 = function (selector) {
    return $_gem9gixxjfuw8tey.one(selector);
  };
  var ancestor$2 = function (scope, selector, isRoot) {
    return $_d0h9pzz3jfuw8tlv.ancestor(scope, function (e) {
      return $_gem9gixxjfuw8tey.is(e, selector);
    }, isRoot);
  };
  var sibling$2 = function (scope, selector) {
    return $_d0h9pzz3jfuw8tlv.sibling(scope, function (e) {
      return $_gem9gixxjfuw8tey.is(e, selector);
    });
  };
  var child$3 = function (scope, selector) {
    return $_d0h9pzz3jfuw8tlv.child(scope, function (e) {
      return $_gem9gixxjfuw8tey.is(e, selector);
    });
  };
  var descendant$2 = function (scope, selector) {
    return $_gem9gixxjfuw8tey.one(selector, scope);
  };
  var closest$2 = function (scope, selector, isRoot) {
    return ClosestOrAncestor($_gem9gixxjfuw8tey.is, ancestor$2, scope, selector, isRoot);
  };
  var $_c8lemt10bjfuw8tt8 = {
    first: first$2,
    ancestor: ancestor$2,
    sibling: sibling$2,
    child: child$3,
    descendant: descendant$2,
    closest: closest$2
  };

  var $_cy6bab10cjfuw8tt9 = {
    BACKSPACE: $_2vokfcwwjfuw8tb4.constant([8]),
    TAB: $_2vokfcwwjfuw8tb4.constant([9]),
    ENTER: $_2vokfcwwjfuw8tb4.constant([13]),
    SHIFT: $_2vokfcwwjfuw8tb4.constant([16]),
    CTRL: $_2vokfcwwjfuw8tb4.constant([17]),
    ALT: $_2vokfcwwjfuw8tb4.constant([18]),
    CAPSLOCK: $_2vokfcwwjfuw8tb4.constant([20]),
    ESCAPE: $_2vokfcwwjfuw8tb4.constant([27]),
    SPACE: $_2vokfcwwjfuw8tb4.constant([32]),
    PAGEUP: $_2vokfcwwjfuw8tb4.constant([33]),
    PAGEDOWN: $_2vokfcwwjfuw8tb4.constant([34]),
    END: $_2vokfcwwjfuw8tb4.constant([35]),
    HOME: $_2vokfcwwjfuw8tb4.constant([36]),
    LEFT: $_2vokfcwwjfuw8tb4.constant([37]),
    UP: $_2vokfcwwjfuw8tb4.constant([38]),
    RIGHT: $_2vokfcwwjfuw8tb4.constant([39]),
    DOWN: $_2vokfcwwjfuw8tb4.constant([40]),
    INSERT: $_2vokfcwwjfuw8tb4.constant([45]),
    DEL: $_2vokfcwwjfuw8tb4.constant([46]),
    META: $_2vokfcwwjfuw8tb4.constant([
      91,
      93,
      224
    ]),
    F10: $_2vokfcwwjfuw8tb4.constant([121])
  };

  var cyclePrev = function (values, index, predicate) {
    var before = $_efmt4zxbjfuw8tcj.reverse(values.slice(0, index));
    var after = $_efmt4zxbjfuw8tcj.reverse(values.slice(index + 1));
    return $_efmt4zxbjfuw8tcj.find(before.concat(after), predicate);
  };
  var tryPrev = function (values, index, predicate) {
    var before = $_efmt4zxbjfuw8tcj.reverse(values.slice(0, index));
    return $_efmt4zxbjfuw8tcj.find(before, predicate);
  };
  var cycleNext = function (values, index, predicate) {
    var before = values.slice(0, index);
    var after = values.slice(index + 1);
    return $_efmt4zxbjfuw8tcj.find(after.concat(before), predicate);
  };
  var tryNext = function (values, index, predicate) {
    var after = values.slice(index + 1);
    return $_efmt4zxbjfuw8tcj.find(after, predicate);
  };

  var inSet = function (keys) {
    return function (event) {
      return $_efmt4zxbjfuw8tcj.contains(keys, event.raw().which);
    };
  };
  var and = function (preds) {
    return function (event) {
      return $_efmt4zxbjfuw8tcj.forall(preds, function (pred) {
        return pred(event);
      });
    };
  };
  var isShift = function (event) {
    return event.raw().shiftKey === true;
  };
  var isControl = function (event) {
    return event.raw().ctrlKey === true;
  };
  var isNotControl = $_2vokfcwwjfuw8tb4.not(isControl);
  var isNotShift = $_2vokfcwwjfuw8tb4.not(isShift);

  var rule = function (matches, action) {
    return {
      matches: matches,
      classification: action
    };
  };
  var choose$2 = function (transitions, event) {
    var transition = $_efmt4zxbjfuw8tcj.find(transitions, function (t) {
      return t.matches(event);
    });
    return transition.map(function (t) {
      return t.classification;
    });
  };

  var cycleBy = function (value, delta, min, max) {
    var r = value + delta;
    if (r > max) {
      return min;
    } else {
      return r < min ? max : r;
    }
  };
  var cap = function (value, min, max) {
    if (value <= min) {
      return min;
    } else {
      return value >= max ? max : value;
    }
  };

  var dehighlightAll = function (component, hConfig, hState) {
    var highlighted = $_951f03109jfuw8tt3.descendants(component.element(), '.' + hConfig.highlightClass());
    $_efmt4zxbjfuw8tcj.each(highlighted, function (h) {
      $_6po7jxyujfuw8tl0.remove(h, hConfig.highlightClass());
      component.getSystem().getByDom(h).each(function (target) {
        hConfig.onDehighlight()(component, target);
      });
    });
  };
  var dehighlight = function (component, hConfig, hState, target) {
    var wasHighlighted = isHighlighted(component, hConfig, hState, target);
    $_6po7jxyujfuw8tl0.remove(target.element(), hConfig.highlightClass());
    if (wasHighlighted) {
      hConfig.onDehighlight()(component, target);
    }
  };
  var highlight = function (component, hConfig, hState, target) {
    var wasHighlighted = isHighlighted(component, hConfig, hState, target);
    dehighlightAll(component, hConfig, hState);
    $_6po7jxyujfuw8tl0.add(target.element(), hConfig.highlightClass());
    if (!wasHighlighted) {
      hConfig.onHighlight()(component, target);
    }
  };
  var highlightFirst = function (component, hConfig, hState) {
    getFirst(component, hConfig, hState).each(function (firstComp) {
      highlight(component, hConfig, hState, firstComp);
    });
  };
  var highlightLast = function (component, hConfig, hState) {
    getLast(component, hConfig, hState).each(function (lastComp) {
      highlight(component, hConfig, hState, lastComp);
    });
  };
  var highlightAt = function (component, hConfig, hState, index) {
    getByIndex(component, hConfig, hState, index).fold(function (err) {
      throw new Error(err);
    }, function (firstComp) {
      highlight(component, hConfig, hState, firstComp);
    });
  };
  var highlightBy = function (component, hConfig, hState, predicate) {
    var items = $_951f03109jfuw8tt3.descendants(component.element(), '.' + hConfig.itemClass());
    var itemComps = $_e8fwikzljfuw8tp3.cat($_efmt4zxbjfuw8tcj.map(items, function (i) {
      return component.getSystem().getByDom(i).toOption();
    }));
    var targetComp = $_efmt4zxbjfuw8tcj.find(itemComps, predicate);
    targetComp.each(function (c) {
      highlight(component, hConfig, hState, c);
    });
  };
  var isHighlighted = function (component, hConfig, hState, queryTarget) {
    return $_6po7jxyujfuw8tl0.has(queryTarget.element(), hConfig.highlightClass());
  };
  var getHighlighted = function (component, hConfig, hState) {
    return $_c8lemt10bjfuw8tt8.descendant(component.element(), '.' + hConfig.highlightClass()).bind(component.getSystem().getByDom);
  };
  var getByIndex = function (component, hConfig, hState, index) {
    var items = $_951f03109jfuw8tt3.descendants(component.element(), '.' + hConfig.itemClass());
    return Option.from(items[index]).fold(function () {
      return Result.error('No element found with index ' + index);
    }, component.getSystem().getByDom);
  };
  var getFirst = function (component, hConfig, hState) {
    return $_c8lemt10bjfuw8tt8.descendant(component.element(), '.' + hConfig.itemClass()).bind(component.getSystem().getByDom);
  };
  var getLast = function (component, hConfig, hState) {
    var items = $_951f03109jfuw8tt3.descendants(component.element(), '.' + hConfig.itemClass());
    var last = items.length > 0 ? Option.some(items[items.length - 1]) : Option.none();
    return last.bind(component.getSystem().getByDom);
  };
  var getDelta = function (component, hConfig, hState, delta) {
    var items = $_951f03109jfuw8tt3.descendants(component.element(), '.' + hConfig.itemClass());
    var current = $_efmt4zxbjfuw8tcj.findIndex(items, function (item) {
      return $_6po7jxyujfuw8tl0.has(item, hConfig.highlightClass());
    });
    return current.bind(function (selected) {
      var dest = cycleBy(selected, delta, 0, items.length - 1);
      return component.getSystem().getByDom(items[dest]);
    });
  };
  var getPrevious = function (component, hConfig, hState) {
    return getDelta(component, hConfig, hState, -1);
  };
  var getNext = function (component, hConfig, hState) {
    return getDelta(component, hConfig, hState, +1);
  };


  var HighlightApis = Object.freeze({
  	dehighlightAll: dehighlightAll,
  	dehighlight: dehighlight,
  	highlight: highlight,
  	highlightFirst: highlightFirst,
  	highlightLast: highlightLast,
  	highlightAt: highlightAt,
  	highlightBy: highlightBy,
  	isHighlighted: isHighlighted,
  	getHighlighted: getHighlighted,
  	getFirst: getFirst,
  	getLast: getLast,
  	getPrevious: getPrevious,
  	getNext: getNext
  });

  var HighlightSchema = [
    strict$1('highlightClass'),
    strict$1('itemClass'),
    onHandler('onHighlight'),
    onHandler('onDehighlight')
  ];

  var Highlighting = create$1({
    fields: HighlightSchema,
    name: 'highlighting',
    apis: HighlightApis
  });

  var dom = function () {
    var get = function (component) {
      return $_f15fvwz1jfuw8tlo.search(component.element());
    };
    var set = function (component, focusee) {
      component.getSystem().triggerFocus(focusee, component.element());
    };
    return {
      get: get,
      set: set
    };
  };
  var highlights = function () {
    var get = function (component) {
      return Highlighting.getHighlighted(component).map(function (item) {
        return item.element();
      });
    };
    var set = function (component, element) {
      component.getSystem().getByDom(element).fold($_2vokfcwwjfuw8tb4.noop, function (item) {
        Highlighting.highlight(component, item);
      });
    };
    return {
      get: get,
      set: set
    };
  };

  var typical = function (infoSchema, stateInit, getRules, getEvents, getApis, optFocusIn) {
    var schema = function () {
      return infoSchema.concat([
        defaulted$1('focusManager', dom()),
        output$1('handler', me),
        output$1('state', stateInit)
      ]);
    };
    var processKey = function (component, simulatedEvent, keyingConfig, keyingState) {
      var rules = getRules(component, simulatedEvent, keyingConfig, keyingState);
      return choose$2(rules, simulatedEvent.event()).bind(function (rule$$1) {
        return rule$$1(component, simulatedEvent, keyingConfig, keyingState);
      });
    };
    var toEvents = function (keyingConfig, keyingState) {
      var otherEvents = getEvents(keyingConfig, keyingState);
      var keyEvents = derive(optFocusIn.map(function (focusIn) {
        return run(focus$1(), function (component, simulatedEvent) {
          focusIn(component, keyingConfig, keyingState, simulatedEvent);
          simulatedEvent.stop();
        });
      }).toArray().concat([run(keydown(), function (component, simulatedEvent) {
          processKey(component, simulatedEvent, keyingConfig, keyingState).each(function (_) {
            simulatedEvent.stop();
          });
        })]));
      return $_3jctjywxjfuw8tb6.deepMerge(otherEvents, keyEvents);
    };
    var me = {
      schema: schema,
      processKey: processKey,
      toEvents: toEvents,
      toApis: getApis
    };
    return me;
  };

  var create$2 = function (cyclicField) {
    var schema = [
      option('onEscape'),
      option('onEnter'),
      defaulted$1('selector', '[data-alloy-tabstop="true"]'),
      defaulted$1('firstTabstop', 0),
      defaulted$1('useTabstopAt', $_2vokfcwwjfuw8tb4.constant(true)),
      option('visibilitySelector')
    ].concat([cyclicField]);
    var isVisible = function (tabbingConfig, element) {
      var target = tabbingConfig.visibilitySelector().bind(function (sel) {
        return $_c8lemt10bjfuw8tt8.closest(element, sel);
      }).getOr(element);
      return $_sgteu105jfuw8tsc.get(target) > 0;
    };
    var findInitial = function (component, tabbingConfig) {
      var tabstops = $_951f03109jfuw8tt3.descendants(component.element(), tabbingConfig.selector());
      var visibles = $_efmt4zxbjfuw8tcj.filter(tabstops, function (elem) {
        return isVisible(tabbingConfig, elem);
      });
      return Option.from(visibles[tabbingConfig.firstTabstop()]);
    };
    var findCurrent = function (component, tabbingConfig) {
      return tabbingConfig.focusManager().get(component).bind(function (elem) {
        return $_c8lemt10bjfuw8tt8.closest(elem, tabbingConfig.selector());
      });
    };
    var isTabstop = function (tabbingConfig, element) {
      return isVisible(tabbingConfig, element) && tabbingConfig.useTabstopAt()(element);
    };
    var focusIn = function (component, tabbingConfig, tabbingState) {
      findInitial(component, tabbingConfig).each(function (target) {
        tabbingConfig.focusManager().set(component, target);
      });
    };
    var goFromTabstop = function (component, tabstops, stopIndex, tabbingConfig, cycle) {
      return cycle(tabstops, stopIndex, function (elem) {
        return isTabstop(tabbingConfig, elem);
      }).fold(function () {
        return tabbingConfig.cyclic() ? Option.some(true) : Option.none();
      }, function (target) {
        tabbingConfig.focusManager().set(component, target);
        return Option.some(true);
      });
    };
    var go = function (component, simulatedEvent, tabbingConfig, cycle) {
      var tabstops = $_951f03109jfuw8tt3.descendants(component.element(), tabbingConfig.selector());
      return findCurrent(component, tabbingConfig).bind(function (tabstop) {
        var optStopIndex = $_efmt4zxbjfuw8tcj.findIndex(tabstops, $_2vokfcwwjfuw8tb4.curry($_4867a0xsjfuw8tej.eq, tabstop));
        return optStopIndex.bind(function (stopIndex) {
          return goFromTabstop(component, tabstops, stopIndex, tabbingConfig, cycle);
        });
      });
    };
    var goBackwards = function (component, simulatedEvent, tabbingConfig, tabbingState) {
      var navigate = tabbingConfig.cyclic() ? cyclePrev : tryPrev;
      return go(component, simulatedEvent, tabbingConfig, navigate);
    };
    var goForwards = function (component, simulatedEvent, tabbingConfig, tabbingState) {
      var navigate = tabbingConfig.cyclic() ? cycleNext : tryNext;
      return go(component, simulatedEvent, tabbingConfig, navigate);
    };
    var execute = function (component, simulatedEvent, tabbingConfig, tabbingState) {
      return tabbingConfig.onEnter().bind(function (f) {
        return f(component, simulatedEvent);
      });
    };
    var exit = function (component, simulatedEvent, tabbingConfig, tabbingState) {
      return tabbingConfig.onEscape().bind(function (f) {
        return f(component, simulatedEvent);
      });
    };
    var getRules = $_2vokfcwwjfuw8tb4.constant([
      rule(and([
        isShift,
        inSet($_cy6bab10cjfuw8tt9.TAB())
      ]), goBackwards),
      rule(inSet($_cy6bab10cjfuw8tt9.TAB()), goForwards),
      rule(inSet($_cy6bab10cjfuw8tt9.ESCAPE()), exit),
      rule(and([
        isNotShift,
        inSet($_cy6bab10cjfuw8tt9.ENTER())
      ]), execute)
    ]);
    var getEvents = $_2vokfcwwjfuw8tb4.constant({});
    var getApis = $_2vokfcwwjfuw8tb4.constant({});
    return typical(schema, init, getRules, getEvents, getApis, Option.some(focusIn));
  };

  var AcyclicType = create$2(state$1('cyclic', $_2vokfcwwjfuw8tb4.constant(false)));

  var CyclicType = create$2(state$1('cyclic', $_2vokfcwwjfuw8tb4.constant(true)));

  var inside = function (target) {
    return $_74lhjaxjjfuw8tdt.name(target) === 'input' && $_47adx7ywjfuw8tl3.get(target, 'type') !== 'radio' || $_74lhjaxjjfuw8tdt.name(target) === 'textarea';
  };

  var doDefaultExecute = function (component, simulatedEvent, focused) {
    dispatch(component, focused, execute());
    return Option.some(true);
  };
  var defaultExecute = function (component, simulatedEvent, focused) {
    return inside(focused) && inSet($_cy6bab10cjfuw8tt9.SPACE())(simulatedEvent.event()) ? Option.none() : doDefaultExecute(component, simulatedEvent, focused);
  };

  var schema$1 = [
    defaulted$1('execute', defaultExecute),
    defaulted$1('useSpace', false),
    defaulted$1('useEnter', true),
    defaulted$1('useControlEnter', false),
    defaulted$1('useDown', false)
  ];
  var execute$1 = function (component, simulatedEvent, executeConfig, executeState) {
    return executeConfig.execute()(component, simulatedEvent, component.element());
  };
  var getRules = function (component, simulatedEvent, executeConfig, executeState) {
    var spaceExec = executeConfig.useSpace() && !inside(component.element()) ? $_cy6bab10cjfuw8tt9.SPACE() : [];
    var enterExec = executeConfig.useEnter() ? $_cy6bab10cjfuw8tt9.ENTER() : [];
    var downExec = executeConfig.useDown() ? $_cy6bab10cjfuw8tt9.DOWN() : [];
    var execKeys = spaceExec.concat(enterExec).concat(downExec);
    return [rule(inSet(execKeys), execute$1)].concat(executeConfig.useControlEnter() ? [rule(and([
        isControl,
        inSet($_cy6bab10cjfuw8tt9.ENTER())
      ]), execute$1)] : []);
  };
  var getEvents = $_2vokfcwwjfuw8tb4.constant({});
  var getApis = $_2vokfcwwjfuw8tb4.constant({});
  var ExecutionType = typical(schema$1, init, getRules, getEvents, getApis, Option.none());

  var flatgrid = function (spec) {
    var dimensions = Cell(Option.none());
    var setGridSize = function (numRows, numColumns) {
      dimensions.set(Option.some({
        numRows: $_2vokfcwwjfuw8tb4.constant(numRows),
        numColumns: $_2vokfcwwjfuw8tb4.constant(numColumns)
      }));
    };
    var getNumRows = function () {
      return dimensions.get().map(function (d) {
        return d.numRows();
      });
    };
    var getNumColumns = function () {
      return dimensions.get().map(function (d) {
        return d.numColumns();
      });
    };
    return BehaviourState({
      readState: $_2vokfcwwjfuw8tb4.constant({}),
      setGridSize: setGridSize,
      getNumRows: getNumRows,
      getNumColumns: getNumColumns
    });
  };
  var init$1 = function (spec) {
    return spec.state()(spec);
  };


  var KeyingState = Object.freeze({
  	flatgrid: flatgrid,
  	init: init$1
  });

  var onDirection = function (isLtr, isRtl) {
    return function (element) {
      return getDirection(element) === 'rtl' ? isRtl : isLtr;
    };
  };
  var getDirection = function (element) {
    return $_aag5ti106jfuw8tse.get(element, 'direction') === 'rtl' ? 'rtl' : 'ltr';
  };
  var $_7wrg0f10tjfuw8tw7 = {
    onDirection: onDirection,
    getDirection: getDirection
  };

  var useH = function (movement) {
    return function (component, simulatedEvent, config, state) {
      var move = movement(component.element());
      return use(move, component, simulatedEvent, config, state);
    };
  };
  var west = function (moveLeft, moveRight) {
    var movement = $_7wrg0f10tjfuw8tw7.onDirection(moveLeft, moveRight);
    return useH(movement);
  };
  var east = function (moveLeft, moveRight) {
    var movement = $_7wrg0f10tjfuw8tw7.onDirection(moveRight, moveLeft);
    return useH(movement);
  };
  var useV = function (move) {
    return function (component, simulatedEvent, config, state) {
      return use(move, component, simulatedEvent, config, state);
    };
  };
  var use = function (move, component, simulatedEvent, config, state) {
    var outcome = config.focusManager().get(component).bind(function (focused) {
      return move(component.element(), focused, config, state);
    });
    return outcome.map(function (newFocus) {
      config.focusManager().set(component, newFocus);
      return true;
    });
  };
  var north = useV;
  var south = useV;
  var move = useV;

  var visibilityToggler = function (element, property, hiddenValue, visibleValue) {
    var initial = $_aag5ti106jfuw8tse.get(element, property);
    if (initial === undefined)
      initial = '';
    var value = initial === hiddenValue ? visibleValue : hiddenValue;
    var off = $_2vokfcwwjfuw8tb4.curry($_aag5ti106jfuw8tse.set, element, property, initial);
    var on = $_2vokfcwwjfuw8tb4.curry($_aag5ti106jfuw8tse.set, element, property, value);
    return Toggler(off, on, false);
  };
  var toggler$1 = function (element) {
    return visibilityToggler(element, 'visibility', 'hidden', 'visible');
  };
  var displayToggler = function (element, value) {
    return visibilityToggler(element, 'display', 'none', value);
  };
  var isHidden = function (dom) {
    return dom.offsetWidth <= 0 && dom.offsetHeight <= 0;
  };
  var isVisible = function (element) {
    var dom = element.dom();
    return !isHidden(dom);
  };
  var $_cdppfu10vjfuw8twl = {
    toggler: toggler$1,
    displayToggler: displayToggler,
    isVisible: isVisible
  };

  var indexInfo = $_4xhupwxnjfuw8tea.immutableBag([
    'index',
    'candidates'
  ], []);
  var locate = function (candidates, predicate) {
    return $_efmt4zxbjfuw8tcj.findIndex(candidates, predicate).map(function (index) {
      return indexInfo({
        index: index,
        candidates: candidates
      });
    });
  };

  var locateVisible = function (container, current, selector) {
    var filter = $_cdppfu10vjfuw8twl.isVisible;
    return locateIn(container, current, selector, filter);
  };
  var locateIn = function (container, current, selector, filter) {
    var predicate = $_2vokfcwwjfuw8tb4.curry($_4867a0xsjfuw8tej.eq, current);
    var candidates = $_951f03109jfuw8tt3.descendants(container, selector);
    var visible = $_efmt4zxbjfuw8tcj.filter(candidates, $_cdppfu10vjfuw8twl.isVisible);
    return locate(visible, predicate);
  };
  var findIndex$2 = function (elements, target) {
    return $_efmt4zxbjfuw8tcj.findIndex(elements, function (elem) {
      return $_4867a0xsjfuw8tej.eq(target, elem);
    });
  };

  var withGrid = function (values, index, numCols, f) {
    var oldRow = Math.floor(index / numCols);
    var oldColumn = index % numCols;
    return f(oldRow, oldColumn).bind(function (address) {
      var newIndex = address.row() * numCols + address.column();
      return newIndex >= 0 && newIndex < values.length ? Option.some(values[newIndex]) : Option.none();
    });
  };
  var cycleHorizontal = function (values, index, numRows, numCols, delta) {
    return withGrid(values, index, numCols, function (oldRow, oldColumn) {
      var onLastRow = oldRow === numRows - 1;
      var colsInRow = onLastRow ? values.length - oldRow * numCols : numCols;
      var newColumn = cycleBy(oldColumn, delta, 0, colsInRow - 1);
      return Option.some({
        row: $_2vokfcwwjfuw8tb4.constant(oldRow),
        column: $_2vokfcwwjfuw8tb4.constant(newColumn)
      });
    });
  };
  var cycleVertical = function (values, index, numRows, numCols, delta) {
    return withGrid(values, index, numCols, function (oldRow, oldColumn) {
      var newRow = cycleBy(oldRow, delta, 0, numRows - 1);
      var onLastRow = newRow === numRows - 1;
      var colsInRow = onLastRow ? values.length - newRow * numCols : numCols;
      var newCol = cap(oldColumn, 0, colsInRow - 1);
      return Option.some({
        row: $_2vokfcwwjfuw8tb4.constant(newRow),
        column: $_2vokfcwwjfuw8tb4.constant(newCol)
      });
    });
  };
  var cycleRight = function (values, index, numRows, numCols) {
    return cycleHorizontal(values, index, numRows, numCols, +1);
  };
  var cycleLeft = function (values, index, numRows, numCols) {
    return cycleHorizontal(values, index, numRows, numCols, -1);
  };
  var cycleUp = function (values, index, numRows, numCols) {
    return cycleVertical(values, index, numRows, numCols, -1);
  };
  var cycleDown = function (values, index, numRows, numCols) {
    return cycleVertical(values, index, numRows, numCols, +1);
  };

  var schema$2 = [
    strict$1('selector'),
    defaulted$1('execute', defaultExecute),
    onKeyboardHandler('onEscape'),
    defaulted$1('captureTab', false),
    initSize()
  ];
  var focusIn = function (component, gridConfig, gridState) {
    $_c8lemt10bjfuw8tt8.descendant(component.element(), gridConfig.selector()).each(function (first) {
      gridConfig.focusManager().set(component, first);
    });
  };
  var findCurrent = function (component, gridConfig) {
    return gridConfig.focusManager().get(component).bind(function (elem) {
      return $_c8lemt10bjfuw8tt8.closest(elem, gridConfig.selector());
    });
  };
  var execute$2 = function (component, simulatedEvent, gridConfig, gridState) {
    return findCurrent(component, gridConfig).bind(function (focused) {
      return gridConfig.execute()(component, simulatedEvent, focused);
    });
  };
  var doMove = function (cycle) {
    return function (element, focused, gridConfig, gridState) {
      return locateVisible(element, focused, gridConfig.selector()).bind(function (identified) {
        return cycle(identified.candidates(), identified.index(), gridState.getNumRows().getOr(gridConfig.initSize().numRows()), gridState.getNumColumns().getOr(gridConfig.initSize().numColumns()));
      });
    };
  };
  var handleTab = function (component, simulatedEvent, gridConfig, gridState) {
    return gridConfig.captureTab() ? Option.some(true) : Option.none();
  };
  var doEscape = function (component, simulatedEvent, gridConfig, gridState) {
    return gridConfig.onEscape()(component, simulatedEvent);
  };
  var moveLeft = doMove(cycleLeft);
  var moveRight = doMove(cycleRight);
  var moveNorth = doMove(cycleUp);
  var moveSouth = doMove(cycleDown);
  var getRules$1 = $_2vokfcwwjfuw8tb4.constant([
    rule(inSet($_cy6bab10cjfuw8tt9.LEFT()), west(moveLeft, moveRight)),
    rule(inSet($_cy6bab10cjfuw8tt9.RIGHT()), east(moveLeft, moveRight)),
    rule(inSet($_cy6bab10cjfuw8tt9.UP()), north(moveNorth)),
    rule(inSet($_cy6bab10cjfuw8tt9.DOWN()), south(moveSouth)),
    rule(and([
      isShift,
      inSet($_cy6bab10cjfuw8tt9.TAB())
    ]), handleTab),
    rule(and([
      isNotShift,
      inSet($_cy6bab10cjfuw8tt9.TAB())
    ]), handleTab),
    rule(inSet($_cy6bab10cjfuw8tt9.ESCAPE()), doEscape),
    rule(inSet($_cy6bab10cjfuw8tt9.SPACE().concat($_cy6bab10cjfuw8tt9.ENTER())), execute$2)
  ]);
  var getEvents$1 = $_2vokfcwwjfuw8tb4.constant({});
  var getApis$1 = {};
  var FlatgridType = typical(schema$2, flatgrid, getRules$1, getEvents$1, getApis$1, Option.some(focusIn));

  var horizontal = function (container, selector, current, delta) {
    return locateVisible(container, current, selector).bind(function (identified) {
      var index = identified.index();
      var candidates = identified.candidates();
      var newIndex = cycleBy(index, delta, 0, candidates.length - 1);
      return Option.from(candidates[newIndex]);
    });
  };

  var schema$3 = [
    strict$1('selector'),
    defaulted$1('getInitial', Option.none),
    defaulted$1('execute', defaultExecute),
    defaulted$1('executeOnMove', false)
  ];
  var findCurrent$1 = function (component, flowConfig) {
    return flowConfig.focusManager().get(component).bind(function (elem) {
      return $_c8lemt10bjfuw8tt8.closest(elem, flowConfig.selector());
    });
  };
  var execute$3 = function (component, simulatedEvent, flowConfig) {
    return findCurrent$1(component, flowConfig).bind(function (focused) {
      return flowConfig.execute()(component, simulatedEvent, focused);
    });
  };
  var focusIn$1 = function (component, flowConfig) {
    flowConfig.getInitial()(component).or($_c8lemt10bjfuw8tt8.descendant(component.element(), flowConfig.selector())).each(function (first) {
      flowConfig.focusManager().set(component, first);
    });
  };
  var moveLeft$1 = function (element, focused, info) {
    return horizontal(element, info.selector(), focused, -1);
  };
  var moveRight$1 = function (element, focused, info) {
    return horizontal(element, info.selector(), focused, +1);
  };
  var doMove$1 = function (movement) {
    return function (component, simulatedEvent, flowConfig) {
      return movement(component, simulatedEvent, flowConfig).bind(function () {
        return flowConfig.executeOnMove() ? execute$3(component, simulatedEvent, flowConfig) : Option.some(true);
      });
    };
  };
  var getRules$2 = function (_) {
    return [
      rule(inSet($_cy6bab10cjfuw8tt9.LEFT().concat($_cy6bab10cjfuw8tt9.UP())), doMove$1(west(moveLeft$1, moveRight$1))),
      rule(inSet($_cy6bab10cjfuw8tt9.RIGHT().concat($_cy6bab10cjfuw8tt9.DOWN())), doMove$1(east(moveLeft$1, moveRight$1))),
      rule(inSet($_cy6bab10cjfuw8tt9.ENTER()), execute$3),
      rule(inSet($_cy6bab10cjfuw8tt9.SPACE()), execute$3)
    ];
  };
  var getEvents$2 = $_2vokfcwwjfuw8tb4.constant({});
  var getApis$2 = $_2vokfcwwjfuw8tb4.constant({});
  var FlowType = typical(schema$3, init, getRules$2, getEvents$2, getApis$2, Option.some(focusIn$1));

  var outcome = $_4xhupwxnjfuw8tea.immutableBag([
    'rowIndex',
    'columnIndex',
    'cell'
  ], []);
  var toCell = function (matrix, rowIndex, columnIndex) {
    return Option.from(matrix[rowIndex]).bind(function (row) {
      return Option.from(row[columnIndex]).map(function (cell) {
        return outcome({
          rowIndex: rowIndex,
          columnIndex: columnIndex,
          cell: cell
        });
      });
    });
  };
  var cycleHorizontal$1 = function (matrix, rowIndex, startCol, deltaCol) {
    var row = matrix[rowIndex];
    var colsInRow = row.length;
    var newColIndex = cycleBy(startCol, deltaCol, 0, colsInRow - 1);
    return toCell(matrix, rowIndex, newColIndex);
  };
  var cycleVertical$1 = function (matrix, colIndex, startRow, deltaRow) {
    var nextRowIndex = cycleBy(startRow, deltaRow, 0, matrix.length - 1);
    var colsInNextRow = matrix[nextRowIndex].length;
    var nextColIndex = cap(colIndex, 0, colsInNextRow - 1);
    return toCell(matrix, nextRowIndex, nextColIndex);
  };
  var moveHorizontal = function (matrix, rowIndex, startCol, deltaCol) {
    var row = matrix[rowIndex];
    var colsInRow = row.length;
    var newColIndex = cap(startCol + deltaCol, 0, colsInRow - 1);
    return toCell(matrix, rowIndex, newColIndex);
  };
  var moveVertical = function (matrix, colIndex, startRow, deltaRow) {
    var nextRowIndex = cap(startRow + deltaRow, 0, matrix.length - 1);
    var colsInNextRow = matrix[nextRowIndex].length;
    var nextColIndex = cap(colIndex, 0, colsInNextRow - 1);
    return toCell(matrix, nextRowIndex, nextColIndex);
  };
  var cycleRight$1 = function (matrix, startRow, startCol) {
    return cycleHorizontal$1(matrix, startRow, startCol, +1);
  };
  var cycleLeft$1 = function (matrix, startRow, startCol) {
    return cycleHorizontal$1(matrix, startRow, startCol, -1);
  };
  var cycleUp$1 = function (matrix, startRow, startCol) {
    return cycleVertical$1(matrix, startCol, startRow, -1);
  };
  var cycleDown$1 = function (matrix, startRow, startCol) {
    return cycleVertical$1(matrix, startCol, startRow, +1);
  };
  var moveLeft$2 = function (matrix, startRow, startCol) {
    return moveHorizontal(matrix, startRow, startCol, -1);
  };
  var moveRight$2 = function (matrix, startRow, startCol) {
    return moveHorizontal(matrix, startRow, startCol, +1);
  };
  var moveUp = function (matrix, startRow, startCol) {
    return moveVertical(matrix, startCol, startRow, -1);
  };
  var moveDown = function (matrix, startRow, startCol) {
    return moveVertical(matrix, startCol, startRow, +1);
  };

  var schema$4 = [
    strictObjOf('selectors', [
      strict$1('row'),
      strict$1('cell')
    ]),
    defaulted$1('cycles', true),
    defaulted$1('previousSelector', Option.none),
    defaulted$1('execute', defaultExecute)
  ];
  var focusIn$2 = function (component, matrixConfig) {
    var focused = matrixConfig.previousSelector()(component).orThunk(function () {
      var selectors = matrixConfig.selectors();
      return $_c8lemt10bjfuw8tt8.descendant(component.element(), selectors.cell());
    });
    focused.each(function (cell) {
      matrixConfig.focusManager().set(component, cell);
    });
  };
  var execute$4 = function (component, simulatedEvent, matrixConfig) {
    return $_f15fvwz1jfuw8tlo.search(component.element()).bind(function (focused) {
      return matrixConfig.execute()(component, simulatedEvent, focused);
    });
  };
  var toMatrix = function (rows, matrixConfig) {
    return $_efmt4zxbjfuw8tcj.map(rows, function (row) {
      return $_951f03109jfuw8tt3.descendants(row, matrixConfig.selectors().cell());
    });
  };
  var doMove$2 = function (ifCycle, ifMove) {
    return function (element, focused, matrixConfig) {
      var move$$1 = matrixConfig.cycles() ? ifCycle : ifMove;
      return $_c8lemt10bjfuw8tt8.closest(focused, matrixConfig.selectors().row()).bind(function (inRow) {
        var cellsInRow = $_951f03109jfuw8tt3.descendants(inRow, matrixConfig.selectors().cell());
        return findIndex$2(cellsInRow, focused).bind(function (colIndex) {
          var allRows = $_951f03109jfuw8tt3.descendants(element, matrixConfig.selectors().row());
          return findIndex$2(allRows, inRow).bind(function (rowIndex) {
            var matrix = toMatrix(allRows, matrixConfig);
            return move$$1(matrix, rowIndex, colIndex).map(function (next) {
              return next.cell();
            });
          });
        });
      });
    };
  };
  var moveLeft$3 = doMove$2(cycleLeft$1, moveLeft$2);
  var moveRight$3 = doMove$2(cycleRight$1, moveRight$2);
  var moveNorth$1 = doMove$2(cycleUp$1, moveUp);
  var moveSouth$1 = doMove$2(cycleDown$1, moveDown);
  var getRules$3 = $_2vokfcwwjfuw8tb4.constant([
    rule(inSet($_cy6bab10cjfuw8tt9.LEFT()), west(moveLeft$3, moveRight$3)),
    rule(inSet($_cy6bab10cjfuw8tt9.RIGHT()), east(moveLeft$3, moveRight$3)),
    rule(inSet($_cy6bab10cjfuw8tt9.UP()), north(moveNorth$1)),
    rule(inSet($_cy6bab10cjfuw8tt9.DOWN()), south(moveSouth$1)),
    rule(inSet($_cy6bab10cjfuw8tt9.SPACE().concat($_cy6bab10cjfuw8tt9.ENTER())), execute$4)
  ]);
  var getEvents$3 = $_2vokfcwwjfuw8tb4.constant({});
  var getApis$3 = $_2vokfcwwjfuw8tb4.constant({});
  var MatrixType = typical(schema$4, init, getRules$3, getEvents$3, getApis$3, Option.some(focusIn$2));

  var schema$5 = [
    strict$1('selector'),
    defaulted$1('execute', defaultExecute),
    defaulted$1('moveOnTab', false)
  ];
  var execute$5 = function (component, simulatedEvent, menuConfig) {
    return menuConfig.focusManager().get(component).bind(function (focused) {
      return menuConfig.execute()(component, simulatedEvent, focused);
    });
  };
  var focusIn$3 = function (component, menuConfig, simulatedEvent) {
    $_c8lemt10bjfuw8tt8.descendant(component.element(), menuConfig.selector()).each(function (first) {
      menuConfig.focusManager().set(component, first);
    });
  };
  var moveUp$1 = function (element, focused, info) {
    return horizontal(element, info.selector(), focused, -1);
  };
  var moveDown$1 = function (element, focused, info) {
    return horizontal(element, info.selector(), focused, +1);
  };
  var fireShiftTab = function (component, simulatedEvent, menuConfig) {
    return menuConfig.moveOnTab() ? move(moveUp$1)(component, simulatedEvent, menuConfig) : Option.none();
  };
  var fireTab = function (component, simulatedEvent, menuConfig) {
    return menuConfig.moveOnTab() ? move(moveDown$1)(component, simulatedEvent, menuConfig) : Option.none();
  };
  var getRules$4 = $_2vokfcwwjfuw8tb4.constant([
    rule(inSet($_cy6bab10cjfuw8tt9.UP()), move(moveUp$1)),
    rule(inSet($_cy6bab10cjfuw8tt9.DOWN()), move(moveDown$1)),
    rule(and([
      isShift,
      inSet($_cy6bab10cjfuw8tt9.TAB())
    ]), fireShiftTab),
    rule(and([
      isNotShift,
      inSet($_cy6bab10cjfuw8tt9.TAB())
    ]), fireTab),
    rule(inSet($_cy6bab10cjfuw8tt9.ENTER()), execute$5),
    rule(inSet($_cy6bab10cjfuw8tt9.SPACE()), execute$5)
  ]);
  var getEvents$4 = $_2vokfcwwjfuw8tb4.constant({});
  var getApis$4 = $_2vokfcwwjfuw8tb4.constant({});
  var MenuType = typical(schema$5, init, getRules$4, getEvents$4, getApis$4, Option.some(focusIn$3));

  var schema$6 = [
    onKeyboardHandler('onSpace'),
    onKeyboardHandler('onEnter'),
    onKeyboardHandler('onShiftEnter'),
    onKeyboardHandler('onLeft'),
    onKeyboardHandler('onRight'),
    onKeyboardHandler('onTab'),
    onKeyboardHandler('onShiftTab'),
    onKeyboardHandler('onUp'),
    onKeyboardHandler('onDown'),
    onKeyboardHandler('onEscape'),
    option('focusIn')
  ];
  var getRules$5 = function (component, simulatedEvent, executeInfo) {
    return [
      rule(inSet($_cy6bab10cjfuw8tt9.SPACE()), executeInfo.onSpace()),
      rule(and([
        isNotShift,
        inSet($_cy6bab10cjfuw8tt9.ENTER())
      ]), executeInfo.onEnter()),
      rule(and([
        isShift,
        inSet($_cy6bab10cjfuw8tt9.ENTER())
      ]), executeInfo.onShiftEnter()),
      rule(and([
        isShift,
        inSet($_cy6bab10cjfuw8tt9.TAB())
      ]), executeInfo.onShiftTab()),
      rule(and([
        isNotShift,
        inSet($_cy6bab10cjfuw8tt9.TAB())
      ]), executeInfo.onTab()),
      rule(inSet($_cy6bab10cjfuw8tt9.UP()), executeInfo.onUp()),
      rule(inSet($_cy6bab10cjfuw8tt9.DOWN()), executeInfo.onDown()),
      rule(inSet($_cy6bab10cjfuw8tt9.LEFT()), executeInfo.onLeft()),
      rule(inSet($_cy6bab10cjfuw8tt9.RIGHT()), executeInfo.onRight()),
      rule(inSet($_cy6bab10cjfuw8tt9.SPACE()), executeInfo.onSpace()),
      rule(inSet($_cy6bab10cjfuw8tt9.ESCAPE()), executeInfo.onEscape())
    ];
  };
  var focusIn$4 = function (component, executeInfo) {
    return executeInfo.focusIn().bind(function (f) {
      return f(component, executeInfo);
    });
  };
  var getEvents$5 = $_2vokfcwwjfuw8tb4.constant({});
  var getApis$5 = $_2vokfcwwjfuw8tb4.constant({});
  var SpecialType = typical(schema$6, init, getRules$5, getEvents$5, getApis$5, Option.some(focusIn$4));

  var $_5g1im2102jfuw8trm = {
    acyclic: AcyclicType.schema(),
    cyclic: CyclicType.schema(),
    flow: FlowType.schema(),
    flatgrid: FlatgridType.schema(),
    matrix: MatrixType.schema(),
    execution: ExecutionType.schema(),
    menu: MenuType.schema(),
    special: SpecialType.schema()
  };

  var Keying = createModes$1({
    branchKey: 'mode',
    branches: $_5g1im2102jfuw8trm,
    name: 'keying',
    active: {
      events: function (keyingConfig, keyingState) {
        var handler = keyingConfig.handler();
        return handler.toEvents(keyingConfig, keyingState);
      }
    },
    apis: {
      focusIn: function (component) {
        component.getSystem().triggerFocus(component.element(), component.element());
      },
      setGridSize: function (component, keyConfig, keyState, numRows, numColumns) {
        if (!hasKey$1(keyState, 'setGridSize')) {
          console.error('Layout does not support setGridSize');
        } else {
          keyState.setGridSize(numRows, numColumns);
        }
      }
    },
    state: KeyingState
  });

  var field$1 = function (name, forbidden) {
    return defaultedObjOf(name, {}, $_efmt4zxbjfuw8tcj.map(forbidden, function (f) {
      return forbid(f.name(), 'Cannot configure ' + f.name() + ' for ' + name);
    }).concat([state$1('dump', $_2vokfcwwjfuw8tb4.identity)]));
  };
  var get$5 = function (data) {
    return data.dump();
  };

  var _placeholder = 'placeholder';
  var adt$2 = $_dldkf4y5jfuw8tgp.generate([
    {
      single: [
        'required',
        'valueThunk'
      ]
    },
    {
      multiple: [
        'required',
        'valueThunks'
      ]
    }
  ]);
  var subPlaceholder = function (owner, detail, compSpec, placeholders) {
    if (owner.exists(function (o) {
        return o !== compSpec.owner;
      })) {
      return adt$2.single(true, $_2vokfcwwjfuw8tb4.constant(compSpec));
    }
    return readOptFrom$1(placeholders, compSpec.name).fold(function () {
      throw new Error('Unknown placeholder component: ' + compSpec.name + '\nKnown: [' + $_8qu224wzjfuw8tb9.keys(placeholders) + ']\nNamespace: ' + owner.getOr('none') + '\nSpec: ' + $_6s9vvgygjfuw8ti8.stringify(compSpec, null, 2));
    }, function (newSpec) {
      return newSpec.replace();
    });
  };
  var scan = function (owner, detail, compSpec, placeholders) {
    if (compSpec.uiType === _placeholder) {
      return subPlaceholder(owner, detail, compSpec, placeholders);
    } else {
      return adt$2.single(false, $_2vokfcwwjfuw8tb4.constant(compSpec));
    }
  };
  var substitute = function (owner, detail, compSpec, placeholders) {
    var base = scan(owner, detail, compSpec, placeholders);
    return base.fold(function (req, valueThunk) {
      var value = valueThunk(detail, compSpec.config, compSpec.validated);
      var childSpecs = readOptFrom$1(value, 'components').getOr([]);
      var substituted = $_efmt4zxbjfuw8tcj.bind(childSpecs, function (c) {
        return substitute(owner, detail, c, placeholders);
      });
      return [$_3jctjywxjfuw8tb6.deepMerge(value, { components: substituted })];
    }, function (req, valuesThunk) {
      var values = valuesThunk(detail, compSpec.config, compSpec.validated);
      return values;
    });
  };
  var substituteAll = function (owner, detail, components, placeholders) {
    return $_efmt4zxbjfuw8tcj.bind(components, function (c) {
      return substitute(owner, detail, c, placeholders);
    });
  };
  var oneReplace = function (label, replacements) {
    var called = false;
    var used = function () {
      return called;
    };
    var replace = function () {
      if (called === true) {
        throw new Error('Trying to use the same placeholder more than once: ' + label);
      }
      called = true;
      return replacements;
    };
    var required = function () {
      return replacements.fold(function (req, _) {
        return req;
      }, function (req, _) {
        return req;
      });
    };
    return {
      name: $_2vokfcwwjfuw8tb4.constant(label),
      required: required,
      used: used,
      replace: replace
    };
  };
  var substitutePlaces = function (owner, detail, components, placeholders) {
    var ps = $_8qu224wzjfuw8tb9.map(placeholders, function (ph, name) {
      return oneReplace(name, ph);
    });
    var outcome = substituteAll(owner, detail, components, ps);
    $_8qu224wzjfuw8tb9.each(ps, function (p) {
      if (p.used() === false && p.required()) {
        throw new Error('Placeholder: ' + p.name() + ' was not found in components list\nNamespace: ' + owner.getOr('none') + '\nComponents: ' + $_6s9vvgygjfuw8ti8.stringify(detail.components(), null, 2));
      }
    });
    return outcome;
  };
  var single = adt$2.single;
  var multiple = adt$2.multiple;
  var placeholder = $_2vokfcwwjfuw8tb4.constant(_placeholder);

  var unique = 0;
  var generate$1 = function (prefix) {
    var date = new Date();
    var time = date.getTime();
    var random = Math.floor(Math.random() * 1000000000);
    unique++;
    return prefix + '_' + random + unique + String(time);
  };
  var $_5j06su11ajfuw8u1p = { generate: generate$1 };

  var adt$3 = $_dldkf4y5jfuw8tgp.generate([
    { required: ['data'] },
    { external: ['data'] },
    { optional: ['data'] },
    { group: ['data'] }
  ]);
  var fFactory = defaulted$1('factory', { sketch: $_2vokfcwwjfuw8tb4.identity });
  var fSchema = defaulted$1('schema', []);
  var fName = strict$1('name');
  var fPname = field('pname', 'pname', defaultedThunk(function (typeSpec) {
    return '<alloy.' + $_5j06su11ajfuw8u1p.generate(typeSpec.name) + '>';
  }), anyValue$1());
  var fDefaults = defaulted$1('defaults', $_2vokfcwwjfuw8tb4.constant({}));
  var fOverrides = defaulted$1('overrides', $_2vokfcwwjfuw8tb4.constant({}));
  var requiredSpec = objOf([
    fFactory,
    fSchema,
    fName,
    fPname,
    fDefaults,
    fOverrides
  ]);
  var externalSpec = objOf([
    fFactory,
    fSchema,
    fName,
    fDefaults,
    fOverrides
  ]);
  var optionalSpec = objOf([
    fFactory,
    fSchema,
    fName,
    fPname,
    fDefaults,
    fOverrides
  ]);
  var groupSpec = objOf([
    fFactory,
    fSchema,
    fName,
    strict$1('unit'),
    fPname,
    fDefaults,
    fOverrides
  ]);
  var asNamedPart = function (part) {
    return part.fold(Option.some, Option.none, Option.some, Option.some);
  };
  var name$1 = function (part) {
    var get = function (data) {
      return data.name();
    };
    return part.fold(get, get, get, get);
  };
  var convert = function (adtConstructor, partSpec) {
    return function (spec) {
      var data = asStructOrDie('Converting part type', partSpec, spec);
      return adtConstructor(data);
    };
  };
  var required = convert(adt$3.required, requiredSpec);
  var external = convert(adt$3.external, externalSpec);
  var optional = convert(adt$3.optional, optionalSpec);
  var group = convert(adt$3.group, groupSpec);
  var original = $_2vokfcwwjfuw8tb4.constant('entirety');

  var combine = function (detail, data, partSpec, partValidated) {
    var spec = partSpec;
    return $_3jctjywxjfuw8tb6.deepMerge(data.defaults()(detail, partSpec, partValidated), partSpec, { uid: detail.partUids()[data.name()] }, data.overrides()(detail, partSpec, partValidated), { 'debug.sketcher': wrap$2('part-' + data.name(), spec) });
  };
  var subs = function (owner, detail, parts) {
    var internals = {};
    var externals = {};
    $_efmt4zxbjfuw8tcj.each(parts, function (part) {
      part.fold(function (data) {
        internals[data.pname()] = single(true, function (detail, partSpec, partValidated) {
          return data.factory().sketch(combine(detail, data, partSpec, partValidated));
        });
      }, function (data) {
        var partSpec = detail.parts()[data.name()]();
        externals[data.name()] = $_2vokfcwwjfuw8tb4.constant(combine(detail, data, partSpec[original()]()));
      }, function (data) {
        internals[data.pname()] = single(false, function (detail, partSpec, partValidated) {
          return data.factory().sketch(combine(detail, data, partSpec, partValidated));
        });
      }, function (data) {
        internals[data.pname()] = multiple(true, function (detail, _partSpec, _partValidated) {
          var units = detail[data.name()]();
          return $_efmt4zxbjfuw8tcj.map(units, function (u) {
            return data.factory().sketch($_3jctjywxjfuw8tb6.deepMerge(data.defaults()(detail, u), u, data.overrides()(detail, u)));
          });
        });
      });
    });
    return {
      internals: $_2vokfcwwjfuw8tb4.constant(internals),
      externals: $_2vokfcwwjfuw8tb4.constant(externals)
    };
  };

  var generate$2 = function (owner, parts) {
    var r = {};
    $_efmt4zxbjfuw8tcj.each(parts, function (part) {
      asNamedPart(part).each(function (np) {
        var g = doGenerateOne(owner, np.pname());
        r[np.name()] = function (config) {
          var validated = asRawOrDie('Part: ' + np.name() + ' in ' + owner, objOf(np.schema()), config);
          return $_3jctjywxjfuw8tb6.deepMerge(g, {
            config: config,
            validated: validated
          });
        };
      });
    });
    return r;
  };
  var doGenerateOne = function (owner, pname) {
    return {
      uiType: placeholder(),
      owner: owner,
      name: pname
    };
  };
  var generateOne = function (owner, pname, config) {
    return {
      uiType: placeholder(),
      owner: owner,
      name: pname,
      config: config,
      validated: {}
    };
  };
  var schemas = function (parts) {
    return $_efmt4zxbjfuw8tcj.bind(parts, function (part) {
      return part.fold(Option.none, Option.some, Option.none, Option.none).map(function (data) {
        return strictObjOf(data.name(), data.schema().concat([snapshot$1(original())]));
      }).toArray();
    });
  };
  var names = function (parts) {
    return $_efmt4zxbjfuw8tcj.map(parts, name$1);
  };
  var substitutes = function (owner, detail, parts) {
    return subs(owner, detail, parts);
  };
  var components = function (owner, detail, internals) {
    return substitutePlaces(Option.some(owner), detail, detail.components(), internals);
  };
  var getPart = function (component, detail, partKey) {
    var uid = detail.partUids()[partKey];
    return component.getSystem().getByUid(uid).toOption();
  };
  var getPartOrDie = function (component, detail, partKey) {
    return getPart(component, detail, partKey).getOrDie('Could not find part: ' + partKey);
  };
  var getAllParts = function (component, detail) {
    var system = component.getSystem();
    return $_8qu224wzjfuw8tb9.map(detail.partUids(), function (pUid, k) {
      return $_2vokfcwwjfuw8tb4.constant(system.getByUid(pUid));
    });
  };
  var defaultUids = function (baseUid, partTypes) {
    var partNames = names(partTypes);
    return wrapAll$1($_efmt4zxbjfuw8tcj.map(partNames, function (pn) {
      return {
        key: pn,
        value: baseUid + '-' + pn
      };
    }));
  };
  var defaultUidsSchema = function (partTypes) {
    return field('partUids', 'partUids', mergeWithThunk(function (spec) {
      return defaultUids(spec.uid, partTypes);
    }), anyValue$1());
  };

  var premadeTag = $_5j06su11ajfuw8u1p.generate('alloy-premade');
  var _apiConfig = $_5j06su11ajfuw8u1p.generate('api');
  var premade = function (comp) {
    return wrap$2(premadeTag, comp);
  };
  var getPremade = function (spec) {
    return readOptFrom$1(spec, premadeTag);
  };
  var makeApi = function (f) {
    return markAsSketchApi(function (component) {
      var args = Array.prototype.slice.call(arguments, 0);
      var spi = component.config(_apiConfig);
      return f.apply(undefined, [spi].concat(args));
    }, f);
  };
  var apiConfig = $_2vokfcwwjfuw8tb4.constant(_apiConfig);

  var prefix$1 = $_2vokfcwwjfuw8tb4.constant('alloy-id-');
  var idAttr = $_2vokfcwwjfuw8tb4.constant('data-alloy-id');

  var prefix$2 = prefix$1();
  var idAttr$1 = idAttr();
  var write = function (label, elem) {
    var id = $_5j06su11ajfuw8u1p.generate(prefix$2 + label);
    $_47adx7ywjfuw8tl3.set(elem, idAttr$1, id);
    return id;
  };
  var writeOnly = function (elem, uid) {
    $_47adx7ywjfuw8tl3.set(elem, idAttr$1, uid);
  };
  var read$2 = function (elem) {
    var id = $_74lhjaxjjfuw8tdt.isElement(elem) ? $_47adx7ywjfuw8tl3.get(elem, idAttr$1) : null;
    return Option.from(id);
  };
  var generate$3 = function (prefix) {
    return $_5j06su11ajfuw8u1p.generate(prefix);
  };
  var attribute = $_2vokfcwwjfuw8tb4.constant(idAttr$1);

  var base$1 = function (label, partSchemas, partUidsSchemas, spec) {
    var ps = partSchemas.length > 0 ? [strictObjOf('parts', partSchemas)] : [];
    return ps.concat([
      strict$1('uid'),
      defaulted$1('dom', {}),
      defaulted$1('components', []),
      snapshot$1('originalSpec'),
      defaulted$1('debug.sketcher', {})
    ]).concat(partUidsSchemas);
  };
  var asStructOrDie$1 = function (label, schema, spec, partSchemas, partUidsSchemas) {
    var baseS = base$1(label, partSchemas, partUidsSchemas, spec);
    return asStructOrDie(label + ' [SpecSchema]', objOfOnly(baseS.concat(schema)), spec);
  };

  var single$1 = function (owner, schema, factory, spec) {
    var specWithUid = supplyUid(spec);
    var detail = asStructOrDie$1(owner, schema, specWithUid, [], []);
    return $_3jctjywxjfuw8tb6.deepMerge(factory(detail, specWithUid), { 'debug.sketcher': wrap$2(owner, spec) });
  };
  var composite = function (owner, schema, partTypes, factory, spec) {
    var specWithUid = supplyUid(spec);
    var partSchemas = schemas(partTypes);
    var partUidsSchema = defaultUidsSchema(partTypes);
    var detail = asStructOrDie$1(owner, schema, specWithUid, partSchemas, [partUidsSchema]);
    var subs = substitutes(owner, detail, partTypes);
    var components$$1 = components(owner, detail, subs.internals());
    return $_3jctjywxjfuw8tb6.deepMerge(factory(detail, components$$1, specWithUid, subs.externals()), { 'debug.sketcher': wrap$2(owner, spec) });
  };
  var supplyUid = function (spec) {
    return $_3jctjywxjfuw8tb6.deepMerge({ uid: generate$3('uid') }, spec);
  };

  function isSketchSpec(spec) {
    return spec.uid !== undefined;
  }
  var singleSchema = objOfOnly([
    strict$1('name'),
    strict$1('factory'),
    strict$1('configFields'),
    defaulted$1('apis', {}),
    defaulted$1('extraApis', {})
  ]);
  var compositeSchema = objOfOnly([
    strict$1('name'),
    strict$1('factory'),
    strict$1('configFields'),
    strict$1('partFields'),
    defaulted$1('apis', {}),
    defaulted$1('extraApis', {})
  ]);
  var single$2 = function (rawConfig) {
    var config = asRawOrDie('Sketcher for ' + rawConfig.name, singleSchema, rawConfig);
    var sketch = function (spec) {
      return single$1(config.name, config.configFields, config.factory, spec);
    };
    var apis = $_8qu224wzjfuw8tb9.map(config.apis, makeApi);
    var extraApis = $_8qu224wzjfuw8tb9.map(config.extraApis, function (f, k) {
      return markAsExtraApi(f, k);
    });
    return $_3jctjywxjfuw8tb6.deepMerge({
      name: $_2vokfcwwjfuw8tb4.constant(config.name),
      partFields: $_2vokfcwwjfuw8tb4.constant([]),
      configFields: $_2vokfcwwjfuw8tb4.constant(config.configFields),
      sketch: sketch
    }, apis, extraApis);
  };
  var composite$1 = function (rawConfig) {
    var config = asRawOrDie('Sketcher for ' + rawConfig.name, compositeSchema, rawConfig);
    var sketch = function (spec) {
      return composite(config.name, config.configFields, config.partFields, config.factory, spec);
    };
    var parts = generate$2(config.name, config.partFields);
    var apis = $_8qu224wzjfuw8tb9.map(config.apis, makeApi);
    var extraApis = $_8qu224wzjfuw8tb9.map(config.extraApis, function (f, k) {
      return markAsExtraApi(f, k);
    });
    return $_3jctjywxjfuw8tb6.deepMerge({
      name: $_2vokfcwwjfuw8tb4.constant(config.name),
      partFields: $_2vokfcwwjfuw8tb4.constant(config.partFields),
      configFields: $_2vokfcwwjfuw8tb4.constant(config.configFields),
      sketch: sketch,
      parts: $_2vokfcwwjfuw8tb4.constant(parts)
    }, apis, extraApis);
  };

  var factory = function (detail, spec) {
    var events = events$2(detail.action());
    var optType = readOptFrom$1(detail.dom(), 'attributes').bind(readOpt$1('type'));
    var optTag = readOptFrom$1(detail.dom(), 'tag');
    return {
      uid: detail.uid(),
      dom: detail.dom(),
      components: detail.components(),
      events: events,
      behaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2([
        Focusing.config({}),
        Keying.config({
          mode: 'execution',
          useSpace: true,
          useEnter: true
        })
      ]), get$5(detail.buttonBehaviours())),
      domModification: {
        attributes: $_3jctjywxjfuw8tb6.deepMerge(optType.fold(function () {
          return optTag.is('button') ? { type: 'button' } : {};
        }, function (t) {
          return {};
        }), { role: detail.role().getOr('button') })
      },
      eventOrder: detail.eventOrder()
    };
  };
  var Button = single$2({
    name: 'Button',
    factory: factory,
    configFields: [
      defaulted$1('uid', undefined),
      strict$1('dom'),
      defaulted$1('components', []),
      field$1('buttonBehaviours', [
        Focusing,
        Keying
      ]),
      option('action'),
      option('role'),
      defaulted$1('eventOrder', {})
    ]
  });

  var exhibit$2 = function (base, unselectConfig) {
    return nu$6({
      styles: {
        '-webkit-user-select': 'none',
        'user-select': 'none',
        '-ms-user-select': 'none',
        '-moz-user-select': '-moz-none'
      },
      attributes: { unselectable: 'on' }
    });
  };
  var events$4 = function (unselectConfig) {
    return derive([abort(selectstart(), $_2vokfcwwjfuw8tb4.constant(true))]);
  };


  var ActiveUnselecting = Object.freeze({
  	events: events$4,
  	exhibit: exhibit$2
  });

  var Unselecting = create$1({
    fields: [],
    name: 'unselecting',
    active: ActiveUnselecting
  });

  var getAttrs = function (elem) {
    var attributes = elem.dom().attributes !== undefined ? elem.dom().attributes : [];
    return $_efmt4zxbjfuw8tcj.foldl(attributes, function (b, attr) {
      if (attr.name === 'class') {
        return b;
      } else {
        return $_3jctjywxjfuw8tb6.deepMerge(b, wrap$2(attr.name, attr.value));
      }
    }, {});
  };
  var getClasses = function (elem) {
    return Array.prototype.slice.call(elem.dom().classList, 0);
  };
  var fromHtml$2 = function (html) {
    var elem = $_bwdnu0xijfuw8tdo.fromHtml(html);
    var children = $_aff64dxmjfuw8tdx.children(elem);
    var attrs = getAttrs(elem);
    var classes = getClasses(elem);
    var contents = children.length === 0 ? {} : { innerHtml: $_2dunqqzfjfuw8tnk.get(elem) };
    return $_3jctjywxjfuw8tb6.deepMerge({
      tag: $_74lhjaxjjfuw8tdt.name(elem),
      classes: classes,
      attributes: attrs
    }, contents);
  };

  var dom$1 = function (rawHtml) {
    var html = $_b463kaxdjfuw8tcv.supplant(rawHtml, { prefix: $_2fp9skztjfuw8tqe.prefix() });
    return fromHtml$2(html);
  };
  var spec = function (rawHtml) {
    var sDom = dom$1(rawHtml);
    return { dom: sDom };
  };

  var forToolbarCommand = function (editor, command) {
    return forToolbar(command, function () {
      editor.execCommand(command);
    }, {});
  };
  var getToggleBehaviours = function (command) {
    return derive$2([
      Toggling.config({
        toggleClass: $_2fp9skztjfuw8tqe.resolve('toolbar-button-selected'),
        toggleOnExecute: false,
        aria: { mode: 'pressed' }
      }),
      $_9de9iyzsjfuw8tqa.format(command, function (button, status) {
        var toggle = status ? Toggling.on : Toggling.off;
        toggle(button);
      })
    ]);
  };
  var forToolbarStateCommand = function (editor, command) {
    var extraBehaviours = getToggleBehaviours(command);
    return forToolbar(command, function () {
      editor.execCommand(command);
    }, extraBehaviours);
  };
  var forToolbarStateAction = function (editor, clazz, command, action) {
    var extraBehaviours = getToggleBehaviours(command);
    return forToolbar(clazz, action, extraBehaviours);
  };
  var forToolbar = function (clazz, action, extraBehaviours) {
    return Button.sketch({
      dom: dom$1('<span class="${prefix}-toolbar-button ${prefix}-icon-' + clazz + ' ${prefix}-icon"></span>'),
      action: action,
      buttonBehaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2([Unselecting.config({})]), extraBehaviours)
    });
  };
  var $_44weuozujfuw8tqh = {
    forToolbar: forToolbar,
    forToolbarCommand: forToolbarCommand,
    forToolbarStateAction: forToolbarStateAction,
    forToolbarStateCommand: forToolbarStateCommand
  };

  var reduceBy = function (value, min, max, step) {
    if (value < min) {
      return value;
    } else if (value > max) {
      return max;
    } else if (value === min) {
      return min - 1;
    } else {
      return Math.max(min, value - step);
    }
  };
  var increaseBy = function (value, min, max, step) {
    if (value > max) {
      return value;
    } else if (value < min) {
      return min;
    } else if (value === max) {
      return max + 1;
    } else {
      return Math.min(max, value + step);
    }
  };
  var capValue = function (value, min, max) {
    return Math.max(min, Math.min(max, value));
  };
  var snapValueOfX = function (bounds, value, min, max, step, snapStart) {
    return snapStart.fold(function () {
      var initValue = value - min;
      var extraValue = Math.round(initValue / step) * step;
      return capValue(min + extraValue, min - 1, max + 1);
    }, function (start) {
      var remainder = (value - start) % step;
      var adjustment = Math.round(remainder / step);
      var rawSteps = Math.floor((value - start) / step);
      var maxSteps = Math.floor((max - start) / step);
      var numSteps = Math.min(maxSteps, rawSteps + adjustment);
      var r = start + numSteps * step;
      return Math.max(start, r);
    });
  };
  var findValueOfX = function (bounds, min, max, xValue, step, snapToGrid, snapStart) {
    var range = max - min;
    if (xValue < bounds.left) {
      return min - 1;
    } else if (xValue > bounds.right) {
      return max + 1;
    } else {
      var xOffset = Math.min(bounds.right, Math.max(xValue, bounds.left)) - bounds.left;
      var newValue = capValue(xOffset / bounds.width * range + min, min - 1, max + 1);
      var roundedValue = Math.round(newValue);
      return snapToGrid && newValue >= min && newValue <= max ? snapValueOfX(bounds, newValue, min, max, step, snapStart) : roundedValue;
    }
  };

  var _changeEvent = 'slider.change.value';
  var isTouch = $_5reqwox3jfuw8tbu.detect().deviceType.isTouch();
  var getEventSource = function (simulatedEvent) {
    var evt = simulatedEvent.event().raw();
    if (isTouch && evt.touches !== undefined && evt.touches.length === 1) {
      return Option.some(evt.touches[0]);
    } else if (isTouch && evt.touches !== undefined) {
      return Option.none();
    } else if (!isTouch && evt.clientX !== undefined) {
      return Option.some(evt);
    } else {
      return Option.none();
    }
  };
  var getEventX = function (simulatedEvent) {
    var spot = getEventSource(simulatedEvent);
    return spot.map(function (s) {
      return s.clientX;
    });
  };
  var fireChange = function (component, value) {
    emitWith(component, _changeEvent, { value: value });
  };
  var setToRedge = function (redge, detail) {
    fireChange(redge, detail.max() + 1);
  };
  var setToLedge = function (ledge, detail) {
    fireChange(ledge, detail.min() - 1);
  };
  var setToX = function (spectrum, spectrumBounds, detail, xValue) {
    var value = findValueOfX(spectrumBounds, detail.min(), detail.max(), xValue, detail.stepSize(), detail.snapToGrid(), detail.snapStart());
    fireChange(spectrum, value);
  };
  var setXFromEvent = function (spectrum, detail, spectrumBounds, simulatedEvent) {
    return getEventX(simulatedEvent).map(function (xValue) {
      setToX(spectrum, spectrumBounds, detail, xValue);
      return xValue;
    });
  };
  var moveLeft$4 = function (spectrum, detail) {
    var newValue = reduceBy(detail.value().get(), detail.min(), detail.max(), detail.stepSize());
    fireChange(spectrum, newValue);
  };
  var moveRight$4 = function (spectrum, detail) {
    var newValue = increaseBy(detail.value().get(), detail.min(), detail.max(), detail.stepSize());
    fireChange(spectrum, newValue);
  };
  var changeEvent = $_2vokfcwwjfuw8tb4.constant(_changeEvent);

  var platform = $_5reqwox3jfuw8tbu.detect();
  var isTouch$1 = platform.deviceType.isTouch();
  var edgePart = function (name, action) {
    return optional({
      name: '' + name + '-edge',
      overrides: function (detail) {
        var touchEvents = derive([runActionExtra(touchstart(), action, [detail])]);
        var mouseEvents = derive([
          runActionExtra(mousedown(), action, [detail]),
          runActionExtra(mousemove(), function (l, det) {
            if (det.mouseIsDown().get()) {
              action(l, det);
            }
          }, [detail])
        ]);
        return { events: isTouch$1 ? touchEvents : mouseEvents };
      }
    });
  };
  var ledgePart = edgePart('left', setToLedge);
  var redgePart = edgePart('right', setToRedge);
  var thumbPart = required({
    name: 'thumb',
    defaults: $_2vokfcwwjfuw8tb4.constant({ dom: { styles: { position: 'absolute' } } }),
    overrides: function (detail) {
      return {
        events: derive([
          redirectToPart(touchstart(), detail, 'spectrum'),
          redirectToPart(touchmove(), detail, 'spectrum'),
          redirectToPart(touchend(), detail, 'spectrum')
        ])
      };
    }
  });
  var spectrumPart = required({
    schema: [state$1('mouseIsDown', function () {
        return Cell(false);
      })],
    name: 'spectrum',
    overrides: function (detail) {
      var moveToX = function (spectrum, simulatedEvent) {
        var spectrumBounds = spectrum.element().dom().getBoundingClientRect();
        setXFromEvent(spectrum, detail, spectrumBounds, simulatedEvent);
      };
      var touchEvents = derive([
        run(touchstart(), moveToX),
        run(touchmove(), moveToX)
      ]);
      var mouseEvents = derive([
        run(mousedown(), moveToX),
        run(mousemove(), function (spectrum, se) {
          if (detail.mouseIsDown().get()) {
            moveToX(spectrum, se);
          }
        })
      ]);
      return {
        behaviours: derive$2(isTouch$1 ? [] : [
          Keying.config({
            mode: 'special',
            onLeft: function (spectrum) {
              moveLeft$4(spectrum, detail);
              return Option.some(true);
            },
            onRight: function (spectrum) {
              moveRight$4(spectrum, detail);
              return Option.some(true);
            }
          }),
          Focusing.config({})
        ]),
        events: isTouch$1 ? touchEvents : mouseEvents
      };
    }
  });
  var SliderParts = [
    ledgePart,
    redgePart,
    thumbPart,
    spectrumPart
  ];

  var onLoad$1 = function (component, repConfig, repState) {
    repConfig.store().manager().onLoad(component, repConfig, repState);
  };
  var onUnload = function (component, repConfig, repState) {
    repConfig.store().manager().onUnload(component, repConfig, repState);
  };
  var setValue = function (component, repConfig, repState, data) {
    repConfig.store().manager().setValue(component, repConfig, repState, data);
  };
  var getValue = function (component, repConfig, repState) {
    return repConfig.store().manager().getValue(component, repConfig, repState);
  };


  var RepresentApis = Object.freeze({
  	onLoad: onLoad$1,
  	onUnload: onUnload,
  	setValue: setValue,
  	getValue: getValue
  });

  var events$5 = function (repConfig, repState) {
    var es = repConfig.resetOnDom() ? [
      runOnAttached(function (comp, se) {
        onLoad$1(comp, repConfig, repState);
      }),
      runOnDetached(function (comp, se) {
        onUnload(comp, repConfig, repState);
      })
    ] : [loadEvent(repConfig, repState, onLoad$1)];
    return derive(es);
  };


  var ActiveRepresenting = Object.freeze({
  	events: events$5
  });

  var memory = function () {
    var data = Cell(null);
    var readState = function () {
      return {
        mode: 'memory',
        value: data.get()
      };
    };
    var isNotSet = function () {
      return data.get() === null;
    };
    var clear = function () {
      data.set(null);
    };
    return BehaviourState({
      set: data.set,
      get: data.get,
      isNotSet: isNotSet,
      clear: clear,
      readState: readState
    });
  };
  var manual = function () {
    var readState = function () {
    };
    return BehaviourState({ readState: readState });
  };
  var dataset = function () {
    var data = Cell({});
    var readState = function () {
      return {
        mode: 'dataset',
        dataset: data.get()
      };
    };
    return BehaviourState({
      readState: readState,
      set: data.set,
      get: data.get
    });
  };
  var init$2 = function (spec) {
    return spec.store().manager().state(spec);
  };


  var RepresentState = Object.freeze({
  	memory: memory,
  	dataset: dataset,
  	manual: manual,
  	init: init$2
  });

  var setValue$1 = function (component, repConfig, repState, data) {
    var dataKey = repConfig.store().getDataKey();
    repState.set({});
    repConfig.store().setData()(component, data);
    repConfig.onSetValue()(component, data);
  };
  var getValue$1 = function (component, repConfig, repState) {
    var key = repConfig.store().getDataKey()(component);
    var dataset$$1 = repState.get();
    return readOptFrom$1(dataset$$1, key).fold(function () {
      return repConfig.store().getFallbackEntry()(key);
    }, function (data) {
      return data;
    });
  };
  var onLoad$2 = function (component, repConfig, repState) {
    repConfig.store().initialValue().each(function (data) {
      setValue$1(component, repConfig, repState, data);
    });
  };
  var onUnload$1 = function (component, repConfig, repState) {
    repState.set({});
  };
  var DatasetStore = [
    option('initialValue'),
    strict$1('getFallbackEntry'),
    strict$1('getDataKey'),
    strict$1('setData'),
    output$1('manager', {
      setValue: setValue$1,
      getValue: getValue$1,
      onLoad: onLoad$2,
      onUnload: onUnload$1,
      state: dataset
    })
  ];

  var getValue$2 = function (component, repConfig, repState) {
    return repConfig.store().getValue()(component);
  };
  var setValue$2 = function (component, repConfig, repState, data) {
    repConfig.store().setValue()(component, data);
    repConfig.onSetValue()(component, data);
  };
  var onLoad$3 = function (component, repConfig, repState) {
    repConfig.store().initialValue().each(function (data) {
      repConfig.store().setValue()(component, data);
    });
  };
  var ManualStore = [
    strict$1('getValue'),
    defaulted$1('setValue', $_2vokfcwwjfuw8tb4.noop),
    option('initialValue'),
    output$1('manager', {
      setValue: setValue$2,
      getValue: getValue$2,
      onLoad: onLoad$3,
      onUnload: $_2vokfcwwjfuw8tb4.noop,
      state: init
    })
  ];

  var setValue$3 = function (component, repConfig, repState, data) {
    repState.set(data);
    repConfig.onSetValue()(component, data);
  };
  var getValue$3 = function (component, repConfig, repState) {
    return repState.get();
  };
  var onLoad$4 = function (component, repConfig, repState) {
    repConfig.store().initialValue().each(function (initVal) {
      if (repState.isNotSet()) {
        repState.set(initVal);
      }
    });
  };
  var onUnload$2 = function (component, repConfig, repState) {
    repState.clear();
  };
  var MemoryStore = [
    option('initialValue'),
    output$1('manager', {
      setValue: setValue$3,
      getValue: getValue$3,
      onLoad: onLoad$4,
      onUnload: onUnload$2,
      state: memory
    })
  ];

  var RepresentSchema = [
    defaultedOf('store', { mode: 'memory' }, choose$1('mode', {
      memory: MemoryStore,
      manual: ManualStore,
      dataset: DatasetStore
    })),
    onHandler('onSetValue'),
    defaulted$1('resetOnDom', false)
  ];

  var Representing = create$1({
    fields: RepresentSchema,
    name: 'representing',
    active: ActiveRepresenting,
    apis: RepresentApis,
    extra: {
      setValueFrom: function (component, source) {
        var value = Representing.getValue(source);
        Representing.setValue(component, value);
      }
    },
    state: RepresentState
  });

  var isTouch$2 = $_5reqwox3jfuw8tbu.detect().deviceType.isTouch();
  var SliderSchema = [
    strict$1('min'),
    strict$1('max'),
    defaulted$1('stepSize', 1),
    defaulted$1('onChange', $_2vokfcwwjfuw8tb4.noop),
    defaulted$1('onInit', $_2vokfcwwjfuw8tb4.noop),
    defaulted$1('onDragStart', $_2vokfcwwjfuw8tb4.noop),
    defaulted$1('onDragEnd', $_2vokfcwwjfuw8tb4.noop),
    defaulted$1('snapToGrid', false),
    option('snapStart'),
    strict$1('getInitialValue'),
    field$1('sliderBehaviours', [
      Keying,
      Representing
    ]),
    state$1('value', function (spec) {
      return Cell(spec.min);
    })
  ].concat(!isTouch$2 ? [state$1('mouseIsDown', function () {
      return Cell(false);
    })] : []);

  var api$1 = Dimension('width', function (element) {
    return element.dom().offsetWidth;
  });
  var set$4 = function (element, h) {
    api$1.set(element, h);
  };
  var get$6 = function (element) {
    return api$1.get(element);
  };
  var getOuter$2 = function (element) {
    return api$1.getOuter(element);
  };
  var setMax$1 = function (element, value) {
    var inclusions = [
      'margin-left',
      'border-left-width',
      'padding-left',
      'padding-right',
      'border-right-width',
      'margin-right'
    ];
    var absMax = api$1.max(element, value, inclusions);
    $_aag5ti106jfuw8tse.set(element, 'max-width', absMax + 'px');
  };
  var $_dsj1h711zjfuw8u73 = {
    set: set$4,
    get: get$6,
    getOuter: getOuter$2,
    setMax: setMax$1
  };

  var isTouch$3 = $_5reqwox3jfuw8tbu.detect().deviceType.isTouch();
  var sketch$1 = function (detail, components$$1, spec, externals) {
    var range = detail.max() - detail.min();
    var getXCentre = function (component) {
      var rect = component.element().dom().getBoundingClientRect();
      return (rect.left + rect.right) / 2;
    };
    var getThumb = function (component) {
      return getPartOrDie(component, detail, 'thumb');
    };
    var getXOffset = function (slider, spectrumBounds, detail) {
      var v = detail.value().get();
      if (v < detail.min()) {
        return getPart(slider, detail, 'left-edge').fold(function () {
          return 0;
        }, function (ledge) {
          return getXCentre(ledge) - spectrumBounds.left;
        });
      } else if (v > detail.max()) {
        return getPart(slider, detail, 'right-edge').fold(function () {
          return spectrumBounds.width;
        }, function (redge) {
          return getXCentre(redge) - spectrumBounds.left;
        });
      } else {
        return (detail.value().get() - detail.min()) / range * spectrumBounds.width;
      }
    };
    var getXPos = function (slider) {
      var spectrum = getPartOrDie(slider, detail, 'spectrum');
      var spectrumBounds = spectrum.element().dom().getBoundingClientRect();
      var sliderBounds = slider.element().dom().getBoundingClientRect();
      var xOffset = getXOffset(slider, spectrumBounds, detail);
      return spectrumBounds.left - sliderBounds.left + xOffset;
    };
    var refresh = function (component) {
      var pos = getXPos(component);
      var thumb = getThumb(component);
      var thumbRadius = $_dsj1h711zjfuw8u73.get(thumb.element()) / 2;
      $_aag5ti106jfuw8tse.set(thumb.element(), 'left', pos - thumbRadius + 'px');
    };
    var changeValue = function (component, newValue) {
      var oldValue = detail.value().get();
      var thumb = getThumb(component);
      if (oldValue !== newValue || $_aag5ti106jfuw8tse.getRaw(thumb.element(), 'left').isNone()) {
        detail.value().set(newValue);
        refresh(component);
        detail.onChange()(component, thumb, newValue);
        return Option.some(true);
      } else {
        return Option.none();
      }
    };
    var resetToMin = function (slider) {
      changeValue(slider, detail.min());
    };
    var resetToMax = function (slider) {
      changeValue(slider, detail.max());
    };
    var uiEventsArr = isTouch$3 ? [
      run(touchstart(), function (slider, simulatedEvent) {
        detail.onDragStart()(slider, getThumb(slider));
      }),
      run(touchend(), function (slider, simulatedEvent) {
        detail.onDragEnd()(slider, getThumb(slider));
      })
    ] : [
      run(mousedown(), function (slider, simulatedEvent) {
        simulatedEvent.stop();
        detail.onDragStart()(slider, getThumb(slider));
        detail.mouseIsDown().set(true);
      }),
      run(mouseup(), function (slider, simulatedEvent) {
        detail.onDragEnd()(slider, getThumb(slider));
        detail.mouseIsDown().set(false);
      })
    ];
    return {
      uid: detail.uid(),
      dom: detail.dom(),
      components: components$$1,
      behaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2($_efmt4zxbjfuw8tcj.flatten([
        !isTouch$3 ? [Keying.config({
            mode: 'special',
            focusIn: function (slider) {
              return getPart(slider, detail, 'spectrum').map(Keying.focusIn).map($_2vokfcwwjfuw8tb4.constant(true));
            }
          })] : [],
        [Representing.config({
            store: {
              mode: 'manual',
              getValue: function (_) {
                return detail.value().get();
              }
            }
          })]
      ])), get$5(detail.sliderBehaviours())),
      events: derive([
        run(changeEvent(), function (slider, simulatedEvent) {
          changeValue(slider, simulatedEvent.event().value());
        }),
        runOnAttached(function (slider, simulatedEvent) {
          detail.value().set(detail.getInitialValue()());
          var thumb = getThumb(slider);
          refresh(slider);
          detail.onInit()(slider, thumb, detail.value().get());
        })
      ].concat(uiEventsArr)),
      apis: {
        resetToMin: resetToMin,
        resetToMax: resetToMax,
        refresh: refresh
      },
      domModification: { styles: { position: 'relative' } }
    };
  };

  var Slider = composite$1({
    name: 'Slider',
    configFields: SliderSchema,
    partFields: SliderParts,
    factory: sketch$1,
    apis: {
      resetToMin: function (apis, slider) {
        apis.resetToMin(slider);
      },
      resetToMax: function (apis, slider) {
        apis.resetToMax(slider);
      },
      refresh: function (apis, slider) {
        apis.refresh(slider);
      }
    }
  });

  var button = function (realm, clazz, makeItems) {
    return $_44weuozujfuw8tqh.forToolbar(clazz, function () {
      var items = makeItems();
      realm.setContextToolbar([{
          label: clazz + ' group',
          items: items
        }]);
    }, {});
  };

  var BLACK = -1;
  var makeSlider = function (spec$$1) {
    var getColor = function (hue) {
      if (hue < 0) {
        return 'black';
      } else if (hue > 360) {
        return 'white';
      } else {
        return 'hsl(' + hue + ', 100%, 50%)';
      }
    };
    var onInit = function (slider, thumb, value) {
      var color = getColor(value);
      $_aag5ti106jfuw8tse.set(thumb.element(), 'background-color', color);
    };
    var onChange = function (slider, thumb, value) {
      var color = getColor(value);
      $_aag5ti106jfuw8tse.set(thumb.element(), 'background-color', color);
      spec$$1.onChange(slider, thumb, color);
    };
    return Slider.sketch({
      dom: dom$1('<div class="${prefix}-slider ${prefix}-hue-slider-container"></div>'),
      components: [
        Slider.parts()['left-edge'](spec('<div class="${prefix}-hue-slider-black"></div>')),
        Slider.parts().spectrum({
          dom: dom$1('<div class="${prefix}-slider-gradient-container"></div>'),
          components: [spec('<div class="${prefix}-slider-gradient"></div>')],
          behaviours: derive$2([Toggling.config({ toggleClass: $_2fp9skztjfuw8tqe.resolve('thumb-active') })])
        }),
        Slider.parts()['right-edge'](spec('<div class="${prefix}-hue-slider-white"></div>')),
        Slider.parts().thumb({
          dom: dom$1('<div class="${prefix}-slider-thumb"></div>'),
          behaviours: derive$2([Toggling.config({ toggleClass: $_2fp9skztjfuw8tqe.resolve('thumb-active') })])
        })
      ],
      onChange: onChange,
      onDragStart: function (slider, thumb) {
        Toggling.on(thumb);
      },
      onDragEnd: function (slider, thumb) {
        Toggling.off(thumb);
      },
      onInit: onInit,
      stepSize: 10,
      min: 0,
      max: 360,
      getInitialValue: spec$$1.getInitialValue,
      sliderBehaviours: derive$2([$_9de9iyzsjfuw8tqa.orientation(Slider.refresh)])
    });
  };
  var makeItems = function (spec$$1) {
    return [makeSlider(spec$$1)];
  };
  var sketch$2 = function (realm, editor) {
    var spec$$1 = {
      onChange: function (slider, thumb, color) {
        editor.undoManager.transact(function () {
          editor.formatter.apply('forecolor', { value: color });
          editor.nodeChanged();
        });
      },
      getInitialValue: function () {
        return BLACK;
      }
    };
    return button(realm, 'color', function () {
      return makeItems(spec$$1);
    });
  };
  var $_zydxw11kjfuw8u3z = {
    makeItems: makeItems,
    sketch: sketch$2
  };

  var schema$7 = objOfOnly([
    strict$1('getInitialValue'),
    strict$1('onChange'),
    strict$1('category'),
    strict$1('sizes')
  ]);
  var sketch$3 = function (rawSpec) {
    var spec$$1 = asRawOrDie('SizeSlider', schema$7, rawSpec);
    var isValidValue = function (valueIndex) {
      return valueIndex >= 0 && valueIndex < spec$$1.sizes.length;
    };
    var onChange = function (slider, thumb, valueIndex) {
      if (isValidValue(valueIndex)) {
        spec$$1.onChange(valueIndex);
      }
    };
    return Slider.sketch({
      dom: {
        tag: 'div',
        classes: [
          $_2fp9skztjfuw8tqe.resolve('slider-' + spec$$1.category + '-size-container'),
          $_2fp9skztjfuw8tqe.resolve('slider'),
          $_2fp9skztjfuw8tqe.resolve('slider-size-container')
        ]
      },
      onChange: onChange,
      onDragStart: function (slider, thumb) {
        Toggling.on(thumb);
      },
      onDragEnd: function (slider, thumb) {
        Toggling.off(thumb);
      },
      min: 0,
      max: spec$$1.sizes.length - 1,
      stepSize: 1,
      getInitialValue: spec$$1.getInitialValue,
      snapToGrid: true,
      sliderBehaviours: derive$2([$_9de9iyzsjfuw8tqa.orientation(Slider.refresh)]),
      components: [
        Slider.parts().spectrum({
          dom: dom$1('<div class="${prefix}-slider-size-container"></div>'),
          components: [spec('<div class="${prefix}-slider-size-line"></div>')]
        }),
        Slider.parts().thumb({
          dom: dom$1('<div class="${prefix}-slider-thumb"></div>'),
          behaviours: derive$2([Toggling.config({ toggleClass: $_2fp9skztjfuw8tqe.resolve('thumb-active') })])
        })
      ]
    });
  };
  var $_uk6us122jfuw8u79 = { sketch: sketch$3 };

  var ancestor$3 = function (scope, transform, isRoot) {
    var element = scope.dom();
    var stop = $_8aqeo3wyjfuw8tb8.isFunction(isRoot) ? isRoot : $_2vokfcwwjfuw8tb4.constant(false);
    while (element.parentNode) {
      element = element.parentNode;
      var el = $_bwdnu0xijfuw8tdo.fromDom(element);
      var transformed = transform(el);
      if (transformed.isSome())
        return transformed;
      else if (stop(el))
        break;
    }
    return Option.none();
  };
  var closest$3 = function (scope, transform, isRoot) {
    var current = transform(scope);
    return current.orThunk(function () {
      return isRoot(scope) ? Option.none() : ancestor$3(scope, transform, isRoot);
    });
  };
  var $_90p555124jfuw8u81 = {
    ancestor: ancestor$3,
    closest: closest$3
  };

  var candidates = [
    '9px',
    '10px',
    '11px',
    '12px',
    '14px',
    '16px',
    '18px',
    '20px',
    '24px',
    '32px',
    '36px'
  ];
  var defaultSize = 'medium';
  var defaultIndex = 2;
  var indexToSize = function (index) {
    return Option.from(candidates[index]);
  };
  var sizeToIndex = function (size) {
    return $_efmt4zxbjfuw8tcj.findIndex(candidates, function (v) {
      return v === size;
    });
  };
  var getRawOrComputed = function (isRoot, rawStart) {
    var optStart = $_74lhjaxjjfuw8tdt.isElement(rawStart) ? Option.some(rawStart) : $_aff64dxmjfuw8tdx.parent(rawStart);
    return optStart.map(function (start) {
      var inline = $_90p555124jfuw8u81.closest(start, function (elem) {
        return $_aag5ti106jfuw8tse.getRaw(elem, 'font-size');
      }, isRoot);
      return inline.getOrThunk(function () {
        return $_aag5ti106jfuw8tse.get(start, 'font-size');
      });
    }).getOr('');
  };
  var getSize = function (editor) {
    var node = editor.selection.getStart();
    var elem = $_bwdnu0xijfuw8tdo.fromDom(node);
    var root = $_bwdnu0xijfuw8tdo.fromDom(editor.getBody());
    var isRoot = function (e) {
      return $_4867a0xsjfuw8tej.eq(root, e);
    };
    var elemSize = getRawOrComputed(isRoot, elem);
    return $_efmt4zxbjfuw8tcj.find(candidates, function (size) {
      return elemSize === size;
    }).getOr(defaultSize);
  };
  var applySize = function (editor, value) {
    var currentValue = getSize(editor);
    if (currentValue !== value) {
      editor.execCommand('fontSize', false, value);
    }
  };
  var get$7 = function (editor) {
    var size = getSize(editor);
    return sizeToIndex(size).getOr(defaultIndex);
  };
  var apply$1 = function (editor, index) {
    indexToSize(index).each(function (size) {
      applySize(editor, size);
    });
  };
  var $_ek5te123jfuw8u7k = {
    candidates: $_2vokfcwwjfuw8tb4.constant(candidates),
    get: get$7,
    apply: apply$1
  };

  var sizes = $_ek5te123jfuw8u7k.candidates();
  var makeSlider$1 = function (spec$$1) {
    return $_uk6us122jfuw8u79.sketch({
      onChange: spec$$1.onChange,
      sizes: sizes,
      category: 'font',
      getInitialValue: spec$$1.getInitialValue
    });
  };
  var makeItems$1 = function (spec$$1) {
    return [
      spec('<span class="${prefix}-toolbar-button ${prefix}-icon-small-font ${prefix}-icon"></span>'),
      makeSlider$1(spec$$1),
      spec('<span class="${prefix}-toolbar-button ${prefix}-icon-large-font ${prefix}-icon"></span>')
    ];
  };
  var sketch$4 = function (realm, editor) {
    var spec$$1 = {
      onChange: function (value) {
        $_ek5te123jfuw8u7k.apply(editor, value);
      },
      getInitialValue: function () {
        return $_ek5te123jfuw8u7k.get(editor);
      }
    };
    return button(realm, 'font-size', function () {
      return makeItems$1(spec$$1);
    });
  };

  var record = function (spec) {
    var uid = isSketchSpec(spec) && hasKey$1(spec, 'uid') ? spec.uid : generate$3('memento');
    var get = function (any) {
      return any.getSystem().getByUid(uid).getOrDie();
    };
    var getOpt = function (any) {
      return any.getSystem().getByUid(uid).fold(Option.none, Option.some);
    };
    var asSpec = function () {
      return $_3jctjywxjfuw8tb6.deepMerge(spec, { uid: uid });
    };
    return {
      get: get,
      getOpt: getOpt,
      asSpec: asSpec
    };
  };

  function create$3(width, height) {
    return resize(document.createElement('canvas'), width, height);
  }
  function clone$2(canvas) {
    var tCanvas, ctx;
    tCanvas = create$3(canvas.width, canvas.height);
    ctx = get2dContext(tCanvas);
    ctx.drawImage(canvas, 0, 0);
    return tCanvas;
  }
  function get2dContext(canvas) {
    return canvas.getContext('2d');
  }
  function get3dContext(canvas) {
    var gl = null;
    try {
      gl = canvas.getContext('webgl') || canvas.getContext('experimental-webgl');
    } catch (e) {
    }
    if (!gl) {
      gl = null;
    }
    return gl;
  }
  function resize(canvas, width, height) {
    canvas.width = width;
    canvas.height = height;
    return canvas;
  }
  var $_3ha18t129jfuw8u9g = {
    create: create$3,
    clone: clone$2,
    resize: resize,
    get2dContext: get2dContext,
    get3dContext: get3dContext
  };

  function getWidth(image) {
    return image.naturalWidth || image.width;
  }
  function getHeight(image) {
    return image.naturalHeight || image.height;
  }
  var $_3360ic12ajfuw8u9i = {
    getWidth: getWidth,
    getHeight: getHeight
  };

  var promise = function () {
    var Promise = function (fn) {
      if (typeof this !== 'object')
        throw new TypeError('Promises must be constructed via new');
      if (typeof fn !== 'function')
        throw new TypeError('not a function');
      this._state = null;
      this._value = null;
      this._deferreds = [];
      doResolve(fn, bind(resolve, this), bind(reject, this));
    };
    var asap = Promise.immediateFn || typeof setImmediate === 'function' && setImmediate || function (fn) {
      setTimeout(fn, 1);
    };
    function bind(fn, thisArg) {
      return function () {
        fn.apply(thisArg, arguments);
      };
    }
    var isArray = Array.isArray || function (value) {
      return Object.prototype.toString.call(value) === '[object Array]';
    };
    function handle(deferred) {
      var me = this;
      if (this._state === null) {
        this._deferreds.push(deferred);
        return;
      }
      asap(function () {
        var cb = me._state ? deferred.onFulfilled : deferred.onRejected;
        if (cb === null) {
          (me._state ? deferred.resolve : deferred.reject)(me._value);
          return;
        }
        var ret;
        try {
          ret = cb(me._value);
        } catch (e) {
          deferred.reject(e);
          return;
        }
        deferred.resolve(ret);
      });
    }
    function resolve(newValue) {
      try {
        if (newValue === this)
          throw new TypeError('A promise cannot be resolved with itself.');
        if (newValue && (typeof newValue === 'object' || typeof newValue === 'function')) {
          var then = newValue.then;
          if (typeof then === 'function') {
            doResolve(bind(then, newValue), bind(resolve, this), bind(reject, this));
            return;
          }
        }
        this._state = true;
        this._value = newValue;
        finale.call(this);
      } catch (e) {
        reject.call(this, e);
      }
    }
    function reject(newValue) {
      this._state = false;
      this._value = newValue;
      finale.call(this);
    }
    function finale() {
      for (var i = 0, len = this._deferreds.length; i < len; i++) {
        handle.call(this, this._deferreds[i]);
      }
      this._deferreds = null;
    }
    function Handler(onFulfilled, onRejected, resolve, reject) {
      this.onFulfilled = typeof onFulfilled === 'function' ? onFulfilled : null;
      this.onRejected = typeof onRejected === 'function' ? onRejected : null;
      this.resolve = resolve;
      this.reject = reject;
    }
    function doResolve(fn, onFulfilled, onRejected) {
      var done = false;
      try {
        fn(function (value) {
          if (done)
            return;
          done = true;
          onFulfilled(value);
        }, function (reason) {
          if (done)
            return;
          done = true;
          onRejected(reason);
        });
      } catch (ex) {
        if (done)
          return;
        done = true;
        onRejected(ex);
      }
    }
    Promise.prototype['catch'] = function (onRejected) {
      return this.then(null, onRejected);
    };
    Promise.prototype.then = function (onFulfilled, onRejected) {
      var me = this;
      return new Promise(function (resolve, reject) {
        handle.call(me, new Handler(onFulfilled, onRejected, resolve, reject));
      });
    };
    Promise.all = function () {
      var args = Array.prototype.slice.call(arguments.length === 1 && isArray(arguments[0]) ? arguments[0] : arguments);
      return new Promise(function (resolve, reject) {
        if (args.length === 0)
          return resolve([]);
        var remaining = args.length;
        function res(i, val) {
          try {
            if (val && (typeof val === 'object' || typeof val === 'function')) {
              var then = val.then;
              if (typeof then === 'function') {
                then.call(val, function (val) {
                  res(i, val);
                }, reject);
                return;
              }
            }
            args[i] = val;
            if (--remaining === 0) {
              resolve(args);
            }
          } catch (ex) {
            reject(ex);
          }
        }
        for (var i = 0; i < args.length; i++) {
          res(i, args[i]);
        }
      });
    };
    Promise.resolve = function (value) {
      if (value && typeof value === 'object' && value.constructor === Promise) {
        return value;
      }
      return new Promise(function (resolve) {
        resolve(value);
      });
    };
    Promise.reject = function (value) {
      return new Promise(function (resolve, reject) {
        reject(value);
      });
    };
    Promise.race = function (values) {
      return new Promise(function (resolve, reject) {
        for (var i = 0, len = values.length; i < len; i++) {
          values[i].then(resolve, reject);
        }
      });
    };
    return Promise;
  };
  var Promise = window.Promise ? window.Promise : promise();

  function Blob (parts, properties) {
    var f = $_dxyj33xujfuw8tet.getOrDie('Blob');
    return new f(parts, properties);
  }

  function FileReader () {
    var f = $_dxyj33xujfuw8tet.getOrDie('FileReader');
    return new f();
  }

  function Uint8Array (arr) {
    var f = $_dxyj33xujfuw8tet.getOrDie('Uint8Array');
    return new f(arr);
  }

  var requestAnimationFrame = function (callback) {
    var f = $_dxyj33xujfuw8tet.getOrDie('requestAnimationFrame');
    f(callback);
  };
  var atob = function (base64) {
    var f = $_dxyj33xujfuw8tet.getOrDie('atob');
    return f(base64);
  };
  var $_76467112fjfuw8u9q = {
    atob: atob,
    requestAnimationFrame: requestAnimationFrame
  };

  function imageToBlob(image) {
    var src = image.src;
    if (src.indexOf('data:') === 0) {
      return dataUriToBlob(src);
    }
    return anyUriToBlob(src);
  }
  function blobToImage(blob) {
    return new Promise(function (resolve, reject) {
      var blobUrl = URL.createObjectURL(blob);
      var image = new Image();
      var removeListeners = function () {
        image.removeEventListener('load', loaded);
        image.removeEventListener('error', error);
      };
      function loaded() {
        removeListeners();
        resolve(image);
      }
      function error() {
        removeListeners();
        reject('Unable to load data of type ' + blob.type + ': ' + blobUrl);
      }
      image.addEventListener('load', loaded);
      image.addEventListener('error', error);
      image.src = blobUrl;
      if (image.complete) {
        loaded();
      }
    });
  }
  function anyUriToBlob(url) {
    return new Promise(function (resolve, reject) {
      var xhr = new XMLHttpRequest();
      xhr.open('GET', url, true);
      xhr.responseType = 'blob';
      xhr.onload = function () {
        if (this.status == 200) {
          resolve(this.response);
        }
      };
      xhr.onerror = function () {
        var _this = this;
        var corsError = function () {
          var obj = new Error('No access to download image');
          obj.code = 18;
          obj.name = 'SecurityError';
          return obj;
        };
        var genericError = function () {
          return new Error('Error ' + _this.status + ' downloading image');
        };
        reject(this.status === 0 ? corsError() : genericError());
      };
      xhr.send();
    });
  }
  function dataUriToBlobSync(uri) {
    var data = uri.split(',');
    var matches = /data:([^;]+)/.exec(data[0]);
    if (!matches)
      return Option.none();
    var mimetype = matches[1];
    var base64 = data[1];
    var sliceSize = 1024;
    var byteCharacters = $_76467112fjfuw8u9q.atob(base64);
    var bytesLength = byteCharacters.length;
    var slicesCount = Math.ceil(bytesLength / sliceSize);
    var byteArrays = new Array(slicesCount);
    for (var sliceIndex = 0; sliceIndex < slicesCount; ++sliceIndex) {
      var begin = sliceIndex * sliceSize;
      var end = Math.min(begin + sliceSize, bytesLength);
      var bytes = new Array(end - begin);
      for (var offset = begin, i = 0; offset < end; ++i, ++offset) {
        bytes[i] = byteCharacters[offset].charCodeAt(0);
      }
      byteArrays[sliceIndex] = Uint8Array(bytes);
    }
    return Option.some(Blob(byteArrays, { type: mimetype }));
  }
  function dataUriToBlob(uri) {
    return new Promise(function (resolve, reject) {
      dataUriToBlobSync(uri).fold(function () {
        reject('uri is not base64: ' + uri);
      }, resolve);
    });
  }
  function uriToBlob(url) {
    if (url.indexOf('blob:') === 0) {
      return anyUriToBlob(url);
    }
    if (url.indexOf('data:') === 0) {
      return dataUriToBlob(url);
    }
    return null;
  }
  function canvasToBlob(canvas, type, quality) {
    type = type || 'image/png';
    if (HTMLCanvasElement.prototype.toBlob) {
      return new Promise(function (resolve) {
        canvas.toBlob(function (blob) {
          resolve(blob);
        }, type, quality);
      });
    } else {
      return dataUriToBlob(canvas.toDataURL(type, quality));
    }
  }
  function canvasToDataURL(getCanvas, type, quality) {
    type = type || 'image/png';
    return getCanvas.then(function (canvas) {
      return canvas.toDataURL(type, quality);
    });
  }
  function blobToCanvas(blob) {
    return blobToImage(blob).then(function (image) {
      revokeImageUrl(image);
      var context, canvas;
      canvas = $_3ha18t129jfuw8u9g.create($_3360ic12ajfuw8u9i.getWidth(image), $_3360ic12ajfuw8u9i.getHeight(image));
      context = $_3ha18t129jfuw8u9g.get2dContext(canvas);
      context.drawImage(image, 0, 0);
      return canvas;
    });
  }
  function blobToDataUri(blob) {
    return new Promise(function (resolve) {
      var reader = new FileReader();
      reader.onloadend = function () {
        resolve(reader.result);
      };
      reader.readAsDataURL(blob);
    });
  }
  function blobToArrayBuffer(blob) {
    return new Promise(function (resolve) {
      var reader = new FileReader();
      reader.onloadend = function () {
        resolve(reader.result);
      };
      reader.readAsArrayBuffer(blob);
    });
  }
  function blobToBase64(blob) {
    return blobToDataUri(blob).then(function (dataUri) {
      return dataUri.split(',')[1];
    });
  }
  function revokeImageUrl(image) {
    URL.revokeObjectURL(image.src);
  }
  var $_fqgkv9128jfuw8u93 = {
    blobToImage: blobToImage,
    imageToBlob: imageToBlob,
    blobToArrayBuffer: blobToArrayBuffer,
    blobToDataUri: blobToDataUri,
    blobToBase64: blobToBase64,
    dataUriToBlobSync: dataUriToBlobSync,
    canvasToBlob: canvasToBlob,
    canvasToDataURL: canvasToDataURL,
    blobToCanvas: blobToCanvas,
    uriToBlob: uriToBlob
  };

  var blobToImage$1 = function (image) {
    return $_fqgkv9128jfuw8u93.blobToImage(image);
  };
  var imageToBlob$1 = function (blob) {
    return $_fqgkv9128jfuw8u93.imageToBlob(blob);
  };
  var blobToDataUri$1 = function (blob) {
    return $_fqgkv9128jfuw8u93.blobToDataUri(blob);
  };
  var blobToBase64$1 = function (blob) {
    return $_fqgkv9128jfuw8u93.blobToBase64(blob);
  };
  var dataUriToBlobSync$1 = function (uri) {
    return $_fqgkv9128jfuw8u93.dataUriToBlobSync(uri);
  };
  var uriToBlob$1 = function (uri) {
    return Option.from($_fqgkv9128jfuw8u93.uriToBlob(uri));
  };
  var $_e0pod3127jfuw8u8y = {
    blobToImage: blobToImage$1,
    imageToBlob: imageToBlob$1,
    blobToDataUri: blobToDataUri$1,
    blobToBase64: blobToBase64$1,
    dataUriToBlobSync: dataUriToBlobSync$1,
    uriToBlob: uriToBlob$1
  };

  var addImage = function (editor, blob) {
    $_e0pod3127jfuw8u8y.blobToBase64(blob).then(function (base64) {
      editor.undoManager.transact(function () {
        var cache = editor.editorUpload.blobCache;
        var info = cache.create($_5j06su11ajfuw8u1p.generate('mceu'), blob, base64);
        cache.add(info);
        var img = editor.dom.createHTML('img', { src: info.blobUri() });
        editor.insertContent(img);
      });
    });
  };
  var extractBlob = function (simulatedEvent) {
    var event = simulatedEvent.event();
    var files = event.raw().target.files || event.raw().dataTransfer.files;
    return Option.from(files[0]);
  };
  var sketch$5 = function (editor) {
    var pickerDom = {
      tag: 'input',
      attributes: {
        accept: 'image/*',
        type: 'file',
        title: ''
      },
      styles: {
        visibility: 'hidden',
        position: 'absolute'
      }
    };
    var memPicker = record({
      dom: pickerDom,
      events: derive([
        cutter(click()),
        run(change(), function (picker, simulatedEvent) {
          extractBlob(simulatedEvent).each(function (blob) {
            addImage(editor, blob);
          });
        })
      ])
    });
    return Button.sketch({
      dom: dom$1('<span class="${prefix}-toolbar-button ${prefix}-icon-image ${prefix}-icon"></span>'),
      components: [memPicker.asSpec()],
      action: function (button) {
        var picker = memPicker.get(button);
        picker.element().dom().click();
      }
    });
  };

  var get$8 = function (element) {
    return element.dom().textContent;
  };
  var set$5 = function (element, value) {
    element.dom().textContent = value;
  };
  var $_eo325p12ijfuw8uaa = {
    get: get$8,
    set: set$5
  };

  var isNotEmpty = function (val) {
    return val.length > 0;
  };
  var defaultToEmpty = function (str) {
    return str === undefined || str === null ? '' : str;
  };
  var noLink = function (editor) {
    var text = editor.selection.getContent({ format: 'text' });
    return {
      url: '',
      text: text,
      title: '',
      target: '',
      link: Option.none()
    };
  };
  var fromLink = function (link) {
    var text = $_eo325p12ijfuw8uaa.get(link);
    var url = $_47adx7ywjfuw8tl3.get(link, 'href');
    var title = $_47adx7ywjfuw8tl3.get(link, 'title');
    var target = $_47adx7ywjfuw8tl3.get(link, 'target');
    return {
      url: defaultToEmpty(url),
      text: text !== url ? defaultToEmpty(text) : '',
      title: defaultToEmpty(title),
      target: defaultToEmpty(target),
      link: Option.some(link)
    };
  };
  var getInfo = function (editor) {
    return query(editor).fold(function () {
      return noLink(editor);
    }, function (link) {
      return fromLink(link);
    });
  };
  var wasSimple = function (link) {
    var prevHref = $_47adx7ywjfuw8tl3.get(link, 'href');
    var prevText = $_eo325p12ijfuw8uaa.get(link);
    return prevHref === prevText;
  };
  var getTextToApply = function (link, url, info) {
    return info.text.filter(isNotEmpty).fold(function () {
      return wasSimple(link) ? Option.some(url) : Option.none();
    }, Option.some);
  };
  var unlinkIfRequired = function (editor, info) {
    var activeLink = info.link.bind($_2vokfcwwjfuw8tb4.identity);
    activeLink.each(function (link) {
      editor.execCommand('unlink');
    });
  };
  var getAttrs$1 = function (url, info) {
    var attrs = {};
    attrs.href = url;
    info.title.filter(isNotEmpty).each(function (title) {
      attrs.title = title;
    });
    info.target.filter(isNotEmpty).each(function (target) {
      attrs.target = target;
    });
    return attrs;
  };
  var applyInfo = function (editor, info) {
    info.url.filter(isNotEmpty).fold(function () {
      unlinkIfRequired(editor, info);
    }, function (url) {
      var attrs = getAttrs$1(url, info);
      var activeLink = info.link.bind($_2vokfcwwjfuw8tb4.identity);
      activeLink.fold(function () {
        var text = info.text.filter(isNotEmpty).getOr(url);
        editor.insertContent(editor.dom.createHTML('a', attrs, editor.dom.encode(text)));
      }, function (link) {
        var text = getTextToApply(link, url, info);
        $_47adx7ywjfuw8tl3.setAll(link, attrs);
        text.each(function (newText) {
          $_eo325p12ijfuw8uaa.set(link, newText);
        });
      });
    });
  };
  var query = function (editor) {
    var start = $_bwdnu0xijfuw8tdo.fromDom(editor.selection.getStart());
    return $_c8lemt10bjfuw8tt8.closest(start, 'a');
  };
  var $_fhf8dq12hjfuw8u9y = {
    getInfo: getInfo,
    applyInfo: applyInfo,
    query: query
  };

  var platform$1 = $_5reqwox3jfuw8tbu.detect();
  var preserve$1 = function (f, editor) {
    var rng = editor.selection.getRng();
    f();
    editor.selection.setRng(rng);
  };
  var forAndroid = function (editor, f) {
    var wrapper = platform$1.os.isAndroid() ? preserve$1 : $_2vokfcwwjfuw8tb4.apply;
    wrapper(f, editor);
  };
  var $_6d07m912jjfuw8uab = { forAndroid: forAndroid };

  var events$6 = function (name, eventHandlers) {
    var events = derive(eventHandlers);
    return create$1({
      fields: [strict$1('enabled')],
      name: name,
      active: { events: $_2vokfcwwjfuw8tb4.constant(events) }
    });
  };
  var config = function (name, eventHandlers) {
    var me = events$6(name, eventHandlers);
    return {
      key: name,
      value: {
        config: {},
        me: me,
        configAsRaw: $_2vokfcwwjfuw8tb4.constant({}),
        initialConfig: {},
        state: noState()
      }
    };
  };

  var getCurrent = function (component, composeConfig, composeState) {
    return composeConfig.find()(component);
  };


  var ComposeApis = Object.freeze({
  	getCurrent: getCurrent
  });

  var ComposeSchema = [strict$1('find')];

  var Composing = create$1({
    fields: ComposeSchema,
    name: 'composing',
    apis: ComposeApis
  });

  var factory$1 = function (detail, spec) {
    return {
      uid: detail.uid(),
      dom: $_3jctjywxjfuw8tb6.deepMerge({
        tag: 'div',
        attributes: { role: 'presentation' }
      }, detail.dom()),
      components: detail.components(),
      behaviours: get$5(detail.containerBehaviours()),
      events: detail.events(),
      domModification: detail.domModification(),
      eventOrder: detail.eventOrder()
    };
  };
  var Container = single$2({
    name: 'Container',
    factory: factory$1,
    configFields: [
      defaulted$1('components', []),
      field$1('containerBehaviours', []),
      defaulted$1('events', {}),
      defaulted$1('domModification', {}),
      defaulted$1('eventOrder', {})
    ]
  });

  var factory$2 = function (detail, spec) {
    return {
      uid: detail.uid(),
      dom: detail.dom(),
      behaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2([
        Representing.config({
          store: {
            mode: 'memory',
            initialValue: detail.getInitialValue()()
          }
        }),
        Composing.config({ find: Option.some })
      ]), get$5(detail.dataBehaviours())),
      events: derive([runOnAttached(function (component, simulatedEvent) {
          Representing.setValue(component, detail.getInitialValue()());
        })])
    };
  };
  var DataField = single$2({
    name: 'DataField',
    factory: factory$2,
    configFields: [
      strict$1('uid'),
      strict$1('dom'),
      strict$1('getInitialValue'),
      field$1('dataBehaviours', [
        Representing,
        Composing
      ])
    ]
  });

  var get$9 = function (element) {
    return element.dom().value;
  };
  var set$6 = function (element, value) {
    if (value === undefined)
      throw new Error('Value.set was undefined');
    element.dom().value = value;
  };
  var $_7340hz12tjfuw8uci = {
    set: set$6,
    get: get$9
  };

  var schema$8 = $_2vokfcwwjfuw8tb4.constant([
    option('data'),
    defaulted$1('inputAttributes', {}),
    defaulted$1('inputStyles', {}),
    defaulted$1('type', 'input'),
    defaulted$1('tag', 'input'),
    defaulted$1('inputClasses', []),
    onHandler('onSetValue'),
    defaulted$1('styles', {}),
    option('placeholder'),
    defaulted$1('eventOrder', {}),
    field$1('inputBehaviours', [
      Representing,
      Focusing
    ]),
    defaulted$1('selectOnFocus', true)
  ]);
  var behaviours = function (detail) {
    return $_3jctjywxjfuw8tb6.deepMerge(derive$2([
      Representing.config({
        store: {
          mode: 'manual',
          initialValue: detail.data().getOr(undefined),
          getValue: function (input) {
            return $_7340hz12tjfuw8uci.get(input.element());
          },
          setValue: function (input, data) {
            var current = $_7340hz12tjfuw8uci.get(input.element());
            if (current !== data) {
              $_7340hz12tjfuw8uci.set(input.element(), data);
            }
          }
        },
        onSetValue: detail.onSetValue()
      }),
      Focusing.config({
        onFocus: detail.selectOnFocus() === false ? $_2vokfcwwjfuw8tb4.noop : function (component) {
          var input = component.element();
          var value = $_7340hz12tjfuw8uci.get(input);
          input.dom().setSelectionRange(0, value.length);
        }
      })
    ]), get$5(detail.inputBehaviours()));
  };
  var dom$2 = function (detail) {
    return {
      tag: detail.tag(),
      attributes: $_3jctjywxjfuw8tb6.deepMerge(wrapAll$1([{
          key: 'type',
          value: detail.type()
        }].concat(detail.placeholder().map(function (pc) {
        return {
          key: 'placeholder',
          value: pc
        };
      }).toArray())), detail.inputAttributes()),
      styles: detail.inputStyles(),
      classes: detail.inputClasses()
    };
  };

  var factory$3 = function (detail, spec) {
    return {
      uid: detail.uid(),
      dom: dom$2(detail),
      components: [],
      behaviours: behaviours(detail),
      eventOrder: detail.eventOrder()
    };
  };
  var Input = single$2({
    name: 'Input',
    configFields: schema$8(),
    factory: factory$3
  });

  var exhibit$3 = function (base, tabConfig) {
    return nu$6({
      attributes: wrapAll$1([{
          key: tabConfig.tabAttr(),
          value: 'true'
        }])
    });
  };


  var ActiveTabstopping = Object.freeze({
  	exhibit: exhibit$3
  });

  var TabstopSchema = [defaulted$1('tabAttr', 'data-alloy-tabstop')];

  var Tabstopping = create$1({
    fields: TabstopSchema,
    name: 'tabstopping',
    active: ActiveTabstopping
  });

  var clearInputBehaviour = 'input-clearing';
  var field$2 = function (name, placeholder) {
    var inputSpec = record(Input.sketch({
      placeholder: placeholder,
      onSetValue: function (input$$1, data) {
        emit(input$$1, input());
      },
      inputBehaviours: derive$2([
        Composing.config({ find: Option.some }),
        Tabstopping.config({}),
        Keying.config({ mode: 'execution' })
      ]),
      selectOnFocus: false
    }));
    var buttonSpec = record(Button.sketch({
      dom: dom$1('<button class="${prefix}-input-container-x ${prefix}-icon-cancel-circle ${prefix}-icon"></button>'),
      action: function (button) {
        var input$$1 = inputSpec.get(button);
        Representing.setValue(input$$1, '');
      }
    }));
    return {
      name: name,
      spec: Container.sketch({
        dom: dom$1('<div class="${prefix}-input-container"></div>'),
        components: [
          inputSpec.asSpec(),
          buttonSpec.asSpec()
        ],
        containerBehaviours: derive$2([
          Toggling.config({ toggleClass: $_2fp9skztjfuw8tqe.resolve('input-container-empty') }),
          Composing.config({
            find: function (comp) {
              return Option.some(inputSpec.get(comp));
            }
          }),
          config(clearInputBehaviour, [run(input(), function (iContainer) {
              var input$$1 = inputSpec.get(iContainer);
              var val = Representing.getValue(input$$1);
              var f = val.length > 0 ? Toggling.off : Toggling.on;
              f(iContainer);
            })])
        ])
      })
    };
  };
  var hidden = function (name) {
    return {
      name: name,
      spec: DataField.sketch({
        dom: {
          tag: 'span',
          styles: { display: 'none' }
        },
        getInitialValue: function () {
          return Option.none();
        }
      })
    };
  };

  var nativeDisabled = [
    'input',
    'button',
    'textarea'
  ];
  var onLoad$5 = function (component, disableConfig, disableState) {
    if (disableConfig.disabled()) {
      disable(component, disableConfig, disableState);
    }
  };
  var hasNative = function (component) {
    return $_efmt4zxbjfuw8tcj.contains(nativeDisabled, $_74lhjaxjjfuw8tdt.name(component.element()));
  };
  var nativeIsDisabled = function (component) {
    return $_47adx7ywjfuw8tl3.has(component.element(), 'disabled');
  };
  var nativeDisable = function (component) {
    $_47adx7ywjfuw8tl3.set(component.element(), 'disabled', 'disabled');
  };
  var nativeEnable = function (component) {
    $_47adx7ywjfuw8tl3.remove(component.element(), 'disabled');
  };
  var ariaIsDisabled = function (component) {
    return $_47adx7ywjfuw8tl3.get(component.element(), 'aria-disabled') === 'true';
  };
  var ariaDisable = function (component) {
    $_47adx7ywjfuw8tl3.set(component.element(), 'aria-disabled', 'true');
  };
  var ariaEnable = function (component) {
    $_47adx7ywjfuw8tl3.set(component.element(), 'aria-disabled', 'false');
  };
  var disable = function (component, disableConfig, disableState) {
    disableConfig.disableClass().each(function (disableClass) {
      $_6po7jxyujfuw8tl0.add(component.element(), disableClass);
    });
    var f = hasNative(component) ? nativeDisable : ariaDisable;
    f(component);
  };
  var enable = function (component, disableConfig, disableState) {
    disableConfig.disableClass().each(function (disableClass) {
      $_6po7jxyujfuw8tl0.remove(component.element(), disableClass);
    });
    var f = hasNative(component) ? nativeEnable : ariaEnable;
    f(component);
  };
  var isDisabled = function (component) {
    return hasNative(component) ? nativeIsDisabled(component) : ariaIsDisabled(component);
  };


  var DisableApis = Object.freeze({
  	enable: enable,
  	disable: disable,
  	isDisabled: isDisabled,
  	onLoad: onLoad$5
  });

  var exhibit$4 = function (base, disableConfig, disableState) {
    return nu$6({ classes: disableConfig.disabled() ? disableConfig.disableClass().map($_efmt4zxbjfuw8tcj.pure).getOr([]) : [] });
  };
  var events$7 = function (disableConfig, disableState) {
    return derive([
      abort(execute(), function (component, simulatedEvent) {
        return isDisabled(component);
      }),
      loadEvent(disableConfig, disableState, onLoad$5)
    ]);
  };


  var ActiveDisable = Object.freeze({
  	exhibit: exhibit$4,
  	events: events$7
  });

  var DisableSchema = [
    defaulted$1('disabled', false),
    option('disableClass')
  ];

  var Disabling = create$1({
    fields: DisableSchema,
    name: 'disabling',
    active: ActiveDisable,
    apis: DisableApis
  });

  var owner$1 = 'form';
  var schema$9 = [field$1('formBehaviours', [Representing])];
  var getPartName = function (name) {
    return '<alloy.field.' + name + '>';
  };
  var sketch$6 = function (fSpec) {
    var parts = function () {
      var record = [];
      var field = function (name, config) {
        record.push(name);
        return generateOne(owner$1, getPartName(name), config);
      };
      return {
        field: field,
        record: function () {
          return record;
        }
      };
    }();
    var spec = fSpec(parts);
    var partNames = parts.record();
    var fieldParts = $_efmt4zxbjfuw8tcj.map(partNames, function (n) {
      return required({
        name: n,
        pname: getPartName(n)
      });
    });
    return composite(owner$1, schema$9, fieldParts, make, spec);
  };
  var make = function (detail, components$$1, spec) {
    return $_3jctjywxjfuw8tb6.deepMerge({
      'debug.sketcher': { Form: spec },
      'uid': detail.uid(),
      'dom': detail.dom(),
      'components': components$$1,
      'behaviours': $_3jctjywxjfuw8tb6.deepMerge(derive$2([Representing.config({
          store: {
            mode: 'manual',
            getValue: function (form) {
              var optPs = getAllParts(form, detail);
              return $_8qu224wzjfuw8tb9.map(optPs, function (optPThunk, pName) {
                return optPThunk().bind(Composing.getCurrent).map(Representing.getValue);
              });
            },
            setValue: function (form, values) {
              $_8qu224wzjfuw8tb9.each(values, function (newValue, key) {
                getPart(form, detail, key).each(function (wrapper) {
                  Composing.getCurrent(wrapper).each(function (field) {
                    Representing.setValue(field, newValue);
                  });
                });
              });
            }
          }
        })]), get$5(detail.formBehaviours())),
      'apis': {
        getField: function (form, key) {
          return getPart(form, detail, key).bind(Composing.getCurrent);
        }
      }
    });
  };
  var Form = {
    getField: makeApi(function (apis, component, key) {
      return apis.getField(component, key);
    }),
    sketch: sketch$6
  };

  var revocable = function (doRevoke) {
    var subject = Cell(Option.none());
    var revoke = function () {
      subject.get().each(doRevoke);
    };
    var clear = function () {
      revoke();
      subject.set(Option.none());
    };
    var set = function (s) {
      revoke();
      subject.set(Option.some(s));
    };
    var isSet = function () {
      return subject.get().isSome();
    };
    return {
      clear: clear,
      isSet: isSet,
      set: set
    };
  };
  var destroyable = function () {
    return revocable(function (s) {
      s.destroy();
    });
  };
  var unbindable = function () {
    return revocable(function (s) {
      s.unbind();
    });
  };
  var api$2 = function () {
    var subject = Cell(Option.none());
    var revoke = function () {
      subject.get().each(function (s) {
        s.destroy();
      });
    };
    var clear = function () {
      revoke();
      subject.set(Option.none());
    };
    var set = function (s) {
      revoke();
      subject.set(Option.some(s));
    };
    var run = function (f) {
      subject.get().each(f);
    };
    var isSet = function () {
      return subject.get().isSome();
    };
    return {
      clear: clear,
      isSet: isSet,
      set: set,
      run: run
    };
  };
  var value$3 = function () {
    var subject = Cell(Option.none());
    var clear = function () {
      subject.set(Option.none());
    };
    var set = function (s) {
      subject.set(Option.some(s));
    };
    var on = function (f) {
      subject.get().each(f);
    };
    var isSet = function () {
      return subject.get().isSome();
    };
    return {
      clear: clear,
      set: set,
      isSet: isSet,
      on: on
    };
  };
  var $_bh7xqm133jfuw8uet = {
    destroyable: destroyable,
    unbindable: unbindable,
    api: api$2,
    value: value$3
  };

  var SWIPING_LEFT = 1;
  var SWIPING_RIGHT = -1;
  var SWIPING_NONE = 0;
  var init$3 = function (xValue) {
    return {
      xValue: xValue,
      points: []
    };
  };
  var move$1 = function (model, xValue) {
    if (xValue === model.xValue) {
      return model;
    }
    var currentDirection = xValue - model.xValue > 0 ? SWIPING_LEFT : SWIPING_RIGHT;
    var newPoint = {
      direction: currentDirection,
      xValue: xValue
    };
    var priorPoints = function () {
      if (model.points.length === 0) {
        return [];
      } else {
        var prev = model.points[model.points.length - 1];
        return prev.direction === currentDirection ? model.points.slice(0, model.points.length - 1) : model.points;
      }
    }();
    return {
      xValue: xValue,
      points: priorPoints.concat([newPoint])
    };
  };
  var complete = function (model) {
    if (model.points.length === 0) {
      return SWIPING_NONE;
    } else {
      var firstDirection = model.points[0].direction;
      var lastDirection = model.points[model.points.length - 1].direction;
      return firstDirection === SWIPING_RIGHT && lastDirection === SWIPING_RIGHT ? SWIPING_RIGHT : firstDirection === SWIPING_LEFT && lastDirection === SWIPING_LEFT ? SWIPING_LEFT : SWIPING_NONE;
    }
  };
  var $_f3hwqu134jfuw8uev = {
    init: init$3,
    move: move$1,
    complete: complete
  };

  var sketch$7 = function (rawSpec) {
    var navigateEvent = 'navigateEvent';
    var wrapperAdhocEvents = 'serializer-wrapper-events';
    var formAdhocEvents = 'form-events';
    var schema = objOf([
      strict$1('fields'),
      defaulted$1('maxFieldIndex', rawSpec.fields.length - 1),
      strict$1('onExecute'),
      strict$1('getInitialValue'),
      state$1('state', function () {
        return {
          dialogSwipeState: $_bh7xqm133jfuw8uet.value(),
          currentScreen: Cell(0)
        };
      })
    ]);
    var spec$$1 = asRawOrDie('SerialisedDialog', schema, rawSpec);
    var navigationButton = function (direction, directionName, enabled) {
      return Button.sketch({
        dom: dom$1('<span class="${prefix}-icon-' + directionName + ' ${prefix}-icon"></span>'),
        action: function (button) {
          emitWith(button, navigateEvent, { direction: direction });
        },
        buttonBehaviours: derive$2([Disabling.config({
            disableClass: $_2fp9skztjfuw8tqe.resolve('toolbar-navigation-disabled'),
            disabled: !enabled
          })])
      });
    };
    var reposition = function (dialog, message) {
      $_c8lemt10bjfuw8tt8.descendant(dialog.element(), '.' + $_2fp9skztjfuw8tqe.resolve('serialised-dialog-chain')).each(function (parent) {
        $_aag5ti106jfuw8tse.set(parent, 'left', -spec$$1.state.currentScreen.get() * message.width + 'px');
      });
    };
    var navigate = function (dialog, direction) {
      var screens = $_951f03109jfuw8tt3.descendants(dialog.element(), '.' + $_2fp9skztjfuw8tqe.resolve('serialised-dialog-screen'));
      $_c8lemt10bjfuw8tt8.descendant(dialog.element(), '.' + $_2fp9skztjfuw8tqe.resolve('serialised-dialog-chain')).each(function (parent) {
        if (spec$$1.state.currentScreen.get() + direction >= 0 && spec$$1.state.currentScreen.get() + direction < screens.length) {
          $_aag5ti106jfuw8tse.getRaw(parent, 'left').each(function (left) {
            var currentLeft = parseInt(left, 10);
            var w = $_dsj1h711zjfuw8u73.get(screens[0]);
            $_aag5ti106jfuw8tse.set(parent, 'left', currentLeft - direction * w + 'px');
          });
          spec$$1.state.currentScreen.set(spec$$1.state.currentScreen.get() + direction);
        }
      });
    };
    var focusInput = function (dialog) {
      var inputs = $_951f03109jfuw8tt3.descendants(dialog.element(), 'input');
      var optInput = Option.from(inputs[spec$$1.state.currentScreen.get()]);
      optInput.each(function (input$$1) {
        dialog.getSystem().getByDom(input$$1).each(function (inputComp) {
          dispatchFocus(dialog, inputComp.element());
        });
      });
      var dotitems = memDots.get(dialog);
      Highlighting.highlightAt(dotitems, spec$$1.state.currentScreen.get());
    };
    var resetState = function () {
      spec$$1.state.currentScreen.set(0);
      spec$$1.state.dialogSwipeState.clear();
    };
    var memForm = record(Form.sketch(function (parts) {
      return {
        dom: dom$1('<div class="${prefix}-serialised-dialog"></div>'),
        components: [Container.sketch({
            dom: dom$1('<div class="${prefix}-serialised-dialog-chain" style="left: 0px; position: absolute;"></div>'),
            components: $_efmt4zxbjfuw8tcj.map(spec$$1.fields, function (field$$1, i) {
              return i <= spec$$1.maxFieldIndex ? Container.sketch({
                dom: dom$1('<div class="${prefix}-serialised-dialog-screen"></div>'),
                components: $_efmt4zxbjfuw8tcj.flatten([
                  [navigationButton(-1, 'previous', i > 0)],
                  [parts.field(field$$1.name, field$$1.spec)],
                  [navigationButton(+1, 'next', i < spec$$1.maxFieldIndex)]
                ])
              }) : parts.field(field$$1.name, field$$1.spec);
            })
          })],
        formBehaviours: derive$2([
          $_9de9iyzsjfuw8tqa.orientation(function (dialog, message) {
            reposition(dialog, message);
          }),
          Keying.config({
            mode: 'special',
            focusIn: function (dialog) {
              focusInput(dialog);
            },
            onTab: function (dialog) {
              navigate(dialog, +1);
              return Option.some(true);
            },
            onShiftTab: function (dialog) {
              navigate(dialog, -1);
              return Option.some(true);
            }
          }),
          config(formAdhocEvents, [
            runOnAttached(function (dialog, simulatedEvent) {
              resetState();
              var dotitems = memDots.get(dialog);
              Highlighting.highlightFirst(dotitems);
              spec$$1.getInitialValue(dialog).each(function (v) {
                Representing.setValue(dialog, v);
              });
            }),
            runOnExecute(spec$$1.onExecute),
            run(transitionend(), function (dialog, simulatedEvent) {
              if (simulatedEvent.event().raw().propertyName === 'left') {
                focusInput(dialog);
              }
            }),
            run(navigateEvent, function (dialog, simulatedEvent) {
              var direction = simulatedEvent.event().direction();
              navigate(dialog, direction);
            })
          ])
        ])
      };
    }));
    var memDots = record({
      dom: dom$1('<div class="${prefix}-dot-container"></div>'),
      behaviours: derive$2([Highlighting.config({
          highlightClass: $_2fp9skztjfuw8tqe.resolve('dot-active'),
          itemClass: $_2fp9skztjfuw8tqe.resolve('dot-item')
        })]),
      components: $_efmt4zxbjfuw8tcj.bind(spec$$1.fields, function (_f, i) {
        return i <= spec$$1.maxFieldIndex ? [spec('<div class="${prefix}-dot-item ${prefix}-icon-full-dot ${prefix}-icon"></div>')] : [];
      })
    });
    return {
      dom: dom$1('<div class="${prefix}-serializer-wrapper"></div>'),
      components: [
        memForm.asSpec(),
        memDots.asSpec()
      ],
      behaviours: derive$2([
        Keying.config({
          mode: 'special',
          focusIn: function (wrapper) {
            var form = memForm.get(wrapper);
            Keying.focusIn(form);
          }
        }),
        config(wrapperAdhocEvents, [
          run(touchstart(), function (wrapper, simulatedEvent) {
            spec$$1.state.dialogSwipeState.set($_f3hwqu134jfuw8uev.init(simulatedEvent.event().raw().touches[0].clientX));
          }),
          run(touchmove(), function (wrapper, simulatedEvent) {
            spec$$1.state.dialogSwipeState.on(function (state) {
              simulatedEvent.event().prevent();
              spec$$1.state.dialogSwipeState.set($_f3hwqu134jfuw8uev.move(state, simulatedEvent.event().raw().touches[0].clientX));
            });
          }),
          run(touchend(), function (wrapper) {
            spec$$1.state.dialogSwipeState.on(function (state) {
              var dialog = memForm.get(wrapper);
              var direction = -1 * $_f3hwqu134jfuw8uev.complete(state);
              navigate(dialog, direction);
            });
          })
        ])
      ])
    };
  };

  var getGroups = $_ctj1zwx4jfuw8tbw.cached(function (realm, editor) {
    return [{
        label: 'the link group',
        items: [sketch$7({
            fields: [
              field$2('url', 'Type or paste URL'),
              field$2('text', 'Link text'),
              field$2('title', 'Link title'),
              field$2('target', 'Link target'),
              hidden('link')
            ],
            maxFieldIndex: [
              'url',
              'text',
              'title',
              'target'
            ].length - 1,
            getInitialValue: function () {
              return Option.some($_fhf8dq12hjfuw8u9y.getInfo(editor));
            },
            onExecute: function (dialog) {
              var info = Representing.getValue(dialog);
              $_fhf8dq12hjfuw8u9y.applyInfo(editor, info);
              realm.restoreToolbar();
              editor.focus();
            }
          })]
      }];
  });
  var sketch$8 = function (realm, editor) {
    return $_44weuozujfuw8tqh.forToolbarStateAction(editor, 'link', 'link', function () {
      var groups = getGroups(realm, editor);
      realm.setContextToolbar(groups);
      $_6d07m912jjfuw8uab.forAndroid(editor, function () {
        realm.focusToolbar();
      });
      $_fhf8dq12hjfuw8u9y.query(editor).each(function (link) {
        editor.selection.select(link.dom());
      });
    });
  };

  var DefaultStyleFormats = [
    {
      title: 'Headings',
      items: [
        {
          title: 'Heading 1',
          format: 'h1'
        },
        {
          title: 'Heading 2',
          format: 'h2'
        },
        {
          title: 'Heading 3',
          format: 'h3'
        },
        {
          title: 'Heading 4',
          format: 'h4'
        },
        {
          title: 'Heading 5',
          format: 'h5'
        },
        {
          title: 'Heading 6',
          format: 'h6'
        }
      ]
    },
    {
      title: 'Inline',
      items: [
        {
          title: 'Bold',
          icon: 'bold',
          format: 'bold'
        },
        {
          title: 'Italic',
          icon: 'italic',
          format: 'italic'
        },
        {
          title: 'Underline',
          icon: 'underline',
          format: 'underline'
        },
        {
          title: 'Strikethrough',
          icon: 'strikethrough',
          format: 'strikethrough'
        },
        {
          title: 'Superscript',
          icon: 'superscript',
          format: 'superscript'
        },
        {
          title: 'Subscript',
          icon: 'subscript',
          format: 'subscript'
        },
        {
          title: 'Code',
          icon: 'code',
          format: 'code'
        }
      ]
    },
    {
      title: 'Blocks',
      items: [
        {
          title: 'Paragraph',
          format: 'p'
        },
        {
          title: 'Blockquote',
          format: 'blockquote'
        },
        {
          title: 'Div',
          format: 'div'
        },
        {
          title: 'Pre',
          format: 'pre'
        }
      ]
    },
    {
      title: 'Alignment',
      items: [
        {
          title: 'Left',
          icon: 'alignleft',
          format: 'alignleft'
        },
        {
          title: 'Center',
          icon: 'aligncenter',
          format: 'aligncenter'
        },
        {
          title: 'Right',
          icon: 'alignright',
          format: 'alignright'
        },
        {
          title: 'Justify',
          icon: 'alignjustify',
          format: 'alignjustify'
        }
      ]
    }
  ];

  var isRecursive = function (component, originator, target) {
    return $_4867a0xsjfuw8tej.eq(originator, component.element()) && !$_4867a0xsjfuw8tej.eq(originator, target);
  };
  var $_4ab21o139jfuw8ugy = {
    events: derive([can(focus$1(), function (component, simulatedEvent) {
        var originator = simulatedEvent.event().originator();
        var target = simulatedEvent.event().target();
        if (isRecursive(component, originator, target)) {
          console.warn(focus$1() + ' did not get interpreted by the desired target. ' + '\nOriginator: ' + element(originator) + '\nTarget: ' + element(target) + '\nCheck the ' + focus$1() + ' event handlers');
          return false;
        } else {
          return true;
        }
      })])
  };

  var make$1 = $_2vokfcwwjfuw8tb4.identity;

  var SystemApi = $_2cliu2ysjfuw8tkr.exactly([
    'debugInfo',
    'triggerFocus',
    'triggerEvent',
    'triggerEscape',
    'addToWorld',
    'removeFromWorld',
    'addToGui',
    'removeFromGui',
    'build',
    'getByUid',
    'getByDom',
    'broadcast',
    'broadcastOn'
  ]);

  var NoContextApi = function (getComp) {
    var fail = function (event) {
      return function () {
        throw new Error('The component must be in a context to send: ' + event + '\n' + element(getComp().element()) + ' is not in context.');
      };
    };
    return SystemApi({
      debugInfo: $_2vokfcwwjfuw8tb4.constant('fake'),
      triggerEvent: fail('triggerEvent'),
      triggerFocus: fail('triggerFocus'),
      triggerEscape: fail('triggerEscape'),
      build: fail('build'),
      addToWorld: fail('addToWorld'),
      removeFromWorld: fail('removeFromWorld'),
      addToGui: fail('addToGui'),
      removeFromGui: fail('removeFromGui'),
      getByUid: fail('getByUid'),
      getByDom: fail('getByDom'),
      broadcast: fail('broadcast'),
      broadcastOn: fail('broadcastOn')
    });
  };

  var generateFrom = function (spec, all) {
    var schema = $_efmt4zxbjfuw8tcj.map(all, function (a) {
      return field(a.name(), a.name(), asOption(), objOf([
        strict$1('config'),
        defaulted$1('state', NoState)
      ]));
    });
    var validated = asStruct('component.behaviours', objOf(schema), spec.behaviours).fold(function (errInfo) {
      throw new Error(formatError(errInfo) + '\nComplete spec:\n' + $_6s9vvgygjfuw8ti8.stringify(spec, null, 2));
    }, $_2vokfcwwjfuw8tb4.identity);
    return {
      list: all,
      data: $_8qu224wzjfuw8tb9.map(validated, function (blobOptionThunk) {
        var blobOption = blobOptionThunk();
        return $_2vokfcwwjfuw8tb4.constant(blobOption.map(function (blob) {
          return {
            config: blob.config(),
            state: blob.state().init(blob.config())
          };
        }));
      })
    };
  };
  var getBehaviours = function (bData) {
    return bData.list;
  };
  var getData = function (bData) {
    return bData.data;
  };
  var $_47y96w13ejfuw8uhv = {
    generateFrom: generateFrom,
    getBehaviours: getBehaviours,
    getData: getData
  };

  var byInnerKey = function (data, tuple) {
    var r = {};
    $_8qu224wzjfuw8tb9.each(data, function (detail, key) {
      $_8qu224wzjfuw8tb9.each(detail, function (value, indexKey) {
        var chain = readOr$1(indexKey, [])(r);
        r[indexKey] = chain.concat([tuple(key, value)]);
      });
    });
    return r;
  };

  var behaviourDom = function (name, modification) {
    return {
      name: $_2vokfcwwjfuw8tb4.constant(name),
      modification: modification
    };
  };
  var concat = function (chain, aspect) {
    var values = $_efmt4zxbjfuw8tcj.bind(chain, function (c) {
      return c.modification().getOr([]);
    });
    return Result.value(wrap$2(aspect, values));
  };
  var onlyOne = function (chain, aspect, order) {
    if (chain.length > 1) {
      return Result.error('Multiple behaviours have tried to change DOM "' + aspect + '". The guilty behaviours are: ' + $_6s9vvgygjfuw8ti8.stringify($_efmt4zxbjfuw8tcj.map(chain, function (b) {
        return b.name();
      })) + '. At this stage, this ' + 'is not supported. Future releases might provide strategies for resolving this.');
    } else if (chain.length === 0) {
      return Result.value({});
    } else {
      return Result.value(chain[0].modification().fold(function () {
        return {};
      }, function (m) {
        return wrap$2(aspect, m);
      }));
    }
  };
  var duplicate = function (aspect, k, obj, behaviours) {
    return Result.error('Mulitple behaviours have tried to change the _' + k + '_ "' + aspect + '"' + '. The guilty behaviours are: ' + $_6s9vvgygjfuw8ti8.stringify($_efmt4zxbjfuw8tcj.bind(behaviours, function (b) {
      return b.modification().getOr({})[k] !== undefined ? [b.name()] : [];
    }), null, 2) + '. This is not currently supported.');
  };
  var safeMerge = function (chain, aspect) {
    var y = $_efmt4zxbjfuw8tcj.foldl(chain, function (acc, c) {
      var obj = c.modification().getOr({});
      return acc.bind(function (accRest) {
        var parts = $_8qu224wzjfuw8tb9.mapToArray(obj, function (v, k) {
          return accRest[k] !== undefined ? duplicate(aspect, k, obj, chain) : Result.value(wrap$2(k, v));
        });
        return consolidate(parts, accRest);
      });
    }, Result.value({}));
    return y.map(function (yValue) {
      return wrap$2(aspect, yValue);
    });
  };
  var mergeTypes = {
    classes: concat,
    attributes: safeMerge,
    styles: safeMerge,
    domChildren: onlyOne,
    defChildren: onlyOne,
    innerHtml: onlyOne,
    value: onlyOne
  };
  var combine$1 = function (info, baseMod, behaviours, base) {
    var behaviourDoms = $_3jctjywxjfuw8tb6.deepMerge({}, baseMod);
    $_efmt4zxbjfuw8tcj.each(behaviours, function (behaviour) {
      behaviourDoms[behaviour.name()] = behaviour.exhibit(info, base);
    });
    var byAspect = byInnerKey(behaviourDoms, behaviourDom);
    var usedAspect = $_8qu224wzjfuw8tb9.map(byAspect, function (values, aspect) {
      return $_efmt4zxbjfuw8tcj.bind(values, function (value) {
        return value.modification().fold(function () {
          return [];
        }, function (v) {
          return [value];
        });
      });
    });
    var modifications = $_8qu224wzjfuw8tb9.mapToArray(usedAspect, function (values, aspect) {
      return readOptFrom$1(mergeTypes, aspect).fold(function () {
        return Result.error('Unknown field type: ' + aspect);
      }, function (merger) {
        return merger(values, aspect);
      });
    });
    var consolidated = consolidate(modifications, {});
    return consolidated.map(nu$6);
  };

  var sortKeys = function (label, keyName, array, order) {
    var sliced = array.slice(0);
    try {
      var sorted = sliced.sort(function (a, b) {
        var aKey = a[keyName]();
        var bKey = b[keyName]();
        var aIndex = order.indexOf(aKey);
        var bIndex = order.indexOf(bKey);
        if (aIndex === -1) {
          throw new Error('The ordering for ' + label + ' does not have an entry for ' + aKey + '.\nOrder specified: ' + $_6s9vvgygjfuw8ti8.stringify(order, null, 2));
        }
        if (bIndex === -1) {
          throw new Error('The ordering for ' + label + ' does not have an entry for ' + bKey + '.\nOrder specified: ' + $_6s9vvgygjfuw8ti8.stringify(order, null, 2));
        }
        if (aIndex < bIndex) {
          return -1;
        } else if (bIndex < aIndex) {
          return 1;
        } else {
          return 0;
        }
      });
      return Result.value(sorted);
    } catch (err) {
      return Result.error([err]);
    }
  };
  var $_52rc8e13ijfuw8ujk = { sortKeys: sortKeys };

  var nu$7 = function (handler, purpose) {
    return {
      handler: handler,
      purpose: $_2vokfcwwjfuw8tb4.constant(purpose)
    };
  };
  var curryArgs = function (descHandler, extraArgs) {
    return {
      handler: $_2vokfcwwjfuw8tb4.curry.apply(undefined, [descHandler.handler].concat(extraArgs)),
      purpose: descHandler.purpose
    };
  };
  var getHandler = function (descHandler) {
    return descHandler.handler;
  };

  var behaviourTuple = function (name, handler) {
    return {
      name: $_2vokfcwwjfuw8tb4.constant(name),
      handler: $_2vokfcwwjfuw8tb4.constant(handler)
    };
  };
  var nameToHandlers = function (behaviours, info) {
    var r = {};
    $_efmt4zxbjfuw8tcj.each(behaviours, function (behaviour) {
      r[behaviour.name()] = behaviour.handlers(info);
    });
    return r;
  };
  var groupByEvents = function (info, behaviours, base) {
    var behaviourEvents = $_3jctjywxjfuw8tb6.deepMerge(base, nameToHandlers(behaviours, info));
    return byInnerKey(behaviourEvents, behaviourTuple);
  };
  var combine$2 = function (info, eventOrder, behaviours, base) {
    var byEventName = groupByEvents(info, behaviours, base);
    return combineGroups(byEventName, eventOrder);
  };
  var assemble = function (rawHandler) {
    var handler = read(rawHandler);
    return function (component, simulatedEvent) {
      var args = Array.prototype.slice.call(arguments, 0);
      if (handler.abort.apply(undefined, args)) {
        simulatedEvent.stop();
      } else if (handler.can.apply(undefined, args)) {
        handler.run.apply(undefined, args);
      }
    };
  };
  var missingOrderError = function (eventName, tuples) {
    return Result.error(['The event (' + eventName + ') has more than one behaviour that listens to it.\nWhen this occurs, you must ' + 'specify an event ordering for the behaviours in your spec (e.g. [ "listing", "toggling" ]).\nThe behaviours that ' + 'can trigger it are: ' + $_6s9vvgygjfuw8ti8.stringify($_efmt4zxbjfuw8tcj.map(tuples, function (c) {
        return c.name();
      }), null, 2)]);
  };
  var fuse$1 = function (tuples, eventOrder, eventName) {
    var order = eventOrder[eventName];
    if (!order) {
      return missingOrderError(eventName, tuples);
    } else {
      return $_52rc8e13ijfuw8ujk.sortKeys('Event: ' + eventName, 'name', tuples, order).map(function (sortedTuples) {
        var handlers = $_efmt4zxbjfuw8tcj.map(sortedTuples, function (tuple) {
          return tuple.handler();
        });
        return fuse(handlers);
      });
    }
  };
  var combineGroups = function (byEventName, eventOrder) {
    var r = $_8qu224wzjfuw8tb9.mapToArray(byEventName, function (tuples, eventName) {
      var combined = tuples.length === 1 ? Result.value(tuples[0].handler()) : fuse$1(tuples, eventOrder, eventName);
      return combined.map(function (handler) {
        var assembled = assemble(handler);
        var purpose = tuples.length > 1 ? $_efmt4zxbjfuw8tcj.filter(eventOrder, function (o) {
          return $_efmt4zxbjfuw8tcj.contains(tuples, function (t) {
            return t.name() === o;
          });
        }).join(' > ') : tuples[0].name();
        return wrap$2(eventName, nu$7(assembled, purpose));
      });
    });
    return consolidate(r, {});
  };

  var toInfo = function (spec) {
    return asStruct('custom.definition', objOfOnly([
      field('dom', 'dom', strict(), objOfOnly([
        strict$1('tag'),
        defaulted$1('styles', {}),
        defaulted$1('classes', []),
        defaulted$1('attributes', {}),
        option('value'),
        option('innerHtml')
      ])),
      strict$1('components'),
      strict$1('uid'),
      defaulted$1('events', {}),
      defaulted$1('apis', $_2vokfcwwjfuw8tb4.constant({})),
      field('eventOrder', 'eventOrder', mergeWith({
        'alloy.execute': [
          'disabling',
          'alloy.base.behaviour',
          'toggling'
        ],
        'alloy.focus': [
          'alloy.base.behaviour',
          'focusing',
          'keying'
        ],
        'alloy.system.init': [
          'alloy.base.behaviour',
          'disabling',
          'toggling',
          'representing'
        ],
        'input': [
          'alloy.base.behaviour',
          'representing',
          'streaming',
          'invalidating'
        ],
        'alloy.system.detached': [
          'alloy.base.behaviour',
          'representing'
        ]
      }), anyValue$1()),
      option('domModification'),
      snapshot$1('originalSpec'),
      defaulted$1('debug.sketcher', 'unknown')
    ]), spec);
  };
  var getUid = function (info) {
    return wrap$2(idAttr(), info.uid());
  };
  var toDefinition = function (info) {
    var base = {
      tag: info.dom().tag(),
      classes: info.dom().classes(),
      attributes: $_3jctjywxjfuw8tb6.deepMerge(getUid(info), info.dom().attributes()),
      styles: info.dom().styles(),
      domChildren: $_efmt4zxbjfuw8tcj.map(info.components(), function (comp) {
        return comp.element();
      })
    };
    return nu$5($_3jctjywxjfuw8tb6.deepMerge(base, info.dom().innerHtml().map(function (h) {
      return wrap$2('innerHtml', h);
    }).getOr({}), info.dom().value().map(function (h) {
      return wrap$2('value', h);
    }).getOr({})));
  };
  var toModification = function (info) {
    return info.domModification().fold(function () {
      return nu$6({});
    }, nu$6);
  };
  var toEvents = function (info) {
    return info.events();
  };

  var add$3 = function (element, classes) {
    $_efmt4zxbjfuw8tcj.each(classes, function (x) {
      $_6po7jxyujfuw8tl0.add(element, x);
    });
  };
  var remove$6 = function (element, classes) {
    $_efmt4zxbjfuw8tcj.each(classes, function (x) {
      $_6po7jxyujfuw8tl0.remove(element, x);
    });
  };
  var toggle$3 = function (element, classes) {
    $_efmt4zxbjfuw8tcj.each(classes, function (x) {
      $_6po7jxyujfuw8tl0.toggle(element, x);
    });
  };
  var hasAll = function (element, classes) {
    return $_efmt4zxbjfuw8tcj.forall(classes, function (clazz) {
      return $_6po7jxyujfuw8tl0.has(element, clazz);
    });
  };
  var hasAny = function (element, classes) {
    return $_efmt4zxbjfuw8tcj.exists(classes, function (clazz) {
      return $_6po7jxyujfuw8tl0.has(element, clazz);
    });
  };
  var getNative = function (element) {
    var classList = element.dom().classList;
    var r = new Array(classList.length);
    for (var i = 0; i < classList.length; i++) {
      r[i] = classList.item(i);
    }
    return r;
  };
  var get$10 = function (element) {
    return $_bxqp80yxjfuw8tlc.supports(element) ? getNative(element) : $_bxqp80yxjfuw8tlc.get(element);
  };
  var $_c6ke2t13mjfuw8uku = {
    add: add$3,
    remove: remove$6,
    toggle: toggle$3,
    hasAll: hasAll,
    hasAny: hasAny,
    get: get$10
  };

  var getChildren = function (definition) {
    if (definition.domChildren().isSome() && definition.defChildren().isSome()) {
      throw new Error('Cannot specify children and child specs! Must be one or the other.\nDef: ' + defToStr(definition));
    } else {
      return definition.domChildren().fold(function () {
        var defChildren = definition.defChildren().getOr([]);
        return $_efmt4zxbjfuw8tcj.map(defChildren, renderDef);
      }, function (domChildren) {
        return domChildren;
      });
    }
  };
  var renderToDom = function (definition) {
    var subject = $_bwdnu0xijfuw8tdo.fromTag(definition.tag());
    $_47adx7ywjfuw8tl3.setAll(subject, definition.attributes().getOr({}));
    $_c6ke2t13mjfuw8uku.add(subject, definition.classes().getOr([]));
    $_aag5ti106jfuw8tse.setAll(subject, definition.styles().getOr({}));
    $_2dunqqzfjfuw8tnk.set(subject, definition.innerHtml().getOr(''));
    var children = getChildren(definition);
    $_g8n2ewxzjfuw8tf7.append(subject, children);
    definition.value().each(function (value) {
      $_7340hz12tjfuw8uci.set(subject, value);
    });
    return subject;
  };
  var renderDef = function (spec) {
    var definition = nu$5(spec);
    return renderToDom(definition);
  };

  var getBehaviours$1 = function (spec) {
    var behaviours = readOptFrom$1(spec, 'behaviours').getOr({});
    var keys = $_efmt4zxbjfuw8tcj.filter($_8qu224wzjfuw8tb9.keys(behaviours), function (k) {
      return behaviours[k] !== undefined;
    });
    return $_efmt4zxbjfuw8tcj.map(keys, function (k) {
      return spec.behaviours[k].me;
    });
  };
  var generateFrom$1 = function (spec, all) {
    return $_47y96w13ejfuw8uhv.generateFrom(spec, all);
  };
  var generate$4 = function (spec) {
    var all = getBehaviours$1(spec);
    return generateFrom$1(spec, all);
  };

  var ComponentApi = $_2cliu2ysjfuw8tkr.exactly([
    'getSystem',
    'config',
    'hasConfigured',
    'spec',
    'connect',
    'disconnect',
    'element',
    'syncComponents',
    'readState',
    'components',
    'events'
  ]);

  var build = function (spec) {
    var getMe = function () {
      return me;
    };
    var systemApi = Cell(NoContextApi(getMe));
    var info = getOrDie$1(toInfo($_3jctjywxjfuw8tb6.deepMerge(spec, { behaviours: undefined })));
    var bBlob = generate$4(spec);
    var bList = $_47y96w13ejfuw8uhv.getBehaviours(bBlob);
    var bData = $_47y96w13ejfuw8uhv.getData(bBlob);
    var definition = toDefinition(info);
    var baseModification = { 'alloy.base.modification': toModification(info) };
    var modification = combine$1(bData, baseModification, bList, definition).getOrDie();
    var modDefinition = merge$1(definition, modification);
    var item = renderToDom(modDefinition);
    var baseEvents = { 'alloy.base.behaviour': toEvents(info) };
    var events = combine$2(bData, info.eventOrder(), bList, baseEvents).getOrDie();
    var subcomponents = Cell(info.components());
    var connect = function (newApi) {
      systemApi.set(newApi);
    };
    var disconnect = function () {
      systemApi.set(NoContextApi(getMe));
    };
    var syncComponents = function () {
      var children = $_aff64dxmjfuw8tdx.children(item);
      var subs = $_efmt4zxbjfuw8tcj.bind(children, function (child) {
        return systemApi.get().getByDom(child).fold(function () {
          return [];
        }, function (c) {
          return [c];
        });
      });
      subcomponents.set(subs);
    };
    var config = function (behaviour) {
      if (behaviour === apiConfig()) {
        return info.apis();
      }
      var b = bData;
      var f = $_8aqeo3wyjfuw8tb8.isFunction(b[behaviour.name()]) ? b[behaviour.name()] : function () {
        throw new Error('Could not find ' + behaviour.name() + ' in ' + $_6s9vvgygjfuw8ti8.stringify(spec, null, 2));
      };
      return f();
    };
    var hasConfigured = function (behaviour) {
      return $_8aqeo3wyjfuw8tb8.isFunction(bData[behaviour.name()]);
    };
    var readState = function (behaviourName) {
      return bData[behaviourName]().map(function (b) {
        return b.state.readState();
      }).getOr('not enabled');
    };
    var me = ComponentApi({
      getSystem: systemApi.get,
      config: config,
      hasConfigured: hasConfigured,
      spec: $_2vokfcwwjfuw8tb4.constant(spec),
      readState: readState,
      connect: connect,
      disconnect: disconnect,
      element: $_2vokfcwwjfuw8tb4.constant(item),
      syncComponents: syncComponents,
      components: subcomponents.get,
      events: $_2vokfcwwjfuw8tb4.constant(events)
    });
    return me;
  };

  var buildSubcomponents = function (spec) {
    var components = readOr$1('components', [])(spec);
    return $_efmt4zxbjfuw8tcj.map(components, build$1);
  };
  var buildFromSpec = function (userSpec) {
    var spec = make$1(userSpec);
    var components = buildSubcomponents(spec);
    var completeSpec = $_3jctjywxjfuw8tb6.deepMerge($_4ab21o139jfuw8ugy, spec, wrap$2('components', components));
    return Result.value(build(completeSpec));
  };
  var text = function (textContent) {
    var element = $_bwdnu0xijfuw8tdo.fromText(textContent);
    return external$1({ element: element });
  };
  var external$1 = function (spec) {
    var extSpec = asStructOrDie('external.component', objOfOnly([
      strict$1('element'),
      option('uid')
    ]), spec);
    var systemApi = Cell(NoContextApi());
    var connect = function (newApi) {
      systemApi.set(newApi);
    };
    var disconnect = function () {
      systemApi.set(NoContextApi(function () {
        return me;
      }));
    };
    extSpec.uid().each(function (uid) {
      writeOnly(extSpec.element(), uid);
    });
    var me = ComponentApi({
      getSystem: systemApi.get,
      config: Option.none,
      hasConfigured: $_2vokfcwwjfuw8tb4.constant(false),
      connect: connect,
      disconnect: disconnect,
      element: $_2vokfcwwjfuw8tb4.constant(extSpec.element()),
      spec: $_2vokfcwwjfuw8tb4.constant(spec),
      readState: $_2vokfcwwjfuw8tb4.constant('No state'),
      syncComponents: $_2vokfcwwjfuw8tb4.noop,
      components: $_2vokfcwwjfuw8tb4.constant([]),
      events: $_2vokfcwwjfuw8tb4.constant({})
    });
    return premade(me);
  };
  var build$1 = function (rawUserSpec) {
    return getPremade(rawUserSpec).fold(function () {
      var userSpecWithUid = $_3jctjywxjfuw8tb6.deepMerge({ uid: generate$3('') }, rawUserSpec);
      return buildFromSpec(userSpecWithUid).getOrDie();
    }, function (prebuilt) {
      return prebuilt;
    });
  };
  var premade$1 = premade;

  var hoverEvent = 'alloy.item-hover';
  var focusEvent = 'alloy.item-focus';
  var onHover = function (item) {
    if ($_f15fvwz1jfuw8tlo.search(item.element()).isNone() || Focusing.isFocused(item)) {
      if (!Focusing.isFocused(item)) {
        Focusing.focus(item);
      }
      emitWith(item, hoverEvent, { item: item });
    }
  };
  var onFocus = function (item) {
    emitWith(item, focusEvent, { item: item });
  };
  var hover = $_2vokfcwwjfuw8tb4.constant(hoverEvent);
  var focus$4 = $_2vokfcwwjfuw8tb4.constant(focusEvent);

  var builder = function (info) {
    return {
      dom: $_3jctjywxjfuw8tb6.deepMerge(info.dom(), { attributes: { role: info.toggling().isSome() ? 'menuitemcheckbox' : 'menuitem' } }),
      behaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2([
        info.toggling().fold(Toggling.revoke, function (tConfig) {
          return Toggling.config($_3jctjywxjfuw8tb6.deepMerge({ aria: { mode: 'checked' } }, tConfig));
        }),
        Focusing.config({
          ignore: info.ignoreFocus(),
          onFocus: function (component) {
            onFocus(component);
          }
        }),
        Keying.config({ mode: 'execution' }),
        Representing.config({
          store: {
            mode: 'memory',
            initialValue: info.data()
          }
        })
      ]), info.itemBehaviours()),
      events: derive([
        runWithTarget(tapOrClick(), emitExecute),
        cutter(mousedown()),
        run(mouseover(), onHover),
        run(focusItem(), Focusing.focus)
      ]),
      components: info.components(),
      domModification: info.domModification()
    };
  };
  var schema$10 = [
    strict$1('data'),
    strict$1('components'),
    strict$1('dom'),
    option('toggling'),
    defaulted$1('itemBehaviours', {}),
    defaulted$1('ignoreFocus', false),
    defaulted$1('domModification', {}),
    output$1('builder', builder)
  ];

  var builder$1 = function (detail) {
    return {
      dom: detail.dom(),
      components: detail.components(),
      events: derive([stopper(focusItem())])
    };
  };
  var schema$11 = [
    strict$1('dom'),
    strict$1('components'),
    output$1('builder', builder$1)
  ];

  var owner$2 = $_2vokfcwwjfuw8tb4.constant('item-widget');
  var parts = $_2vokfcwwjfuw8tb4.constant([required({
      name: 'widget',
      overrides: function (detail) {
        return {
          behaviours: derive$2([Representing.config({
              store: {
                mode: 'manual',
                getValue: function (component) {
                  return detail.data();
                },
                setValue: function () {
                }
              }
            })])
        };
      }
    })]);

  var builder$2 = function (info) {
    var subs = substitutes(owner$2(), info, parts());
    var components$$1 = components(owner$2(), info, subs.internals());
    var focusWidget = function (component) {
      return getPart(component, info, 'widget').map(function (widget) {
        Keying.focusIn(widget);
        return widget;
      });
    };
    var onHorizontalArrow = function (component, simulatedEvent) {
      return inside(simulatedEvent.event().target()) ? Option.none() : function () {
        if (info.autofocus()) {
          simulatedEvent.setSource(component.element());
          return Option.none();
        } else {
          return Option.none();
        }
      }();
    };
    return $_3jctjywxjfuw8tb6.deepMerge({
      dom: info.dom(),
      components: components$$1,
      domModification: info.domModification(),
      events: derive([
        runOnExecute(function (component, simulatedEvent) {
          focusWidget(component).each(function (widget) {
            simulatedEvent.stop();
          });
        }),
        run(mouseover(), onHover),
        run(focusItem(), function (component, simulatedEvent) {
          if (info.autofocus()) {
            focusWidget(component);
          } else {
            Focusing.focus(component);
          }
        })
      ]),
      behaviours: derive$2([
        Representing.config({
          store: {
            mode: 'memory',
            initialValue: info.data()
          }
        }),
        Focusing.config({
          onFocus: function (component) {
            onFocus(component);
          }
        }),
        Keying.config({
          mode: 'special',
          onLeft: onHorizontalArrow,
          onRight: onHorizontalArrow,
          onEscape: function (component, simulatedEvent) {
            if (!Focusing.isFocused(component) && !info.autofocus()) {
              Focusing.focus(component);
              return Option.some(true);
            } else if (info.autofocus()) {
              simulatedEvent.setSource(component.element());
              return Option.none();
            } else {
              return Option.none();
            }
          }
        })
      ])
    });
  };
  var schema$12 = [
    strict$1('uid'),
    strict$1('data'),
    strict$1('components'),
    strict$1('dom'),
    defaulted$1('autofocus', false),
    defaulted$1('domModification', {}),
    defaultUidsSchema(parts()),
    output$1('builder', builder$2)
  ];

  var itemSchema$1 = choose$1('type', {
    widget: schema$12,
    item: schema$10,
    separator: schema$11
  });
  var configureGrid = function (detail, movementInfo) {
    return {
      mode: 'flatgrid',
      selector: '.' + detail.markers().item(),
      initSize: {
        numColumns: movementInfo.initSize().numColumns(),
        numRows: movementInfo.initSize().numRows()
      },
      focusManager: detail.focusManager()
    };
  };
  var configureMenu = function (detail, movementInfo) {
    return {
      mode: 'menu',
      selector: '.' + detail.markers().item(),
      moveOnTab: movementInfo.moveOnTab(),
      focusManager: detail.focusManager()
    };
  };
  var parts$1 = $_2vokfcwwjfuw8tb4.constant([group({
      factory: {
        sketch: function (spec) {
          var itemInfo = asStructOrDie('menu.spec item', itemSchema$1, spec);
          return itemInfo.builder()(itemInfo);
        }
      },
      name: 'items',
      unit: 'item',
      defaults: function (detail, u) {
        var fallbackUid = generate$3('');
        return $_3jctjywxjfuw8tb6.deepMerge({ uid: fallbackUid }, u);
      },
      overrides: function (detail, u) {
        return {
          type: u.type,
          ignoreFocus: detail.fakeFocus(),
          domModification: { classes: [detail.markers().item()] }
        };
      }
    })]);
  var schema$13 = $_2vokfcwwjfuw8tb4.constant([
    strict$1('value'),
    strict$1('items'),
    strict$1('dom'),
    strict$1('components'),
    defaulted$1('eventOrder', {}),
    field$1('menuBehaviours', [
      Highlighting,
      Representing,
      Composing,
      Keying
    ]),
    defaultedOf('movement', {
      mode: 'menu',
      moveOnTab: true
    }, choose$1('mode', {
      grid: [
        initSize(),
        output$1('config', configureGrid)
      ],
      menu: [
        defaulted$1('moveOnTab', true),
        output$1('config', configureMenu)
      ]
    })),
    itemMarkers(),
    defaulted$1('fakeFocus', false),
    defaulted$1('focusManager', dom()),
    onHandler('onHighlight')
  ]);
  var name$2 = $_2vokfcwwjfuw8tb4.constant('menu');

  var focus$5 = $_2vokfcwwjfuw8tb4.constant('alloy.menu-focus');

  var make$2 = function (detail, components, spec, externals) {
    return $_3jctjywxjfuw8tb6.deepMerge({
      dom: $_3jctjywxjfuw8tb6.deepMerge(detail.dom(), { attributes: { role: 'menu' } }),
      uid: detail.uid(),
      behaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2([
        Highlighting.config({
          highlightClass: detail.markers().selectedItem(),
          itemClass: detail.markers().item(),
          onHighlight: detail.onHighlight()
        }),
        Representing.config({
          store: {
            mode: 'memory',
            initialValue: detail.value()
          }
        }),
        Composing.config({ find: $_2vokfcwwjfuw8tb4.identity }),
        Keying.config(detail.movement().config()(detail, detail.movement()))
      ]), get$5(detail.menuBehaviours())),
      events: derive([
        run(focus$4(), function (menu, simulatedEvent) {
          var event = simulatedEvent.event();
          menu.getSystem().getByDom(event.target()).each(function (item) {
            Highlighting.highlight(menu, item);
            simulatedEvent.stop();
            emitWith(menu, focus$5(), {
              menu: menu,
              item: item
            });
          });
        }),
        run(hover(), function (menu, simulatedEvent) {
          var item = simulatedEvent.event().item();
          Highlighting.highlight(menu, item);
        })
      ]),
      components: components,
      eventOrder: detail.eventOrder()
    });
  };

  var Menu = composite$1({
    name: 'Menu',
    configFields: schema$13(),
    partFields: parts$1(),
    factory: make$2
  });

  var preserve$2 = function (f, container) {
    var ownerDoc = $_aff64dxmjfuw8tdx.owner(container);
    var refocus = $_f15fvwz1jfuw8tlo.active(ownerDoc).bind(function (focused) {
      var hasFocus = function (elem) {
        return $_4867a0xsjfuw8tej.eq(focused, elem);
      };
      return hasFocus(container) ? Option.some(container) : $_d0h9pzz3jfuw8tlv.descendant(container, hasFocus);
    });
    var result = f(container);
    refocus.each(function (oldFocus) {
      $_f15fvwz1jfuw8tlo.active(ownerDoc).filter(function (newFocus) {
        return $_4867a0xsjfuw8tej.eq(newFocus, oldFocus);
      }).orThunk(function () {
        $_f15fvwz1jfuw8tlo.focus(oldFocus);
      });
    });
    return result;
  };

  var set$7 = function (component, replaceConfig, replaceState, data) {
    detachChildren(component);
    preserve$2(function () {
      var children = $_efmt4zxbjfuw8tcj.map(data, component.getSystem().build);
      $_efmt4zxbjfuw8tcj.each(children, function (l) {
        attach(component, l);
      });
    }, component.element());
  };
  var insert = function (component, replaceConfig, insertion, childSpec) {
    var child = component.getSystem().build(childSpec);
    attachWith(component, child, insertion);
  };
  var append$2 = function (component, replaceConfig, replaceState, appendee) {
    insert(component, replaceConfig, $_cwa5ncxljfuw8tdv.append, appendee);
  };
  var prepend$2 = function (component, replaceConfig, replaceState, prependee) {
    insert(component, replaceConfig, $_cwa5ncxljfuw8tdv.prepend, prependee);
  };
  var remove$7 = function (component, replaceConfig, replaceState, removee) {
    var children = contents(component, replaceConfig);
    var foundChild = $_efmt4zxbjfuw8tcj.find(children, function (child) {
      return $_4867a0xsjfuw8tej.eq(removee.element(), child.element());
    });
    foundChild.each(detach);
  };
  var contents = function (component, replaceConfig) {
    return component.components();
  };


  var ReplaceApis = Object.freeze({
  	append: append$2,
  	prepend: prepend$2,
  	remove: remove$7,
  	set: set$7,
  	contents: contents
  });

  var Replacing = create$1({
    fields: [],
    name: 'replacing',
    apis: ReplaceApis
  });

  var transpose = function (obj) {
    return $_8qu224wzjfuw8tb9.tupleMap(obj, function (v, k) {
      return {
        k: v,
        v: k
      };
    });
  };
  var trace = function (items, byItem, byMenu, finish) {
    return readOptFrom$1(byMenu, finish).bind(function (triggerItem) {
      return readOptFrom$1(items, triggerItem).bind(function (triggerMenu) {
        var rest = trace(items, byItem, byMenu, triggerMenu);
        return Option.some([triggerMenu].concat(rest));
      });
    }).getOr([]);
  };
  var generate$5 = function (menus, expansions) {
    var items = {};
    $_8qu224wzjfuw8tb9.each(menus, function (menuItems, menu) {
      $_efmt4zxbjfuw8tcj.each(menuItems, function (item) {
        items[item] = menu;
      });
    });
    var byItem = expansions;
    var byMenu = transpose(expansions);
    var menuPaths = $_8qu224wzjfuw8tb9.map(byMenu, function (triggerItem, submenu) {
      return [submenu].concat(trace(items, byItem, byMenu, submenu));
    });
    return $_8qu224wzjfuw8tb9.map(items, function (path) {
      return readOptFrom$1(menuPaths, path).getOr([path]);
    });
  };

  function LayeredState () {
    var expansions = Cell({});
    var menus = Cell({});
    var paths = Cell({});
    var primary = Cell(Option.none());
    var toItemValues = Cell($_2vokfcwwjfuw8tb4.constant([]));
    var clear = function () {
      expansions.set({});
      menus.set({});
      paths.set({});
      primary.set(Option.none());
    };
    var isClear = function () {
      return primary.get().isNone();
    };
    var setContents = function (sPrimary, sMenus, sExpansions, sToItemValues) {
      primary.set(Option.some(sPrimary));
      expansions.set(sExpansions);
      menus.set(sMenus);
      toItemValues.set(sToItemValues);
      var menuValues = sToItemValues(sMenus);
      var sPaths = generate$5(menuValues, sExpansions);
      paths.set(sPaths);
    };
    var expand = function (itemValue) {
      return readOptFrom$1(expansions.get(), itemValue).map(function (menu) {
        var current = readOptFrom$1(paths.get(), itemValue).getOr([]);
        return [menu].concat(current);
      });
    };
    var collapse = function (itemValue) {
      return readOptFrom$1(paths.get(), itemValue).bind(function (path) {
        return path.length > 1 ? Option.some(path.slice(1)) : Option.none();
      });
    };
    var refresh = function (itemValue) {
      return readOptFrom$1(paths.get(), itemValue);
    };
    var lookupMenu = function (menuValue) {
      return readOptFrom$1(menus.get(), menuValue);
    };
    var otherMenus = function (path) {
      var menuValues = toItemValues.get()(menus.get());
      return $_efmt4zxbjfuw8tcj.difference($_8qu224wzjfuw8tb9.keys(menuValues), path);
    };
    var getPrimary = function () {
      return primary.get().bind(lookupMenu);
    };
    var getMenus = function () {
      return menus.get();
    };
    return {
      setContents: setContents,
      expand: expand,
      refresh: refresh,
      collapse: collapse,
      lookupMenu: lookupMenu,
      otherMenus: otherMenus,
      getPrimary: getPrimary,
      getMenus: getMenus,
      clear: clear,
      isClear: isClear
    };
  }

  var make$3 = function (detail, rawUiSpec) {
    var buildMenus = function (container, menus) {
      return $_8qu224wzjfuw8tb9.map(menus, function (spec, name) {
        var data = Menu.sketch($_3jctjywxjfuw8tb6.deepMerge(spec, {
          value: name,
          items: spec.items,
          markers: narrow$1(rawUiSpec.markers, [
            'item',
            'selectedItem'
          ]),
          fakeFocus: detail.fakeFocus(),
          onHighlight: detail.onHighlight(),
          focusManager: detail.fakeFocus() ? highlights() : dom()
        }));
        return container.getSystem().build(data);
      });
    };
    var state = LayeredState();
    var setup = function (container) {
      var componentMap = buildMenus(container, detail.data().menus());
      state.setContents(detail.data().primary(), componentMap, detail.data().expansions(), function (sMenus) {
        return toMenuValues(container, sMenus);
      });
      return state.getPrimary();
    };
    var getItemValue = function (item) {
      return Representing.getValue(item).value;
    };
    var toMenuValues = function (container, sMenus) {
      return $_8qu224wzjfuw8tb9.map(detail.data().menus(), function (data, menuName) {
        return $_efmt4zxbjfuw8tcj.bind(data.items, function (item) {
          return item.type === 'separator' ? [] : [item.data.value];
        });
      });
    };
    var setActiveMenu = function (container, menu) {
      Highlighting.highlight(container, menu);
      Highlighting.getHighlighted(menu).orThunk(function () {
        return Highlighting.getFirst(menu);
      }).each(function (item) {
        dispatch(container, item.element(), focusItem());
      });
    };
    var getMenus = function (state, menuValues) {
      return $_e8fwikzljfuw8tp3.cat($_efmt4zxbjfuw8tcj.map(menuValues, state.lookupMenu));
    };
    var updateMenuPath = function (container, state, path) {
      return Option.from(path[0]).bind(state.lookupMenu).map(function (activeMenu) {
        var rest = getMenus(state, path.slice(1));
        $_efmt4zxbjfuw8tcj.each(rest, function (r) {
          $_6po7jxyujfuw8tl0.add(r.element(), detail.markers().backgroundMenu());
        });
        if (!$_8634tqxhjfuw8tdl.inBody(activeMenu.element())) {
          Replacing.append(container, premade$1(activeMenu));
        }
        $_c6ke2t13mjfuw8uku.remove(activeMenu.element(), [detail.markers().backgroundMenu()]);
        setActiveMenu(container, activeMenu);
        var others = getMenus(state, state.otherMenus(path));
        $_efmt4zxbjfuw8tcj.each(others, function (o) {
          $_c6ke2t13mjfuw8uku.remove(o.element(), [detail.markers().backgroundMenu()]);
          if (!detail.stayInDom()) {
            Replacing.remove(container, o);
          }
        });
        return activeMenu;
      });
    };
    var expandRight = function (container, item) {
      var value = getItemValue(item);
      return state.expand(value).bind(function (path) {
        Option.from(path[0]).bind(state.lookupMenu).each(function (activeMenu) {
          if (!$_8634tqxhjfuw8tdl.inBody(activeMenu.element())) {
            Replacing.append(container, premade$1(activeMenu));
          }
          detail.onOpenSubmenu()(container, item, activeMenu);
          Highlighting.highlightFirst(activeMenu);
        });
        return updateMenuPath(container, state, path);
      });
    };
    var collapseLeft = function (container, item) {
      var value = getItemValue(item);
      return state.collapse(value).bind(function (path) {
        return updateMenuPath(container, state, path).map(function (activeMenu) {
          detail.onCollapseMenu()(container, item, activeMenu);
          return activeMenu;
        });
      });
    };
    var updateView = function (container, item) {
      var value = getItemValue(item);
      return state.refresh(value).bind(function (path) {
        return updateMenuPath(container, state, path);
      });
    };
    var onRight = function (container, item) {
      return inside(item.element()) ? Option.none() : expandRight(container, item);
    };
    var onLeft = function (container, item) {
      return inside(item.element()) ? Option.none() : collapseLeft(container, item);
    };
    var onEscape = function (container, item) {
      return collapseLeft(container, item).orThunk(function () {
        return detail.onEscape()(container, item);
      });
    };
    var keyOnItem = function (f) {
      return function (container, simulatedEvent) {
        return $_c8lemt10bjfuw8tt8.closest(simulatedEvent.getSource(), '.' + detail.markers().item()).bind(function (target) {
          return container.getSystem().getByDom(target).bind(function (item) {
            return f(container, item);
          });
        });
      };
    };
    var events = derive([
      run(focus$5(), function (sandbox, simulatedEvent) {
        var menu = simulatedEvent.event().menu();
        Highlighting.highlight(sandbox, menu);
      }),
      runOnExecute(function (sandbox, simulatedEvent) {
        var target = simulatedEvent.event().target();
        return sandbox.getSystem().getByDom(target).bind(function (item) {
          var itemValue = getItemValue(item);
          if (itemValue.indexOf('collapse-item') === 0) {
            return collapseLeft(sandbox, item);
          }
          return expandRight(sandbox, item).orThunk(function () {
            return detail.onExecute()(sandbox, item);
          });
        });
      }),
      runOnAttached(function (container, simulatedEvent) {
        setup(container).each(function (primary) {
          Replacing.append(container, premade$1(primary));
          if (detail.openImmediately()) {
            setActiveMenu(container, primary);
            detail.onOpenMenu()(container, primary);
          }
        });
      })
    ].concat(detail.navigateOnHover() ? [run(hover(), function (sandbox, simulatedEvent) {
        var item = simulatedEvent.event().item();
        updateView(sandbox, item);
        expandRight(sandbox, item);
        detail.onHover()(sandbox, item);
      })] : []));
    var collapseMenuApi = function (container) {
      Highlighting.getHighlighted(container).each(function (currentMenu) {
        Highlighting.getHighlighted(currentMenu).each(function (currentItem) {
          collapseLeft(container, currentItem);
        });
      });
    };
    return {
      uid: detail.uid(),
      dom: detail.dom(),
      behaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2([
        Keying.config({
          mode: 'special',
          onRight: keyOnItem(onRight),
          onLeft: keyOnItem(onLeft),
          onEscape: keyOnItem(onEscape),
          focusIn: function (container, keyInfo) {
            state.getPrimary().each(function (primary) {
              dispatch(container, primary.element(), focusItem());
            });
          }
        }),
        Highlighting.config({
          highlightClass: detail.markers().selectedMenu(),
          itemClass: detail.markers().menu()
        }),
        Composing.config({
          find: function (container) {
            return Highlighting.getHighlighted(container);
          }
        }),
        Replacing.config({})
      ]), get$5(detail.tmenuBehaviours())),
      eventOrder: detail.eventOrder(),
      apis: { collapseMenu: collapseMenuApi },
      events: events
    };
  };
  var collapseItem = $_2vokfcwwjfuw8tb4.constant('collapse-item');

  var tieredData = function (primary, menus, expansions) {
    return {
      primary: primary,
      menus: menus,
      expansions: expansions
    };
  };
  var singleData = function (name, menu) {
    return {
      primary: name,
      menus: wrap$2(name, menu),
      expansions: {}
    };
  };
  var collapseItem$1 = function (text) {
    return {
      value: $_5j06su11ajfuw8u1p.generate(collapseItem()),
      text: text
    };
  };
  var TieredMenu = single$2({
    name: 'TieredMenu',
    configFields: [
      onStrictKeyboardHandler('onExecute'),
      onStrictKeyboardHandler('onEscape'),
      onStrictHandler('onOpenMenu'),
      onStrictHandler('onOpenSubmenu'),
      onHandler('onCollapseMenu'),
      defaulted$1('openImmediately', true),
      strictObjOf('data', [
        strict$1('primary'),
        strict$1('menus'),
        strict$1('expansions')
      ]),
      defaulted$1('fakeFocus', false),
      onHandler('onHighlight'),
      onHandler('onHover'),
      tieredMenuMarkers(),
      strict$1('dom'),
      defaulted$1('navigateOnHover', true),
      defaulted$1('stayInDom', false),
      field$1('tmenuBehaviours', [
        Keying,
        Highlighting,
        Composing,
        Replacing
      ]),
      defaulted$1('eventOrder', {})
    ],
    apis: {
      collapseMenu: function (apis, tmenu) {
        apis.collapseMenu(tmenu);
      }
    },
    factory: make$3,
    extraApis: {
      tieredData: tieredData,
      singleData: singleData,
      collapseItem: collapseItem$1
    }
  });

  var findRoute = function (component, transConfig, transState, route) {
    return readOptFrom$1(transConfig.routes(), route.start()).map($_2vokfcwwjfuw8tb4.apply).bind(function (sConfig) {
      return readOptFrom$1(sConfig, route.destination()).map($_2vokfcwwjfuw8tb4.apply);
    });
  };
  var getTransition = function (comp, transConfig, transState) {
    var route = getCurrentRoute(comp, transConfig, transState);
    return route.bind(function (r) {
      return getTransitionOf(comp, transConfig, transState, r);
    });
  };
  var getTransitionOf = function (comp, transConfig, transState, route) {
    return findRoute(comp, transConfig, transState, route).bind(function (r) {
      return r.transition().map(function (t) {
        return {
          transition: $_2vokfcwwjfuw8tb4.constant(t),
          route: $_2vokfcwwjfuw8tb4.constant(r)
        };
      });
    });
  };
  var disableTransition = function (comp, transConfig, transState) {
    getTransition(comp, transConfig, transState).each(function (routeTransition) {
      var t = routeTransition.transition();
      $_6po7jxyujfuw8tl0.remove(comp.element(), t.transitionClass());
      $_47adx7ywjfuw8tl3.remove(comp.element(), transConfig.destinationAttr());
    });
  };
  var getNewRoute = function (comp, transConfig, transState, destination) {
    return {
      start: $_2vokfcwwjfuw8tb4.constant($_47adx7ywjfuw8tl3.get(comp.element(), transConfig.stateAttr())),
      destination: $_2vokfcwwjfuw8tb4.constant(destination)
    };
  };
  var getCurrentRoute = function (comp, transConfig, transState) {
    var el = comp.element();
    return $_47adx7ywjfuw8tl3.has(el, transConfig.destinationAttr()) ? Option.some({
      start: $_2vokfcwwjfuw8tb4.constant($_47adx7ywjfuw8tl3.get(comp.element(), transConfig.stateAttr())),
      destination: $_2vokfcwwjfuw8tb4.constant($_47adx7ywjfuw8tl3.get(comp.element(), transConfig.destinationAttr()))
    }) : Option.none();
  };
  var jumpTo = function (comp, transConfig, transState, destination) {
    disableTransition(comp, transConfig, transState);
    if ($_47adx7ywjfuw8tl3.has(comp.element(), transConfig.stateAttr()) && $_47adx7ywjfuw8tl3.get(comp.element(), transConfig.stateAttr()) !== destination) {
      transConfig.onFinish()(comp, destination);
    }
    $_47adx7ywjfuw8tl3.set(comp.element(), transConfig.stateAttr(), destination);
  };
  var fasttrack = function (comp, transConfig, transState, destination) {
    if ($_47adx7ywjfuw8tl3.has(comp.element(), transConfig.destinationAttr())) {
      $_47adx7ywjfuw8tl3.set(comp.element(), transConfig.stateAttr(), $_47adx7ywjfuw8tl3.get(comp.element(), transConfig.destinationAttr()));
      $_47adx7ywjfuw8tl3.remove(comp.element(), transConfig.destinationAttr());
    }
  };
  var progressTo = function (comp, transConfig, transState, destination) {
    fasttrack(comp, transConfig, transState, destination);
    var route = getNewRoute(comp, transConfig, transState, destination);
    getTransitionOf(comp, transConfig, transState, route).fold(function () {
      jumpTo(comp, transConfig, transState, destination);
    }, function (routeTransition) {
      disableTransition(comp, transConfig, transState);
      var t = routeTransition.transition();
      $_6po7jxyujfuw8tl0.add(comp.element(), t.transitionClass());
      $_47adx7ywjfuw8tl3.set(comp.element(), transConfig.destinationAttr(), destination);
    });
  };
  var getState = function (comp, transConfig, transState) {
    var e = comp.element();
    return $_47adx7ywjfuw8tl3.has(e, transConfig.stateAttr()) ? Option.some($_47adx7ywjfuw8tl3.get(e, transConfig.stateAttr())) : Option.none();
  };


  var TransitionApis = Object.freeze({
  	findRoute: findRoute,
  	disableTransition: disableTransition,
  	getCurrentRoute: getCurrentRoute,
  	jumpTo: jumpTo,
  	progressTo: progressTo,
  	getState: getState
  });

  var events$8 = function (transConfig, transState) {
    return derive([
      run(transitionend(), function (component, simulatedEvent) {
        var raw = simulatedEvent.event().raw();
        getCurrentRoute(component, transConfig, transState).each(function (route) {
          findRoute(component, transConfig, transState, route).each(function (rInfo) {
            rInfo.transition().each(function (rTransition) {
              if (raw.propertyName === rTransition.property()) {
                jumpTo(component, transConfig, transState, route.destination());
                transConfig.onTransition()(component, route);
              }
            });
          });
        });
      }),
      runOnAttached(function (comp, se) {
        jumpTo(comp, transConfig, transState, transConfig.initialState());
      })
    ]);
  };


  var ActiveTransitioning = Object.freeze({
  	events: events$8
  });

  var TransitionSchema = [
    defaulted$1('destinationAttr', 'data-transitioning-destination'),
    defaulted$1('stateAttr', 'data-transitioning-state'),
    strict$1('initialState'),
    onHandler('onTransition'),
    onHandler('onFinish'),
    strictOf('routes', setOf(Result.value, setOf(Result.value, objOfOnly([optionObjOfOnly('transition', [
        strict$1('property'),
        strict$1('transitionClass')
      ])]))))
  ];

  var createRoutes = function (routes) {
    var r = {};
    $_8qu224wzjfuw8tb9.each(routes, function (v, k) {
      var waypoints = k.split('<->');
      r[waypoints[0]] = wrap$2(waypoints[1], v);
      r[waypoints[1]] = wrap$2(waypoints[0], v);
    });
    return r;
  };
  var createBistate = function (first, second, transitions) {
    return wrapAll$1([
      {
        key: first,
        value: wrap$2(second, transitions)
      },
      {
        key: second,
        value: wrap$2(first, transitions)
      }
    ]);
  };
  var createTristate = function (first, second, third, transitions) {
    return wrapAll$1([
      {
        key: first,
        value: wrapAll$1([
          {
            key: second,
            value: transitions
          },
          {
            key: third,
            value: transitions
          }
        ])
      },
      {
        key: second,
        value: wrapAll$1([
          {
            key: first,
            value: transitions
          },
          {
            key: third,
            value: transitions
          }
        ])
      },
      {
        key: third,
        value: wrapAll$1([
          {
            key: first,
            value: transitions
          },
          {
            key: second,
            value: transitions
          }
        ])
      }
    ]);
  };
  var Transitioning = create$1({
    fields: TransitionSchema,
    name: 'transitioning',
    active: ActiveTransitioning,
    apis: TransitionApis,
    extra: {
      createRoutes: createRoutes,
      createBistate: createBistate,
      createTristate: createTristate
    }
  });

  var scrollable = $_2fp9skztjfuw8tqe.resolve('scrollable');
  var register = function (element) {
    $_6po7jxyujfuw8tl0.add(element, scrollable);
  };
  var deregister = function (element) {
    $_6po7jxyujfuw8tl0.remove(element, scrollable);
  };
  var $_3pnsue149jfuw8uqb = {
    register: register,
    deregister: deregister,
    scrollable: $_2vokfcwwjfuw8tb4.constant(scrollable)
  };

  var getValue$4 = function (item) {
    return readOptFrom$1(item, 'format').getOr(item.title);
  };
  var convert$1 = function (formats, memMenuThunk) {
    var mainMenu = makeMenu('Styles', [].concat($_efmt4zxbjfuw8tcj.map(formats.items, function (k) {
      return makeItem(getValue$4(k), k.title, k.isSelected(), k.getPreview(), hasKey$1(formats.expansions, getValue$4(k)));
    })), memMenuThunk, false);
    var submenus = $_8qu224wzjfuw8tb9.map(formats.menus, function (menuItems, menuName) {
      var items = $_efmt4zxbjfuw8tcj.map(menuItems, function (item) {
        return makeItem(getValue$4(item), item.title, item.isSelected !== undefined ? item.isSelected() : false, item.getPreview !== undefined ? item.getPreview() : '', hasKey$1(formats.expansions, getValue$4(item)));
      });
      return makeMenu(menuName, items, memMenuThunk, true);
    });
    var menus = $_3jctjywxjfuw8tb6.deepMerge(submenus, wrap$2('styles', mainMenu));
    var tmenu = TieredMenu.tieredData('styles', menus, formats.expansions);
    return { tmenu: tmenu };
  };
  var makeItem = function (value, text$$1, selected, preview, isMenu) {
    return {
      data: {
        value: value,
        text: text$$1
      },
      type: 'item',
      dom: {
        tag: 'div',
        classes: isMenu ? [$_2fp9skztjfuw8tqe.resolve('styles-item-is-menu')] : []
      },
      toggling: {
        toggleOnExecute: false,
        toggleClass: $_2fp9skztjfuw8tqe.resolve('format-matches'),
        selected: selected
      },
      itemBehaviours: derive$2(isMenu ? [] : [$_9de9iyzsjfuw8tqa.format(value, function (comp, status) {
          var toggle = status ? Toggling.on : Toggling.off;
          toggle(comp);
        })]),
      components: [{
          dom: {
            tag: 'div',
            attributes: { style: preview },
            innerHtml: text$$1
          }
        }]
    };
  };
  var makeMenu = function (value, items, memMenuThunk, collapsable) {
    return {
      value: value,
      dom: { tag: 'div' },
      components: [
        Button.sketch({
          dom: {
            tag: 'div',
            classes: [$_2fp9skztjfuw8tqe.resolve('styles-collapser')]
          },
          components: collapsable ? [
            {
              dom: {
                tag: 'span',
                classes: [$_2fp9skztjfuw8tqe.resolve('styles-collapse-icon')]
              }
            },
            text(value)
          ] : [text(value)],
          action: function (item) {
            if (collapsable) {
              var comp = memMenuThunk().get(item);
              TieredMenu.collapseMenu(comp);
            }
          }
        }),
        {
          dom: {
            tag: 'div',
            classes: [$_2fp9skztjfuw8tqe.resolve('styles-menu-items-container')]
          },
          components: [Menu.parts().items({})],
          behaviours: derive$2([config('adhoc-scrollable-menu', [
              runOnAttached(function (component, simulatedEvent) {
                $_aag5ti106jfuw8tse.set(component.element(), 'overflow-y', 'auto');
                $_aag5ti106jfuw8tse.set(component.element(), '-webkit-overflow-scrolling', 'touch');
                $_3pnsue149jfuw8uqb.register(component.element());
              }),
              runOnDetached(function (component) {
                $_aag5ti106jfuw8tse.remove(component.element(), 'overflow-y');
                $_aag5ti106jfuw8tse.remove(component.element(), '-webkit-overflow-scrolling');
                $_3pnsue149jfuw8uqb.deregister(component.element());
              })
            ])])
        }
      ],
      items: items,
      menuBehaviours: derive$2([Transitioning.config({
          initialState: 'after',
          routes: Transitioning.createTristate('before', 'current', 'after', {
            transition: {
              property: 'transform',
              transitionClass: 'transitioning'
            }
          })
        })])
    };
  };
  var sketch$9 = function (settings) {
    var dataset = convert$1(settings.formats, function () {
      return memMenu;
    });
    var memMenu = record(TieredMenu.sketch({
      dom: {
        tag: 'div',
        classes: [$_2fp9skztjfuw8tqe.resolve('styles-menu')]
      },
      components: [],
      fakeFocus: true,
      stayInDom: true,
      onExecute: function (tmenu, item) {
        var v = Representing.getValue(item);
        settings.handle(item, v.value);
      },
      onEscape: function () {
      },
      onOpenMenu: function (container, menu) {
        var w = $_dsj1h711zjfuw8u73.get(container.element());
        $_dsj1h711zjfuw8u73.set(menu.element(), w);
        Transitioning.jumpTo(menu, 'current');
      },
      onOpenSubmenu: function (container, item, submenu) {
        var w = $_dsj1h711zjfuw8u73.get(container.element());
        var menu = $_c8lemt10bjfuw8tt8.ancestor(item.element(), '[role="menu"]').getOrDie('hacky');
        var menuComp = container.getSystem().getByDom(menu).getOrDie();
        $_dsj1h711zjfuw8u73.set(submenu.element(), w);
        Transitioning.progressTo(menuComp, 'before');
        Transitioning.jumpTo(submenu, 'after');
        Transitioning.progressTo(submenu, 'current');
      },
      onCollapseMenu: function (container, item, menu) {
        var submenu = $_c8lemt10bjfuw8tt8.ancestor(item.element(), '[role="menu"]').getOrDie('hacky');
        var submenuComp = container.getSystem().getByDom(submenu).getOrDie();
        Transitioning.progressTo(submenuComp, 'after');
        Transitioning.progressTo(menu, 'current');
      },
      navigateOnHover: false,
      openImmediately: true,
      data: dataset.tmenu,
      markers: {
        backgroundMenu: $_2fp9skztjfuw8tqe.resolve('styles-background-menu'),
        menu: $_2fp9skztjfuw8tqe.resolve('styles-menu'),
        selectedMenu: $_2fp9skztjfuw8tqe.resolve('styles-selected-menu'),
        item: $_2fp9skztjfuw8tqe.resolve('styles-item'),
        selectedItem: $_2fp9skztjfuw8tqe.resolve('styles-selected-item')
      }
    }));
    return memMenu.asSpec();
  };
  var $_bf3tu6137jfuw8ufb = { sketch: sketch$9 };

  var getFromExpandingItem = function (item) {
    var newItem = $_3jctjywxjfuw8tb6.deepMerge(exclude$1(item, ['items']), { menu: true });
    var rest = expand(item.items);
    var newMenus = $_3jctjywxjfuw8tb6.deepMerge(rest.menus, wrap$2(item.title, rest.items));
    var newExpansions = $_3jctjywxjfuw8tb6.deepMerge(rest.expansions, wrap$2(item.title, item.title));
    return {
      item: newItem,
      menus: newMenus,
      expansions: newExpansions
    };
  };
  var getFromItem = function (item) {
    return hasKey$1(item, 'items') ? getFromExpandingItem(item) : {
      item: item,
      menus: {},
      expansions: {}
    };
  };
  var expand = function (items) {
    return $_efmt4zxbjfuw8tcj.foldr(items, function (acc, item) {
      var newData = getFromItem(item);
      return {
        menus: $_3jctjywxjfuw8tb6.deepMerge(acc.menus, newData.menus),
        items: [newData.item].concat(acc.items),
        expansions: $_3jctjywxjfuw8tb6.deepMerge(acc.expansions, newData.expansions)
      };
    }, {
      menus: {},
      expansions: {},
      items: []
    });
  };
  var $_2ogda014ajfuw8uqg = { expand: expand };

  var register$1 = function (editor, settings) {
    var isSelectedFor = function (format) {
      return function () {
        return editor.formatter.match(format);
      };
    };
    var getPreview = function (format) {
      return function () {
        var styles = editor.formatter.getCssText(format);
        return styles;
      };
    };
    var enrichSupported = function (item) {
      return $_3jctjywxjfuw8tb6.deepMerge(item, {
        isSelected: isSelectedFor(item.format),
        getPreview: getPreview(item.format)
      });
    };
    var enrichMenu = function (item) {
      return $_3jctjywxjfuw8tb6.deepMerge(item, {
        isSelected: $_2vokfcwwjfuw8tb4.constant(false),
        getPreview: $_2vokfcwwjfuw8tb4.constant('')
      });
    };
    var enrichCustom = function (item) {
      var formatName = $_5j06su11ajfuw8u1p.generate(item.title);
      var newItem = $_3jctjywxjfuw8tb6.deepMerge(item, {
        format: formatName,
        isSelected: isSelectedFor(formatName),
        getPreview: getPreview(formatName)
      });
      editor.formatter.register(formatName, newItem);
      return newItem;
    };
    var formats = readOptFrom$1(settings, 'style_formats').getOr(DefaultStyleFormats);
    var doEnrich = function (items) {
      return $_efmt4zxbjfuw8tcj.map(items, function (item) {
        if (hasKey$1(item, 'items')) {
          var newItems = doEnrich(item.items);
          return $_3jctjywxjfuw8tb6.deepMerge(enrichMenu(item), { items: newItems });
        } else if (hasKey$1(item, 'format')) {
          return enrichSupported(item);
        } else {
          return enrichCustom(item);
        }
      });
    };
    return doEnrich(formats);
  };
  var prune = function (editor, formats) {
    var doPrune = function (items) {
      return $_efmt4zxbjfuw8tcj.bind(items, function (item) {
        if (item.items !== undefined) {
          var newItems = doPrune(item.items);
          return newItems.length > 0 ? [item] : [];
        } else {
          var keep = hasKey$1(item, 'format') ? editor.formatter.canApply(item.format) : true;
          return keep ? [item] : [];
        }
      });
    };
    var prunedItems = doPrune(formats);
    return $_2ogda014ajfuw8uqg.expand(prunedItems);
  };
  var ui = function (editor, formats, onDone) {
    var pruned = prune(editor, formats);
    return $_bf3tu6137jfuw8ufb.sketch({
      formats: pruned,
      handle: function (item, value) {
        editor.undoManager.transact(function () {
          if (Toggling.isOn(item)) {
            editor.formatter.remove(value);
          } else {
            editor.formatter.apply(value);
          }
        });
        onDone();
      }
    });
  };
  var $_816rke135jfuw8uey = {
    register: register$1,
    ui: ui
  };

  var defaults = [
    'undo',
    'bold',
    'italic',
    'link',
    'image',
    'bullist',
    'styleselect'
  ];
  var extract$1 = function (rawToolbar) {
    var toolbar = rawToolbar.replace(/\|/g, ' ').trim();
    return toolbar.length > 0 ? toolbar.split(/\s+/) : [];
  };
  var identifyFromArray = function (toolbar) {
    return $_efmt4zxbjfuw8tcj.bind(toolbar, function (item) {
      return $_8aqeo3wyjfuw8tb8.isArray(item) ? identifyFromArray(item) : extract$1(item);
    });
  };
  var identify = function (settings) {
    var toolbar = settings.toolbar !== undefined ? settings.toolbar : defaults;
    return $_8aqeo3wyjfuw8tb8.isArray(toolbar) ? identifyFromArray(toolbar) : extract$1(toolbar);
  };
  var setup = function (realm, editor) {
    var commandSketch = function (name) {
      return function () {
        return $_44weuozujfuw8tqh.forToolbarCommand(editor, name);
      };
    };
    var stateCommandSketch = function (name) {
      return function () {
        return $_44weuozujfuw8tqh.forToolbarStateCommand(editor, name);
      };
    };
    var actionSketch = function (name, query, action) {
      return function () {
        return $_44weuozujfuw8tqh.forToolbarStateAction(editor, name, query, action);
      };
    };
    var undo = commandSketch('undo');
    var redo = commandSketch('redo');
    var bold = stateCommandSketch('bold');
    var italic = stateCommandSketch('italic');
    var underline = stateCommandSketch('underline');
    var removeformat = commandSketch('removeformat');
    var link = function () {
      return sketch$8(realm, editor);
    };
    var unlink = actionSketch('unlink', 'link', function () {
      editor.execCommand('unlink', null, false);
    });
    var image = function () {
      return sketch$5(editor);
    };
    var bullist = actionSketch('unordered-list', 'ul', function () {
      editor.execCommand('InsertUnorderedList', null, false);
    });
    var numlist = actionSketch('ordered-list', 'ol', function () {
      editor.execCommand('InsertOrderedList', null, false);
    });
    var fontsizeselect = function () {
      return sketch$4(realm, editor);
    };
    var forecolor = function () {
      return $_zydxw11kjfuw8u3z.sketch(realm, editor);
    };
    var styleFormats = $_816rke135jfuw8uey.register(editor, editor.settings);
    var styleFormatsMenu = function () {
      return $_816rke135jfuw8uey.ui(editor, styleFormats, function () {
        editor.fire('scrollIntoView');
      });
    };
    var styleselect = function () {
      return $_44weuozujfuw8tqh.forToolbar('style-formats', function (button) {
        editor.fire('toReading');
        realm.dropup().appear(styleFormatsMenu, Toggling.on, button);
      }, derive$2([
        Toggling.config({
          toggleClass: $_2fp9skztjfuw8tqe.resolve('toolbar-button-selected'),
          toggleOnExecute: false,
          aria: { mode: 'pressed' }
        }),
        Receiving.config({
          channels: wrapAll$1([
            $_9de9iyzsjfuw8tqa.receive($_9e19stz9jfuw8tmf.orientationChanged(), Toggling.off),
            $_9de9iyzsjfuw8tqa.receive($_9e19stz9jfuw8tmf.dropupDismissed(), Toggling.off)
          ])
        })
      ]));
    };
    var feature = function (prereq, sketch) {
      return {
        isSupported: function () {
          return prereq.forall(function (p) {
            return hasKey$1(editor.buttons, p);
          });
        },
        sketch: sketch
      };
    };
    return {
      undo: feature(Option.none(), undo),
      redo: feature(Option.none(), redo),
      bold: feature(Option.none(), bold),
      italic: feature(Option.none(), italic),
      underline: feature(Option.none(), underline),
      removeformat: feature(Option.none(), removeformat),
      link: feature(Option.none(), link),
      unlink: feature(Option.none(), unlink),
      image: feature(Option.none(), image),
      bullist: feature(Option.some('bullist'), bullist),
      numlist: feature(Option.some('numlist'), numlist),
      fontsizeselect: feature(Option.none(), fontsizeselect),
      forecolor: feature(Option.none(), forecolor),
      styleselect: feature(Option.none(), styleselect)
    };
  };
  var detect$4 = function (settings, features) {
    var itemNames = identify(settings);
    var present = {};
    return $_efmt4zxbjfuw8tcj.bind(itemNames, function (iName) {
      var r = !hasKey$1(present, iName) && hasKey$1(features, iName) && features[iName].isSupported() ? [features[iName].sketch()] : [];
      present[iName] = true;
      return r;
    });
  };
  var $_4419oszajfuw8tmi = {
    identify: identify,
    setup: setup,
    detect: detect$4
  };

  var mkEvent = function (target, x, y, stop, prevent, kill, raw) {
    return {
      'target': $_2vokfcwwjfuw8tb4.constant(target),
      'x': $_2vokfcwwjfuw8tb4.constant(x),
      'y': $_2vokfcwwjfuw8tb4.constant(y),
      'stop': stop,
      'prevent': prevent,
      'kill': kill,
      'raw': $_2vokfcwwjfuw8tb4.constant(raw)
    };
  };
  var handle = function (filter, handler) {
    return function (rawEvent) {
      if (!filter(rawEvent))
        return;
      var target = $_bwdnu0xijfuw8tdo.fromDom(rawEvent.target);
      var stop = function () {
        rawEvent.stopPropagation();
      };
      var prevent = function () {
        rawEvent.preventDefault();
      };
      var kill = $_2vokfcwwjfuw8tb4.compose(prevent, stop);
      var evt = mkEvent(target, rawEvent.clientX, rawEvent.clientY, stop, prevent, kill, rawEvent);
      handler(evt);
    };
  };
  var binder = function (element, event, filter, handler, useCapture) {
    var wrapped = handle(filter, handler);
    element.dom().addEventListener(event, wrapped, useCapture);
    return { unbind: $_2vokfcwwjfuw8tb4.curry(unbind, element, event, wrapped, useCapture) };
  };
  var bind$1 = function (element, event, filter, handler) {
    return binder(element, event, filter, handler, false);
  };
  var capture = function (element, event, filter, handler) {
    return binder(element, event, filter, handler, true);
  };
  var unbind = function (element, event, handler, useCapture) {
    element.dom().removeEventListener(event, handler, useCapture);
  };
  var $_2sq5yy14djfuw8ur4 = {
    bind: bind$1,
    capture: capture
  };

  var filter$1 = $_2vokfcwwjfuw8tb4.constant(true);
  var bind$2 = function (element, event, handler) {
    return $_2sq5yy14djfuw8ur4.bind(element, event, filter$1, handler);
  };
  var capture$1 = function (element, event, handler) {
    return $_2sq5yy14djfuw8ur4.capture(element, event, filter$1, handler);
  };
  var $_6cl0bk14cjfuw8uqx = {
    bind: bind$2,
    capture: capture$1
  };

  var INTERVAL = 50;
  var INSURANCE = 1000 / INTERVAL;
  var get$11 = function (outerWindow) {
    var isPortrait = outerWindow.matchMedia('(orientation: portrait)').matches;
    return { isPortrait: $_2vokfcwwjfuw8tb4.constant(isPortrait) };
  };
  var getActualWidth = function (outerWindow) {
    var isIos = $_5reqwox3jfuw8tbu.detect().os.isiOS();
    var isPortrait = get$11(outerWindow).isPortrait();
    return isIos && !isPortrait ? outerWindow.screen.height : outerWindow.screen.width;
  };
  var onChange = function (outerWindow, listeners) {
    var win = $_bwdnu0xijfuw8tdo.fromDom(outerWindow);
    var poller = null;
    var change = function () {
      clearInterval(poller);
      var orientation = get$11(outerWindow);
      listeners.onChange(orientation);
      onAdjustment(function () {
        listeners.onReady(orientation);
      });
    };
    var orientationHandle = $_6cl0bk14cjfuw8uqx.bind(win, 'orientationchange', change);
    var onAdjustment = function (f) {
      clearInterval(poller);
      var flag = outerWindow.innerHeight;
      var insurance = 0;
      poller = setInterval(function () {
        if (flag !== outerWindow.innerHeight) {
          clearInterval(poller);
          f(Option.some(outerWindow.innerHeight));
        } else if (insurance > INSURANCE) {
          clearInterval(poller);
          f(Option.none());
        }
        insurance++;
      }, INTERVAL);
    };
    var destroy = function () {
      orientationHandle.unbind();
    };
    return {
      onAdjustment: onAdjustment,
      destroy: destroy
    };
  };
  var $_2v9f8x14bjfuw8uqn = {
    get: get$11,
    onChange: onChange,
    getActualWidth: getActualWidth
  };

  function DelayedFunction (fun, delay) {
    var ref = null;
    var schedule = function () {
      var any = [];
      for (var _i = 0; _i < arguments.length; _i++) {
        any[_i] = arguments[_i];
      }
      var args = arguments;
      ref = setTimeout(function () {
        fun.apply(null, args);
        ref = null;
      }, delay);
    };
    var cancel = function () {
      if (ref !== null) {
        clearTimeout(ref);
        ref = null;
      }
    };
    return {
      cancel: cancel,
      schedule: schedule
    };
  }

  var SIGNIFICANT_MOVE = 5;
  var LONGPRESS_DELAY = 400;
  var getTouch = function (event) {
    if (event.raw().touches === undefined || event.raw().touches.length !== 1) {
      return Option.none();
    }
    return Option.some(event.raw().touches[0]);
  };
  var isFarEnough = function (touch, data) {
    var distX = Math.abs(touch.clientX - data.x());
    var distY = Math.abs(touch.clientY - data.y());
    return distX > SIGNIFICANT_MOVE || distY > SIGNIFICANT_MOVE;
  };
  var monitor = function (settings) {
    var startData = Cell(Option.none());
    var longpress$$1 = DelayedFunction(function (event) {
      startData.set(Option.none());
      settings.triggerEvent(longpress(), event);
    }, LONGPRESS_DELAY);
    var handleTouchstart = function (event) {
      getTouch(event).each(function (touch) {
        longpress$$1.cancel();
        var data = {
          x: $_2vokfcwwjfuw8tb4.constant(touch.clientX),
          y: $_2vokfcwwjfuw8tb4.constant(touch.clientY),
          target: event.target
        };
        longpress$$1.schedule(event);
        startData.set(Option.some(data));
      });
      return Option.none();
    };
    var handleTouchmove = function (event) {
      longpress$$1.cancel();
      getTouch(event).each(function (touch) {
        startData.get().each(function (data) {
          if (isFarEnough(touch, data)) {
            startData.set(Option.none());
          }
        });
      });
      return Option.none();
    };
    var handleTouchend = function (event) {
      longpress$$1.cancel();
      var isSame = function (data) {
        return $_4867a0xsjfuw8tej.eq(data.target(), event.target());
      };
      return startData.get().filter(isSame).map(function (data) {
        return settings.triggerEvent(tap(), event);
      });
    };
    var handlers = wrapAll$1([
      {
        key: touchstart(),
        value: handleTouchstart
      },
      {
        key: touchmove(),
        value: handleTouchmove
      },
      {
        key: touchend(),
        value: handleTouchend
      }
    ]);
    var fireIfReady = function (event, type) {
      return readOptFrom$1(handlers, type).bind(function (handler) {
        return handler(event);
      });
    };
    return { fireIfReady: fireIfReady };
  };

  var monitor$1 = function (editorApi) {
    var tapEvent = monitor({
      triggerEvent: function (type, evt) {
        editorApi.onTapContent(evt);
      }
    });
    var onTouchend = function () {
      return $_6cl0bk14cjfuw8uqx.bind(editorApi.body(), 'touchend', function (evt) {
        tapEvent.fireIfReady(evt, 'touchend');
      });
    };
    var onTouchmove = function () {
      return $_6cl0bk14cjfuw8uqx.bind(editorApi.body(), 'touchmove', function (evt) {
        tapEvent.fireIfReady(evt, 'touchmove');
      });
    };
    var fireTouchstart = function (evt) {
      tapEvent.fireIfReady(evt, 'touchstart');
    };
    return {
      fireTouchstart: fireTouchstart,
      onTouchend: onTouchend,
      onTouchmove: onTouchmove
    };
  };
  var $_bz8sbn14ijfuw8usd = { monitor: monitor$1 };

  var isAndroid6 = $_5reqwox3jfuw8tbu.detect().os.version.major >= 6;
  var initEvents = function (editorApi, toolstrip, alloy) {
    var tapping = $_bz8sbn14ijfuw8usd.monitor(editorApi);
    var outerDoc = $_aff64dxmjfuw8tdx.owner(toolstrip);
    var isRanged = function (sel) {
      return !$_4867a0xsjfuw8tej.eq(sel.start(), sel.finish()) || sel.soffset() !== sel.foffset();
    };
    var hasRangeInUi = function () {
      return $_f15fvwz1jfuw8tlo.active(outerDoc).filter(function (input) {
        return $_74lhjaxjjfuw8tdt.name(input) === 'input';
      }).exists(function (input) {
        return input.dom().selectionStart !== input.dom().selectionEnd;
      });
    };
    var updateMargin = function () {
      var rangeInContent = editorApi.doc().dom().hasFocus() && editorApi.getSelection().exists(isRanged);
      alloy.getByDom(toolstrip).each((rangeInContent || hasRangeInUi()) === true ? Toggling.on : Toggling.off);
    };
    var listeners = [
      $_6cl0bk14cjfuw8uqx.bind(editorApi.body(), 'touchstart', function (evt) {
        editorApi.onTouchContent();
        tapping.fireTouchstart(evt);
      }),
      tapping.onTouchmove(),
      tapping.onTouchend(),
      $_6cl0bk14cjfuw8uqx.bind(toolstrip, 'touchstart', function (evt) {
        editorApi.onTouchToolstrip();
      }),
      editorApi.onToReading(function () {
        $_f15fvwz1jfuw8tlo.blur(editorApi.body());
      }),
      editorApi.onToEditing($_2vokfcwwjfuw8tb4.noop),
      editorApi.onScrollToCursor(function (tinyEvent) {
        tinyEvent.preventDefault();
        editorApi.getCursorBox().each(function (bounds) {
          var cWin = editorApi.win();
          var isOutside = bounds.top() > cWin.innerHeight || bounds.bottom() > cWin.innerHeight;
          var cScrollBy = isOutside ? bounds.bottom() - cWin.innerHeight + 50 : 0;
          if (cScrollBy !== 0) {
            cWin.scrollTo(cWin.pageXOffset, cWin.pageYOffset + cScrollBy);
          }
        });
      })
    ].concat(isAndroid6 === true ? [] : [
      $_6cl0bk14cjfuw8uqx.bind($_bwdnu0xijfuw8tdo.fromDom(editorApi.win()), 'blur', function () {
        alloy.getByDom(toolstrip).each(Toggling.off);
      }),
      $_6cl0bk14cjfuw8uqx.bind(outerDoc, 'select', updateMargin),
      $_6cl0bk14cjfuw8uqx.bind(editorApi.doc(), 'selectionchange', updateMargin)
    ]);
    var destroy = function () {
      $_efmt4zxbjfuw8tcj.each(listeners, function (l) {
        l.unbind();
      });
    };
    return { destroy: destroy };
  };
  var $_2zmd3p14hjfuw8uru = { initEvents: initEvents };

  var safeParse = function (element, attribute) {
    var parsed = parseInt($_47adx7ywjfuw8tl3.get(element, attribute), 10);
    return isNaN(parsed) ? 0 : parsed;
  };
  var $_f77yow14mjfuw8ut9 = { safeParse: safeParse };

  function NodeValue (is, name) {
    var get = function (element) {
      if (!is(element))
        throw new Error('Can only get ' + name + ' value of a ' + name + ' node');
      return getOption(element).getOr('');
    };
    var getOptionIE10 = function (element) {
      try {
        return getOptionSafe(element);
      } catch (e) {
        return Option.none();
      }
    };
    var getOptionSafe = function (element) {
      return is(element) ? Option.from(element.dom().nodeValue) : Option.none();
    };
    var browser = $_5reqwox3jfuw8tbu.detect().browser;
    var getOption = browser.isIE() && browser.version.major === 10 ? getOptionIE10 : getOptionSafe;
    var set = function (element, value) {
      if (!is(element))
        throw new Error('Can only set raw ' + name + ' value of a ' + name + ' node');
      element.dom().nodeValue = value;
    };
    return {
      get: get,
      getOption: getOption,
      set: set
    };
  }

  var api$3 = NodeValue($_74lhjaxjjfuw8tdt.isText, 'text');
  var get$12 = function (element) {
    return api$3.get(element);
  };
  var getOption = function (element) {
    return api$3.getOption(element);
  };
  var set$8 = function (element, value) {
    api$3.set(element, value);
  };
  var $_18tyjl14pjfuw8utr = {
    get: get$12,
    getOption: getOption,
    set: set$8
  };

  var getEnd = function (element) {
    return $_74lhjaxjjfuw8tdt.name(element) === 'img' ? 1 : $_18tyjl14pjfuw8utr.getOption(element).fold(function () {
      return $_aff64dxmjfuw8tdx.children(element).length;
    }, function (v) {
      return v.length;
    });
  };
  var isEnd = function (element, offset) {
    return getEnd(element) === offset;
  };
  var isStart = function (element, offset) {
    return offset === 0;
  };
  var NBSP = '\xA0';
  var isTextNodeWithCursorPosition = function (el) {
    return $_18tyjl14pjfuw8utr.getOption(el).filter(function (text) {
      return text.trim().length !== 0 || text.indexOf(NBSP) > -1;
    }).isSome();
  };
  var elementsWithCursorPosition = [
    'img',
    'br'
  ];
  var isCursorPosition = function (elem) {
    var hasCursorPosition = isTextNodeWithCursorPosition(elem);
    return hasCursorPosition || $_efmt4zxbjfuw8tcj.contains(elementsWithCursorPosition, $_74lhjaxjjfuw8tdt.name(elem));
  };
  var $_8t9la614ojfuw8uto = {
    getEnd: getEnd,
    isEnd: isEnd,
    isStart: isStart,
    isCursorPosition: isCursorPosition
  };

  var adt$4 = $_dldkf4y5jfuw8tgp.generate([
    { 'before': ['element'] },
    {
      'on': [
        'element',
        'offset'
      ]
    },
    { after: ['element'] }
  ]);
  var cata = function (subject, onBefore, onOn, onAfter) {
    return subject.fold(onBefore, onOn, onAfter);
  };
  var getStart = function (situ) {
    return situ.fold($_2vokfcwwjfuw8tb4.identity, $_2vokfcwwjfuw8tb4.identity, $_2vokfcwwjfuw8tb4.identity);
  };
  var $_d45kr014sjfuw8uu3 = {
    before: adt$4.before,
    on: adt$4.on,
    after: adt$4.after,
    cata: cata,
    getStart: getStart
  };

  var type$1 = $_dldkf4y5jfuw8tgp.generate([
    { domRange: ['rng'] },
    {
      relative: [
        'startSitu',
        'finishSitu'
      ]
    },
    {
      exact: [
        'start',
        'soffset',
        'finish',
        'foffset'
      ]
    }
  ]);
  var range$1 = $_4xhupwxnjfuw8tea.immutable('start', 'soffset', 'finish', 'foffset');
  var exactFromRange = function (simRange) {
    return type$1.exact(simRange.start(), simRange.soffset(), simRange.finish(), simRange.foffset());
  };
  var getStart$1 = function (selection) {
    return selection.match({
      domRange: function (rng) {
        return $_bwdnu0xijfuw8tdo.fromDom(rng.startContainer);
      },
      relative: function (startSitu, finishSitu) {
        return $_d45kr014sjfuw8uu3.getStart(startSitu);
      },
      exact: function (start, soffset, finish, foffset) {
        return start;
      }
    });
  };
  var getWin = function (selection) {
    var start = getStart$1(selection);
    return $_aff64dxmjfuw8tdx.defaultView(start);
  };
  var $_cx764414rjfuw8uty = {
    domRange: type$1.domRange,
    relative: type$1.relative,
    exact: type$1.exact,
    exactFromRange: exactFromRange,
    range: range$1,
    getWin: getWin
  };

  var makeRange = function (start, soffset, finish, foffset) {
    var doc = $_aff64dxmjfuw8tdx.owner(start);
    var rng = doc.dom().createRange();
    rng.setStart(start.dom(), soffset);
    rng.setEnd(finish.dom(), foffset);
    return rng;
  };
  var commonAncestorContainer = function (start, soffset, finish, foffset) {
    var r = makeRange(start, soffset, finish, foffset);
    return $_bwdnu0xijfuw8tdo.fromDom(r.commonAncestorContainer);
  };
  var after$2 = function (start, soffset, finish, foffset) {
    var r = makeRange(start, soffset, finish, foffset);
    var same = $_4867a0xsjfuw8tej.eq(start, finish) && soffset === foffset;
    return r.collapsed && !same;
  };
  var $_7xrggl14ujfuw8uuf = {
    after: after$2,
    commonAncestorContainer: commonAncestorContainer
  };

  var fromElements = function (elements, scope) {
    var doc = scope || document;
    var fragment = doc.createDocumentFragment();
    $_efmt4zxbjfuw8tcj.each(elements, function (element) {
      fragment.appendChild(element.dom());
    });
    return $_bwdnu0xijfuw8tdo.fromDom(fragment);
  };
  var $_1c2i9n14vjfuw8uuh = { fromElements: fromElements };

  var selectNodeContents = function (win, element) {
    var rng = win.document.createRange();
    selectNodeContentsUsing(rng, element);
    return rng;
  };
  var selectNodeContentsUsing = function (rng, element) {
    rng.selectNodeContents(element.dom());
  };
  var isWithin = function (outerRange, innerRange) {
    return innerRange.compareBoundaryPoints(outerRange.END_TO_START, outerRange) < 1 && innerRange.compareBoundaryPoints(outerRange.START_TO_END, outerRange) > -1;
  };
  var create$4 = function (win) {
    return win.document.createRange();
  };
  var setStart = function (rng, situ) {
    situ.fold(function (e) {
      rng.setStartBefore(e.dom());
    }, function (e, o) {
      rng.setStart(e.dom(), o);
    }, function (e) {
      rng.setStartAfter(e.dom());
    });
  };
  var setFinish = function (rng, situ) {
    situ.fold(function (e) {
      rng.setEndBefore(e.dom());
    }, function (e, o) {
      rng.setEnd(e.dom(), o);
    }, function (e) {
      rng.setEndAfter(e.dom());
    });
  };
  var replaceWith = function (rng, fragment) {
    deleteContents(rng);
    rng.insertNode(fragment.dom());
  };
  var relativeToNative = function (win, startSitu, finishSitu) {
    var range = win.document.createRange();
    setStart(range, startSitu);
    setFinish(range, finishSitu);
    return range;
  };
  var exactToNative = function (win, start, soffset, finish, foffset) {
    var rng = win.document.createRange();
    rng.setStart(start.dom(), soffset);
    rng.setEnd(finish.dom(), foffset);
    return rng;
  };
  var deleteContents = function (rng) {
    rng.deleteContents();
  };
  var cloneFragment = function (rng) {
    var fragment = rng.cloneContents();
    return $_bwdnu0xijfuw8tdo.fromDom(fragment);
  };
  var toRect = function (rect) {
    return {
      left: $_2vokfcwwjfuw8tb4.constant(rect.left),
      top: $_2vokfcwwjfuw8tb4.constant(rect.top),
      right: $_2vokfcwwjfuw8tb4.constant(rect.right),
      bottom: $_2vokfcwwjfuw8tb4.constant(rect.bottom),
      width: $_2vokfcwwjfuw8tb4.constant(rect.width),
      height: $_2vokfcwwjfuw8tb4.constant(rect.height)
    };
  };
  var getFirstRect = function (rng) {
    var rects = rng.getClientRects();
    var rect = rects.length > 0 ? rects[0] : rng.getBoundingClientRect();
    return rect.width > 0 || rect.height > 0 ? Option.some(rect).map(toRect) : Option.none();
  };
  var getBounds = function (rng) {
    var rect = rng.getBoundingClientRect();
    return rect.width > 0 || rect.height > 0 ? Option.some(rect).map(toRect) : Option.none();
  };
  var toString$1 = function (rng) {
    return rng.toString();
  };
  var $_90n0ki14wjfuw8uuk = {
    create: create$4,
    replaceWith: replaceWith,
    selectNodeContents: selectNodeContents,
    selectNodeContentsUsing: selectNodeContentsUsing,
    relativeToNative: relativeToNative,
    exactToNative: exactToNative,
    deleteContents: deleteContents,
    cloneFragment: cloneFragment,
    getFirstRect: getFirstRect,
    getBounds: getBounds,
    isWithin: isWithin,
    toString: toString$1
  };

  var adt$5 = $_dldkf4y5jfuw8tgp.generate([
    {
      ltr: [
        'start',
        'soffset',
        'finish',
        'foffset'
      ]
    },
    {
      rtl: [
        'start',
        'soffset',
        'finish',
        'foffset'
      ]
    }
  ]);
  var fromRange = function (win, type, range) {
    return type($_bwdnu0xijfuw8tdo.fromDom(range.startContainer), range.startOffset, $_bwdnu0xijfuw8tdo.fromDom(range.endContainer), range.endOffset);
  };
  var getRanges = function (win, selection) {
    return selection.match({
      domRange: function (rng) {
        return {
          ltr: $_2vokfcwwjfuw8tb4.constant(rng),
          rtl: Option.none
        };
      },
      relative: function (startSitu, finishSitu) {
        return {
          ltr: $_ctj1zwx4jfuw8tbw.cached(function () {
            return $_90n0ki14wjfuw8uuk.relativeToNative(win, startSitu, finishSitu);
          }),
          rtl: $_ctj1zwx4jfuw8tbw.cached(function () {
            return Option.some($_90n0ki14wjfuw8uuk.relativeToNative(win, finishSitu, startSitu));
          })
        };
      },
      exact: function (start, soffset, finish, foffset) {
        return {
          ltr: $_ctj1zwx4jfuw8tbw.cached(function () {
            return $_90n0ki14wjfuw8uuk.exactToNative(win, start, soffset, finish, foffset);
          }),
          rtl: $_ctj1zwx4jfuw8tbw.cached(function () {
            return Option.some($_90n0ki14wjfuw8uuk.exactToNative(win, finish, foffset, start, soffset));
          })
        };
      }
    });
  };
  var doDiagnose = function (win, ranges) {
    var rng = ranges.ltr();
    if (rng.collapsed) {
      var reversed = ranges.rtl().filter(function (rev) {
        return rev.collapsed === false;
      });
      return reversed.map(function (rev) {
        return adt$5.rtl($_bwdnu0xijfuw8tdo.fromDom(rev.endContainer), rev.endOffset, $_bwdnu0xijfuw8tdo.fromDom(rev.startContainer), rev.startOffset);
      }).getOrThunk(function () {
        return fromRange(win, adt$5.ltr, rng);
      });
    } else {
      return fromRange(win, adt$5.ltr, rng);
    }
  };
  var diagnose = function (win, selection) {
    var ranges = getRanges(win, selection);
    return doDiagnose(win, ranges);
  };
  var asLtrRange = function (win, selection) {
    var diagnosis = diagnose(win, selection);
    return diagnosis.match({
      ltr: function (start, soffset, finish, foffset) {
        var rng = win.document.createRange();
        rng.setStart(start.dom(), soffset);
        rng.setEnd(finish.dom(), foffset);
        return rng;
      },
      rtl: function (start, soffset, finish, foffset) {
        var rng = win.document.createRange();
        rng.setStart(finish.dom(), foffset);
        rng.setEnd(start.dom(), soffset);
        return rng;
      }
    });
  };
  var $_dmfqjk14xjfuw8uuw = {
    ltr: adt$5.ltr,
    rtl: adt$5.rtl,
    diagnose: diagnose,
    asLtrRange: asLtrRange
  };

  var searchForPoint = function (rectForOffset, x, y, maxX, length) {
    if (length === 0)
      return 0;
    else if (x === maxX)
      return length - 1;
    var xDelta = maxX;
    for (var i = 1; i < length; i++) {
      var rect = rectForOffset(i);
      var curDeltaX = Math.abs(x - rect.left);
      if (y > rect.bottom) {
      } else if (y < rect.top || curDeltaX > xDelta) {
        return i - 1;
      } else {
        xDelta = curDeltaX;
      }
    }
    return 0;
  };
  var inRect = function (rect, x, y) {
    return x >= rect.left && x <= rect.right && y >= rect.top && y <= rect.bottom;
  };
  var $_80479l150jfuw8uvg = {
    inRect: inRect,
    searchForPoint: searchForPoint
  };

  var locateOffset = function (doc, textnode, x, y, rect) {
    var rangeForOffset = function (offset) {
      var r = doc.dom().createRange();
      r.setStart(textnode.dom(), offset);
      r.collapse(true);
      return r;
    };
    var rectForOffset = function (offset) {
      var r = rangeForOffset(offset);
      return r.getBoundingClientRect();
    };
    var length = $_18tyjl14pjfuw8utr.get(textnode).length;
    var offset = $_80479l150jfuw8uvg.searchForPoint(rectForOffset, x, y, rect.right, length);
    return rangeForOffset(offset);
  };
  var locate$1 = function (doc, node, x, y) {
    var r = doc.dom().createRange();
    r.selectNode(node.dom());
    var rects = r.getClientRects();
    var foundRect = $_e8fwikzljfuw8tp3.findMap(rects, function (rect) {
      return $_80479l150jfuw8uvg.inRect(rect, x, y) ? Option.some(rect) : Option.none();
    });
    return foundRect.map(function (rect) {
      return locateOffset(doc, node, x, y, rect);
    });
  };
  var $_17zjwv151jfuw8uvi = { locate: locate$1 };

  var searchInChildren = function (doc, node, x, y) {
    var r = doc.dom().createRange();
    var nodes = $_aff64dxmjfuw8tdx.children(node);
    return $_e8fwikzljfuw8tp3.findMap(nodes, function (n) {
      r.selectNode(n.dom());
      return $_80479l150jfuw8uvg.inRect(r.getBoundingClientRect(), x, y) ? locateNode(doc, n, x, y) : Option.none();
    });
  };
  var locateNode = function (doc, node, x, y) {
    var locator = $_74lhjaxjjfuw8tdt.isText(node) ? $_17zjwv151jfuw8uvi.locate : searchInChildren;
    return locator(doc, node, x, y);
  };
  var locate$2 = function (doc, node, x, y) {
    var r = doc.dom().createRange();
    r.selectNode(node.dom());
    var rect = r.getBoundingClientRect();
    var boundedX = Math.max(rect.left, Math.min(rect.right, x));
    var boundedY = Math.max(rect.top, Math.min(rect.bottom, y));
    return locateNode(doc, node, boundedX, boundedY);
  };
  var $_bvyyoa14zjfuw8uva = { locate: locate$2 };

  var first$3 = function (element) {
    return $_d0h9pzz3jfuw8tlv.descendant(element, $_8t9la614ojfuw8uto.isCursorPosition);
  };
  var last$2 = function (element) {
    return descendantRtl(element, $_8t9la614ojfuw8uto.isCursorPosition);
  };
  var descendantRtl = function (scope, predicate) {
    var descend = function (element) {
      var children = $_aff64dxmjfuw8tdx.children(element);
      for (var i = children.length - 1; i >= 0; i--) {
        var child = children[i];
        if (predicate(child))
          return Option.some(child);
        var res = descend(child);
        if (res.isSome())
          return res;
      }
      return Option.none();
    };
    return descend(scope);
  };
  var $_cihv40153jfuw8uvr = {
    first: first$3,
    last: last$2
  };

  var COLLAPSE_TO_LEFT = true;
  var COLLAPSE_TO_RIGHT = false;
  var getCollapseDirection = function (rect, x) {
    return x - rect.left < rect.right - x ? COLLAPSE_TO_LEFT : COLLAPSE_TO_RIGHT;
  };
  var createCollapsedNode = function (doc, target, collapseDirection) {
    var r = doc.dom().createRange();
    r.selectNode(target.dom());
    r.collapse(collapseDirection);
    return r;
  };
  var locateInElement = function (doc, node, x) {
    var cursorRange = doc.dom().createRange();
    cursorRange.selectNode(node.dom());
    var rect = cursorRange.getBoundingClientRect();
    var collapseDirection = getCollapseDirection(rect, x);
    var f = collapseDirection === COLLAPSE_TO_LEFT ? $_cihv40153jfuw8uvr.first : $_cihv40153jfuw8uvr.last;
    return f(node).map(function (target) {
      return createCollapsedNode(doc, target, collapseDirection);
    });
  };
  var locateInEmpty = function (doc, node, x) {
    var rect = node.dom().getBoundingClientRect();
    var collapseDirection = getCollapseDirection(rect, x);
    return Option.some(createCollapsedNode(doc, node, collapseDirection));
  };
  var search$1 = function (doc, node, x) {
    var f = $_aff64dxmjfuw8tdx.children(node).length === 0 ? locateInEmpty : locateInElement;
    return f(doc, node, x);
  };
  var $_g8y4zr152jfuw8uvn = { search: search$1 };

  var caretPositionFromPoint = function (doc, x, y) {
    return Option.from(doc.dom().caretPositionFromPoint(x, y)).bind(function (pos) {
      if (pos.offsetNode === null)
        return Option.none();
      var r = doc.dom().createRange();
      r.setStart(pos.offsetNode, pos.offset);
      r.collapse();
      return Option.some(r);
    });
  };
  var caretRangeFromPoint = function (doc, x, y) {
    return Option.from(doc.dom().caretRangeFromPoint(x, y));
  };
  var searchTextNodes = function (doc, node, x, y) {
    var r = doc.dom().createRange();
    r.selectNode(node.dom());
    var rect = r.getBoundingClientRect();
    var boundedX = Math.max(rect.left, Math.min(rect.right, x));
    var boundedY = Math.max(rect.top, Math.min(rect.bottom, y));
    return $_bvyyoa14zjfuw8uva.locate(doc, node, boundedX, boundedY);
  };
  var searchFromPoint = function (doc, x, y) {
    return $_bwdnu0xijfuw8tdo.fromPoint(doc, x, y).bind(function (elem) {
      var fallback = function () {
        return $_g8y4zr152jfuw8uvn.search(doc, elem, x);
      };
      return $_aff64dxmjfuw8tdx.children(elem).length === 0 ? fallback() : searchTextNodes(doc, elem, x, y).orThunk(fallback);
    });
  };
  var availableSearch = document.caretPositionFromPoint ? caretPositionFromPoint : document.caretRangeFromPoint ? caretRangeFromPoint : searchFromPoint;
  var fromPoint$1 = function (win, x, y) {
    var doc = $_bwdnu0xijfuw8tdo.fromDom(win.document);
    return availableSearch(doc, x, y).map(function (rng) {
      return $_cx764414rjfuw8uty.range($_bwdnu0xijfuw8tdo.fromDom(rng.startContainer), rng.startOffset, $_bwdnu0xijfuw8tdo.fromDom(rng.endContainer), rng.endOffset);
    });
  };
  var $_g4cowo14yjfuw8uv6 = { fromPoint: fromPoint$1 };

  var withinContainer = function (win, ancestor, outerRange, selector) {
    var innerRange = $_90n0ki14wjfuw8uuk.create(win);
    var self = $_gem9gixxjfuw8tey.is(ancestor, selector) ? [ancestor] : [];
    var elements = self.concat($_951f03109jfuw8tt3.descendants(ancestor, selector));
    return $_efmt4zxbjfuw8tcj.filter(elements, function (elem) {
      $_90n0ki14wjfuw8uuk.selectNodeContentsUsing(innerRange, elem);
      return $_90n0ki14wjfuw8uuk.isWithin(outerRange, innerRange);
    });
  };
  var find$4 = function (win, selection, selector) {
    var outerRange = $_dmfqjk14xjfuw8uuw.asLtrRange(win, selection);
    var ancestor = $_bwdnu0xijfuw8tdo.fromDom(outerRange.commonAncestorContainer);
    return $_74lhjaxjjfuw8tdt.isElement(ancestor) ? withinContainer(win, ancestor, outerRange, selector) : [];
  };
  var $_4gqnn6154jfuw8uvv = { find: find$4 };

  var beforeSpecial = function (element, offset) {
    var name = $_74lhjaxjjfuw8tdt.name(element);
    if ('input' === name)
      return $_d45kr014sjfuw8uu3.after(element);
    else if (!$_efmt4zxbjfuw8tcj.contains([
        'br',
        'img'
      ], name))
      return $_d45kr014sjfuw8uu3.on(element, offset);
    else
      return offset === 0 ? $_d45kr014sjfuw8uu3.before(element) : $_d45kr014sjfuw8uu3.after(element);
  };
  var preprocessRelative = function (startSitu, finishSitu) {
    var start = startSitu.fold($_d45kr014sjfuw8uu3.before, beforeSpecial, $_d45kr014sjfuw8uu3.after);
    var finish = finishSitu.fold($_d45kr014sjfuw8uu3.before, beforeSpecial, $_d45kr014sjfuw8uu3.after);
    return $_cx764414rjfuw8uty.relative(start, finish);
  };
  var preprocessExact = function (start, soffset, finish, foffset) {
    var startSitu = beforeSpecial(start, soffset);
    var finishSitu = beforeSpecial(finish, foffset);
    return $_cx764414rjfuw8uty.relative(startSitu, finishSitu);
  };
  var preprocess = function (selection) {
    return selection.match({
      domRange: function (rng) {
        var start = $_bwdnu0xijfuw8tdo.fromDom(rng.startContainer);
        var finish = $_bwdnu0xijfuw8tdo.fromDom(rng.endContainer);
        return preprocessExact(start, rng.startOffset, finish, rng.endOffset);
      },
      relative: preprocessRelative,
      exact: preprocessExact
    });
  };
  var $_3ib99q155jfuw8uw0 = {
    beforeSpecial: beforeSpecial,
    preprocess: preprocess,
    preprocessRelative: preprocessRelative,
    preprocessExact: preprocessExact
  };

  var doSetNativeRange = function (win, rng) {
    Option.from(win.getSelection()).each(function (selection) {
      selection.removeAllRanges();
      selection.addRange(rng);
    });
  };
  var doSetRange = function (win, start, soffset, finish, foffset) {
    var rng = $_90n0ki14wjfuw8uuk.exactToNative(win, start, soffset, finish, foffset);
    doSetNativeRange(win, rng);
  };
  var findWithin = function (win, selection, selector) {
    return $_4gqnn6154jfuw8uvv.find(win, selection, selector);
  };
  var setRangeFromRelative = function (win, relative) {
    return $_dmfqjk14xjfuw8uuw.diagnose(win, relative).match({
      ltr: function (start, soffset, finish, foffset) {
        doSetRange(win, start, soffset, finish, foffset);
      },
      rtl: function (start, soffset, finish, foffset) {
        var selection = win.getSelection();
        if (selection.setBaseAndExtent) {
          selection.setBaseAndExtent(start.dom(), soffset, finish.dom(), foffset);
        } else if (selection.extend) {
          selection.collapse(start.dom(), soffset);
          selection.extend(finish.dom(), foffset);
        } else {
          doSetRange(win, finish, foffset, start, soffset);
        }
      }
    });
  };
  var setExact = function (win, start, soffset, finish, foffset) {
    var relative = $_3ib99q155jfuw8uw0.preprocessExact(start, soffset, finish, foffset);
    setRangeFromRelative(win, relative);
  };
  var setRelative = function (win, startSitu, finishSitu) {
    var relative = $_3ib99q155jfuw8uw0.preprocessRelative(startSitu, finishSitu);
    setRangeFromRelative(win, relative);
  };
  var toNative = function (selection) {
    var win = $_cx764414rjfuw8uty.getWin(selection).dom();
    var getDomRange = function (start, soffset, finish, foffset) {
      return $_90n0ki14wjfuw8uuk.exactToNative(win, start, soffset, finish, foffset);
    };
    var filtered = $_3ib99q155jfuw8uw0.preprocess(selection);
    return $_dmfqjk14xjfuw8uuw.diagnose(win, filtered).match({
      ltr: getDomRange,
      rtl: getDomRange
    });
  };
  var readRange = function (selection) {
    if (selection.rangeCount > 0) {
      var firstRng = selection.getRangeAt(0);
      var lastRng = selection.getRangeAt(selection.rangeCount - 1);
      return Option.some($_cx764414rjfuw8uty.range($_bwdnu0xijfuw8tdo.fromDom(firstRng.startContainer), firstRng.startOffset, $_bwdnu0xijfuw8tdo.fromDom(lastRng.endContainer), lastRng.endOffset));
    } else {
      return Option.none();
    }
  };
  var doGetExact = function (selection) {
    var anchorNode = $_bwdnu0xijfuw8tdo.fromDom(selection.anchorNode);
    var focusNode = $_bwdnu0xijfuw8tdo.fromDom(selection.focusNode);
    return $_7xrggl14ujfuw8uuf.after(anchorNode, selection.anchorOffset, focusNode, selection.focusOffset) ? Option.some($_cx764414rjfuw8uty.range($_bwdnu0xijfuw8tdo.fromDom(selection.anchorNode), selection.anchorOffset, $_bwdnu0xijfuw8tdo.fromDom(selection.focusNode), selection.focusOffset)) : readRange(selection);
  };
  var setToElement = function (win, element) {
    var rng = $_90n0ki14wjfuw8uuk.selectNodeContents(win, element);
    doSetNativeRange(win, rng);
  };
  var forElement = function (win, element) {
    var rng = $_90n0ki14wjfuw8uuk.selectNodeContents(win, element);
    return $_cx764414rjfuw8uty.range($_bwdnu0xijfuw8tdo.fromDom(rng.startContainer), rng.startOffset, $_bwdnu0xijfuw8tdo.fromDom(rng.endContainer), rng.endOffset);
  };
  var getExact = function (win) {
    var selection = win.getSelection();
    return selection.rangeCount > 0 ? doGetExact(selection) : Option.none();
  };
  var get$13 = function (win) {
    return getExact(win).map(function (range) {
      return $_cx764414rjfuw8uty.exact(range.start(), range.soffset(), range.finish(), range.foffset());
    });
  };
  var getFirstRect$1 = function (win, selection) {
    var rng = $_dmfqjk14xjfuw8uuw.asLtrRange(win, selection);
    return $_90n0ki14wjfuw8uuk.getFirstRect(rng);
  };
  var getBounds$1 = function (win, selection) {
    var rng = $_dmfqjk14xjfuw8uuw.asLtrRange(win, selection);
    return $_90n0ki14wjfuw8uuk.getBounds(rng);
  };
  var getAtPoint = function (win, x, y) {
    return $_g4cowo14yjfuw8uv6.fromPoint(win, x, y);
  };
  var getAsString = function (win, selection) {
    var rng = $_dmfqjk14xjfuw8uuw.asLtrRange(win, selection);
    return $_90n0ki14wjfuw8uuk.toString(rng);
  };
  var clear$1 = function (win) {
    var selection = win.getSelection();
    selection.removeAllRanges();
  };
  var clone$3 = function (win, selection) {
    var rng = $_dmfqjk14xjfuw8uuw.asLtrRange(win, selection);
    return $_90n0ki14wjfuw8uuk.cloneFragment(rng);
  };
  var replace = function (win, selection, elements) {
    var rng = $_dmfqjk14xjfuw8uuw.asLtrRange(win, selection);
    var fragment = $_1c2i9n14vjfuw8uuh.fromElements(elements, win.document);
    $_90n0ki14wjfuw8uuk.replaceWith(rng, fragment);
  };
  var deleteAt = function (win, selection) {
    var rng = $_dmfqjk14xjfuw8uuw.asLtrRange(win, selection);
    $_90n0ki14wjfuw8uuk.deleteContents(rng);
  };
  var isCollapsed = function (start, soffset, finish, foffset) {
    return $_4867a0xsjfuw8tej.eq(start, finish) && soffset === foffset;
  };
  var $_3h0r8w14tjfuw8uu9 = {
    setExact: setExact,
    getExact: getExact,
    get: get$13,
    setRelative: setRelative,
    toNative: toNative,
    setToElement: setToElement,
    clear: clear$1,
    clone: clone$3,
    replace: replace,
    deleteAt: deleteAt,
    forElement: forElement,
    getFirstRect: getFirstRect$1,
    getBounds: getBounds$1,
    getAtPoint: getAtPoint,
    findWithin: findWithin,
    getAsString: getAsString,
    isCollapsed: isCollapsed
  };

  var COLLAPSED_WIDTH = 2;
  var collapsedRect = function (rect) {
    return {
      left: rect.left,
      top: rect.top,
      right: rect.right,
      bottom: rect.bottom,
      width: $_2vokfcwwjfuw8tb4.constant(COLLAPSED_WIDTH),
      height: rect.height
    };
  };
  var toRect$1 = function (rawRect) {
    return {
      left: $_2vokfcwwjfuw8tb4.constant(rawRect.left),
      top: $_2vokfcwwjfuw8tb4.constant(rawRect.top),
      right: $_2vokfcwwjfuw8tb4.constant(rawRect.right),
      bottom: $_2vokfcwwjfuw8tb4.constant(rawRect.bottom),
      width: $_2vokfcwwjfuw8tb4.constant(rawRect.width),
      height: $_2vokfcwwjfuw8tb4.constant(rawRect.height)
    };
  };
  var getRectsFromRange = function (range) {
    if (!range.collapsed) {
      return $_efmt4zxbjfuw8tcj.map(range.getClientRects(), toRect$1);
    } else {
      var start_1 = $_bwdnu0xijfuw8tdo.fromDom(range.startContainer);
      return $_aff64dxmjfuw8tdx.parent(start_1).bind(function (parent) {
        var selection = $_cx764414rjfuw8uty.exact(start_1, range.startOffset, parent, $_8t9la614ojfuw8uto.getEnd(parent));
        var optRect = $_3h0r8w14tjfuw8uu9.getFirstRect(range.startContainer.ownerDocument.defaultView, selection);
        return optRect.map(collapsedRect).map($_efmt4zxbjfuw8tcj.pure);
      }).getOr([]);
    }
  };
  var getRectangles = function (cWin) {
    var sel = cWin.getSelection();
    return sel !== undefined && sel.rangeCount > 0 ? getRectsFromRange(sel.getRangeAt(0)) : [];
  };
  var $_1h6vvx14njfuw8utc = { getRectangles: getRectangles };

  var autocompleteHack = function () {
    return function (f) {
      setTimeout(function () {
        f();
      }, 0);
    };
  };
  var resume = function (cWin) {
    cWin.focus();
    var iBody = $_bwdnu0xijfuw8tdo.fromDom(cWin.document.body);
    var inInput = $_f15fvwz1jfuw8tlo.active().exists(function (elem) {
      return $_efmt4zxbjfuw8tcj.contains([
        'input',
        'textarea'
      ], $_74lhjaxjjfuw8tdt.name(elem));
    });
    var transaction = inInput ? autocompleteHack() : $_2vokfcwwjfuw8tb4.apply;
    transaction(function () {
      $_f15fvwz1jfuw8tlo.active().each($_f15fvwz1jfuw8tlo.blur);
      $_f15fvwz1jfuw8tlo.focus(iBody);
    });
  };
  var $_655uvc156jfuw8uw4 = { resume: resume };

  var EXTRA_SPACING = 50;
  var data = 'data-' + $_2fp9skztjfuw8tqe.resolve('last-outer-height');
  var setLastHeight = function (cBody, value) {
    $_47adx7ywjfuw8tl3.set(cBody, data, value);
  };
  var getLastHeight = function (cBody) {
    return $_f77yow14mjfuw8ut9.safeParse(cBody, data);
  };
  var getBoundsFrom = function (rect) {
    return {
      top: $_2vokfcwwjfuw8tb4.constant(rect.top()),
      bottom: $_2vokfcwwjfuw8tb4.constant(rect.top() + rect.height())
    };
  };
  var getBounds$2 = function (cWin) {
    var rects = $_1h6vvx14njfuw8utc.getRectangles(cWin);
    return rects.length > 0 ? Option.some(rects[0]).map(getBoundsFrom) : Option.none();
  };
  var findDelta = function (outerWindow, cBody) {
    var last = getLastHeight(cBody);
    var current = outerWindow.innerHeight;
    return last > current ? Option.some(last - current) : Option.none();
  };
  var calculate = function (cWin, bounds, delta) {
    var isOutside = bounds.top() > cWin.innerHeight || bounds.bottom() > cWin.innerHeight;
    return isOutside ? Math.min(delta, bounds.bottom() - cWin.innerHeight + EXTRA_SPACING) : 0;
  };
  var setup$1 = function (outerWindow, cWin) {
    var cBody = $_bwdnu0xijfuw8tdo.fromDom(cWin.document.body);
    var toEditing = function () {
      $_655uvc156jfuw8uw4.resume(cWin);
    };
    var onResize = $_6cl0bk14cjfuw8uqx.bind($_bwdnu0xijfuw8tdo.fromDom(outerWindow), 'resize', function () {
      findDelta(outerWindow, cBody).each(function (delta) {
        getBounds$2(cWin).each(function (bounds) {
          var cScrollBy = calculate(cWin, bounds, delta);
          if (cScrollBy !== 0) {
            cWin.scrollTo(cWin.pageXOffset, cWin.pageYOffset + cScrollBy);
          }
        });
      });
      setLastHeight(cBody, outerWindow.innerHeight);
    });
    setLastHeight(cBody, outerWindow.innerHeight);
    var destroy = function () {
      onResize.unbind();
    };
    return {
      toEditing: toEditing,
      destroy: destroy
    };
  };
  var $_bbby4714ljfuw8usz = { setup: setup$1 };

  var getBodyFromFrame = function (frame) {
    return Option.some($_bwdnu0xijfuw8tdo.fromDom(frame.dom().contentWindow.document.body));
  };
  var getDocFromFrame = function (frame) {
    return Option.some($_bwdnu0xijfuw8tdo.fromDom(frame.dom().contentWindow.document));
  };
  var getWinFromFrame = function (frame) {
    return Option.from(frame.dom().contentWindow);
  };
  var getSelectionFromFrame = function (frame) {
    var optWin = getWinFromFrame(frame);
    return optWin.bind($_3h0r8w14tjfuw8uu9.getExact);
  };
  var getFrame = function (editor) {
    return editor.getFrame();
  };
  var getOrDerive = function (name, f) {
    return function (editor) {
      var g = editor[name].getOrThunk(function () {
        var frame = getFrame(editor);
        return function () {
          return f(frame);
        };
      });
      return g();
    };
  };
  var getOrListen = function (editor, doc, name, type) {
    return editor[name].getOrThunk(function () {
      return function (handler) {
        return $_6cl0bk14cjfuw8uqx.bind(doc, type, handler);
      };
    });
  };
  var toRect$2 = function (rect) {
    return {
      left: $_2vokfcwwjfuw8tb4.constant(rect.left),
      top: $_2vokfcwwjfuw8tb4.constant(rect.top),
      right: $_2vokfcwwjfuw8tb4.constant(rect.right),
      bottom: $_2vokfcwwjfuw8tb4.constant(rect.bottom),
      width: $_2vokfcwwjfuw8tb4.constant(rect.width),
      height: $_2vokfcwwjfuw8tb4.constant(rect.height)
    };
  };
  var getActiveApi = function (editor) {
    var frame = getFrame(editor);
    var tryFallbackBox = function (win) {
      var isCollapsed = function (sel) {
        return $_4867a0xsjfuw8tej.eq(sel.start(), sel.finish()) && sel.soffset() === sel.foffset();
      };
      var toStartRect = function (sel) {
        var rect = sel.start().dom().getBoundingClientRect();
        return rect.width > 0 || rect.height > 0 ? Option.some(rect).map(toRect$2) : Option.none();
      };
      return $_3h0r8w14tjfuw8uu9.getExact(win).filter(isCollapsed).bind(toStartRect);
    };
    return getBodyFromFrame(frame).bind(function (body) {
      return getDocFromFrame(frame).bind(function (doc) {
        return getWinFromFrame(frame).map(function (win) {
          var html = $_bwdnu0xijfuw8tdo.fromDom(doc.dom().documentElement);
          var getCursorBox = editor.getCursorBox.getOrThunk(function () {
            return function () {
              return $_3h0r8w14tjfuw8uu9.get(win).bind(function (sel) {
                return $_3h0r8w14tjfuw8uu9.getFirstRect(win, sel).orThunk(function () {
                  return tryFallbackBox(win);
                });
              });
            };
          });
          var setSelection = editor.setSelection.getOrThunk(function () {
            return function (start, soffset, finish, foffset) {
              $_3h0r8w14tjfuw8uu9.setExact(win, start, soffset, finish, foffset);
            };
          });
          var clearSelection = editor.clearSelection.getOrThunk(function () {
            return function () {
              $_3h0r8w14tjfuw8uu9.clear(win);
            };
          });
          return {
            body: $_2vokfcwwjfuw8tb4.constant(body),
            doc: $_2vokfcwwjfuw8tb4.constant(doc),
            win: $_2vokfcwwjfuw8tb4.constant(win),
            html: $_2vokfcwwjfuw8tb4.constant(html),
            getSelection: $_2vokfcwwjfuw8tb4.curry(getSelectionFromFrame, frame),
            setSelection: setSelection,
            clearSelection: clearSelection,
            frame: $_2vokfcwwjfuw8tb4.constant(frame),
            onKeyup: getOrListen(editor, doc, 'onKeyup', 'keyup'),
            onNodeChanged: getOrListen(editor, doc, 'onNodeChanged', 'selectionchange'),
            onDomChanged: editor.onDomChanged,
            onScrollToCursor: editor.onScrollToCursor,
            onScrollToElement: editor.onScrollToElement,
            onToReading: editor.onToReading,
            onToEditing: editor.onToEditing,
            onToolbarScrollStart: editor.onToolbarScrollStart,
            onTouchContent: editor.onTouchContent,
            onTapContent: editor.onTapContent,
            onTouchToolstrip: editor.onTouchToolstrip,
            getCursorBox: getCursorBox
          };
        });
      });
    });
  };
  var $_9kqusv157jfuw8uwf = {
    getBody: getOrDerive('getBody', getBodyFromFrame),
    getDoc: getOrDerive('getDoc', getDocFromFrame),
    getWin: getOrDerive('getWin', getWinFromFrame),
    getSelection: getOrDerive('getSelection', getSelectionFromFrame),
    getFrame: getFrame,
    getActiveApi: getActiveApi
  };

  var attr = 'data-ephox-mobile-fullscreen-style';
  var siblingStyles = 'display:none!important;';
  var ancestorPosition = 'position:absolute!important;';
  var ancestorStyles = 'top:0!important;left:0!important;margin:0' + '!important;padding:0!important;width:100%!important;';
  var bgFallback = 'background-color:rgb(255,255,255)!important;';
  var isAndroid = $_5reqwox3jfuw8tbu.detect().os.isAndroid();
  var matchColor = function (editorBody) {
    var color = $_aag5ti106jfuw8tse.get(editorBody, 'background-color');
    return color !== undefined && color !== '' ? 'background-color:' + color + '!important' : bgFallback;
  };
  var clobberStyles = function (container, editorBody) {
    var gatherSibilings = function (element) {
      var siblings = $_951f03109jfuw8tt3.siblings(element, '*');
      return siblings;
    };
    var clobber = function (clobberStyle) {
      return function (element) {
        var styles = $_47adx7ywjfuw8tl3.get(element, 'style');
        var backup = styles === undefined ? 'no-styles' : styles.trim();
        if (backup === clobberStyle) {
          return;
        } else {
          $_47adx7ywjfuw8tl3.set(element, attr, backup);
          $_47adx7ywjfuw8tl3.set(element, 'style', clobberStyle);
        }
      };
    };
    var ancestors = $_951f03109jfuw8tt3.ancestors(container, '*');
    var siblings = $_efmt4zxbjfuw8tcj.bind(ancestors, gatherSibilings);
    var bgColor = matchColor(editorBody);
    $_efmt4zxbjfuw8tcj.each(siblings, clobber(siblingStyles));
    $_efmt4zxbjfuw8tcj.each(ancestors, clobber(ancestorPosition + ancestorStyles + bgColor));
    var containerStyles = isAndroid === true ? '' : ancestorPosition;
    clobber(containerStyles + ancestorStyles + bgColor)(container);
  };
  var restoreStyles = function () {
    var clobberedEls = $_951f03109jfuw8tt3.all('[' + attr + ']');
    $_efmt4zxbjfuw8tcj.each(clobberedEls, function (element) {
      var restore = $_47adx7ywjfuw8tl3.get(element, attr);
      if (restore !== 'no-styles') {
        $_47adx7ywjfuw8tl3.set(element, 'style', restore);
      } else {
        $_47adx7ywjfuw8tl3.remove(element, 'style');
      }
      $_47adx7ywjfuw8tl3.remove(element, attr);
    });
  };
  var $_ggb1il158jfuw8uwy = {
    clobberStyles: clobberStyles,
    restoreStyles: restoreStyles
  };

  var tag = function () {
    var head = $_c8lemt10bjfuw8tt8.first('head').getOrDie();
    var nu = function () {
      var meta = $_bwdnu0xijfuw8tdo.fromTag('meta');
      $_47adx7ywjfuw8tl3.set(meta, 'name', 'viewport');
      $_cwa5ncxljfuw8tdv.append(head, meta);
      return meta;
    };
    var element = $_c8lemt10bjfuw8tt8.first('meta[name="viewport"]').getOrThunk(nu);
    var backup = $_47adx7ywjfuw8tl3.get(element, 'content');
    var maximize = function () {
      $_47adx7ywjfuw8tl3.set(element, 'content', 'width=device-width, initial-scale=1.0, user-scalable=no, maximum-scale=1.0');
    };
    var restore = function () {
      if (backup !== undefined && backup !== null && backup.length > 0) {
        $_47adx7ywjfuw8tl3.set(element, 'content', backup);
      } else {
        $_47adx7ywjfuw8tl3.set(element, 'content', 'user-scalable=yes');
      }
    };
    return {
      maximize: maximize,
      restore: restore
    };
  };
  var $_41kbg3159jfuw8ux8 = { tag: tag };

  var create$5 = function (platform, mask) {
    var meta = $_41kbg3159jfuw8ux8.tag();
    var androidApi = $_bh7xqm133jfuw8uet.api();
    var androidEvents = $_bh7xqm133jfuw8uet.api();
    var enter = function () {
      mask.hide();
      $_6po7jxyujfuw8tl0.add(platform.container, $_2fp9skztjfuw8tqe.resolve('fullscreen-maximized'));
      $_6po7jxyujfuw8tl0.add(platform.container, $_2fp9skztjfuw8tqe.resolve('android-maximized'));
      meta.maximize();
      $_6po7jxyujfuw8tl0.add(platform.body, $_2fp9skztjfuw8tqe.resolve('android-scroll-reload'));
      androidApi.set($_bbby4714ljfuw8usz.setup(platform.win, $_9kqusv157jfuw8uwf.getWin(platform.editor).getOrDie('no')));
      $_9kqusv157jfuw8uwf.getActiveApi(platform.editor).each(function (editorApi) {
        $_ggb1il158jfuw8uwy.clobberStyles(platform.container, editorApi.body());
        androidEvents.set($_2zmd3p14hjfuw8uru.initEvents(editorApi, platform.toolstrip, platform.alloy));
      });
    };
    var exit = function () {
      meta.restore();
      mask.show();
      $_6po7jxyujfuw8tl0.remove(platform.container, $_2fp9skztjfuw8tqe.resolve('fullscreen-maximized'));
      $_6po7jxyujfuw8tl0.remove(platform.container, $_2fp9skztjfuw8tqe.resolve('android-maximized'));
      $_ggb1il158jfuw8uwy.restoreStyles();
      $_6po7jxyujfuw8tl0.remove(platform.body, $_2fp9skztjfuw8tqe.resolve('android-scroll-reload'));
      androidEvents.clear();
      androidApi.clear();
    };
    return {
      enter: enter,
      exit: exit
    };
  };
  var $_55cvbw14gjfuw8uro = { create: create$5 };

  var adaptable = function (fn, rate) {
    var timer = null;
    var args = null;
    var cancel = function () {
      if (timer !== null) {
        clearTimeout(timer);
        timer = null;
        args = null;
      }
    };
    var throttle = function () {
      args = arguments;
      if (timer === null) {
        timer = setTimeout(function () {
          fn.apply(null, args);
          timer = null;
          args = null;
        }, rate);
      }
    };
    return {
      cancel: cancel,
      throttle: throttle
    };
  };
  var first$4 = function (fn, rate) {
    var timer = null;
    var cancel = function () {
      if (timer !== null) {
        clearTimeout(timer);
        timer = null;
      }
    };
    var throttle = function () {
      var args = arguments;
      if (timer === null) {
        timer = setTimeout(function () {
          fn.apply(null, args);
          timer = null;
          args = null;
        }, rate);
      }
    };
    return {
      cancel: cancel,
      throttle: throttle
    };
  };
  var last$3 = function (fn, rate) {
    var timer = null;
    var cancel = function () {
      if (timer !== null) {
        clearTimeout(timer);
        timer = null;
      }
    };
    var throttle = function () {
      var args = arguments;
      if (timer !== null)
        clearTimeout(timer);
      timer = setTimeout(function () {
        fn.apply(null, args);
        timer = null;
        args = null;
      }, rate);
    };
    return {
      cancel: cancel,
      throttle: throttle
    };
  };
  var $_6hl53v15bjfuw8uxr = {
    adaptable: adaptable,
    first: first$4,
    last: last$3
  };

  var sketch$10 = function (onView, translate) {
    var memIcon = record(Container.sketch({
      dom: dom$1('<div aria-hidden="true" class="${prefix}-mask-tap-icon"></div>'),
      containerBehaviours: derive$2([Toggling.config({
          toggleClass: $_2fp9skztjfuw8tqe.resolve('mask-tap-icon-selected'),
          toggleOnExecute: false
        })])
    }));
    var onViewThrottle = $_6hl53v15bjfuw8uxr.first(onView, 200);
    return Container.sketch({
      dom: dom$1('<div class="${prefix}-disabled-mask"></div>'),
      components: [Container.sketch({
          dom: dom$1('<div class="${prefix}-content-container"></div>'),
          components: [Button.sketch({
              dom: dom$1('<div class="${prefix}-content-tap-section"></div>'),
              components: [memIcon.asSpec()],
              action: function (button) {
                onViewThrottle.throttle();
              },
              buttonBehaviours: derive$2([Toggling.config({ toggleClass: $_2fp9skztjfuw8tqe.resolve('mask-tap-icon-selected') })])
            })]
        })]
    });
  };
  var $_d5dv5715ajfuw8uxg = { sketch: sketch$10 };

  var MobileSchema = objOf([
    strictObjOf('editor', [
      strict$1('getFrame'),
      option('getBody'),
      option('getDoc'),
      option('getWin'),
      option('getSelection'),
      option('setSelection'),
      option('clearSelection'),
      option('cursorSaver'),
      option('onKeyup'),
      option('onNodeChanged'),
      option('getCursorBox'),
      strict$1('onDomChanged'),
      defaulted$1('onTouchContent', $_2vokfcwwjfuw8tb4.noop),
      defaulted$1('onTapContent', $_2vokfcwwjfuw8tb4.noop),
      defaulted$1('onTouchToolstrip', $_2vokfcwwjfuw8tb4.noop),
      defaulted$1('onScrollToCursor', $_2vokfcwwjfuw8tb4.constant({ unbind: $_2vokfcwwjfuw8tb4.noop })),
      defaulted$1('onScrollToElement', $_2vokfcwwjfuw8tb4.constant({ unbind: $_2vokfcwwjfuw8tb4.noop })),
      defaulted$1('onToEditing', $_2vokfcwwjfuw8tb4.constant({ unbind: $_2vokfcwwjfuw8tb4.noop })),
      defaulted$1('onToReading', $_2vokfcwwjfuw8tb4.constant({ unbind: $_2vokfcwwjfuw8tb4.noop })),
      defaulted$1('onToolbarScrollStart', $_2vokfcwwjfuw8tb4.identity)
    ]),
    strict$1('socket'),
    strict$1('toolstrip'),
    strict$1('dropup'),
    strict$1('toolbar'),
    strict$1('container'),
    strict$1('alloy'),
    state$1('win', function (spec) {
      return $_aff64dxmjfuw8tdx.owner(spec.socket).dom().defaultView;
    }),
    state$1('body', function (spec) {
      return $_bwdnu0xijfuw8tdo.fromDom(spec.socket.dom().ownerDocument.body);
    }),
    defaulted$1('translate', $_2vokfcwwjfuw8tb4.identity),
    defaulted$1('setReadOnly', $_2vokfcwwjfuw8tb4.noop),
    defaulted$1('readOnlyOnInit', $_2vokfcwwjfuw8tb4.constant(true))
  ]);

  var produce = function (raw) {
    var mobile = asRawOrDie('Getting AndroidWebapp schema', MobileSchema, raw);
    $_aag5ti106jfuw8tse.set(mobile.toolstrip, 'width', '100%');
    var onTap = function () {
      mobile.setReadOnly(true);
      mode.enter();
    };
    var mask = build$1($_d5dv5715ajfuw8uxg.sketch(onTap, mobile.translate));
    mobile.alloy.add(mask);
    var maskApi = {
      show: function () {
        mobile.alloy.add(mask);
      },
      hide: function () {
        mobile.alloy.remove(mask);
      }
    };
    $_cwa5ncxljfuw8tdv.append(mobile.container, mask.element());
    var mode = $_55cvbw14gjfuw8uro.create(mobile, maskApi);
    return {
      setReadOnly: mobile.setReadOnly,
      refreshStructure: $_2vokfcwwjfuw8tb4.noop,
      enter: mode.enter,
      exit: mode.exit,
      destroy: $_2vokfcwwjfuw8tb4.noop
    };
  };
  var $_6g5ji714fjfuw8urf = { produce: produce };

  var schema$14 = $_2vokfcwwjfuw8tb4.constant([
    defaulted$1('shell', true),
    field$1('toolbarBehaviours', [Replacing])
  ]);
  var enhanceGroups = function (detail) {
    return { behaviours: derive$2([Replacing.config({})]) };
  };
  var parts$2 = $_2vokfcwwjfuw8tb4.constant([optional({
      name: 'groups',
      overrides: enhanceGroups
    })]);
  var name$3 = $_2vokfcwwjfuw8tb4.constant('Toolbar');

  var factory$4 = function (detail, components$$1, spec, _externals) {
    var setGroups = function (toolbar, groups) {
      getGroupContainer(toolbar).fold(function () {
        console.error('Toolbar was defined to not be a shell, but no groups container was specified in components');
        throw new Error('Toolbar was defined to not be a shell, but no groups container was specified in components');
      }, function (container) {
        Replacing.set(container, groups);
      });
    };
    var getGroupContainer = function (component) {
      return detail.shell() ? Option.some(component) : getPart(component, detail, 'groups');
    };
    var extra = detail.shell() ? {
      behaviours: [Replacing.config({})],
      components: []
    } : {
      behaviours: [],
      components: components$$1
    };
    return {
      uid: detail.uid(),
      dom: detail.dom(),
      components: extra.components,
      behaviours: $_3jctjywxjfuw8tb6.deepMerge(derive$2(extra.behaviours), get$5(detail.toolbarBehaviours())),
      apis: { setGroups: setGroups },
      domModification: { attributes: { role: 'group' } }
    };
  };
  var Toolbar = composite$1({
    name: 'Toolbar',
    configFields: schema$14(),
    partFields: parts$2(),
    factory: factory$4,
    apis: {
      setGroups: function (apis, toolbar, groups) {
        apis.setGroups(toolbar, groups);
      }
    }
  });

  var schema$15 = $_2vokfcwwjfuw8tb4.constant([
    strict$1('items'),
    markers(['itemClass']),
    field$1('tgroupBehaviours', [Keying])
  ]);
  var parts$3 = $_2vokfcwwjfuw8tb4.constant([group({
      name: 'items',
      unit: 'item',
      overrides: function (detail) {
        return { domModification: { classes: [detail.markers().itemClass()] } };
      }
    })]);
  var name$4 = $_2vokfcwwjfuw8tb4.constant('ToolbarGroup');

  var factory$5 = function (detail, components, spec, _externals) {
    return $_3jctjywxjfuw8tb6.deepMerge({ dom: { attributes: { role: 'toolbar' } } }, {
      'uid': detail.uid(),
      'dom': detail.dom(),
      'components': components,
      'behaviours': $_3jctjywxjfuw8tb6.deepMerge(derive$2([Keying.config({
          mode: 'flow',
          selector: '.' + detail.markers().itemClass()
        })]), get$5(detail.tgroupBehaviours())),
      'debug.sketcher': spec['debug.sketcher']
    });
  };
  var ToolbarGroup = composite$1({
    name: 'ToolbarGroup',
    configFields: schema$15(),
    partFields: parts$3(),
    factory: factory$5
  });

  var dataHorizontal = 'data-' + $_2fp9skztjfuw8tqe.resolve('horizontal-scroll');
  var canScrollVertically = function (container) {
    container.dom().scrollTop = 1;
    var result = container.dom().scrollTop !== 0;
    container.dom().scrollTop = 0;
    return result;
  };
  var canScrollHorizontally = function (container) {
    container.dom().scrollLeft = 1;
    var result = container.dom().scrollLeft !== 0;
    container.dom().scrollLeft = 0;
    return result;
  };
  var hasVerticalScroll = function (container) {
    return container.dom().scrollTop > 0 || canScrollVertically(container);
  };
  var hasHorizontalScroll = function (container) {
    return container.dom().scrollLeft > 0 || canScrollHorizontally(container);
  };
  var markAsHorizontal = function (container) {
    $_47adx7ywjfuw8tl3.set(container, dataHorizontal, 'true');
  };
  var hasScroll = function (container) {
    return $_47adx7ywjfuw8tl3.get(container, dataHorizontal) === 'true' ? hasHorizontalScroll : hasVerticalScroll;
  };
  var exclusive = function (scope, selector) {
    return $_6cl0bk14cjfuw8uqx.bind(scope, 'touchmove', function (event) {
      $_c8lemt10bjfuw8tt8.closest(event.target(), selector).filter(hasScroll).fold(function () {
        event.raw().preventDefault();
      }, $_2vokfcwwjfuw8tb4.noop);
    });
  };
  var $_22oqbo15ijfuw8uzk = {
    exclusive: exclusive,
    markAsHorizontal: markAsHorizontal
  };

  function ScrollingToolbar () {
    var makeGroup = function (gSpec) {
      var scrollClass = gSpec.scrollable === true ? '${prefix}-toolbar-scrollable-group' : '';
      return {
        dom: dom$1('<div aria-label="' + gSpec.label + '" class="${prefix}-toolbar-group ' + scrollClass + '"></div>'),
        tgroupBehaviours: derive$2([config('adhoc-scrollable-toolbar', gSpec.scrollable === true ? [runOnInit(function (component, simulatedEvent) {
              $_aag5ti106jfuw8tse.set(component.element(), 'overflow-x', 'auto');
              $_22oqbo15ijfuw8uzk.markAsHorizontal(component.element());
              $_3pnsue149jfuw8uqb.register(component.element());
            })] : [])]),
        components: [Container.sketch({ components: [ToolbarGroup.parts().items({})] })],
        markers: { itemClass: $_2fp9skztjfuw8tqe.resolve('toolbar-group-item') },
        items: gSpec.items
      };
    };
    var toolbar = build$1(Toolbar.sketch({
      dom: dom$1('<div class="${prefix}-toolbar"></div>'),
      components: [Toolbar.parts().groups({})],
      toolbarBehaviours: derive$2([
        Toggling.config({
          toggleClass: $_2fp9skztjfuw8tqe.resolve('context-toolbar'),
          toggleOnExecute: false,
          aria: { mode: 'none' }
        }),
        Keying.config({ mode: 'cyclic' })
      ]),
      shell: true
    }));
    var wrapper = build$1(Container.sketch({
      dom: { classes: [$_2fp9skztjfuw8tqe.resolve('toolstrip')] },
      components: [premade$1(toolbar)],
      containerBehaviours: derive$2([Toggling.config({
          toggleClass: $_2fp9skztjfuw8tqe.resolve('android-selection-context-toolbar'),
          toggleOnExecute: false
        })])
    }));
    var resetGroups = function () {
      Toolbar.setGroups(toolbar, initGroups.get());
      Toggling.off(toolbar);
    };
    var initGroups = Cell([]);
    var setGroups = function (gs) {
      initGroups.set(gs);
      resetGroups();
    };
    var createGroups = function (gs) {
      return $_efmt4zxbjfuw8tcj.map(gs, $_2vokfcwwjfuw8tb4.compose(ToolbarGroup.sketch, makeGroup));
    };
    var refresh = function () {
    };
    var setContextToolbar = function (gs) {
      Toggling.on(toolbar);
      Toolbar.setGroups(toolbar, gs);
    };
    var restoreToolbar = function () {
      if (Toggling.isOn(toolbar)) {
        resetGroups();
      }
    };
    var focus = function () {
      Keying.focusIn(toolbar);
    };
    return {
      wrapper: $_2vokfcwwjfuw8tb4.constant(wrapper),
      toolbar: $_2vokfcwwjfuw8tb4.constant(toolbar),
      createGroups: createGroups,
      setGroups: setGroups,
      setContextToolbar: setContextToolbar,
      restoreToolbar: restoreToolbar,
      refresh: refresh,
      focus: focus
    };
  }

  var makeEditSwitch = function (webapp) {
    return build$1(Button.sketch({
      dom: dom$1('<div class="${prefix}-mask-edit-icon ${prefix}-icon"></div>'),
      action: function () {
        webapp.run(function (w) {
          w.setReadOnly(false);
        });
      }
    }));
  };
  var makeSocket = function () {
    return build$1(Container.sketch({
      dom: dom$1('<div class="${prefix}-editor-socket"></div>'),
      components: [],
      containerBehaviours: derive$2([Replacing.config({})])
    }));
  };
  var showEdit = function (socket, switchToEdit) {
    Replacing.append(socket, premade$1(switchToEdit));
  };
  var hideEdit = function (socket, switchToEdit) {
    Replacing.remove(socket, switchToEdit);
  };
  var updateMode = function (socket, switchToEdit, readOnly, root) {
    var swap = readOnly === true ? Swapping.toAlpha : Swapping.toOmega;
    swap(root);
    var f = readOnly ? showEdit : hideEdit;
    f(socket, switchToEdit);
  };
  var $_9pcl2n15jjfuw8uzs = {
    makeEditSwitch: makeEditSwitch,
    makeSocket: makeSocket,
    updateMode: updateMode
  };

  var getAnimationRoot = function (component, slideConfig) {
    return slideConfig.getAnimationRoot().fold(function () {
      return component.element();
    }, function (get) {
      return get(component);
    });
  };
  var getDimensionProperty = function (slideConfig) {
    return slideConfig.dimension().property();
  };
  var getDimension = function (slideConfig, elem) {
    return slideConfig.dimension().getDimension()(elem);
  };
  var disableTransitions = function (component, slideConfig) {
    var root = getAnimationRoot(component, slideConfig);
    $_c6ke2t13mjfuw8uku.remove(root, [
      slideConfig.shrinkingClass(),
      slideConfig.growingClass()
    ]);
  };
  var setShrunk = function (component, slideConfig) {
    $_6po7jxyujfuw8tl0.remove(component.element(), slideConfig.openClass());
    $_6po7jxyujfuw8tl0.add(component.element(), slideConfig.closedClass());
    $_aag5ti106jfuw8tse.set(component.element(), getDimensionProperty(slideConfig), '0px');
    $_aag5ti106jfuw8tse.reflow(component.element());
  };
  var measureTargetSize = function (component, slideConfig) {
    setGrown(component, slideConfig);
    var expanded = getDimension(slideConfig, component.element());
    setShrunk(component, slideConfig);
    return expanded;
  };
  var setGrown = function (component, slideConfig) {
    $_6po7jxyujfuw8tl0.remove(component.element(), slideConfig.closedClass());
    $_6po7jxyujfuw8tl0.add(component.element(), slideConfig.openClass());
    $_aag5ti106jfuw8tse.remove(component.element(), getDimensionProperty(slideConfig));
  };
  var doImmediateShrink = function (component, slideConfig, slideState) {
    slideState.setCollapsed();
    $_aag5ti106jfuw8tse.set(component.element(), getDimensionProperty(slideConfig), getDimension(slideConfig, component.element()));
    $_aag5ti106jfuw8tse.reflow(component.element());
    disableTransitions(component, slideConfig);
    setShrunk(component, slideConfig);
    slideConfig.onStartShrink()(component);
    slideConfig.onShrunk()(component);
  };
  var doStartShrink = function (component, slideConfig, slideState) {
    slideState.setCollapsed();
    $_aag5ti106jfuw8tse.set(component.element(), getDimensionProperty(slideConfig), getDimension(slideConfig, component.element()));
    $_aag5ti106jfuw8tse.reflow(component.element());
    var root = getAnimationRoot(component, slideConfig);
    $_6po7jxyujfuw8tl0.add(root, slideConfig.shrinkingClass());
    setShrunk(component, slideConfig);
    slideConfig.onStartShrink()(component);
  };
  var doStartGrow = function (component, slideConfig, slideState) {
    var fullSize = measureTargetSize(component, slideConfig);
    var root = getAnimationRoot(component, slideConfig);
    $_6po7jxyujfuw8tl0.add(root, slideConfig.growingClass());
    setGrown(component, slideConfig);
    $_aag5ti106jfuw8tse.set(component.element(), getDimensionProperty(slideConfig), fullSize);
    slideState.setExpanded();
    slideConfig.onStartGrow()(component);
  };
  var grow = function (component, slideConfig, slideState) {
    if (!slideState.isExpanded()) {
      doStartGrow(component, slideConfig, slideState);
    }
  };
  var shrink = function (component, slideConfig, slideState) {
    if (slideState.isExpanded()) {
      doStartShrink(component, slideConfig, slideState);
    }
  };
  var immediateShrink = function (component, slideConfig, slideState) {
    if (slideState.isExpanded()) {
      doImmediateShrink(component, slideConfig, slideState);
    }
  };
  var hasGrown = function (component, slideConfig, slideState) {
    return slideState.isExpanded();
  };
  var hasShrunk = function (component, slideConfig, slideState) {
    return slideState.isCollapsed();
  };
  var isGrowing = function (component, slideConfig, slideState) {
    var root = getAnimationRoot(component, slideConfig);
    return $_6po7jxyujfuw8tl0.has(root, slideConfig.growingClass()) === true;
  };
  var isShrinking = function (component, slideConfig, slideState) {
    var root = getAnimationRoot(component, slideConfig);
    return $_6po7jxyujfuw8tl0.has(root, slideConfig.shrinkingClass()) === true;
  };
  var isTransitioning = function (component, slideConfig, slideState) {
    return isGrowing(component, slideConfig, slideState) === true || isShrinking(component, slideConfig, slideState) === true;
  };
  var toggleGrow = function (component, slideConfig, slideState) {
    var f = slideState.isExpanded() ? doStartShrink : doStartGrow;
    f(component, slideConfig, slideState);
  };


  var SlidingApis = Object.freeze({
  	grow: grow,
  	shrink: shrink,
  	immediateShrink: immediateShrink,
  	hasGrown: hasGrown,
  	hasShrunk: hasShrunk,
  	isGrowing: isGrowing,
  	isShrinking: isShrinking,
  	isTransitioning: isTransitioning,
  	toggleGrow: toggleGrow,
  	disableTransitions: disableTransitions
  });

  var exhibit$5 = function (base, slideConfig) {
    var expanded = slideConfig.expanded();
    return expanded ? nu$6({
      classes: [slideConfig.openClass()],
      styles: {}
    }) : nu$6({
      classes: [slideConfig.closedClass()],
      styles: wrap$2(slideConfig.dimension().property(), '0px')
    });
  };
  var events$9 = function (slideConfig, slideState) {
    return derive([run(transitionend(), function (component, simulatedEvent) {
        var raw = simulatedEvent.event().raw();
        if (raw.propertyName === slideConfig.dimension().property()) {
          disableTransitions(component, slideConfig);
          if (slideState.isExpanded()) {
            $_aag5ti106jfuw8tse.remove(component.element(), slideConfig.dimension().property());
          }
          var notify = slideState.isExpanded() ? slideConfig.onGrown() : slideConfig.onShrunk();
          notify(component, simulatedEvent);
        }
      })]);
  };


  var ActiveSliding = Object.freeze({
  	exhibit: exhibit$5,
  	events: events$9
  });

  var SlidingSchema = [
    strict$1('closedClass'),
    strict$1('openClass'),
    strict$1('shrinkingClass'),
    strict$1('growingClass'),
    option('getAnimationRoot'),
    onHandler('onShrunk'),
    onHandler('onStartShrink'),
    onHandler('onGrown'),
    onHandler('onStartGrow'),
    defaulted$1('expanded', false),
    strictOf('dimension', choose$1('property', {
      width: [
        output$1('property', 'width'),
        output$1('getDimension', function (elem) {
          return $_dsj1h711zjfuw8u73.get(elem) + 'px';
        })
      ],
      height: [
        output$1('property', 'height'),
        output$1('getDimension', function (elem) {
          return $_sgteu105jfuw8tsc.get(elem) + 'px';
        })
      ]
    }))
  ];

  var init$4 = function (spec) {
    var state = Cell(spec.expanded());
    var readState = function () {
      return 'expanded: ' + state.get();
    };
    return BehaviourState({
      isExpanded: function () {
        return state.get() === true;
      },
      isCollapsed: function () {
        return state.get() === false;
      },
      setCollapsed: $_2vokfcwwjfuw8tb4.curry(state.set, false),
      setExpanded: $_2vokfcwwjfuw8tb4.curry(state.set, true),
      readState: readState
    });
  };


  var SlidingState = Object.freeze({
  	init: init$4
  });

  var Sliding = create$1({
    fields: SlidingSchema,
    name: 'sliding',
    active: ActiveSliding,
    apis: SlidingApis,
    state: SlidingState
  });

  var build$2 = function (refresh, scrollIntoView) {
    var dropup = build$1(Container.sketch({
      dom: {
        tag: 'div',
        classes: $_2fp9skztjfuw8tqe.resolve('dropup')
      },
      components: [],
      containerBehaviours: derive$2([
        Replacing.config({}),
        Sliding.config({
          closedClass: $_2fp9skztjfuw8tqe.resolve('dropup-closed'),
          openClass: $_2fp9skztjfuw8tqe.resolve('dropup-open'),
          shrinkingClass: $_2fp9skztjfuw8tqe.resolve('dropup-shrinking'),
          growingClass: $_2fp9skztjfuw8tqe.resolve('dropup-growing'),
          dimension: { property: 'height' },
          onShrunk: function (component) {
            refresh();
            scrollIntoView();
            Replacing.set(component, []);
          },
          onGrown: function (component) {
            refresh();
            scrollIntoView();
          }
        }),
        $_9de9iyzsjfuw8tqa.orientation(function (component, data) {
          disappear($_2vokfcwwjfuw8tb4.noop);
        })
      ])
    }));
    var appear = function (menu, update, component) {
      if (Sliding.hasShrunk(dropup) === true && Sliding.isTransitioning(dropup) === false) {
        window.requestAnimationFrame(function () {
          update(component);
          Replacing.set(dropup, [menu()]);
          Sliding.grow(dropup);
        });
      }
    };
    var disappear = function (onReadyToShrink) {
      window.requestAnimationFrame(function () {
        onReadyToShrink();
        Sliding.shrink(dropup);
      });
    };
    return {
      appear: appear,
      disappear: disappear,
      component: $_2vokfcwwjfuw8tb4.constant(dropup),
      element: dropup.element
    };
  };

  var isDangerous = function (event) {
    return event.raw().which === $_cy6bab10cjfuw8tt9.BACKSPACE()[0] && !$_efmt4zxbjfuw8tcj.contains([
      'input',
      'textarea'
    ], $_74lhjaxjjfuw8tdt.name(event.target()));
  };
  var isFirefox = $_5reqwox3jfuw8tbu.detect().browser.isFirefox();
  var settingsSchema = objOfOnly([
    strictFunction('triggerEvent'),
    strictFunction('broadcastEvent'),
    defaulted$1('stopBackspace', true)
  ]);
  var bindFocus = function (container, handler) {
    if (isFirefox) {
      return $_6cl0bk14cjfuw8uqx.capture(container, 'focus', handler);
    } else {
      return $_6cl0bk14cjfuw8uqx.bind(container, 'focusin', handler);
    }
  };
  var bindBlur = function (container, handler) {
    if (isFirefox) {
      return $_6cl0bk14cjfuw8uqx.capture(container, 'blur', handler);
    } else {
      return $_6cl0bk14cjfuw8uqx.bind(container, 'focusout', handler);
    }
  };
  var setup$2 = function (container, rawSettings) {
    var settings = asRawOrDie('Getting GUI events settings', settingsSchema, rawSettings);
    var pointerEvents = $_5reqwox3jfuw8tbu.detect().deviceType.isTouch() ? [
      'touchstart',
      'touchmove',
      'touchend',
      'gesturestart'
    ] : [
      'mousedown',
      'mouseup',
      'mouseover',
      'mousemove',
      'mouseout',
      'click'
    ];
    var tapEvent = monitor(settings);
    var simpleEvents = $_efmt4zxbjfuw8tcj.map(pointerEvents.concat([
      'selectstart',
      'input',
      'contextmenu',
      'change',
      'transitionend',
      'dragstart',
      'dragover',
      'drop'
    ]), function (type) {
      return $_6cl0bk14cjfuw8uqx.bind(container, type, function (event) {
        tapEvent.fireIfReady(event, type).each(function (tapStopped) {
          if (tapStopped) {
            event.kill();
          }
        });
        var stopped = settings.triggerEvent(type, event);
        if (stopped) {
          event.kill();
        }
      });
    });
    var onKeydown = $_6cl0bk14cjfuw8uqx.bind(container, 'keydown', function (event) {
      var stopped = settings.triggerEvent('keydown', event);
      if (stopped) {
        event.kill();
      } else if (settings.stopBackspace === true && isDangerous(event)) {
        event.prevent();
      }
    });
    var onFocusIn = bindFocus(container, function (event) {
      var stopped = settings.triggerEvent('focusin', event);
      if (stopped) {
        event.kill();
      }
    });
    var onFocusOut = bindBlur(container, function (event) {
      var stopped = settings.triggerEvent('focusout', event);
      if (stopped) {
        event.kill();
      }
      setTimeout(function () {
        settings.triggerEvent(postBlur(), event);
      }, 0);
    });
    var defaultView = $_aff64dxmjfuw8tdx.defaultView(container);
    var onWindowScroll = $_6cl0bk14cjfuw8uqx.bind(defaultView, 'scroll', function (event) {
      var stopped = settings.broadcastEvent(windowScroll(), event);
      if (stopped) {
        event.kill();
      }
    });
    var unbind = function () {
      $_efmt4zxbjfuw8tcj.each(simpleEvents, function (e) {
        e.unbind();
      });
      onKeydown.unbind();
      onFocusIn.unbind();
      onFocusOut.unbind();
      onWindowScroll.unbind();
    };
    return { unbind: unbind };
  };

  var derive$3 = function (rawEvent, rawTarget) {
    var source = readOptFrom$1(rawEvent, 'target').map(function (getTarget) {
      return getTarget();
    }).getOr(rawTarget);
    return Cell(source);
  };

  var fromSource = function (event, source) {
    var stopper = Cell(false);
    var cutter = Cell(false);
    var stop = function () {
      stopper.set(true);
    };
    var cut = function () {
      cutter.set(true);
    };
    return {
      stop: stop,
      cut: cut,
      isStopped: stopper.get,
      isCut: cutter.get,
      event: $_2vokfcwwjfuw8tb4.constant(event),
      setSource: source.set,
      getSource: source.get
    };
  };
  var fromExternal = function (event) {
    var stopper = Cell(false);
    var stop = function () {
      stopper.set(true);
    };
    return {
      stop: stop,
      cut: $_2vokfcwwjfuw8tb4.noop,
      isStopped: stopper.get,
      isCut: $_2vokfcwwjfuw8tb4.constant(false),
      event: $_2vokfcwwjfuw8tb4.constant(event),
      setTarget: $_2vokfcwwjfuw8tb4.die('Cannot set target of a broadcasted event'),
      getTarget: $_2vokfcwwjfuw8tb4.die('Cannot get target of a broadcasted event')
    };
  };

  var adt$6 = $_dldkf4y5jfuw8tgp.generate([
    { stopped: [] },
    { resume: ['element'] },
    { complete: [] }
  ]);
  var doTriggerHandler = function (lookup, eventType, rawEvent, target, source, logger) {
    var handler = lookup(eventType, target);
    var simulatedEvent = fromSource(rawEvent, source);
    return handler.fold(function () {
      logger.logEventNoHandlers(eventType, target);
      return adt$6.complete();
    }, function (handlerInfo) {
      var descHandler = handlerInfo.descHandler();
      var eventHandler = getHandler(descHandler);
      eventHandler(simulatedEvent);
      if (simulatedEvent.isStopped()) {
        logger.logEventStopped(eventType, handlerInfo.element(), descHandler.purpose());
        return adt$6.stopped();
      } else if (simulatedEvent.isCut()) {
        logger.logEventCut(eventType, handlerInfo.element(), descHandler.purpose());
        return adt$6.complete();
      } else {
        return $_aff64dxmjfuw8tdx.parent(handlerInfo.element()).fold(function () {
          logger.logNoParent(eventType, handlerInfo.element(), descHandler.purpose());
          return adt$6.complete();
        }, function (parent) {
          logger.logEventResponse(eventType, handlerInfo.element(), descHandler.purpose());
          return adt$6.resume(parent);
        });
      }
    });
  };
  var doTriggerOnUntilStopped = function (lookup, eventType, rawEvent, rawTarget, source, logger) {
    return doTriggerHandler(lookup, eventType, rawEvent, rawTarget, source, logger).fold(function () {
      return true;
    }, function (parent) {
      return doTriggerOnUntilStopped(lookup, eventType, rawEvent, parent, source, logger);
    }, function () {
      return false;
    });
  };
  var triggerHandler = function (lookup, eventType, rawEvent, target, logger) {
    var source = derive$3(rawEvent, target);
    return doTriggerHandler(lookup, eventType, rawEvent, target, source, logger);
  };
  var broadcast = function (listeners, rawEvent, logger) {
    var simulatedEvent = fromExternal(rawEvent);
    $_efmt4zxbjfuw8tcj.each(listeners, function (listener) {
      var descHandler = listener.descHandler();
      var handler = getHandler(descHandler);
      handler(simulatedEvent);
    });
    return simulatedEvent.isStopped();
  };
  var triggerUntilStopped = function (lookup, eventType, rawEvent, logger) {
    var rawTarget = rawEvent.target();
    return triggerOnUntilStopped(lookup, eventType, rawEvent, rawTarget, logger);
  };
  var triggerOnUntilStopped = function (lookup, eventType, rawEvent, rawTarget, logger) {
    var source = derive$3(rawEvent, rawTarget);
    return doTriggerOnUntilStopped(lookup, eventType, rawEvent, rawTarget, source, logger);
  };

  var closest$4 = function (target, transform, isRoot) {
    var delegate = $_d0h9pzz3jfuw8tlv.closest(target, function (elem) {
      return transform(elem).isSome();
    }, isRoot);
    return delegate.bind(transform);
  };

  var eventHandler = $_4xhupwxnjfuw8tea.immutable('element', 'descHandler');
  var messageHandler = function (id, handler) {
    return {
      id: $_2vokfcwwjfuw8tb4.constant(id),
      descHandler: $_2vokfcwwjfuw8tb4.constant(handler)
    };
  };
  function EventRegistry () {
    var registry = {};
    var registerId = function (extraArgs, id, events) {
      $_8qu224wzjfuw8tb9.each(events, function (v, k) {
        var handlers = registry[k] !== undefined ? registry[k] : {};
        handlers[id] = curryArgs(v, extraArgs);
        registry[k] = handlers;
      });
    };
    var findHandler = function (handlers, elem) {
      return read$2(elem).fold(function () {
        return Option.none();
      }, function (id) {
        var reader = readOpt$1(id);
        return handlers.bind(reader).map(function (descHandler) {
          return eventHandler(elem, descHandler);
        });
      });
    };
    var filterByType = function (type) {
      return readOptFrom$1(registry, type).map(function (handlers) {
        return $_8qu224wzjfuw8tb9.mapToArray(handlers, function (f, id) {
          return messageHandler(id, f);
        });
      }).getOr([]);
    };
    var find = function (isAboveRoot, type, target) {
      var readType = readOpt$1(type);
      var handlers = readType(registry);
      return closest$4(target, function (elem) {
        return findHandler(handlers, elem);
      }, isAboveRoot);
    };
    var unregisterId = function (id) {
      $_8qu224wzjfuw8tb9.each(registry, function (handlersById, eventName) {
        if (handlersById.hasOwnProperty(id)) {
          delete handlersById[id];
        }
      });
    };
    return {
      registerId: registerId,
      unregisterId: unregisterId,
      filterByType: filterByType,
      find: find
    };
  }

  function Registry () {
    var events = EventRegistry();
    var components = {};
    var readOrTag = function (component) {
      var elem = component.element();
      return read$2(elem).fold(function () {
        return write('uid-', component.element());
      }, function (uid) {
        return uid;
      });
    };
    var failOnDuplicate = function (component, tagId) {
      var conflict = components[tagId];
      if (conflict === component) {
        unregister(component);
      } else {
        throw new Error('The tagId "' + tagId + '" is already used by: ' + element(conflict.element()) + '\nCannot use it for: ' + element(component.element()) + '\n' + 'The conflicting element is' + ($_8634tqxhjfuw8tdl.inBody(conflict.element()) ? ' ' : ' not ') + 'already in the DOM');
      }
    };
    var register = function (component) {
      var tagId = readOrTag(component);
      if (hasKey$1(components, tagId)) {
        failOnDuplicate(component, tagId);
      }
      var extraArgs = [component];
      events.registerId(extraArgs, tagId, component.events());
      components[tagId] = component;
    };
    var unregister = function (component) {
      read$2(component.element()).each(function (tagId) {
        components[tagId] = undefined;
        events.unregisterId(tagId);
      });
    };
    var filter = function (type) {
      return events.filterByType(type);
    };
    var find = function (isAboveRoot, type, target) {
      return events.find(isAboveRoot, type, target);
    };
    var getById = function (id) {
      return readOpt$1(id)(components);
    };
    return {
      find: find,
      filter: filter,
      register: register,
      unregister: unregister,
      getById: getById
    };
  }

  var takeover = function (root) {
    var isAboveRoot = function (el) {
      return $_aff64dxmjfuw8tdx.parent(root.element()).fold(function () {
        return true;
      }, function (parent) {
        return $_4867a0xsjfuw8tej.eq(el, parent);
      });
    };
    var registry = Registry();
    var lookup = function (eventName, target) {
      return registry.find(isAboveRoot, eventName, target);
    };
    var domEvents = setup$2(root.element(), {
      triggerEvent: function (eventName, event) {
        return monitorEvent(eventName, event.target(), function (logger) {
          return triggerUntilStopped(lookup, eventName, event, logger);
        });
      },
      broadcastEvent: function (eventName, event) {
        var listeners = registry.filter(eventName);
        return broadcast(listeners, event);
      }
    });
    var systemApi = SystemApi({
      debugInfo: $_2vokfcwwjfuw8tb4.constant('real'),
      triggerEvent: function (eventName, target, data) {
        monitorEvent(eventName, target, function (logger) {
          triggerOnUntilStopped(lookup, eventName, data, target, logger);
        });
      },
      triggerFocus: function (target, originator) {
        read$2(target).fold(function () {
          $_f15fvwz1jfuw8tlo.focus(target);
        }, function (_alloyId) {
          monitorEvent(focus$1(), target, function (logger) {
            triggerHandler(lookup, focus$1(), {
              originator: $_2vokfcwwjfuw8tb4.constant(originator),
              target: $_2vokfcwwjfuw8tb4.constant(target)
            }, target, logger);
          });
        });
      },
      triggerEscape: function (comp, simulatedEvent) {
        systemApi.triggerEvent('keydown', comp.element(), simulatedEvent.event());
      },
      getByUid: function (uid) {
        return getByUid(uid);
      },
      getByDom: function (elem) {
        return getByDom(elem);
      },
      build: build$1,
      addToGui: function (c) {
        add(c);
      },
      removeFromGui: function (c) {
        remove(c);
      },
      addToWorld: function (c) {
        addToWorld(c);
      },
      removeFromWorld: function (c) {
        removeFromWorld(c);
      },
      broadcast: function (message) {
        broadcast$$1(message);
      },
      broadcastOn: function (channels, message) {
        broadcastOn(channels, message);
      }
    });
    var addToWorld = function (component) {
      component.connect(systemApi);
      if (!$_74lhjaxjjfuw8tdt.isText(component.element())) {
        registry.register(component);
        $_efmt4zxbjfuw8tcj.each(component.components(), addToWorld);
        systemApi.triggerEvent(systemInit(), component.element(), { target: $_2vokfcwwjfuw8tb4.constant(component.element()) });
      }
    };
    var removeFromWorld = function (component) {
      if (!$_74lhjaxjjfuw8tdt.isText(component.element())) {
        $_efmt4zxbjfuw8tcj.each(component.components(), removeFromWorld);
        registry.unregister(component);
      }
      component.disconnect();
    };
    var add = function (component) {
      attach(root, component);
    };
    var remove = function (component) {
      detach(component);
    };
    var destroy = function () {
      domEvents.unbind();
      $_138z6jxyjfuw8tf4.remove(root.element());
    };
    var broadcastData = function (data) {
      var receivers = registry.filter(receive());
      $_efmt4zxbjfuw8tcj.each(receivers, function (receiver) {
        var descHandler = receiver.descHandler();
        var handler = getHandler(descHandler);
        handler(data);
      });
    };
    var broadcast$$1 = function (message) {
      broadcastData({
        universal: $_2vokfcwwjfuw8tb4.constant(true),
        data: $_2vokfcwwjfuw8tb4.constant(message)
      });
    };
    var broadcastOn = function (channels, message) {
      broadcastData({
        universal: $_2vokfcwwjfuw8tb4.constant(false),
        channels: $_2vokfcwwjfuw8tb4.constant(channels),
        data: $_2vokfcwwjfuw8tb4.constant(message)
      });
    };
    var getByUid = function (uid) {
      return registry.getById(uid).fold(function () {
        return Result.error(new Error('Could not find component with uid: "' + uid + '" in system.'));
      }, Result.value);
    };
    var getByDom = function (elem) {
      var uid = read$2(elem).getOr('not found');
      return getByUid(uid);
    };
    addToWorld(root);
    return {
      root: $_2vokfcwwjfuw8tb4.constant(root),
      element: root.element,
      destroy: destroy,
      add: add,
      remove: remove,
      getByUid: getByUid,
      getByDom: getByDom,
      addToWorld: addToWorld,
      removeFromWorld: removeFromWorld,
      broadcast: broadcast$$1,
      broadcastOn: broadcastOn
    };
  };

  var READ_ONLY_MODE_CLASS = $_2vokfcwwjfuw8tb4.constant($_2fp9skztjfuw8tqe.resolve('readonly-mode'));
  var EDIT_MODE_CLASS = $_2vokfcwwjfuw8tb4.constant($_2fp9skztjfuw8tqe.resolve('edit-mode'));
  function OuterContainer (spec) {
    var root = build$1(Container.sketch({
      dom: { classes: [$_2fp9skztjfuw8tqe.resolve('outer-container')].concat(spec.classes) },
      containerBehaviours: derive$2([Swapping.config({
          alpha: READ_ONLY_MODE_CLASS(),
          omega: EDIT_MODE_CLASS()
        })])
    }));
    return takeover(root);
  }

  function AndroidRealm (scrollIntoView) {
    var alloy = OuterContainer({ classes: [$_2fp9skztjfuw8tqe.resolve('android-container')] });
    var toolbar = ScrollingToolbar();
    var webapp = $_bh7xqm133jfuw8uet.api();
    var switchToEdit = $_9pcl2n15jjfuw8uzs.makeEditSwitch(webapp);
    var socket = $_9pcl2n15jjfuw8uzs.makeSocket();
    var dropup = build$2($_2vokfcwwjfuw8tb4.noop, scrollIntoView);
    alloy.add(toolbar.wrapper());
    alloy.add(socket);
    alloy.add(dropup.component());
    var setToolbarGroups = function (rawGroups) {
      var groups = toolbar.createGroups(rawGroups);
      toolbar.setGroups(groups);
    };
    var setContextToolbar = function (rawGroups) {
      var groups = toolbar.createGroups(rawGroups);
      toolbar.setContextToolbar(groups);
    };
    var focusToolbar = function () {
      toolbar.focus();
    };
    var restoreToolbar = function () {
      toolbar.restoreToolbar();
    };
    var init = function (spec) {
      webapp.set($_6g5ji714fjfuw8urf.produce(spec));
    };
    var exit = function () {
      webapp.run(function (w) {
        w.exit();
        Replacing.remove(socket, switchToEdit);
      });
    };
    var updateMode = function (readOnly) {
      $_9pcl2n15jjfuw8uzs.updateMode(socket, switchToEdit, readOnly, alloy.root());
    };
    return {
      system: $_2vokfcwwjfuw8tb4.constant(alloy),
      element: alloy.element,
      init: init,
      exit: exit,
      setToolbarGroups: setToolbarGroups,
      setContextToolbar: setContextToolbar,
      focusToolbar: focusToolbar,
      restoreToolbar: restoreToolbar,
      updateMode: updateMode,
      socket: $_2vokfcwwjfuw8tb4.constant(socket),
      dropup: $_2vokfcwwjfuw8tb4.constant(dropup)
    };
  }

  var input$1 = function (parent, operation) {
    var input = $_bwdnu0xijfuw8tdo.fromTag('input');
    $_aag5ti106jfuw8tse.setAll(input, {
      opacity: '0',
      position: 'absolute',
      top: '-1000px',
      left: '-1000px'
    });
    $_cwa5ncxljfuw8tdv.append(parent, input);
    $_f15fvwz1jfuw8tlo.focus(input);
    operation(input);
    $_138z6jxyjfuw8tf4.remove(input);
  };
  var $_e8m84k163jfuw8v59 = { input: input$1 };

  var refreshInput = function (input) {
    var start = input.dom().selectionStart;
    var end = input.dom().selectionEnd;
    var dir = input.dom().selectionDirection;
    setTimeout(function () {
      input.dom().setSelectionRange(start, end, dir);
      $_f15fvwz1jfuw8tlo.focus(input);
    }, 50);
  };
  var refresh = function (winScope) {
    var sel = winScope.getSelection();
    if (sel.rangeCount > 0) {
      var br = sel.getRangeAt(0);
      var r = winScope.document.createRange();
      r.setStart(br.startContainer, br.startOffset);
      r.setEnd(br.endContainer, br.endOffset);
      sel.removeAllRanges();
      sel.addRange(r);
    }
  };
  var $_5098ol165jfuw8v5p = {
    refreshInput: refreshInput,
    refresh: refresh
  };

  var resume$1 = function (cWin, frame) {
    $_f15fvwz1jfuw8tlo.active().each(function (active) {
      if (!$_4867a0xsjfuw8tej.eq(active, frame)) {
        $_f15fvwz1jfuw8tlo.blur(active);
      }
    });
    cWin.focus();
    $_f15fvwz1jfuw8tlo.focus($_bwdnu0xijfuw8tdo.fromDom(cWin.document.body));
    $_5098ol165jfuw8v5p.refresh(cWin);
  };
  var $_7ddnf2164jfuw8v5j = { resume: resume$1 };

  var stubborn = function (outerBody, cWin, page, frame) {
    var toEditing = function () {
      $_7ddnf2164jfuw8v5j.resume(cWin, frame);
    };
    var toReading = function () {
      $_e8m84k163jfuw8v59.input(outerBody, $_f15fvwz1jfuw8tlo.blur);
    };
    var captureInput = $_6cl0bk14cjfuw8uqx.bind(page, 'keydown', function (evt) {
      if (!$_efmt4zxbjfuw8tcj.contains([
          'input',
          'textarea'
        ], $_74lhjaxjjfuw8tdt.name(evt.target()))) {
        toEditing();
      }
    });
    var onToolbarTouch = function () {
    };
    var destroy = function () {
      captureInput.unbind();
    };
    return {
      toReading: toReading,
      toEditing: toEditing,
      onToolbarTouch: onToolbarTouch,
      destroy: destroy
    };
  };
  var timid = function (outerBody, cWin, page, frame) {
    var dismissKeyboard = function () {
      $_f15fvwz1jfuw8tlo.blur(frame);
    };
    var onToolbarTouch = function () {
      dismissKeyboard();
    };
    var toReading = function () {
      dismissKeyboard();
    };
    var toEditing = function () {
      $_7ddnf2164jfuw8v5j.resume(cWin, frame);
    };
    return {
      toReading: toReading,
      toEditing: toEditing,
      onToolbarTouch: onToolbarTouch,
      destroy: $_2vokfcwwjfuw8tb4.noop
    };
  };
  var $_8wqcx8162jfuw8v4y = {
    stubborn: stubborn,
    timid: timid
  };

  var initEvents$1 = function (editorApi, iosApi, toolstrip, socket, dropup) {
    var saveSelectionFirst = function () {
      iosApi.run(function (api) {
        api.highlightSelection();
      });
    };
    var refreshIosSelection = function () {
      iosApi.run(function (api) {
        api.refreshSelection();
      });
    };
    var scrollToY = function (yTop, height) {
      var y = yTop - socket.dom().scrollTop;
      iosApi.run(function (api) {
        api.scrollIntoView(y, y + height);
      });
    };
    var scrollToElement = function (target) {
      scrollToY(iosApi, socket);
    };
    var scrollToCursor = function () {
      editorApi.getCursorBox().each(function (box) {
        scrollToY(box.top(), box.height());
      });
    };
    var clearSelection = function () {
      iosApi.run(function (api) {
        api.clearSelection();
      });
    };
    var clearAndRefresh = function () {
      clearSelection();
      refreshThrottle.throttle();
    };
    var refreshView = function () {
      scrollToCursor();
      iosApi.run(function (api) {
        api.syncHeight();
      });
    };
    var reposition = function () {
      var toolbarHeight = $_sgteu105jfuw8tsc.get(toolstrip);
      iosApi.run(function (api) {
        api.setViewportOffset(toolbarHeight);
      });
      refreshIosSelection();
      refreshView();
    };
    var toEditing = function () {
      iosApi.run(function (api) {
        api.toEditing();
      });
    };
    var toReading = function () {
      iosApi.run(function (api) {
        api.toReading();
      });
    };
    var onToolbarTouch = function (event) {
      iosApi.run(function (api) {
        api.onToolbarTouch(event);
      });
    };
    var tapping = $_bz8sbn14ijfuw8usd.monitor(editorApi);
    var refreshThrottle = $_6hl53v15bjfuw8uxr.last(refreshView, 300);
    var listeners = [
      editorApi.onKeyup(clearAndRefresh),
      editorApi.onNodeChanged(refreshIosSelection),
      editorApi.onDomChanged(refreshThrottle.throttle),
      editorApi.onDomChanged(refreshIosSelection),
      editorApi.onScrollToCursor(function (tinyEvent) {
        tinyEvent.preventDefault();
        refreshThrottle.throttle();
      }),
      editorApi.onScrollToElement(function (event) {
        scrollToElement(event.element());
      }),
      editorApi.onToEditing(toEditing),
      editorApi.onToReading(toReading),
      $_6cl0bk14cjfuw8uqx.bind(editorApi.doc(), 'touchend', function (touchEvent) {
        if ($_4867a0xsjfuw8tej.eq(editorApi.html(), touchEvent.target()) || $_4867a0xsjfuw8tej.eq(editorApi.body(), touchEvent.target())) {
        }
      }),
      $_6cl0bk14cjfuw8uqx.bind(toolstrip, 'transitionend', function (transitionEvent) {
        if (transitionEvent.raw().propertyName === 'height') {
          reposition();
        }
      }),
      $_6cl0bk14cjfuw8uqx.capture(toolstrip, 'touchstart', function (touchEvent) {
        saveSelectionFirst();
        onToolbarTouch(touchEvent);
        editorApi.onTouchToolstrip();
      }),
      $_6cl0bk14cjfuw8uqx.bind(editorApi.body(), 'touchstart', function (evt) {
        clearSelection();
        editorApi.onTouchContent();
        tapping.fireTouchstart(evt);
      }),
      tapping.onTouchmove(),
      tapping.onTouchend(),
      $_6cl0bk14cjfuw8uqx.bind(editorApi.body(), 'click', function (event) {
        event.kill();
      }),
      $_6cl0bk14cjfuw8uqx.bind(toolstrip, 'touchmove', function () {
        editorApi.onToolbarScrollStart();
      })
    ];
    var destroy = function () {
      $_efmt4zxbjfuw8tcj.each(listeners, function (l) {
        l.unbind();
      });
    };
    return { destroy: destroy };
  };
  var $_6p8ia7166jfuw8v5u = { initEvents: initEvents$1 };

  function FakeSelection (win, frame) {
    var doc = win.document;
    var container = $_bwdnu0xijfuw8tdo.fromTag('div');
    $_6po7jxyujfuw8tl0.add(container, $_2fp9skztjfuw8tqe.resolve('unfocused-selections'));
    $_cwa5ncxljfuw8tdv.append($_bwdnu0xijfuw8tdo.fromDom(doc.documentElement), container);
    var onTouch = $_6cl0bk14cjfuw8uqx.bind(container, 'touchstart', function (event) {
      event.prevent();
      $_7ddnf2164jfuw8v5j.resume(win, frame);
      clear();
    });
    var make = function (rectangle) {
      var span = $_bwdnu0xijfuw8tdo.fromTag('span');
      $_c6ke2t13mjfuw8uku.add(span, [
        $_2fp9skztjfuw8tqe.resolve('layer-editor'),
        $_2fp9skztjfuw8tqe.resolve('unfocused-selection')
      ]);
      $_aag5ti106jfuw8tse.setAll(span, {
        left: rectangle.left() + 'px',
        top: rectangle.top() + 'px',
        width: rectangle.width() + 'px',
        height: rectangle.height() + 'px'
      });
      return span;
    };
    var update = function () {
      clear();
      var rectangles = $_1h6vvx14njfuw8utc.getRectangles(win);
      var spans = $_efmt4zxbjfuw8tcj.map(rectangles, make);
      $_g8n2ewxzjfuw8tf7.append(container, spans);
    };
    var clear = function () {
      $_138z6jxyjfuw8tf4.empty(container);
    };
    var destroy = function () {
      onTouch.unbind();
      $_138z6jxyjfuw8tf4.remove(container);
    };
    var isActive = function () {
      return $_aff64dxmjfuw8tdx.children(container).length > 0;
    };
    return {
      update: update,
      isActive: isActive,
      destroy: destroy,
      clear: clear
    };
  }

  var nu$8 = function (baseFn) {
    var data = Option.none();
    var callbacks = [];
    var map = function (f) {
      return nu$8(function (nCallback) {
        get(function (data) {
          nCallback(f(data));
        });
      });
    };
    var get = function (nCallback) {
      if (isReady())
        call(nCallback);
      else
        callbacks.push(nCallback);
    };
    var set = function (x) {
      data = Option.some(x);
      run(callbacks);
      callbacks = [];
    };
    var isReady = function () {
      return data.isSome();
    };
    var run = function (cbs) {
      $_efmt4zxbjfuw8tcj.each(cbs, call);
    };
    var call = function (cb) {
      data.each(function (x) {
        setTimeout(function () {
          cb(x);
        }, 0);
      });
    };
    baseFn(set);
    return {
      get: get,
      map: map,
      isReady: isReady
    };
  };
  var pure$1 = function (a) {
    return nu$8(function (callback) {
      callback(a);
    });
  };
  var LazyValue = {
    nu: nu$8,
    pure: pure$1
  };

  var bounce = function (f) {
    return function () {
      var args = Array.prototype.slice.call(arguments);
      var me = this;
      setTimeout(function () {
        f.apply(me, args);
      }, 0);
    };
  };
  var $_6coh2216cjfuw8v7t = { bounce: bounce };

  var nu$9 = function (baseFn) {
    var get = function (callback) {
      baseFn($_6coh2216cjfuw8v7t.bounce(callback));
    };
    var map = function (fab) {
      return nu$9(function (callback) {
        get(function (a) {
          var value = fab(a);
          callback(value);
        });
      });
    };
    var bind = function (aFutureB) {
      return nu$9(function (callback) {
        get(function (a) {
          aFutureB(a).get(callback);
        });
      });
    };
    var anonBind = function (futureB) {
      return nu$9(function (callback) {
        get(function (a) {
          futureB.get(callback);
        });
      });
    };
    var toLazy = function () {
      return LazyValue.nu(get);
    };
    return {
      map: map,
      bind: bind,
      anonBind: anonBind,
      toLazy: toLazy,
      get: get
    };
  };
  var pure$2 = function (a) {
    return nu$9(function (callback) {
      callback(a);
    });
  };
  var Future = {
    nu: nu$9,
    pure: pure$2
  };

  var adjust = function (value, destination, amount) {
    if (Math.abs(value - destination) <= amount) {
      return Option.none();
    } else if (value < destination) {
      return Option.some(value + amount);
    } else {
      return Option.some(value - amount);
    }
  };
  var create$7 = function () {
    var interval = null;
    var animate = function (getCurrent, destination, amount, increment, doFinish, rate) {
      var finished = false;
      var finish = function (v) {
        finished = true;
        doFinish(v);
      };
      clearInterval(interval);
      var abort = function (v) {
        clearInterval(interval);
        finish(v);
      };
      interval = setInterval(function () {
        var value = getCurrent();
        adjust(value, destination, amount).fold(function () {
          clearInterval(interval);
          finish(destination);
        }, function (s) {
          increment(s, abort);
          if (!finished) {
            var newValue = getCurrent();
            if (newValue !== s || Math.abs(newValue - destination) > Math.abs(value - destination)) {
              clearInterval(interval);
              finish(destination);
            }
          }
        });
      }, rate);
    };
    return { animate: animate };
  };
  var $_4d6on916djfuw8v7v = {
    create: create$7,
    adjust: adjust
  };

  var findDevice = function (deviceWidth, deviceHeight) {
    var devices = [
      {
        width: 320,
        height: 480,
        keyboard: {
          portrait: 300,
          landscape: 240
        }
      },
      {
        width: 320,
        height: 568,
        keyboard: {
          portrait: 300,
          landscape: 240
        }
      },
      {
        width: 375,
        height: 667,
        keyboard: {
          portrait: 305,
          landscape: 240
        }
      },
      {
        width: 414,
        height: 736,
        keyboard: {
          portrait: 320,
          landscape: 240
        }
      },
      {
        width: 768,
        height: 1024,
        keyboard: {
          portrait: 320,
          landscape: 400
        }
      },
      {
        width: 1024,
        height: 1366,
        keyboard: {
          portrait: 380,
          landscape: 460
        }
      }
    ];
    return $_e8fwikzljfuw8tp3.findMap(devices, function (device) {
      return deviceWidth <= device.width && deviceHeight <= device.height ? Option.some(device.keyboard) : Option.none();
    }).getOr({
      portrait: deviceHeight / 5,
      landscape: deviceWidth / 4
    });
  };
  var $_fe8yws16gjfuw8v8s = { findDevice: findDevice };

  var softKeyboardLimits = function (outerWindow) {
    return $_fe8yws16gjfuw8v8s.findDevice(outerWindow.screen.width, outerWindow.screen.height);
  };
  var accountableKeyboardHeight = function (outerWindow) {
    var portrait = $_2v9f8x14bjfuw8uqn.get(outerWindow).isPortrait();
    var limits = softKeyboardLimits(outerWindow);
    var keyboard = portrait ? limits.portrait : limits.landscape;
    var visualScreenHeight = portrait ? outerWindow.screen.height : outerWindow.screen.width;
    return visualScreenHeight - outerWindow.innerHeight > keyboard ? 0 : keyboard;
  };
  var getGreenzone = function (socket, dropup) {
    var outerWindow = $_aff64dxmjfuw8tdx.owner(socket).dom().defaultView;
    var viewportHeight = $_sgteu105jfuw8tsc.get(socket) + $_sgteu105jfuw8tsc.get(dropup);
    var acc = accountableKeyboardHeight(outerWindow);
    return viewportHeight - acc;
  };
  var updatePadding = function (contentBody, socket, dropup) {
    var greenzoneHeight = getGreenzone(socket, dropup);
    var deltaHeight = $_sgteu105jfuw8tsc.get(socket) + $_sgteu105jfuw8tsc.get(dropup) - greenzoneHeight;
    $_aag5ti106jfuw8tse.set(contentBody, 'padding-bottom', deltaHeight + 'px');
  };
  var $_m18jz16fjfuw8v8l = {
    getGreenzone: getGreenzone,
    updatePadding: updatePadding
  };

  var fixture = $_dldkf4y5jfuw8tgp.generate([
    {
      fixed: [
        'element',
        'property',
        'offsetY'
      ]
    },
    {
      scroller: [
        'element',
        'offsetY'
      ]
    }
  ]);
  var yFixedData = 'data-' + $_2fp9skztjfuw8tqe.resolve('position-y-fixed');
  var yFixedProperty = 'data-' + $_2fp9skztjfuw8tqe.resolve('y-property');
  var yScrollingData = 'data-' + $_2fp9skztjfuw8tqe.resolve('scrolling');
  var windowSizeData = 'data-' + $_2fp9skztjfuw8tqe.resolve('last-window-height');
  var getYFixedData = function (element) {
    return $_f77yow14mjfuw8ut9.safeParse(element, yFixedData);
  };
  var getYFixedProperty = function (element) {
    return $_47adx7ywjfuw8tl3.get(element, yFixedProperty);
  };
  var getLastWindowSize = function (element) {
    return $_f77yow14mjfuw8ut9.safeParse(element, windowSizeData);
  };
  var classifyFixed = function (element, offsetY) {
    var prop = getYFixedProperty(element);
    return fixture.fixed(element, prop, offsetY);
  };
  var classifyScrolling = function (element, offsetY) {
    return fixture.scroller(element, offsetY);
  };
  var classify = function (element) {
    var offsetY = getYFixedData(element);
    var classifier = $_47adx7ywjfuw8tl3.get(element, yScrollingData) === 'true' ? classifyScrolling : classifyFixed;
    return classifier(element, offsetY);
  };
  var findFixtures = function (container) {
    var candidates = $_951f03109jfuw8tt3.descendants(container, '[' + yFixedData + ']');
    return $_efmt4zxbjfuw8tcj.map(candidates, classify);
  };
  var takeoverToolbar = function (toolbar) {
    var oldToolbarStyle = $_47adx7ywjfuw8tl3.get(toolbar, 'style');
    $_aag5ti106jfuw8tse.setAll(toolbar, {
      position: 'absolute',
      top: '0px'
    });
    $_47adx7ywjfuw8tl3.set(toolbar, yFixedData, '0px');
    $_47adx7ywjfuw8tl3.set(toolbar, yFixedProperty, 'top');
    var restore = function () {
      $_47adx7ywjfuw8tl3.set(toolbar, 'style', oldToolbarStyle || '');
      $_47adx7ywjfuw8tl3.remove(toolbar, yFixedData);
      $_47adx7ywjfuw8tl3.remove(toolbar, yFixedProperty);
    };
    return { restore: restore };
  };
  var takeoverViewport = function (toolbarHeight, height, viewport) {
    var oldViewportStyle = $_47adx7ywjfuw8tl3.get(viewport, 'style');
    $_3pnsue149jfuw8uqb.register(viewport);
    $_aag5ti106jfuw8tse.setAll(viewport, {
      position: 'absolute',
      height: height + 'px',
      width: '100%',
      top: toolbarHeight + 'px'
    });
    $_47adx7ywjfuw8tl3.set(viewport, yFixedData, toolbarHeight + 'px');
    $_47adx7ywjfuw8tl3.set(viewport, yScrollingData, 'true');
    $_47adx7ywjfuw8tl3.set(viewport, yFixedProperty, 'top');
    var restore = function () {
      $_3pnsue149jfuw8uqb.deregister(viewport);
      $_47adx7ywjfuw8tl3.set(viewport, 'style', oldViewportStyle || '');
      $_47adx7ywjfuw8tl3.remove(viewport, yFixedData);
      $_47adx7ywjfuw8tl3.remove(viewport, yScrollingData);
      $_47adx7ywjfuw8tl3.remove(viewport, yFixedProperty);
    };
    return { restore: restore };
  };
  var takeoverDropup = function (dropup, toolbarHeight, viewportHeight) {
    var oldDropupStyle = $_47adx7ywjfuw8tl3.get(dropup, 'style');
    $_aag5ti106jfuw8tse.setAll(dropup, {
      position: 'absolute',
      bottom: '0px'
    });
    $_47adx7ywjfuw8tl3.set(dropup, yFixedData, '0px');
    $_47adx7ywjfuw8tl3.set(dropup, yFixedProperty, 'bottom');
    var restore = function () {
      $_47adx7ywjfuw8tl3.set(dropup, 'style', oldDropupStyle || '');
      $_47adx7ywjfuw8tl3.remove(dropup, yFixedData);
      $_47adx7ywjfuw8tl3.remove(dropup, yFixedProperty);
    };
    return { restore: restore };
  };
  var deriveViewportHeight = function (viewport, toolbarHeight, dropupHeight) {
    var outerWindow = $_aff64dxmjfuw8tdx.owner(viewport).dom().defaultView;
    var winH = outerWindow.innerHeight;
    $_47adx7ywjfuw8tl3.set(viewport, windowSizeData, winH + 'px');
    return winH - toolbarHeight - dropupHeight;
  };
  var takeover$1 = function (viewport, contentBody, toolbar, dropup) {
    var outerWindow = $_aff64dxmjfuw8tdx.owner(viewport).dom().defaultView;
    var toolbarSetup = takeoverToolbar(toolbar);
    var toolbarHeight = $_sgteu105jfuw8tsc.get(toolbar);
    var dropupHeight = $_sgteu105jfuw8tsc.get(dropup);
    var viewportHeight = deriveViewportHeight(viewport, toolbarHeight, dropupHeight);
    var viewportSetup = takeoverViewport(toolbarHeight, viewportHeight, viewport);
    var dropupSetup = takeoverDropup(dropup, toolbarHeight, viewportHeight);
    var isActive = true;
    var restore = function () {
      isActive = false;
      toolbarSetup.restore();
      viewportSetup.restore();
      dropupSetup.restore();
    };
    var isExpanding = function () {
      var currentWinHeight = outerWindow.innerHeight;
      var lastWinHeight = getLastWindowSize(viewport);
      return currentWinHeight > lastWinHeight;
    };
    var refresh = function () {
      if (isActive) {
        var newToolbarHeight = $_sgteu105jfuw8tsc.get(toolbar);
        var dropupHeight_1 = $_sgteu105jfuw8tsc.get(dropup);
        var newHeight = deriveViewportHeight(viewport, newToolbarHeight, dropupHeight_1);
        $_47adx7ywjfuw8tl3.set(viewport, yFixedData, newToolbarHeight + 'px');
        $_aag5ti106jfuw8tse.set(viewport, 'height', newHeight + 'px');
        $_aag5ti106jfuw8tse.set(dropup, 'bottom', -(newToolbarHeight + newHeight + dropupHeight_1) + 'px');
        $_m18jz16fjfuw8v8l.updatePadding(contentBody, viewport, dropup);
      }
    };
    var setViewportOffset = function (newYOffset) {
      var offsetPx = newYOffset + 'px';
      $_47adx7ywjfuw8tl3.set(viewport, yFixedData, offsetPx);
      refresh();
    };
    $_m18jz16fjfuw8v8l.updatePadding(contentBody, viewport, dropup);
    return {
      setViewportOffset: setViewportOffset,
      isExpanding: isExpanding,
      isShrinking: $_2vokfcwwjfuw8tb4.not(isExpanding),
      refresh: refresh,
      restore: restore
    };
  };
  var $_a6i45416ejfuw8v83 = {
    findFixtures: findFixtures,
    takeover: takeover$1,
    getYFixedData: getYFixedData
  };

  var animator = $_4d6on916djfuw8v7v.create();
  var ANIMATION_STEP = 15;
  var NUM_TOP_ANIMATION_FRAMES = 10;
  var ANIMATION_RATE = 10;
  var lastScroll = 'data-' + $_2fp9skztjfuw8tqe.resolve('last-scroll-top');
  var getTop = function (element) {
    var raw = $_aag5ti106jfuw8tse.getRaw(element, 'top').getOr(0);
    return parseInt(raw, 10);
  };
  var getScrollTop = function (element) {
    return parseInt(element.dom().scrollTop, 10);
  };
  var moveScrollAndTop = function (element, destination, finalTop) {
    return Future.nu(function (callback) {
      var getCurrent = $_2vokfcwwjfuw8tb4.curry(getScrollTop, element);
      var update = function (newScroll) {
        element.dom().scrollTop = newScroll;
        $_aag5ti106jfuw8tse.set(element, 'top', getTop(element) + ANIMATION_STEP + 'px');
      };
      var finish = function () {
        element.dom().scrollTop = destination;
        $_aag5ti106jfuw8tse.set(element, 'top', finalTop + 'px');
        callback(destination);
      };
      animator.animate(getCurrent, destination, ANIMATION_STEP, update, finish, ANIMATION_RATE);
    });
  };
  var moveOnlyScroll = function (element, destination) {
    return Future.nu(function (callback) {
      var getCurrent = $_2vokfcwwjfuw8tb4.curry(getScrollTop, element);
      $_47adx7ywjfuw8tl3.set(element, lastScroll, getCurrent());
      var update = function (newScroll, abort) {
        var previous = $_f77yow14mjfuw8ut9.safeParse(element, lastScroll);
        if (previous !== element.dom().scrollTop) {
          abort(element.dom().scrollTop);
        } else {
          element.dom().scrollTop = newScroll;
          $_47adx7ywjfuw8tl3.set(element, lastScroll, newScroll);
        }
      };
      var finish = function () {
        element.dom().scrollTop = destination;
        $_47adx7ywjfuw8tl3.set(element, lastScroll, destination);
        callback(destination);
      };
      var distance = Math.abs(destination - getCurrent());
      var step = Math.ceil(distance / NUM_TOP_ANIMATION_FRAMES);
      animator.animate(getCurrent, destination, step, update, finish, ANIMATION_RATE);
    });
  };
  var moveOnlyTop = function (element, destination) {
    return Future.nu(function (callback) {
      var getCurrent = $_2vokfcwwjfuw8tb4.curry(getTop, element);
      var update = function (newTop) {
        $_aag5ti106jfuw8tse.set(element, 'top', newTop + 'px');
      };
      var finish = function () {
        update(destination);
        callback(destination);
      };
      var distance = Math.abs(destination - getCurrent());
      var step = Math.ceil(distance / NUM_TOP_ANIMATION_FRAMES);
      animator.animate(getCurrent, destination, step, update, finish, ANIMATION_RATE);
    });
  };
  var updateTop = function (element, amount) {
    var newTop = amount + $_a6i45416ejfuw8v83.getYFixedData(element) + 'px';
    $_aag5ti106jfuw8tse.set(element, 'top', newTop);
  };
  var moveWindowScroll = function (toolbar, viewport, destY) {
    var outerWindow = $_aff64dxmjfuw8tdx.owner(toolbar).dom().defaultView;
    return Future.nu(function (callback) {
      updateTop(toolbar, destY);
      updateTop(viewport, destY);
      outerWindow.scrollTo(0, destY);
      callback(destY);
    });
  };
  var $_ednzzl169jfuw8v7f = {
    moveScrollAndTop: moveScrollAndTop,
    moveOnlyScroll: moveOnlyScroll,
    moveOnlyTop: moveOnlyTop,
    moveWindowScroll: moveWindowScroll
  };

  function BackgroundActivity (doAction) {
    var action = Cell(LazyValue.pure({}));
    var start = function (value) {
      var future = LazyValue.nu(function (callback) {
        return doAction(value).get(callback);
      });
      action.set(future);
    };
    var idle = function (g) {
      action.get().get(function () {
        g();
      });
    };
    return {
      start: start,
      idle: idle
    };
  }

  var scrollIntoView = function (cWin, socket, dropup, top, bottom) {
    var greenzone = $_m18jz16fjfuw8v8l.getGreenzone(socket, dropup);
    var refreshCursor = $_2vokfcwwjfuw8tb4.curry($_5098ol165jfuw8v5p.refresh, cWin);
    if (top > greenzone || bottom > greenzone) {
      $_ednzzl169jfuw8v7f.moveOnlyScroll(socket, socket.dom().scrollTop - greenzone + bottom).get(refreshCursor);
    } else if (top < 0) {
      $_ednzzl169jfuw8v7f.moveOnlyScroll(socket, socket.dom().scrollTop + top).get(refreshCursor);
    } else {
    }
  };
  var $_76dc0f16ijfuw8v91 = { scrollIntoView: scrollIntoView };

  var par = function (asyncValues, nu) {
    return nu(function (callback) {
      var r = [];
      var count = 0;
      var cb = function (i) {
        return function (value) {
          r[i] = value;
          count++;
          if (count >= asyncValues.length) {
            callback(r);
          }
        };
      };
      if (asyncValues.length === 0) {
        callback([]);
      } else {
        $_efmt4zxbjfuw8tcj.each(asyncValues, function (asyncValue, i) {
          asyncValue.get(cb(i));
        });
      }
    });
  };
  var $_ggu2fw16ljfuw8v9g = { par: par };

  var par$1 = function (futures) {
    return $_ggu2fw16ljfuw8v9g.par(futures, Future.nu);
  };
  var mapM = function (array, fn) {
    var futures = $_efmt4zxbjfuw8tcj.map(array, fn);
    return par$1(futures);
  };
  var compose$1 = function (f, g) {
    return function (a) {
      return g(a).bind(f);
    };
  };
  var $_6sz6216kjfuw8v9e = {
    par: par$1,
    mapM: mapM,
    compose: compose$1
  };

  var updateFixed = function (element, property, winY, offsetY) {
    var destination = winY + offsetY;
    $_aag5ti106jfuw8tse.set(element, property, destination + 'px');
    return Future.pure(offsetY);
  };
  var updateScrollingFixed = function (element, winY, offsetY) {
    var destTop = winY + offsetY;
    var oldProp = $_aag5ti106jfuw8tse.getRaw(element, 'top').getOr(offsetY);
    var delta = destTop - parseInt(oldProp, 10);
    var destScroll = element.dom().scrollTop + delta;
    return $_ednzzl169jfuw8v7f.moveScrollAndTop(element, destScroll, destTop);
  };
  var updateFixture = function (fixture, winY) {
    return fixture.fold(function (element, property, offsetY) {
      return updateFixed(element, property, winY, offsetY);
    }, function (element, offsetY) {
      return updateScrollingFixed(element, winY, offsetY);
    });
  };
  var updatePositions = function (container, winY) {
    var fixtures = $_a6i45416ejfuw8v83.findFixtures(container);
    var updates = $_efmt4zxbjfuw8tcj.map(fixtures, function (fixture) {
      return updateFixture(fixture, winY);
    });
    return $_6sz6216kjfuw8v9e.par(updates);
  };
  var $_g2djjf16jjfuw8v95 = { updatePositions: updatePositions };

  var VIEW_MARGIN = 5;
  var register$2 = function (toolstrip, socket, container, outerWindow, structure, cWin) {
    var scroller = BackgroundActivity(function (y) {
      return $_ednzzl169jfuw8v7f.moveWindowScroll(toolstrip, socket, y);
    });
    var scrollBounds = function () {
      var rects = $_1h6vvx14njfuw8utc.getRectangles(cWin);
      return Option.from(rects[0]).bind(function (rect) {
        var viewTop = rect.top() - socket.dom().scrollTop;
        var outside = viewTop > outerWindow.innerHeight + VIEW_MARGIN || viewTop < -VIEW_MARGIN;
        return outside ? Option.some({
          top: $_2vokfcwwjfuw8tb4.constant(viewTop),
          bottom: $_2vokfcwwjfuw8tb4.constant(viewTop + rect.height())
        }) : Option.none();
      });
    };
    var scrollThrottle = $_6hl53v15bjfuw8uxr.last(function () {
      scroller.idle(function () {
        $_g2djjf16jjfuw8v95.updatePositions(container, outerWindow.pageYOffset).get(function () {
          var extraScroll = scrollBounds();
          extraScroll.each(function (extra) {
            socket.dom().scrollTop = socket.dom().scrollTop + extra.top();
          });
          scroller.start(0);
          structure.refresh();
        });
      });
    }, 1000);
    var onScroll = $_6cl0bk14cjfuw8uqx.bind($_bwdnu0xijfuw8tdo.fromDom(outerWindow), 'scroll', function () {
      if (outerWindow.pageYOffset < 0) {
        return;
      }
      scrollThrottle.throttle();
    });
    $_g2djjf16jjfuw8v95.updatePositions(container, outerWindow.pageYOffset).get($_2vokfcwwjfuw8tb4.identity);
    return { unbind: onScroll.unbind };
  };
  var setup$3 = function (bag) {
    var cWin = bag.cWin();
    var ceBody = bag.ceBody();
    var socket = bag.socket();
    var toolstrip = bag.toolstrip();
    var toolbar = bag.toolbar();
    var contentElement = bag.contentElement();
    var keyboardType = bag.keyboardType();
    var outerWindow = bag.outerWindow();
    var dropup = bag.dropup();
    var structure = $_a6i45416ejfuw8v83.takeover(socket, ceBody, toolstrip, dropup);
    var keyboardModel = keyboardType(bag.outerBody(), cWin, $_8634tqxhjfuw8tdl.body(), contentElement, toolstrip, toolbar);
    var toEditing = function () {
      keyboardModel.toEditing();
      clearSelection();
    };
    var toReading = function () {
      keyboardModel.toReading();
    };
    var onToolbarTouch = function (event) {
      keyboardModel.onToolbarTouch(event);
    };
    var onOrientation = $_2v9f8x14bjfuw8uqn.onChange(outerWindow, {
      onChange: $_2vokfcwwjfuw8tb4.noop,
      onReady: structure.refresh
    });
    onOrientation.onAdjustment(function () {
      structure.refresh();
    });
    var onResize = $_6cl0bk14cjfuw8uqx.bind($_bwdnu0xijfuw8tdo.fromDom(outerWindow), 'resize', function () {
      if (structure.isExpanding()) {
        structure.refresh();
      }
    });
    var onScroll = register$2(toolstrip, socket, bag.outerBody(), outerWindow, structure, cWin);
    var unfocusedSelection = FakeSelection(cWin, contentElement);
    var refreshSelection = function () {
      if (unfocusedSelection.isActive()) {
        unfocusedSelection.update();
      }
    };
    var highlightSelection = function () {
      unfocusedSelection.update();
    };
    var clearSelection = function () {
      unfocusedSelection.clear();
    };
    var scrollIntoView = function (top, bottom) {
      $_76dc0f16ijfuw8v91.scrollIntoView(cWin, socket, dropup, top, bottom);
    };
    var syncHeight = function () {
      $_aag5ti106jfuw8tse.set(contentElement, 'height', contentElement.dom().contentWindow.document.body.scrollHeight + 'px');
    };
    var setViewportOffset = function (newYOffset) {
      structure.setViewportOffset(newYOffset);
      $_ednzzl169jfuw8v7f.moveOnlyTop(socket, newYOffset).get($_2vokfcwwjfuw8tb4.identity);
    };
    var destroy = function () {
      structure.restore();
      onOrientation.destroy();
      onScroll.unbind();
      onResize.unbind();
      keyboardModel.destroy();
      unfocusedSelection.destroy();
      $_e8m84k163jfuw8v59.input($_8634tqxhjfuw8tdl.body(), $_f15fvwz1jfuw8tlo.blur);
    };
    return {
      toEditing: toEditing,
      toReading: toReading,
      onToolbarTouch: onToolbarTouch,
      refreshSelection: refreshSelection,
      clearSelection: clearSelection,
      highlightSelection: highlightSelection,
      scrollIntoView: scrollIntoView,
      updateToolbarPadding: $_2vokfcwwjfuw8tb4.noop,
      setViewportOffset: setViewportOffset,
      syncHeight: syncHeight,
      refreshStructure: structure.refresh,
      destroy: destroy
    };
  };
  var $_5bsj6g167jfuw8v6c = { setup: setup$3 };

  var create$8 = function (platform, mask) {
    var meta = $_41kbg3159jfuw8ux8.tag();
    var priorState = $_bh7xqm133jfuw8uet.value();
    var scrollEvents = $_bh7xqm133jfuw8uet.value();
    var iosApi = $_bh7xqm133jfuw8uet.api();
    var iosEvents = $_bh7xqm133jfuw8uet.api();
    var enter = function () {
      mask.hide();
      var doc = $_bwdnu0xijfuw8tdo.fromDom(document);
      $_9kqusv157jfuw8uwf.getActiveApi(platform.editor).each(function (editorApi) {
        priorState.set({
          socketHeight: $_aag5ti106jfuw8tse.getRaw(platform.socket, 'height'),
          iframeHeight: $_aag5ti106jfuw8tse.getRaw(editorApi.frame(), 'height'),
          outerScroll: document.body.scrollTop
        });
        scrollEvents.set({ exclusives: $_22oqbo15ijfuw8uzk.exclusive(doc, '.' + $_3pnsue149jfuw8uqb.scrollable()) });
        $_6po7jxyujfuw8tl0.add(platform.container, $_2fp9skztjfuw8tqe.resolve('fullscreen-maximized'));
        $_ggb1il158jfuw8uwy.clobberStyles(platform.container, editorApi.body());
        meta.maximize();
        $_aag5ti106jfuw8tse.set(platform.socket, 'overflow', 'scroll');
        $_aag5ti106jfuw8tse.set(platform.socket, '-webkit-overflow-scrolling', 'touch');
        $_f15fvwz1jfuw8tlo.focus(editorApi.body());
        var setupBag = $_4xhupwxnjfuw8tea.immutableBag([
          'cWin',
          'ceBody',
          'socket',
          'toolstrip',
          'toolbar',
          'dropup',
          'contentElement',
          'cursor',
          'keyboardType',
          'isScrolling',
          'outerWindow',
          'outerBody'
        ], []);
        iosApi.set($_5bsj6g167jfuw8v6c.setup(setupBag({
          cWin: editorApi.win(),
          ceBody: editorApi.body(),
          socket: platform.socket,
          toolstrip: platform.toolstrip,
          toolbar: platform.toolbar,
          dropup: platform.dropup.element(),
          contentElement: editorApi.frame(),
          cursor: $_2vokfcwwjfuw8tb4.noop,
          outerBody: platform.body,
          outerWindow: platform.win,
          keyboardType: $_8wqcx8162jfuw8v4y.stubborn,
          isScrolling: function () {
            return scrollEvents.get().exists(function (s) {
              return s.socket.isScrolling();
            });
          }
        })));
        iosApi.run(function (api) {
          api.syncHeight();
        });
        iosEvents.set($_6p8ia7166jfuw8v5u.initEvents(editorApi, iosApi, platform.toolstrip, platform.socket, platform.dropup));
      });
    };
    var exit = function () {
      meta.restore();
      iosEvents.clear();
      iosApi.clear();
      mask.show();
      priorState.on(function (s) {
        s.socketHeight.each(function (h) {
          $_aag5ti106jfuw8tse.set(platform.socket, 'height', h);
        });
        s.iframeHeight.each(function (h) {
          $_aag5ti106jfuw8tse.set(platform.editor.getFrame(), 'height', h);
        });
        document.body.scrollTop = s.scrollTop;
      });
      priorState.clear();
      scrollEvents.on(function (s) {
        s.exclusives.unbind();
      });
      scrollEvents.clear();
      $_6po7jxyujfuw8tl0.remove(platform.container, $_2fp9skztjfuw8tqe.resolve('fullscreen-maximized'));
      $_ggb1il158jfuw8uwy.restoreStyles();
      $_3pnsue149jfuw8uqb.deregister(platform.toolbar);
      $_aag5ti106jfuw8tse.remove(platform.socket, 'overflow');
      $_aag5ti106jfuw8tse.remove(platform.socket, '-webkit-overflow-scrolling');
      $_f15fvwz1jfuw8tlo.blur(platform.editor.getFrame());
      $_9kqusv157jfuw8uwf.getActiveApi(platform.editor).each(function (editorApi) {
        editorApi.clearSelection();
      });
    };
    var refreshStructure = function () {
      iosApi.run(function (api) {
        api.refreshStructure();
      });
    };
    return {
      enter: enter,
      refreshStructure: refreshStructure,
      exit: exit
    };
  };
  var $_31v0ry161jfuw8v4j = { create: create$8 };

  var produce$1 = function (raw) {
    var mobile = asRawOrDie('Getting IosWebapp schema', MobileSchema, raw);
    $_aag5ti106jfuw8tse.set(mobile.toolstrip, 'width', '100%');
    $_aag5ti106jfuw8tse.set(mobile.container, 'position', 'relative');
    var onView = function () {
      mobile.setReadOnly(mobile.readOnlyOnInit());
      mode.enter();
    };
    var mask = build$1($_d5dv5715ajfuw8uxg.sketch(onView, mobile.translate));
    mobile.alloy.add(mask);
    var maskApi = {
      show: function () {
        mobile.alloy.add(mask);
      },
      hide: function () {
        mobile.alloy.remove(mask);
      }
    };
    var mode = $_31v0ry161jfuw8v4j.create(mobile, maskApi);
    return {
      setReadOnly: mobile.setReadOnly,
      refreshStructure: mode.refreshStructure,
      enter: mode.enter,
      exit: mode.exit,
      destroy: $_2vokfcwwjfuw8tb4.noop
    };
  };
  var $_b1mcl2160jfuw8v4c = { produce: produce$1 };

  function IosRealm (scrollIntoView) {
    var alloy = OuterContainer({ classes: [$_2fp9skztjfuw8tqe.resolve('ios-container')] });
    var toolbar = ScrollingToolbar();
    var webapp = $_bh7xqm133jfuw8uet.api();
    var switchToEdit = $_9pcl2n15jjfuw8uzs.makeEditSwitch(webapp);
    var socket = $_9pcl2n15jjfuw8uzs.makeSocket();
    var dropup = build$2(function () {
      webapp.run(function (w) {
        w.refreshStructure();
      });
    }, scrollIntoView);
    alloy.add(toolbar.wrapper());
    alloy.add(socket);
    alloy.add(dropup.component());
    var setToolbarGroups = function (rawGroups) {
      var groups = toolbar.createGroups(rawGroups);
      toolbar.setGroups(groups);
    };
    var setContextToolbar = function (rawGroups) {
      var groups = toolbar.createGroups(rawGroups);
      toolbar.setContextToolbar(groups);
    };
    var focusToolbar = function () {
      toolbar.focus();
    };
    var restoreToolbar = function () {
      toolbar.restoreToolbar();
    };
    var init = function (spec) {
      webapp.set($_b1mcl2160jfuw8v4c.produce(spec));
    };
    var exit = function () {
      webapp.run(function (w) {
        Replacing.remove(socket, switchToEdit);
        w.exit();
      });
    };
    var updateMode = function (readOnly) {
      $_9pcl2n15jjfuw8uzs.updateMode(socket, switchToEdit, readOnly, alloy.root());
    };
    return {
      system: $_2vokfcwwjfuw8tb4.constant(alloy),
      element: alloy.element,
      init: init,
      exit: exit,
      setToolbarGroups: setToolbarGroups,
      setContextToolbar: setContextToolbar,
      focusToolbar: focusToolbar,
      restoreToolbar: restoreToolbar,
      updateMode: updateMode,
      socket: $_2vokfcwwjfuw8tb4.constant(socket),
      dropup: $_2vokfcwwjfuw8tb4.constant(dropup)
    };
  }

  var global$3 = tinymce.util.Tools.resolve('tinymce.EditorManager');

  var derive$4 = function (editor) {
    var base = readOptFrom$1(editor.settings, 'skin_url').fold(function () {
      return global$3.baseURL + '/skins/' + 'lightgray';
    }, function (url) {
      return url;
    });
    return {
      content: base + '/content.mobile.min.css',
      ui: base + '/skin.mobile.min.css'
    };
  };
  var $_9zui4e16mjfuw8v9l = { derive: derive$4 };

  var fontSizes = [
    'x-small',
    'small',
    'medium',
    'large',
    'x-large'
  ];
  var fireChange$1 = function (realm, command, state) {
    realm.system().broadcastOn([$_9e19stz9jfuw8tmf.formatChanged()], {
      command: command,
      state: state
    });
  };
  var init$5 = function (realm, editor) {
    var allFormats = $_8qu224wzjfuw8tb9.keys(editor.formatter.get());
    $_efmt4zxbjfuw8tcj.each(allFormats, function (command) {
      editor.formatter.formatChanged(command, function (state) {
        fireChange$1(realm, command, state);
      });
    });
    $_efmt4zxbjfuw8tcj.each([
      'ul',
      'ol'
    ], function (command) {
      editor.selection.selectorChanged(command, function (state, data) {
        fireChange$1(realm, command, state);
      });
    });
  };
  var $_4i8ew016ojfuw8v9o = {
    init: init$5,
    fontSizes: $_2vokfcwwjfuw8tb4.constant(fontSizes)
  };

  var fireSkinLoaded = function (editor) {
    var done = function () {
      editor._skinLoaded = true;
      editor.fire('SkinLoaded');
    };
    return function () {
      if (editor.initialized) {
        done();
      } else {
        editor.on('init', done);
      }
    };
  };
  var $_gchh4h16pjfuw8v9u = { fireSkinLoaded: fireSkinLoaded };

  var READING = $_2vokfcwwjfuw8tb4.constant('toReading');
  var EDITING = $_2vokfcwwjfuw8tb4.constant('toEditing');
  global$2.add('mobile', function (editor) {
    var renderUI = function (args) {
      var cssUrls = $_9zui4e16mjfuw8v9l.derive(editor);
      if (isSkinDisabled(editor) === false) {
        editor.contentCSS.push(cssUrls.content);
        global$1.DOM.styleSheetLoader.load(cssUrls.ui, $_gchh4h16pjfuw8v9u.fireSkinLoaded(editor));
      } else {
        $_gchh4h16pjfuw8v9u.fireSkinLoaded(editor)();
      }
      var doScrollIntoView = function () {
        editor.fire('scrollIntoView');
      };
      var wrapper = $_bwdnu0xijfuw8tdo.fromTag('div');
      var realm = $_5reqwox3jfuw8tbu.detect().os.isAndroid() ? AndroidRealm(doScrollIntoView) : IosRealm(doScrollIntoView);
      var original = $_bwdnu0xijfuw8tdo.fromDom(args.targetNode);
      $_cwa5ncxljfuw8tdv.after(original, wrapper);
      attachSystem(wrapper, realm.system());
      var findFocusIn = function (elem) {
        return $_f15fvwz1jfuw8tlo.search(elem).bind(function (focused) {
          return realm.system().getByDom(focused).toOption();
        });
      };
      var outerWindow = args.targetNode.ownerDocument.defaultView;
      var orientation = $_2v9f8x14bjfuw8uqn.onChange(outerWindow, {
        onChange: function () {
          var alloy = realm.system();
          alloy.broadcastOn([$_9e19stz9jfuw8tmf.orientationChanged()], { width: $_2v9f8x14bjfuw8uqn.getActualWidth(outerWindow) });
        },
        onReady: $_2vokfcwwjfuw8tb4.noop
      });
      var setReadOnly = function (dynamicGroup, readOnlyGroups, mainGroups, ro) {
        if (ro === false) {
          editor.selection.collapse();
        }
        var toolbars = configureToolbar(dynamicGroup, readOnlyGroups, mainGroups);
        realm.setToolbarGroups(ro === true ? toolbars.readOnly : toolbars.main);
        editor.setMode(ro === true ? 'readonly' : 'design');
        editor.fire(ro === true ? READING() : EDITING());
        realm.updateMode(ro);
      };
      var configureToolbar = function (dynamicGroup, readOnlyGroups, mainGroups) {
        var dynamic = dynamicGroup.get();
        var toolbars = {
          readOnly: dynamic.backToMask.concat(readOnlyGroups.get()),
          main: dynamic.backToMask.concat(mainGroups.get())
        };
        if (readOnlyOnInit(editor)) {
          toolbars.readOnly = dynamic.backToMask.concat(readOnlyGroups.get());
          toolbars.main = dynamic.backToReadOnly.concat(mainGroups.get());
        }
        return toolbars;
      };
      var bindHandler = function (label, handler) {
        editor.on(label, handler);
        return {
          unbind: function () {
            editor.off(label);
          }
        };
      };
      editor.on('init', function () {
        realm.init({
          editor: {
            getFrame: function () {
              return $_bwdnu0xijfuw8tdo.fromDom(editor.contentAreaContainer.querySelector('iframe'));
            },
            onDomChanged: function () {
              return { unbind: $_2vokfcwwjfuw8tb4.noop };
            },
            onToReading: function (handler) {
              return bindHandler(READING(), handler);
            },
            onToEditing: function (handler) {
              return bindHandler(EDITING(), handler);
            },
            onScrollToCursor: function (handler) {
              editor.on('scrollIntoView', function (tinyEvent) {
                handler(tinyEvent);
              });
              var unbind = function () {
                editor.off('scrollIntoView');
                orientation.destroy();
              };
              return { unbind: unbind };
            },
            onTouchToolstrip: function () {
              hideDropup();
            },
            onTouchContent: function () {
              var toolbar = $_bwdnu0xijfuw8tdo.fromDom(editor.editorContainer.querySelector('.' + $_2fp9skztjfuw8tqe.resolve('toolbar')));
              findFocusIn(toolbar).each(emitExecute);
              realm.restoreToolbar();
              hideDropup();
            },
            onTapContent: function (evt) {
              var target = evt.target();
              if ($_74lhjaxjjfuw8tdt.name(target) === 'img') {
                editor.selection.select(target.dom());
                evt.kill();
              } else if ($_74lhjaxjjfuw8tdt.name(target) === 'a') {
                var component = realm.system().getByDom($_bwdnu0xijfuw8tdo.fromDom(editor.editorContainer));
                component.each(function (container) {
                  if (Swapping.isAlpha(container)) {
                    $_5567t9z7jfuw8tmd.openLink(target.dom());
                  }
                });
              }
            }
          },
          container: $_bwdnu0xijfuw8tdo.fromDom(editor.editorContainer),
          socket: $_bwdnu0xijfuw8tdo.fromDom(editor.contentAreaContainer),
          toolstrip: $_bwdnu0xijfuw8tdo.fromDom(editor.editorContainer.querySelector('.' + $_2fp9skztjfuw8tqe.resolve('toolstrip'))),
          toolbar: $_bwdnu0xijfuw8tdo.fromDom(editor.editorContainer.querySelector('.' + $_2fp9skztjfuw8tqe.resolve('toolbar'))),
          dropup: realm.dropup(),
          alloy: realm.system(),
          translate: $_2vokfcwwjfuw8tb4.noop,
          setReadOnly: function (ro) {
            setReadOnly(dynamicGroup, readOnlyGroups, mainGroups, ro);
          },
          readOnlyOnInit: function () {
            return readOnlyOnInit(editor);
          }
        });
        var hideDropup = function () {
          realm.dropup().disappear(function () {
            realm.system().broadcastOn([$_9e19stz9jfuw8tmf.dropupDismissed()], {});
          });
        };
        var backToMaskGroup = {
          label: 'The first group',
          scrollable: false,
          items: [$_44weuozujfuw8tqh.forToolbar('back', function () {
              editor.selection.collapse();
              realm.exit();
            }, {})]
        };
        var backToReadOnlyGroup = {
          label: 'Back to read only',
          scrollable: false,
          items: [$_44weuozujfuw8tqh.forToolbar('readonly-back', function () {
              setReadOnly(dynamicGroup, readOnlyGroups, mainGroups, true);
            }, {})]
        };
        var readOnlyGroup = {
          label: 'The read only mode group',
          scrollable: true,
          items: []
        };
        var features = $_4419oszajfuw8tmi.setup(realm, editor);
        var items = $_4419oszajfuw8tmi.detect(editor.settings, features);
        var actionGroup = {
          label: 'the action group',
          scrollable: true,
          items: items
        };
        var extraGroup = {
          label: 'The extra group',
          scrollable: false,
          items: []
        };
        var mainGroups = Cell([
          actionGroup,
          extraGroup
        ]);
        var readOnlyGroups = Cell([
          readOnlyGroup,
          extraGroup
        ]);
        var dynamicGroup = Cell({
          backToMask: [backToMaskGroup],
          backToReadOnly: [backToReadOnlyGroup]
        });
        $_4i8ew016ojfuw8v9o.init(realm, editor);
      });
      return {
        iframeContainer: realm.socket().element().dom(),
        editorContainer: realm.element().dom()
      };
    };
    return {
      getNotificationManagerImpl: function () {
        return {
          open: $_2vokfcwwjfuw8tb4.identity,
          close: $_2vokfcwwjfuw8tb4.noop,
          reposition: $_2vokfcwwjfuw8tb4.noop,
          getArgs: $_2vokfcwwjfuw8tb4.identity
        };
      },
      renderUI: renderUI
    };
  });
  function Theme () {
  }

  return Theme;

}());
})();
