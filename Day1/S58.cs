using System.Collections.Generic;
class InetAddress { //..
}

class Server {
	string name;
	string CPUModel;
	int RAMSizeInMB;
	int diskSizeInMB;
	InetAddress ipAddress;
}
class Administrator {
	string adminId;
	Server[] serversAdminedByHim;
}
class DHCPConfig {
	InetAddress startIP;
	InetAddress endIP;
}
class FileServerConfig {
	Dictionary<string,int> userIdToQuota;
	int getQuotaForUser(string userId) {
		//...
	}
	void setQuotaForUser(string userId, int quota) {
		//...
	}
}
class ServerConfigSystem {
	Server[] servers;
	Administrator[] admins;
	Dictionary<Server,DHCPConfig> DHCPservers;
	Dictionary<Server,FileServerConfig> FileServers;
}
