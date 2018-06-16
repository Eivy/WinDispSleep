using System.Runtime.InteropServices;
namespace WinDispSleep {
	static class API {
		/// <summary>PostMessage(Windows API)</summary>
		/// <param name="hWnd">ポスト先ウインドウのハンドル</param>
		/// <param name="msg">メッセージ</param>
		/// <param name="wParam">メッセージの最初のパラメータ</param>
		/// <param name="lParam">メッセージの２番目のパラメータ</param>
		[DllImport("user32.dll")]
		static extern bool PostMessageA(uint hWnd, uint msg, uint wParam, uint lParam);

		/// <summary>LockWorkstation(Windows API)</summary>
		[DllImport("user32.dll")]
		static extern bool LockWorkStation();

		/// <summary>ディスプレイをスリープします</summary>
		public static void SleepDisplay() {
			PostMessageA(0xffff, 0x0112, 0xf170, 2);
		}

		// <summary>Windowsをロックします</summary>
		public static void Lock() {
			LockWorkStation();
		}
		
	}
}
