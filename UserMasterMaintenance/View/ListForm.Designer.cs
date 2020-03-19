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
			this.RegisterButton = new System.Windows.Forms.Button();
			this.UpdateButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.UserCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
			// 
			// UpdateButton
			// 
			this.UpdateButton.Location = new System.Drawing.Point(112, 12);
			this.UpdateButton.Name = "UpdateButton";
			this.UpdateButton.Size = new System.Drawing.Size(94, 48);
			this.UpdateButton.TabIndex = 1;
			this.UpdateButton.Text = "更新";
			this.UpdateButton.UseVisualStyleBackColor = true;
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(212, 12);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(94, 48);
			this.DeleteButton.TabIndex = 2;
			this.DeleteButton.Text = "削除";
			this.DeleteButton.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserCheck,
            this.ID,
            this.Name,
            this.Age,
            this.Gender,
            this.Department});
			this.dataGridView1.Location = new System.Drawing.Point(12, 66);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 21;
			this.dataGridView1.Size = new System.Drawing.Size(776, 372);
			this.dataGridView1.TabIndex = 3;
			// 
			// UserCheck
			// 
			this.UserCheck.HeaderText = "";
			this.UserCheck.Name = "UserCheck";
			this.UserCheck.Width = 50;
			// 
			// ID
			// 
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Width = 136;
			// 
			// Name
			// 
			this.Name.HeaderText = "名前";
			this.Name.Name = "Name";
			this.Name.ReadOnly = true;
			this.Name.Width = 136;
			// 
			// Age
			// 
			this.Age.HeaderText = "年齢";
			this.Age.Name = "Age";
			this.Age.ReadOnly = true;
			this.Age.Width = 136;
			// 
			// Gender
			// 
			this.Gender.HeaderText = "性別";
			this.Gender.Name = "Gender";
			this.Gender.ReadOnly = true;
			this.Gender.Width = 136;
			// 
			// Department
			// 
			this.Department.HeaderText = "所属";
			this.Department.Name = "Department";
			this.Department.ReadOnly = true;
			this.Department.Width = 136;
			// 
			// ListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridView1);
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
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button RegisterButton;
		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn UserCheck;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Age;
		private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
		private System.Windows.Forms.DataGridViewTextBoxColumn Department;
	}
}

