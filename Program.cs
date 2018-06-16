using System;
using System.Windows.Forms;

namespace WinDispSleep {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			new Sleeper();
			Application.Run();
		}
	}
}
