namespace WinDispSleep {
	partial class ConfigForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lockCheck = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.key = new System.Windows.Forms.ComboBox();
			this.mod = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			//
			// ok
			//
			this.ok.Location = new System.Drawing.Point(112, 122);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(67, 20);
			this.ok.TabIndex = 0;
			this.ok.Text = "OK";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.Ok_Click);
			//
			// cancel
			//
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(185, 122);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(67, 20);
			this.cancel.TabIndex = 1;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.Cancel_Click);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(43, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Key";
			//
			// lockCheck
			//
			this.lockCheck.AutoSize = true;
			this.lockCheck.Location = new System.Drawing.Point(73, 100);
			this.lockCheck.Name = "lockCheck";
			this.lockCheck.Size = new System.Drawing.Size(48, 16);
			this.lockCheck.TabIndex = 4;
			this.lockCheck.Text = "Lock";
			this.lockCheck.UseVisualStyleBackColor = true;
			this.lockCheck.CheckedChanged += new System.EventHandler(this.LockCheck_CheckedChanged);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(132, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(11, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "+";
			//
			// key
			//
			this.key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.key.FormattingEnabled = true;
			this.key.Location = new System.Drawing.Point(149, 55);
			this.key.Name = "key";
			this.key.Size = new System.Drawing.Size(84, 20);
			this.key.TabIndex = 7;
			this.key.SelectionChangeCommitted += new System.EventHandler(this.Key_SelectionChangeCommitted);
			//
			// mod
			//
			this.mod.FormattingEnabled = true;
			this.mod.ItemHeight = 12;
			this.mod.Location = new System.Drawing.Point(73, 29);
			this.mod.Name = "mod";
			this.mod.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.mod.Size = new System.Drawing.Size(53, 64);
			this.mod.TabIndex = 8;
			this.mod.SelectedValueChanged += new System.EventHandler(this.Mod_SelectedValueChanged);
			//
			// ConfigForm
			//
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(264, 154);
			this.ControlBox = false;
			this.Controls.Add(this.mod);
			this.Controls.Add(this.key);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lockCheck);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConfigForm";
			this.Text = "WinDispSleep";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox lockCheck;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox key;
		private System.Windows.Forms.ListBox mod;
	}
}
