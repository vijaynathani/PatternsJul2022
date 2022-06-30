using System;
using System.Collections.Generic;
class Reader {
};
class BufferedReader : Reader { //..
	public BufferedReader(Reader r) { //..
	}
}

class TokenStream {
    List<String> parsedTokenList;
    int currentTokenIdxInList;
    BufferedReader charInputSourceForParsing;
    int previousCharReadFromSource;
    TokenStream(Reader reader) {
        charInputSourceForParsing = new BufferedReader(reader);
        takeChar();
        parsedTokenList = parseTokensFromInputSource();
        currentTokenIdxInList = 0;
    }
    List<string> parseTokensFromInputSource() {
        List<string> tokensParsedSoFar = null; 
        //...
        return tokensParsedSoFar;
    }
	void takeChar() { //...
	}
    //...
}
