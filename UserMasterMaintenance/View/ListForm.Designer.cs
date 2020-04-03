namespace UserMasterMaintenance.View
{
	partial class ListForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.RegisterButton = new System.Windows.Forms.Button();
			this.UpdateButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.UsersDataGridView = new System.Windows.Forms.DataGridView();
			this.UserCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// RegisterButton
			// 
			this.RegisterButton.Location = new System.Drawing.Point(12, 12);
			this.RegisterButton.Name = "RegisterButton";
			this.RegisterButton.Size = new System.Drawing.Size(94, 48);
			this.RegisterButton.TabIndex = 0;
			this.RegisterButton.Text = "登録";
			this.RegisterButton.UseVisualStyleBackColor = true;
			this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
			// 
			// UpdateButton
			// 
			this.UpdateButton.Location = new System.Drawing.Point(112, 12);
			this.UpdateButton.Name = "UpdateButton";
			this.UpdateButton.Size = new System.Drawing.Size(94, 48);
			this.UpdateButton.TabIndex = 1;
			this.UpdateButton.Text = "更新";
			this.UpdateButton.UseVisualStyleBackColor = true;
			this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(212, 12);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(94, 48);
			this.DeleteButton.TabIndex = 2;
			this.DeleteButton.Text = "削除";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// UsersDataGridView
			// 
			this.UsersDataGridView.AllowUserToAddRows = false;
			this.UsersDataGridView.AllowUserToDeleteRows = false;
			this.UsersDataGridView.AllowUserToResizeColumns = false;
			this.UsersDataGridView.AllowUserToResizeRows = false;
			this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserCheck,
            this.UserID,
            this.UserName,
            this.UserAge,
            this.UserGender,
            this.UserDepartment});
			this.UsersDataGridView.Location = new System.Drawing.Point(12, 66);
			this.UsersDataGridView.Name = "UsersDataGridView";
			this.UsersDataGridView.RowTemplate.Height = 21;
			this.UsersDataGridView.Size = new System.Drawing.Size(776, 372);
			this.UsersDataGridView.TabIndex = 3;
			// 
			// UserCheck
			// 
			this.UserCheck.FalseValue = "0";
			this.UserCheck.HeaderText = "";
			this.UserCheck.Name = "UserCheck";
			this.UserCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.UserCheck.TrueValue = "1";
			this.UserCheck.Width = 50;
			// 
			// UserID
			// 
			this.UserID.DataPropertyName = "ID";
			this.UserID.HeaderText = "ID";
			this.UserID.Name = "UserID";
			this.UserID.ReadOnly = true;
			this.UserID.Width = 136;
			// 
			// UserName
			// 
			this.UserName.DataPropertyName = "Name";
			this.UserName.HeaderText = "名前";
			this.UserName.Name = "UserName";
			this.UserName.ReadOnly = true;
			this.UserName.Width = 136;
			// 
			// UserAge
			// 
			this.UserAge.DataPropertyName = "Age";
			this.UserAge.HeaderText = "年齢";
			this.UserAge.Name = "UserAge";
			this.UserAge.ReadOnly = true;
			this.UserAge.Width = 136;
			// 
			// UserGender
			// 
			this.UserGender.DataPropertyName = "Gender";
			this.UserGender.HeaderText = "性別";
			this.UserGender.Name = "UserGender";
			this.UserGender.ReadOnly = true;
			this.UserGender.Width = 136;
			// 
			// UserDepartment
			// 
			this.UserDepartment.DataPropertyName = "Department";
			this.UserDepartment.HeaderText = "所属";
			this.UserDepartment.Name = "UserDepartment";
			this.UserDepartment.ReadOnly = true;
			this.UserDepartment.Width = 136;
			// 
			// ListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.UsersDataGridView);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.UpdateButton);
			this.Controls.Add(this.RegisterButton);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(816, 489);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(816, 489);
			this.Name = "ListForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UserMasterMaintenance";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseButton_Click);
			this.Load += new System.EventHandler(this.ListForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button RegisterButton;
		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.DataGridView UsersDataGridView;
		private System.Windows.Forms.BindingSource userBindingSource;
		private System.Windows.Forms.DataGridViewCheckBoxColumn UserCheck;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserAge;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserGender;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserDepartment;
	}
}

