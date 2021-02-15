
namespace Farmacy
{
    partial class FormRegister
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
            this.lblErrorRegister = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.tbUsernameReg = new System.Windows.Forms.TextBox();
            this.tbPasswordReg = new System.Windows.Forms.TextBox();
            this.tbFirstNameReg = new System.Windows.Forms.TextBox();
            this.tbLastNameReg = new System.Windows.Forms.TextBox();
            this.tbCountryReg = new System.Windows.Forms.TextBox();
            this.tbStreetReg = new System.Windows.Forms.TextBox();
            this.tbNumberReg = new System.Windows.Forms.TextBox();
            this.tbZipCodeReg = new System.Windows.Forms.TextBox();
            this.tbCityReg = new System.Windows.Forms.TextBox();
            this.tbPhoneNumberReg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblErrorRegister
            // 
            this.lblErrorRegister.AutoSize = true;
            this.lblErrorRegister.ForeColor = System.Drawing.Color.Red;
            this.lblErrorRegister.Location = new System.Drawing.Point(290, 275);
            this.lblErrorRegister.Name = "lblErrorRegister";
            this.lblErrorRegister.Size = new System.Drawing.Size(0, 17);
            this.lblErrorRegister.TabIndex = 0;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(158, 336);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 32);
            this.btnReg.TabIndex = 0;
            this.btnReg.Text = "Register";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // tbUsernameReg
            // 
            this.tbUsernameReg.ForeColor = System.Drawing.Color.Red;
            this.tbUsernameReg.Location = new System.Drawing.Point(42, 48);
            this.tbUsernameReg.Name = "tbUsernameReg";
            this.tbUsernameReg.Size = new System.Drawing.Size(100, 22);
            this.tbUsernameReg.TabIndex = 1;
            this.tbUsernameReg.Enter += new System.EventHandler(this.tbUsernameReg_Enter);
            this.tbUsernameReg.Leave += new System.EventHandler(this.tbUsernameReg_Leave);
            // 
            // tbPasswordReg
            // 
            this.tbPasswordReg.Location = new System.Drawing.Point(42, 103);
            this.tbPasswordReg.Name = "tbPasswordReg";
            this.tbPasswordReg.Size = new System.Drawing.Size(100, 22);
            this.tbPasswordReg.TabIndex = 2;
            this.tbPasswordReg.Enter += new System.EventHandler(this.tbPasswordReg_Enter);
            this.tbPasswordReg.Leave += new System.EventHandler(this.tbPasswordReg_Leave);
            // 
            // tbFirstNameReg
            // 
            this.tbFirstNameReg.Location = new System.Drawing.Point(42, 159);
            this.tbFirstNameReg.Name = "tbFirstNameReg";
            this.tbFirstNameReg.Size = new System.Drawing.Size(100, 22);
            this.tbFirstNameReg.TabIndex = 3;
            this.tbFirstNameReg.Enter += new System.EventHandler(this.tbFirstNameReg_Enter);
            this.tbFirstNameReg.Leave += new System.EventHandler(this.tbFirstNameReg_Leave);
            // 
            // tbLastNameReg
            // 
            this.tbLastNameReg.Location = new System.Drawing.Point(42, 214);
            this.tbLastNameReg.Name = "tbLastNameReg";
            this.tbLastNameReg.Size = new System.Drawing.Size(100, 22);
            this.tbLastNameReg.TabIndex = 4;
            this.tbLastNameReg.Enter += new System.EventHandler(this.tbLastNameReg_Enter);
            this.tbLastNameReg.Leave += new System.EventHandler(this.tbLastNameReg_Leave);
            // 
            // tbCountryReg
            // 
            this.tbCountryReg.Location = new System.Drawing.Point(293, 270);
            this.tbCountryReg.Name = "tbCountryReg";
            this.tbCountryReg.Size = new System.Drawing.Size(100, 22);
            this.tbCountryReg.TabIndex = 10;
            this.tbCountryReg.Enter += new System.EventHandler(this.tbCountryReg_Enter);
            this.tbCountryReg.Leave += new System.EventHandler(this.tbCountryReg_Leave);
            // 
            // tbStreetReg
            // 
            this.tbStreetReg.Location = new System.Drawing.Point(293, 48);
            this.tbStreetReg.Name = "tbStreetReg";
            this.tbStreetReg.Size = new System.Drawing.Size(100, 22);
            this.tbStreetReg.TabIndex = 6;
            this.tbStreetReg.Enter += new System.EventHandler(this.tbStreetReg_Enter);
            this.tbStreetReg.Leave += new System.EventHandler(this.tbStreetReg_Leave);
            // 
            // tbNumberReg
            // 
            this.tbNumberReg.Location = new System.Drawing.Point(293, 104);
            this.tbNumberReg.Name = "tbNumberReg";
            this.tbNumberReg.Size = new System.Drawing.Size(100, 22);
            this.tbNumberReg.TabIndex = 7;
            this.tbNumberReg.Enter += new System.EventHandler(this.tbNumberReg_Enter);
            this.tbNumberReg.Leave += new System.EventHandler(this.tbNumberReg_Leave);
            // 
            // tbZipCodeReg
            // 
            this.tbZipCodeReg.Location = new System.Drawing.Point(293, 214);
            this.tbZipCodeReg.Name = "tbZipCodeReg";
            this.tbZipCodeReg.Size = new System.Drawing.Size(100, 22);
            this.tbZipCodeReg.TabIndex = 9;
            this.tbZipCodeReg.Enter += new System.EventHandler(this.tbZipCodeReg_Enter);
            this.tbZipCodeReg.Leave += new System.EventHandler(this.tbZipCodeReg_Leave);
            // 
            // tbCityReg
            // 
            this.tbCityReg.Location = new System.Drawing.Point(293, 159);
            this.tbCityReg.Name = "tbCityReg";
            this.tbCityReg.Size = new System.Drawing.Size(100, 22);
            this.tbCityReg.TabIndex = 8;
            this.tbCityReg.Enter += new System.EventHandler(this.tbCity_Enter);
            this.tbCityReg.Leave += new System.EventHandler(this.tbCity_Leave);
            // 
            // tbPhoneNumberReg
            // 
            this.tbPhoneNumberReg.Location = new System.Drawing.Point(42, 275);
            this.tbPhoneNumberReg.Name = "tbPhoneNumberReg";
            this.tbPhoneNumberReg.Size = new System.Drawing.Size(100, 22);
            this.tbPhoneNumberReg.TabIndex = 5;
            this.tbPhoneNumberReg.Enter += new System.EventHandler(this.tbPhoneNumberReg_Enter);
            this.tbPhoneNumberReg.Leave += new System.EventHandler(this.tbPhoneNumberReg_Leave);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 450);
            this.Controls.Add(this.tbPhoneNumberReg);
            this.Controls.Add(this.tbCityReg);
            this.Controls.Add(this.tbZipCodeReg);
            this.Controls.Add(this.tbNumberReg);
            this.Controls.Add(this.tbStreetReg);
            this.Controls.Add(this.tbCountryReg);
            this.Controls.Add(this.tbLastNameReg);
            this.Controls.Add(this.tbFirstNameReg);
            this.Controls.Add(this.tbPasswordReg);
            this.Controls.Add(this.tbUsernameReg);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.lblErrorRegister);
            this.Name = "FormRegister";
            this.Text = "FormRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblErrorRegister;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.TextBox tbUsernameReg;
        private System.Windows.Forms.TextBox tbPasswordReg;
        private System.Windows.Forms.TextBox tbFirstNameReg;
        private System.Windows.Forms.TextBox tbLastNameReg;
        private System.Windows.Forms.TextBox tbCountryReg;
        private System.Windows.Forms.TextBox tbStreetReg;
        private System.Windows.Forms.TextBox tbNumberReg;
        private System.Windows.Forms.TextBox tbZipCodeReg;
        private System.Windows.Forms.TextBox tbCityReg;
        private System.Windows.Forms.TextBox tbPhoneNumberReg;
    }
}