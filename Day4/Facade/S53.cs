using System;
using System.Collections.Generic;
class PianoKey {
	private const int frequency_for_key0 = 50;
	private const int frequency_for_key1 = 500;
	private const int frequency_for_key2 = 5000;
	public static readonly PianoKey key0;
	public static readonly PianoKey key1;
	public static readonly PianoKey key2;
	static PianoKey() {
		key0 = new PianoKey(frequency_for_key0);
		key1 = new PianoKey(frequency_for_key1);
		key2 = new PianoKey(frequency_for_key2);
	}
    //...
    int frequency;
    private PianoKey(int frequency) {
        this.frequency = frequency;
    }
    public void playSound() {
        //play the frequency.
    }
}
class Piano {
    List<PianoKey> rythmn;
    public void play() {
        for(int i=0;i<rythmn.Count;i++)
            rythmn[i].playSound();
    }
}
