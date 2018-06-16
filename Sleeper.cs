using System;
using System.Linq;
using System.Windows.Forms;

namespace WinDispSleep {
	public class Sleeper {
		Config config;

		// ModifyKeys state
		bool win = false;
		bool ctrl = false;
		bool alt = false;
		bool shift = false;

		public Sleeper() {
			config = Config.Read();
			SetIcon();
			Hook.Register(Proc);
		}

		void Proc(uint msg, Hook.KBDLLHOOKSTRUCT o) {
			// Set ModifyKeys state
			if ((msg & 0x101) == 0x101) {
				switch (o.vkCode) {
					case (uint)Keys.LWin:
					case (uint)Keys.RWin:
						win = false;
						return;
					case (uint)Keys.LShiftKey:
					case (uint)Keys.RShiftKey:
						shift = false;
						return;
					case 164: // RAlt
					case 165: // LAlt
						alt = false;
						return;
					case (uint)Keys.LControlKey:
					case (uint)Keys.RControlKey:
						ctrl = false;
						return;
				}
			} else if ((msg & 0x100) == 0x100) {
				switch (o.vkCode) {
					case (uint)Keys.LWin:
					case (uint)Keys.RWin:
						win = true;
						return;
					case (uint)Keys.LShiftKey:
					case (uint)Keys.RShiftKey:
						shift = true;
						return;
					case 164: // LAlt
					case 165: // RAlt
						alt = true;
						return;
					case (uint)Keys.RControlKey:
					case (uint)Keys.LControlKey:
						ctrl = true;
						return;
					default:
						return; // Lock process run only when key up
				}
			} else {
				return; // Lock process runs only when key up
			}

			try {
				if (config.Mod.Contains(Mod.Alt) && !alt) {
					return;
				}
				if (config.Mod.Contains(Mod.Shift) && !shift) {
					return;
				}
				if (config.Mod.Contains(Mod.Ctrl) && !ctrl) {
					return;
				}
				if (config.Mod.Contains(Mod.Win) && !win) {
					return;
				}
				if (o.vkCode == (uint)config.Key) {
					API.SleepDisplay();
					if (config.Lock) {
						API.Lock();
					}
				}
			}
			catch (Exception e) {
				MessageBox.Show(e.Message + "\n" + e.StackTrace, Application.ProductName + " Error!!");
			}
		}

		void SetIcon() {
			var icon = new NotifyIcon {
				Icon = Properties.Resources.icon,
				Visible = true,
			};
			Application.ApplicationExit += (o, e) => icon.Dispose();

			var version = new ToolStripMenuItem {
				Text = "Ver. " + Application.ProductVersion,
				Enabled = false,
			};
			var settings = new ToolStripMenuItem { Text = "Settings..." };
			settings.Click += (o, e) => {
				if (new ConfigForm().ShowDialog() == DialogResult.OK) {
					config = Config.Read();
				}
			};
			var exit = new ToolStripMenuItem { Text = "Exit" };
			exit.Click += (o, e) => Application.Exit();
			icon.ContextMenuStrip = new ContextMenuStrip();
			icon.ContextMenuStrip.Items.AddRange(new[] { version, settings, exit });
		}

	}
}
