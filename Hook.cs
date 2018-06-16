using System;
using System.Runtime.InteropServices;

namespace WinDispSleep {

	/// <summary>
	/// キーボードフッククラス
	/// </summary>
	static class Hook {
		/// <summary>Win32API</summary>
		static class NativeMethods {
			/// <summary>フックプロシージャのデリゲート</summary>
			/// <param name="nCode">フックプロシージャに渡すフックコード</param>
			/// <param name="msg">フックプロシージャに渡す値</param>
			/// <param name="msllhookstruct">フックプロシージャに渡す値</param>
			/// <returns>フックチェーン内の次のフックプロシージャの戻り値</returns>
			public delegate IntPtr KeyboardHookCallback(int nCode, uint msg, ref KBDLLHOOKSTRUCT kbdllhookstruct);

			/// <summary>
			/// アプリケーション定義のフックプロシージャをフックチェーン内にインストールします。
			/// フックプロシージャをインストールすると、特定のイベントタイプを監視できます。
			/// 監視の対象になるイベントは、特定のスレッド、または呼び出し側スレッドと同じデスクトップ内のすべてのスレッドに関連付けられているものです。
			/// </summary>
			/// <param name="idHook">フックタイプ</param>
			/// <param name="lpfn">フックプロシージャ</param>
			/// <param name="hMod">アプリケーションインスタンスのハンドル</param>
			/// <param name="dwThreadId">スレッドの識別子</param>
			/// <returns>関数が成功すると、フックプロシージャのハンドルが返ります。関数が失敗すると、NULL が返ります。</returns>
			[DllImport("user32.dll")]
			public static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookCallback lpfn, IntPtr hMod, uint dwThreadId);

			/// <summary>
			/// 現在のフックチェーン内の次のフックプロシージャに、フック情報を渡します。
			/// フックプロシージャは、フック情報を処理する前でも、フック情報を処理した後でも、この関数を呼び出せます。
			/// </summary>
			/// <param name="hhk">現在のフックのハンドル</param>
			/// <param name="nCode">フックプロシージャに渡すフックコード</param>
			/// <param name="msg">フックプロシージャに渡す値</param>
			/// <param name="msllhookstruct">フックプロシージャに渡す値</param>
			/// <returns>フックチェーン内の次のフックプロシージャの戻り値</returns>
			[DllImport("user32.dll")]
			public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, uint msg, ref KBDLLHOOKSTRUCT kbdllhookstruct);

			/// <summary>SetWindowsHookEx 関数を使ってフックチェーン内にインストールされたフックプロシージャを削除します。</summary>
			/// <param name="hhk">削除対象のフックプロシージャのハンドル</param>
			/// <returns>関数が成功すると、0 以外の値が返ります。関数が失敗すると、0 が返ります。</returns>
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool UnhookWindowsHookEx(IntPtr hhk);
		}

		/// <summary>低レベルのキーボードの入力イベントの構造体</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct KBDLLHOOKSTRUCT {
			public uint vkCode;
			public uint scanCode;
			public uint flags;
			public uint time;
			public IntPtr dwExtraInfo;
		}

		/// <summary>フックプロシージャのハンドル</summary>
		static IntPtr Handle;

		public static void Register(Action<uint, KBDLLHOOKSTRUCT> callback) {
			if(Handle != IntPtr.Zero) {
				throw new Exception("Register ONLY Once");
			}
			var h = Marshal.GetHINSTANCE(typeof(Hook).Assembly.GetModules()[0]);
			NativeMethods.KeyboardHookCallback c = delegate (int nCode, uint msg, ref KBDLLHOOKSTRUCT s) {
				callback(msg, s);
				return NativeMethods.CallNextHookEx(Handle, nCode, msg, ref s);
			};
			var handle = NativeMethods.SetWindowsHookEx(13, c, h, 0); // 13 = WH_KEYBOARD_LL 低水準キーボード入力イベント
			if (handle == IntPtr.Zero) {
				throw new System.ComponentModel.Win32Exception("Exception occored with SetWindowsHookEx.");
			}
			Handle = handle;
		}

		/// <summary>フックプロシージャをフックチェーンから外します</summary>
		public static void Unregister() {
			NativeMethods.UnhookWindowsHookEx(Handle);
		}

	}
}
