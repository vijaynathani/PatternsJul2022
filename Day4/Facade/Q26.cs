using System;
using System.Text;
using System.Collections.Generic;
class Board {
    //...
    class Piece {
        //...
        public String representation;
    }
	class Location {
		//...
		public Piece current;
	}
	List<Location> squares() { //...
		return null;
	}
	String boardRepresentation() {
		StringBuilder buf = new StringBuilder();
		foreach(Location l in squares())
			buf.Append(l.current.representation.Substring(0, 1));
		return buf.ToString();
	}
}
