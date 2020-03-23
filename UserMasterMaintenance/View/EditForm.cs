using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMasterMaintenance.View
{

	public partial class EditForm : Form
	{
		/// <summary>
		/// 一覧表示フォームプロパティ
		/// </summary>
		private ListForm ListForm { get; set; }

		private Control.EditControl EditControl { get; set; }


		public EditForm(ListForm listForm)
		{
			InitializeComponent();

			ListForm = listForm;
			EditControl = new Control.EditControl(ListForm.SelectedEditType);

			IdTextBox.Text = ListForm.SelectedUser.ID;
		}

		/// <summary>
		/// OKボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OKButton_Click(object sender, EventArgs e)
		{
			EditControl.DoEdit();
			ListForm.Users = 
		}

		/// <summary>
		/// キャンセルボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// 画面を表示する
		/// </summary>
		private void ShowDisplay()
		{

		}

	}
}
