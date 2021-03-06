/* globals $ */

var smapi = smapi || {};
var app;
smapi.modList = function (mods) {
    // init data
    var data = {
        mods: mods,
        visibleCount: mods.length,
        showAdvanced: false,
        filters: {
            source: {
                open: {
                    label: "open",
                    id: "show-open-source",
                    value: true
                },
                closed: {
                    label: "closed",
                    id: "show-closed-source",
                    value: true
                }
            },
            status: {
                ok: {
                    label: "ok",
                    id: "show-status-ok",
                    value: true
                },
                optional: {
                    label: "optional",
                    id: "show-status-optional",
                    value: true
                },
                unofficial: {
                    label: "unofficial",
                    id: "show-status-unofficial",
                    value: true
                },
                workaround: {
                    label: "workaround",
                    id: "show-status-workaround",
                    value: true
                },
                broken: {
                    label: "broken",
                    id: "show-status-broken",
                    value: true
                },
                abandoned: {
                    label: "abandoned",
                    id: "show-status-abandoned",
                    value: true
                },
                obsolete: {
                    label: "obsolete",
                    id: "show-status-obsolete",
                    value: true
                }
            },
            download: {
                chucklefish: {
                    label: "Chucklefish",
                    id: "show-chucklefish",
                    value: true
                },
                nexus: {
                    label: "Nexus",
                    id: "show-nexus",
                    value: true
                },
                custom: {
                    label: "custom",
                    id: "show-custom",
                    value: true
                }
            }
        },
        search: ""
    };
    for (var i = 0; i < data.mods.length; i++) {
        var mod = mods[i];

        // set initial visibility
        mod.Visible = true;

        // concatenate searchable text
        mod.SearchableText = [mod.Name, mod.AlternateNames, mod.Author, mod.AlternateAuthors, mod.Compatibility.Summary, mod.BrokeIn];
        if (mod.Compatibility.UnofficialVersion)
            mod.SearchableText.push(mod.Compatibility.UnofficialVersion);
        if (mod.BetaCompatibility) {
            mod.SearchableText.push(mod.BetaCompatibility.Summary);
            if (mod.BetaCompatibility.UnofficialVersion)
                mod.SearchableText.push(mod.BetaCompatibility.UnofficialVersion);
        }
        for (var p = 0; p < mod.ModPages; p++)
            mod.SearchableField.push(mod.ModPages[p].Text);
        mod.SearchableText = mod.SearchableText.join(" ").toLowerCase();
    }

    // init app
    app = new Vue({
        el: "#app",
        data: data,
        mounted: function() {
            // enable table sorting
            $("#mod-list").tablesorter({
                cssHeader: "header",
                cssAsc: "headerSortUp",
                cssDesc: "headerSortDown"
            });

            // put focus in textbox for quick search
            if (!location.hash)
                $("#search-box").focus();

            // jump to anchor (since table is added after page load)
            if (location.hash) {
                var row = $(location.hash).get(0);
                if (row)
                    row.scrollIntoView();
            }
        },
        methods: {
            /**
             * Update the visibility of all mods based on the current search text and filters.
             */
            applyFilters: function () {
                // get search terms
                var words = data.search.toLowerCase().split(" ");

                // apply criteria
                data.visibleCount = data.mods.length;
                for (var i = 0; i < data.mods.length; i++) {
                    var mod = data.mods[i];
                    mod.Visible = true;

                    // check filters
                    if (!this.matchesFilters(mod)) {
                        mod.Visible = false;
                        data.visibleCount--;
                        continue;
                    }

                    // check search terms (all search words should match)
                    if (words.length) {
                        for (var w = 0; w < words.length; w++) {
                            if (mod.SearchableText.indexOf(words[w]) === -1) {
                                mod.Visible = false;
                                data.visibleCount--;
                                break;
                            }
                        }
                    }
                }
            },


            /**
             * Get whether a mod matches the current filters.
             * @param {object} mod The mod to check.
             * @returns {bool} Whether the mod matches the filters.
             */
            matchesFilters: function(mod) {
                var filters = data.filters;

                // check source
                if (!filters.source.open.value && mod.SourceUrl)
                    return false;
                if (!filters.source.closed.value && !mod.SourceUrl)
                    return false;

                // check status
                var status = (mod.BetaCompatibility || mod.Compatibility).Status;
                if (filters.status[status] && !filters.status[status].value)
                    return false;

                // check download sites
                var ignoreSites = [];

                if (!filters.download.chucklefish.value)
                    ignoreSites.push("Chucklefish");
                if (!filters.download.nexus.value)
                    ignoreSites.push("Nexus");
                if (!filters.download.custom.value)
                    ignoreSites.push("custom");

                if (ignoreSites.length) {
                    var anyLeft = false;
                    for (var i = 0; i < mod.ModPageSites.length; i++) {
                        if (ignoreSites.indexOf(mod.ModPageSites[i]) === -1) {
                            anyLeft = true;
                            break;
                        }
                    }

                    if (!anyLeft)
                        return false;
                }

                return true;
            }
        }
    });
};
