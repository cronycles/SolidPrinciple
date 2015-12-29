using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SolidPrinciples
{
	public class OpenClosed : DisplayableSample
	{
		public string Run()
		{
			var result = "OpenClose.html";
			result += Environment.NewLine + "software entities … should be open for extension, but closed for modification.";
			this.LaunchJavascriptSample("OpenClose.html");

			return result;
		}

		private void LaunchJavascriptSample(string fileName)
		{
			string filePath = $"file:///{Path.Combine(Application.StartupPath, "JavascriptSamples", fileName)}".Replace("\\", "/");
			Process.Start(filePath);
		}
	}
}
