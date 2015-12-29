using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SolidPrinciples
{
	public class SingleResponsib : DisplayableSample
	{
		public string Run()
		{
			var result = "SingleResponsibility.html";
			result += Environment.NewLine + "a class should have only a single responsibility (i.e. only one potential change in the software's specification should be able to affect the specification of the class)";
			this.LaunchJavascriptSample("SingleResponsibility.html");

			return result;
		}

		private void LaunchJavascriptSample(string fileName)
		{
			string filePath = $"file:///{Path.Combine(Application.StartupPath, "JavascriptSamples", fileName)}".Replace("\\", "/");
			Process.Start(filePath);
		}
	}
}
