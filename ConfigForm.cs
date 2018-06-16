using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinDispSleep {
	public partial class ConfigForm : Form {

		Config config = new Config();

		public ConfigForm() {
			InitializeComponent();
			var config = Config.Read();
			mod.DataSource = Enum.GetValues(typeof(Mod));
			foreach(var i in config.Mod) {
				mod.SelectedItems.Add(i);
			}
			mod.SelectedItem= config.Mod;
			key.DataSource = Enum.GetValues(typeof(Keys));
			key.SelectedItem = config.Key;
			lockCheck.Checked = config.Lock;
		}

		private void Mod_SelectedValueChanged(object sender, EventArgs e) {
			config.Mod = ((ListBox)sender).SelectedItems.Cast<Mod>().ToArray();
		}

		private void Key_SelectionChangeCommitted(object sender, EventArgs e) {
			Console.WriteLine(key.SelectedValue);
			config.Key = (Keys)((ComboBox)sender).SelectedValue;
		}

		private void LockCheck_CheckedChanged(object sender, EventArgs e) {
			config.Lock = ((CheckBox)sender).Checked;
		}

		private void Ok_Click(object sender, EventArgs e) {
			try {
				Config.Write(config);
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.StackTrace, ex.Message);
			}
		}

		private void Cancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

	}
}
