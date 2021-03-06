﻿namespace UserMasterMaintenance.View
{
	partial class EditForm
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
			this.components = new System.ComponentModel.Container();
			this.IdLabel = new System.Windows.Forms.Label();
			this.NameLabel = new System.Windows.Forms.Label();
			this.AgeLabel = new System.Windows.Forms.Label();
			this.GenderLabel = new System.Windows.Forms.Label();
			this.DepartmentLabel = new System.Windows.Forms.Label();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.IdTextBox = new System.Windows.Forms.TextBox();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.AgeTextBox = new System.Windows.Forms.TextBox();
			this.MenRadioButton = new System.Windows.Forms.RadioButton();
			this.WomenRadioButton = new System.Windows.Forms.RadioButton();
			this.DepartmentCombBox = new System.Windows.Forms.ComboBox();
			this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// IdLabel
			// 
			this.IdLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.IdLabel.Location = new System.Drawing.Point(30, 55);
			this.IdLabel.Name = "IdLabel";
			this.IdLabel.Size = new System.Drawing.Size(38, 23);
			this.IdLabel.TabIndex = 0;
			this.IdLabel.Text = "ID";
			this.IdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameLabel
			// 
			this.NameLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NameLabel.Location = new System.Drawing.Point(30, 114);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(58, 23);
			this.NameLabel.TabIndex = 1;
			this.NameLabel.Text = "名前";
			this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AgeLabel
			// 
			this.AgeLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.AgeLabel.Location = new System.Drawing.Point(30, 180);
			this.AgeLabel.Name = "AgeLabel";
			this.AgeLabel.Size = new System.Drawing.Size(58, 23);
			this.AgeLabel.TabIndex = 2;
			this.AgeLabel.Text = "年齢";
			this.AgeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GenderLabel
			// 
			this.GenderLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.GenderLabel.Location = new System.Drawing.Point(30, 251);
			this.GenderLabel.Name = "GenderLabel";
			this.GenderLabel.Size = new System.Drawing.Size(58, 23);
			this.GenderLabel.TabIndex = 3;
			this.GenderLabel.Text = "性別";
			this.GenderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DepartmentLabel
			// 
			this.DepartmentLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.DepartmentLabel.Location = new System.Drawing.Point(30, 328);
			this.DepartmentLabel.Name = "DepartmentLabel";
			this.DepartmentLabel.Size = new System.Drawing.Size(58, 23);
			this.DepartmentLabel.TabIndex = 4;
			this.DepartmentLabel.Text = "所属";
			this.DepartmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(157, 388);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(90, 50);
			this.OKButton.TabIndex = 5;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(256, 388);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(90, 50);
			this.CancelButton.TabIndex = 6;
			this.CancelButton.Text = "キャンセル";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// IdTextBox
			// 
			this.IdTextBox.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.IdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.IdTextBox.Location = new System.Drawing.Point(88, 55);
			this.IdTextBox.MaxLength = 4;
			this.IdTextBox.Name = "IdTextBox";
			this.IdTextBox.Size = new System.Drawing.Size(63, 21);
			this.IdTextBox.TabIndex = 7;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NameTextBox.Location = new System.Drawing.Point(88, 114);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(258, 21);
			this.NameTextBox.TabIndex = 8;
			// 
			// AgeTextBox
			// 
			this.AgeTextBox.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.AgeTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.AgeTextBox.Location = new System.Drawing.Point(88, 180);
			this.AgeTextBox.MaxLength = 3;
			this.AgeTextBox.Name = "AgeTextBox";
			this.AgeTextBox.Size = new System.Drawing.Size(63, 21);
			this.AgeTextBox.TabIndex = 9;
			// 
			// MenRadioButton
			// 
			this.MenRadioButton.AutoSize = true;
			this.MenRadioButton.Checked = true;
			this.MenRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MenRadioButton.Location = new System.Drawing.Point(112, 251);
			this.MenRadioButton.Name = "MenRadioButton";
			this.MenRadioButton.Size = new System.Drawing.Size(55, 18);
			this.MenRadioButton.TabIndex = 12;
			this.MenRadioButton.TabStop = true;
			this.MenRadioButton.Text = "男性";
			this.MenRadioButton.UseVisualStyleBackColor = true;
			// 
			// WomenRadioButton
			// 
			this.WomenRadioButton.AutoSize = true;
			this.WomenRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.WomenRadioButton.Location = new System.Drawing.Point(201, 251);
			this.WomenRadioButton.Name = "WomenRadioButton";
			this.WomenRadioButton.Size = new System.Drawing.Size(55, 18);
			this.WomenRadioButton.TabIndex = 13;
			this.WomenRadioButton.Text = "女性";
			this.WomenRadioButton.UseVisualStyleBackColor = true;
			// 
			// DepartmentCombBox
			// 
			this.DepartmentCombBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DepartmentCombBox.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.DepartmentCombBox.FormattingEnabled = true;
			this.DepartmentCombBox.Location = new System.Drawing.Point(88, 323);
			this.DepartmentCombBox.Name = "DepartmentCombBox";
			this.DepartmentCombBox.Size = new System.Drawing.Size(258, 21);
			this.DepartmentCombBox.TabIndex = 14;
			// 
			// departmentBindingSource
			// 
			this.departmentBindingSource.DataSource = typeof(UserMasterMaintenance.Model.Department);
			// 
			// EditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 450);
			this.Controls.Add(this.DepartmentCombBox);
			this.Controls.Add(this.WomenRadioButton);
			this.Controls.Add(this.MenRadioButton);
			this.Controls.Add(this.AgeTextBox);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.IdTextBox);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.DepartmentLabel);
			this.Controls.Add(this.GenderLabel);
			this.Controls.Add(this.AgeLabel);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.IdLabel);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(374, 489);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(374, 489);
			this.Name = "EditForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UserMasterMaintenance";
			((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label IdLabel;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label AgeLabel;
		private System.Windows.Forms.Label GenderLabel;
		private System.Windows.Forms.Label DepartmentLabel;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.TextBox IdTextBox;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.TextBox AgeTextBox;
		private System.Windows.Forms.RadioButton MenRadioButton;
		private System.Windows.Forms.RadioButton WomenRadioButton;
		private System.Windows.Forms.ComboBox DepartmentCombBox;
		private System.Windows.Forms.BindingSource departmentBindingSource;
	}
}