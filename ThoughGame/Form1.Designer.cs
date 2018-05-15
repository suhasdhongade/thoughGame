namespace ThoughGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.requestTypeCombo = new System.Windows.Forms.ComboBox();
            this.BtnSubmitRequest = new System.Windows.Forms.Button();
            this.txtServiceResponse = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // requestTypeCombo
            // 
            this.requestTypeCombo.FormattingEnabled = true;
            this.requestTypeCombo.Items.AddRange(new object[] {
            "Challenge",
            "Input",
            "output"});
            this.requestTypeCombo.Location = new System.Drawing.Point(44, 27);
            this.requestTypeCombo.Name = "requestTypeCombo";
            this.requestTypeCombo.Size = new System.Drawing.Size(128, 21);
            this.requestTypeCombo.TabIndex = 0;
            // 
            // BtnSubmitRequest
            // 
            this.BtnSubmitRequest.Location = new System.Drawing.Point(44, 82);
            this.BtnSubmitRequest.Name = "BtnSubmitRequest";
            this.BtnSubmitRequest.Size = new System.Drawing.Size(128, 23);
            this.BtnSubmitRequest.TabIndex = 2;
            this.BtnSubmitRequest.Text = "Submit Request";
            this.BtnSubmitRequest.UseVisualStyleBackColor = true;
            this.BtnSubmitRequest.Click += new System.EventHandler(this.BtnSubmitRequest_Click);
            // 
            // txtServiceResponse
            // 
            this.txtServiceResponse.Location = new System.Drawing.Point(263, 12);
            this.txtServiceResponse.Multiline = true;
            this.txtServiceResponse.Name = "txtServiceResponse";
            this.txtServiceResponse.ReadOnly = true;
            this.txtServiceResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServiceResponse.Size = new System.Drawing.Size(718, 448);
            this.txtServiceResponse.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtServiceResponse);
            this.Controls.Add(this.BtnSubmitRequest);
            this.Controls.Add(this.requestTypeCombo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox requestTypeCombo;
        private System.Windows.Forms.Button BtnSubmitRequest;
        private System.Windows.Forms.TextBox txtServiceResponse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

