using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.IO.Directory;

namespace WinDispSleep {

	/// <summary>設定ファイルクラス</summary>
	public class Config {

		/// <summary>キャプチャのトリガーキー</summary>
		public Keys Key { get; set; } = Keys.S;

		/// <summary>ディスプレイスリープ時にロックするか</summary>
		public bool Lock { get; set; } = true;

		public Mod[] Mod { get; set; } = {WinDispSleep.Mod.Win};

		static readonly string ConfigPath = GetParent(Application.ExecutablePath) + @"\" + Application.ProductName + ".config";

		/// <summary>設定を読み込みます</summary>
		/// <returns>読み込んだ設定</returns>
		public static Config Read() {
			if(!File.Exists(ConfigPath)) {
				return new Config();
			}

			Config c;
			var sz = new XmlSerializer(typeof(Config));
			using(var sr = new StreamReader(ConfigPath, new UTF8Encoding(false))) {
				c = (Config)sz.Deserialize(sr);
			}
			return c;
		}

		/// <summary>設定をファイルに書き出します</summary>
		/// <param name="c">書き出す設定</param>
		public static void Write(Config c) {
			var sz = new XmlSerializer(typeof(Config));
			using(var sw = new StreamWriter(ConfigPath, false, new UTF8Encoding(false))) {
				sz.Serialize(sw, c);
			}
		}

	}
}
