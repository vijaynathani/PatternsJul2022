using System;
class Participant { //...
	public string getELastName() { //..
		return null; 
	}
	public string getEFirstName() { //..
		return null; 
	}
	public string getCLastName() { //..
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
	public string eName, cName;
	public Address eAddress, cAddress;
}
class OrganizationsInDB { //..
	public static OrganizationsInDB getInstance() { //..
		return null;
	}
	public string getOrganization(string pid) { //..
		return null;
	}
	public Organization locateOrganization(string oid) { //..
		return null;
	}
}

//Improve the code
public class Badge {
    string pid; //participant ID
    string engName; //participant's full name in English
    string chiName; //participant's full name in Chinese
    string engOrgName; //name of the participant's organization in English
    string chiOrgName; //name of the participant's organization in Chinese
    string engCountry; //the organization's country in English
    string chiCountry; //the organization's country in Chinese
    //***********************
    //constructor.
    //The participant ID is provided. It then loads all the info from the DB.
    //***********************
    public Badge(string pid) {
        this.pid = pid;
        //***********************
        //get the participant's full names.
        //***********************
        ParticipantsInDB partsInDB = ParticipantsInDB.getInstance();
        Participant part = partsInDB.locateParticipant(pid);
        if (part != null) {
            //get the participant's full name in English.
            engName = part.getELastName() + ", " + part.getEFirstName();
            //get the participant's full name in Chinese.
            chiName = part.getCLastName()+part.getCFirstName();
            //***********************
            //get the organization's name and country.
            //***********************
            OrganizationsInDB orgsInDB = OrganizationsInDB.getInstance();
            //find the ID of the organization employing this participant.
            string oid = orgsInDB.getOrganization(pid);
            if (oid != null) {
                Organization org = orgsInDB.locateOrganization(oid);
                engOrgName = org.eName;
                chiOrgName = org.cName;
                engCountry = org.eAddress.getCountry();
                chiCountry = org.cAddress.getCountry();
            }
        }
    }
    //...
}
