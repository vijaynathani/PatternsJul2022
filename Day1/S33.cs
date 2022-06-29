class SurveyDataType {
	string baseFileName;
	bool hideDataFile;
	SurveyDataType(string baseFileName, bool hideDataFile) {
		this.baseFileName = baseFileName;
		this.hideDataFile = hideDataFile;
	}
	string getSavePath() {
		return "c:/application/data/"+baseFileName+".dat";
	}
	static SurveyDataType rawDataType = new SurveyDataType(
	        "raw", true);
	static SurveyDataType cleanedUpDataType = new SurveyDataType(
	        "cleanedUp", true);
	static SurveyDataType processedDataType = new SurveyDataType(
	        "processed", true);
	static SurveyDataType publicationDataType = new SurveyDataType(
	        "publication", false);
}
