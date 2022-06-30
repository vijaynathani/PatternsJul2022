using System;
class Participant { //...
	public string getEFullName() { //..
		return null; 
	}
	public string getCFullName() { //..
		return null; 
	}
	public string getCFirstName() { //..
		return null; 
	}
}
class ParticipantsInDB { //..
	public static ParticipantsInDB getInstance() { //..
		return null;
	}
	public Participant locateParticipant(string pid) { //..
		return null;
	}
}
class Address { 
	public string getCountry() { //..
		return null;
	}
}
class Organization { //..
	public string eName, cName;        //getter funcions not written
	public Address eAddress, cAddress; //for brevity
}
class OrganizationsInDB { //..
	public static OrganizationsInDB getInstance() { //..
		return null;
	}
	public string findOrganizationEmploying (string pid) { //..
		return null;
	}
	public Organization locateOrganization(string oid) { //..
		return null;
	}
}

public class ParticipantInfoOnBadge {
    string participantId;
    string participantEngFullName;
    string participantChiFullName;
    string engOrgName;
    string chiOrgName;
    string engOrgCountry;
    string chiOrgCountry;

    public ParticipantInfoOnBadge(string participantId) {
        loadInfoFromDB(participantId);
    }
    void loadInfoFromDB(string participantId) {
        this.participantId = participantId;
        getParticipantFullNames();
        getOrgNameAndCountry();
    }
    void getParticipantFullNames() {
        ParticipantsInDB partsInDB = ParticipantsInDB.getInstance();
        Participant part = partsInDB.locateParticipant(participantId);
        if (part != null) {
            participantEngFullName = part.getEFullName();
            participantChiFullName = part.getCFullName();
        }
    }
    void getOrgNameAndCountry() {
        OrganizationsInDB orgsInDB = OrganizationsInDB.getInstance();
        string oid = orgsInDB.findOrganizationEmploying(participantId);
        if (oid != null) {
            Organization org = orgsInDB.locateOrganization(oid);
            engOrgName = org.eName;
            chiOrgName = org.cName;
            engOrgCountry = org.eAddress.getCountry();
            chiOrgCountry = org.cAddress.getCountry();
        }
    }
}
