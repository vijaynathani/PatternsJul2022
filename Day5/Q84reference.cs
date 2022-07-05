class JFrame {
}
class Font {
}
class JDialog { //..
}
/* This is a word processor application. It can let the user select the
 * font. Before the user confirms to change the font, it will let the
 * user preview the effect of the change. The current code is shown below.
 * Point out the code smell. If we need to reuse the ChooseFontDialog
 * in a GUI application that doesn't support this preview functionality,
 * how should you change the code?
 */
class WordProcessorMainFrame : JFrame {
    void onChangeFont() {
        ChooseFontDialog chooseFontDialog = new ChooseFontDialog(this);
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
    WordProcessorMainFrame mainFrame;
    Font selectedFont;
    public ChooseFontDialog(WordProcessorMainFrame mainFrame) {
        this.mainFrame = mainFrame;
    }
    public bool showOnScreen() {
        //...
		return false;
    }
    public void onSelectedFontChange() {
        selectedFont = getSelectedFontFromUI();
        mainFrame.previewWithFont(selectedFont);
    }
    public Font getSelectedFontFromUI() { //...
		return null;
    }
    public Font getSelectedFont() {
        return selectedFont;
    }
}
