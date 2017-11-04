//CdnPath=http://ajax.aspnetcdn.com/ajax/4.5.1/1/MicrosoftAjaxGlobalization.js
//----------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------
// MicrosoftAjaxGlobalization.js
Type._registerScript("MicrosoftAjaxGlobalization.js", ["MicrosoftAjaxCore.js"]);
Date._appendPreOrPostMatch = function(e, b) {
    var d = 0, a = false;
    for (var c = 0, g = e.length; c < g; c++) {
        var f = e.charAt(c);
        switch (f) {
        case "'":
            if (a) b.append("'");
            else d++;
            a = false;
            break;
        case "\\":
            if (a) b.append("\\");
            a = !a;
            break;
        default:
            b.append(f);
            a = false
        }
    }
    return d
};
Date._expandFormat = function(a, b) {
    if (!b) b = "F";
    var c = b.length;
    if (c === 1)
        switch (b) {
        case "d":
            return a.ShortDatePattern;
        case "D":
            return a.LongDatePattern;
        case "t":
            return a.ShortTimePattern;
        case "T":
            return a.LongTimePattern;
        case "f":
            return a.LongDatePattern + " " + a.ShortTimePattern;
        case "F":
            return a.FullDateTimePattern;
        case "M":
        case "m":
            return a.MonthDayPattern;
        case "s":
            return a.SortableDateTimePattern;
        case "Y":
        case "y":
            return a.YearMonthPattern;
        default:
            throw Error.format(Sys.Res.formatInvalidString)
        }
    else if (c === 2 && b.charAt(0) === "%") b = b.charAt(1);
    return b
};
Date._expandYear = function(c, a) {
    var d = new Date, e = Date._getEra(d);
    if (a < 100) {
        var b = Date._getEraYear(d, c, e);
        a += b - b % 100;
        if (a > c.Calendar.TwoDigitYearMax) a -= 100
    }
    return a
};
Date._getEra = function(e, c) {
    if (!c) return 0;
    var b, d = e.getTime();
    for (var a = 0, f = c.length; a < f; a += 4) {
        b = c[a + 2];
        if (b === null || d >= b) return a
    }
    return 0
};
Date._getEraYear = function(d, b, e, c) {
    var a = d.getFullYear();
    if (!c && b.eras) a -= b.eras[e + 3];
    return a
};
Date._getParseRegExp = function(b, e) {
    if (!b._parseRegExp) b._parseRegExp = {};
    else if (b._parseRegExp[e]) return b._parseRegExp[e];
    var c = Date._expandFormat(b, e);
    c = c.replace(/([\^\$\.\*\+\?\|\[\]\(\)\{\}])/g, "\\\\$1");
    var a = new Sys.StringBuilder("^"), j = [], f = 0, i = 0, h = Date._getTokenRegExp(), d;
    while ((d = h.exec(c)) !== null) {
        var l = c.slice(f, d.index);
        f = h.lastIndex;
        i += Date._appendPreOrPostMatch(l, a);
        if (i % 2 === 1) {
            a.append(d[0]);
            continue
        }
        switch (d[0]) {
        case "dddd":
        case "ddd":
        case "MMMM":
        case "MMM":
        case "gg":
        case "g":
            a.append("(\\D+)");
            break;
        case "tt":
        case "t":
            a.append("(\\D*)");
            break;
        case "yyyy":
            a.append("(\\d{4})");
            break;
        case "fff":
            a.append("(\\d{3})");
            break;
        case "ff":
            a.append("(\\d{2})");
            break;
        case "f":
            a.append("(\\d)");
            break;
        case "dd":
        case "d":
        case "MM":
        case "M":
        case "yy":
        case "y":
        case "HH":
        case "H":
        case "hh":
        case "h":
        case "mm":
        case "m":
        case "ss":
        case "s":
            a.append("(\\d\\d?)");
            break;
        case "zzz":
            a.append("([+-]?\\d\\d?:\\d{2})");
            break;
        case "zz":
        case "z":
            a.append("([+-]?\\d\\d?)");
            break;
        case "/":
            a.append("(\\" + b.DateSeparator + ")")
        }
        Array.add(j, d[0])
    }
    Date._appendPreOrPostMatch(c.slice(f), a);
    a.append("$");
    var k = a.toString().replace(/\s+/g, "\\s+"), g = { "regExp": k, "groups": j };
    b._parseRegExp[e] = g;
    return g
};
Date._getTokenRegExp = function() {
    return /\/|dddd|ddd|dd|d|MMMM|MMM|MM|M|yyyy|yy|y|hh|h|HH|H|mm|m|ss|s|tt|t|fff|ff|f|zzz|zz|z|gg|g/g
};
Date.parseLocale = function(a) { return Date._parse(a, Sys.CultureInfo.CurrentCulture, arguments) };
Date.parseInvariant = function(a) { return Date._parse(a, Sys.CultureInfo.InvariantCulture, arguments) };
Date._parse = function(h, d, i) {
    var a, c, b, f, e, g = false;
    for (a = 1, c = i.length; a < c; a++) {
        f = i[a];
        if (f) {
            g = true;
            b = Date._parseExact(h, f, d);
            if (b) return b
        }
    }
    if (!g) {
        e = d._getDateTimeFormats();
        for (a = 0, c = e.length; a < c; a++) {
            b = Date._parseExact(h, e[a], d);
            if (b) return b
        }
    }
    return null
};
Date._parseExact = function(w, D, k) {
    w = w.trim();
    var g = k.dateTimeFormat, A = Date._getParseRegExp(g, D), C = (new RegExp(A.regExp)).exec(w);
    if (C === null) return null;
    var B = A.groups,
        x = null,
        e = null,
        c = null,
        j = null,
        i = null,
        d = 0,
        h,
        p = 0,
        q = 0,
        f = 0,
        l = null,
        v = false;
    for (var s = 0, E = B.length; s < E; s++) {
        var a = C[s + 1];
        if (a)
            switch (B[s]) {
            case "dd":
            case "d":
                j = parseInt(a, 10);
                if (j < 1 || j > 31) return null;
                break;
            case "MMMM":
                c = k._getMonthIndex(a);
                if (c < 0 || c > 11) return null;
                break;
            case "MMM":
                c = k._getAbbrMonthIndex(a);
                if (c < 0 || c > 11) return null;
                break;
            case "M":
            case "MM":
                c = parseInt(a, 10) - 1;
                if (c < 0 || c > 11) return null;
                break;
            case "y":
            case "yy":
                e = Date._expandYear(g, parseInt(a, 10));
                if (e < 0 || e > 9999) return null;
                break;
            case "yyyy":
                e = parseInt(a, 10);
                if (e < 0 || e > 9999) return null;
                break;
            case "h":
            case "hh":
                d = parseInt(a, 10);
                if (d === 12) d = 0;
                if (d < 0 || d > 11) return null;
                break;
            case "H":
            case "HH":
                d = parseInt(a, 10);
                if (d < 0 || d > 23) return null;
                break;
            case "m":
            case "mm":
                p = parseInt(a, 10);
                if (p < 0 || p > 59) return null;
                break;
            case "s":
            case "ss":
                q = parseInt(a, 10);
                if (q < 0 || q > 59) return null;
                break;
            case "tt":
            case "t":
                var z = a.toUpperCase();
                v = z === g.PMDesignator.toUpperCase();
                if (!v && z !== g.AMDesignator.toUpperCase()) return null;
                break;
            case "f":
                f = parseInt(a, 10) * 100;
                if (f < 0 || f > 999) return null;
                break;
            case "ff":
                f = parseInt(a, 10) * 10;
                if (f < 0 || f > 999) return null;
                break;
            case "fff":
                f = parseInt(a, 10);
                if (f < 0 || f > 999) return null;
                break;
            case "dddd":
                i = k._getDayIndex(a);
                if (i < 0 || i > 6) return null;
                break;
            case "ddd":
                i = k._getAbbrDayIndex(a);
                if (i < 0 || i > 6) return null;
                break;
            case "zzz":
                var u = a.split(/:/);
                if (u.length !== 2) return null;
                h = parseInt(u[0], 10);
                if (h < -12 || h > 13) return null;
                var m = parseInt(u[1], 10);
                if (m < 0 || m > 59) return null;
                l = h * 60 + (a.startsWith("-") ? -m : m);
                break;
            case "z":
            case "zz":
                h = parseInt(a, 10);
                if (h < -12 || h > 13) return null;
                l = h * 60;
                break;
            case "g":
            case "gg":
                var o = a;
                if (!o || !g.eras) return null;
                o = o.toLowerCase().trim();
                for (var r = 0, F = g.eras.length; r < F; r += 4)
                    if (o === g.eras[r + 1].toLowerCase()) {
                        x = r;
                        break
                    }
                if (x === null) return null
            }
    }
    var b = new Date, t, n = g.Calendar.convert;
    if (n) t = n.fromGregorian(b)[0];
    else t = b.getFullYear();
    if (e === null) e = t;
    else if (g.eras) e += g.eras[(x || 0) + 3];
    if (c === null) c = 0;
    if (j === null) j = 1;
    if (n) {
        b = n.toGregorian(e, c, j);
        if (b === null) return null
    } else {
        b.setFullYear(e, c, j);
        if (b.getDate() !== j) return null;
        if (i !== null && b.getDay() !== i) return null
    }
    if (v && d < 12) d += 12;
    b.setHours(d, p, q, f);
    if (l !== null) {
        var y = b.getMinutes() - (l + b.getTimezoneOffset());
        b.setHours(b.getHours() + parseInt(y / 60, 10), y % 60)
    }
    return b
};
Date.prototype.format = function(a) { return this._toFormattedString(a, Sys.CultureInfo.InvariantCulture) };
Date.prototype.localeFormat = function(a) { return this._toFormattedString(a, Sys.CultureInfo.CurrentCulture) };
Date.prototype._toFormattedString = function(e, j) {
    var b = j.dateTimeFormat, n = b.Calendar.convert;
    if (!e || !e.length || e === "i")
        if (j && j.name.length)
            if (n) return this._toFormattedString(b.FullDateTimePattern, j);
            else {
                var r = new Date(this.getTime()), x = Date._getEra(this, b.eras);
                r.setFullYear(Date._getEraYear(this, b, x));
                return r.toLocaleString()
            }
        else return this.toString();
    var l = b.eras, k = e === "s";
    e = Date._expandFormat(b, e);
    var a = new Sys.StringBuilder, c;

    function d(a) {
        if (a < 10) return "0" + a;
        return a.toString()
    }

    function m(a) {
        if (a < 10) return "00" + a;
        if (a < 100) return "0" + a;
        return a.toString()
    }

    function v(a) {
        if (a < 10) return "000" + a;
        else if (a < 100) return "00" + a;
        else if (a < 1000) return "0" + a;
        return a.toString()
    }

    var h, p, t = /([^d]|^)(d|dd)([^d]|$)/g;

    function s() {
        if (h || p) return h;
        h = t.test(e);
        p = true;
        return h
    }

    var q = 0, o = Date._getTokenRegExp(), f;
    if (!k && n) f = n.fromGregorian(this);
    for (; true;) {
        var w = o.lastIndex, i = o.exec(e), u = e.slice(w, i ? i.index : e.length);
        q += Date._appendPreOrPostMatch(u, a);
        if (!i) break;
        if (q % 2 === 1) {
            a.append(i[0]);
            continue
        }

        function g(a, b) {
            if (f) return f[b];
            switch (b) {
            case 0:
                return a.getFullYear();
            case 1:
                return a.getMonth();
            case 2:
                return a.getDate()
            }
        }

        switch (i[0]) {
        case "dddd":
            a.append(b.DayNames[this.getDay()]);
            break;
        case "ddd":
            a.append(b.AbbreviatedDayNames[this.getDay()]);
            break;
        case "dd":
            h = true;
            a.append(d(g(this, 2)));
            break;
        case "d":
            h = true;
            a.append(g(this, 2));
            break;
        case "MMMM":
            a.append(b.MonthGenitiveNames && s() ? b.MonthGenitiveNames[g(this, 1)] : b.MonthNames[g(this, 1)]);
            break;
        case "MMM":
            a.append(b.AbbreviatedMonthGenitiveNames && s()
                ? b.AbbreviatedMonthGenitiveNames[g(this, 1)]
                : b.AbbreviatedMonthNames[g(this, 1)]);
            break;
        case "MM":
            a.append(d(g(this, 1) + 1));
            break;
        case "M":
            a.append(g(this, 1) + 1);
            break;
        case "yyyy":
            a.append(v(f ? f[0] : Date._getEraYear(this, b, Date._getEra(this, l), k)));
            break;
        case "yy":
            a.append(d((f ? f[0] : Date._getEraYear(this, b, Date._getEra(this, l), k)) % 100));
            break;
        case "y":
            a.append((f ? f[0] : Date._getEraYear(this, b, Date._getEra(this, l), k)) % 100);
            break;
        case "hh":
            c = this.getHours() % 12;
            if (c === 0) c = 12;
            a.append(d(c));
            break;
        case "h":
            c = this.getHours() % 12;
            if (c === 0) c = 12;
            a.append(c);
            break;
        case "HH":
            a.append(d(this.getHours()));
            break;
        case "H":
            a.append(this.getHours());
            break;
        case "mm":
            a.append(d(this.getMinutes()));
            break;
        case "m":
            a.append(this.getMinutes());
            break;
        case "ss":
            a.append(d(this.getSeconds()));
            break;
        case "s":
            a.append(this.getSeconds());
            break;
        case "tt":
            a.append(this.getHours() < 12 ? b.AMDesignator : b.PMDesignator);
            break;
        case "t":
            a.append((this.getHours() < 12 ? b.AMDesignator : b.PMDesignator).charAt(0));
            break;
        case "f":
            a.append(m(this.getMilliseconds()).charAt(0));
            break;
        case "ff":
            a.append(m(this.getMilliseconds()).substr(0, 2));
            break;
        case "fff":
            a.append(m(this.getMilliseconds()));
            break;
        case "z":
            c = this.getTimezoneOffset() / 60;
            a.append((c <= 0 ? "+" : "-") + Math.floor(Math.abs(c)));
            break;
        case "zz":
            c = this.getTimezoneOffset() / 60;
            a.append((c <= 0 ? "+" : "-") + d(Math.floor(Math.abs(c))));
            break;
        case "zzz":
            c = this.getTimezoneOffset() / 60;
            a.append((c <= 0 ? "+" : "-") +
                d(Math.floor(Math.abs(c))) +
                ":" +
                d(Math.abs(this.getTimezoneOffset() % 60)));
            break;
        case "g":
        case "gg":
            if (b.eras) a.append(b.eras[Date._getEra(this, l) + 1]);
            break;
        case "/":
            a.append(b.DateSeparator)
        }
    }
    return a.toString()
};
String.localeFormat = function() { return String._toFormattedString(true, arguments) };
Number.parseLocale = function(a) { return Number._parse(a, Sys.CultureInfo.CurrentCulture) };
Number.parseInvariant = function(a) { return Number._parse(a, Sys.CultureInfo.InvariantCulture) };
Number._parse = function(b, o) {
    b = b.trim();
    if (b.match(/^[+-]?infinity$/i)) return parseFloat(b);
    if (b.match(/^0x[a-f0-9]+$/i)) return parseInt(b);
    var a = o.numberFormat, g = Number._parseNumberNegativePattern(b, a, a.NumberNegativePattern), h = g[0], e = g[1];
    if (h === "" && a.NumberNegativePattern !== 1) {
        g = Number._parseNumberNegativePattern(b, a, 1);
        h = g[0];
        e = g[1]
    }
    if (h === "") h = "+";
    var j, d, f = e.indexOf("e");
    if (f < 0) f = e.indexOf("E");
    if (f < 0) {
        d = e;
        j = null
    } else {
        d = e.substr(0, f);
        j = e.substr(f + 1)
    }
    var c, k, m = d.indexOf(a.NumberDecimalSeparator);
    if (m < 0) {
        c = d;
        k = null
    } else {
        c = d.substr(0, m);
        k = d.substr(m + a.NumberDecimalSeparator.length)
    }
    c = c.split(a.NumberGroupSeparator).join("");
    var n = a.NumberGroupSeparator.replace(/\u00A0/g, " ");
    if (a.NumberGroupSeparator !== n) c = c.split(n).join("");
    var l = h + c;
    if (k !== null) l += "." + k;
    if (j !== null) {
        var i = Number._parseNumberNegativePattern(j, a, 1);
        if (i[0] === "") i[0] = "+";
        l += "e" + i[0] + i[1]
    }
    if (l.match(/^[+-]?\d*\.?\d*(e[+-]?\d+)?$/)) return parseFloat(l);
    return Number.NaN
};
Number._parseNumberNegativePattern = function(a, d, e) {
    var b = d.NegativeSign, c = d.PositiveSign;
    switch (e) {
    case 4:
        b = " " + b;
        c = " " + c;
    case 3:
        if (a.endsWith(b)) return ["-", a.substr(0, a.length - b.length)];
        else if (a.endsWith(c)) return ["+", a.substr(0, a.length - c.length)];
        break;
    case 2:
        b += " ";
        c += " ";
    case 1:
        if (a.startsWith(b)) return ["-", a.substr(b.length)];
        else if (a.startsWith(c)) return ["+", a.substr(c.length)];
        break;
    case 0:
        if (a.startsWith("(") && a.endsWith(")")) return ["-", a.substr(1, a.length - 2)]
    }
    return ["", a]
};
Number.prototype.format = function(a) { return this._toFormattedString(a, Sys.CultureInfo.InvariantCulture) };
Number.prototype.localeFormat = function(a) { return this._toFormattedString(a, Sys.CultureInfo.CurrentCulture) };
Number.prototype._toFormattedString = function(e, j) {
    if (!e || e.length === 0 || e === "i")
        if (j && j.name.length > 0) return this.toLocaleString();
        else return this.toString();
    var o = ["n %", "n%", "%n"],
        n = ["-n %", "-n%", "-%n"],
        p = ["(n)", "-n", "- n", "n-", "n -"],
        m = ["$n", "n$", "$ n", "n $"],
        l = [
            "($n)", "-$n", "$-n", "$n-", "(n$)", "-n$", "n-$", "n$-", "-n $", "-$ n", "n $-", "$ n-", "$ -n", "n- $",
            "($ n)", "(n $)"
        ];

    function g(a, c, d) {
        for (var b = a.length; b < c; b++) a = d ? "0" + a : a + "0";
        return a
    }

    function i(j, i, l, n, p) {
        var h = l[0], k = 1, o = Math.pow(10, i), m = Math.round(j * o) / o;
        if (!isFinite(m)) m = j;
        j = m;
        var b = j.toString(), a = "", c, e = b.split(/e/i);
        b = e[0];
        c = e.length > 1 ? parseInt(e[1]) : 0;
        e = b.split(".");
        b = e[0];
        a = e.length > 1 ? e[1] : "";
        var q;
        if (c > 0) {
            a = g(a, c, false);
            b += a.slice(0, c);
            a = a.substr(c)
        } else if (c < 0) {
            c = -c;
            b = g(b, c + 1, true);
            a = b.slice(-c, b.length) + a;
            b = b.slice(0, -c)
        }
        if (i > 0) {
            if (a.length > i) a = a.slice(0, i);
            else a = g(a, i, false);
            a = p + a
        } else a = "";
        var d = b.length - 1, f = "";
        while (d >= 0) {
            if (h === 0 || h > d)
                if (f.length > 0) return b.slice(0, d + 1) + n + f + a;
                else return b.slice(0, d + 1) + a;
            if (f.length > 0) f = b.slice(d - h + 1, d + 1) + n + f;
            else f = b.slice(d - h + 1, d + 1);
            d -= h;
            if (k < l.length) {
                h = l[k];
                k++
            }
        }
        return b.slice(0, d + 1) + n + f + a
    }

    var a = j.numberFormat, d = Math.abs(this);
    if (!e) e = "D";
    var b = -1;
    if (e.length > 1) b = parseInt(e.slice(1), 10);
    var c;
    switch (e.charAt(0)) {
    case "d":
    case "D":
        c = "n";
        if (b !== -1) d = g("" + d, b, true);
        if (this < 0) d = -d;
        break;
    case "c":
    case "C":
        if (this < 0) c = l[a.CurrencyNegativePattern];
        else c = m[a.CurrencyPositivePattern];
        if (b === -1) b = a.CurrencyDecimalDigits;
        d = i(Math.abs(this), b, a.CurrencyGroupSizes, a.CurrencyGroupSeparator, a.CurrencyDecimalSeparator);
        break;
    case "n":
    case "N":
        if (this < 0) c = p[a.NumberNegativePattern];
        else c = "n";
        if (b === -1) b = a.NumberDecimalDigits;
        d = i(Math.abs(this), b, a.NumberGroupSizes, a.NumberGroupSeparator, a.NumberDecimalSeparator);
        break;
    case "p":
    case "P":
        if (this < 0) c = n[a.PercentNegativePattern];
        else c = o[a.PercentPositivePattern];
        if (b === -1) b = a.PercentDecimalDigits;
        d = i(Math.abs(this) * 100, b, a.PercentGroupSizes, a.PercentGroupSeparator, a.PercentDecimalSeparator);
        break;
    default:
        throw Error.format(Sys.Res.formatBadFormatSpecifier)
    }
    var k = /n|\$|-|%/g, f = "";
    for (; true;) {
        var q = k.lastIndex, h = k.exec(c);
        f += c.slice(q, h ? h.index : c.length);
        if (!h) break;
        switch (h[0]) {
        case "n":
            f += d;
            break;
        case "$":
            f += a.CurrencySymbol;
            break;
        case "-":
            if (/[1-9]/.test(d)) f += a.NegativeSign;
            break;
        case "%":
            f += a.PercentSymbol
        }
    }
    return f
};
Sys.CultureInfo = function(c, b, a) {
    this.name = c;
    this.numberFormat = b;
    this.dateTimeFormat = a
};
Sys.CultureInfo.prototype = {
    _getDateTimeFormats: function() {
        if (!this._dateTimeFormats) {
            var a = this.dateTimeFormat;
            this._dateTimeFormats = [
                a.MonthDayPattern, a.YearMonthPattern, a.ShortDatePattern, a.ShortTimePattern, a.LongDatePattern,
                a.LongTimePattern, a.FullDateTimePattern, a.RFC1123Pattern, a.SortableDateTimePattern,
                a.UniversalSortableDateTimePattern
            ]
        }
        return this._dateTimeFormats
    },
    _getIndex: function(c, d, e) {
        var b = this._toUpper(c), a = Array.indexOf(d, b);
        if (a === -1) a = Array.indexOf(e, b);
        return a
    },
    _getMonthIndex: function(a) {
        if (!this._upperMonths) {
            this._upperMonths = this._toUpperArray(this.dateTimeFormat.MonthNames);
            this._upperMonthsGenitive = this._toUpperArray(this.dateTimeFormat.MonthGenitiveNames)
        }
        return this._getIndex(a, this._upperMonths, this._upperMonthsGenitive)
    },
    _getAbbrMonthIndex: function(a) {
        if (!this._upperAbbrMonths) {
            this._upperAbbrMonths = this._toUpperArray(this.dateTimeFormat.AbbreviatedMonthNames);
            this._upperAbbrMonthsGenitive = this._toUpperArray(this.dateTimeFormat.AbbreviatedMonthGenitiveNames)
        }
        return this._getIndex(a, this._upperAbbrMonths, this._upperAbbrMonthsGenitive)
    },
    _getDayIndex: function(a) {
        if (!this._upperDays) this._upperDays = this._toUpperArray(this.dateTimeFormat.DayNames);
        return Array.indexOf(this._upperDays, this._toUpper(a))
    },
    _getAbbrDayIndex: function(a) {
        if (!this._upperAbbrDays) this._upperAbbrDays = this._toUpperArray(this.dateTimeFormat.AbbreviatedDayNames);
        return Array.indexOf(this._upperAbbrDays, this._toUpper(a))
    },
    _toUpperArray: function(c) {
        var b = [];
        for (var a = 0, d = c.length; a < d; a++) b[a] = this._toUpper(c[a]);
        return b
    },
    _toUpper: function(a) { return a.split("\u00a0").join(" ").toUpperCase() }
};
Sys.CultureInfo.registerClass("Sys.CultureInfo");
Sys.CultureInfo._parse = function(a) {
    var b = a.dateTimeFormat;
    if (b && !b.eras) b.eras = a.eras;
    return new Sys.CultureInfo(a.name, a.numberFormat, b)
};
Sys.CultureInfo.InvariantCulture = Sys.CultureInfo._parse({
    "name": "",
    "numberFormat":
    {
        "CurrencyDecimalDigits": 2,
        "CurrencyDecimalSeparator": ".",
        "IsReadOnly": true,
        "CurrencyGroupSizes": [3],
        "NumberGroupSizes": [3],
        "PercentGroupSizes": [3],
        "CurrencyGroupSeparator": ",",
        "CurrencySymbol": "\u00a4",
        "NaNSymbol": "NaN",
        "CurrencyNegativePattern": 0,
        "NumberNegativePattern": 1,
        "PercentPositivePattern": 0,
        "PercentNegativePattern": 0,
        "NegativeInfinitySymbol": "-Infinity",
        "NegativeSign": "-",
        "NumberDecimalDigits": 2,
        "NumberDecimalSeparator": ".",
        "NumberGroupSeparator": ",",
        "CurrencyPositivePattern": 0,
        "PositiveInfinitySymbol": "Infinity",
        "PositiveSign": "+",
        "PercentDecimalDigits": 2,
        "PercentDecimalSeparator": ".",
        "PercentGroupSeparator": ",",
        "PercentSymbol": "%",
        "PerMilleSymbol": "\u2030",
        "NativeDigits": ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"],
        "DigitSubstitution": 1
    },
    "dateTimeFormat": {
        "AMDesignator": "AM",
        "Calendar":
        {
            "MinSupportedDateTime": "@-62135568000000@",
            "MaxSupportedDateTime": "@253402300799999@",
            "AlgorithmType": 1,
            "CalendarType": 1,
            "Eras": [1],
            "TwoDigitYearMax": 2029,
            "IsReadOnly": true
        },
        "DateSeparator": "/",
        "FirstDayOfWeek": 0,
        "CalendarWeekRule": 0,
        "FullDateTimePattern": "dddd, dd MMMM yyyy HH:mm:ss",
        "LongDatePattern": "dddd, dd MMMM yyyy",
        "LongTimePattern": "HH:mm:ss",
        "MonthDayPattern": "MMMM dd",
        "PMDesignator": "PM",
        "RFC1123Pattern": "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",
        "ShortDatePattern": "MM/dd/yyyy",
        "ShortTimePattern": "HH:mm",
        "SortableDateTimePattern": "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
        "TimeSeparator": ":",
        "UniversalSortableDateTimePattern": "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
        "YearMonthPattern": "yyyy MMMM",
        "AbbreviatedDayNames": ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
        "ShortestDayNames": ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"],
        "DayNames": ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
        "AbbreviatedMonthNames":
            ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""],
        "MonthNames":
        [
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
            "November", "December", ""
        ],
        "IsReadOnly": true,
        "NativeCalendarName": "Gregorian Calendar",
        "AbbreviatedMonthGenitiveNames": [
            "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""
        ],
        "MonthGenitiveNames": [
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
            "November", "December", ""
        ]
    },
    "eras": [1, "A.D.", null, 0]
});
if (typeof __cultureInfo === "object") {
    Sys.CultureInfo.CurrentCulture = Sys.CultureInfo._parse(__cultureInfo);
    delete __cultureInfo
} else
    Sys.CultureInfo.CurrentCulture = Sys.CultureInfo._parse(
        {
            "name": "en-US",
            "numberFormat":
            {
                "CurrencyDecimalDigits": 2,
                "CurrencyDecimalSeparator": ".",
                "IsReadOnly": false,
                "CurrencyGroupSizes": [3],
                "NumberGroupSizes": [3],
                "PercentGroupSizes": [3],
                "CurrencyGroupSeparator": ",",
                "CurrencySymbol": "$",
                "NaNSymbol": "NaN",
                "CurrencyNegativePattern": 0,
                "NumberNegativePattern": 1,
                "PercentPositivePattern": 0,
                "PercentNegativePattern": 0,
                "NegativeInfinitySymbol": "-Infinity",
                "NegativeSign": "-",
                "NumberDecimalDigits": 2,
                "NumberDecimalSeparator": ".",
                "NumberGroupSeparator": ",",
                "CurrencyPositivePattern": 0,
                "PositiveInfinitySymbol": "Infinity",
                "PositiveSign": "+",
                "PercentDecimalDigits": 2,
                "PercentDecimalSeparator": ".",
                "PercentGroupSeparator": ",",
                "PercentSymbol": "%",
                "PerMilleSymbol": "\u2030",
                "NativeDigits": ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"],
                "DigitSubstitution": 1
            },
            "dateTimeFormat": {
                "AMDesignator": "AM",
                "Calendar":
                {
                    "MinSupportedDateTime": "@-62135568000000@",
                    "MaxSupportedDateTime": "@253402300799999@",
                    "AlgorithmType": 1,
                    "CalendarType": 1,
                    "Eras": [1],
                    "TwoDigitYearMax": 2029,
                    "IsReadOnly": false
                },
                "DateSeparator": "/",
                "FirstDayOfWeek": 0,
                "CalendarWeekRule": 0,
                "FullDateTimePattern": "dddd, MMMM dd, yyyy h:mm:ss tt",
                "LongDatePattern": "dddd, MMMM dd, yyyy",
                "LongTimePattern": "h:mm:ss tt",
                "MonthDayPattern": "MMMM dd",
                "PMDesignator": "PM",
                "RFC1123Pattern": "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",
                "ShortDatePattern": "M/d/yyyy",
                "ShortTimePattern": "h:mm tt",
                "SortableDateTimePattern": "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                "TimeSeparator": ":",
                "UniversalSortableDateTimePattern": "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                "YearMonthPattern": "MMMM, yyyy",
                "AbbreviatedDayNames": ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
                "ShortestDayNames": ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"],
                "DayNames": ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
                "AbbreviatedMonthNames":
                    ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""],
                "MonthNames":
                [
                    "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                    "November", "December", ""
                ],
                "IsReadOnly": false,
                "NativeCalendarName": "Gregorian Calendar",
                "AbbreviatedMonthGenitiveNames": [
                    "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", ""
                ],
                "MonthGenitiveNames": [
                    "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                    "November", "December", ""
                ]
            },
            "eras": [1, "A.D.", null, 0]
        });