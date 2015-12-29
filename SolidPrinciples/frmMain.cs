using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolidPrinciples
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void linkSingleResp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.LaunchSample(new SingleResponsib());
			EnableShowCodeButtonIfCodeCanBeShown();
		}

		private void linkOpenClosed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.LaunchSample(new OpenClosed());
			EnableShowCodeButtonIfCodeCanBeShown();
		}

		private void linkLiskov_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.LaunchSample(new Liskov());
			EnableShowCodeButtonIfCodeCanBeShown();
		}

		private void linkInterfaceSegreg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.LaunchSample(new IfaceSegreg());
			EnableShowCodeButtonIfCodeCanBeShown();

		}

		private void linkDependencyInv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.LaunchSample(new DependecInv());
			EnableShowCodeButtonIfCodeCanBeShown();

		}

		private void btnSeeCode_Click(object sender, EventArgs e)
		{
			if (!CodeCanBeShown())
			{
				MessageBox.Show("Can't show you the code for this sample", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			this.LoadFileIntoResultBox(this.GetFileName());
		}

		private void EnableShowCodeButtonIfCodeCanBeShown()
		{
			btnSeeCode.Visible = CodeCanBeShown();
		}

		private bool CodeCanBeShown()
		{
			string fileName = this.GetFileName();
			return (!string.IsNullOrEmpty(fileName) && File.Exists(Path.Combine(Application.StartupPath, fileName)));
		}

		private string GetFileName()
		{
			return txtResult.Lines?.FirstOrDefault();
		}

		private void LaunchSample(DisplayableSample sample)
		{
			this.txtResult.Text = sample.Run();
		}


		private void LoadFileIntoResultBox(string fileName)
		{
			StreamReader fileReader = File.OpenText(fileName);
			this.txtResult.Text = fileReader.ReadToEnd();
			fileReader.Close();
		}
	}
}
