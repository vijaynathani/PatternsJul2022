using System;
using System.Collections.Generic;
class ReportCatalogueIndexCommandParser {
    const int ORG_CATALOG = 0;
    const int PART_CATALOG = 1;
    static Dictionary <string, int> catalogCodes;
    static ReportCatalogueIndexCommandParser() {
        catalogCodes = new Dictionary<string,int>();
        catalogCodes.Add("orgNoGrouping", ORG_CATALOG);
        catalogCodes.Add("orgGroupByCountry", ORG_CATALOG);
        catalogCodes.Add("orgGroupByTypeOfOrgName", ORG_CATALOG);
        catalogCodes.Add("part", PART_CATALOG);
        //...
    }
    int getGroupingType(string grouping) {
		return catalogCodes[grouping];
    }
}
