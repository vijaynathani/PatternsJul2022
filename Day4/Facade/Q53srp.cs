using System;
using System.Collections.Generic;
//Improve the code
class PianoKey {
    const int key0 = 0;
    const int key1 = 1;
    const int key2 = 2;
    int keyNumber;
    public void playSound() {
        if (keyNumber == 0) {
            //play the frequency for key0
        }
        else if (keyNumber == 1) {
            //play the frequency for key1
        }
        else if (keyNumber == 2) {
            //play the frequency for key2
        }
    }
	//Function to set keyNumber to key0, key1 or key2
}
class Piano {
    List<PianoKey> rythmn;
    public void play() {
        for(int i=0;i<rythmn.Count;i++)
            rythmn[i].playSound();
    }
}
