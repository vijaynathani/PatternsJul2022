using System;
//improve code
class ReportCatalogueIndexCommandParser {
    const string NO_GROUPING = "orgNoGrouping";
    const int ORG_CATALOG = 0;
    const int PART_CATALOG = 1;
    //.... other codes
    int getGroupingType(string grouping) {
        if (grouping.Equals(NO_GROUPING)) {
            return ORG_CATALOG;
        } else if (grouping.Equals("orgGroupByCountry")) {
            return ORG_CATALOG;
        } else if (grouping.Equals("orgGroupByTypeOfOrgName")) {
            return ORG_CATALOG;
        } else if (grouping.Equals("part")) {
            return PART_CATALOG;
        } else    // many other if statements
			//...
			//final else
            throw new Exception("Invalid grouping!");
	}
}
