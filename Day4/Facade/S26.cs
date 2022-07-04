using System;
using System.Text;
using System.Collections.Generic;
class Board {
    //...
    class Piece {
        //...
        String representation;
		String character() {
			return representation.Substring(0, 1);
		}
		public void addTo(StringBuilder buf) {
			buf.Append(character());
		}
    }
	class Location {
		//...
		public Piece current;
		public void addTo(StringBuilder buf) {
			current.addTo(buf);
		}
	}
	List<Location> squares() { //...
		return null;
	}
	String boardRepresentation() {
		StringBuilder buf = new StringBuilder();
		foreach(Location l in squares())
			l.addTo(buf);
		return buf.ToString();
	}
}
