using System.Windows.Forms;

namespace WinDispSleep {
	public enum Mod {
		Win = Keys.LWin | Keys.RWin,
		Ctrl = Keys.LControlKey | Keys.RControlKey,
		Shift = Keys.LShiftKey | Keys.RShiftKey,
		Alt = Keys.Alt,
	}
}
