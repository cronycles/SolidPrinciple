namespace SolidPrinciples
{
	partial class frmMain
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.linkSingleResp = new System.Windows.Forms.LinkLabel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.linkOpenClosed = new System.Windows.Forms.LinkLabel();
			this.linkLiskov = new System.Windows.Forms.LinkLabel();
			this.linkInterfaceSegreg = new System.Windows.Forms.LinkLabel();
			this.linkDependencyInv = new System.Windows.Forms.LinkLabel();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.btnSeeCode = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// linkSingleResp
			// 
			this.linkSingleResp.AutoSize = true;
			this.linkSingleResp.Location = new System.Drawing.Point(13, 13);
			this.linkSingleResp.Name = "linkSingleResp";
			this.linkSingleResp.Size = new System.Drawing.Size(37, 21);
			this.linkSingleResp.TabIndex = 0;
			this.linkSingleResp.TabStop = true;
			this.linkSingleResp.Text = "SRP";
			this.toolTip1.SetToolTip(this.linkSingleResp, "Single responsibility principle");
			this.linkSingleResp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSingleResp_LinkClicked);
			// 
			// linkOpenClosed
			// 
			this.linkOpenClosed.AutoSize = true;
			this.linkOpenClosed.Location = new System.Drawing.Point(56, 13);
			this.linkOpenClosed.Name = "linkOpenClosed";
			this.linkOpenClosed.Size = new System.Drawing.Size(46, 21);
			this.linkOpenClosed.TabIndex = 1;
			this.linkOpenClosed.TabStop = true;
			this.linkOpenClosed.Text = "OCP";
			this.toolTip1.SetToolTip(this.linkOpenClosed, "Open/Closed principle");
			this.linkOpenClosed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenClosed_LinkClicked);
			// 
			// linkLiskov
			// 
			this.linkLiskov.AutoSize = true;
			this.linkLiskov.Location = new System.Drawing.Point(108, 13);
			this.linkLiskov.Name = "linkLiskov";
			this.linkLiskov.Size = new System.Drawing.Size(34, 21);
			this.linkLiskov.TabIndex = 3;
			this.linkLiskov.TabStop = true;
			this.linkLiskov.Text = "LSP";
			this.toolTip1.SetToolTip(this.linkLiskov, "Liskov substitution principle\r\nRIGHT CLICK to see the code");
			this.linkLiskov.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLiskov_LinkClicked);
			// 
			// linkInterfaceSegreg
			// 
			this.linkInterfaceSegreg.AutoSize = true;
			this.linkInterfaceSegreg.Location = new System.Drawing.Point(148, 13);
			this.linkInterfaceSegreg.Name = "linkInterfaceSegreg";
			this.linkInterfaceSegreg.Size = new System.Drawing.Size(32, 21);
			this.linkInterfaceSegreg.TabIndex = 4;
			this.linkInterfaceSegreg.TabStop = true;
			this.linkInterfaceSegreg.Text = "ISP";
			this.toolTip1.SetToolTip(this.linkInterfaceSegreg, "Interface Segregation principle");
			this.linkInterfaceSegreg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInterfaceSegreg_LinkClicked);
			// 
			// linkDependencyInv
			// 
			this.linkDependencyInv.AutoSize = true;
			this.linkDependencyInv.Location = new System.Drawing.Point(186, 13);
			this.linkDependencyInv.Name = "linkDependencyInv";
			this.linkDependencyInv.Size = new System.Drawing.Size(36, 21);
			this.linkDependencyInv.TabIndex = 5;
			this.linkDependencyInv.TabStop = true;
			this.linkDependencyInv.Text = "DIP";
			this.toolTip1.SetToolTip(this.linkDependencyInv, "Dependency Inversion principle");
			this.linkDependencyInv.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDependencyInv_LinkClicked);
			// 
			// txtResult
			// 
			this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResult.BackColor = System.Drawing.SystemColors.ControlLight;
			this.txtResult.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtResult.Location = new System.Drawing.Point(12, 52);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ReadOnly = true;
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResult.Size = new System.Drawing.Size(953, 429);
			this.txtResult.TabIndex = 2;
			// 
			// btnSeeCode
			// 
			this.btnSeeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSeeCode.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnSeeCode.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSeeCode.Location = new System.Drawing.Point(843, 23);
			this.btnSeeCode.Name = "btnSeeCode";
			this.btnSeeCode.Size = new System.Drawing.Size(121, 23);
			this.btnSeeCode.TabIndex = 6;
			this.btnSeeCode.Text = "Show me the code";
			this.btnSeeCode.UseVisualStyleBackColor = false;
			this.btnSeeCode.Visible = false;
			this.btnSeeCode.Click += new System.EventHandler(this.btnSeeCode_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(977, 493);
			this.Controls.Add(this.btnSeeCode);
			this.Controls.Add(this.linkDependencyInv);
			this.Controls.Add(this.linkInterfaceSegreg);
			this.Controls.Add(this.linkLiskov);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.linkOpenClosed);
			this.Controls.Add(this.linkSingleResp);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "frmMain";
			this.Text = "SOLID principles";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel linkSingleResp;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.LinkLabel linkOpenClosed;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.LinkLabel linkLiskov;
		private System.Windows.Forms.LinkLabel linkInterfaceSegreg;
		private System.Windows.Forms.LinkLabel linkDependencyInv;
		private System.Windows.Forms.Button btnSeeCode;
	}
}

