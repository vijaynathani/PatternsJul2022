using System;
using System.Collections.Generic;
class Reader {
};
class BufferedReader : Reader { //..
	public BufferedReader(Reader r) { //..
	}
}
//Improve the code
class TokenStream {
    List<string> v; //a list of tokens parsed from br.
    int index; //index of the current token in v.
    Reader br; //read the chars from here to parse the tokens.
    int currentChar; //previous char read from br.
    //read the chars from the reader and parse the tokens.
    public TokenStream(Reader read) {
        br = new BufferedReader(read);
        takeChar();
        v = parseFile();
        index=0;
    }
    //read the chars from br, parse the tokens and store them into an List
    List<string> parseFile() {
        List<string> v = null; //accumulate the tokens that have been parsed.
        //...
        return v;
    }
	void takeChar() { //...
	}
    //...
}
