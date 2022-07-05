class JFrame {
}
class Font {
}
class JDialog { //..
}

delegate void FontChangeListener(Font newFont);

class WordProcessorMainFrame : JFrame {
	void fontChanged (Font newFont) { 
		previewWithFont(newFont);
	}
	public void onChangeFont() {
		ChooseFontDialog chooseFontDialog = new ChooseFontDialog(
				fontChanged);
		if (chooseFontDialog.showOnScreen()) {
			Font newFont = chooseFontDialog.getSelectedFont();
			//show the contents using this new font.
		} else {
			//show the contents using the existing font.
		}
	}
	public void previewWithFont(Font font) {
		//show the contents using this preview font.
	}
}
class ChooseFontDialog : JDialog {
	FontChangeListener fontChangeListener;
	Font selectedFont;
	public ChooseFontDialog(FontChangeListener fontChangeListener) {
		this.fontChangeListener = fontChangeListener;
	}
	public bool showOnScreen() { //...
		return false;
	} 
	public void onSelectedFontChange() {
		selectedFont = getSelectedFontFromUI();
		fontChangeListener(selectedFont);
	}
	public Font getSelectedFontFromUI() { //...
		return null;
	}
	public Font getSelectedFont() {
		return selectedFont;
	}
}
