(function () {
    function D() {
        var a, b = arguments,
            c, d = {},
            e = function (a, b) {
                var c, d;
                typeof a !== "object" && (a = {});
                for (d in b) b.hasOwnProperty(d) && (c = b[d], a[d] = c && typeof c === "object" && Object.prototype.toString.call(c) !== "[object Array]" && d !== "renderTo" && typeof c.nodeType !== "number" ? e(a[d] || {}, c) : b[d]);
                return a
            };
        b[0] === !0 && (d = b[1], b = Array.prototype.slice.call(b, 2));
        c = b.length;
        for (a = 0; a < c; a++) d = e(d, b[a]);
        return d
    }

    function G(a, b) {
        return parseInt(a, b || 10)
    }

    function Ba(a) {
        return typeof a === "string"
    }

    function da(a) {
        return a &&
            typeof a === "object"
    }

    function Ga(a) {
        return Object.prototype.toString.call(a) === "[object Array]"
    }

    function qa(a) {
        return typeof a === "number"
    }

    function Ca(a) {
        return V.log(a) / V.LN10
    }

    function ia(a) {
        return V.pow(10, a)
    }

    function ja(a, b) {
        for (var c = a.length; c--; )
            if (a[c] === b) {
                a.splice(c, 1);
                break
            }
    }

    function q(a) {
        return a !== x && a !== null
    }

    function K(a, b, c) {
        var d, e;
        if (Ba(b)) q(c) ? a.setAttribute(b, c) : a && a.getAttribute && (e = a.getAttribute(b));
        else if (q(b) && da(b))
            for (d in b) a.setAttribute(d, b[d]);
        return e
    }

    function ra(a) {
        return Ga(a) ?
            a : [a]
    }

    function M(a, b) {
        if (sa && !ca && b && b.opacity !== x) b.filter = "alpha(opacity=" + b.opacity * 100 + ")";
        t(a.style, b)
    }

    function $(a, b, c, d, e) {
        a = C.createElement(a);
        b && t(a, b);
        e && M(a, {
            padding: 0,
            border: P,
            margin: 0
        });
        c && M(a, c);
        d && d.appendChild(a);
        return a
    }

    function ka(a, b) {
        var c = function () {
            return x
        };
        c.prototype = new a;
        t(c.prototype, b);
        return c
    }

    function Ha(a, b) {
        return Array((b || 2) + 1 - String(a).length).join(0) + a
    }

    function Wa(a) {
        return (db && db(a) || nb || 0) * 6E4
    }

    function Ia(a, b) {
        for (var c = "{", d = !1, e, f, g, h, i, j = [];
            (c = a.indexOf(c)) !==
            -1; ) {
            e = a.slice(0, c);
            if (d) {
                f = e.split(":");
                g = f.shift().split(".");
                i = g.length;
                e = b;
                for (h = 0; h < i; h++) e = e[g[h]];
                if (f.length) f = f.join(":"), g = /\.([0-9])/, h = S.lang, i = void 0, /f$/.test(f) ? (i = (i = f.match(g)) ? i[1] : -1, e !== null && (e = B.numberFormat(e, i, h.decimalPoint, f.indexOf(",") > -1 ? h.thousandsSep : ""))) : e = Na(f, e)
            }
            j.push(e);
            a = a.slice(c + 1);
            c = (d = !d) ? "}" : "{"
        }
        j.push(a);
        return j.join("")
    }

    function ob(a) {
        return V.pow(10, T(V.log(a) / V.LN10))
    }

    function pb(a, b, c, d, e) {
        var f, g = a,
            c = p(c, 1);
        f = a / c;
        b || (b = [1, 2, 2.5, 5, 10], d === !1 && (c ===
            1 ? b = [1, 2, 5, 10] : c <= 0.1 && (b = [1 / c])));
        for (d = 0; d < b.length; d++)
            if (g = b[d], e && g * c >= a || !e && f <= (b[d] + (b[d + 1] || b[d])) / 2) break;
        g *= c;
        return g
    }

    function qb(a, b) {
        var c = a.length,
            d, e;
        for (e = 0; e < c; e++) a[e].ss_i = e;
        a.sort(function (a, c) {
            d = b(a, c);
            return d === 0 ? a.ss_i - c.ss_i : d
        });
        for (e = 0; e < c; e++) delete a[e].ss_i
    }

    function Oa(a) {
        for (var b = a.length, c = a[0]; b--; ) a[b] < c && (c = a[b]);
        return c
    }

    function Da(a) {
        for (var b = a.length, c = a[0]; b--; ) a[b] > c && (c = a[b]);
        return c
    }

    function Pa(a, b) {
        for (var c in a) a[c] && a[c] !== b && a[c].destroy && a[c].destroy(),
            delete a[c]
    }

    function Qa(a) {
        eb || (eb = $(Ja));
        a && eb.appendChild(a);
        eb.innerHTML = ""
    }

    function la(a, b) {
        var c = "Highcharts error #" + a + ":" + a;
        if (b) throw c;
        L.console && console.log(c)
    }

    function ea(a, b) {
        return parseFloat(a.toPrecision(b || 14))
    }

    function Ra(a, b) {
        b.renderer.globalAnimation = p(a, b.animation)
    }

    function Cb() {
        var a = S.global,
            b = a.useUTC,
            c = b ? "getUTC" : "get",
            d = b ? "setUTC" : "set";
        ya = a.Date || window.Date;
        nb = b && a.timezoneOffset;
        db = b && a.getTimezoneOffset;
        fb = function (a, c, d, h, i, j) {
            var k;
            b ? (k =
                ya.UTC.apply(0, arguments), k += Wa(k)) : k = (new ya(a, c, p(d, 1), p(h, 0), p(i, 0), p(j, 0))).getTime();
            return k
        };
        rb = c + "Minutes";
        sb = c + "Hours";
        tb = c + "Day";
        Xa = c + "Date";
        Ya = c + "Month";
        Za = c + "FullYear";
        Db = d + "Milliseconds";
        Eb = d + "Seconds";
        Fb = d + "Minutes";
        Gb = d + "Hours";
        ub = d + "Date";
        vb = d + "Month";
        wb = d + "FullYear"
    }

    function Q() { }

    function Sa(a, b, c, d) {
        this.axis = a;
        this.pos = b;
        this.type = c || "";
        this.isNew = !0;
        !c && !d && this.addLabel()
    }

    function Hb(a, b, c, d, e) {
        var f = a.chart.inverted;
        this.axis = a;
        this.isNegative = c;
        this.options = b;
        this.x = d;
        this.total =
            null;
        this.points = {};
        this.stack = e;
        this.alignOptions = {
            align: b.align || (f ? c ? "left" : "right" : "center"),
            verticalAlign: b.verticalAlign || (f ? "middle" : c ? "bottom" : "top"),
            y: p(b.y, f ? 4 : c ? 14 : -6),
            x: p(b.x, f ? c ? -6 : 6 : 0)
        };
        this.textAlign = b.textAlign || (f ? c ? "right" : "left" : "center")
    }
    var x, C = document,
        L = window,
        V = Math,
        w = V.round,
        T = V.floor,
        ta = V.ceil,
        s = V.max,
        z = V.min,
        O = V.abs,
        W = V.cos,
        aa = V.sin,
        ma = V.PI,
        ga = ma * 2 / 360,
        za = navigator.userAgent,
        Ib = L.opera,
        sa = /(msie|trident|edge)/i.test(za) && !Ib,
        gb = C.documentMode === 8,
        hb = !sa && /AppleWebKit/.test(za),
        Ka = /Firefox/.test(za),
        Jb = /(Mobile|Android|Windows Phone)/.test(za),
        Ea = "http://www.w3.org/2000/svg",
        ca = !!C.createElementNS && !!C.createElementNS(Ea, "svg").createSVGRect,
        Nb = Ka && parseInt(za.split("Firefox/")[1], 10) < 4,
        fa = !ca && !sa && !!C.createElement("canvas").getContext,
        $a, ab, Kb = {},
        xb = 0,
        eb, S, Na, yb, F, ua = function () {
            return x
        },
        X = [],
        bb = 0,
        Ja = "div",
        P = "none",
        Ob = /^[0-9]+$/,
        ib = ["plotTop", "marginRight", "marginBottom", "plotLeft"],
        Pb = "stroke-width",
        ya, fb, nb, db, rb, sb, tb, Xa, Ya, Za, Db, Eb, Fb, Gb, ub, vb, wb, N = {},
        B;
    B = L.Highcharts =
        L.Highcharts ? la(16, !0) : {};
    B.seriesTypes = N;
    var t = B.extend = function (a, b) {
        var c;
        a || (a = {});
        for (c in b) a[c] = b[c];
        return a
    },
        p = B.pick = function () {
            var a = arguments,
                b, c, d = a.length;
            for (b = 0; b < d; b++)
                if (c = a[b], c !== x && c !== null) return c
            },
        Ta = B.wrap = function (a, b, c) {
            var d = a[b];
            a[b] = function () {
                var a = Array.prototype.slice.call(arguments);
                a.unshift(d);
                return c.apply(this, a)
            }
        };
    Na = function (a, b, c) {
        if (!q(b) || isNaN(b)) return S.lang.invalidDate || "";
        var a = p(a, "%Y-%m-%d %H:%M:%S"),
            d = new ya(b - Wa(b)),
            e, f = d[sb](),
            g = d[tb](),
            h = d[Xa](),
            i = d[Ya](),
            j = d[Za](),
            k = S.lang,
            m = k.weekdays,
            d = t({
                a: m[g].substr(0, 3),
                A: m[g],
                d: Ha(h),
                e: h,
                w: g,
                b: k.shortMonths[i],
                B: k.months[i],
                m: Ha(i + 1),
                y: j.toString().substr(2, 2),
                Y: j,
                H: Ha(f),
                k: f,
                I: Ha(f % 12 || 12),
                l: f % 12 || 12,
                M: Ha(d[rb]()),
                p: f < 12 ? "AM" : "PM",
                P: f < 12 ? "am" : "pm",
                S: Ha(d.getSeconds()),
                L: Ha(w(b % 1E3), 3)
            }, B.dateFormats);
        for (e in d)
            for (; a.indexOf("%" + e) !== -1; ) a = a.replace("%" + e, typeof d[e] === "function" ? d[e](b) : d[e]);
        return c ? a.substr(0, 1).toUpperCase() + a.substr(1) : a
    };
    F = {
        millisecond: 1,
        second: 1E3,
        minute: 6E4,
        hour: 36E5,
        day: 864E5,
        week: 6048E5,
        month: 24192E5,
        year: 314496E5
    };
    B.numberFormat = function (a, b, c, d) {
        var e = S.lang,
            a = +a || 0,
            f = b === -1 ? z((a.toString().split(".")[1] || "").length, 20) : isNaN(b = O(b)) ? 2 : b,
            b = c === void 0 ? e.decimalPoint : c,
            d = d === void 0 ? e.thousandsSep : d,
            e = a < 0 ? "-" : "",
            c = String(G(a = O(a).toFixed(f))),
            g = c.length > 3 ? c.length % 3 : 0;
        return e + (g ? c.substr(0, g) + d : "") + c.substr(g).replace(/(\d{3})(?=\d)/g, "$1" + d) + (f ? b + O(a - c).toFixed(f).slice(2) : "")
    };
    yb = {
        init: function (a, b, c) {
            var b = b || "",
                d = a.shift,
                e = b.indexOf("C") > -1,
                f = e ? 7 : 3,
                g, b = b.split(" "),
                c = [].concat(c),
                h, i, j = function (a) {
                    for (g = a.length; g--; ) a[g] === "M" && a.splice(g + 1, 0, a[g + 1], a[g + 2], a[g + 1], a[g + 2])
                };
            e && (j(b), j(c));
            a.isArea && (h = b.splice(b.length - 6, 6), i = c.splice(c.length - 6, 6));
            if (d <= c.length / f && b.length === c.length)
                for (; d--; ) c = [].concat(c).splice(0, f).concat(c);
            a.shift = 0;
            if (b.length)
                for (a = c.length; b.length < a; ) d = [].concat(b).splice(b.length - f, f), e && (d[f - 6] = d[f - 2], d[f - 5] = d[f - 1]), b = b.concat(d);
            h && (b = b.concat(h), c = c.concat(i));
            return [b, c]
        },
        step: function (a, b, c, d) {
            var e = [],
                f = a.length;
            if (c === 1) e =
                d;
            else if (f === b.length && c < 1)
                for (; f--; ) d = parseFloat(a[f]), e[f] = isNaN(d) ? a[f] : c * parseFloat(b[f] - d) + d;
            else e = b;
            return e
        }
    };
    (function (a) {
        L.HighchartsAdapter = L.HighchartsAdapter || a && {
            init: function (b) {
                var c = a.fx;
                a.extend(a.easing, {
                    easeOutQuad: function (a, b, c, g, h) {
                        return -g * (b /= h) * (b - 2) + c
                    }
                });
                a.each(["cur", "_default", "width", "height", "opacity"], function (b, e) {
                    var f = c.step,
                        g;
                    e === "cur" ? f = c.prototype : e === "_default" && a.Tween && (f = a.Tween.propHooks[e], e = "set");
                    (g = f[e]) && (f[e] = function (a) {
                        var c, a = b ? a : this;
                        if (a.prop !==
                            "align") return c = a.elem, c.attr ? c.attr(a.prop, e === "cur" ? x : a.now) : g.apply(this, arguments)
                    })
                });
                Ta(a.cssHooks.opacity, "get", function (a, b, c) {
                    return b.attr ? b.opacity || 0 : a.call(this, b, c)
                });
                this.addAnimSetter("d", function (a) {
                    var c = a.elem,
                        f;
                    if (!a.started) f = b.init(c, c.d, c.toD), a.start = f[0], a.end = f[1], a.started = !0;
                    c.attr("d", b.step(a.start, a.end, a.pos, c.toD))
                });
                this.each = Array.prototype.forEach ? function (a, b) {
                    return Array.prototype.forEach.call(a, b)
                } : function (a, b) {
                    var c, g = a.length;
                    for (c = 0; c < g; c++)
                        if (b.call(a[c],
                                a[c], c, a) === !1) return c
                    };
                    a.fn.highcharts = function () {
                        var a = "Chart",
                        b = arguments,
                        c, g;
                        if (this[0]) {
                            Ba(b[0]) && (a = b[0], b = Array.prototype.slice.call(b, 1));
                            c = b[0];
                            if (c !== x) c.chart = c.chart || {}, c.chart.renderTo = this[0], new B[a](c, b[1]), g = this;
                            c === x && (g = X[K(this[0], "data-highcharts-chart")])
                        }
                        return g
                    }
                },
                addAnimSetter: function (b, c) {
                    a.Tween ? a.Tween.propHooks[b] = {
                        set: c
                    } : a.fx.step[b] = c
                },
                getScript: a.getScript,
                inArray: a.inArray,
                adapterRun: function (b, c) {
                    return a(b)[c]()
                },
                grep: a.grep,
                map: function (a, c) {
                    for (var d = [], e =
                        0, f = a.length; e < f; e++) d[e] = c.call(a[e], a[e], e, a);
                    return d
                },
                offset: function (b) {
                    return a(b).offset()
                },
                addEvent: function (b, c, d) {
                    a(b).bind(c, d)
                },
                removeEvent: function (b, c, d) {
                    var e = C.removeEventListener ? "removeEventListener" : "detachEvent";
                    C[e] && b && !b[e] && (b[e] = function () { });
                    a(b).unbind(c, d)
                },
                fireEvent: function (b, c, d, e) {
                    var f = a.Event(c),
                    g = "detached" + c,
                    h;
                    !sa && d && (delete d.layerX, delete d.layerY, delete d.returnValue);
                    t(f, d);
                    b[c] && (b[g] = b[c], b[c] = null);
                    a.each(["preventDefault", "stopPropagation"], function (a,
                    b) {
                        var c = f[b];
                        f[b] = function () {
                            try {
                                c.call(f)
                            } catch (a) {
                                b === "preventDefault" && (h = !0)
                            }
                        }
                    });
                    a(b).trigger(f);
                    b[g] && (b[c] = b[g], b[g] = null);
                    e && !f.isDefaultPrevented() && !h && e(f)
                },
                washMouseEvent: function (a) {
                    var c = a.originalEvent || a;
                    if (c.pageX === x) c.pageX = a.pageX, c.pageY = a.pageY;
                    return c
                },
                animate: function (b, c, d) {
                    var e = a(b);
                    if (!b.style) b.style = {};
                    if (c.d) b.toD = c.d, c.d = 1;
                    e.stop();
                    c.opacity !== x && b.attr && (c.opacity += "px");
                    b.hasAnim = 1;
                    e.animate(c, d)
                },
                stop: function (b) {
                    b.hasAnim && a(b).stop()
                }
            }
        })(L.jQuery);
        var U = L.HighchartsAdapter,
        E = U || {};
        U && U.init.call(U, yb);
        var jb = E.adapterRun,
        Qb = E.getScript,
        La = E.inArray,
        o = B.each = E.each,
        kb = E.grep,
        Rb = E.offset,
        Ua = E.map,
        I = E.addEvent,
        Y = E.removeEvent,
        J = E.fireEvent,
        Sb = E.washMouseEvent,
        lb = E.animate,
        cb = E.stop;
        S = {
            colors: "#7cb5ec,#434348,#90ed7d,#f7a35c,#8085e9,#f15c80,#e4d354,#2b908f,#f45b5b,#91e8e1".split(","),
            symbols: ["circle", "diamond", "square", "triangle", "triangle-down"],
            lang: {
                loading: "Loading...",
                months: "January,February,March,April,May,June,July,August,September,October,November,December".split(","),
                shortMonths: "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec".split(","),
                weekdays: "Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday".split(","),
                decimalPoint: ".",
                numericSymbols: "k,M,G,T,P,E".split(","),
                resetZoom: "Reset zoom",
                resetZoomTitle: "Reset zoom level 1:1",
                thousandsSep: " "
            },
            global: {
                useUTC: !0,
              //  canvasToolsURL: "http://code.highcharts.com/4.1.9/modules/canvas-tools.js",
                //VMLRadialGradientURL: "http://code.highcharts.com/4.1.9/gfx/vml-radial-gradient.png"
            },
            chart: {
                borderColor: "#4572A7",
                borderRadius: 0,
                defaultSeriesType: "line",
                ignoreHiddenSeries: !0,
                spacing: [10, 10, 15, 10],
                backgroundColor: "#FFFFFF",
                plotBorderColor: "#C0C0C0",
                resetZoomButton: {
                    theme: {
                        zIndex: 20
                    },
                    position: {
                        align: "right",
                        x: -10,
                        y: 10
                    }
                }
            },
            title: {
                text: "Chart title",
                align: "center",
                margin: 15,
                style: {
                    color: "#333333",
                    fontSize: "18px"
                }
            },
            subtitle: {
                text: "",
                align: "center",
                style: {
                    color: "#555555"
                }
            },
            plotOptions: {
                line: {
                    allowPointSelect: !1,
                    showCheckbox: !1,
                    animation: {
                        duration: 1E3
                    },
                    events: {},
                    lineWidth: 2,
                    marker: {
                        lineWidth: 0,
                        radius: 4,
                        lineColor: "#FFFFFF",
                        states: {
                            hover: {
                                enabled: !0,
                                lineWidthPlus: 1,
                                radiusPlus: 2
                            },
                            select: {
                                fillColor: "#FFFFFF",
                                lineColor: "#000000",
                                lineWidth: 2
                            }
                        }
                    },
                    point: {
                        events: {}
                    },
                    dataLabels: {
                        align: "center",
                        formatter: function () {
                            return this.y === null ? "" : B.numberFormat(this.y, -1)
                        },
                        style: {
                            color: "contrast",
                            fontSize: "11px",
                            fontWeight: "bold",
                            textShadow: "0 0 6px contrast, 0 0 3px contrast"
                        },
                        verticalAlign: "bottom",
                        x: 0,
                        y: 0,
                        padding: 5
                    },
                    cropThreshold: 300,
                    pointRange: 0,
                    softThreshold: !0,
                    states: {
                        hover: {
                            lineWidthPlus: 1,
                            marker: {},
                            halo: {
                                size: 10,
                                opacity: 0.25
                            }
                        },
                        select: {
                            marker: {}
                        }
                    },
                    stickyTracking: !0,
                    turboThreshold: 1E3
                }
            },
            labels: {
                style: {
                    position: "absolute",
                    color: "#3E576F"
                }
            },
            legend: {
                enabled: !0,
                align: "center",
                layout: "horizontal",
                labelFormatter: function () {
                    return this.name
                },
                borderColor: "#909090",
                borderRadius: 0,
                navigation: {
                    activeColor: "#274b6d",
                    inactiveColor: "#CCC"
                },
                shadow: !1,
                itemStyle: {
                    color: "#333333",
                    fontSize: "12px",
                    fontWeight: "bold"
                },
                itemHoverStyle: {
                    color: "#000"
                },
                itemHiddenStyle: {
                    color: "#CCC"
                },
                itemCheckboxStyle: {
                    position: "absolute",
                    width: "13px",
                    height: "13px"
                },
                symbolPadding: 5,
                verticalAlign: "bottom",
                x: 0,
                y: 0,
                title: {
                    style: {
                        fontWeight: "bold"
                    }
                }
            },
            loading: {
                labelStyle: {
                    fontWeight: "bold",
                    position: "relative",
                    top: "45%"
                },
                style: {
                    position: "absolute",
                    backgroundColor: "white",
                    opacity: 0.5,
                    textAlign: "center"
                }
            },
            tooltip: {
                enabled: !0,
                animation: ca,
                backgroundColor: "rgba(249, 249, 249, .85)",
                borderWidth: 1,
                borderRadius: 3,
                dateTimeLabelFormats: {
                    millisecond: "%A, %b %e, %H:%M:%S.%L",
                    second: "%A, %b %e, %H:%M:%S",
                    minute: "%A, %b %e, %H:%M",
                    hour: "%A, %b %e, %H:%M",
                    day: "%A, %b %e, %Y",
                    week: "Week from %A, %b %e, %Y",
                    month: "%B %Y",
                    year: "%Y"
                },
                footerFormat: "",
                headerFormat: '<span style="font-size: 10px">{point.key}</span><br/>',
                pointFormat: '<span style="color:{point.color}">\u25cf</span> {series.name}: <b>{point.y}</b><br/>',
                shadow: !0,
                snap: Jb ? 25 : 10,
                style: {
                    color: "#333333",
                    cursor: "default",
                    fontSize: "12px",
                    padding: "8px",
                    pointerEvents: "none",
                    whiteSpace: "nowrap"
                }
            },
            credits: {
                enabled: !0,
                text: "LearnEngg.com",
                href: "http://learnengg.com",
                position: {
                    align: "right",
                    x: -10,
                    verticalAlign: "bottom",
                    y: -5
                },
                style: {
                    cursor: "pointer",
                    color: "#909090",
                    fontSize: "9px"
                }
            }
        };
        var ba = S.plotOptions,
        U = ba.line;
        Cb();
        var Tb = /rgba\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]?(?:\.[0-9]+)?)\s*\)/,
        Ub = /#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/,
        Vb = /rgb\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*\)/,
        na = function (a) {
            var b = [],
                c, d;
            (function (a) {
                a && a.stops ? d = Ua(a.stops, function (a) {
                    return na(a[1])
                }) : (c = Tb.exec(a)) ? b = [G(c[1]), G(c[2]), G(c[3]), parseFloat(c[4], 10)] : (c = Ub.exec(a)) ? b = [G(c[1], 16), G(c[2], 16), G(c[3], 16), 1] : (c = Vb.exec(a)) &&
                    (b = [G(c[1]), G(c[2]), G(c[3]), 1])
            })(a);
            return {
                get: function (c) {
                    var f;
                    d ? (f = D(a), f.stops = [].concat(f.stops), o(d, function (a, b) {
                        f.stops[b] = [f.stops[b][0], a.get(c)]
                    })) : f = b && !isNaN(b[0]) ? c === "rgb" ? "rgb(" + b[0] + "," + b[1] + "," + b[2] + ")" : c === "a" ? b[3] : "rgba(" + b.join(",") + ")" : a;
                    return f
                },
                brighten: function (a) {
                    if (d) o(d, function (b) {
                        b.brighten(a)
                    });
                    else if (qa(a) && a !== 0) {
                        var c;
                        for (c = 0; c < 3; c++) b[c] += G(a * 255), b[c] < 0 && (b[c] = 0), b[c] > 255 && (b[c] = 255)
                    }
                    return this
                },
                rgba: b,
                setOpacity: function (a) {
                    b[3] = a;
                    return this
                },
                raw: a
            }
        };
        Q.prototype = {
            opacity: 1,
            textProps: "fontSize,fontWeight,fontFamily,fontStyle,color,lineHeight,width,textDecoration,textOverflow,textShadow".split(","),
            init: function (a, b) {
                this.element = b === "span" ? $(b) : C.createElementNS(Ea, b);
                this.renderer = a
            },
            animate: function (a, b, c) {
                b = p(b, this.renderer.globalAnimation, !0);
                cb(this);
                if (b) {
                    b = D(b, {});
                    if (c) b.complete = c;
                    lb(this, a, b)
                } else this.attr(a, null, c);
                return this
            },
            colorGradient: function (a, b, c) {
                var d = this.renderer,
                e, f, g, h, i, j, k, m, n, l, u, r = [];
                a.linearGradient ? f = "linearGradient" : a.radialGradient &&
                (f = "radialGradient");
                if (f) {
                    g = a[f];
                    i = d.gradients;
                    k = a.stops;
                    l = c.radialReference;
                    Ga(g) && (a[f] = g = {
                        x1: g[0],
                        y1: g[1],
                        x2: g[2],
                        y2: g[3],
                        gradientUnits: "userSpaceOnUse"
                    });
                    f === "radialGradient" && l && !q(g.gradientUnits) && (h = g, g = D(g, d.getRadialAttr(l, h), {
                        gradientUnits: "userSpaceOnUse"
                    }));
                    for (u in g) u !== "id" && r.push(u, g[u]);
                    for (u in k) r.push(k[u]);
                    r = r.join(",");
                    i[r] ? a = i[r].attr("id") : (g.id = a = "highcharts-" + xb++, i[r] = j = d.createElement(f).attr(g).add(d.defs), j.radAttr = h, j.stops = [], o(k, function (a) {
                        a[1].indexOf("rgba") ===
                        0 ? (e = na(a[1]), m = e.get("rgb"), n = e.get("a")) : (m = a[1], n = 1);
                        a = d.createElement("stop").attr({
                            offset: a[0],
                            "stop-color": m,
                            "stop-opacity": n
                        }).add(j);
                        j.stops.push(a)
                    }));
                    c.setAttribute(b, "url(" + d.url + "#" + a + ")");
                    c.gradient = r
                }
            },
            applyTextShadow: function (a) {
                var b = this.element,
                c, d = a.indexOf("contrast") !== -1,
                e = {},
                f = this.renderer.forExport,
                g = f || b.style.textShadow !== x && !sa;
                if (d) e.textShadow = a = a.replace(/contrast/g, this.renderer.getContrast(b.style.fill));
                if (hb || f) e.textRendering = "geometricPrecision";
                g ? this.css(e) :
                (this.fakeTS = !0, this.ySetter = this.xSetter, c = [].slice.call(b.getElementsByTagName("tspan")), o(a.split(/\s?,\s?/g), function (a) {
                    var d = b.firstChild,
                        e, f, a = a.split(" ");
                    e = a[a.length - 1];
                    (f = a[a.length - 2]) && o(c, function (a, c) {
                        var g;
                        c === 0 && (a.setAttribute("x", b.getAttribute("x")), c = b.getAttribute("y"), a.setAttribute("y", c || 0), c === null && b.setAttribute("y", 0));
                        g = a.cloneNode(1);
                        K(g, {
                            "class": "highcharts-text-shadow",
                            fill: e,
                            stroke: e,
                            "stroke-opacity": 1 / s(G(f), 3),
                            "stroke-width": f,
                            "stroke-linejoin": "round"
                        });
                        b.insertBefore(g,
                            d)
                    })
                }))
            },
            attr: function (a, b, c) {
                var d, e = this.element,
                f, g = this,
                h;
                typeof a === "string" && b !== x && (d = a, a = {}, a[d] = b);
                if (typeof a === "string") g = (this[a + "Getter"] || this._defaultGetter).call(this, a, e);
                else {
                    for (d in a) {
                        b = a[d];
                        h = !1;
                        this.symbolName && /^(x|y|width|height|r|start|end|innerR|anchorX|anchorY)/.test(d) && (f || (this.symbolAttr(a), f = !0), h = !0);
                        if (this.rotation && (d === "x" || d === "y")) this.doTransform = !0;
                        h || (this[d + "Setter"] || this._defaultSetter).call(this, b, d, e);
                        this.shadows && /^(width|height|visibility|x|y|d|transform|cx|cy|r)$/.test(d) &&
                        this.updateShadows(d, b)
                    }
                    if (this.doTransform) this.updateTransform(), this.doTransform = !1
                }
                c && c();
                return g
            },
            updateShadows: function (a, b) {
                for (var c = this.shadows, d = c.length; d--; ) c[d].setAttribute(a, a === "height" ? s(b - (c[d].cutHeight || 0), 0) : a === "d" ? this.d : b)
            },
            addClass: function (a) {
                var b = this.element,
                c = K(b, "class") || "";
                c.indexOf(a) === -1 && K(b, "class", c + " " + a);
                return this
            },
            symbolAttr: function (a) {
                var b = this;
                o("x,y,r,start,end,width,height,innerR,anchorX,anchorY".split(","), function (c) {
                    b[c] = p(a[c], b[c])
                });
                b.attr({
                    d: b.renderer.symbols[b.symbolName](b.x,
                    b.y, b.width, b.height, b)
                })
            },
            clip: function (a) {
                return this.attr("clip-path", a ? "url(" + this.renderer.url + "#" + a.id + ")" : P)
            },
            crisp: function (a) {
                var b, c = {},
                d, e = a.strokeWidth || this.strokeWidth || 0;
                d = w(e) % 2 / 2;
                a.x = T(a.x || this.x || 0) + d;
                a.y = T(a.y || this.y || 0) + d;
                a.width = T((a.width || this.width || 0) - 2 * d);
                a.height = T((a.height || this.height || 0) - 2 * d);
                a.strokeWidth = e;
                for (b in a) this[b] !== a[b] && (this[b] = c[b] = a[b]);
                return c
            },
            css: function (a) {
                var b = this.styles,
                c = {},
                d = this.element,
                e, f, g = "";
                e = !b;
                if (a && a.color) a.fill = a.color;
                if (b)
                    for (f in a) a[f] !==
                    b[f] && (c[f] = a[f], e = !0);
                if (e) {
                    e = this.textWidth = a && a.width && d.nodeName.toLowerCase() === "text" && G(a.width) || this.textWidth;
                    b && (a = t(b, c));
                    this.styles = a;
                    e && (fa || !ca && this.renderer.forExport) && delete a.width;
                    if (sa && !ca) M(this.element, a);
                    else {
                        b = function (a, b) {
                            return "-" + b.toLowerCase()
                        };
                        for (f in a) g += f.replace(/([A-Z])/g, b) + ":" + a[f] + ";";
                        K(d, "style", g)
                    }
                    e && this.added && this.renderer.buildText(this)
                }
                return this
            },
            on: function (a, b) {
                var c = this,
                d = c.element;
                ab && a === "click" ? (d.ontouchstart = function (a) {
                    c.touchEventFired =
                    ya.now();
                    a.preventDefault();
                    b.call(d, a)
                }, d.onclick = function (a) {
                    (za.indexOf("Android") === -1 || ya.now() - (c.touchEventFired || 0) > 1100) && b.call(d, a)
                }) : d["on" + a] = b;
                return this
            },
            setRadialReference: function (a) {
                var b = this.renderer.gradients[this.element.gradient];
                this.element.radialReference = a;
                b && b.radAttr && b.animate(this.renderer.getRadialAttr(a, b.radAttr));
                return this
            },
            translate: function (a, b) {
                return this.attr({
                    translateX: a,
                    translateY: b
                })
            },
            invert: function () {
                this.inverted = !0;
                this.updateTransform();
                return this
            },
            updateTransform: function () {
                var a = this.translateX || 0,
                b = this.translateY || 0,
                c = this.scaleX,
                d = this.scaleY,
                e = this.inverted,
                f = this.rotation,
                g = this.element;
                e && (a += this.attr("width"), b += this.attr("height"));
                a = ["translate(" + a + "," + b + ")"];
                e ? a.push("rotate(90) scale(-1,1)") : f && a.push("rotate(" + f + " " + (g.getAttribute("x") || 0) + " " + (g.getAttribute("y") || 0) + ")");
                (q(c) || q(d)) && a.push("scale(" + p(c, 1) + " " + p(d, 1) + ")");
                a.length && g.setAttribute("transform", a.join(" "))
            },
            toFront: function () {
                var a = this.element;
                a.parentNode.appendChild(a);
                return this
            },
            align: function (a, b, c) {
                var d, e, f, g, h = {};
                e = this.renderer;
                f = e.alignedObjects;
                if (a) {
                    if (this.alignOptions = a, this.alignByTranslate = b, !c || Ba(c)) this.alignTo = d = c || "renderer", ja(f, this), f.push(this), c = null
                } else a = this.alignOptions, b = this.alignByTranslate, d = this.alignTo;
                c = p(c, e[d], e);
                d = a.align;
                e = a.verticalAlign;
                f = (c.x || 0) + (a.x || 0);
                g = (c.y || 0) + (a.y || 0);
                if (d === "right" || d === "center") f += (c.width - (a.width || 0)) / {
                    right: 1,
                    center: 2
                }[d];
                h[b ? "translateX" : "x"] = w(f);
                if (e === "bottom" || e === "middle") g += (c.height -
                (a.height || 0)) / ({
                    bottom: 1,
                    middle: 2
                }[e] || 1);
                h[b ? "translateY" : "y"] = w(g);
                this[this.placed ? "animate" : "attr"](h);
                this.placed = !0;
                this.alignAttr = h;
                return this
            },
            getBBox: function (a) {
                var b, c = this.renderer,
                d, e = this.rotation,
                f = this.element,
                g = this.styles,
                h = e * ga;
                d = this.textStr;
                var i, j = f.style,
                k, m;
                d !== x && (m = ["", e || 0, g && g.fontSize, f.style.width].join(","), m = d === "" || Ob.test(d) ? "num:" + d.toString().length + m : d + m);
                m && !a && (b = c.cache[m]);
                if (!b) {
                    if (f.namespaceURI === Ea || c.forExport) {
                        try {
                            k = this.fakeTS && function (a) {
                                o(f.querySelectorAll(".highcharts-text-shadow"),
                                function (b) {
                                    b.style.display = a
                                })
                            }, Ka && j.textShadow ? (i = j.textShadow, j.textShadow = "") : k && k(P), b = f.getBBox ? t({}, f.getBBox()) : {
                                width: f.offsetWidth,
                                height: f.offsetHeight
                            }, i ? j.textShadow = i : k && k("")
                        } catch (n) { }
                        if (!b || b.width < 0) b = {
                            width: 0,
                            height: 0
                        }
                    } else b = this.htmlGetBBox();
                    if (c.isSVG) {
                        a = b.width;
                        d = b.height;
                        if (sa && g && g.fontSize === "11px" && d.toPrecision(3) === "16.9") b.height = d = 14;
                        if (e) b.width = O(d * aa(h)) + O(a * W(h)), b.height = O(d * W(h)) + O(a * aa(h))
                    }
                    m && (c.cache[m] = b)
                }
                return b
            },
            show: function (a) {
                return this.attr({
                    visibility: a ?
                    "inherit" : "visible"
                })
            },
            hide: function () {
                return this.attr({
                    visibility: "hidden"
                })
            },
            fadeOut: function (a) {
                var b = this;
                b.animate({
                    opacity: 0
                }, {
                    duration: a || 150,
                    complete: function () {
                        b.attr({
                            y: -9999
                        })
                    }
                })
            },
            add: function (a) {
                var b = this.renderer,
                c = this.element,
                d;
                if (a) this.parentGroup = a;
                this.parentInverted = a && a.inverted;
                this.textStr !== void 0 && b.buildText(this);
                this.added = !0;
                if (!a || a.handleZ || this.zIndex) d = this.zIndexSetter();
                d || (a ? a.element : b.box).appendChild(c);
                if (this.onAdd) this.onAdd();
                return this
            },
            safeRemoveChild: function (a) {
                var b =
                a.parentNode;
                b && b.removeChild(a)
            },
            destroy: function () {
                var a = this,
                b = a.element || {},
                c = a.shadows,
                d = a.renderer.isSVG && b.nodeName === "SPAN" && a.parentGroup,
                e, f;
                b.onclick = b.onmouseout = b.onmouseover = b.onmousemove = b.point = null;
                cb(a);
                if (a.clipPath) a.clipPath = a.clipPath.destroy();
                if (a.stops) {
                    for (f = 0; f < a.stops.length; f++) a.stops[f] = a.stops[f].destroy();
                    a.stops = null
                }
                a.safeRemoveChild(b);
                for (c && o(c, function (b) {
                    a.safeRemoveChild(b)
                }); d && d.div && d.div.childNodes.length === 0; ) b = d.parentGroup, a.safeRemoveChild(d.div), delete d.div,
                d = b;
                a.alignTo && ja(a.renderer.alignedObjects, a);
                for (e in a) delete a[e];
                return null
            },
            shadow: function (a, b, c) {
                var d = [],
                e, f, g = this.element,
                h, i, j, k;
                if (a) {
                    i = p(a.width, 3);
                    j = (a.opacity || 0.15) / i;
                    k = this.parentInverted ? "(-1,-1)" : "(" + p(a.offsetX, 1) + ", " + p(a.offsetY, 1) + ")";
                    for (e = 1; e <= i; e++) {
                        f = g.cloneNode(0);
                        h = i * 2 + 1 - 2 * e;
                        K(f, {
                            isShadow: "true",
                            stroke: a.color || "black",
                            "stroke-opacity": j * e,
                            "stroke-width": h,
                            transform: "translate" + k,
                            fill: P
                        });
                        if (c) K(f, "height", s(K(f, "height") - h, 0)), f.cutHeight = h;
                        b ? b.element.appendChild(f) :
                        g.parentNode.insertBefore(f, g);
                        d.push(f)
                    }
                    this.shadows = d
                }
                return this
            },
            xGetter: function (a) {
                this.element.nodeName === "circle" && (a = {
                    x: "cx",
                    y: "cy"
                }[a] || a);
                return this._defaultGetter(a)
            },
            _defaultGetter: function (a) {
                a = p(this[a], this.element ? this.element.getAttribute(a) : null, 0);
                /^[\-0-9\.]+$/.test(a) && (a = parseFloat(a));
                return a
            },
            dSetter: function (a, b, c) {
                a && a.join && (a = a.join(" "));
                /(NaN| {2}|^$)/.test(a) && (a = "M 0 0");
                c.setAttribute(b, a);
                this[b] = a
            },
            dashstyleSetter: function (a) {
                var b;
                if (a = a && a.toLowerCase()) {
                    a =
                    a.replace("shortdashdotdot", "3,1,1,1,1,1,").replace("shortdashdot", "3,1,1,1").replace("shortdot", "1,1,").replace("shortdash", "3,1,").replace("longdash", "8,3,").replace(/dot/g, "1,3,").replace("dash", "4,3,").replace(/,$/, "").split(",");
                    for (b = a.length; b--; ) a[b] = G(a[b]) * this["stroke-width"];
                    a = a.join(",").replace("NaN", "none");
                    this.element.setAttribute("stroke-dasharray", a)
                }
            },
            alignSetter: function (a) {
                this.element.setAttribute("text-anchor", {
                    left: "start",
                    center: "middle",
                    right: "end"
                }[a])
            },
            opacitySetter: function (a,
            b, c) {
                this[b] = a;
                c.setAttribute(b, a)
            },
            titleSetter: function (a) {
                var b = this.element.getElementsByTagName("title")[0];
                b || (b = C.createElementNS(Ea, "title"), this.element.appendChild(b));
                b.appendChild(C.createTextNode(String(p(a), "").replace(/<[^>]*>/g, "")))
            },
            textSetter: function (a) {
                if (a !== this.textStr) delete this.bBox, this.textStr = a, this.added && this.renderer.buildText(this)
            },
            fillSetter: function (a, b, c) {
                typeof a === "string" ? c.setAttribute(b, a) : a && this.colorGradient(a, b, c)
            },
            visibilitySetter: function (a, b, c) {
                a ===
                "inherit" ? c.removeAttribute(b) : c.setAttribute(b, a)
            },
            zIndexSetter: function (a, b) {
                var c = this.renderer,
                d = this.parentGroup,
                c = (d || c).element || c.box,
                e, f, g = this.element,
                h;
                e = this.added;
                var i;
                q(a) && (g.setAttribute(b, a), a = +a, this[b] === a && (e = !1), this[b] = a);
                if (e) {
                    if ((a = this.zIndex) && d) d.handleZ = !0;
                    d = c.childNodes;
                    for (i = 0; i < d.length && !h; i++)
                        if (e = d[i], f = K(e, "zIndex"), e !== g && (G(f) > a || !q(a) && q(f))) c.insertBefore(g, e), h = !0;
                    h || c.appendChild(g)
                }
                return h
            },
            _defaultSetter: function (a, b, c) {
                c.setAttribute(b, a)
            }
        };
        Q.prototype.yGetter =
        Q.prototype.xGetter;
        Q.prototype.translateXSetter = Q.prototype.translateYSetter = Q.prototype.rotationSetter = Q.prototype.verticalAlignSetter = Q.prototype.scaleXSetter = Q.prototype.scaleYSetter = function (a, b) {
            this[b] = a;
            this.doTransform = !0
        };
        Q.prototype["stroke-widthSetter"] = Q.prototype.strokeSetter = function (a, b, c) {
            this[b] = a;
            if (this.stroke && this["stroke-width"]) this.strokeWidth = this["stroke-width"], Q.prototype.fillSetter.call(this, this.stroke, "stroke", c), c.setAttribute("stroke-width", this["stroke-width"]),
            this.hasStroke = !0;
            else if (b === "stroke-width" && a === 0 && this.hasStroke) c.removeAttribute("stroke"), this.hasStroke = !1
        };
        var Aa = function () {
            this.init.apply(this, arguments)
        };
        Aa.prototype = {
            Element: Q,
            init: function (a, b, c, d, e, f) {
                var g = location,
                h, d = this.createElement("svg").attr({
                    version: "1.1"
                }).css(this.getStyle(d));
                h = d.element;
                a.appendChild(h);
                a.innerHTML.indexOf("xmlns") === -1 && K(h, "xmlns", Ea);
                this.isSVG = !0;
                this.box = h;
                this.boxWrapper = d;
                this.alignedObjects = [];
                this.url = (Ka || hb) && C.getElementsByTagName("base").length ?
                g.href.replace(/#.*?$/, "").replace(/([\('\)])/g, "\\$1").replace(/ /g, "%20") : "";
                this.createElement("desc").add().element.appendChild(C.createTextNode("Created with Highcharts 4.1.9"));
                this.defs = this.createElement("defs").add();
                this.allowHTML = f;
                this.forExport = e;
                this.gradients = {};
                this.cache = {};
                this.setSize(b, c, !1);
                var i;
                if (Ka && a.getBoundingClientRect) this.subPixelFix = b = function () {
                    M(a, {
                        left: 0,
                        top: 0
                    });
                    i = a.getBoundingClientRect();
                    M(a, {
                        left: ta(i.left) - i.left + "px",
                        top: ta(i.top) - i.top + "px"
                    })
                }, b(), I(L, "resize",
                b)
            },
            getStyle: function (a) {
                return this.style = t({
                    fontFamily: '"Lucida Grande", "Lucida Sans Unicode", Arial, Helvetica, sans-serif',
                    fontSize: "12px"
                }, a)
            },
            isHidden: function () {
                return !this.boxWrapper.getBBox().width
            },
            destroy: function () {
                var a = this.defs;
                this.box = null;
                this.boxWrapper = this.boxWrapper.destroy();
                Pa(this.gradients || {});
                this.gradients = null;
                if (a) this.defs = a.destroy();
                this.subPixelFix && Y(L, "resize", this.subPixelFix);
                return this.alignedObjects = null
            },
            createElement: function (a) {
                var b = new this.Element;
                b.init(this, a);
                return b
            },
            draw: function () { },
            getRadialAttr: function (a, b) {
                return {
                    cx: a[0] - a[2] / 2 + b.cx * a[2],
                    cy: a[1] - a[2] / 2 + b.cy * a[2],
                    r: b.r * a[2]
                }
            },
            buildText: function (a) {
                for (var b = a.element, c = this, d = c.forExport, e = p(a.textStr, "").toString(), f = e.indexOf("<") !== -1, g = b.childNodes, h, i, j = K(b, "x"), k = a.styles, m = a.textWidth, n = k && k.lineHeight, l = k && k.textShadow, u = k && k.textOverflow === "ellipsis", r = g.length, Z = m && !a.added && this.box, A = function (a) {
                    return n ? G(n) : c.fontMetrics(/(px|em)$/.test(a && a.style.fontSize) ? a.style.fontSize :
                        k && k.fontSize || c.style.fontSize || 12, a).h
                }, v = function (a) {
                    return a.replace(/&lt;/g, "<").replace(/&gt;/g, ">")
                }; r--; ) b.removeChild(g[r]);
                !f && !l && !u && e.indexOf(" ") === -1 ? b.appendChild(C.createTextNode(v(e))) : (h = /<.*style="([^"]+)".*>/, i = /<.*href="(http[^"]+)".*>/, Z && Z.appendChild(b), e = f ? e.replace(/<(b|strong)>/g, '<span style="font-weight:bold">').replace(/<(i|em)>/g, '<span style="font-style:italic">').replace(/<a/g, "<span").replace(/<\/(b|strong|i|em|a)>/g, "</span>").split(/<br.*?>/g) : [e], e[e.length - 1] ===
                "" && e.pop(), o(e, function (e, f) {
                    var g, n = 0,
                        e = e.replace(/<span/g, "|||<span").replace(/<\/span>/g, "</span>|||");
                    g = e.split("|||");
                    o(g, function (e) {
                        if (e !== "" || g.length === 1) {
                            var l = {},
                                r = C.createElementNS(Ea, "tspan"),
                                p;
                            h.test(e) && (p = e.match(h)[1].replace(/(;| |^)color([ :])/, "$1fill$2"), K(r, "style", p));
                            i.test(e) && !d && (K(r, "onclick", 'location.href="' + e.match(i)[1] + '"'), M(r, {
                                cursor: "pointer"
                            }));
                            e = v(e.replace(/<(.|\n)*?>/g, "") || " ");
                            if (e !== " ") {
                                r.appendChild(C.createTextNode(e));
                                if (n) l.dx = 0;
                                else if (f && j !== null) l.x =
                                    j;
                                K(r, l);
                                b.appendChild(r);
                                !n && f && (!ca && d && M(r, {
                                    display: "block"
                                }), K(r, "dy", A(r)));
                                if (m) {
                                    for (var l = e.replace(/([^\^])-/g, "$1- ").split(" "), Z = g.length > 1 || f || l.length > 1 && k.whiteSpace !== "nowrap", o, y, q, s = [], x = A(r), t = 1, w = a.rotation, z = e, D = z.length;
                                        (Z || u) && (l.length || s.length); ) a.rotation = 0, o = a.getBBox(!0), q = o.width, !ca && c.forExport && (q = c.measureSpanWidth(r.firstChild.data, a.styles)), o = q > m, y === void 0 && (y = o), u && y ? (D /= 2, z === "" || !o && D < 0.5 ? l = [] : (o && (y = !0), z = e.substring(0, z.length + (o ? -1 : 1) * ta(D)), l = [z + (m > 3 ? "\u2026" :
                                        "")], r.removeChild(r.firstChild))) : !o || l.length === 1 ? (l = s, s = [], l.length && (t++, r = C.createElementNS(Ea, "tspan"), K(r, {
                                            dy: x,
                                            x: j
                                        }), p && K(r, "style", p), b.appendChild(r)), q > m && (m = q)) : (r.removeChild(r.firstChild), s.unshift(l.pop())), l.length && r.appendChild(C.createTextNode(l.join(" ").replace(/- /g, "-")));
                                    y && a.attr("title", a.textStr);
                                    a.rotation = w
                                }
                                n++
                            }
                        }
                    })
                }), Z && Z.removeChild(b), l && a.applyTextShadow && a.applyTextShadow(l))
            },
            getContrast: function (a) {
                a = na(a).rgba;
                return a[0] + a[1] + a[2] > 384 ? "#000000" : "#FFFFFF"
            },
            button: function (a,
            b, c, d, e, f, g, h, i) {
                var j = this.label(a, b, c, i, null, null, null, null, "button"),
                k = 0,
                m, n, l, u, r, p, a = {
                    x1: 0,
                    y1: 0,
                    x2: 0,
                    y2: 1
                },
                e = D({
                    "stroke-width": 1,
                    stroke: "#CCCCCC",
                    fill: {
                        linearGradient: a,
                        stops: [
                            [0, "#FEFEFE"],
                            [1, "#F6F6F6"]
                        ]
                    },
                    r: 2,
                    padding: 5,
                    style: {
                        color: "black"
                    }
                }, e);
                l = e.style;
                delete e.style;
                f = D(e, {
                    stroke: "#68A",
                    fill: {
                        linearGradient: a,
                        stops: [
                        [0, "#FFF"],
                        [1, "#ACF"]
                    ]
                    }
                }, f);
                u = f.style;
                delete f.style;
                g = D(e, {
                    stroke: "#68A",
                    fill: {
                        linearGradient: a,
                        stops: [
                        [0, "#9BD"],
                        [1, "#CDF"]
                    ]
                    }
                }, g);
                r = g.style;
                delete g.style;
                h = D(e, {
                    style: {
                        color: "#CCC"
                    }
                },
                h);
                p = h.style;
                delete h.style;
                I(j.element, sa ? "mouseover" : "mouseenter", function () {
                    k !== 3 && j.attr(f).css(u)
                });
                I(j.element, sa ? "mouseout" : "mouseleave", function () {
                    k !== 3 && (m = [e, f, g][k], n = [l, u, r][k], j.attr(m).css(n))
                });
                j.setState = function (a) {
                    (j.state = k = a) ? a === 2 ? j.attr(g).css(r) : a === 3 && j.attr(h).css(p) : j.attr(e).css(l)
                };
                return j.on("click", function (a) {
                    k !== 3 && d.call(j, a)
                }).attr(e).css(t({
                    cursor: "default"
                }, l))
            },
            crispLine: function (a, b) {
                a[1] === a[4] && (a[1] = a[4] = w(a[1]) - b % 2 / 2);
                a[2] === a[5] && (a[2] = a[5] = w(a[2]) + b % 2 /
                2);
                return a
            },
            path: function (a) {
                var b = {
                    fill: P
                };
                Ga(a) ? b.d = a : da(a) && t(b, a);
                return this.createElement("path").attr(b)
            },
            circle: function (a, b, c) {
                a = da(a) ? a : {
                    x: a,
                    y: b,
                    r: c
                };
                b = this.createElement("circle");
                b.xSetter = function (a) {
                    this.element.setAttribute("cx", a)
                };
                b.ySetter = function (a) {
                    this.element.setAttribute("cy", a)
                };
                return b.attr(a)
            },
            arc: function (a, b, c, d, e, f) {
                if (da(a)) b = a.y, c = a.r, d = a.innerR, e = a.start, f = a.end, a = a.x;
                a = this.symbol("arc", a || 0, b || 0, c || 0, c || 0, {
                    innerR: d || 0,
                    start: e || 0,
                    end: f || 0
                });
                a.r = c;
                return a
            },
            rect: function (a,
            b, c, d, e, f) {
                var e = da(a) ? a.r : e,
                g = this.createElement("rect"),
                a = da(a) ? a : a === x ? {} : {
                    x: a,
                    y: b,
                    width: s(c, 0),
                    height: s(d, 0)
                };
                if (f !== x) a.strokeWidth = f, a = g.crisp(a);
                if (e) a.r = e;
                g.rSetter = function (a) {
                    K(this.element, {
                        rx: a,
                        ry: a
                    })
                };
                return g.attr(a)
            },
            setSize: function (a, b, c) {
                var d = this.alignedObjects,
                e = d.length;
                this.width = a;
                this.height = b;
                for (this.boxWrapper[p(c, !0) ? "animate" : "attr"]({
                    width: a,
                    height: b
                }); e--; ) d[e].align()
            },
            g: function (a) {
                var b = this.createElement("g");
                return q(a) ? b.attr({
                    "class": "highcharts-" + a
                }) : b
            },
            image: function (a,
            b, c, d, e) {
                var f = {
                    preserveAspectRatio: P
                };
                arguments.length > 1 && t(f, {
                    x: b,
                    y: c,
                    width: d,
                    height: e
                });
                f = this.createElement("image").attr(f);
                f.element.setAttributeNS ? f.element.setAttributeNS("http://www.w3.org/1999/xlink", "href", a) : f.element.setAttribute("hc-svg-href", a);
                return f
            },
            symbol: function (a, b, c, d, e, f) {
                var g, h = this.symbols[a],
                h = h && h(w(b), w(c), d, e, f),
                i = /^url\((.*?)\)$/,
                j, k;
                if (h) g = this.path(h), t(g, {
                    symbolName: a,
                    x: b,
                    y: c,
                    width: d,
                    height: e
                }), f && t(g, f);
                else if (i.test(a)) k = function (a, b) {
                    a.element && (a.attr({
                        width: b[0],
                        height: b[1]
                    }), a.alignByTranslate || a.translate(w((d - b[0]) / 2), w((e - b[1]) / 2)))
                }, j = a.match(i)[1], a = Kb[j] || f && f.width && f.height && [f.width, f.height], g = this.image(j).attr({
                    x: b,
                    y: c
                }), g.isImg = !0, a ? k(g, a) : (g.attr({
                    width: 0,
                    height: 0
                }), $("img", {
                    onload: function () {
                        this.width === 0 && (M(this, {
                            position: "absolute",
                            top: "-999em"
                        }), document.body.appendChild(this));
                        k(g, Kb[j] = [this.width, this.height]);
                        this.parentNode && this.parentNode.removeChild(this)
                    },
                    src: j
                }));
                return g
            },
            symbols: {
                circle: function (a, b, c, d) {
                    var e = 0.166 * c;
                    return ["M",
                    a + c / 2, b, "C", a + c + e, b, a + c + e, b + d, a + c / 2, b + d, "C", a - e, b + d, a - e, b, a + c / 2, b, "Z"
                ]
                },
                square: function (a, b, c, d) {
                    return ["M", a, b, "L", a + c, b, a + c, b + d, a, b + d, "Z"]
                },
                triangle: function (a, b, c, d) {
                    return ["M", a + c / 2, b, "L", a + c, b + d, a, b + d, "Z"]
                },
                "triangle-down": function (a, b, c, d) {
                    return ["M", a, b, "L", a + c, b, a + c / 2, b + d, "Z"]
                },
                diamond: function (a, b, c, d) {
                    return ["M", a + c / 2, b, "L", a + c, b + d / 2, a + c / 2, b + d, a, b + d / 2, "Z"]
                },
                arc: function (a, b, c, d, e) {
                    var f = e.start,
                    c = e.r || c || d,
                    g = e.end - 0.001,
                    d = e.innerR,
                    h = e.open,
                    i = W(f),
                    j = aa(f),
                    k = W(g),
                    g = aa(g),
                    e = e.end - f < ma ? 0 : 1;
                    return ["M", a + c * i, b + c * j, "A", c, c, 0, e, 1, a + c * k, b + c * g, h ? "M" : "L", a + d * k, b + d * g, "A", d, d, 0, e, 0, a + d * i, b + d * j, h ? "" : "Z"]
                },
                callout: function (a, b, c, d, e) {
                    var f = z(e && e.r || 0, c, d),
                    g = f + 6,
                    h = e && e.anchorX,
                    e = e && e.anchorY,
                    i;
                    i = ["M", a + f, b, "L", a + c - f, b, "C", a + c, b, a + c, b, a + c, b + f, "L", a + c, b + d - f, "C", a + c, b + d, a + c, b + d, a + c - f, b + d, "L", a + f, b + d, "C", a, b + d, a, b + d, a, b + d - f, "L", a, b + f, "C", a, b, a, b, a + f, b];
                    h && h > c && e > b + g && e < b + d - g ? i.splice(13, 3, "L", a + c, e - 6, a + c + 6, e, a + c, e + 6, a + c, b + d - f) : h && h < 0 && e > b + g && e < b + d - g ? i.splice(33, 3, "L", a, e + 6, a - 6, e, a, e - 6, a, b + f) : e && e >
                    d && h > a + g && h < a + c - g ? i.splice(23, 3, "L", h + 6, b + d, h, b + d + 6, h - 6, b + d, a + f, b + d) : e && e < 0 && h > a + g && h < a + c - g && i.splice(3, 3, "L", h - 6, b, h, b - 6, h + 6, b, c - f, b);
                    return i
                }
            },
            clipRect: function (a, b, c, d) {
                var e = "highcharts-" + xb++,
                f = this.createElement("clipPath").attr({
                    id: e
                }).add(this.defs),
                a = this.rect(a, b, c, d, 0).add(f);
                a.id = e;
                a.clipPath = f;
                a.count = 0;
                return a
            },
            text: function (a, b, c, d) {
                var e = fa || !ca && this.forExport,
                f = {};
                if (d && (this.allowHTML || !this.forExport)) return this.html(a, b, c);
                f.x = Math.round(b || 0);
                if (c) f.y = Math.round(c);
                if (a ||
                a === 0) f.text = a;
                a = this.createElement("text").attr(f);
                e && a.css({
                    position: "absolute"
                });
                if (!d) a.xSetter = function (a, b, c) {
                    var d = c.getElementsByTagName("tspan"),
                    e, f = c.getAttribute(b),
                    n;
                    for (n = 0; n < d.length; n++) e = d[n], e.getAttribute(b) === f && e.setAttribute(b, a);
                    c.setAttribute(b, a)
                };
                return a
            },
            fontMetrics: function (a, b) {
                var c, d, a = a || this.style.fontSize;
                !a && b && L.getComputedStyle && (b = b.element || b, a = (c = L.getComputedStyle(b, "")) && c.fontSize);
                a = /px/.test(a) ? G(a) : /em/.test(a) ? parseFloat(a) * 12 : 12;
                c = a < 24 ? a + 3 : w(a * 1.2);
                d = w(c * 0.8);
                return {
                    h: c,
                    b: d,
                    f: a
                }
            },
            rotCorr: function (a, b, c) {
                var d = a;
                b && c && (d = s(d * W(b * ga), 4));
                return {
                    x: -a / 3 * aa(b * ga),
                    y: d
                }
            },
            label: function (a, b, c, d, e, f, g, h, i) {
                function j() {
                    var a, b;
                    a = u.element.style;
                    p = (s === void 0 || va === void 0 || l.styles.textAlign) && q(u.textStr) && u.getBBox();
                    l.width = (s || p.width || 0) + 2 * v + y;
                    l.height = (va || p.height || 0) + 2 * v;
                    B = v + n.fontMetrics(a && a.fontSize, u).b;
                    if (E) {
                        if (!r) a = w(-A * v) + C, b = (h ? -B : 0) + C, l.box = r = d ? n.symbol(d, a, b, l.width, l.height, H) : n.rect(a, b, l.width, l.height, 0, H[Pb]), r.isImg || r.attr("fill",
                        P), r.add(l);
                        r.isImg || r.attr(t({
                            width: w(l.width),
                            height: w(l.height)
                        }, H));
                        H = null
                    }
                }

                function k() {
                    var a = l.styles,
                    a = a && a.textAlign,
                    b = y + v * (1 - A),
                    c;
                    c = h ? 0 : B;
                    if (q(s) && p && (a === "center" || a === "right")) b += {
                        center: 0.5,
                        right: 1
                    }[a] * (s - p.width);
                    if (b !== u.x || c !== u.y) u.attr("x", b), c !== x && u.attr("y", c);
                    u.x = b;
                    u.y = c
                }

                function m(a, b) {
                    r ? r.attr(a, b) : H[a] = b
                }
                var n = this,
                l = n.g(i),
                u = n.text("", 0, 0, g).attr({
                    zIndex: 1
                }),
                r, p, A = 0,
                v = 3,
                y = 0,
                s, va, zb, z, C = 0,
                H = {},
                B, E;
                l.onAdd = function () {
                    u.add(l);
                    l.attr({
                        text: a || a === 0 ? a : "",
                        x: b,
                        y: c
                    });
                    r && q(e) && l.attr({
                        anchorX: e,
                        anchorY: f
                    })
                };
                l.widthSetter = function (a) {
                    s = a
                };
                l.heightSetter = function (a) {
                    va = a
                };
                l.paddingSetter = function (a) {
                    if (q(a) && a !== v) v = l.padding = a, k()
                };
                l.paddingLeftSetter = function (a) {
                    q(a) && a !== y && (y = a, k())
                };
                l.alignSetter = function (a) {
                    A = {
                        left: 0,
                        center: 0.5,
                        right: 1
                    }[a]
                };
                l.textSetter = function (a) {
                    a !== x && u.textSetter(a);
                    j();
                    k()
                };
                l["stroke-widthSetter"] = function (a, b) {
                    a && (E = !0);
                    C = a % 2 / 2;
                    m(b, a)
                };
                l.strokeSetter = l.fillSetter = l.rSetter = function (a, b) {
                    b === "fill" && a && (E = !0);
                    m(b, a)
                };
                l.anchorXSetter = function (a, b) {
                    e = a;
                    m(b, w(a) -
                    C - zb)
                };
                l.anchorYSetter = function (a, b) {
                    f = a;
                    m(b, a - z)
                };
                l.xSetter = function (a) {
                    l.x = a;
                    A && (a -= A * ((s || p.width) + v));
                    zb = w(a);
                    l.attr("translateX", zb)
                };
                l.ySetter = function (a) {
                    z = l.y = w(a);
                    l.attr("translateY", z)
                };
                var G = l.css;
                return t(l, {
                    css: function (a) {
                        if (a) {
                            var b = {},
                            a = D(a);
                            o(l.textProps, function (c) {
                                a[c] !== x && (b[c] = a[c], delete a[c])
                            });
                            u.css(b)
                        }
                        return G.call(l, a)
                    },
                    getBBox: function () {
                        return {
                            width: p.width + 2 * v,
                            height: p.height + 2 * v,
                            x: p.x - v,
                            y: p.y - v
                        }
                    },
                    shadow: function (a) {
                        r && r.shadow(a);
                        return l
                    },
                    destroy: function () {
                        Y(l.element,
                        "mouseenter");
                        Y(l.element, "mouseleave");
                        u && (u = u.destroy());
                        r && (r = r.destroy());
                        Q.prototype.destroy.call(l);
                        l = n = j = k = m = null
                    }
                })
            }
        };
        $a = Aa;
        t(Q.prototype, {
            htmlCss: function (a) {
                var b = this.element;
                if (b = a && b.tagName === "SPAN" && a.width) delete a.width, this.textWidth = b, this.updateTransform();
                if (a && a.textOverflow === "ellipsis") a.whiteSpace = "nowrap", a.overflow = "hidden";
                this.styles = t(this.styles, a);
                M(this.element, a);
                return this
            },
            htmlGetBBox: function () {
                var a = this.element;
                if (a.nodeName === "text") a.style.position = "absolute";
                return {
                    x: a.offsetLeft,
                    y: a.offsetTop,
                    width: a.offsetWidth,
                    height: a.offsetHeight
                }
            },
            htmlUpdateTransform: function () {
                if (this.added) {
                    var a = this.renderer,
                    b = this.element,
                    c = this.translateX || 0,
                    d = this.translateY || 0,
                    e = this.x || 0,
                    f = this.y || 0,
                    g = this.textAlign || "left",
                    h = {
                        left: 0,
                        center: 0.5,
                        right: 1
                    }[g],
                    i = this.shadows,
                    j = this.styles;
                    M(b, {
                        marginLeft: c,
                        marginTop: d
                    });
                    i && o(i, function (a) {
                        M(a, {
                            marginLeft: c + 1,
                            marginTop: d + 1
                        })
                    });
                    this.inverted && o(b.childNodes, function (c) {
                        a.invertChild(c, b)
                    });
                    if (b.tagName === "SPAN") {
                        var k = this.rotation,
                        m, n = G(this.textWidth),
                        l = [k, g, b.innerHTML, this.textWidth, this.textAlign].join(",");
                        if (l !== this.cTT) {
                            m = a.fontMetrics(b.style.fontSize).b;
                            q(k) && this.setSpanRotation(k, h, m);
                            i = p(this.elemWidth, b.offsetWidth);
                            if (i > n && /[ \-]/.test(b.textContent || b.innerText)) M(b, {
                                width: n + "px",
                                display: "block",
                                whiteSpace: j && j.whiteSpace || "normal"
                            }), i = n;
                            this.getSpanCorrection(i, m, h, k, g)
                        }
                        M(b, {
                            left: e + (this.xCorr || 0) + "px",
                            top: f + (this.yCorr || 0) + "px"
                        });
                        if (hb) m = b.offsetHeight;
                        this.cTT = l
                    }
                } else this.alignOnAdd = !0
            },
            setSpanRotation: function (a,
            b, c) {
                var d = {},
                e = sa ? "-ms-transform" : hb ? "-webkit-transform" : Ka ? "MozTransform" : Ib ? "-o-transform" : "";
                d[e] = d.transform = "rotate(" + a + "deg)";
                d[e + (Ka ? "Origin" : "-origin")] = d.transformOrigin = b * 100 + "% " + c + "px";
                M(this.element, d)
            },
            getSpanCorrection: function (a, b, c) {
                this.xCorr = -a * c;
                this.yCorr = -b
            }
        });
        t(Aa.prototype, {
            html: function (a, b, c) {
                var d = this.createElement("span"),
                e = d.element,
                f = d.renderer;
                d.textSetter = function (a) {
                    a !== e.innerHTML && delete this.bBox;
                    e.innerHTML = this.textStr = a;
                    d.htmlUpdateTransform()
                };
                d.xSetter = d.ySetter =
                d.alignSetter = d.rotationSetter = function (a, b) {
                    b === "align" && (b = "textAlign");
                    d[b] = a;
                    d.htmlUpdateTransform()
                };
                d.attr({
                    text: a,
                    x: w(b),
                    y: w(c)
                }).css({
                    position: "absolute",
                    fontFamily: this.style.fontFamily,
                    fontSize: this.style.fontSize
                });
                e.style.whiteSpace = "nowrap";
                d.css = d.htmlCss;
                if (f.isSVG) d.add = function (a) {
                    var b, c = f.box.parentNode,
                    j = [];
                    if (this.parentGroup = a) {
                        if (b = a.div, !b) {
                            for (; a; ) j.push(a), a = a.parentGroup;
                            o(j.reverse(), function (a) {
                                var d, e = K(a.element, "class");
                                e && (e = {
                                    className: e
                                });
                                b = a.div = a.div || $(Ja, e, {
                                    position: "absolute",
                                    left: (a.translateX || 0) + "px",
                                    top: (a.translateY || 0) + "px"
                                }, b || c);
                                d = b.style;
                                t(a, {
                                    translateXSetter: function (b, c) {
                                        d.left = b + "px";
                                        a[c] = b;
                                        a.doTransform = !0
                                    },
                                    translateYSetter: function (b, c) {
                                        d.top = b + "px";
                                        a[c] = b;
                                        a.doTransform = !0
                                    }
                                });
                                o(["opacity", "visibility"], function (b) {
                                    Ta(a, b + "Setter", function (a, b, c, e) {
                                        a.call(this, b, c, e);
                                        d[c] = b
                                    })
                                })
                            })
                        }
                    } else b = c;
                    b.appendChild(e);
                    d.added = !0;
                    d.alignOnAdd && d.htmlUpdateTransform();
                    return d
                };
                return d
            }
        });
        if (!ca && !fa) {
            E = {
                init: function (a, b) {
                    var c = ["<", b, ' filled="f" stroked="f"'],
                    d = ["position: ",
                        "absolute", ";"
                    ],
                    e = b === Ja;
                    (b === "shape" || e) && d.push("left:0;top:0;width:1px;height:1px;");
                    d.push("visibility: ", e ? "hidden" : "visible");
                    c.push(' style="', d.join(""), '"/>');
                    if (b) c = e || b === "span" || b === "img" ? c.join("") : a.prepVML(c), this.element = $(c);
                    this.renderer = a
                },
                add: function (a) {
                    var b = this.renderer,
                    c = this.element,
                    d = b.box,
                    d = a ? a.element || a : d;
                    a && a.inverted && b.invertChild(c, d);
                    d.appendChild(c);
                    this.added = !0;
                    this.alignOnAdd && !this.deferUpdateTransform && this.updateTransform();
                    if (this.onAdd) this.onAdd();
                    return this
                },
                updateTransform: Q.prototype.htmlUpdateTransform,
                setSpanRotation: function () {
                    var a = this.rotation,
                    b = W(a * ga),
                    c = aa(a * ga);
                    M(this.element, {
                        filter: a ? ["progid:DXImageTransform.Microsoft.Matrix(M11=", b, ", M12=", -c, ", M21=", c, ", M22=", b, ", sizingMethod='auto expand')"].join("") : P
                    })
                },
                getSpanCorrection: function (a, b, c, d, e) {
                    var f = d ? W(d * ga) : 1,
                    g = d ? aa(d * ga) : 0,
                    h = p(this.elemHeight, this.element.offsetHeight),
                    i;
                    this.xCorr = f < 0 && -a;
                    this.yCorr = g < 0 && -h;
                    i = f * g < 0;
                    this.xCorr += g * b * (i ? 1 - c : c);
                    this.yCorr -= f * b * (d ? i ? c : 1 - c : 1);
                    e && e !==
                    "left" && (this.xCorr -= a * c * (f < 0 ? -1 : 1), d && (this.yCorr -= h * c * (g < 0 ? -1 : 1)), M(this.element, {
                        textAlign: e
                    }))
                },
                pathToVML: function (a) {
                    for (var b = a.length, c = []; b--; )
                        if (qa(a[b])) c[b] = w(a[b] * 10) - 5;
                        else if (a[b] === "Z") c[b] = "x";
                        else if (c[b] = a[b], a.isArc && (a[b] === "wa" || a[b] === "at")) c[b + 5] === c[b + 7] && (c[b + 7] += a[b + 7] > a[b + 5] ? 1 : -1), c[b + 6] === c[b + 8] && (c[b + 8] += a[b + 8] > a[b + 6] ? 1 : -1);
                    return c.join(" ") || "x"
                },
                clip: function (a) {
                    var b = this,
                    c;
                    a ? (c = a.members, ja(c, b), c.push(b), b.destroyClip = function () {
                        ja(c, b)
                    }, a = a.getCSS(b)) : (b.destroyClip &&
                    b.destroyClip(), a = {
                        clip: gb ? "inherit" : "rect(auto)"
                    });
                    return b.css(a)
                },
                css: Q.prototype.htmlCss,
                safeRemoveChild: function (a) {
                    a.parentNode && Qa(a)
                },
                destroy: function () {
                    this.destroyClip && this.destroyClip();
                    return Q.prototype.destroy.apply(this)
                },
                on: function (a, b) {
                    this.element["on" + a] = function () {
                        var a = L.event;
                        a.target = a.srcElement;
                        b(a)
                    };
                    return this
                },
                cutOffPath: function (a, b) {
                    var c, a = a.split(/[ ,]/);
                    c = a.length;
                    if (c === 9 || c === 11) a[c - 4] = a[c - 2] = G(a[c - 2]) - 10 * b;
                    return a.join(" ")
                },
                shadow: function (a, b, c) {
                    var d = [],
                    e,
                    f = this.element,
                    g = this.renderer,
                    h, i = f.style,
                    j, k = f.path,
                    m, n, l, u;
                    k && typeof k.value !== "string" && (k = "x");
                    n = k;
                    if (a) {
                        l = p(a.width, 3);
                        u = (a.opacity || 0.15) / l;
                        for (e = 1; e <= 3; e++) {
                            m = l * 2 + 1 - 2 * e;
                            c && (n = this.cutOffPath(k.value, m + 0.5));
                            j = ['<shape isShadow="true" strokeweight="', m, '" filled="false" path="', n, '" coordsize="10 10" style="', f.style.cssText, '" />'];
                            h = $(g.prepVML(j), null, {
                                left: G(i.left) + p(a.offsetX, 1),
                                top: G(i.top) + p(a.offsetY, 1)
                            });
                            if (c) h.cutOff = m + 1;
                            j = ['<stroke color="', a.color || "black", '" opacity="', u * e, '"/>'];
                            $(g.prepVML(j), null, null, h);
                            b ? b.element.appendChild(h) : f.parentNode.insertBefore(h, f);
                            d.push(h)
                        }
                        this.shadows = d
                    }
                    return this
                },
                updateShadows: ua,
                setAttr: function (a, b) {
                    gb ? this.element[a] = b : this.element.setAttribute(a, b)
                },
                classSetter: function (a) {
                    this.element.className = a
                },
                dashstyleSetter: function (a, b, c) {
                    (c.getElementsByTagName("stroke")[0] || $(this.renderer.prepVML(["<stroke/>"]), null, null, c))[b] = a || "solid";
                    this[b] = a
                },
                dSetter: function (a, b, c) {
                    var d = this.shadows,
                    a = a || [];
                    this.d = a.join && a.join(" ");
                    c.path = a =
                    this.pathToVML(a);
                    if (d)
                        for (c = d.length; c--; ) d[c].path = d[c].cutOff ? this.cutOffPath(a, d[c].cutOff) : a;
                    this.setAttr(b, a)
                },
                fillSetter: function (a, b, c) {
                    var d = c.nodeName;
                    if (d === "SPAN") c.style.color = a;
                    else if (d !== "IMG") c.filled = a !== P, this.setAttr("fillcolor", this.renderer.color(a, c, b, this))
                },
                opacitySetter: ua,
                rotationSetter: function (a, b, c) {
                    c = c.style;
                    this[b] = c[b] = a;
                    c.left = -w(aa(a * ga) + 1) + "px";
                    c.top = w(W(a * ga)) + "px"
                },
                strokeSetter: function (a, b, c) {
                    this.setAttr("strokecolor", this.renderer.color(a, c, b))
                },
                "stroke-widthSetter": function (a,
                b, c) {
                    c.stroked = !!a;
                    this[b] = a;
                    qa(a) && (a += "px");
                    this.setAttr("strokeweight", a)
                },
                titleSetter: function (a, b) {
                    this.setAttr(b, a)
                },
                visibilitySetter: function (a, b, c) {
                    a === "inherit" && (a = "visible");
                    this.shadows && o(this.shadows, function (c) {
                        c.style[b] = a
                    });
                    c.nodeName === "DIV" && (a = a === "hidden" ? "-999em" : 0, gb || (c.style[b] = a ? "visible" : "hidden"), b = "top");
                    c.style[b] = a
                },
                xSetter: function (a, b, c) {
                    this[b] = a;
                    b === "x" ? b = "left" : b === "y" && (b = "top");
                    this.updateClipping ? (this[b] = a, this.updateClipping()) : c.style[b] = a
                },
                zIndexSetter: function (a,
                b, c) {
                    c.style[b] = a
                }
            };
            B.VMLElement = E = ka(Q, E);
            E.prototype.ySetter = E.prototype.widthSetter = E.prototype.heightSetter = E.prototype.xSetter;
            var Ma = {
                Element: E,
                isIE8: za.indexOf("MSIE 8.0") > -1,
                init: function (a, b, c, d) {
                    var e;
                    this.alignedObjects = [];
                    d = this.createElement(Ja).css(t(this.getStyle(d), {
                        position: "relative"
                    }));
                    e = d.element;
                    a.appendChild(d.element);
                    this.isVML = !0;
                    this.box = e;
                    this.boxWrapper = d;
                    this.cache = {};
                    this.setSize(b, c, !1);
                    if (!C.namespaces.hcv) {
                        C.namespaces.add("hcv", "urn:schemas-microsoft-com:vml");
                        try {
                            C.createStyleSheet().cssText =
                            "hcv\\:fill, hcv\\:path, hcv\\:shape, hcv\\:stroke{ behavior:url(#default#VML); display: inline-block; } "
                        } catch (f) {
                            C.styleSheets[0].cssText += "hcv\\:fill, hcv\\:path, hcv\\:shape, hcv\\:stroke{ behavior:url(#default#VML); display: inline-block; } "
                        }
                    }
                },
                isHidden: function () {
                    return !this.box.offsetWidth
                },
                clipRect: function (a, b, c, d) {
                    var e = this.createElement(),
                    f = da(a);
                    return t(e, {
                        members: [],
                        count: 0,
                        left: (f ? a.x : a) + 1,
                        top: (f ? a.y : b) + 1,
                        width: (f ? a.width : c) - 1,
                        height: (f ? a.height : d) - 1,
                        getCSS: function (a) {
                            var b = a.element,
                            c = b.nodeName,
                            a = a.inverted,
                            d = this.top - (c === "shape" ? b.offsetTop : 0),
                            e = this.left,
                            b = e + this.width,
                            f = d + this.height,
                            d = {
                                clip: "rect(" + w(a ? e : d) + "px," + w(a ? f : b) + "px," + w(a ? b : f) + "px," + w(a ? d : e) + "px)"
                            };
                            !a && gb && c === "DIV" && t(d, {
                                width: b + "px",
                                height: f + "px"
                            });
                            return d
                        },
                        updateClipping: function () {
                            o(e.members, function (a) {
                                a.element && a.css(e.getCSS(a))
                            })
                        }
                    })
                },
                color: function (a, b, c, d) {
                    var e = this,
                    f, g = /^rgba/,
                    h, i, j = P;
                    a && a.linearGradient ? i = "gradient" : a && a.radialGradient && (i = "pattern");
                    if (i) {
                        var k, m, n = a.linearGradient || a.radialGradient,
                        l, u, r, p, A, v = "",
                        a = a.stops,
                        y, q = [],
                        va = function () {
                            h = ['<fill colors="' + q.join(",") + '" opacity="', r, '" o:opacity2="', u, '" type="', i, '" ', v, 'focus="100%" method="any" />'];
                            $(e.prepVML(h), null, null, b)
                        };
                        l = a[0];
                        y = a[a.length - 1];
                        l[0] > 0 && a.unshift([0, l[1]]);
                        y[0] < 1 && a.push([1, y[1]]);
                        o(a, function (a, b) {
                            g.test(a[1]) ? (f = na(a[1]), k = f.get("rgb"), m = f.get("a")) : (k = a[1], m = 1);
                            q.push(a[0] * 100 + "% " + k);
                            b ? (r = m, p = k) : (u = m, A = k)
                        });
                        if (c === "fill")
                            if (i === "gradient") c = n.x1 || n[0] || 0, a = n.y1 || n[1] || 0, l = n.x2 || n[2] || 0, n = n.y2 || n[3] || 0, v =
                            'angle="' + (90 - V.atan((n - a) / (l - c)) * 180 / ma) + '"', va();
                            else {
                                var j = n.r,
                                s = j * 2,
                                x = j * 2,
                                t = n.cx,
                                w = n.cy,
                                z = b.radialReference,
                                D, j = function () {
                                    z && (D = d.getBBox(), t += (z[0] - D.x) / D.width - 0.5, w += (z[1] - D.y) / D.height - 0.5, s *= z[2] / D.width, x *= z[2] / D.height);
                                    v = 'src="' + S.global.VMLRadialGradientURL + '" size="' + s + "," + x + '" origin="0.5,0.5" position="' + t + "," + w + '" color2="' + A + '" ';
                                    va()
                                };
                                d.added ? j() : d.onAdd = j;
                                j = p
                            } else j = k
                    } else if (g.test(a) && b.tagName !== "IMG") f = na(a), h = ["<", c, ' opacity="', f.get("a"), '"/>'], $(this.prepVML(h), null, null,
                    b), j = f.get("rgb");
                    else {
                        j = b.getElementsByTagName(c);
                        if (j.length) j[0].opacity = 1, j[0].type = "solid";
                        j = a
                    }
                    return j
                },
                prepVML: function (a) {
                    var b = this.isIE8,
                    a = a.join("");
                    b ? (a = a.replace("/>", ' xmlns="urn:schemas-microsoft-com:vml" />'), a = a.indexOf('style="') === -1 ? a.replace("/>", ' style="display:inline-block;behavior:url(#default#VML);" />') : a.replace('style="', 'style="display:inline-block;behavior:url(#default#VML);')) : a = a.replace("<", "<hcv:");
                    return a
                },
                text: Aa.prototype.html,
                path: function (a) {
                    var b = {
                        coordsize: "10 10"
                    };
                    Ga(a) ? b.d = a : da(a) && t(b, a);
                    return this.createElement("shape").attr(b)
                },
                circle: function (a, b, c) {
                    var d = this.symbol("circle");
                    if (da(a)) c = a.r, b = a.y, a = a.x;
                    d.isCircle = !0;
                    d.r = c;
                    return d.attr({
                        x: a,
                        y: b
                    })
                },
                g: function (a) {
                    var b;
                    a && (b = {
                        className: "highcharts-" + a,
                        "class": "highcharts-" + a
                    });
                    return this.createElement(Ja).attr(b)
                },
                image: function (a, b, c, d, e) {
                    var f = this.createElement("img").attr({
                        src: a
                    });
                    arguments.length > 1 && f.attr({
                        x: b,
                        y: c,
                        width: d,
                        height: e
                    });
                    return f
                },
                createElement: function (a) {
                    return a === "rect" ? this.symbol(a) :
                    Aa.prototype.createElement.call(this, a)
                },
                invertChild: function (a, b) {
                    var c = this,
                    d = b.style,
                    e = a.tagName === "IMG" && a.style;
                    M(a, {
                        flip: "x",
                        left: G(d.width) - (e ? G(e.top) : 1),
                        top: G(d.height) - (e ? G(e.left) : 1),
                        rotation: -90
                    });
                    o(a.childNodes, function (b) {
                        c.invertChild(b, a)
                    })
                },
                symbols: {
                    arc: function (a, b, c, d, e) {
                        var f = e.start,
                        g = e.end,
                        h = e.r || c || d,
                        c = e.innerR,
                        d = W(f),
                        i = aa(f),
                        j = W(g),
                        k = aa(g);
                        if (g - f === 0) return ["x"];
                        f = ["wa", a - h, b - h, a + h, b + h, a + h * d, b + h * i, a + h * j, b + h * k];
                        e.open && !c && f.push("e", "M", a, b);
                        f.push("at", a - c, b - c, a + c, b + c, a + c *
                        j, b + c * k, a + c * d, b + c * i, "x", "e");
                        f.isArc = !0;
                        return f
                    },
                    circle: function (a, b, c, d, e) {
                        e && (c = d = 2 * e.r);
                        e && e.isCircle && (a -= c / 2, b -= d / 2);
                        return ["wa", a, b, a + c, b + d, a + c, b + d / 2, a + c, b + d / 2, "e"]
                    },
                    rect: function (a, b, c, d, e) {
                        return Aa.prototype.symbols[!q(e) || !e.r ? "square" : "callout"].call(0, a, b, c, d, e)
                    }
                }
            };
            B.VMLRenderer = E = function () {
                this.init.apply(this, arguments)
            };
            E.prototype = D(Aa.prototype, Ma);
            $a = E
        }
        Aa.prototype.measureSpanWidth = function (a, b) {
            var c = C.createElement("span"),
            d;
            d = C.createTextNode(a);
            c.appendChild(d);
            M(c, b);
            this.box.appendChild(c);
            d = c.offsetWidth;
            Qa(c);
            return d
        };
        var Lb;
        if (fa) B.CanVGRenderer = E = function () {
            Ea = "http://www.w3.org/1999/xhtml"
        }, E.prototype.symbols = {}, Lb = function () {
            function a() {
                var a = b.length,
                d;
                for (d = 0; d < a; d++) b[d]();
                b = []
            }
            var b = [];
            return {
                push: function (c, d) {
                    b.length === 0 && Qb(d, a);
                    b.push(c)
                }
            }
        } (), $a = E;
        Sa.prototype = {
            addLabel: function () {
                var a = this.axis,
                b = a.options,
                c = a.chart,
                d = a.categories,
                e = a.names,
                f = this.pos,
                g = b.labels,
                h = a.tickPositions,
                i = f === h[0],
                j = f === h[h.length - 1],
                e = d ? p(d[f], e[f], f) : f,
                d = this.label,
                h = h.info,
                k;
                a.isDatetimeAxis &&
                h && (k = b.dateTimeLabelFormats[h.higherRanks[f] || h.unitName]);
                this.isFirst = i;
                this.isLast = j;
                b = a.labelFormatter.call({
                    axis: a,
                    chart: c,
                    isFirst: i,
                    isLast: j,
                    dateTimeLabelFormat: k,
                    value: a.isLog ? ea(ia(e)) : e
                });
                q(d) ? d && d.attr({
                    text: b
                }) : (this.labelLength = (this.label = d = q(b) && g.enabled ? c.renderer.text(b, 0, 0, g.useHTML).css(D(g.style)).add(a.labelGroup) : null) && d.getBBox().width, this.rotation = 0)
            },
            getLabelSize: function () {
                return this.label ? this.label.getBBox()[this.axis.horiz ? "height" : "width"] : 0
            },
            handleOverflow: function (a) {
                var b =
                this.axis,
                c = a.x,
                d = b.chart.chartWidth,
                e = b.chart.spacing,
                f = p(b.labelLeft, z(b.pos, e[3])),
                e = p(b.labelRight, s(b.pos + b.len, d - e[1])),
                g = this.label,
                h = this.rotation,
                i = {
                    left: 0,
                    center: 0.5,
                    right: 1
                }[b.labelAlign],
                j = g.getBBox().width,
                k = b.slotWidth,
                m = 1,
                n, l = {};
                if (h) h < 0 && c - i * j < f ? n = w(c / W(h * ga) - f) : h > 0 && c + i * j > e && (n = w((d - c) / W(h * ga)));
                else if (d = c + (1 - i) * j, c - i * j < f ? k = a.x + k * (1 - i) - f : d > e && (k = e - a.x + k * i, m = -1), k = z(b.slotWidth, k), k < b.slotWidth && b.labelAlign === "center" && (a.x += m * (b.slotWidth - k - i * (b.slotWidth - z(j, k)))), j > k || b.autoRotation &&
                g.styles.width) n = k;
                if (n) {
                    l.width = n;
                    if (!b.options.labels.style.textOverflow) l.textOverflow = "ellipsis";
                    g.css(l)
                }
            },
            getPosition: function (a, b, c, d) {
                var e = this.axis,
                f = e.chart,
                g = d && f.oldChartHeight || f.chartHeight;
                return {
                    x: a ? e.translate(b + c, null, null, d) + e.transB : e.left + e.offset + (e.opposite ? (d && f.oldChartWidth || f.chartWidth) - e.right - e.left : 0),
                    y: a ? g - e.bottom + e.offset - (e.opposite ? e.height : 0) : g - e.translate(b + c, null, null, d) - e.transB
                }
            },
            getLabelPosition: function (a, b, c, d, e, f, g, h) {
                var i = this.axis,
                j = i.transA,
                k = i.reversed,
                m = i.staggerLines,
                n = i.tickRotCorr || {
                    x: 0,
                    y: 0
                },
                c = p(e.y, n.y + (i.side === 2 ? 8 : -(c.getBBox().height / 2))),
                a = a + e.x + n.x - (f && d ? f * j * (k ? -1 : 1) : 0),
                b = b + c - (f && !d ? f * j * (k ? 1 : -1) : 0);
                m && (b += g / (h || 1) % m * (i.labelOffset / m));
                return {
                    x: a,
                    y: w(b)
                }
            },
            getMarkPath: function (a, b, c, d, e, f) {
                return f.crispLine(["M", a, b, "L", a + (e ? 0 : -c), b + (e ? c : 0)], d)
            },
            render: function (a, b, c) {
                var d = this.axis,
                e = d.options,
                f = d.chart.renderer,
                g = d.horiz,
                h = this.type,
                i = this.label,
                j = this.pos,
                k = e.labels,
                m = this.gridLine,
                n = h ? h + "Grid" : "grid",
                l = h ? h + "Tick" : "tick",
                u = e[n + "LineWidth"],
                r = e[n + "LineColor"],
                o = e[n + "LineDashStyle"],
                A = e[l + "Length"],
                n = p(e[l + "Width"], !h && d.isXAxis ? 1 : 0),
                v = e[l + "Color"],
                y = e[l + "Position"],
                l = this.mark,
                q = k.step,
                va = !0,
                s = d.tickmarkOffset,
                t = this.getPosition(g, j, s, b),
                w = t.x,
                t = t.y,
                z = g && w === d.pos + d.len || !g && t === d.pos ? -1 : 1,
                c = p(c, 1);
                this.isActive = !0;
                if (u) {
                    j = d.getPlotLinePath(j + s, u * z, b, !0);
                    if (m === x) {
                        m = {
                            stroke: r,
                            "stroke-width": u
                        };
                        if (o) m.dashstyle = o;
                        if (!h) m.zIndex = 1;
                        if (b) m.opacity = 0;
                        this.gridLine = m = u ? f.path(j).attr(m).add(d.gridGroup) : null
                    }
                    if (!b && m && j) m[this.isNew ? "attr" :
                    "animate"]({
                        d: j,
                        opacity: c
                    })
                }
                if (n && A) y === "inside" && (A = -A), d.opposite && (A = -A), h = this.getMarkPath(w, t, A, n * z, g, f), l ? l.animate({
                    d: h,
                    opacity: c
                }) : this.mark = f.path(h).attr({
                    stroke: v,
                    "stroke-width": n,
                    opacity: c
                }).add(d.axisGroup);
                if (i && !isNaN(w)) i.xy = t = this.getLabelPosition(w, t, i, g, k, s, a, q), this.isFirst && !this.isLast && !p(e.showFirstLabel, 1) || this.isLast && !this.isFirst && !p(e.showLastLabel, 1) ? va = !1 : g && !d.isRadial && !k.step && !k.rotation && !b && c !== 0 && this.handleOverflow(t), q && a % q && (va = !1), va && !isNaN(t.y) ? (t.opacity =
                c, i[this.isNew ? "attr" : "animate"](t), this.isNew = !1) : i.attr("y", -9999)
            },
            destroy: function () {
                Pa(this, this.axis)
            }
        };
        B.PlotLineOrBand = function (a, b) {
            this.axis = a;
            if (b) this.options = b, this.id = b.id
        };
        B.PlotLineOrBand.prototype = {
            render: function () {
                var a = this,
                b = a.axis,
                c = b.horiz,
                d = a.options,
                e = d.label,
                f = a.label,
                g = d.width,
                h = d.to,
                i = d.from,
                j = q(i) && q(h),
                k = d.value,
                m = d.dashStyle,
                n = a.svgElem,
                l = [],
                u, r = d.color,
                p = d.zIndex,
                o = d.events,
                v = {},
                y = b.chart.renderer;
                b.isLog && (i = Ca(i), h = Ca(h), k = Ca(k));
                if (g) {
                    if (l = b.getPlotLinePath(k, g),
                    v = {
                        stroke: r,
                        "stroke-width": g
                    }, m) v.dashstyle = m
                } else if (j) {
                    l = b.getPlotBandPath(i, h, d);
                    if (r) v.fill = r;
                    if (d.borderWidth) v.stroke = d.borderColor, v["stroke-width"] = d.borderWidth
                } else return;
                if (q(p)) v.zIndex = p;
                if (n)
                    if (l) n.animate({
                        d: l
                    }, null, n.onGetPath);
                    else {
                        if (n.hide(), n.onGetPath = function () {
                            n.show()
                        }, f) a.label = f = f.destroy()
                    } else if (l && l.length && (a.svgElem = n = y.path(l).attr(v).add(), o))
                    for (u in d = function (b) {
                        n.on(b, function (c) {
                            o[b].apply(a, [c])
                        })
                    }, o) d(u);
                if (e && q(e.text) && l && l.length && b.width > 0 && b.height > 0) {
                    e =
                    D({
                        align: c && j && "center",
                        x: c ? !j && 4 : 10,
                        verticalAlign: !c && j && "middle",
                        y: c ? j ? 16 : 10 : j ? 6 : -4,
                        rotation: c && !j && 90
                    }, e);
                    if (!f) {
                        v = {
                            align: e.textAlign || e.align,
                            rotation: e.rotation
                        };
                        if (q(p)) v.zIndex = p;
                        a.label = f = y.text(e.text, 0, 0, e.useHTML).attr(v).css(e.style).add()
                    }
                    b = [l[1], l[4], j ? l[6] : l[1]];
                    j = [l[2], l[5], j ? l[7] : l[2]];
                    l = Oa(b);
                    c = Oa(j);
                    f.align(e, !1, {
                        x: l,
                        y: c,
                        width: Da(b) - l,
                        height: Da(j) - c
                    });
                    f.show()
                } else f && f.hide();
                return a
            },
            destroy: function () {
                ja(this.axis.plotLinesAndBands, this);
                delete this.axis;
                Pa(this)
            }
        };
        var ha = B.Axis =
        function () {
            this.init.apply(this, arguments)
        };
        ha.prototype = {
            defaultOptions: {
                dateTimeLabelFormats: {
                    millisecond: "%H:%M:%S.%L",
                    second: "%H:%M:%S",
                    minute: "%H:%M",
                    hour: "%H:%M",
                    day: "%e. %b",
                    week: "%e. %b",
                    month: "%b '%y",
                    year: "%Y"
                },
                endOnTick: !1,
                gridLineColor: "#D8D8D8",
                labels: {
                    enabled: !0,
                    style: {
                        color: "#606060",
                        cursor: "default",
                        fontSize: "11px"
                    },
                    x: 0,
                    y: 15
                },
                lineColor: "#C0D0E0",
                lineWidth: 1,
                minPadding: 0.01,
                maxPadding: 0.01,
                minorGridLineColor: "#E0E0E0",
                minorGridLineWidth: 1,
                minorTickColor: "#A0A0A0",
                minorTickLength: 2,
                minorTickPosition: "outside",
                startOfWeek: 1,
                startOnTick: !1,
                tickColor: "#C0D0E0",
                tickLength: 10,
                tickmarkPlacement: "between",
                tickPixelInterval: 100,
                tickPosition: "outside",
                title: {
                    align: "middle",
                    style: {
                        color: "#707070"
                    }
                },
                type: "linear"
            },
            defaultYAxisOptions: {
                endOnTick: !0,
                gridLineWidth: 1,
                tickPixelInterval: 72,
                showLastLabel: !0,
                labels: {
                    x: -8,
                    y: 3
                },
                lineWidth: 0,
                maxPadding: 0.05,
                minPadding: 0.05,
                startOnTick: !0,
                title: {
                    rotation: 270,
                    text: "Values"
                },
                stackLabels: {
                    enabled: !1,
                    formatter: function () {
                        return B.numberFormat(this.total, -1)
                    },
                    style: D(ba.line.dataLabels.style, {
                        color: "#000000"
                    })
                }
            },
            defaultLeftAxisOptions: {
                labels: {
                    x: -15,
                    y: null
                },
                title: {
                    rotation: 270
                }
            },
            defaultRightAxisOptions: {
                labels: {
                    x: 15,
                    y: null
                },
                title: {
                    rotation: 90
                }
            },
            defaultBottomAxisOptions: {
                labels: {
                    autoRotation: [-45],
                    x: 0,
                    y: null
                },
                title: {
                    rotation: 0
                }
            },
            defaultTopAxisOptions: {
                labels: {
                    autoRotation: [-45],
                    x: 0,
                    y: -15
                },
                title: {
                    rotation: 0
                }
            },
            init: function (a, b) {
                var c = b.isX;
                this.chart = a;
                this.horiz = a.inverted ? !c : c;
                this.coll = (this.isXAxis = c) ? "xAxis" : "yAxis";
                this.opposite = b.opposite;
                this.side =
                b.side || (this.horiz ? this.opposite ? 0 : 2 : this.opposite ? 1 : 3);
                this.setOptions(b);
                var d = this.options,
                e = d.type;
                this.labelFormatter = d.labels.formatter || this.defaultLabelFormatter;
                this.userOptions = b;
                this.minPixelPadding = 0;
                this.reversed = d.reversed;
                this.visible = d.visible !== !1;
                this.zoomEnabled = d.zoomEnabled !== !1;
                this.categories = d.categories || e === "category";
                this.names = this.names || [];
                this.isLog = e === "logarithmic";
                this.isDatetimeAxis = e === "datetime";
                this.isLinked = q(d.linkedTo);
                this.ticks = {};
                this.labelEdge = [];
                this.minorTicks = {};
                this.plotLinesAndBands = [];
                this.alternateBands = {};
                this.len = 0;
                this.minRange = this.userMinRange = d.minRange || d.maxZoom;
                this.range = d.range;
                this.offset = d.offset || 0;
                this.stacks = {};
                this.oldStacks = {};
                this.stacksTouched = 0;
                this.min = this.max = null;
                this.crosshair = p(d.crosshair, ra(a.options.tooltip.crosshairs)[c ? 0 : 1], !1);
                var f, d = this.options.events;
                La(this, a.axes) === -1 && (c && !this.isColorAxis ? a.axes.splice(a.xAxis.length, 0, this) : a.axes.push(this), a[this.coll].push(this));
                this.series = this.series || [];
                if (a.inverted &&
                c && this.reversed === x) this.reversed = !0;
                this.removePlotLine = this.removePlotBand = this.removePlotBandOrLine;
                for (f in d) I(this, f, d[f]);
                if (this.isLog) this.val2lin = Ca, this.lin2val = ia
            },
            setOptions: function (a) {
                this.options = D(this.defaultOptions, this.isXAxis ? {} : this.defaultYAxisOptions, [this.defaultTopAxisOptions, this.defaultRightAxisOptions, this.defaultBottomAxisOptions, this.defaultLeftAxisOptions][this.side], D(S[this.coll], a))
            },
            defaultLabelFormatter: function () {
                var a = this.axis,
                b = this.value,
                c = a.categories,
                d =
                this.dateTimeLabelFormat,
                e = S.lang.numericSymbols,
                f = e && e.length,
                g, h = a.options.labels.format,
                a = a.isLog ? b : a.tickInterval;
                if (h) g = Ia(h, this);
                else if (c) g = b;
                else if (d) g = Na(d, b);
                else if (f && a >= 1E3)
                    for (; f-- && g === x; ) c = Math.pow(1E3, f + 1), a >= c && b * 10 % c === 0 && e[f] !== null && (g = B.numberFormat(b / c, -1) + e[f]);
                g === x && (g = O(b) >= 1E4 ? B.numberFormat(b, -1) : B.numberFormat(b, -1, x, ""));
                return g
            },
            getSeriesExtremes: function () {
                var a = this,
                b = a.chart;
                a.hasVisibleSeries = !1;
                a.dataMin = a.dataMax = a.threshold = null;
                a.softThreshold = !a.isXAxis;
                a.buildStacks && a.buildStacks();
                o(a.series, function (c) {
                    if (c.visible || !b.options.chart.ignoreHiddenSeries) {
                        var d = c.options,
                        e = d.threshold,
                        f;
                        a.hasVisibleSeries = !0;
                        a.isLog && e <= 0 && (e = null);
                        if (a.isXAxis) {
                            if (d = c.xData, d.length) a.dataMin = z(p(a.dataMin, d[0]), Oa(d)), a.dataMax = s(p(a.dataMax, d[0]), Da(d))
                        } else {
                            c.getExtremes();
                            f = c.dataMax;
                            c = c.dataMin;
                            if (q(c) && q(f)) a.dataMin = z(p(a.dataMin, c), c), a.dataMax = s(p(a.dataMax, f), f);
                            if (q(e)) a.threshold = e;
                            if (!d.softThreshold || a.isLog) a.softThreshold = !1
                        }
                    }
                })
            },
            translate: function (a,
            b, c, d, e, f) {
                var g = this.linkedParent || this,
                h = 1,
                i = 0,
                j = d ? g.oldTransA : g.transA,
                d = d ? g.oldMin : g.min,
                k = g.minPixelPadding,
                e = (g.doPostTranslate || g.isLog && e) && g.lin2val;
                if (!j) j = g.transA;
                if (c) h *= -1, i = g.len;
                g.reversed && (h *= -1, i -= h * (g.sector || g.len));
                b ? (a = a * h + i, a -= k, a = a / j + d, e && (a = g.lin2val(a))) : (e && (a = g.val2lin(a)), f === "between" && (f = 0.5), a = h * (a - d) * j + i + h * k + (qa(f) ? j * f * g.pointRange : 0));
                return a
            },
            toPixels: function (a, b) {
                return this.translate(a, !1, !this.horiz, null, !0) + (b ? 0 : this.pos)
            },
            toValue: function (a, b) {
                return this.translate(a -
                (b ? 0 : this.pos), !0, !this.horiz, null, !0)
            },
            getPlotLinePath: function (a, b, c, d, e) {
                var f = this.chart,
                g = this.left,
                h = this.top,
                i, j, k = c && f.oldChartHeight || f.chartHeight,
                m = c && f.oldChartWidth || f.chartWidth,
                n;
                i = this.transB;
                var l = function (a, b, c) {
                    if (a < b || a > c) d ? a = z(s(b, a), c) : n = !0;
                    return a
                },
                e = p(e, this.translate(a, null, null, c)),
                a = c = w(e + i);
                i = j = w(k - e - i);
                isNaN(e) ? n = !0 : this.horiz ? (i = h, j = k - this.bottom, a = c = l(a, g, g + this.width)) : (a = g, c = m - this.right, i = j = l(i, h, h + this.height));
                return n && !d ? null : f.renderer.crispLine(["M", a, i, "L",
                c, j
            ], b || 1)
            },
            getLinearTickPositions: function (a, b, c) {
                var d, e = ea(T(b / a) * a),
                f = ea(ta(c / a) * a),
                g = [];
                if (b === c && qa(b)) return [b];
                for (b = e; b <= f; ) {
                    g.push(b);
                    b = ea(b + a);
                    if (b === d) break;
                    d = b
                }
                return g
            },
            getMinorTickPositions: function () {
                var a = this.options,
                b = this.tickPositions,
                c = this.minorTickInterval,
                d = [],
                e, f = this.pointRangePadding || 0;
                e = this.min - f;
                var f = this.max + f,
                g = f - e;
                if (g && g / c < this.len / 3)
                    if (this.isLog) {
                        f = b.length;
                        for (e = 1; e < f; e++) d = d.concat(this.getLogTickPositions(c, b[e - 1], b[e], !0))
                    } else if (this.isDatetimeAxis && a.minorTickInterval ===
                "auto") d = d.concat(this.getTimeTicks(this.normalizeTimeTickInterval(c), e, f, a.startOfWeek));
                    else
                        for (b = e + (b[0] - e) % c; b <= f; b += c) d.push(b);
                d.length !== 0 && this.trimTicks(d, a.startOnTick, a.endOnTick);
                return d
            },
            adjustForMinRange: function () {
                var a = this.options,
                b = this.min,
                c = this.max,
                d, e = this.dataMax - this.dataMin >= this.minRange,
                f, g, h, i, j, k;
                if (this.isXAxis && this.minRange === x && !this.isLog) q(a.min) || q(a.max) ? this.minRange = null : (o(this.series, function (a) {
                    i = a.xData;
                    for (g = j = a.xIncrement ? 1 : i.length - 1; g > 0; g--)
                        if (h = i[g] -
                        i[g - 1], f === x || h < f) f = h
                    }), this.minRange = z(f * 5, this.dataMax - this.dataMin));
                    if (c - b < this.minRange) {
                        k = this.minRange;
                        d = (k - c + b) / 2;
                        d = [b - d, p(a.min, b - d)];
                        if (e) d[2] = this.dataMin;
                        b = Da(d);
                        c = [b + k, p(a.max, b + k)];
                        if (e) c[2] = this.dataMax;
                        c = Oa(c);
                        c - b < k && (d[0] = c - k, d[1] = p(a.min, c - k), b = Da(d))
                    }
                    this.min = b;
                    this.max = c
                },
                setAxisTranslation: function (a) {
                    var b = this,
                c = b.max - b.min,
                d = b.axisPointRange || 0,
                e, f = 0,
                g = 0,
                h = b.linkedParent,
                i = !!b.categories,
                j = b.transA,
                k = b.isXAxis;
                    if (k || i || d)
                        if (h ? (f = h.minPointOffset, g = h.pointRangePadding) : o(b.series,
                        function (a) {
                            var c = i ? 1 : k ? a.pointRange : b.axisPointRange || 0,
                                h = a.options.pointPlacement,
                                j = a.closestPointRange;
                            d = s(d, c);
                            b.single || (f = s(f, Ba(h) ? 0 : c / 2), g = s(g, h === "on" ? 0 : c));
                            !a.noSharedTooltip && q(j) && (e = q(e) ? z(e, j) : j)
                        }), h = b.ordinalSlope && e ? b.ordinalSlope / e : 1, b.minPointOffset = f *= h, b.pointRangePadding = g *= h, b.pointRange = z(d, c), k) b.closestPointRange = e;
                    if (a) b.oldTransA = j;
                    b.translationSlope = b.transA = j = b.len / (c + g || 1);
                    b.transB = b.horiz ? b.left : b.bottom;
                    b.minPixelPadding = j * f
                },
                minFromRange: function () {
                    return this.max -
                this.range
                },
                setTickInterval: function (a) {
                    var b = this,
                c = b.chart,
                d = b.options,
                e = b.isLog,
                f = b.isDatetimeAxis,
                g = b.isXAxis,
                h = b.isLinked,
                i = d.maxPadding,
                j = d.minPadding,
                k = d.tickInterval,
                m = d.tickPixelInterval,
                n = b.categories,
                l = b.threshold,
                u = b.softThreshold,
                r, Z, A, v;
                    !f && !n && !h && this.getTickAmount();
                    A = p(b.userMin, d.min);
                    v = p(b.userMax, d.max);
                    h ? (b.linkedParent = c[b.coll][d.linkedTo], c = b.linkedParent.getExtremes(), b.min = p(c.min, c.dataMin), b.max = p(c.max, c.dataMax), d.type !== b.linkedParent.options.type && la(11, 1)) : (!u && q(l) &&
                (b.dataMin >= l ? (r = l, j = 0) : b.dataMax <= l && (Z = l, i = 0)), b.min = p(A, r, b.dataMin), b.max = p(v, Z, b.dataMax));
                    if (e) !a && z(b.min, p(b.dataMin, b.min)) <= 0 && la(10, 1), b.min = ea(Ca(b.min), 15), b.max = ea(Ca(b.max), 15);
                    if (b.range && q(b.max)) b.userMin = b.min = A = s(b.min, b.minFromRange()), b.userMax = v = b.max, b.range = null;
                    b.beforePadding && b.beforePadding();
                    b.adjustForMinRange();
                    if (!n && !b.axisPointRange && !b.usePercentage && !h && q(b.min) && q(b.max) && (c = b.max - b.min)) !q(A) && j && (b.min -= c * j), !q(v) && i && (b.max += c * i);
                    if (qa(d.floor)) b.min = s(b.min,
                d.floor);
                    if (qa(d.ceiling)) b.max = z(b.max, d.ceiling);
                    if (u && q(b.dataMin))
                        if (l = l || 0, !q(A) && b.min < l && b.dataMin >= l) b.min = l;
                        else if (!q(v) && b.max > l && b.dataMax <= l) b.max = l;
                    b.tickInterval = b.min === b.max || b.min === void 0 || b.max === void 0 ? 1 : h && !k && m === b.linkedParent.options.tickPixelInterval ? k = b.linkedParent.tickInterval : p(k, this.tickAmount ? (b.max - b.min) / s(this.tickAmount - 1, 1) : void 0, n ? 1 : (b.max - b.min) * m / s(b.len, m));
                    g && !a && o(b.series, function (a) {
                        a.processData(b.min !== b.oldMin || b.max !== b.oldMax)
                    });
                    b.setAxisTranslation(!0);
                    b.beforeSetTickPositions && b.beforeSetTickPositions();
                    if (b.postProcessTickInterval) b.tickInterval = b.postProcessTickInterval(b.tickInterval);
                    if (b.pointRange) b.tickInterval = s(b.pointRange, b.tickInterval);
                    a = p(d.minTickInterval, b.isDatetimeAxis && b.closestPointRange);
                    if (!k && b.tickInterval < a) b.tickInterval = a;
                    if (!f && !e && !k) b.tickInterval = pb(b.tickInterval, null, ob(b.tickInterval), p(d.allowDecimals, !(b.tickInterval > 0.5 && b.tickInterval < 5 && b.max > 1E3 && b.max < 9999)), !!this.tickAmount);
                    if (!this.tickAmount && this.len) b.tickInterval =
                b.unsquish();
                    this.setTickPositions()
                },
                setTickPositions: function () {
                    var a = this.options,
                b, c = a.tickPositions,
                d = a.tickPositioner,
                e = a.startOnTick,
                f = a.endOnTick,
                g;
                    this.tickmarkOffset = this.categories && a.tickmarkPlacement === "between" && this.tickInterval === 1 ? 0.5 : 0;
                    this.minorTickInterval = a.minorTickInterval === "auto" && this.tickInterval ? this.tickInterval / 5 : a.minorTickInterval;
                    this.tickPositions = b = c && c.slice();
                    if (!b && (b = this.isDatetimeAxis ? this.getTimeTicks(this.normalizeTimeTickInterval(this.tickInterval, a.units),
                    this.min, this.max, a.startOfWeek, this.ordinalPositions, this.closestPointRange, !0) : this.isLog ? this.getLogTickPositions(this.tickInterval, this.min, this.max) : this.getLinearTickPositions(this.tickInterval, this.min, this.max), b.length > this.len && (b = [b[0], b.pop()]), this.tickPositions = b, d && (d = d.apply(this, [this.min, this.max])))) this.tickPositions = b = d;
                    if (!this.isLinked) this.trimTicks(b, e, f), this.min === this.max && q(this.min) && !this.tickAmount && (g = !0, this.min -= 0.5, this.max += 0.5), this.single = g, !c && !d && this.adjustTickAmount()
                },
                trimTicks: function (a, b, c) {
                    var d = a[0],
                e = a[a.length - 1],
                f = this.minPointOffset || 0;
                    b ? this.min = d : this.min - f > d && a.shift();
                    c ? this.max = e : this.max + f < e && a.pop();
                    a.length === 0 && q(d) && a.push((e + d) / 2)
                },
                getTickAmount: function () {
                    var a = {},
                b, c = this.options,
                d = c.tickAmount,
                e = c.tickPixelInterval;
                    !q(c.tickInterval) && this.len < e && !this.isRadial && !this.isLog && c.startOnTick && c.endOnTick && (d = 2);
                    !d && this.chart.options.chart.alignTicks !== !1 && c.alignTicks !== !1 && (o(this.chart[this.coll], function (c) {
                        var d = c.options,
                    e = c.horiz,
                    d = [e ?
                        d.left : d.top, e ? d.width : d.height, d.pane
                    ].join(",");
                        c.series.length && (a[d] ? b = !0 : a[d] = 1)
                    }), b && (d = ta(this.len / e) + 1));
                    if (d < 4) this.finalTickAmt = d, d = 5;
                    this.tickAmount = d
                },
                adjustTickAmount: function () {
                    var a = this.tickInterval,
                b = this.tickPositions,
                c = this.tickAmount,
                d = this.finalTickAmt,
                e = b && b.length;
                    if (e < c) {
                        for (; b.length < c; ) b.push(ea(b[b.length - 1] + a));
                        this.transA *= (e - 1) / (c - 1);
                        this.max = b[b.length - 1]
                    } else e > c && (this.tickInterval *= 2, this.setTickPositions());
                    if (q(d)) {
                        for (a = c = b.length; a--; ) (d === 3 && a % 2 === 1 || d <= 2 && a >
                    0 && a < c - 1) && b.splice(a, 1);
                        this.finalTickAmt = x
                    }
                },
                setScale: function () {
                    var a, b;
                    this.oldMin = this.min;
                    this.oldMax = this.max;
                    this.oldAxisLength = this.len;
                    this.setAxisSize();
                    b = this.len !== this.oldAxisLength;
                    o(this.series, function (b) {
                        if (b.isDirtyData || b.isDirty || b.xAxis.isDirty) a = !0
                    });
                    if (b || a || this.isLinked || this.forceRedraw || this.userMin !== this.oldUserMin || this.userMax !== this.oldUserMax) {
                        if (this.resetStacks && this.resetStacks(), this.forceRedraw = !1, this.getSeriesExtremes(), this.setTickInterval(), this.oldUserMin =
                    this.userMin, this.oldUserMax = this.userMax, !this.isDirty) this.isDirty = b || this.min !== this.oldMin || this.max !== this.oldMax
                    } else this.cleanStacks && this.cleanStacks()
                },
                setExtremes: function (a, b, c, d, e) {
                    var f = this,
                g = f.chart,
                c = p(c, !0);
                    o(f.series, function (a) {
                        delete a.kdTree
                    });
                    e = t(e, {
                        min: a,
                        max: b
                    });
                    J(f, "setExtremes", e, function () {
                        f.userMin = a;
                        f.userMax = b;
                        f.eventArgs = e;
                        c && g.redraw(d)
                    })
                },
                zoom: function (a, b) {
                    var c = this.dataMin,
                d = this.dataMax,
                e = this.options,
                f = z(c, p(e.min, c)),
                e = s(d, p(e.max, d));
                    this.allowZoomOutside ||
                (q(c) && a <= f && (a = f), q(d) && b >= e && (b = e));
                    this.displayBtn = a !== x || b !== x;
                    this.setExtremes(a, b, !1, x, {
                        trigger: "zoom"
                    });
                    return !0
                },
                setAxisSize: function () {
                    var a = this.chart,
                b = this.options,
                c = b.offsetLeft || 0,
                d = this.horiz,
                e = p(b.width, a.plotWidth - c + (b.offsetRight || 0)),
                f = p(b.height, a.plotHeight),
                g = p(b.top, a.plotTop),
                b = p(b.left, a.plotLeft + c),
                c = /%$/;
                    c.test(f) && (f = parseFloat(f) / 100 * a.plotHeight);
                    c.test(g) && (g = parseFloat(g) / 100 * a.plotHeight + a.plotTop);
                    this.left = b;
                    this.top = g;
                    this.width = e;
                    this.height = f;
                    this.bottom = a.chartHeight -
                f - g;
                    this.right = a.chartWidth - e - b;
                    this.len = s(d ? e : f, 0);
                    this.pos = d ? b : g
                },
                getExtremes: function () {
                    var a = this.isLog;
                    return {
                        min: a ? ea(ia(this.min)) : this.min,
                        max: a ? ea(ia(this.max)) : this.max,
                        dataMin: this.dataMin,
                        dataMax: this.dataMax,
                        userMin: this.userMin,
                        userMax: this.userMax
                    }
                },
                getThreshold: function (a) {
                    var b = this.isLog,
                c = b ? ia(this.min) : this.min,
                b = b ? ia(this.max) : this.max;
                    a === null ? a = b < 0 ? b : c : c > a ? a = c : b < a && (a = b);
                    return this.translate(a, 0, 1, 0, 1)
                },
                autoLabelAlign: function (a) {
                    a = (p(a, 0) - this.side * 90 + 720) % 360;
                    return a > 15 &&
                a < 165 ? "right" : a > 195 && a < 345 ? "left" : "center"
                },
                unsquish: function () {
                    var a = this.ticks,
                b = this.options.labels,
                c = this.horiz,
                d = this.tickInterval,
                e = d,
                f = this.len / (((this.categories ? 1 : 0) + this.max - this.min) / d),
                g, h = b.rotation,
                i = this.chart.renderer.fontMetrics(b.style.fontSize, a[0] && a[0].label),
                j, k = Number.MAX_VALUE,
                m, n = function (a) {
                    a /= f || 1;
                    a = a > 1 ? ta(a) : 1;
                    return a * d
                };
                    c ? (m = !b.staggerLines && !b.step && (q(h) ? [h] : f < p(b.autoRotationLimit, 80) && b.autoRotation)) && o(m, function (a) {
                        var b;
                        if (a === h || a && a >= -90 && a <= 90) j = n(O(i.h / aa(ga *
                    a))), b = j + O(a / 360), b < k && (k = b, g = a, e = j)
                    }) : b.step || (e = n(i.h));
                    this.autoRotation = m;
                    this.labelRotation = p(g, h);
                    return e
                },
                renderUnsquish: function () {
                    var a = this.chart,
                b = a.renderer,
                c = this.tickPositions,
                d = this.ticks,
                e = this.options.labels,
                f = this.horiz,
                g = a.margin,
                h = this.categories ? c.length : c.length - 1,
                i = this.slotWidth = f && !e.step && !e.rotation && (this.staggerLines || 1) * a.plotWidth / h || !f && (g[3] && g[3] - a.spacing[3] || a.chartWidth * 0.33),
                j = s(1, w(i - 2 * (e.padding || 5))),
                k = {},
                g = b.fontMetrics(e.style.fontSize, d[0] && d[0].label),
                h = e.style.textOverflow,
                m, n = 0;
                    if (!Ba(e.rotation)) k.rotation = e.rotation || 0;
                    if (this.autoRotation) o(c, function (a) {
                        if ((a = d[a]) && a.labelLength > n) n = a.labelLength
                    }), n > j && n > g.h ? k.rotation = this.labelRotation : this.labelRotation = 0;
                    else if (i && (m = {
                        width: j + "px"
                    }, !h)) {
                        m.textOverflow = "clip";
                        for (i = c.length; !f && i--; )
                            if (j = c[i], j = d[j].label)
                                if (j.styles.textOverflow === "ellipsis" && j.css({
                                    textOverflow: "clip"
                                }), j.getBBox().height > this.len / c.length - (g.h - g.f)) j.specCss = {
                                    textOverflow: "ellipsis"
                                }
                    }
                    if (k.rotation && (m = {
                        width: (n >
                        a.chartHeight * 0.5 ? a.chartHeight * 0.33 : a.chartHeight) + "px"
                    }, !h)) m.textOverflow = "ellipsis";
                    this.labelAlign = k.align = e.align || this.autoLabelAlign(this.labelRotation);
                    o(c, function (a) {
                        var b = (a = d[a]) && a.label;
                        if (b) b.attr(k), m && b.css(D(m, b.specCss)), delete b.specCss, a.rotation = k.rotation
                    });
                    this.tickRotCorr = b.rotCorr(g.b, this.labelRotation || 0, this.side === 2)
                },
                hasData: function () {
                    return this.hasVisibleSeries || q(this.min) && q(this.max) && !!this.tickPositions
                },
                getOffset: function () {
                    var a = this,
                b = a.chart,
                c = b.renderer,
                d = a.options,
                e = a.tickPositions,
                f = a.ticks,
                g = a.horiz,
                h = a.side,
                i = b.inverted ? [1, 0, 3, 2][h] : h,
                j, k, m = 0,
                n, l = 0,
                u = d.title,
                r = d.labels,
                Z = 0,
                A = b.axisOffset,
                b = b.clipOffset,
                v = [-1, 1, 1, -1][h],
                y, t = a.axisParent;
                    j = a.hasData();
                    a.showAxis = k = j || p(d.showEmpty, !0);
                    a.staggerLines = a.horiz && r.staggerLines;
                    if (!a.axisGroup) a.gridGroup = c.g("grid").attr({
                        zIndex: d.gridZIndex || 1
                    }).add(t), a.axisGroup = c.g("axis").attr({
                        zIndex: d.zIndex || 2
                    }).add(t), a.labelGroup = c.g("axis-labels").attr({
                        zIndex: r.zIndex || 7
                    }).addClass("highcharts-" + a.coll.toLowerCase() +
                "-labels").add(t);
                    if (j || a.isLinked) {
                        if (o(e, function (b) {
                            f[b] ? f[b].addLabel() : f[b] = new Sa(a, b)
                        }), a.renderUnsquish(), o(e, function (b) {
                            if (h === 0 || h === 2 || {
                                1: "left",
                                3: "right"
                            }[h] === a.labelAlign) Z = s(f[b].getLabelSize(), Z)
                        }), a.staggerLines) Z *= a.staggerLines, a.labelOffset = Z
                    } else
                        for (y in f) f[y].destroy(), delete f[y];
                    if (u && u.text && u.enabled !== !1) {
                        if (!a.axisTitle) a.axisTitle = c.text(u.text, 0, 0, u.useHTML).attr({
                            zIndex: 7,
                            rotation: u.rotation || 0,
                            align: u.textAlign || {
                                low: "left",
                                middle: "center",
                                high: "right"
                            }[u.align]
                        }).addClass("highcharts-" +
                    this.coll.toLowerCase() + "-title").css(u.style).add(a.axisGroup), a.axisTitle.isNew = !0;
                        if (k) m = a.axisTitle.getBBox()[g ? "height" : "width"], n = u.offset, l = q(n) ? 0 : p(u.margin, g ? 5 : 10);
                        a.axisTitle[k ? "show" : "hide"]()
                    }
                    a.offset = v * p(d.offset, A[h]);
                    a.tickRotCorr = a.tickRotCorr || {
                        x: 0,
                        y: 0
                    };
                    c = h === 2 ? a.tickRotCorr.y : 0;
                    g = Z + l + (Z && v * (g ? p(r.y, a.tickRotCorr.y + 8) : r.x) - c);
                    a.axisTitleMargin = p(n, g);
                    A[h] = s(A[h], a.axisTitleMargin + m + v * a.offset, g);
                    d = d.offset ? 0 : T(d.lineWidth / 2) * 2;
                    b[i] = s(b[i], d)
                },
                getLinePath: function (a) {
                    var b = this.chart,
                c = this.opposite,
                d = this.offset,
                e = this.horiz,
                f = this.left + (c ? this.width : 0) + d,
                d = b.chartHeight - this.bottom - (c ? this.height : 0) + d;
                    c && (a *= -1);
                    return b.renderer.crispLine(["M", e ? this.left : f, e ? d : this.top, "L", e ? b.chartWidth - this.right : f, e ? d : b.chartHeight - this.bottom], a)
                },
                getTitlePosition: function () {
                    var a = this.horiz,
                b = this.left,
                c = this.top,
                d = this.len,
                e = this.options.title,
                f = a ? b : c,
                g = this.opposite,
                h = this.offset,
                i = e.x || 0,
                j = e.y || 0,
                k = G(e.style.fontSize || 12),
                d = {
                    low: f + (a ? 0 : d),
                    middle: f + d / 2,
                    high: f + (a ? d : 0)
                }[e.align],
                b = (a ?
                    c + this.height : b) + (a ? 1 : -1) * (g ? -1 : 1) * this.axisTitleMargin + (this.side === 2 ? k : 0);
                    return {
                        x: a ? d + i : b + (g ? this.width : 0) + h + i,
                        y: a ? b + j - (g ? this.height : 0) + h : d + j
                    }
                },
                render: function () {
                    var a = this,
                b = a.chart,
                c = b.renderer,
                d = a.options,
                e = a.isLog,
                f = a.isLinked,
                g = a.tickPositions,
                h = a.axisTitle,
                i = a.ticks,
                j = a.minorTicks,
                k = a.alternateBands,
                m = d.stackLabels,
                n = d.alternateGridColor,
                l = a.tickmarkOffset,
                u = d.lineWidth,
                r, p = b.hasRendered && q(a.oldMin) && !isNaN(a.oldMin),
                A = a.showAxis,
                v = c.globalAnimation,
                y, s;
                    a.labelEdge.length = 0;
                    a.overlap = !1;
                    o([i, j, k], function (a) {
                        for (var b in a) a[b].isActive = !1
                    });
                    if (a.hasData() || f) {
                        a.minorTickInterval && !a.categories && o(a.getMinorTickPositions(), function (b) {
                            j[b] || (j[b] = new Sa(a, b, "minor"));
                            p && j[b].isNew && j[b].render(null, !0);
                            j[b].render(null, !1, 1)
                        });
                        if (g.length && (o(g, function (b, c) {
                            if (!f || b >= a.min && b <= a.max) i[b] || (i[b] = new Sa(a, b)), p && i[b].isNew && i[b].render(c, !0, 0.1), i[b].render(c)
                        }), l && (a.min === 0 || a.single))) i[-1] || (i[-1] = new Sa(a, -1, null, !0)), i[-1].render(-1);
                        n && o(g, function (b, c) {
                            s = g[c + 1] !== x ? g[c + 1] +
                        l : a.max - l;
                            if (c % 2 === 0 && b < a.max && s <= a.max - l) k[b] || (k[b] = new B.PlotLineOrBand(a)), y = b + l, k[b].options = {
                                from: e ? ia(y) : y,
                                to: e ? ia(s) : s,
                                color: n
                            }, k[b].render(), k[b].isActive = !0
                        });
                        if (!a._addedPlotLB) o((d.plotLines || []).concat(d.plotBands || []), function (b) {
                            a.addPlotBandOrLine(b)
                        }), a._addedPlotLB = !0
                    }
                    o([i, j, k], function (a) {
                        var c, d, e = [],
                    f = v ? v.duration || 500 : 0,
                    g = function () {
                        for (d = e.length; d--; ) a[e[d]] && !a[e[d]].isActive && (a[e[d]].destroy(), delete a[e[d]])
                    };
                        for (c in a)
                            if (!a[c].isActive) a[c].render(c, !1, 0), a[c].isActive = !1, e.push(c);
                        a === k || !b.hasRendered || !f ? g() : f && setTimeout(g, f)
                    });
                    if (u) r = a.getLinePath(u), a.axisLine ? a.axisLine.animate({
                        d: r
                    }) : a.axisLine = c.path(r).attr({
                        stroke: d.lineColor,
                        "stroke-width": u,
                        zIndex: 7
                    }).add(a.axisGroup), a.axisLine[A ? "show" : "hide"]();
                    if (h && A) h[h.isNew ? "attr" : "animate"](a.getTitlePosition()), h.isNew = !1;
                    m && m.enabled && a.renderStackTotals();
                    a.isDirty = !1
                },
                redraw: function () {
                    this.visible && (this.render(), o(this.plotLinesAndBands, function (a) {
                        a.render()
                    }));
                    o(this.series, function (a) {
                        a.isDirty = !0
                    })
                },
                destroy: function (a) {
                    var b = this,
                c = b.stacks,
                d, e = b.plotLinesAndBands;
                    a || Y(b);
                    for (d in c) Pa(c[d]), c[d] = null;
                    o([b.ticks, b.minorTicks, b.alternateBands], function (a) {
                        Pa(a)
                    });
                    for (a = e.length; a--; ) e[a].destroy();
                    o("stackTotalGroup,axisLine,axisTitle,axisGroup,cross,gridGroup,labelGroup".split(","), function (a) {
                        b[a] && (b[a] = b[a].destroy())
                    });
                    this.cross && this.cross.destroy()
                },
                drawCrosshair: function (a, b) {
                    var c, d = this.crosshair,
                e = d.animation;
                    if (!this.crosshair || (q(b) || !p(this.crosshair.snap, !0)) === !1 || b && b.series &&
                b.series[this.coll] !== this) this.hideCrosshair();
                    else if (p(d.snap, !0) ? q(b) && (c = this.isXAxis ? b.plotX : this.len - b.plotY) : c = this.horiz ? a.chartX - this.pos : this.len - a.chartY + this.pos, c = this.isRadial ? this.getPlotLinePath(this.isXAxis ? b.x : p(b.stackY, b.y)) || null : this.getPlotLinePath(null, null, null, null, c) || null, c === null) this.hideCrosshair();
                    else if (this.cross) this.cross.attr({
                        visibility: "visible"
                    })[e ? "animate" : "attr"]({
                        d: c
                    }, e);
                    else {
                        e = this.categories && !this.isRadial;
                        e = {
                            "stroke-width": d.width || (e ? this.transA :
                        1),
                            stroke: d.color || (e ? "rgba(155,200,255,0.2)" : "#C0C0C0"),
                            zIndex: d.zIndex || 2
                        };
                        if (d.dashStyle) e.dashstyle = d.dashStyle;
                        this.cross = this.chart.renderer.path(c).attr(e).add()
                    }
                },
                hideCrosshair: function () {
                    this.cross && this.cross.hide()
                }
            };
            t(ha.prototype, {
                getPlotBandPath: function (a, b) {
                    var c = this.getPlotLinePath(b, null, null, !0),
                d = this.getPlotLinePath(a, null, null, !0);
                    d && c && d.toString() !== c.toString() ? d.push(c[4], c[5], c[1], c[2]) : d = null;
                    return d
                },
                addPlotBand: function (a) {
                    return this.addPlotBandOrLine(a, "plotBands")
                },
                addPlotLine: function (a) {
                    return this.addPlotBandOrLine(a, "plotLines")
                },
                addPlotBandOrLine: function (a, b) {
                    var c = (new B.PlotLineOrBand(this, a)).render(),
                d = this.userOptions;
                    c && (b && (d[b] = d[b] || [], d[b].push(a)), this.plotLinesAndBands.push(c));
                    return c
                },
                removePlotBandOrLine: function (a) {
                    for (var b = this.plotLinesAndBands, c = this.options, d = this.userOptions, e = b.length; e--; ) b[e].id === a && b[e].destroy();
                    o([c.plotLines || [], d.plotLines || [], c.plotBands || [], d.plotBands || []], function (b) {
                        for (e = b.length; e--; ) b[e].id === a &&
                    ja(b, b[e])
                    })
                }
            });
            ha.prototype.getTimeTicks = function (a, b, c, d) {
                var e = [],
            f = {},
            g = S.global.useUTC,
            h, i = new ya(b - Wa(b)),
            j = a.unitRange,
            k = a.count;
                if (q(b)) {
                    i[Db](j >= F.second ? 0 : k * T(i.getMilliseconds() / k));
                    if (j >= F.second) i[Eb](j >= F.minute ? 0 : k * T(i.getSeconds() / k));
                    if (j >= F.minute) i[Fb](j >= F.hour ? 0 : k * T(i[rb]() / k));
                    if (j >= F.hour) i[Gb](j >= F.day ? 0 : k * T(i[sb]() / k));
                    if (j >= F.day) i[ub](j >= F.month ? 1 : k * T(i[Xa]() / k));
                    j >= F.month && (i[vb](j >= F.year ? 0 : k * T(i[Ya]() / k)), h = i[Za]());
                    j >= F.year && (h -= h % k, i[wb](h));
                    if (j === F.week) i[ub](i[Xa]() -
                i[tb]() + p(d, 1));
                    b = 1;
                    if (nb || db) i = i.getTime(), i = new ya(i + Wa(i));
                    h = i[Za]();
                    for (var d = i.getTime(), m = i[Ya](), n = i[Xa](), l = (F.day + (g ? Wa(i) : i.getTimezoneOffset() * 6E4)) % F.day; d < c; ) e.push(d), j === F.year ? d = fb(h + b * k, 0) : j === F.month ? d = fb(h, m + b * k) : !g && (j === F.day || j === F.week) ? d = fb(h, m, n + b * k * (j === F.day ? 1 : 7)) : d += j * k, b++;
                    e.push(d);
                    o(kb(e, function (a) {
                        return j <= F.hour && a % F.day === l
                    }), function (a) {
                        f[a] = "day"
                    })
                }
                e.info = t(a, {
                    higherRanks: f,
                    totalRange: j * k
                });
                return e
            };
            ha.prototype.normalizeTimeTickInterval = function (a, b) {
                var c =
            b || [
                ["millisecond", [1, 2, 5, 10, 20, 25, 50, 100, 200, 500]],
                ["second", [1, 2, 5, 10, 15, 30]],
                ["minute", [1, 2, 5, 10, 15, 30]],
                ["hour", [1, 2, 3, 4, 6, 8, 12]],
                ["day", [1, 2]],
                ["week", [1, 2]],
                ["month", [1, 2, 3, 4, 6]],
                ["year", null]
            ],
            d = c[c.length - 1],
            e = F[d[0]],
            f = d[1],
            g;
                for (g = 0; g < c.length; g++)
                    if (d = c[g], e = F[d[0]], f = d[1], c[g + 1] && a <= (e * f[f.length - 1] + F[c[g + 1][0]]) / 2) break;
                e === F.year && a < 5 * e && (f = [1, 2, 5]);
                c = pb(a / e, f, d[0] === "year" ? s(ob(a / e), 1) : 1);
                return {
                    unitRange: e,
                    count: c,
                    unitName: d[0]
                }
            };
            ha.prototype.getLogTickPositions = function (a, b, c, d) {
                var e =
            this.options,
            f = this.len,
            g = [];
                if (!d) this._minorAutoInterval = null;
                if (a >= 0.5) a = w(a), g = this.getLinearTickPositions(a, b, c);
                else if (a >= 0.08)
                    for (var f = T(b), h, i, j, k, m, e = a > 0.3 ? [1, 2, 4] : a > 0.15 ? [1, 2, 4, 6, 8] : [1, 2, 3, 4, 5, 6, 7, 8, 9]; f < c + 1 && !m; f++) {
                        i = e.length;
                        for (h = 0; h < i && !m; h++) j = Ca(ia(f) * e[h]), j > b && (!d || k <= c) && k !== x && g.push(k), k > c && (m = !0), k = j
                    } else if (b = ia(b), c = ia(c), a = e[d ? "minorTickInterval" : "tickInterval"], a = p(a === "auto" ? null : a, this._minorAutoInterval, (c - b) * (e.tickPixelInterval / (d ? 5 : 1)) / ((d ? f / this.tickPositions.length :
                    f) || 1)), a = pb(a, null, ob(a)), g = Ua(this.getLinearTickPositions(a, b, c), Ca), !d) this._minorAutoInterval = a / 5;
                if (!d) this.tickInterval = a;
                return g
            };
            var Mb = B.Tooltip = function () {
                this.init.apply(this, arguments)
            };
            Mb.prototype = {
                init: function (a, b) {
                    var c = b.borderWidth,
                d = b.style,
                e = G(d.padding);
                    this.chart = a;
                    this.options = b;
                    this.crosshairs = [];
                    this.now = {
                        x: 0,
                        y: 0
                    };
                    this.isHidden = !0;
                    this.label = a.renderer.label("", 0, 0, b.shape || "callout", null, null, b.useHTML, null, "tooltip").attr({
                        padding: e,
                        fill: b.backgroundColor,
                        "stroke-width": c,
                        r: b.borderRadius,
                        zIndex: 8
                    }).css(d).css({
                        padding: 0
                    }).add().attr({
                        y: -9999
                    });
                    fa || this.label.shadow(b.shadow);
                    this.shared = b.shared
                },
                destroy: function () {
                    if (this.label) this.label = this.label.destroy();
                    clearTimeout(this.hideTimer);
                    clearTimeout(this.tooltipTimeout)
                },
                move: function (a, b, c, d) {
                    var e = this,
                f = e.now,
                g = e.options.animation !== !1 && !e.isHidden && (O(a - f.x) > 1 || O(b - f.y) > 1),
                h = e.followPointer || e.len > 1;
                    t(f, {
                        x: g ? (2 * f.x + a) / 3 : a,
                        y: g ? (f.y + b) / 2 : b,
                        anchorX: h ? x : g ? (2 * f.anchorX + c) / 3 : c,
                        anchorY: h ? x : g ? (f.anchorY + d) / 2 : d
                    });
                    e.label.attr(f);
                    if (g) clearTimeout(this.tooltipTimeout), this.tooltipTimeout = setTimeout(function () {
                        e && e.move(a, b, c, d)
                    }, 32)
                },
                hide: function (a) {
                    var b = this;
                    clearTimeout(this.hideTimer);
                    if (!this.isHidden) this.hideTimer = setTimeout(function () {
                        b.label.fadeOut();
                        b.isHidden = !0
                    }, p(a, this.options.hideDelay, 500))
                },
                getAnchor: function (a, b) {
                    var c, d = this.chart,
                e = d.inverted,
                f = d.plotTop,
                g = d.plotLeft,
                h = 0,
                i = 0,
                j, k, a = ra(a);
                    c = a[0].tooltipPos;
                    this.followPointer && b && (b.chartX === x && (b = d.pointer.normalize(b)), c = [b.chartX - d.plotLeft, b.chartY -
                f
            ]);
                    c || (o(a, function (a) {
                        j = a.series.yAxis;
                        k = a.series.xAxis;
                        h += a.plotX + (!e && k ? k.left - g : 0);
                        i += (a.plotLow ? (a.plotLow + a.plotHigh) / 2 : a.plotY) + (!e && j ? j.top - f : 0)
                    }), h /= a.length, i /= a.length, c = [e ? d.plotWidth - i : h, this.shared && !e && a.length > 1 && b ? b.chartY - f : e ? d.plotHeight - h : i]);
                    return Ua(c, w)
                },
                getPosition: function (a, b, c) {
                    var d = this.chart,
                e = this.distance,
                f = {},
                g = c.h || 0,
                h, i = ["y", d.chartHeight, b, c.plotY + d.plotTop, d.plotTop, d.plotTop + d.plotHeight],
                j = ["x", d.chartWidth, a, c.plotX + d.plotLeft, d.plotLeft, d.plotLeft + d.plotWidth],
                k = p(c.ttBelow, d.inverted && !c.negative || !d.inverted && c.negative),
                m = function (a, b, c, d, h, i) {
                    var j = c < d - e,
                        n = d + e + c < b,
                        m = d - e - c;
                    d += e;
                    if (k && n) f[a] = d;
                    else if (!k && j) f[a] = m;
                    else if (j) f[a] = z(i - c, m - g < 0 ? m : m - g);
                    else if (n) f[a] = s(h, d + g + c > b ? d : d + g);
                    else return !1
                },
                n = function (a, b, c, d) {
                    if (d < e || d > b - e) return !1;
                    else f[a] = d < c / 2 ? 1 : d > b - c / 2 ? b - c - 2 : d - c / 2
                },
                l = function (a) {
                    var b = i;
                    i = j;
                    j = b;
                    h = a
                },
                u = function () {
                    m.apply(0, i) !== !1 ? n.apply(0, j) === !1 && !h && (l(!0), u()) : h ? f.x = f.y = 0 : (l(!0), u())
                };
                    (d.inverted || this.len > 1) && l();
                    u();
                    return f
                },
                defaultFormatter: function (a) {
                    var b =
                this.points || ra(this),
                c;
                    c = [a.tooltipFooterHeaderFormatter(b[0])];
                    c = c.concat(a.bodyFormatter(b));
                    c.push(a.tooltipFooterHeaderFormatter(b[0], !0));
                    return c.join("")
                },
                refresh: function (a, b) {
                    var c = this.chart,
                d = this.label,
                e = this.options,
                f, g, h, i = {},
                j, k = [];
                    j = e.formatter || this.defaultFormatter;
                    var i = c.hoverPoints,
                m, n = this.shared;
                    clearTimeout(this.hideTimer);
                    this.followPointer = ra(a)[0].series.tooltipOptions.followPointer;
                    h = this.getAnchor(a, b);
                    f = h[0];
                    g = h[1];
                    n && (!a.series || !a.series.noSharedTooltip) ? (c.hoverPoints =
                a, i && o(i, function (a) {
                    a.setState()
                }), o(a, function (a) {
                    a.setState("hover");
                    k.push(a.getLabelConfig())
                }), i = {
                    x: a[0].category,
                    y: a[0].y
                }, i.points = k, this.len = k.length, a = a[0]) : i = a.getLabelConfig();
                    j = j.call(i, this);
                    i = a.series;
                    this.distance = p(i.tooltipOptions.distance, 16);
                    j === !1 ? this.hide() : (this.isHidden && (cb(d), d.attr("opacity", 1).show()), d.attr({
                        text: j
                    }), m = e.borderColor || a.color || i.color || "#606060", d.attr({
                        stroke: m
                    }), this.updatePosition({
                        plotX: f,
                        plotY: g,
                        negative: a.negative,
                        ttBelow: a.ttBelow,
                        h: h[2] || 0
                    }), this.isHidden = !1);
                    J(c, "tooltipRefresh", {
                        text: j,
                        x: f + c.plotLeft,
                        y: g + c.plotTop,
                        borderColor: m
                    })
                },
                updatePosition: function (a) {
                    var b = this.chart,
                c = this.label,
                c = (this.options.positioner || this.getPosition).call(this, c.width, c.height, a);
                    this.move(w(c.x), w(c.y || 0), a.plotX + b.plotLeft, a.plotY + b.plotTop)
                },
                getXDateFormat: function (a, b, c) {
                    var d, b = b.dateTimeLabelFormats,
                e = c && c.closestPointRange,
                f, g = {
                    millisecond: 15,
                    second: 12,
                    minute: 9,
                    hour: 6,
                    day: 3
                },
                h, i = "millisecond";
                    if (e) {
                        h = Na("%m-%d %H:%M:%S.%L", a.x);
                        for (f in F) {
                            if (e === F.week && +Na("%w",
                            a.x) === c.options.startOfWeek && h.substr(6) === "00:00:00.000") {
                                f = "week";
                                break
                            } else if (F[f] > e) {
                                f = i;
                                break
                            } else if (g[f] && h.substr(g[f]) !== "01-01 00:00:00.000".substr(g[f])) break;
                            f !== "week" && (i = f)
                        }
                        f && (d = b[f])
                    } else d = b.day;
                    return d || b.year
                },
                tooltipFooterHeaderFormatter: function (a, b) {
                    var c = b ? "footer" : "header",
                d = a.series,
                e = d.tooltipOptions,
                f = e.xDateFormat,
                g = d.xAxis,
                h = g && g.options.type === "datetime" && qa(a.key),
                c = e[c + "Format"];
                    h && !f && (f = this.getXDateFormat(a, e, g));
                    h && f && (c = c.replace("{point.key}", "{point.key:" +
                f + "}"));
                    return Ia(c, {
                        point: a,
                        series: d
                    })
                },
                bodyFormatter: function (a) {
                    return Ua(a, function (a) {
                        var c = a.series.tooltipOptions;
                        return (c.pointFormatter || a.point.tooltipFormatter).call(a.point, c.pointFormat)
                    })
                }
            };
            var oa;
            ab = C.documentElement.ontouchstart !== x;
            var Va = B.Pointer = function (a, b) {
                this.init(a, b)
            };
            Va.prototype = {
                init: function (a, b) {
                    var c = b.chart,
                d = c.events,
                e = fa ? "" : c.zoomType,
                c = a.inverted,
                f;
                    this.options = b;
                    this.chart = a;
                    this.zoomX = f = /x/.test(e);
                    this.zoomY = e = /y/.test(e);
                    this.zoomHor = f && !c || e && c;
                    this.zoomVert =
                e && !c || f && c;
                    this.hasZoom = f || e;
                    this.runChartClick = d && !!d.click;
                    this.pinchDown = [];
                    this.lastValidTouch = {};
                    if (B.Tooltip && b.tooltip.enabled) a.tooltip = new Mb(a, b.tooltip), this.followTouchMove = p(b.tooltip.followTouchMove, !0);
                    this.setDOMEvents()
                },
                normalize: function (a, b) {
                    var c, d, a = a || window.event,
                a = Sb(a);
                    if (!a.target) a.target = a.srcElement;
                    d = a.touches ? a.touches.length ? a.touches.item(0) : a.changedTouches[0] : a;
                    if (!b) this.chartPosition = b = Rb(this.chart.container);
                    d.pageX === x ? (c = s(a.x, a.clientX - b.left), d = a.y) : (c =
                d.pageX - b.left, d = d.pageY - b.top);
                    return t(a, {
                        chartX: w(c),
                        chartY: w(d)
                    })
                },
                getCoordinates: function (a) {
                    var b = {
                        xAxis: [],
                        yAxis: []
                    };
                    o(this.chart.axes, function (c) {
                        b[c.isXAxis ? "xAxis" : "yAxis"].push({
                            axis: c,
                            value: c.toValue(a[c.horiz ? "chartX" : "chartY"])
                        })
                    });
                    return b
                },
                runPointActions: function (a) {
                    var b = this.chart,
                c = b.series,
                d = b.tooltip,
                e = d ? d.shared : !1,
                f = b.hoverPoint,
                g = b.hoverSeries,
                h, i = Number.MAX_VALUE,
                j, k, m = [],
                n, l;
                    if (!e && !g)
                        for (h = 0; h < c.length; h++)
                            if (c[h].directTouch || !c[h].options.stickyTracking) c = [];
                    g && (e ? g.noSharedTooltip :
                g.directTouch) && f ? n = f : (o(c, function (b) {
                    j = b.noSharedTooltip && e;
                    k = !e && b.directTouch;
                    b.visible && !j && !k && p(b.options.enableMouseTracking, !0) && (l = b.searchPoint(a, !j && b.kdDimensions === 1)) && m.push(l)
                }), o(m, function (a) {
                    if (a && typeof a.dist === "number" && a.dist < i) i = a.dist, n = a
                }));
                    if (n && (n !== this.prevKDPoint || d && d.isHidden)) {
                        if (e && !n.series.noSharedTooltip) {
                            for (h = m.length; h--; ) (m[h].clientX !== n.clientX || m[h].series.noSharedTooltip) && m.splice(h, 1);
                            m.length && d && d.refresh(m, a);
                            o(m, function (b) {
                                b.onMouseOver(a, b !==
                            (g && g.directTouch && f || n))
                            })
                        } else if (d && d.refresh(n, a), !g || !g.directTouch) n.onMouseOver(a);
                        this.prevKDPoint = n
                    } else c = g && g.tooltipOptions.followPointer, d && c && !d.isHidden && (c = d.getAnchor([{}], a), d.updatePosition({
                        plotX: c[0],
                        plotY: c[1]
                    }));
                    if (d && !this._onDocumentMouseMove) this._onDocumentMouseMove = function (a) {
                        if (X[oa]) X[oa].pointer.onDocumentMouseMove(a)
                    }, I(C, "mousemove", this._onDocumentMouseMove);
                    o(b.axes, function (b) {
                        b.drawCrosshair(a, p(n, f))
                    })
                },
                reset: function (a, b) {
                    var c = this.chart,
                d = c.hoverSeries,
                e =
                c.hoverPoint,
                f = c.hoverPoints,
                g = c.tooltip,
                h = g && g.shared ? f : e;
                    (a = a && g && h) && ra(h)[0].plotX === x && (a = !1);
                    if (a) g.refresh(h), e && (e.setState(e.state, !0), o(c.axes, function (a) {
                        p(a.options.crosshair && a.options.crosshair.snap, !0) ? a.drawCrosshair(null, e) : a.hideCrosshair()
                    }));
                    else {
                        if (e) e.onMouseOut();
                        f && o(f, function (a) {
                            a.setState()
                        });
                        if (d) d.onMouseOut();
                        g && g.hide(b);
                        if (this._onDocumentMouseMove) Y(C, "mousemove", this._onDocumentMouseMove), this._onDocumentMouseMove = null;
                        o(c.axes, function (a) {
                            a.hideCrosshair()
                        });
                        this.hoverX =
                    c.hoverPoints = c.hoverPoint = null
                    }
                },
                scaleGroups: function (a, b) {
                    var c = this.chart,
                d;
                    o(c.series, function (e) {
                        d = a || e.getPlotBox();
                        e.xAxis && e.xAxis.zoomEnabled && (e.group.attr(d), e.markerGroup && (e.markerGroup.attr(d), e.markerGroup.clip(b ? c.clipRect : null)), e.dataLabelsGroup && e.dataLabelsGroup.attr(d))
                    });
                    c.clipRect.attr(b || c.clipBox)
                },
                dragStart: function (a) {
                    var b = this.chart;
                    b.mouseIsDown = a.type;
                    b.cancelClick = !1;
                    b.mouseDownX = this.mouseDownX = a.chartX;
                    b.mouseDownY = this.mouseDownY = a.chartY
                },
                drag: function (a) {
                    var b =
                this.chart,
                c = b.options.chart,
                d = a.chartX,
                e = a.chartY,
                f = this.zoomHor,
                g = this.zoomVert,
                h = b.plotLeft,
                i = b.plotTop,
                j = b.plotWidth,
                k = b.plotHeight,
                m, n = this.selectionMarker,
                l = this.mouseDownX,
                u = this.mouseDownY,
                r = c.panKey && a[c.panKey + "Key"];
                    if (!n || !n.touch)
                        if (d < h ? d = h : d > h + j && (d = h + j), e < i ? e = i : e > i + k && (e = i + k), this.hasDragged = Math.sqrt(Math.pow(l - d, 2) + Math.pow(u - e, 2)), this.hasDragged > 10) {
                            m = b.isInsidePlot(l - h, u - i);
                            if (b.hasCartesianSeries && (this.zoomX || this.zoomY) && m && !r && !n) this.selectionMarker = n = b.renderer.rect(h, i,
                        f ? 1 : j, g ? 1 : k, 0).attr({
                            fill: c.selectionMarkerFill || "rgba(69,114,167,0.25)",
                            zIndex: 7
                        }).add();
                            n && f && (d -= l, n.attr({
                                width: O(d),
                                x: (d > 0 ? 0 : d) + l
                            }));
                            n && g && (d = e - u, n.attr({
                                height: O(d),
                                y: (d > 0 ? 0 : d) + u
                            }));
                            m && !n && c.panning && b.pan(a, c.panning)
                        }
                },
                drop: function (a) {
                    var b = this,
                c = this.chart,
                d = this.hasPinched;
                    if (this.selectionMarker) {
                        var e = {
                            xAxis: [],
                            yAxis: [],
                            originalEvent: a.originalEvent || a
                        },
                    f = this.selectionMarker,
                    g = f.attr ? f.attr("x") : f.x,
                    h = f.attr ? f.attr("y") : f.y,
                    i = f.attr ? f.attr("width") : f.width,
                    j = f.attr ? f.attr("height") :
                    f.height,
                    k;
                        if (this.hasDragged || d) o(c.axes, function (c) {
                            if (c.zoomEnabled && q(c.min) && (d || b[{
                                xAxis: "zoomX",
                                yAxis: "zoomY"
                            }[c.coll]])) {
                                var f = c.horiz,
                            l = a.type === "touchend" ? c.minPixelPadding : 0,
                            u = c.toValue((f ? g : h) + l),
                            f = c.toValue((f ? g + i : h + j) - l);
                                e[c.coll].push({
                                    axis: c,
                                    min: z(u, f),
                                    max: s(u, f)
                                });
                                k = !0
                            }
                        }), k && J(c, "selection", e, function (a) {
                            c.zoom(t(a, d ? {
                                animation: !1
                            } : null))
                        });
                        this.selectionMarker = this.selectionMarker.destroy();
                        d && this.scaleGroups()
                    }
                    if (c) M(c.container, {
                        cursor: c._cursor
                    }), c.cancelClick = this.hasDragged >
                10, c.mouseIsDown = this.hasDragged = this.hasPinched = !1, this.pinchDown = []
                },
                onContainerMouseDown: function (a) {
                    a = this.normalize(a);
                    a.preventDefault && a.preventDefault();
                    this.dragStart(a)
                },
                onDocumentMouseUp: function (a) {
                    X[oa] && X[oa].pointer.drop(a)
                },
                onDocumentMouseMove: function (a) {
                    var b = this.chart,
                c = this.chartPosition,
                a = this.normalize(a, c);
                    c && !this.inClass(a.target, "highcharts-tracker") && !b.isInsidePlot(a.chartX - b.plotLeft, a.chartY - b.plotTop) && this.reset()
                },
                onContainerMouseLeave: function () {
                    var a = X[oa];
                    if (a) a.pointer.reset(),
                a.pointer.chartPosition = null
                },
                onContainerMouseMove: function (a) {
                    var b = this.chart;
                    oa = b.index;
                    a = this.normalize(a);
                    a.returnValue = !1;
                    b.mouseIsDown === "mousedown" && this.drag(a);
                    (this.inClass(a.target, "highcharts-tracker") || b.isInsidePlot(a.chartX - b.plotLeft, a.chartY - b.plotTop)) && !b.openMenu && this.runPointActions(a)
                },
                inClass: function (a, b) {
                    for (var c; a; ) {
                        if (c = K(a, "class"))
                            if (c.indexOf(b) !== -1) return !0;
                            else if (c.indexOf("highcharts-container") !== -1) return !1;
                        a = a.parentNode
                    }
                },
                onTrackerMouseOut: function (a) {
                    var b =
                this.chart.hoverSeries,
                a = a.relatedTarget || a.toElement;
                    if (b && !b.options.stickyTracking && !this.inClass(a, "highcharts-tooltip") && !this.inClass(a, "highcharts-series-" + b.index)) b.onMouseOut()
                },
                onContainerClick: function (a) {
                    var b = this.chart,
                c = b.hoverPoint,
                d = b.plotLeft,
                e = b.plotTop,
                a = this.normalize(a);
                    a.originalEvent = a;
                    b.cancelClick || (c && this.inClass(a.target, "highcharts-tracker") ? (J(c.series, "click", t(a, {
                        point: c
                    })), b.hoverPoint && c.firePointEvent("click", a)) : (t(a, this.getCoordinates(a)), b.isInsidePlot(a.chartX -
                d, a.chartY - e) && J(b, "click", a)))
                },
                setDOMEvents: function () {
                    var a = this,
                b = a.chart.container;
                    b.onmousedown = function (b) {
                        a.onContainerMouseDown(b)
                    };
                    b.onmousemove = function (b) {
                        a.onContainerMouseMove(b)
                    };
                    b.onclick = function (b) {
                        a.onContainerClick(b)
                    };
                    I(b, "mouseleave", a.onContainerMouseLeave);
                    bb === 1 && I(C, "mouseup", a.onDocumentMouseUp);
                    if (ab) b.ontouchstart = function (b) {
                        a.onContainerTouchStart(b)
                    }, b.ontouchmove = function (b) {
                        a.onContainerTouchMove(b)
                    }, bb === 1 && I(C, "touchend", a.onDocumentTouchEnd)
                },
                destroy: function () {
                    var a;
                    Y(this.chart.container, "mouseleave", this.onContainerMouseLeave);
                    bb || (Y(C, "mouseup", this.onDocumentMouseUp), Y(C, "touchend", this.onDocumentTouchEnd));
                    clearInterval(this.tooltipTimeout);
                    for (a in this) this[a] = null
                }
            };
            t(B.Pointer.prototype, {
                pinchTranslate: function (a, b, c, d, e, f) {
                    (this.zoomHor || this.pinchHor) && this.pinchTranslateDirection(!0, a, b, c, d, e, f);
                    (this.zoomVert || this.pinchVert) && this.pinchTranslateDirection(!1, a, b, c, d, e, f)
                },
                pinchTranslateDirection: function (a, b, c, d, e, f, g, h) {
                    var i = this.chart,
                j = a ? "x" :
                "y",
                k = a ? "X" : "Y",
                m = "chart" + k,
                n = a ? "width" : "height",
                l = i["plot" + (a ? "Left" : "Top")],
                u, r, p = h || 1,
                o = i.inverted,
                v = i.bounds[a ? "h" : "v"],
                s = b.length === 1,
                q = b[0][m],
                t = c[0][m],
                x = !s && b[1][m],
                w = !s && c[1][m],
                z, c = function () {
                    !s && O(q - x) > 20 && (p = h || O(t - w) / O(q - x));
                    r = (l - t) / p + q;
                    u = i["plot" + (a ? "Width" : "Height")] / p
                };
                    c();
                    b = r;
                    b < v.min ? (b = v.min, z = !0) : b + u > v.max && (b = v.max - u, z = !0);
                    z ? (t -= 0.8 * (t - g[j][0]), s || (w -= 0.8 * (w - g[j][1])), c()) : g[j] = [t, w];
                    o || (f[j] = r - l, f[n] = u);
                    f = o ? 1 / p : p;
                    e[n] = u;
                    e[j] = b;
                    d[o ? a ? "scaleY" : "scaleX" : "scale" + k] = p;
                    d["translate" +
                k] = f * l + (t - f * q)
                },
                pinch: function (a) {
                    var b = this,
                c = b.chart,
                d = b.pinchDown,
                e = a.touches,
                f = e.length,
                g = b.lastValidTouch,
                h = b.hasZoom,
                i = b.selectionMarker,
                j = {},
                k = f === 1 && (b.inClass(a.target, "highcharts-tracker") && c.runTrackerClick || b.runChartClick),
                m = {};
                    if (f > 1) b.initiated = !0;
                    h && b.initiated && !k && a.preventDefault();
                    Ua(e, function (a) {
                        return b.normalize(a)
                    });
                    if (a.type === "touchstart") o(e, function (a, b) {
                        d[b] = {
                            chartX: a.chartX,
                            chartY: a.chartY
                        }
                    }), g.x = [d[0].chartX, d[1] && d[1].chartX], g.y = [d[0].chartY, d[1] && d[1].chartY], o(c.axes,
                function (a) {
                    if (a.zoomEnabled) {
                        var b = c.bounds[a.horiz ? "h" : "v"],
                            d = a.minPixelPadding,
                            e = a.toPixels(p(a.options.min, a.dataMin)),
                            f = a.toPixels(p(a.options.max, a.dataMax)),
                            g = z(e, f),
                            e = s(e, f);
                        b.min = z(a.pos, g - d);
                        b.max = s(a.pos + a.len, e + d)
                    }
                }), b.res = !0;
                    else if (d.length) {
                        if (!i) b.selectionMarker = i = t({
                            destroy: ua,
                            touch: !0
                        }, c.plotBox);
                        b.pinchTranslate(d, e, j, i, m, g);
                        b.hasPinched = h;
                        b.scaleGroups(j, m);
                        if (!h && b.followTouchMove && f === 1) this.runPointActions(b.normalize(a));
                        else if (b.res) b.res = !1, this.reset(!1, 0)
                    }
                },
                touch: function (a,
            b) {
                    var c = this.chart;
                    oa = c.index;
                    a.touches.length === 1 ? (a = this.normalize(a), c.isInsidePlot(a.chartX - c.plotLeft, a.chartY - c.plotTop) && !c.openMenu ? (b && this.runPointActions(a), this.pinch(a)) : b && this.reset()) : a.touches.length === 2 && this.pinch(a)
                },
                onContainerTouchStart: function (a) {
                    this.touch(a, !0)
                },
                onContainerTouchMove: function (a) {
                    this.touch(a)
                },
                onDocumentTouchEnd: function (a) {
                    X[oa] && X[oa].pointer.drop(a)
                }
            });
            if (L.PointerEvent || L.MSPointerEvent) {
                var wa = {},
            Ab = !!L.PointerEvent,
            Wb = function () {
                var a, b = [];
                b.item = function (a) {
                    return this[a]
                };
                for (a in wa) wa.hasOwnProperty(a) && b.push({
                    pageX: wa[a].pageX,
                    pageY: wa[a].pageY,
                    target: wa[a].target
                });
                return b
            },
            Bb = function (a, b, c, d) {
                a = a.originalEvent || a;
                if ((a.pointerType === "touch" || a.pointerType === a.MSPOINTER_TYPE_TOUCH) && X[oa]) d(a), d = X[oa].pointer, d[b]({
                    type: c,
                    target: a.currentTarget,
                    preventDefault: ua,
                    touches: Wb()
                })
            };
                t(Va.prototype, {
                    onContainerPointerDown: function (a) {
                        Bb(a, "onContainerTouchStart", "touchstart", function (a) {
                            wa[a.pointerId] = {
                                pageX: a.pageX,
                                pageY: a.pageY,
                                target: a.currentTarget
                            }
                        })
                    },
                    onContainerPointerMove: function (a) {
                        Bb(a,
                    "onContainerTouchMove", "touchmove",
                    function (a) {
                        wa[a.pointerId] = {
                            pageX: a.pageX,
                            pageY: a.pageY
                        };
                        if (!wa[a.pointerId].target) wa[a.pointerId].target = a.currentTarget
                    })
                    },
                    onDocumentPointerUp: function (a) {
                        Bb(a, "onDocumentTouchEnd", "touchend", function (a) {
                            delete wa[a.pointerId]
                        })
                    },
                    batchMSEvents: function (a) {
                        a(this.chart.container, Ab ? "pointerdown" : "MSPointerDown", this.onContainerPointerDown);
                        a(this.chart.container, Ab ? "pointermove" : "MSPointerMove", this.onContainerPointerMove);
                        a(C, Ab ? "pointerup" : "MSPointerUp", this.onDocumentPointerUp)
                    }
                });
                Ta(Va.prototype, "init", function (a, b, c) {
                    a.call(this, b, c);
                    this.hasZoom && M(b.container, {
                        "-ms-touch-action": P,
                        "touch-action": P
                    })
                });
                Ta(Va.prototype, "setDOMEvents", function (a) {
                    a.apply(this);
                    (this.hasZoom || this.followTouchMove) && this.batchMSEvents(I)
                });
                Ta(Va.prototype, "destroy", function (a) {
                    this.batchMSEvents(Y);
                    a.call(this)
                })
            }
            var mb = B.Legend = function (a, b) {
                this.init(a, b)
            };
            mb.prototype = {
                init: function (a, b) {
                    var c = this,
                d = b.itemStyle,
                e = b.itemMarginTop || 0;
                    this.options = b;
                    if (b.enabled) c.itemStyle = d, c.itemHiddenStyle =
                D(d, b.itemHiddenStyle), c.itemMarginTop = e, c.padding = d = p(b.padding, 8), c.initialItemX = d, c.initialItemY = d - 5, c.maxItemWidth = 0, c.chart = a, c.itemHeight = 0, c.symbolWidth = p(b.symbolWidth, 16), c.pages = [], c.render(), I(c.chart, "endResize", function () {
                    c.positionCheckboxes()
                })
                },
                colorizeItem: function (a, b) {
                    var c = this.options,
                d = a.legendItem,
                e = a.legendLine,
                f = a.legendSymbol,
                g = this.itemHiddenStyle.color,
                c = b ? c.itemStyle.color : g,
                h = b ? a.legendColor || a.color || "#CCC" : g,
                g = a.options && a.options.marker,
                i = {
                    fill: h
                },
                j;
                    d && d.css({
                        fill: c,
                        color: c
                    });
                    e && e.attr({
                        stroke: h
                    });
                    if (f) {
                        if (g && f.isMarker)
                            for (j in i.stroke = h, g = a.convertAttribs(g), g) d = g[j], d !== x && (i[j] = d);
                        f.attr(i)
                    }
                },
                positionItem: function (a) {
                    var b = this.options,
                c = b.symbolPadding,
                b = !b.rtl,
                d = a._legendItemPos,
                e = d[0],
                d = d[1],
                f = a.checkbox;
                    (a = a.legendGroup) && a.element && a.translate(b ? e : this.legendWidth - e - 2 * c - 4, d);
                    if (f) f.x = e, f.y = d
                },
                destroyItem: function (a) {
                    var b = a.checkbox;
                    o(["legendItem", "legendLine", "legendSymbol", "legendGroup"], function (b) {
                        a[b] && (a[b] = a[b].destroy())
                    });
                    b && Qa(a.checkbox)
                },
                destroy: function () {
                    var a = this.group,
                b = this.box;
                    if (b) this.box = b.destroy();
                    if (a) this.group = a.destroy()
                },
                positionCheckboxes: function (a) {
                    var b = this.group.alignAttr,
                c, d = this.clipHeight || this.legendHeight;
                    if (b) c = b.translateY, o(this.allItems, function (e) {
                        var f = e.checkbox,
                    g;
                        f && (g = c + f.y + (a || 0) + 3, M(f, {
                            left: b.translateX + e.checkboxOffset + f.x - 20 + "px",
                            top: g + "px",
                            display: g > c - 6 && g < c + d - 6 ? "" : P
                        }))
                    })
                },
                renderTitle: function () {
                    var a = this.padding,
                b = this.options.title,
                c = 0;
                    if (b.text) {
                        if (!this.title) this.title = this.chart.renderer.label(b.text,
                    a - 3, a - 4, null, null, null, null, null, "legend-title").attr({
                        zIndex: 1
                    }).css(b.style).add(this.group);
                        a = this.title.getBBox();
                        c = a.height;
                        this.offsetWidth = a.width;
                        this.contentGroup.attr({
                            translateY: c
                        })
                    }
                    this.titleHeight = c
                },
                setText: function (a) {
                    var b = this.options;
                    a.legendItem.attr({
                        text: b.labelFormat ? Ia(b.labelFormat, a) : b.labelFormatter.call(a)
                    })
                },
                renderItem: function (a) {
                    var b = this.chart,
                c = b.renderer,
                d = this.options,
                e = d.layout === "horizontal",
                f = this.symbolWidth,
                g = d.symbolPadding,
                h = this.itemStyle,
                i = this.itemHiddenStyle,
                j = this.padding,
                k = e ? p(d.itemDistance, 20) : 0,
                m = !d.rtl,
                n = d.width,
                l = d.itemMarginBottom || 0,
                u = this.itemMarginTop,
                r = this.initialItemX,
                o = a.legendItem,
                A = a.series && a.series.drawLegendSymbol ? a.series : a,
                v = A.options,
                v = this.createCheckboxForItem && v && v.showCheckbox,
                q = d.useHTML;
                    if (!o) {
                        a.legendGroup = c.g("legend-item").attr({
                            zIndex: 1
                        }).add(this.scrollGroup);
                        a.legendItem = o = c.text("", m ? f + g : -g, this.baseline || 0, q).css(D(a.visible ? h : i)).attr({
                            align: m ? "left" : "right",
                            zIndex: 2
                        }).add(a.legendGroup);
                        if (!this.baseline) this.fontMetrics =
                    c.fontMetrics(h.fontSize, o), this.baseline = this.fontMetrics.f + 3 + u, o.attr("y", this.baseline);
                        A.drawLegendSymbol(this, a);
                        this.setItemEvents && this.setItemEvents(a, o, q, h, i);
                        this.colorizeItem(a, a.visible);
                        v && this.createCheckboxForItem(a)
                    }
                    this.setText(a);
                    c = o.getBBox();
                    f = a.checkboxOffset = d.itemWidth || a.legendItemWidth || f + g + c.width + k + (v ? 20 : 0);
                    this.itemHeight = g = w(a.legendItemHeight || c.height);
                    if (e && this.itemX - r + f > (n || b.chartWidth - 2 * j - r - d.x)) this.itemX = r, this.itemY += u + this.lastLineHeight + l, this.lastLineHeight =
                0;
                    this.maxItemWidth = s(this.maxItemWidth, f);
                    this.lastItemY = u + this.itemY + l;
                    this.lastLineHeight = s(g, this.lastLineHeight);
                    a._legendItemPos = [this.itemX, this.itemY];
                    e ? this.itemX += f : (this.itemY += u + g + l, this.lastLineHeight = g);
                    this.offsetWidth = n || s((e ? this.itemX - r - k : f) + j, this.offsetWidth)
                },
                getAllItems: function () {
                    var a = [];
                    o(this.chart.series, function (b) {
                        var c = b.options;
                        if (p(c.showInLegend, !q(c.linkedTo) ? x : !1, !0)) a = a.concat(b.legendItems || (c.legendType === "point" ? b.data : b))
                    });
                    return a
                },
                adjustMargins: function (a,
            b) {
                    var c = this.chart,
                d = this.options,
                e = d.align.charAt(0) + d.verticalAlign.charAt(0) + d.layout.charAt(0);
                    this.display && !d.floating && o([/(lth|ct|rth)/, /(rtv|rm|rbv)/, /(rbh|cb|lbh)/, /(lbv|lm|ltv)/], function (f, g) {
                        f.test(e) && !q(a[g]) && (c[ib[g]] = s(c[ib[g]], c.legend[(g + 1) % 2 ? "legendHeight" : "legendWidth"] + [1, -1, -1, 1][g] * d[g % 2 ? "x" : "y"] + p(d.margin, 12) + b[g]))
                    })
                },
                render: function () {
                    var a = this,
                b = a.chart,
                c = b.renderer,
                d = a.group,
                e, f, g, h, i = a.box,
                j = a.options,
                k = a.padding,
                m = j.borderWidth,
                n = j.backgroundColor;
                    a.itemX = a.initialItemX;
                    a.itemY = a.initialItemY;
                    a.offsetWidth = 0;
                    a.lastItemY = 0;
                    if (!d) a.group = d = c.g("legend").attr({
                        zIndex: 7
                    }).add(), a.contentGroup = c.g().attr({
                        zIndex: 1
                    }).add(d), a.scrollGroup = c.g().add(a.contentGroup);
                    a.renderTitle();
                    e = a.getAllItems();
                    qb(e, function (a, b) {
                        return (a.options && a.options.legendIndex || 0) - (b.options && b.options.legendIndex || 0)
                    });
                    j.reversed && e.reverse();
                    a.allItems = e;
                    a.display = f = !!e.length;
                    a.lastLineHeight = 0;
                    o(e, function (b) {
                        a.renderItem(b)
                    });
                    g = (j.width || a.offsetWidth) + k;
                    h = a.lastItemY + a.lastLineHeight +
                a.titleHeight;
                    h = a.handleOverflow(h);
                    h += k;
                    if (m || n) {
                        if (i) {
                            if (g > 0 && h > 0) i[i.isNew ? "attr" : "animate"](i.crisp({
                                width: g,
                                height: h
                            })), i.isNew = !1
                        } else a.box = i = c.rect(0, 0, g, h, j.borderRadius, m || 0).attr({
                            stroke: j.borderColor,
                            "stroke-width": m || 0,
                            fill: n || P
                        }).add(d).shadow(j.shadow), i.isNew = !0;
                        i[f ? "show" : "hide"]()
                    }
                    a.legendWidth = g;
                    a.legendHeight = h;
                    o(e, function (b) {
                        a.positionItem(b)
                    });
                    f && d.align(t({
                        width: g,
                        height: h
                    }, j), !0, "spacingBox");
                    b.isResizing || this.positionCheckboxes()
                },
                handleOverflow: function (a) {
                    var b = this,
                c =
                this.chart,
                d = c.renderer,
                e = this.options,
                f = e.y,
                f = c.spacingBox.height + (e.verticalAlign === "top" ? -f : f) - this.padding,
                g = e.maxHeight,
                h, i = this.clipRect,
                j = e.navigation,
                k = p(j.animation, !0),
                m = j.arrowSize || 12,
                n = this.nav,
                l = this.pages,
                u = this.padding,
                r, q = this.allItems,
                A = function (a) {
                    i.attr({
                        height: a
                    });
                    if (b.contentGroup.div) b.contentGroup.div.style.clip = "rect(" + u + "px,9999px," + (u + a) + "px,0)"
                };
                    e.layout === "horizontal" && (f /= 2);
                    g && (f = z(f, g));
                    l.length = 0;
                    if (a > f) {
                        this.clipHeight = h = s(f - 20 - this.titleHeight - u, 0);
                        this.currentPage =
                    p(this.currentPage, 1);
                        this.fullHeight = a;
                        o(q, function (a, b) {
                            var c = a._legendItemPos[1],
                        d = w(a.legendItem.getBBox().height),
                        e = l.length;
                            if (!e || c - l[e - 1] > h && (r || c) !== l[e - 1]) l.push(r || c), e++;
                            b === q.length - 1 && c + d - l[e - 1] > h && l.push(c);
                            c !== r && (r = c)
                        });
                        if (!i) i = b.clipRect = d.clipRect(0, u, 9999, 0), b.contentGroup.clip(i);
                        A(h);
                        if (!n) this.nav = n = d.g().attr({
                            zIndex: 1
                        }).add(this.group), this.up = d.symbol("triangle", 0, 0, m, m).on("click", function () {
                            b.scroll(-1, k)
                        }).add(n), this.pager = d.text("", 15, 10).css(j.style).add(n), this.down =
                    d.symbol("triangle-down", 0, 0, m, m).on("click", function () {
                        b.scroll(1, k)
                    }).add(n);
                        b.scroll(0);
                        a = f
                    } else if (n) A(c.chartHeight), n.hide(), this.scrollGroup.attr({
                        translateY: 1
                    }), this.clipHeight = 0;
                    return a
                },
                scroll: function (a, b) {
                    var c = this.pages,
                d = c.length,
                e = this.currentPage + a,
                f = this.clipHeight,
                g = this.options.navigation,
                h = g.activeColor,
                g = g.inactiveColor,
                i = this.pager,
                j = this.padding;
                    e > d && (e = d);
                    if (e > 0) b !== x && Ra(b, this.chart), this.nav.attr({
                        translateX: j,
                        translateY: f + this.padding + 7 + this.titleHeight,
                        visibility: "visible"
                    }),
                this.up.attr({
                    fill: e === 1 ? g : h
                }).css({
                    cursor: e === 1 ? "default" : "pointer"
                }), i.attr({
                    text: e + "/" + d
                }), this.down.attr({
                    x: 18 + this.pager.getBBox().width,
                    fill: e === d ? g : h
                }).css({
                    cursor: e === d ? "default" : "pointer"
                }), c = -c[e - 1] + this.initialItemY, this.scrollGroup.animate({
                    translateY: c
                }), this.currentPage = e, this.positionCheckboxes(c)
                }
            };
            Ma = B.LegendSymbolMixin = {
                drawRectangle: function (a, b) {
                    var c = a.options.symbolHeight || a.fontMetrics.f;
                    b.legendSymbol = this.chart.renderer.rect(0, a.baseline - c + 1, a.symbolWidth, c, a.options.symbolRadius ||
                0).attr({
                    zIndex: 3
                }).add(b.legendGroup)
                },
                drawLineMarker: function (a) {
                    var b = this.options,
                c = b.marker,
                d;
                    d = a.symbolWidth;
                    var e = this.chart.renderer,
                f = this.legendGroup,
                a = a.baseline - w(a.fontMetrics.b * 0.3),
                g;
                    if (b.lineWidth) {
                        g = {
                            "stroke-width": b.lineWidth
                        };
                        if (b.dashStyle) g.dashstyle = b.dashStyle;
                        this.legendLine = e.path(["M", 0, a, "L", d, a]).attr(g).add(f)
                    }
                    if (c && c.enabled !== !1) b = c.radius, this.legendSymbol = d = e.symbol(this.symbol, d / 2 - b, a - b, 2 * b, 2 * b).add(f), d.isMarker = !0
                }
            };
            (/Trident\/7\.0/.test(za) || Ka) && Ta(mb.prototype,
        "positionItem",
        function (a, b) {
            var c = this,
                d = function () {
                    b._legendItemPos && a.call(c, b)
                };
            d();
            setTimeout(d)
        });
            E = B.Chart = function () {
                this.init.apply(this, arguments)
            };
            E.prototype = {
                callbacks: [],
                init: function (a, b) {
                    var c, d = a.series;
                    a.series = null;
                    c = D(S, a);
                    c.series = a.series = d;
                    this.userOptions = a;
                    d = c.chart;
                    this.margin = this.splashArray("margin", d);
                    this.spacing = this.splashArray("spacing", d);
                    var e = d.events;
                    this.bounds = {
                        h: {},
                        v: {}
                    };
                    this.callback = b;
                    this.isResizing = 0;
                    this.options = c;
                    this.axes = [];
                    this.series = [];
                    this.hasCartesianSeries =
                d.showAxes;
                    var f = this,
                g;
                    f.index = X.length;
                    X.push(f);
                    bb++;
                    d.reflow !== !1 && I(f, "load", function () {
                        f.initReflow()
                    });
                    if (e)
                        for (g in e) I(f, g, e[g]);
                    f.xAxis = [];
                    f.yAxis = [];
                    f.animation = fa ? !1 : p(d.animation, !0);
                    f.pointCount = f.colorCounter = f.symbolCounter = 0;
                    f.firstRender()
                },
                initSeries: function (a) {
                    var b = this.options.chart;
                    (b = N[a.type || b.type || b.defaultSeriesType]) || la(17, !0);
                    b = new b;
                    b.init(this, a);
                    return b
                },
                isInsidePlot: function (a, b, c) {
                    var d = c ? b : a,
                a = c ? a : b;
                    return d >= 0 && d <= this.plotWidth && a >= 0 && a <= this.plotHeight
                },
                redraw: function (a) {
                    var b = this.axes,
                c = this.series,
                d = this.pointer,
                e = this.legend,
                f = this.isDirtyLegend,
                g, h, i = this.hasCartesianSeries,
                j = this.isDirtyBox,
                k = c.length,
                m = k,
                n = this.renderer,
                l = n.isHidden(),
                p = [];
                    Ra(a, this);
                    l && this.cloneRenderTo();
                    for (this.layOutTitles(); m--; )
                        if (a = c[m], a.options.stacking && (g = !0, a.isDirty)) {
                            h = !0;
                            break
                        }
                    if (h)
                        for (m = k; m--; )
                            if (a = c[m], a.options.stacking) a.isDirty = !0;
                    o(c, function (a) {
                        a.isDirty && a.options.legendType === "point" && (a.updateTotals && a.updateTotals(), f = !0)
                    });
                    if (f && e.options.enabled) e.render(),
                this.isDirtyLegend = !1;
                    g && this.getStacks();
                    if (i && !this.isResizing) this.maxTicks = null, o(b, function (a) {
                        a.setScale()
                    });
                    this.getMargins();
                    i && (o(b, function (a) {
                        a.isDirty && (j = !0)
                    }), o(b, function (a) {
                        var b = a.min + "," + a.max;
                        if (a.extKey !== b) a.extKey = b, p.push(function () {
                            J(a, "afterSetExtremes", t(a.eventArgs, a.getExtremes()));
                            delete a.eventArgs
                        });
                        (j || g) && a.redraw()
                    }));
                    j && this.drawChartBox();
                    o(c, function (a) {
                        a.isDirty && a.visible && (!a.isCartesian || a.xAxis) && a.redraw()
                    });
                    d && d.reset(!0);
                    n.draw();
                    J(this, "redraw");
                    l && this.cloneRenderTo(!0);
                    o(p, function (a) {
                        a.call()
                    })
                },
                get: function (a) {
                    var b = this.axes,
                c = this.series,
                d, e;
                    for (d = 0; d < b.length; d++)
                        if (b[d].options.id === a) return b[d];
                    for (d = 0; d < c.length; d++)
                        if (c[d].options.id === a) return c[d];
                    for (d = 0; d < c.length; d++) {
                        e = c[d].points || [];
                        for (b = 0; b < e.length; b++)
                            if (e[b].id === a) return e[b]
                        }
                        return null
                    },
                    getAxes: function () {
                        var a = this,
                b = this.options,
                c = b.xAxis = ra(b.xAxis || {}),
                b = b.yAxis = ra(b.yAxis || {});
                        o(c, function (a, b) {
                            a.index = b;
                            a.isX = !0
                        });
                        o(b, function (a, b) {
                            a.index = b
                        });
                        c = c.concat(b);
                        o(c, function (b) {
                            new ha(a,
                    b)
                        })
                    },
                    getSelectedPoints: function () {
                        var a = [];
                        o(this.series, function (b) {
                            a = a.concat(kb(b.points || [], function (a) {
                                return a.selected
                            }))
                        });
                        return a
                    },
                    getSelectedSeries: function () {
                        return kb(this.series, function (a) {
                            return a.selected
                        })
                    },
                    setTitle: function (a, b, c) {
                        var g;
                        var d = this,
                e = d.options,
                f;
                        f = e.title = D(e.title, a);
                        g = e.subtitle = D(e.subtitle, b), e = g;
                        o([
                ["title", a, f],
                ["subtitle", b, e]
            ], function (a) {
                var b = a[0],
                    c = d[b],
                    e = a[1],
                    a = a[2];
                c && e && (d[b] = c = c.destroy());
                a && a.text && !c && (d[b] = d.renderer.text(a.text, 0, 0, a.useHTML).attr({
                    align: a.align,
                    "class": "highcharts-" + b,
                    zIndex: a.zIndex || 4
                }).css(a.style).add())
            });
                        d.layOutTitles(c)
                    },
                    layOutTitles: function (a) {
                        var b = 0,
                c = this.title,
                d = this.subtitle,
                e = this.options,
                f = e.title,
                e = e.subtitle,
                g = this.renderer,
                h = this.spacingBox.width - 44;
                        if (c && (c.css({
                            width: (f.width || h) + "px"
                        }).align(t({
                            y: g.fontMetrics(f.style.fontSize, c).b - 3
                        }, f), !1, "spacingBox"), !f.floating && !f.verticalAlign)) b = c.getBBox().height;
                        d && (d.css({
                            width: (e.width || h) + "px"
                        }).align(t({
                            y: b + (f.margin - 13) + g.fontMetrics(e.style.fontSize, c).b
                        }, e), !1, "spacingBox"), !e.floating && !e.verticalAlign && (b = ta(b + d.getBBox().height)));
                        c = this.titleOffset !== b;
                        this.titleOffset = b;
                        if (!this.isDirtyBox && c) this.isDirtyBox = c, this.hasRendered && p(a, !0) && this.isDirtyBox && this.redraw()
                    },
                    getChartSize: function () {
                        var a = this.options.chart,
                b = a.width,
                a = a.height,
                c = this.renderToClone || this.renderTo;
                        if (!q(b)) this.containerWidth = jb(c, "width");
                        if (!q(a)) this.containerHeight = jb(c, "height");
                        this.chartWidth = s(0, b || this.containerWidth || 600);
                        this.chartHeight = s(0, p(a, this.containerHeight > 19 ? this.containerHeight :
                400))
                    },
                    cloneRenderTo: function (a) {
                        var b = this.renderToClone,
                c = this.container;
                        a ? b && (this.renderTo.appendChild(c), Qa(b), delete this.renderToClone) : (c && c.parentNode === this.renderTo && this.renderTo.removeChild(c), this.renderToClone = b = this.renderTo.cloneNode(0), M(b, {
                            position: "absolute",
                            top: "-9999px",
                            display: "block"
                        }), b.style.setProperty && b.style.setProperty("display", "block", "important"), C.body.appendChild(b), c && b.appendChild(c))
                    },
                    getContainer: function () {
                        var a, b = this.options,
                c = b.chart,
                d, e, f;
                        this.renderTo =
                a = c.renderTo;
                        f = "highcharts-" + xb++;
                        if (Ba(a)) this.renderTo = a = C.getElementById(a);
                        a || la(13, !0);
                        d = G(K(a, "data-highcharts-chart"));
                        !isNaN(d) && X[d] && X[d].hasRendered && X[d].destroy();
                        K(a, "data-highcharts-chart", this.index);
                        a.innerHTML = "";
                        !c.skipClone && !a.offsetWidth && this.cloneRenderTo();
                        this.getChartSize();
                        d = this.chartWidth;
                        e = this.chartHeight;
                        this.container = a = $(Ja, {
                            className: "highcharts-container" + (c.className ? " " + c.className : ""),
                            id: f
                        }, t({
                            position: "relative",
                            overflow: "hidden",
                            width: d + "px",
                            height: e + "px",
                            textAlign: "left",
                            lineHeight: "normal",
                            zIndex: 0,
                            "-webkit-tap-highlight-color": "rgba(0,0,0,0)"
                        }, c.style), this.renderToClone || a);
                        this._cursor = a.style.cursor;
                        this.renderer = new (B[c.renderer] || $a)(a, d, e, c.style, c.forExport, b.exporting && b.exporting.allowHTML);
                        fa && this.renderer.create(this, a, d, e);
                        this.renderer.chartIndex = this.index
                    },
                    getMargins: function (a) {
                        var b = this.spacing,
                c = this.margin,
                d = this.titleOffset;
                        this.resetMargins();
                        if (d && !q(c[0])) this.plotTop = s(this.plotTop, d + this.options.title.margin + b[0]);
                        this.legend.adjustMargins(c,
                b);
                        this.extraBottomMargin && (this.marginBottom += this.extraBottomMargin);
                        this.extraTopMargin && (this.plotTop += this.extraTopMargin);
                        a || this.getAxisMargins()
                    },
                    getAxisMargins: function () {
                        var a = this,
                b = a.axisOffset = [0, 0, 0, 0],
                c = a.margin;
                        a.hasCartesianSeries && o(a.axes, function (a) {
                            a.visible && a.getOffset()
                        });
                        o(ib, function (d, e) {
                            q(c[e]) || (a[d] += b[e])
                        });
                        a.setChartSize()
                    },
                    reflow: function (a) {
                        var b = this,
                c = b.options.chart,
                d = b.renderTo,
                e = c.width || jb(d, "width"),
                f = c.height || jb(d, "height"),
                c = a ? a.target : L,
                d = function () {
                    if (b.container) b.setSize(e,
                        f, !1), b.hasUserSize = null
                };
                        if (!b.hasUserSize && !b.isPrinting && e && f && (c === L || c === C)) {
                            if (e !== b.containerWidth || f !== b.containerHeight) clearTimeout(b.reflowTimeout), a ? b.reflowTimeout = setTimeout(d, 100) : d();
                            b.containerWidth = e;
                            b.containerHeight = f
                        }
                    },
                    initReflow: function () {
                        var a = this,
                b = function (b) {
                    a.reflow(b)
                };
                        I(L, "resize", b);
                        I(a, "destroy", function () {
                            Y(L, "resize", b)
                        })
                    },
                    setSize: function (a, b, c) {
                        var d = this,
                e, f, g, h = d.renderer;
                        d.isResizing += 1;
                        g = function () {
                            d && J(d, "endResize", null, function () {
                                d.isResizing -= 1
                            })
                        };
                        Ra(c,
                d);
                        d.oldChartHeight = d.chartHeight;
                        d.oldChartWidth = d.chartWidth;
                        if (q(a)) d.chartWidth = e = s(0, w(a)), d.hasUserSize = !!e;
                        if (q(b)) d.chartHeight = f = s(0, w(b));
                        a = h.globalAnimation;
                        (a ? lb : M)(d.container, {
                            width: e + "px",
                            height: f + "px"
                        }, a);
                        d.setChartSize(!0);
                        h.setSize(e, f, c);
                        d.maxTicks = null;
                        o(d.axes, function (a) {
                            a.isDirty = !0;
                            a.setScale()
                        });
                        o(d.series, function (a) {
                            a.isDirty = !0
                        });
                        d.isDirtyLegend = !0;
                        d.isDirtyBox = !0;
                        d.layOutTitles();
                        d.getMargins();
                        d.redraw(c);
                        d.oldChartHeight = null;
                        J(d, "resize");
                        a = h.globalAnimation;
                        a === !1 ?
                g() : setTimeout(g, a && a.duration || 500)
                    },
                    setChartSize: function (a) {
                        var b = this.inverted,
                c = this.renderer,
                d = this.chartWidth,
                e = this.chartHeight,
                f = this.options.chart,
                g = this.spacing,
                h = this.clipOffset,
                i, j, k, m;
                        this.plotLeft = i = w(this.plotLeft);
                        this.plotTop = j = w(this.plotTop);
                        this.plotWidth = k = s(0, w(d - i - this.marginRight));
                        this.plotHeight = m = s(0, w(e - j - this.marginBottom));
                        this.plotSizeX = b ? m : k;
                        this.plotSizeY = b ? k : m;
                        this.plotBorderWidth = f.plotBorderWidth || 0;
                        this.spacingBox = c.spacingBox = {
                            x: g[3],
                            y: g[0],
                            width: d - g[3] - g[1],
                            height: e - g[0] - g[2]
                        };
                        this.plotBox = c.plotBox = {
                            x: i,
                            y: j,
                            width: k,
                            height: m
                        };
                        d = 2 * T(this.plotBorderWidth / 2);
                        b = ta(s(d, h[3]) / 2);
                        c = ta(s(d, h[0]) / 2);
                        this.clipBox = {
                            x: b,
                            y: c,
                            width: T(this.plotSizeX - s(d, h[1]) / 2 - b),
                            height: s(0, T(this.plotSizeY - s(d, h[2]) / 2 - c))
                        };
                        a || o(this.axes, function (a) {
                            a.setAxisSize();
                            a.setAxisTranslation()
                        })
                    },
                    resetMargins: function () {
                        var a = this;
                        o(ib, function (b, c) {
                            a[b] = p(a.margin[c], a.spacing[c])
                        });
                        a.axisOffset = [0, 0, 0, 0];
                        a.clipOffset = [0, 0, 0, 0]
                    },
                    drawChartBox: function () {
                        var a = this.options.chart,
                b = this.renderer,
                c = this.chartWidth,
                d = this.chartHeight,
                e = this.chartBackground,
                f = this.plotBackground,
                g = this.plotBorder,
                h = this.plotBGImage,
                i = a.borderWidth || 0,
                j = a.backgroundColor,
                k = a.plotBackgroundColor,
                m = a.plotBackgroundImage,
                n = a.plotBorderWidth || 0,
                l, p = this.plotLeft,
                o = this.plotTop,
                q = this.plotWidth,
                s = this.plotHeight,
                v = this.plotBox,
                t = this.clipRect,
                x = this.clipBox;
                        l = i + (a.shadow ? 8 : 0);
                        if (i || j)
                            if (e) e.animate(e.crisp({
                                width: c - l,
                                height: d - l
                            }));
                            else {
                                e = {
                                    fill: j || P
                                };
                                if (i) e.stroke = a.borderColor, e["stroke-width"] = i;
                                this.chartBackground =
                        b.rect(l / 2, l / 2, c - l, d - l, a.borderRadius, i).attr(e).addClass("highcharts-background").add().shadow(a.shadow)
                            }
                        if (k) f ? f.animate(v) : this.plotBackground = b.rect(p, o, q, s, 0).attr({
                            fill: k
                        }).add().shadow(a.plotShadow);
                        if (m) h ? h.animate(v) : this.plotBGImage = b.image(m, p, o, q, s).add();
                        t ? t.animate({
                            width: x.width,
                            height: x.height
                        }) : this.clipRect = b.clipRect(x);
                        if (n) g ? g.animate(g.crisp({
                            x: p,
                            y: o,
                            width: q,
                            height: s,
                            strokeWidth: -n
                        })) : this.plotBorder = b.rect(p, o, q, s, 0, -n).attr({
                            stroke: a.plotBorderColor,
                            "stroke-width": n,
                            fill: P,
                            zIndex: 1
                        }).add();
                        this.isDirtyBox = !1
                    },
                    propFromSeries: function () {
                        var a = this,
                b = a.options.chart,
                c, d = a.options.series,
                e, f;
                        o(["inverted", "angular", "polar"], function (g) {
                            c = N[b.type || b.defaultSeriesType];
                            f = a[g] || b[g] || c && c.prototype[g];
                            for (e = d && d.length; !f && e--; ) (c = N[d[e].type]) && c.prototype[g] && (f = !0);
                            a[g] = f
                        })
                    },
                    linkSeries: function () {
                        var a = this,
                b = a.series;
                        o(b, function (a) {
                            a.linkedSeries.length = 0
                        });
                        o(b, function (b) {
                            var d = b.options.linkedTo;
                            if (Ba(d) && (d = d === ":previous" ? a.series[b.index - 1] : a.get(d))) d.linkedSeries.push(b),
                    b.linkedParent = d, b.visible = p(b.options.visible, d.options.visible, b.visible)
                        })
                    },
                    renderSeries: function () {
                        o(this.series, function (a) {
                            a.translate();
                            a.render()
                        })
                    },
                    renderLabels: function () {
                        var a = this,
                b = a.options.labels;
                        b.items && o(b.items, function (c) {
                            var d = t(b.style, c.style),
                    e = G(d.left) + a.plotLeft,
                    f = G(d.top) + a.plotTop + 12;
                            delete d.left;
                            delete d.top;
                            a.renderer.text(c.html, e, f).attr({
                                zIndex: 2
                            }).css(d).add()
                        })
                    },
                    render: function () {
                        var a = this.axes,
                b = this.renderer,
                c = this.options,
                d, e, f, g;
                        this.setTitle();
                        this.legend =
                new mb(this, c.legend);
                        this.getStacks && this.getStacks();
                        this.getMargins(!0);
                        this.setChartSize();
                        d = this.plotWidth;
                        e = this.plotHeight -= 13;
                        o(a, function (a) {
                            a.setScale()
                        });
                        this.getAxisMargins();
                        f = d / this.plotWidth > 1.1;
                        g = e / this.plotHeight > 1.1;
                        if (f || g) this.maxTicks = null, o(a, function (a) {
                            (a.horiz && f || !a.horiz && g) && a.setTickInterval(!0)
                        }), this.getMargins();
                        this.drawChartBox();
                        this.hasCartesianSeries && o(a, function (a) {
                            a.visible && a.render()
                        });
                        if (!this.seriesGroup) this.seriesGroup = b.g("series-group").attr({
                            zIndex: 3
                        }).add();
                        this.renderSeries();
                        this.renderLabels();
                        this.showCredits(c.credits);
                        this.hasRendered = !0
                    },
                    showCredits: function (a) {
                        if (a.enabled && !this.credits) this.credits = this.renderer.text(a.text, 0, 0).on("click", function () {
                            if (a.href) location.href = a.href
                        }).attr({
                            align: a.position.align,
                            zIndex: 8
                        }).css(a.style).add().align(a.position)
                    },
                    destroy: function () {
                        var a = this,
                b = a.axes,
                c = a.series,
                d = a.container,
                e, f = d && d.parentNode;
                        J(a, "destroy");
                        X[a.index] = x;
                        bb--;
                        a.renderTo.removeAttribute("data-highcharts-chart");
                        Y(a);
                        for (e = b.length; e--; ) b[e] =
                b[e].destroy();
                        for (e = c.length; e--; ) c[e] = c[e].destroy();
                        o("title,subtitle,chartBackground,plotBackground,plotBGImage,plotBorder,seriesGroup,clipRect,credits,pointer,scroller,rangeSelector,legend,resetZoomButton,tooltip,renderer".split(","), function (b) {
                            var c = a[b];
                            c && c.destroy && (a[b] = c.destroy())
                        });
                        if (d) d.innerHTML = "", Y(d), f && Qa(d);
                        for (e in a) delete a[e]
                    },
                    isReadyToRender: function () {
                        var a = this;
                        return !ca && L == L.top && C.readyState !== "complete" || fa && !L.canvg ? (fa ? Lb.push(function () {
                            a.firstRender()
                        }, a.options.global.canvasToolsURL) :
                C.attachEvent("onreadystatechange", function () {
                    C.detachEvent("onreadystatechange", a.firstRender);
                    C.readyState === "complete" && a.firstRender()
                }), !1) : !0
                    },
                    firstRender: function () {
                        var a = this,
                b = a.options,
                c = a.callback;
                        if (a.isReadyToRender()) {
                            a.getContainer();
                            J(a, "init");
                            a.resetMargins();
                            a.setChartSize();
                            a.propFromSeries();
                            a.getAxes();
                            o(b.series || [], function (b) {
                                a.initSeries(b)
                            });
                            a.linkSeries();
                            J(a, "beforeRender");
                            if (B.Pointer) a.pointer = new Va(a, b);
                            a.render();
                            a.renderer.draw();
                            c && c.apply(a, [a]);
                            o(a.callbacks,
                    function (b) {
                        a.index !== x && b.apply(a, [a])
                    });
                            J(a, "load");
                            a.cloneRenderTo(!0)
                        }
                    },
                    splashArray: function (a, b) {
                        var c = b[a],
                c = da(c) ? c : [c, c, c, c];
                        return [p(b[a + "Top"], c[0]), p(b[a + "Right"], c[1]), p(b[a + "Bottom"], c[2]), p(b[a + "Left"], c[3])]
                    }
                };
                var Xb = B.CenteredSeriesMixin = {
                    getCenter: function () {
                        var a = this.options,
                    b = this.chart,
                    c = 2 * (a.slicedOffset || 0),
                    d = b.plotWidth - 2 * c,
                    b = b.plotHeight - 2 * c,
                    e = a.center,
                    e = [p(e[0], "50%"), p(e[1], "50%"), a.size || "100%", a.innerSize || 0],
                    f = z(d, b),
                    g, h;
                        for (g = 0; g < 4; ++g) h = e[g], a = g < 2 || g === 2 && /%$/.test(h),
                    e[g] = (/%$/.test(h) ? [d, b, f, e[2]][g] * parseFloat(h) / 100 : parseFloat(h)) + (a ? c : 0);
                        e[3] > e[2] && (e[3] = e[2]);
                        return e
                    }
                },
        Fa = function () { };
                Fa.prototype = {
                    init: function (a, b, c) {
                        this.series = a;
                        this.color = a.color;
                        this.applyOptions(b, c);
                        this.pointAttr = {};
                        if (a.options.colorByPoint && (b = a.options.colors || a.chart.options.colors, this.color = this.color || b[a.colorCounter++], a.colorCounter === b.length)) a.colorCounter = 0;
                        a.chart.pointCount++;
                        return this
                    },
                    applyOptions: function (a, b) {
                        var c = this.series,
                d = c.options.pointValKey || c.pointValKey,
                a = Fa.prototype.optionsToObject.call(this, a);
                        t(this, a);
                        this.options = this.options ? t(this.options, a) : a;
                        if (d) this.y = this[d];
                        if (this.x === x && c) this.x = b === x ? c.autoIncrement() : b;
                        return this
                    },
                    optionsToObject: function (a) {
                        var b = {},
                c = this.series,
                d = c.options.keys,
                e = d || c.pointArrayMap || ["y"],
                f = e.length,
                g = 0,
                h = 0;
                        if (typeof a === "number" || a === null) b[e[0]] = a;
                        else if (Ga(a)) {
                            if (!d && a.length > f) {
                                c = typeof a[0];
                                if (c === "string") b.name = a[0];
                                else if (c === "number") b.x = a[0];
                                g++
                            }
                            for (; h < f; ) {
                                if (!d || a[g] !== void 0) b[e[h]] = a[g];
                                g++;
                                h++
                            }
                        } else if (typeof a ===
                "object") {
                            b = a;
                            if (a.dataLabels) c._hasPointLabels = !0;
                            if (a.marker) c._hasPointMarkers = !0
                        }
                        return b
                    },
                    destroy: function () {
                        var a = this.series.chart,
                b = a.hoverPoints,
                c;
                        a.pointCount--;
                        if (b && (this.setState(), ja(b, this), !b.length)) a.hoverPoints = null;
                        if (this === a.hoverPoint) this.onMouseOut();
                        if (this.graphic || this.dataLabel) Y(this), this.destroyElements();
                        this.legendItem && a.legend.destroyItem(this);
                        for (c in this) this[c] = null
                    },
                    destroyElements: function () {
                        for (var a = ["graphic", "dataLabel", "dataLabelUpper", "connector", "shadowGroup"],
                    b, c = 6; c--; ) b = a[c], this[b] && (this[b] = this[b].destroy())
                    },
                    getLabelConfig: function () {
                        return {
                            x: this.category,
                            y: this.y,
                            color: this.color,
                            key: this.name || this.category,
                            series: this.series,
                            point: this,
                            percentage: this.percentage,
                            total: this.total || this.stackTotal
                        }
                    },
                    tooltipFormatter: function (a) {
                        var b = this.series,
                c = b.tooltipOptions,
                d = p(c.valueDecimals, ""),
                e = c.valuePrefix || "",
                f = c.valueSuffix || "";
                        o(b.pointArrayMap || ["y"], function (b) {
                            b = "{point." + b;
                            if (e || f) a = a.replace(b + "}", e + b + "}" + f);
                            a = a.replace(b + "}", b + ":,." + d + "f}")
                        });
                        return Ia(a, {
                            point: this,
                            series: this.series
                        })
                    },
                    firePointEvent: function (a, b, c) {
                        var d = this,
                e = this.series.options;
                        (e.point.events[a] || d.options && d.options.events && d.options.events[a]) && this.importEvents();
                        a === "click" && e.allowPointSelect && (c = function (a) {
                            d.select && d.select(null, a.ctrlKey || a.metaKey || a.shiftKey)
                        });
                        J(this, a, b, c)
                    },
                    visible: !0
                };
                var R = B.Series = function () { };
                R.prototype = {
                    isCartesian: !0,
                    type: "line",
                    pointClass: Fa,
                    sorted: !0,
                    requireSorting: !0,
                    pointAttrToOptions: {
                        stroke: "lineColor",
                        "stroke-width": "lineWidth",
                        fill: "fillColor",
                        r: "radius"
                    },
                    directTouch: !1,
                    axisTypes: ["xAxis", "yAxis"],
                    colorCounter: 0,
                    parallelArrays: ["x", "y"],
                    init: function (a, b) {
                        var c = this,
                d, e, f = a.series,
                g = function (a, b) {
                    return p(a.options.index, a._i) - p(b.options.index, b._i)
                };
                        c.chart = a;
                        c.options = b = c.setOptions(b);
                        c.linkedSeries = [];
                        c.bindAxes();
                        t(c, {
                            name: b.name,
                            state: "",
                            pointAttr: {},
                            visible: b.visible !== !1,
                            selected: b.selected === !0
                        });
                        if (fa) b.animation = !1;
                        e = b.events;
                        for (d in e) I(c, d, e[d]);
                        if (e && e.click || b.point && b.point.events && b.point.events.click ||
                b.allowPointSelect) a.runTrackerClick = !0;
                        c.getColor();
                        c.getSymbol();
                        o(c.parallelArrays, function (a) {
                            c[a + "Data"] = []
                        });
                        c.setData(b.data, !1);
                        if (c.isCartesian) a.hasCartesianSeries = !0;
                        f.push(c);
                        c._i = f.length - 1;
                        qb(f, g);
                        this.yAxis && qb(this.yAxis.series, g);
                        o(f, function (a, b) {
                            a.index = b;
                            a.name = a.name || "Series " + (b + 1)
                        })
                    },
                    bindAxes: function () {
                        var a = this,
                b = a.options,
                c = a.chart,
                d;
                        o(a.axisTypes || [], function (e) {
                            o(c[e], function (c) {
                                d = c.options;
                                if (b[e] === d.index || b[e] !== x && b[e] === d.id || b[e] === x && d.index === 0) c.series.push(a),
                        a[e] = c, c.isDirty = !0
                            });
                            !a[e] && a.optionalAxis !== e && la(18, !0)
                        })
                    },
                    updateParallelArrays: function (a, b) {
                        var c = a.series,
                d = arguments;
                        o(c.parallelArrays, typeof b === "number" ? function (d) {
                            var f = d === "y" && c.toYData ? c.toYData(a) : a[d];
                            c[d + "Data"][b] = f
                        } : function (a) {
                            Array.prototype[b].apply(c[a + "Data"], Array.prototype.slice.call(d, 2))
                        })
                    },
                    autoIncrement: function () {
                        var a = this.options,
                b = this.xIncrement,
                c, d = a.pointIntervalUnit,
                b = p(b, a.pointStart, 0);
                        this.pointInterval = c = p(this.pointInterval, a.pointInterval, 1);
                        if (d === "month" ||
                d === "year") a = new ya(b), a = d === "month" ? +a[vb](a[Ya]() + c) : +a[wb](a[Za]() + c), c = a - b;
                        this.xIncrement = b + c;
                        return b
                    },
                    getSegments: function () {
                        var a = -1,
                b = [],
                c, d = this.points,
                e = d.length;
                        if (e)
                            if (this.options.connectNulls) {
                                for (c = e; c--; ) d[c].y === null && d.splice(c, 1);
                                d.length && (b = [d])
                            } else o(d, function (c, g) {
                                c.y === null ? (g > a + 1 && b.push(d.slice(a + 1, g)), a = g) : g === e - 1 && b.push(d.slice(a + 1, g + 1))
                            });
                        this.segments = b
                    },
                    setOptions: function (a) {
                        var b = this.chart,
                c = b.options.plotOptions,
                b = b.userOptions || {},
                d = b.plotOptions || {},
                e = c[this.type];
                        this.userOptions = a;
                        c = D(e, c.series, a);
                        this.tooltipOptions = D(S.tooltip, S.plotOptions[this.type].tooltip, b.tooltip, d.series && d.series.tooltip, d[this.type] && d[this.type].tooltip, a.tooltip);
                        e.marker === null && delete c.marker;
                        this.zoneAxis = c.zoneAxis;
                        a = this.zones = (c.zones || []).slice();
                        if ((c.negativeColor || c.negativeFillColor) && !c.zones) a.push({
                            value: c[this.zoneAxis + "Threshold"] || c.threshold || 0,
                            color: c.negativeColor,
                            fillColor: c.negativeFillColor
                        });
                        a.length && q(a[a.length - 1].value) && a.push({
                            color: this.color,
                            fillColor: this.fillColor
                        });
                        return c
                    },
                    getCyclic: function (a, b, c) {
                        var d = this.userOptions,
                e = "_" + a + "Index",
                f = a + "Counter";
                        b || (q(d[e]) ? b = d[e] : (d[e] = b = this.chart[f] % c.length, this.chart[f] += 1), b = c[b]);
                        this[a] = b
                    },
                    getColor: function () {
                        this.options.colorByPoint ? this.options.color = null : this.getCyclic("color", this.options.color || ba[this.type].color, this.chart.options.colors)
                    },
                    getSymbol: function () {
                        var a = this.options.marker;
                        this.getCyclic("symbol", a.symbol, this.chart.options.symbols);
                        if (/^url/.test(this.symbol)) a.radius =
                0
                    },
                    drawLegendSymbol: Ma.drawLineMarker,
                    setData: function (a, b, c, d) {
                        var e = this,
                f = e.points,
                g = f && f.length || 0,
                h, i = e.options,
                j = e.chart,
                k = null,
                m = e.xAxis,
                n = m && !!m.categories,
                l = i.turboThreshold,
                u = this.xData,
                r = this.yData,
                s = (h = e.pointArrayMap) && h.length,
                a = a || [];
                        h = a.length;
                        b = p(b, !0);
                        if (d !== !1 && h && g === h && !e.cropped && !e.hasGroupedData && e.visible) o(a, function (a, b) {
                            f[b].update && f[b].update(a, !1, null, !1)
                        });
                        else {
                            e.xIncrement = null;
                            e.pointRange = n ? 1 : i.pointRange;
                            e.colorCounter = 0;
                            o(this.parallelArrays, function (a) {
                                e[a + "Data"].length =
                        0
                            });
                            if (l && h > l) {
                                for (c = 0; k === null && c < h; ) k = a[c], c++;
                                if (qa(k)) {
                                    n = p(i.pointStart, 0);
                                    k = p(i.pointInterval, 1);
                                    for (c = 0; c < h; c++) u[c] = n, r[c] = a[c], n += k;
                                    e.xIncrement = n
                                } else if (Ga(k))
                                    if (s)
                                        for (c = 0; c < h; c++) k = a[c], u[c] = k[0], r[c] = k.slice(1, s + 1);
                                    else
                                        for (c = 0; c < h; c++) k = a[c], u[c] = k[0], r[c] = k[1];
                                else la(12)
                            } else
                                for (c = 0; c < h; c++)
                                    if (a[c] !== x && (k = {
                                        series: e
                                    }, e.pointClass.prototype.applyOptions.apply(k, [a[c]]), e.updateParallelArrays(k, c), n && q(k.name))) m.names[k.x] = k.name;
                            Ba(r[0]) && la(14, !0);
                            e.data = [];
                            e.options.data = a;
                            for (c =
                    g; c--; ) f[c] && f[c].destroy && f[c].destroy();
                            if (m) m.minRange = m.userMinRange;
                            e.isDirty = e.isDirtyData = j.isDirtyBox = !0;
                            c = !1
                        }
                        i.legendType === "point" && (this.processData(), this.generatePoints());
                        b && j.redraw(c)
                    },
                    processData: function (a) {
                        var b = this.xData,
                c = this.yData,
                d = b.length,
                e;
                        e = 0;
                        var f, g, h = this.xAxis,
                i, j = this.options;
                        i = j.cropThreshold;
                        var k = this.getExtremesFromAll || j.getExtremesFromAll,
                m = this.isCartesian,
                n, l;
                        if (m && !this.isDirty && !h.isDirty && !this.yAxis.isDirty && !a) return !1;
                        if (h) a = h.getExtremes(), n = a.min, l =
                a.max;
                        if (m && this.sorted && !k && (!i || d > i || this.forceCrop))
                            if (b[d - 1] < n || b[0] > l) b = [], c = [];
                            else if (b[0] < n || b[d - 1] > l) e = this.cropData(this.xData, this.yData, n, l), b = e.xData, c = e.yData, e = e.start, f = !0;
                        for (i = b.length - 1; i >= 0; i--) d = b[i] - b[i - 1], d > 0 && (g === x || d < g) ? g = d : d < 0 && this.requireSorting && la(15);
                        this.cropped = f;
                        this.cropStart = e;
                        this.processedXData = b;
                        this.processedYData = c;
                        if (j.pointRange === null) this.pointRange = g || 1;
                        this.closestPointRange = g
                    },
                    cropData: function (a, b, c, d) {
                        var e = a.length,
                f = 0,
                g = e,
                h = p(this.cropShoulder,
                    1),
                i;
                        for (i = 0; i < e; i++)
                            if (a[i] >= c) {
                                f = s(0, i - h);
                                break
                            }
                        for (; i < e; i++)
                            if (a[i] > d) {
                                g = i + h;
                                break
                            }
                        return {
                            xData: a.slice(f, g),
                            yData: b.slice(f, g),
                            start: f,
                            end: g
                        }
                    },
                    generatePoints: function () {
                        var a = this.options.data,
                b = this.data,
                c, d = this.processedXData,
                e = this.processedYData,
                f = this.pointClass,
                g = d.length,
                h = this.cropStart || 0,
                i, j = this.hasGroupedData,
                k, m = [],
                n;
                        if (!b && !j) b = [], b.length = a.length, b = this.data = b;
                        for (n = 0; n < g; n++) i = h + n, j ? m[n] = (new f).init(this, [d[n]].concat(ra(e[n]))) : (b[i] ? k = b[i] : a[i] !== x && (b[i] = k = (new f).init(this,
                a[i], d[n])), m[n] = k), m[n].index = i;
                        if (b && (g !== (c = b.length) || j))
                            for (n = 0; n < c; n++)
                                if (n === h && !j && (n += g), b[n]) b[n].destroyElements(), b[n].plotX = x;
                        this.data = b;
                        this.points = m
                    },
                    getExtremes: function (a) {
                        var b = this.yAxis,
                c = this.processedXData,
                d, e = [],
                f = 0;
                        d = this.xAxis.getExtremes();
                        var g = d.min,
                h = d.max,
                i, j, k, m, a = a || this.stackedYData || this.processedYData;
                        d = a.length;
                        for (m = 0; m < d; m++)
                            if (j = c[m], k = a[m], i = k !== null && k !== x && (!b.isLog || k.length || k > 0), j = this.getExtremesFromAll || this.options.getExtremesFromAll || this.cropped ||
                    (c[m + 1] || j) >= g && (c[m - 1] || j) <= h, i && j)
                                if (i = k.length)
                                    for (; i--; ) k[i] !== null && (e[f++] = k[i]);
                                else e[f++] = k;
                        this.dataMin = Oa(e);
                        this.dataMax = Da(e)
                    },
                    translate: function () {
                        this.processedXData || this.processData();
                        this.generatePoints();
                        for (var a = this.options, b = a.stacking, c = this.xAxis, d = c.categories, e = this.yAxis, f = this.points, g = f.length, h = !!this.modifyValue, i = a.pointPlacement, j = i === "between" || qa(i), k = a.threshold, m = a.startFromThreshold ? k : 0, n, l, u, o, t = Number.MAX_VALUE, a = 0; a < g; a++) {
                            var A = f[a],
                    v = A.x,
                    y = A.y;
                            l = A.low;
                            var w =
                    b && e.stacks[(this.negStacks && y < (m ? 0 : k) ? "-" : "") + this.stackKey];
                            if (e.isLog && y !== null && y <= 0) A.y = y = null, la(10);
                            A.plotX = n = z(s(-1E5, c.translate(v, 0, 0, 0, 1, i, this.type === "flags")), 1E5);
                            if (b && this.visible && w && w[v]) o = this.getStackIndicator(o, v, this.index), w = w[v], y = w.points[o.key], l = y[0], y = y[1], l === m && (l = p(k, e.min)), e.isLog && l <= 0 && (l = null), A.total = A.stackTotal = w.total, A.percentage = w.total && A.y / w.total * 100, A.stackY = y, w.setOffset(this.pointXOffset || 0, this.barW || 0);
                            A.yBottom = q(l) ? e.translate(l, 0, 1, 0, 1) : null;
                            h &&
                    (y = this.modifyValue(y, A));
                            A.plotY = l = typeof y === "number" && y !== Infinity ? z(s(-1E5, e.translate(y, 0, 1, 0, 1)), 1E5) : x;
                            A.isInside = l !== x && l >= 0 && l <= e.len && n >= 0 && n <= c.len;
                            A.clientX = j ? c.translate(v, 0, 0, 0, 1) : n;
                            A.negative = A.y < (k || 0);
                            A.category = d && d[A.x] !== x ? d[A.x] : A.x;
                            a && (t = z(t, O(n - u)));
                            u = n
                        }
                        this.closestPointRangePx = t;
                        this.getSegments()
                    },
                    setClip: function (a) {
                        var b = this.chart,
                c = this.options,
                d = b.renderer,
                e = b.inverted,
                f = this.clipBox,
                g = f || b.clipBox,
                h = this.sharedClipKey || ["_sharedClip", a && a.duration, a && a.easing, g.height,
                    c.xAxis, c.yAxis
                ].join(","),
                i = b[h],
                j = b[h + "m"];
                        if (!i) {
                            if (a) g.width = 0, b[h + "m"] = j = d.clipRect(-99, e ? -b.plotLeft : -b.plotTop, 99, e ? b.chartWidth : b.chartHeight);
                            b[h] = i = d.clipRect(g)
                        }
                        a && (i.count += 1);
                        if (c.clip !== !1) this.group.clip(a || f ? i : b.clipRect), this.markerGroup.clip(j), this.sharedClipKey = h;
                        a || (i.count -= 1, i.count <= 0 && h && b[h] && (f || (b[h] = b[h].destroy()), b[h + "m"] && (b[h + "m"] = b[h + "m"].destroy())))
                    },
                    animate: function (a) {
                        var b = this.chart,
                c = this.options.animation,
                d;
                        if (c && !da(c)) c = ba[this.type].animation;
                        a ? this.setClip(c) :
                (d = this.sharedClipKey, (a = b[d]) && a.animate({
                    width: b.plotSizeX
                }, c), b[d + "m"] && b[d + "m"].animate({
                    width: b.plotSizeX + 99
                }, c), this.animate = null)
                    },
                    afterAnimate: function () {
                        this.setClip();
                        J(this, "afterAnimate")
                    },
                    drawPoints: function () {
                        var a, b = this.points,
                c = this.chart,
                d, e, f, g, h, i, j, k, m = this.options.marker,
                n = this.pointAttr[""],
                l, o, r, s = this.markerGroup,
                q = p(m.enabled, this.xAxis.isRadial, this.closestPointRangePx > 2 * m.radius);
                        if (m.enabled !== !1 || this._hasPointMarkers)
                            for (f = b.length; f--; )
                                if (g = b[f], d = T(g.plotX), e = g.plotY,
                        k = g.graphic, l = g.marker || {}, o = !!g.marker, a = q && l.enabled === x || l.enabled, r = g.isInside, a && e !== x && !isNaN(e) && g.y !== null)
                                    if (a = g.pointAttr[g.selected ? "select" : ""] || n, h = a.r, i = p(l.symbol, this.symbol), j = i.indexOf("url") === 0, k) k[r ? "show" : "hide"](!0).animate(t({
                                        x: d - h,
                                        y: e - h
                                    }, k.symbolName ? {
                                        width: 2 * h,
                                        height: 2 * h
                                    } : {}));
                                    else {
                                        if (r && (h > 0 || j)) g.graphic = c.renderer.symbol(i, d - h, e - h, 2 * h, 2 * h, o ? l : m).attr(a).add(s)
                                    } else if (k) g.graphic = k.destroy()
                    },
                    convertAttribs: function (a, b, c, d) {
                        var e = this.pointAttrToOptions,
                f, g, h = {},
                a = a || {},
                b = b || {},
                c = c || {},
                d = d || {};
                        for (f in e) g = e[f], h[f] = p(a[g], b[f], c[f], d[f]);
                        return h
                    },
                    getAttribs: function () {
                        var a = this,
                b = a.options,
                c = ba[a.type].marker ? b.marker : b,
                d = c.states,
                e = d.hover,
                f, g = a.color,
                h = a.options.negativeColor;
                        f = {
                            stroke: g,
                            fill: g
                        };
                        var i = a.points || [],
                j, k, m = [],
                n = a.pointAttrToOptions;
                        j = a.hasPointSpecificOptions;
                        var l = c.lineColor,
                u = c.fillColor;
                        k = b.turboThreshold;
                        var r = a.zones,
                s = a.zoneAxis || "y",
                A;
                        b.marker ? (e.radius = e.radius || c.radius + e.radiusPlus, e.lineWidth = e.lineWidth || c.lineWidth + e.lineWidthPlus) :
                (e.color = e.color || na(e.color || g).brighten(e.brightness).get(), e.negativeColor = e.negativeColor || na(e.negativeColor || h).brighten(e.brightness).get());
                        m[""] = a.convertAttribs(c, f);
                        o(["hover", "select"], function (b) {
                            m[b] = a.convertAttribs(d[b], m[""])
                        });
                        a.pointAttr = m;
                        g = i.length;
                        if (!k || g < k || j)
                            for (; g--; ) {
                                k = i[g];
                                if ((c = k.options && k.options.marker || k.options) && c.enabled === !1) c.radius = 0;
                                if (r.length) {
                                    j = 0;
                                    for (f = r[j]; k[s] >= f.value; ) f = r[++j];
                                    k.color = k.fillColor = p(f.color, a.color)
                                }
                                j = b.colorByPoint || k.color;
                                if (k.options)
                                    for (A in n) q(c[n[A]]) &&
                            (j = !0);
                                if (j) {
                                    c = c || {};
                                    j = [];
                                    d = c.states || {};
                                    f = d.hover = d.hover || {};
                                    if (!b.marker || k.negative && !f.fillColor && !e.fillColor) f[a.pointAttrToOptions.fill] = f.color || !k.options.color && e[k.negative && h ? "negativeColor" : "color"] || na(k.color).brighten(f.brightness || e.brightness).get();
                                    f = {
                                        color: k.color
                                    };
                                    if (!u) f.fillColor = k.color;
                                    if (!l) f.lineColor = k.color;
                                    c.hasOwnProperty("color") && !c.color && delete c.color;
                                    j[""] = a.convertAttribs(t(f, c), m[""]);
                                    j.hover = a.convertAttribs(d.hover, m.hover, j[""]);
                                    j.select = a.convertAttribs(d.select,
                            m.select, j[""])
                                } else j = m;
                                k.pointAttr = j
                            }
                    },
                    destroy: function () {
                        var a = this,
                b = a.chart,
                c = /AppleWebKit\/533/.test(za),
                d, e = a.data || [],
                f, g, h;
                        J(a, "destroy");
                        Y(a);
                        o(a.axisTypes || [], function (b) {
                            if (h = a[b]) ja(h.series, a), h.isDirty = h.forceRedraw = !0
                        });
                        a.legendItem && a.chart.legend.destroyItem(a);
                        for (d = e.length; d--; ) (f = e[d]) && f.destroy && f.destroy();
                        a.points = null;
                        clearTimeout(a.animationTimeout);
                        for (g in a) a[g] instanceof Q && !a[g].survive && (d = c && g === "group" ? "hide" : "destroy", a[g][d]());
                        if (b.hoverSeries === a) b.hoverSeries =
                null;
                        ja(b.series, a);
                        for (g in a) delete a[g]
                    },
                    getSegmentPath: function (a) {
                        var b = this,
                c = [],
                d = b.options.step;
                        o(a, function (e, f) {
                            var g = e.plotX,
                    h = e.plotY,
                    i;
                            b.getPointSpline ? c.push.apply(c, b.getPointSpline(a, e, f)) : (c.push(f ? "L" : "M"), d && f && (i = a[f - 1], d === "right" ? c.push(i.plotX, h, "L") : d === "center" ? c.push((i.plotX + g) / 2, i.plotY, "L", (i.plotX + g) / 2, h, "L") : c.push(g, i.plotY, "L")), c.push(e.plotX, e.plotY))
                        });
                        return c
                    },
                    getGraphPath: function () {
                        var a = this,
                b = [],
                c, d = [];
                        o(a.segments, function (e) {
                            c = a.getSegmentPath(e);
                            e.length >
                    1 ? b = b.concat(c) : d.push(e[0])
                        });
                        a.singlePoints = d;
                        return a.graphPath = b
                    },
                    drawGraph: function () {
                        var a = this,
                b = this.options,
                c = [
                    ["graph", b.lineColor || this.color, b.dashStyle]
                ],
                d = b.lineWidth,
                e = b.linecap !== "square",
                f = this.getGraphPath(),
                g = this.fillGraph && this.color || P;
                        o(this.zones, function (d, e) {
                            c.push(["zoneGraph" + e, d.color || a.color, d.dashStyle || b.dashStyle])
                        });
                        o(c, function (c, i) {
                            var j = c[0],
                    k = a[j];
                            if (k) k.animate({
                                d: f
                            });
                            else if ((d || g) && f.length) k = {
                                stroke: c[1],
                                "stroke-width": d,
                                fill: g,
                                zIndex: 1
                            }, c[2] ? k.dashstyle =
                    c[2] : e && (k["stroke-linecap"] = k["stroke-linejoin"] = "round"), a[j] = a.chart.renderer.path(f).attr(k).add(a.group).shadow(i < 2 && b.shadow)
                        })
                    },
                    applyZones: function () {
                        var a = this,
                b = this.chart,
                c = b.renderer,
                d = this.zones,
                e, f, g = this.clips || [],
                h, i = this.graph,
                j = this.area,
                k = s(b.chartWidth, b.chartHeight),
                m = this[(this.zoneAxis || "y") + "Axis"],
                n, l = m.reversed,
                u = b.inverted,
                r = m.horiz,
                q, t, v, y = !1;
                        if (d.length && (i || j) && m.min !== x) i && i.hide(), j && j.hide(), n = m.getExtremes(), o(d, function (d, o) {
                            e = l ? r ? b.plotWidth : 0 : r ? 0 : m.toPixels(n.min);
                            e = z(s(p(f, e), 0), k);
                            f = z(s(w(m.toPixels(p(d.value, n.max), !0)), 0), k);
                            y && (e = f = m.toPixels(n.max));
                            q = Math.abs(e - f);
                            t = z(e, f);
                            v = s(e, f);
                            if (m.isXAxis) {
                                if (h = {
                                    x: u ? v : t,
                                    y: 0,
                                    width: q,
                                    height: k
                                }, !r) h.x = b.plotHeight - h.x
                            } else if (h = {
                                x: 0,
                                y: u ? v : t,
                                width: k,
                                height: q
                            }, r) h.y = b.plotWidth - h.y;
                            b.inverted && c.isVML && (h = m.isXAxis ? {
                                x: 0,
                                y: l ? t : v,
                                height: h.width,
                                width: b.chartWidth
                            } : {
                                x: h.y - b.plotLeft - b.spacingBox.x,
                                y: 0,
                                width: h.height,
                                height: b.chartHeight
                            });
                            g[o] ? g[o].animate(h) : (g[o] = c.clipRect(h), i && a["zoneGraph" + o].clip(g[o]), j && a["zoneArea" +
                    o].clip(g[o]));
                            y = d.value > n.max
                        }), this.clips = g
                    },
                    invertGroups: function () {
                        function a() {
                            var a = {
                                width: b.yAxis.len,
                                height: b.xAxis.len
                            };
                            o(["group", "markerGroup"], function (c) {
                                b[c] && b[c].attr(a).invert()
                            })
                        }
                        var b = this,
                c = b.chart;
                        if (b.xAxis) I(c, "resize", a), I(b, "destroy", function () {
                            Y(c, "resize", a)
                        }), a(), b.invertGroups = a
                    },
                    plotGroup: function (a, b, c, d, e) {
                        var f = this[a],
                g = !f;
                        g && (this[a] = f = this.chart.renderer.g(b).attr({
                            visibility: c,
                            zIndex: d || 0.1
                        }).add(e), f.addClass("highcharts-series-" + this.index));
                        f[g ? "attr" : "animate"](this.getPlotBox());
                        return f
                    },
                    getPlotBox: function () {
                        var a = this.chart,
                b = this.xAxis,
                c = this.yAxis;
                        if (a.inverted) b = c, c = this.xAxis;
                        return {
                            translateX: b ? b.left : a.plotLeft,
                            translateY: c ? c.top : a.plotTop,
                            scaleX: 1,
                            scaleY: 1
                        }
                    },
                    render: function () {
                        var a = this,
                b = a.chart,
                c, d = a.options,
                e = (c = d.animation) && !!a.animate && b.renderer.isSVG && p(c.duration, 500) || 0,
                f = a.visible ? "visible" : "hidden",
                g = d.zIndex,
                h = a.hasRendered,
                i = b.seriesGroup;
                        c = a.plotGroup("group", "series", f, g, i);
                        a.markerGroup = a.plotGroup("markerGroup", "markers", f, g, i);
                        e && a.animate(!0);
                        a.getAttribs();
                        c.inverted = a.isCartesian ? b.inverted : !1;
                        a.drawGraph && (a.drawGraph(), a.applyZones());
                        o(a.points, function (a) {
                            a.redraw && a.redraw()
                        });
                        a.drawDataLabels && a.drawDataLabels();
                        a.visible && a.drawPoints();
                        a.drawTracker && a.options.enableMouseTracking !== !1 && a.drawTracker();
                        b.inverted && a.invertGroups();
                        d.clip !== !1 && !a.sharedClipKey && !h && c.clip(b.clipRect);
                        e && a.animate();
                        if (!h) e ? a.animationTimeout = setTimeout(function () {
                            a.afterAnimate()
                        }, e) : a.afterAnimate();
                        a.isDirty = a.isDirtyData = !1;
                        a.hasRendered = !0
                    },
                    redraw: function () {
                        var a = this.chart,
                b = this.isDirtyData,
                c = this.isDirty,
                d = this.group,
                e = this.xAxis,
                f = this.yAxis;
                        d && (a.inverted && d.attr({
                            width: a.plotWidth,
                            height: a.plotHeight
                        }), d.animate({
                            translateX: p(e && e.left, a.plotLeft),
                            translateY: p(f && f.top, a.plotTop)
                        }));
                        this.translate();
                        this.render();
                        b && J(this, "updatedData");
                        (c || b) && delete this.kdTree
                    },
                    kdDimensions: 1,
                    kdAxisArray: ["clientX", "plotY"],
                    searchPoint: function (a, b) {
                        var c = this.xAxis,
                d = this.yAxis,
                e = this.chart.inverted;
                        return this.searchKDTree({
                            clientX: e ? c.len -
                    a.chartY + c.pos : a.chartX - c.pos,
                            plotY: e ? d.len - a.chartX + d.pos : a.chartY - d.pos
                        }, b)
                    },
                    buildKDTree: function () {
                        function a(b, d, g) {
                            var h, i;
                            if (i = b && b.length) return h = c.kdAxisArray[d % g], b.sort(function (a, b) {
                                return a[h] - b[h]
                            }), i = Math.floor(i / 2), {
                                point: b[i],
                                left: a(b.slice(0, i), d + 1, g),
                                right: a(b.slice(i + 1), d + 1, g)
                            }
                        }

                        function b() {
                            var b = kb(c.points || [], function (a) {
                                return a.y !== null
                            });
                            c.kdTree = a(b, d, d)
                        }
                        var c = this,
                d = c.kdDimensions;
                        delete c.kdTree;
                        c.options.kdSync ? b() : setTimeout(b)
                    },
                    searchKDTree: function (a, b) {
                        function c(a,
                b, j, k) {
                            var m = b.point,
                    n = d.kdAxisArray[j % k],
                    l, p, o = m;
                            p = q(a[e]) && q(m[e]) ? Math.pow(a[e] - m[e], 2) : null;
                            l = q(a[f]) && q(m[f]) ? Math.pow(a[f] - m[f], 2) : null;
                            l = (p || 0) + (l || 0);
                            m.dist = q(l) ? Math.sqrt(l) : Number.MAX_VALUE;
                            m.distX = q(p) ? Math.sqrt(p) : Number.MAX_VALUE;
                            n = a[n] - m[n];
                            l = n < 0 ? "left" : "right";
                            p = n < 0 ? "right" : "left";
                            b[l] && (l = c(a, b[l], j + 1, k), o = l[g] < o[g] ? l : m);
                            b[p] && Math.sqrt(n * n) < o[g] && (a = c(a, b[p], j + 1, k), o = a[g] < o[g] ? a : o);
                            return o
                        }
                        var d = this,
                e = this.kdAxisArray[0],
                f = this.kdAxisArray[1],
                g = b ? "distX" : "dist";
                        this.kdTree || this.buildKDTree();
                        if (this.kdTree) return c(a, this.kdTree, this.kdDimensions, this.kdDimensions)
                    }
                };
                Hb.prototype = {
                    destroy: function () {
                        Pa(this, this.axis)
                    },
                    render: function (a) {
                        var b = this.options,
                c = b.format,
                c = c ? Ia(c, this) : b.formatter.call(this);
                        this.label ? this.label.attr({
                            text: c,
                            visibility: "hidden"
                        }) : this.label = this.axis.chart.renderer.text(c, null, null, b.useHTML).css(b.style).attr({
                            align: this.textAlign,
                            rotation: b.rotation,
                            visibility: "hidden"
                        }).add(a)
                    },
                    setOffset: function (a, b) {
                        var c = this.axis,
                d = c.chart,
                e = d.inverted,
                f = c.reversed,
                f = this.isNegative && !f || !this.isNegative && f,
                g = c.translate(c.usePercentage ? 100 : this.total, 0, 0, 0, 1),
                c = c.translate(0),
                c = O(g - c),
                h = d.xAxis[0].translate(this.x) + a,
                i = d.plotHeight,
                f = {
                    x: e ? f ? g : g - c : h,
                    y: e ? i - h - b : f ? i - g - c : i - g,
                    width: e ? c : b,
                    height: e ? b : c
                };
                        if (e = this.label) e.align(this.alignOptions, null, f), f = e.alignAttr, e[this.options.crop === !1 || d.isInsidePlot(f.x, f.y) ? "show" : "hide"](!0)
                    }
                };
                E.prototype.getStacks = function () {
                    var a = this;
                    o(a.yAxis, function (a) {
                        if (a.stacks && a.hasVisibleSeries) a.oldStacks = a.stacks
                    });
                    o(a.series,
            function (b) {
                if (b.options.stacking && (b.visible === !0 || a.options.chart.ignoreHiddenSeries === !1)) b.stackKey = b.type + p(b.options.stack, "")
            })
                };
                ha.prototype.buildStacks = function () {
                    var a = this.series,
            b = p(this.options.reversedStacks, !0),
            c = a.length;
                    if (!this.isXAxis) {
                        for (this.usePercentage = !1; c--; ) a[b ? c : a.length - c - 1].setStackedPoints();
                        if (this.usePercentage)
                            for (c = 0; c < a.length; c++) a[c].setPercentStacks()
                    }
                };
                ha.prototype.renderStackTotals = function () {
                    var a = this.chart,
            b = a.renderer,
            c = this.stacks,
            d, e, f = this.stackTotalGroup;
                    if (!f) this.stackTotalGroup = f = b.g("stack-labels").attr({
                        visibility: "visible",
                        zIndex: 6
                    }).add();
                    f.translate(a.plotLeft, a.plotTop);
                    for (d in c)
                        for (e in a = c[d], a) a[e].render(f)
                };
                ha.prototype.resetStacks = function () {
                    var a = this.stacks,
            b, c;
                    if (!this.isXAxis)
                        for (b in a)
                            for (c in a[b]) a[b][c].touched < this.stacksTouched ? (a[b][c].destroy(), delete a[b][c]) : (a[b][c].total = null, a[b][c].cum = 0)
                        };
                        ha.prototype.cleanStacks = function () {
                            var a, b, c;
                            if (!this.isXAxis) {
                                if (this.oldStacks) a = this.stacks = this.oldStacks;
                                for (b in a)
                                    for (c in a[b]) a[b][c].cum =
                    a[b][c].total
                                }
                            };
                            R.prototype.setStackedPoints = function () {
                                if (this.options.stacking && !(this.visible !== !0 && this.chart.options.chart.ignoreHiddenSeries !== !1)) {
                                    var a = this.processedXData,
                b = this.processedYData,
                c = [],
                d = b.length,
                e = this.options,
                f = e.threshold,
                g = e.startFromThreshold ? f : 0,
                h = e.stack,
                e = e.stacking,
                i = this.stackKey,
                j = "-" + i,
                k = this.negStacks,
                m = this.yAxis,
                n = m.stacks,
                l = m.oldStacks,
                o, r, q, t, v, w, x;
                                    m.stacksTouched += 1;
                                    for (v = 0; v < d; v++) {
                                        w = a[v];
                                        x = b[v];
                                        o = this.getStackIndicator(o, w, this.index);
                                        t = o.key;
                                        q = (r = k && x < (g ?
                    0 : f)) ? j : i;
                                        n[q] || (n[q] = {});
                                        if (!n[q][w]) l[q] && l[q][w] ? (n[q][w] = l[q][w], n[q][w].total = null) : n[q][w] = new Hb(m, m.options.stackLabels, r, w, h);
                                        q = n[q][w];
                                        q.points[t] = [p(q.cum, g)];
                                        q.touched = m.stacksTouched;
                                        e === "percent" ? (r = r ? i : j, k && n[r] && n[r][w] ? (r = n[r][w], q.total = r.total = s(r.total, q.total) + O(x) || 0) : q.total = ea(q.total + (O(x) || 0))) : q.total = ea(q.total + (x || 0));
                                        q.cum = p(q.cum, g) + (x || 0);
                                        q.points[t].push(q.cum);
                                        c[v] = q.cum
                                    }
                                    if (e === "percent") m.usePercentage = !0;
                                    this.stackedYData = c;
                                    m.oldStacks = {}
                                }
                            };
                            R.prototype.setPercentStacks =
        function () {
            var a = this,
                b = a.stackKey,
                c = a.yAxis.stacks,
                d = a.processedXData,
                e;
            o([b, "-" + b], function (b) {
                var f;
                for (var g = d.length, h, i; g--; )
                    if (h = d[g], e = a.getStackIndicator(e, h, a.index), f = (i = c[b] && c[b][h]) && i.points[e.key], h = f) i = i.total ? 100 / i.total : 0, h[0] = ea(h[0] * i), h[1] = ea(h[1] * i), a.stackedYData[g] = h[1]
                })
            };
                            R.prototype.getStackIndicator = function (a, b, c) {
                                !q(a) || a.x !== b ? a = {
                                    x: b,
                                    index: 0
                                } : a.index++;
                                a.key = [c, b, a.index].join(",");
                                return a
                            };
                            t(E.prototype, {
                                addSeries: function (a, b, c) {
                                    var d, e = this;
                                    a && (b = p(b, !0), J(e, "addSeries", {
                                        options: a
                                    }, function () {
                                        d = e.initSeries(a);
                                        e.isDirtyLegend = !0;
                                        e.linkSeries();
                                        b && e.redraw(c)
                                    }));
                                    return d
                                },
                                addAxis: function (a, b, c, d) {
                                    var e = b ? "xAxis" : "yAxis",
                f = this.options;
                                    new ha(this, D(a, {
                                        index: this[e].length,
                                        isX: b
                                    }));
                                    f[e] = ra(f[e] || {});
                                    f[e].push(a);
                                    p(c, !0) && this.redraw(d)
                                },
                                showLoading: function (a) {
                                    var b = this,
                c = b.options,
                d = b.loadingDiv,
                e = c.loading,
                f = function () {
                    d && M(d, {
                        left: b.plotLeft + "px",
                        top: b.plotTop + "px",
                        width: b.plotWidth + "px",
                        height: b.plotHeight + "px"
                    })
                };
                                    if (!d) b.loadingDiv = d = $(Ja, {
                                        className: "highcharts-loading"
                                    },
                t(e.style, {
                    zIndex: 10,
                    display: P
                }), b.container), b.loadingSpan = $("span", null, e.labelStyle, d), I(b, "redraw", f);
                                    b.loadingSpan.innerHTML = a || c.lang.loading;
                                    if (!b.loadingShown) M(d, {
                                        opacity: 0,
                                        display: ""
                                    }), lb(d, {
                                        opacity: e.style.opacity
                                    }, {
                                        duration: e.showDuration || 0
                                    }), b.loadingShown = !0;
                                    f()
                                },
                                hideLoading: function () {
                                    var a = this.options,
                b = this.loadingDiv;
                                    b && lb(b, {
                                        opacity: 0
                                    }, {
                                        duration: a.loading.hideDuration || 100,
                                        complete: function () {
                                            M(b, {
                                                display: P
                                            })
                                        }
                                    });
                                    this.loadingShown = !1
                                }
                            });
                            t(Fa.prototype, {
                                update: function (a, b, c, d) {
                                    function e() {
                                        f.applyOptions(a);
                                        if (f.y === null && h) f.graphic = h.destroy();
                                        if (da(a) && !Ga(a)) f.redraw = function () {
                                            if (h && h.element && a && a.marker && a.marker.symbol) f.graphic = h.destroy();
                                            if (a && a.dataLabels && f.dataLabel) f.dataLabel = f.dataLabel.destroy();
                                            f.redraw = null
                                        };
                                        i = f.index;
                                        g.updateParallelArrays(f, i);
                                        if (m && f.name) m[f.x] = f.name;
                                        k.data[i] = f.options;
                                        g.isDirty = g.isDirtyData = !0;
                                        if (!g.fixedBox && g.hasCartesianSeries) j.isDirtyBox = !0;
                                        if (k.legendType === "point") j.isDirtyLegend = !0;
                                        b && j.redraw(c)
                                    }
                                    var f = this,
                g = f.series,
                h = f.graphic,
                i, j = g.chart,
                k = g.options,
                m = g.xAxis && g.xAxis.names,
                b = p(b, !0);
                                    d === !1 ? e() : f.firePointEvent("update", {
                                        options: a
                                    }, e)
                                },
                                remove: function (a, b) {
                                    this.series.removePoint(La(this, this.series.data), a, b)
                                }
                            });
                            t(R.prototype, {
                                addPoint: function (a, b, c, d) {
                                    var e = this,
                f = e.options,
                g = e.data,
                h = e.graph,
                i = e.area,
                j = e.chart,
                k = e.xAxis && e.xAxis.names,
                m = h && h.shift || 0,
                n = ["graph", "area"],
                h = f.data,
                l, u = e.xData;
                                    Ra(d, j);
                                    if (c) {
                                        for (d = e.zones.length; d--; ) n.push("zoneGraph" + d, "zoneArea" + d);
                                        o(n, function (a) {
                                            if (e[a]) e[a].shift = m + (f.step ? 2 : 1)
                                        })
                                    }
                                    if (i) i.isArea = !0;
                                    b = p(b, !0);
                                    i = {
                                        series: e
                                    };
                                    e.pointClass.prototype.applyOptions.apply(i, [a]);
                                    n = i.x;
                                    d = u.length;
                                    if (e.requireSorting && n < u[d - 1])
                                        for (l = !0; d && u[d - 1] > n; ) d--;
                                    e.updateParallelArrays(i, "splice", d, 0, 0);
                                    e.updateParallelArrays(i, d);
                                    if (k && i.name) k[n] = i.name;
                                    h.splice(d, 0, a);
                                    l && (e.data.splice(d, 0, null), e.processData());
                                    f.legendType === "point" && e.generatePoints();
                                    c && (g[0] && g[0].remove ? g[0].remove(!1) : (g.shift(), e.updateParallelArrays(i, "shift"), h.shift()));
                                    e.isDirty = !0;
                                    e.isDirtyData = !0;
                                    b && (e.getAttribs(), j.redraw())
                                },
                                removePoint: function (a,
            b, c) {
                                    var d = this,
                e = d.data,
                f = e[a],
                g = d.points,
                h = d.chart,
                i = function () {
                    e.length === g.length && g.splice(a, 1);
                    e.splice(a, 1);
                    d.options.data.splice(a, 1);
                    d.updateParallelArrays(f || {
                        series: d
                    }, "splice", a, 1);
                    f && f.destroy();
                    d.isDirty = !0;
                    d.isDirtyData = !0;
                    b && h.redraw()
                };
                                    Ra(c, h);
                                    b = p(b, !0);
                                    f ? f.firePointEvent("remove", null, i) : i()
                                },
                                remove: function (a, b) {
                                    var c = this,
                d = c.chart,
                a = p(a, !0);
                                    if (!c.isRemoving) c.isRemoving = !0, J(c, "remove", null, function () {
                                        c.destroy();
                                        d.isDirtyLegend = d.isDirtyBox = !0;
                                        d.linkSeries();
                                        a && d.redraw(b)
                                    });
                                    c.isRemoving = !1
                                },
                                update: function (a, b) {
                                    var c = this,
                d = this.chart,
                e = this.userOptions,
                f = this.type,
                g = N[f].prototype,
                h = ["group", "markerGroup", "dataLabelsGroup"],
                i;
                                    if (a.type && a.type !== f || a.zIndex !== void 0) h.length = 0;
                                    o(h, function (a) {
                                        h[a] = c[a];
                                        delete c[a]
                                    });
                                    a = D(e, {
                                        animation: !1,
                                        index: this.index,
                                        pointStart: this.xData[0]
                                    }, {
                                        data: this.options.data
                                    }, a);
                                    this.remove(!1);
                                    for (i in g) this[i] = x;
                                    t(this, N[a.type || f].prototype);
                                    o(h, function (a) {
                                        c[a] = h[a]
                                    });
                                    this.init(d, a);
                                    d.linkSeries();
                                    p(b, !0) && d.redraw(!1)
                                }
                            });
                            t(ha.prototype, {
                                update: function (a, b) {
                                    var c = this.chart,
                a = c.options[this.coll][this.options.index] = D(this.userOptions, a);
                                    this.destroy(!0);
                                    this._addedPlotLB = this.chart._labelPanes = x;
                                    this.init(c, t(a, {
                                        events: x
                                    }));
                                    c.isDirtyBox = !0;
                                    p(b, !0) && c.redraw()
                                },
                                remove: function (a) {
                                    for (var b = this.chart, c = this.coll, d = this.series, e = d.length; e--; ) d[e] && d[e].remove(!1);
                                    ja(b.axes, this);
                                    ja(b[c], this);
                                    b.options[c].splice(this.options.index, 1);
                                    o(b[c], function (a, b) {
                                        a.options.index = b
                                    });
                                    this.destroy();
                                    b.isDirtyBox = !0;
                                    p(a, !0) && b.redraw()
                                },
                                setTitle: function (a,
            b) {
                                    this.update({
                                        title: a
                                    }, b)
                                },
                                setCategories: function (a, b) {
                                    this.update({
                                        categories: a
                                    }, b)
                                }
                            });
                            var xa = ka(R);
                            N.line = xa;
                            ba.area = D(U, {
                                softThreshold: !1,
                                threshold: 0
                            });
                            var pa = ka(R, {
                                type: "area",
                                getSegments: function () {
                                    var a = this,
                b = [],
                c = [],
                d = [],
                e = this.xAxis,
                f = this.yAxis,
                g = f.stacks[this.stackKey],
                h = {},
                i, j, k = this.points,
                m = this.options.connectNulls,
                n, l, p;
                                    if (this.options.stacking && !this.cropped) {
                                        for (l = 0; l < k.length; l++) h[k[l].x] = k[l];
                                        for (p in g) g[p].total !== null && d.push(+p);
                                        d.sort(function (a, b) {
                                            return a - b
                                        });
                                        o(d, function (b) {
                                            var d =
                        null,
                        k;
                                            if (!m || h[b] && h[b].y !== null)
                                                if (h[b]) c.push(h[b]);
                                                else {
                                                    for (l = a.index; l <= f.series.length; l++)
                                                        if (n = a.getStackIndicator(null, b, l), k = g[b].points[n.key]) {
                                                            d = k[1];
                                                            break
                                                        }
                                                    i = e.translate(b);
                                                    j = f.getThreshold(d);
                                                    c.push({
                                                        y: null,
                                                        plotX: i,
                                                        clientX: i,
                                                        plotY: j,
                                                        yBottom: j,
                                                        onMouseOver: ua
                                                    })
                                                }
                                        });
                                        c.length && b.push(c)
                                    } else R.prototype.getSegments.call(this), b = this.segments;
                                    this.segments = b
                                },
                                getSegmentPath: function (a) {
                                    var b = R.prototype.getSegmentPath.call(this, a),
                c = [].concat(b),
                d, e = this.options;
                                    d = b.length;
                                    var f = this.yAxis.getThreshold(e.threshold),
                g;
                                    d === 3 && c.push("L", b[1], b[2]);
                                    if (e.stacking && !this.closedStacks)
                                        for (d = a.length - 1; d >= 0; d--) g = p(a[d].yBottom, f), d < a.length - 1 && e.step && c.push(a[d + 1].plotX, g), c.push(a[d].plotX, g);
                                    else this.closeSegment(c, a, f);
                                    this.areaPath = this.areaPath.concat(c);
                                    return b
                                },
                                closeSegment: function (a, b, c) {
                                    a.push("L", b[b.length - 1].plotX, c, "L", b[0].plotX, c)
                                },
                                drawGraph: function () {
                                    this.areaPath = [];
                                    R.prototype.drawGraph.apply(this);
                                    var a = this,
                b = this.areaPath,
                c = this.options,
                d = [
                    ["area", this.color, c.fillColor]
                ];
                                    o(this.zones, function (b,
                f) {
                                        d.push(["zoneArea" + f, b.color || a.color, b.fillColor || c.fillColor])
                                    });
                                    o(d, function (d) {
                                        var f = d[0],
                    g = a[f];
                                        g ? g.animate({
                                            d: b
                                        }) : a[f] = a.chart.renderer.path(b).attr({
                                            fill: p(d[2], na(d[1]).setOpacity(p(c.fillOpacity, 0.75)).get()),
                                            zIndex: 0
                                        }).add(a.group)
                                    })
                                },
                                drawLegendSymbol: Ma.drawRectangle
                            });
                            N.area = pa;
                            ba.spline = D(U);
                            xa = ka(R, {
                                type: "spline",
                                getPointSpline: function (a, b, c) {
                                    var d = b.plotX,
                e = b.plotY,
                f = a[c - 1],
                g = a[c + 1],
                h, i, j, k;
                                    if (f && g) {
                                        a = f.plotY;
                                        j = g.plotX;
                                        var g = g.plotY,
                    m;
                                        h = (1.5 * d + f.plotX) / 2.5;
                                        i = (1.5 * e + a) / 2.5;
                                        j = (1.5 *
                    d + j) / 2.5;
                                        k = (1.5 * e + g) / 2.5;
                                        m = (k - i) * (j - d) / (j - h) + e - k;
                                        i += m;
                                        k += m;
                                        i > a && i > e ? (i = s(a, e), k = 2 * e - i) : i < a && i < e && (i = z(a, e), k = 2 * e - i);
                                        k > g && k > e ? (k = s(g, e), i = 2 * e - k) : k < g && k < e && (k = z(g, e), i = 2 * e - k);
                                        b.rightContX = j;
                                        b.rightContY = k
                                    }
                                    c ? (b = ["C", f.rightContX || f.plotX, f.rightContY || f.plotY, h || d, i || e, d, e], f.rightContX = f.rightContY = null) : b = ["M", d, e];
                                    return b
                                }
                            });
                            N.spline = xa;
                            ba.areaspline = D(ba.area);
                            pa = pa.prototype;
                            xa = ka(xa, {
                                type: "areaspline",
                                closedStacks: !0,
                                getSegmentPath: pa.getSegmentPath,
                                closeSegment: pa.closeSegment,
                                drawGraph: pa.drawGraph,
                                drawLegendSymbol: Ma.drawRectangle
                            });
                            N.areaspline = xa;
                            ba.column = D(U, {
                                borderColor: "#FFFFFF",
                                borderRadius: 0,
                                groupPadding: 0.2,
                                marker: null,
                                pointPadding: 0.1,
                                minPointLength: 0,
                                cropThreshold: 50,
                                pointRange: null,
                                states: {
                                    hover: {
                                        brightness: 0.1,
                                        shadow: !1,
                                        halo: !1
                                    },
                                    select: {
                                        color: "#C0C0C0",
                                        borderColor: "#000000",
                                        shadow: !1
                                    }
                                },
                                dataLabels: {
                                    align: null,
                                    verticalAlign: null,
                                    y: null
                                },
                                softThreshold: !1,
                                startFromThreshold: !0,
                                stickyTracking: !1,
                                tooltip: {
                                    distance: 6
                                },
                                threshold: 0
                            });
                            xa = ka(R, {
                                type: "column",
                                pointAttrToOptions: {
                                    stroke: "borderColor",
                                    fill: "color",
                                    r: "borderRadius"
                                },
                                cropShoulder: 0,
                                directTouch: !0,
                                trackerGroups: ["group", "dataLabelsGroup"],
                                negStacks: !0,
                                init: function () {
                                    R.prototype.init.apply(this, arguments);
                                    var a = this,
                b = a.chart;
                                    b.hasRendered && o(b.series, function (b) {
                                        if (b.type === a.type) b.isDirty = !0
                                    })
                                },
                                getColumnMetrics: function () {
                                    var a = this,
                b = a.options,
                c = a.xAxis,
                d = a.yAxis,
                e = c.reversed,
                f, g = {},
                h, i = 0;
                                    b.grouping === !1 ? i = 1 : o(a.chart.series, function (b) {
                                        var c = b.options,
                    e = b.yAxis;
                                        if (b.type === a.type && b.visible && d.len === e.len && d.pos === e.pos) c.stacking ?
                    (f = b.stackKey, g[f] === x && (g[f] = i++), h = g[f]) : c.grouping !== !1 && (h = i++), b.columnIndex = h
                                    });
                                    var j = z(O(c.transA) * (c.ordinalSlope || b.pointRange || c.closestPointRange || c.tickInterval || 1), c.len),
                k = j * b.groupPadding,
                m = (j - 2 * k) / i,
                b = z(b.maxPointWidth || c.len, p(b.pointWidth, m * (1 - 2 * b.pointPadding)));
                                    return a.columnMetrics = {
                                        width: b,
                                        offset: (m - b) / 2 + (k + ((e ? i - (a.columnIndex || 0) : a.columnIndex) || 0) * m - j / 2) * (e ? -1 : 1)
                                    }
                                },
                                crispCol: function (a, b, c, d) {
                                    var e = this.chart,
                f = this.borderWidth,
                g = -(f % 2 ? 0.5 : 0),
                f = f % 2 ? 0.5 : 1;
                                    e.inverted && e.renderer.isVML &&
                (f += 1);
                                    c = Math.round(a + c) + g;
                                    a = Math.round(a) + g;
                                    c -= a;
                                    g = O(b) <= 0.5;
                                    d = Math.round(b + d) + f;
                                    b = Math.round(b) + f;
                                    d -= b;
                                    g && (b -= 1, d += 1);
                                    return {
                                        x: a,
                                        y: b,
                                        width: c,
                                        height: d
                                    }
                                },
                                translate: function () {
                                    var a = this,
                b = a.chart,
                c = a.options,
                d = a.borderWidth = p(c.borderWidth, a.closestPointRange * a.xAxis.transA < 2 ? 0 : 1),
                e = a.yAxis,
                f = a.translatedThreshold = e.getThreshold(c.threshold),
                g = p(c.minPointLength, 5),
                h = a.getColumnMetrics(),
                i = h.width,
                j = a.barW = s(i, 1 + 2 * d),
                k = a.pointXOffset = h.offset;
                                    b.inverted && (f -= 0.5);
                                    c.pointPadding && (j = ta(j));
                                    R.prototype.translate.apply(a);
                                    o(a.points, function (c) {
                                        var d = z(p(c.yBottom, f), 9E4),
                    h = 999 + O(d),
                    h = z(s(-h, c.plotY), e.len + h),
                    o = c.plotX + k,
                    q = j,
                    t = z(h, d),
                    w, v = s(h, d) - t;
                                        O(v) < g && g && (v = g, w = !e.reversed && !c.negative || e.reversed && c.negative, t = O(t - f) > g ? d - g : f - (w ? g : 0));
                                        c.barX = o;
                                        c.pointWidth = i;
                                        c.tooltipPos = b.inverted ? [e.len + e.pos - b.plotLeft - h, a.xAxis.len - o - q / 2, v] : [o + q / 2, h + e.pos - b.plotTop, v];
                                        c.shapeType = "rect";
                                        c.shapeArgs = a.crispCol(o, t, q, v)
                                    })
                                },
                                getSymbol: ua,
                                drawLegendSymbol: Ma.drawRectangle,
                                drawGraph: ua,
                                drawPoints: function () {
                                    var a = this,
                b = this.chart,
                c = a.options,
                d = b.renderer,
                e = c.animationLimit || 250,
                f, g;
                                    o(a.points, function (h) {
                                        var i = h.plotY,
                    j = h.graphic;
                                        if (i !== x && !isNaN(i) && h.y !== null) f = h.shapeArgs, i = q(a.borderWidth) ? {
                                            "stroke-width": a.borderWidth
                                        } : {}, g = h.pointAttr[h.selected ? "select" : ""] || a.pointAttr[""], j ? (cb(j), j.attr(i)[b.pointCount < e ? "animate" : "attr"](D(f))) : h.graphic = d[h.shapeType](f).attr(i).attr(g).add(h.group || a.group).shadow(c.shadow, null, c.stacking && !c.borderRadius);
                                        else if (j) h.graphic = j.destroy()
                                    })
                                },
                                animate: function (a) {
                                    var b = this.yAxis,
                c = this.options,
                d = this.chart.inverted,
                e = {};
                                    if (ca) a ? (e.scaleY = 0.001, a = z(b.pos + b.len, s(b.pos, b.toPixels(c.threshold))), d ? e.translateX = a - b.len : e.translateY = a, this.group.attr(e)) : (e.scaleY = 1, e[d ? "translateX" : "translateY"] = b.pos, this.group.animate(e, this.options.animation), this.animate = null)
                                },
                                remove: function () {
                                    var a = this,
                b = a.chart;
                                    b.hasRendered && o(b.series, function (b) {
                                        if (b.type === a.type) b.isDirty = !0
                                    });
                                    R.prototype.remove.apply(a, arguments)
                                }
                            });
                            N.column = xa;
                            ba.bar = D(ba.column);
                            pa = ka(xa, {
                                type: "bar",
                                inverted: !0
                            });
                            N.bar = pa;
                            ba.scatter = D(U, {
                                lineWidth: 0,
                                marker: {
                                    enabled: !0
                                },
                                tooltip: {
                                    headerFormat: '<span style="color:{point.color}">\u25cf</span> <span style="font-size: 10px;"> {series.name}</span><br/>',
                                    pointFormat: "x: <b>{point.x}</b><br/>y: <b>{point.y}</b><br/>"
                                }
                            });
                            pa = ka(R, {
                                type: "scatter",
                                sorted: !1,
                                requireSorting: !1,
                                noSharedTooltip: !0,
                                trackerGroups: ["group", "markerGroup", "dataLabelsGroup"],
                                takeOrdinalPosition: !1,
                                kdDimensions: 2,
                                drawGraph: function () {
                                    this.options.lineWidth && R.prototype.drawGraph.call(this)
                                }
                            });
                            N.scatter =
        pa;
                            ba.pie = D(U, {
                                borderColor: "#FFFFFF",
                                borderWidth: 1,
                                center: [null, null],
                                clip: !1,
                                colorByPoint: !0,
                                dataLabels: {
                                    distance: 30,
                                    enabled: !0,
                                    formatter: function () {
                                        return this.y === null ? void 0 : this.point.name
                                    },
                                    x: 0
                                },
                                ignoreHiddenPoint: !0,
                                legendType: "point",
                                marker: null,
                                size: null,
                                showInLegend: !1,
                                slicedOffset: 10,
                                states: {
                                    hover: {
                                        brightness: 0.1,
                                        shadow: !1
                                    }
                                },
                                stickyTracking: !1,
                                tooltip: {
                                    followPointer: !0
                                }
                            });
                            U = {
                                type: "pie",
                                isCartesian: !1,
                                pointClass: ka(Fa, {
                                    init: function () {
                                        Fa.prototype.init.apply(this, arguments);
                                        var a = this,
                    b;
                                        a.name =
                    p(a.name, "Slice");
                                        b = function (b) {
                                            a.slice(b.type === "select")
                                        };
                                        I(a, "select", b);
                                        I(a, "unselect", b);
                                        return a
                                    },
                                    setVisible: function (a, b) {
                                        var c = this,
                    d = c.series,
                    e = d.chart,
                    f = d.options.ignoreHiddenPoint,
                    b = p(b, f);
                                        if (a !== c.visible) {
                                            c.visible = c.options.visible = a = a === x ? !c.visible : a;
                                            d.options.data[La(c, d.data)] = c.options;
                                            o(["graphic", "dataLabel", "connector", "shadowGroup"], function (b) {
                                                if (c[b]) c[b][a ? "show" : "hide"](!0)
                                            });
                                            c.legendItem && e.legend.colorizeItem(c, a);
                                            !a && c.state === "hover" && c.setState("");
                                            if (f) d.isDirty = !0;
                                            b && e.redraw()
                                        }
                                    },
                                    slice: function (a, b, c) {
                                        var d = this.series;
                                        Ra(c, d.chart);
                                        p(b, !0);
                                        this.sliced = this.options.sliced = a = q(a) ? a : !this.sliced;
                                        d.options.data[La(this, d.data)] = this.options;
                                        a = a ? this.slicedTranslation : {
                                            translateX: 0,
                                            translateY: 0
                                        };
                                        this.graphic.animate(a);
                                        this.shadowGroup && this.shadowGroup.animate(a)
                                    },
                                    haloPath: function (a) {
                                        var b = this.shapeArgs,
                    c = this.series.chart;
                                        return this.sliced || !this.visible ? [] : this.series.chart.renderer.symbols.arc(c.plotLeft + b.x, c.plotTop + b.y, b.r + a, b.r + a, {
                                            innerR: this.shapeArgs.r,
                                            start: b.start,
                                            end: b.end
                                        })
                                    }
                                }),
                                requireSorting: !1,
                                directTouch: !0,
                                noSharedTooltip: !0,
                                trackerGroups: ["group", "dataLabelsGroup"],
                                axisTypes: [],
                                pointAttrToOptions: {
                                    stroke: "borderColor",
                                    "stroke-width": "borderWidth",
                                    fill: "color"
                                },
                                animate: function (a) {
                                    var b = this,
                c = b.points,
                d = b.startAngleRad;
                                    if (!a) o(c, function (a) {
                                        var c = a.graphic,
                    g = a.shapeArgs;
                                        c && (c.attr({
                                            r: a.startR || b.center[3] / 2,
                                            start: d,
                                            end: d
                                        }), c.animate({
                                            r: g.r,
                                            start: g.start,
                                            end: g.end
                                        }, b.options.animation))
                                    }), b.animate = null
                                },
                                updateTotals: function () {
                                    var a, b = 0,
                c = this.points,
                d = c.length,
                e, f = this.options.ignoreHiddenPoint;
                                    for (a = 0; a < d; a++) e = c[a], b += f && !e.visible ? 0 : e.y;
                                    this.total = b;
                                    for (a = 0; a < d; a++) e = c[a], e.percentage = b > 0 && (e.visible || !f) ? e.y / b * 100 : 0, e.total = b
                                },
                                generatePoints: function () {
                                    R.prototype.generatePoints.call(this);
                                    this.updateTotals()
                                },
                                translate: function (a) {
                                    this.generatePoints();
                                    var b = 0,
                c = this.options,
                d = c.slicedOffset,
                e = d + c.borderWidth,
                f, g, h, i = c.startAngle || 0,
                j = this.startAngleRad = ma / 180 * (i - 90),
                i = (this.endAngleRad = ma / 180 * (p(c.endAngle, i + 360) - 90)) - j,
                k =
                this.points,
                m = c.dataLabels.distance,
                c = c.ignoreHiddenPoint,
                n, l = k.length,
                o;
                                    if (!a) this.center = a = this.getCenter();
                                    this.getX = function (b, c) {
                                        h = V.asin(z((b - a[1]) / (a[2] / 2 + m), 1));
                                        return a[0] + (c ? -1 : 1) * W(h) * (a[2] / 2 + m)
                                    };
                                    for (n = 0; n < l; n++) {
                                        o = k[n];
                                        f = j + b * i;
                                        if (!c || o.visible) b += o.percentage / 100;
                                        g = j + b * i;
                                        o.shapeType = "arc";
                                        o.shapeArgs = {
                                            x: a[0],
                                            y: a[1],
                                            r: a[2] / 2,
                                            innerR: a[3] / 2,
                                            start: w(f * 1E3) / 1E3,
                                            end: w(g * 1E3) / 1E3
                                        };
                                        h = (g + f) / 2;
                                        h > 1.5 * ma ? h -= 2 * ma : h < -ma / 2 && (h += 2 * ma);
                                        o.slicedTranslation = {
                                            translateX: w(W(h) * d),
                                            translateY: w(aa(h) * d)
                                        };
                                        f =
                    W(h) * a[2] / 2;
                                        g = aa(h) * a[2] / 2;
                                        o.tooltipPos = [a[0] + f * 0.7, a[1] + g * 0.7];
                                        o.half = h < -ma / 2 || h > ma / 2 ? 1 : 0;
                                        o.angle = h;
                                        e = z(e, m / 2);
                                        o.labelPos = [a[0] + f + W(h) * m, a[1] + g + aa(h) * m, a[0] + f + W(h) * e, a[1] + g + aa(h) * e, a[0] + f, a[1] + g, m < 0 ? "center" : o.half ? "right" : "left", h]
                                    }
                                },
                                drawGraph: null,
                                drawPoints: function () {
                                    var a = this,
                b = a.chart.renderer,
                c, d, e = a.options.shadow,
                f, g, h;
                                    if (e && !a.shadowGroup) a.shadowGroup = b.g("shadow").add(a.group);
                                    o(a.points, function (i) {
                                        if (i.y !== null) {
                                            d = i.graphic;
                                            g = i.shapeArgs;
                                            f = i.shadowGroup;
                                            if (e && !f) f = i.shadowGroup = b.g("shadow").add(a.shadowGroup);
                                            c = i.sliced ? i.slicedTranslation : {
                                                translateX: 0,
                                                translateY: 0
                                            };
                                            f && f.attr(c);
                                            if (d) d.setRadialReference(a.center).animate(t(g, c));
                                            else {
                                                h = {
                                                    "stroke-linejoin": "round"
                                                };
                                                if (!i.visible) h.visibility = "hidden";
                                                i.graphic = d = b[i.shapeType](g).setRadialReference(a.center).attr(i.pointAttr[i.selected ? "select" : ""]).attr(h).attr(c).add(a.group).shadow(e, f)
                                            }
                                        }
                                    })
                                },
                                searchPoint: ua,
                                sortByAngle: function (a, b) {
                                    a.sort(function (a, d) {
                                        return a.angle !== void 0 && (d.angle - a.angle) * b
                                    })
                                },
                                drawLegendSymbol: Ma.drawRectangle,
                                getCenter: Xb.getCenter,
                                getSymbol: ua
                            };
                            U = ka(R, U);
                            N.pie = U;
                            R.prototype.drawDataLabels = function () {
                                var a = this,
            b = a.options,
            c = b.cursor,
            d = b.dataLabels,
            e = a.points,
            f, g, h = a.hasRendered || 0,
            i, j, k = a.chart.renderer;
                                if (d.enabled || a._hasPointLabels) a.dlProcessOptions && a.dlProcessOptions(d), j = a.plotGroup("dataLabelsGroup", "data-labels", d.defer ? "hidden" : "visible", d.zIndex || 6), p(d.defer, !0) && (j.attr({
                                    opacity: +h
                                }), h || I(a, "afterAnimate", function () {
                                    a.visible && j.show();
                                    j[b.animation ? "animate" : "attr"]({
                                        opacity: 1
                                    }, {
                                        duration: 200
                                    })
                                })), g = d, o(e, function (e) {
                                    var h,
                l = e.dataLabel,
                o, r, s = e.connector,
                w = !0,
                v, y = {};
                                    f = e.dlOptions || e.options && e.options.dataLabels;
                                    h = p(f && f.enabled, g.enabled);
                                    if (l && !h) e.dataLabel = l.destroy();
                                    else if (h) {
                                        d = D(g, f);
                                        v = d.style;
                                        h = d.rotation;
                                        o = e.getLabelConfig();
                                        i = d.format ? Ia(d.format, o) : d.formatter.call(o, d);
                                        v.color = p(d.color, v.color, a.color, "black");
                                        if (l)
                                            if (q(i)) l.attr({
                                                text: i
                                            }), w = !1;
                                            else {
                                                if (e.dataLabel = l = l.destroy(), s) e.connector = s.destroy()
                                            } else if (q(i)) {
                                            l = {
                                                fill: d.backgroundColor,
                                                stroke: d.borderColor,
                                                "stroke-width": d.borderWidth,
                                                r: d.borderRadius ||
                            0,
                                                rotation: h,
                                                padding: d.padding,
                                                zIndex: 1
                                            };
                                            if (v.color === "contrast") y.color = d.inside || d.distance < 0 || b.stacking ? k.getContrast(e.color || a.color) : "#000000";
                                            if (c) y.cursor = c;
                                            for (r in l) l[r] === x && delete l[r];
                                            l = e.dataLabel = k[h ? "text" : "label"](i, 0, -999, d.shape, null, null, d.useHTML).attr(l).css(t(v, y)).add(j).shadow(d.shadow)
                                        }
                                        l && a.alignDataLabel(e, l, d, null, w)
                                    }
                                })
                            };
                            R.prototype.alignDataLabel = function (a, b, c, d, e) {
                                var f = this.chart,
            g = f.inverted,
            h = p(a.plotX, -999),
            i = p(a.plotY, -999),
            j = b.getBBox(),
            k = f.renderer.fontMetrics(c.style.fontSize).b,
            m = this.visible && (a.series.forceDL || f.isInsidePlot(h, w(i), g) || d && f.isInsidePlot(h, g ? d.x + 1 : d.y + d.height - 1, g));
                                if (m) d = t({
                                    x: g ? f.plotWidth - i : h,
                                    y: w(g ? f.plotHeight - h : i),
                                    width: 0,
                                    height: 0
                                }, d), t(c, {
                                    width: j.width,
                                    height: j.height
                                }), c.rotation ? (a = f.renderer.rotCorr(k, c.rotation), b[e ? "attr" : "animate"]({
                                    x: d.x + c.x + d.width / 2 + a.x,
                                    y: d.y + c.y + d.height / 2
                                }).attr({
                                    align: c.align
                                })) : (b.align(c, null, d), g = b.alignAttr, p(c.overflow, "justify") === "justify" ? this.justifyDataLabel(b, c, g, j, d, e) : p(c.crop, !0) && (m = f.isInsidePlot(g.x, g.y) &&
            f.isInsidePlot(g.x + j.width, g.y + j.height)), c.shape && b.attr({
                anchorX: a.plotX,
                anchorY: a.plotY
            }));
                                if (!m) cb(b), b.attr({
                                    y: -999
                                }), b.placed = !1
                            };
                            R.prototype.justifyDataLabel = function (a, b, c, d, e, f) {
                                var g = this.chart,
            h = b.align,
            i = b.verticalAlign,
            j, k, m = a.box ? 0 : a.padding || 0;
                                j = c.x + m;
                                if (j < 0) h === "right" ? b.align = "left" : b.x = -j, k = !0;
                                j = c.x + d.width - m;
                                if (j > g.plotWidth) h === "left" ? b.align = "right" : b.x = g.plotWidth - j, k = !0;
                                j = c.y + m;
                                if (j < 0) i === "bottom" ? b.verticalAlign = "top" : b.y = -j, k = !0;
                                j = c.y + d.height - m;
                                if (j > g.plotHeight) i === "top" ?
            b.verticalAlign = "bottom" : b.y = g.plotHeight - j, k = !0;
                                if (k) a.placed = !f, a.align(b, null, e)
                            };
                            if (N.pie) N.pie.prototype.drawDataLabels = function () {
                                var a = this,
                b = a.data,
                c, d = a.chart,
                e = a.options.dataLabels,
                f = p(e.connectorPadding, 10),
                g = p(e.connectorWidth, 1),
                h = d.plotWidth,
                i = d.plotHeight,
                j, k, m = p(e.softConnector, !0),
                n = e.distance,
                l = a.center,
                q = l[2] / 2,
                r = l[1],
                t = n > 0,
                x, v, y, D = [
                    [],
                    []
                ],
                C, B, E, G, H, F = [0, 0, 0, 0],
                M = function (a, b) {
                    return b.y - a.y
                };
                                if (a.visible && (e.enabled || a._hasPointLabels)) {
                                    R.prototype.drawDataLabels.apply(a);
                                    o(b,
                    function (a) {
                        a.dataLabel && a.visible && D[a.half].push(a)
                    });
                                    for (G = 2; G--; ) {
                                        var J = [],
                        N = [],
                        I = D[G],
                        L = I.length,
                        K;
                                        if (L) {
                                            a.sortByAngle(I, G - 0.5);
                                            for (H = b = 0; !b && I[H]; ) b = I[H] && I[H].dataLabel && (I[H].dataLabel.getBBox().height || 21), H++;
                                            if (n > 0) {
                                                v = z(r + q + n, d.plotHeight);
                                                for (H = s(0, r - q - n); H <= v; H += b) J.push(H);
                                                v = J.length;
                                                if (L > v) {
                                                    c = [].concat(I);
                                                    c.sort(M);
                                                    for (H = L; H--; ) c[H].rank = H;
                                                    for (H = L; H--; ) I[H].rank >= v && I.splice(H, 1);
                                                    L = I.length
                                                }
                                                for (H = 0; H < L; H++) {
                                                    c = I[H];
                                                    y = c.labelPos;
                                                    c = 9999;
                                                    var Q, P;
                                                    for (P = 0; P < v; P++) Q = O(J[P] - y[1]), Q < c && (c = Q,
                                    K = P);
                                                    if (K < H && J[H] !== null) K = H;
                                                    else
                                                        for (v < L - H + K && J[H] !== null && (K = v - L + H); J[K] === null; ) K++;
                                                    N.push({
                                                        i: K,
                                                        y: J[K]
                                                    });
                                                    J[K] = null
                                                }
                                                N.sort(M)
                                            }
                                            for (H = 0; H < L; H++) {
                                                c = I[H];
                                                y = c.labelPos;
                                                x = c.dataLabel;
                                                E = c.visible === !1 ? "hidden" : "inherit";
                                                c = y[1];
                                                if (n > 0) {
                                                    if (v = N.pop(), K = v.i, B = v.y, c > B && J[K + 1] !== null || c < B && J[K - 1] !== null) B = z(s(0, c), d.plotHeight)
                                                } else B = c;
                                                C = e.justify ? l[0] + (G ? -1 : 1) * (q + n) : a.getX(B === r - q - n || B === r + q + n ? c : B, G);
                                                x._attr = {
                                                    visibility: E,
                                                    align: y[6]
                                                };
                                                x._pos = {
                                                    x: C + e.x + ({
                                                        left: f,
                                                        right: -f
                                                    }[y[6]] || 0),
                                                    y: B + e.y - 10
                                                };
                                                x.connX = C;
                                                x.connY =
                                B;
                                                if (this.options.size === null) v = x.width, C - v < f ? F[3] = s(w(v - C + f), F[3]) : C + v > h - f && (F[1] = s(w(C + v - h + f), F[1])), B - b / 2 < 0 ? F[0] = s(w(-B + b / 2), F[0]) : B + b / 2 > i && (F[2] = s(w(B + b / 2 - i), F[2]))
                                            }
                                        }
                                    }
                                    if (Da(F) === 0 || this.verifyDataLabelOverflow(F)) this.placeDataLabels(), t && g && o(this.points, function (b) {
                                        j = b.connector;
                                        y = b.labelPos;
                                        if ((x = b.dataLabel) && x._pos && b.visible) E = x._attr.visibility, C = x.connX, B = x.connY, k = m ? ["M", C + (y[6] === "left" ? 5 : -5), B, "C", C, B, 2 * y[2] - y[4], 2 * y[3] - y[5], y[2], y[3], "L", y[4], y[5]] : ["M", C + (y[6] === "left" ? 5 : -5), B, "L",
                        y[2], y[3], "L", y[4], y[5]
                    ], j ? (j.animate({
                        d: k
                    }), j.attr("visibility", E)) : b.connector = j = a.chart.renderer.path(k).attr({
                        "stroke-width": g,
                        stroke: e.connectorColor || b.color || "#606060",
                        visibility: E
                    }).add(a.dataLabelsGroup);
                                        else if (j) b.connector = j.destroy()
                                    })
                                }
                            }, N.pie.prototype.placeDataLabels = function () {
                                o(this.points, function (a) {
                                    var b = a.dataLabel;
                                    if (b && a.visible) (a = b._pos) ? (b.attr(b._attr), b[b.moved ? "animate" : "attr"](a), b.moved = !0) : b && b.attr({
                                        y: -999
                                    })
                                })
                            }, N.pie.prototype.alignDataLabel = ua, N.pie.prototype.verifyDataLabelOverflow =
        function (a) {
            var b = this.center,
                c = this.options,
                d = c.center,
                e = c.minSize || 80,
                f = e,
                g;
            d[0] !== null ? f = s(b[2] - s(a[1], a[3]), e) : (f = s(b[2] - a[1] - a[3], e), b[0] += (a[3] - a[1]) / 2);
            d[1] !== null ? f = s(z(f, b[2] - s(a[0], a[2])), e) : (f = s(z(f, b[2] - a[0] - a[2]), e), b[1] += (a[0] - a[2]) / 2);
            f < b[2] ? (b[2] = f, b[3] = Math.min(/%$/.test(c.innerSize || 0) ? f * parseFloat(c.innerSize || 0) / 100 : parseFloat(c.innerSize || 0), f), this.translate(b), o(this.points, function (a) {
                if (a.dataLabel) a.dataLabel._pos = null
            }), this.drawDataLabels && this.drawDataLabels()) : g = !0;
            return g
        };
                            if (N.column) N.column.prototype.alignDataLabel = function (a, b, c, d, e) {
                                var f = this.chart.inverted,
            g = a.series,
            h = a.dlBox || a.shapeArgs,
            i = p(a.below, a.plotY > p(this.translatedThreshold, g.yAxis.len)),
            j = p(c.inside, !!this.options.stacking);
                                if (h && (d = D(h), f && (d = {
                                    x: g.yAxis.len - d.y - d.height,
                                    y: g.xAxis.len - d.x - d.width,
                                    width: d.height,
                                    height: d.width
                                }), !j)) f ? (d.x += i ? 0 : d.width, d.width = 0) : (d.y += i ? d.height : 0, d.height = 0);
                                c.align = p(c.align, !f || j ? "center" : i ? "right" : "left");
                                c.verticalAlign = p(c.verticalAlign, f || j ? "middle" : i ? "top" :
            "bottom");
                                R.prototype.alignDataLabel.call(this, a, b, c, d, e)
                            };
                            (function (a) {
                                var b = a.Chart,
            c = a.each,
            d = a.pick,
            e = HighchartsAdapter.addEvent;
                                b.prototype.callbacks.push(function (a) {
                                    function b() {
                                        var e = [];
                                        c(a.series, function (a) {
                                            var b = a.options.dataLabels,
                        f = a.dataLabelCollections || ["dataLabel"];
                                            (b.enabled || a._hasPointLabels) && !b.allowOverlap && a.visible && c(f, function (b) {
                                                c(a.points, function (a) {
                                                    if (a[b]) a[b].labelrank = d(a.labelrank, a.shapeArgs && a.shapeArgs.height), e.push(a[b])
                                                })
                                            })
                                        });
                                        a.hideOverlappingLabels(e)
                                    }
                                    b();
                                    e(a, "redraw", b)
                                });
                                b.prototype.hideOverlappingLabels = function (a) {
                                    var b = a.length,
                d, e, j, k, m, n, l;
                                    for (e = 0; e < b; e++)
                                        if (d = a[e]) d.oldOpacity = d.opacity, d.newOpacity = 1;
                                    a.sort(function (a, b) {
                                        return (b.labelrank || 0) - (a.labelrank || 0)
                                    });
                                    for (e = 0; e < b; e++) {
                                        j = a[e];
                                        for (d = e + 1; d < b; ++d)
                                            if (k = a[d], j && k && j.placed && k.placed && j.newOpacity !== 0 && k.newOpacity !== 0 && (m = j.alignAttr, n = k.alignAttr, l = 2 * (j.box ? 0 : j.padding), m = !(n.x > m.x + (j.width - l) || n.x + (k.width - l) < m.x || n.y > m.y + (j.height - l) || n.y + (k.height - l) < m.y))) (j.labelrank < k.labelrank ?
                        j : k).newOpacity = 0
                                        }
                                        c(a, function (a) {
                                            var b, c;
                                            if (a) {
                                                c = a.newOpacity;
                                                if (a.oldOpacity !== c && a.placed) c ? a.show(!0) : b = function () {
                                                    a.hide()
                                                }, a.alignAttr.opacity = c, a[a.isOld ? "animate" : "attr"](a.alignAttr, null, b);
                                                a.isOld = !0
                                            }
                                        })
                                    }
                                })(B);
                                U = B.TrackerMixin = {
                                    drawTrackerPoint: function () {
                                        var a = this,
                b = a.chart,
                c = b.pointer,
                d = a.options.cursor,
                e = d && {
                    cursor: d
                },
                f = function (a) {
                    for (var c = a.target, d; c && !d; ) d = c.point, c = c.parentNode;
                    if (d !== x && d !== b.hoverPoint) d.onMouseOver(a)
                };
                                        o(a.points, function (a) {
                                            if (a.graphic) a.graphic.element.point =
                    a;
                                            if (a.dataLabel) a.dataLabel.element.point = a
                                        });
                                        if (!a._hasTracking) o(a.trackerGroups, function (b) {
                                            if (a[b] && (a[b].addClass("highcharts-tracker").on("mouseover", f).on("mouseout", function (a) {
                                                c.onTrackerMouseOut(a)
                                            }).css(e), ab)) a[b].on("touchstart", f)
                                        }), a._hasTracking = !0
                                    },
                                    drawTrackerGraph: function () {
                                        var a = this,
                b = a.options,
                c = b.trackByArea,
                d = [].concat(c ? a.areaPath : a.graphPath),
                e = d.length,
                f = a.chart,
                g = f.pointer,
                h = f.renderer,
                i = f.options.tooltip.snap,
                j = a.tracker,
                k = b.cursor,
                m = k && {
                    cursor: k
                },
                k = a.singlePoints,
                n,
                l = function () {
                    if (f.hoverSeries !== a) a.onMouseOver()
                },
                p = "rgba(192,192,192," + (ca ? 1.0E-4 : 0.002) + ")";
                                        if (e && !c)
                                            for (n = e + 1; n--; ) d[n] === "M" && d.splice(n + 1, 0, d[n + 1] - i, d[n + 2], "L"), (n && d[n] === "M" || n === e) && d.splice(n, 0, "L", d[n - 2] + i, d[n - 1]);
                                        for (n = 0; n < k.length; n++) e = k[n], d.push("M", e.plotX - i, e.plotY, "L", e.plotX + i, e.plotY);
                                        j ? j.attr({
                                            d: d
                                        }) : (a.tracker = h.path(d).attr({
                                            "stroke-linejoin": "round",
                                            visibility: a.visible ? "visible" : "hidden",
                                            stroke: p,
                                            fill: c ? p : P,
                                            "stroke-width": b.lineWidth + (c ? 0 : 2 * i),
                                            zIndex: 2
                                        }).add(a.group), o([a.tracker,
                a.markerGroup
            ], function (a) {
                a.addClass("highcharts-tracker").on("mouseover", l).on("mouseout", function (a) {
                    g.onTrackerMouseOut(a)
                }).css(m);
                if (ab) a.on("touchstart", l)
            }))
                                    }
                                };
                                if (N.column) xa.prototype.drawTracker = U.drawTrackerPoint;
                                if (N.pie) N.pie.prototype.drawTracker = U.drawTrackerPoint;
                                if (N.scatter) pa.prototype.drawTracker = U.drawTrackerPoint;
                                t(mb.prototype, {
                                    setItemEvents: function (a, b, c, d, e) {
                                        var f = this;
                                        (c ? b : a.legendGroup).on("mouseover", function () {
                                            a.setState("hover");
                                            b.css(f.options.itemHoverStyle)
                                        }).on("mouseout",
                function () {
                    b.css(a.visible ? d : e);
                    a.setState()
                }).on("click", function (b) {
                    var c = function () {
                        a.setVisible && a.setVisible()
                    },
                    b = {
                        browserEvent: b
                    };
                    a.firePointEvent ? a.firePointEvent("legendItemClick", b, c) : J(a, "legendItemClick", b, c)
                })
                                    },
                                    createCheckboxForItem: function (a) {
                                        a.checkbox = $("input", {
                                            type: "checkbox",
                                            checked: a.selected,
                                            defaultChecked: a.selected
                                        }, this.options.itemCheckboxStyle, this.chart.container);
                                        I(a.checkbox, "click", function (b) {
                                            J(a.series || a, "checkboxClick", {
                                                checked: b.target.checked,
                                                item: a
                                            }, function () {
                                                a.select()
                                            })
                                        })
                                    }
                                });
                                S.legend.itemStyle.cursor = "pointer";
                                t(E.prototype, {
                                    showResetZoom: function () {
                                        var a = this,
                b = S.lang,
                c = a.options.chart.resetZoomButton,
                d = c.theme,
                e = d.states,
                f = c.relativeTo === "chart" ? null : "plotBox";
                                        this.resetZoomButton = a.renderer.button(b.resetZoom, null, null, function () {
                                            a.zoomOut()
                                        }, d, e && e.hover).attr({
                                            align: c.position.align,
                                            title: b.resetZoomTitle
                                        }).add().align(c.position, !1, f)
                                    },
                                    zoomOut: function () {
                                        var a = this;
                                        J(a, "selection", {
                                            resetSelection: !0
                                        }, function () {
                                            a.zoom()
                                        })
                                    },
                                    zoom: function (a) {
                                        var b, c = this.pointer,
                d = !1,
                e;
                                        !a || a.resetSelection ? o(this.axes, function (a) {
                                            b = a.zoom()
                                        }) : o(a.xAxis.concat(a.yAxis), function (a) {
                                            var e = a.axis,
                    h = e.isXAxis;
                                            if (c[h ? "zoomX" : "zoomY"] || c[h ? "pinchX" : "pinchY"]) b = e.zoom(a.min, a.max), e.displayBtn && (d = !0)
                                        });
                                        e = this.resetZoomButton;
                                        if (d && !e) this.showResetZoom();
                                        else if (!d && da(e)) this.resetZoomButton = e.destroy();
                                        b && this.redraw(p(this.options.chart.animation, a && a.animation, this.pointCount < 100))
                                    },
                                    pan: function (a, b) {
                                        var c = this,
                d = c.hoverPoints,
                e;
                                        d && o(d, function (a) {
                                            a.setState()
                                        });
                                        o(b === "xy" ? [1, 0] : [1], function (b) {
                                            var d = a[b ? "chartX" : "chartY"],
                    h = c[b ? "xAxis" : "yAxis"][0],
                    i = c[b ? "mouseDownX" : "mouseDownY"],
                    j = (h.pointRange || 0) / 2,
                    k = h.getExtremes(),
                    m = h.toValue(i - d, !0) + j,
                    j = h.toValue(i + c[b ? "plotWidth" : "plotHeight"] - d, !0) - j,
                    i = i > d;
                                            if (h.series.length && (i || m > z(k.dataMin, k.min)) && (!i || j < s(k.dataMax, k.max))) h.setExtremes(m, j, !1, !1, {
                                                trigger: "pan"
                                            }), e = !0;
                                            c[b ? "mouseDownX" : "mouseDownY"] = d
                                        });
                                        e && c.redraw(!1);
                                        M(c.container, {
                                            cursor: "move"
                                        })
                                    }
                                });
                                t(Fa.prototype, {
                                    select: function (a, b) {
                                        var c = this,
                d = c.series,
                e = d.chart,
                a = p(a, !c.selected);
                                        c.firePointEvent(a ? "select" : "unselect", {
                                            accumulate: b
                                        }, function () {
                                            c.selected = c.options.selected = a;
                                            d.options.data[La(c, d.data)] = c.options;
                                            c.setState(a && "select");
                                            b || o(e.getSelectedPoints(), function (a) {
                                                if (a.selected && a !== c) a.selected = a.options.selected = !1, d.options.data[La(a, d.data)] = a.options, a.setState(""), a.firePointEvent("unselect")
                                            })
                                        })
                                    },
                                    onMouseOver: function (a, b) {
                                        var c = this.series,
                d = c.chart,
                e = d.tooltip,
                f = d.hoverPoint;
                                        if (d.hoverSeries !== c) c.onMouseOver();
                                        if (f && f !== this) f.onMouseOut();
                                        if (this.series && (this.firePointEvent("mouseOver"), e && (!e.shared || c.noSharedTooltip) && e.refresh(this, a), this.setState("hover"), !b)) d.hoverPoint = this
                                    },
                                    onMouseOut: function () {
                                        var a = this.series.chart,
                b = a.hoverPoints;
                                        this.firePointEvent("mouseOut");
                                        if (!b || La(this, b) === -1) this.setState(), a.hoverPoint = null
                                    },
                                    importEvents: function () {
                                        if (!this.hasImportedEvents) {
                                            var a = D(this.series.options.point, this.options).events,
                    b;
                                            this.events = a;
                                            for (b in a) I(this, b, a[b]);
                                            this.hasImportedEvents = !0
                                        }
                                    },
                                    setState: function (a, b) {
                                        var c =
                T(this.plotX),
                d = this.plotY,
                e = this.series,
                f = e.options.states,
                g = ba[e.type].marker && e.options.marker,
                h = g && !g.enabled,
                i = g && g.states[a],
                j = i && i.enabled === !1,
                k = e.stateMarkerGraphic,
                m = this.marker || {},
                n = e.chart,
                l = e.halo,
                o, a = a || "";
                                        o = this.pointAttr[a] || e.pointAttr[a];
                                        if (!(a === this.state && !b || this.selected && a !== "select" || f[a] && f[a].enabled === !1 || a && (j || h && i.enabled === !1) || a && m.states && m.states[a] && m.states[a].enabled === !1)) {
                                            if (this.graphic) g = g && this.graphic.symbolName && o.r, this.graphic.attr(D(o, g ? {
                                                x: c - g,
                                                y: d -
                        g,
                                                width: 2 * g,
                                                height: 2 * g
                                            } : {})), k && k.hide();
                                            else {
                                                if (a && i)
                                                    if (g = i.radius, m = m.symbol || e.symbol, k && k.currentSymbol !== m && (k = k.destroy()), k) k[b ? "animate" : "attr"]({
                                                        x: c - g,
                                                        y: d - g
                                                    });
                                                    else if (m) e.stateMarkerGraphic = k = n.renderer.symbol(m, c - g, d - g, 2 * g, 2 * g).attr(o).add(e.markerGroup), k.currentSymbol = m;
                                                if (k) k[a && n.isInsidePlot(c, d, n.inverted) ? "show" : "hide"](), k.element.point = this
                                            }
                                            if ((c = f[a] && f[a].halo) && c.size) {
                                                if (!l) e.halo = l = n.renderer.path().add(n.seriesGroup);
                                                l.attr(t({
                                                    fill: na(this.color || e.color).setOpacity(c.opacity).get()
                                                },
                        c.attributes))[b ? "animate" : "attr"]({
                            d: this.haloPath(c.size)
                        })
                                            } else l && l.attr({
                                                d: []
                                            });
                                            this.state = a
                                        }
                                    },
                                    haloPath: function (a) {
                                        var b = this.series,
                c = b.chart,
                d = b.getPlotBox(),
                e = c.inverted;
                                        return c.renderer.symbols.circle(d.translateX + (e ? b.yAxis.len - this.plotY : this.plotX) - a, d.translateY + (e ? b.xAxis.len - this.plotX : this.plotY) - a, a * 2, a * 2)
                                    }
                                });
                                t(R.prototype, {
                                    onMouseOver: function () {
                                        var a = this.chart,
                b = a.hoverSeries;
                                        if (b && b !== this) b.onMouseOut();
                                        this.options.events.mouseOver && J(this, "mouseOver");
                                        this.setState("hover");
                                        a.hoverSeries = this
                                    },
                                    onMouseOut: function () {
                                        var a = this.options,
                b = this.chart,
                c = b.tooltip,
                d = b.hoverPoint;
                                        b.hoverSeries = null;
                                        if (d) d.onMouseOut();
                                        this && a.events.mouseOut && J(this, "mouseOut");
                                        c && !a.stickyTracking && (!c.shared || this.noSharedTooltip) && c.hide();
                                        this.setState()
                                    },
                                    setState: function (a) {
                                        var b = this.options,
                c = this.graph,
                d = b.states,
                e = b.lineWidth,
                b = 0,
                a = a || "";
                                        if (this.state !== a && (this.state = a, !(d[a] && d[a].enabled === !1) && (a && (e = d[a].lineWidth || e + (d[a].lineWidthPlus || 0)), c && !c.dashstyle))) {
                                            a = {
                                                "stroke-width": e
                                            };
                                            for (c.attr(a); this["zoneGraph" + b]; ) this["zoneGraph" + b].attr(a), b += 1
                                        }
                                    },
                                    setVisible: function (a, b) {
                                        var c = this,
                d = c.chart,
                e = c.legendItem,
                f, g = d.options.chart.ignoreHiddenSeries,
                h = c.visible;
                                        f = (c.visible = a = c.userOptions.visible = a === x ? !h : a) ? "show" : "hide";
                                        o(["group", "dataLabelsGroup", "markerGroup", "tracker"], function (a) {
                                            if (c[a]) c[a][f]()
                                        });
                                        if (d.hoverSeries === c || (d.hoverPoint && d.hoverPoint.series) === c) c.onMouseOut();
                                        e && d.legend.colorizeItem(c, a);
                                        c.isDirty = !0;
                                        c.options.stacking && o(d.series, function (a) {
                                            if (a.options.stacking &&
                    a.visible) a.isDirty = !0
                                        });
                                        o(c.linkedSeries, function (b) {
                                            b.setVisible(a, !1)
                                        });
                                        if (g) d.isDirtyBox = !0;
                                        b !== !1 && d.redraw();
                                        J(c, f)
                                    },
                                    show: function () {
                                        this.setVisible(!0)
                                    },
                                    hide: function () {
                                        this.setVisible(!1)
                                    },
                                    select: function (a) {
                                        this.selected = a = a === x ? !this.selected : a;
                                        if (this.checkbox) this.checkbox.checked = a;
                                        J(this, a ? "select" : "unselect")
                                    },
                                    drawTracker: U.drawTrackerGraph
                                });
                                t(B, {
                                    Color: na,
                                    Point: Fa,
                                    Tick: Sa,
                                    Renderer: $a,
                                    SVGElement: Q,
                                    SVGRenderer: Aa,
                                    arrayMin: Oa,
                                    arrayMax: Da,
                                    charts: X,
                                    dateFormat: Na,
                                    error: la,
                                    format: Ia,
                                    pathAnim: yb,
                                    getOptions: function () {
                                        return S
                                    },
                                    hasBidiBug: Nb,
                                    isTouchDevice: Jb,
                                    setOptions: function (a) {
                                        S = D(!0, S, a);
                                        Cb();
                                        return S
                                    },
                                    addEvent: I,
                                    removeEvent: Y,
                                    createElement: $,
                                    discardElement: Qa,
                                    css: M,
                                    each: o,
                                    map: Ua,
                                    merge: D,
                                    splat: ra,
                                    extendClass: ka,
                                    pInt: G,
                                    svg: ca,
                                    canvas: fa,
                                    vml: !ca && !fa,
                                    product: "Highcharts",
                                    version: "4.1.9"
                                })
                            })();