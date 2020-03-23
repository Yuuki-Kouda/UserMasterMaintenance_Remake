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
	public partial class ListForm : Form
	{
		/// <summary>
		/// 
		/// </summary>
		private Control.JsonFileControl JsonFileControl { get; set; }

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		List<Model.User> Users { get; set; }

		/// <summary>
		/// 部門リスト
		/// </summary>
		List<Model.Department> Departments { get; set; }

		/// <summary>
		/// 選択した編集タイプ
		/// </summary>
		Control.EditType SelectedEditType { get; set; }

		/// <summary>
		/// 選択したユーザー
		/// </summary>
		public Model.User SelectedUser { get; set; }

		private readonly string MenText = "男性";

		private readonly string WomenText = "女性";

		private readonly string ErrorText = "エラー";

		private readonly string CheckBoxErrorMessageText = "1行だけチェックしてからボタンを押してください";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListForm()
		{
			InitializeComponent();

			JsonFileControl = new Control.JsonFileControl();
			Users = JsonFileControl.GetUsers();
			Departments = JsonFileControl.GetDepartments();
		}

		/// <summary>
		/// ロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListForm_Load(object sender, EventArgs e)
		{
			ShowDisplay();
		}

		/// <summary>
		/// 閉じるボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CloseButton_Click(object sender, FormClosedEventArgs e)
		{
			JsonFileControl.SaveUsersInFile(Users);
			JsonFileControl.SaveDepartmentsInFile(Departments);
		}

		/// <summary>
		/// 登録ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RegisterButton_Click(object sender, EventArgs e)
		{
			EditForm editForm = new EditForm(this);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 更新ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			if (ConfirmCheckBox())
			{
				ShowChecBoxErrorDialog();
				return;
			}

			EditForm editForm = new EditForm(this);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 削除ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (ConfirmCheckBox())
			{
				ShowChecBoxErrorDialog();
				return;
			}

			EditForm editForm = new EditForm(this);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 画面を表示する
		/// </summary>
		private void ShowDisplay()
		{
		}

		/// <summary>
		/// チェックボックスを確認する
		/// </summary>
		/// <returns></returns>
		private bool ConfirmCheckBox()
		{
			var selectedRow = 0;
			var isSelected = false;
			for (int i = 1; i >= UsersDataGridView.RowCount; i++)
			{

				if (!(bool)UsersDataGridView[i, 0].Value)
					continue;

				if (isSelected)
					return true;

				selectedRow = i;
				isSelected = true;
			}

			SelectedUser.ID = (int)UsersDataGridView[selectedRow, 1].Value;
			SelectedUser.Name = (string)UsersDataGridView[selectedRow, 2].Value;
			SelectedUser.Age = (int)UsersDataGridView[selectedRow, 3].Value;

			if ((string)UsersDataGridView[selectedRow, 4].Value == MenText)
				SelectedUser.Gender = GenderType.Men;
			else
				SelectedUser.Gender = GenderType.Women;

			SelectedUser.Department.Name = (string)UsersDataGridView[selectedRow, 5].Value;

			return false;
		}

		/// <summary>
		/// チェックボックスエラーダイアログを表示する
		/// </summary>
		private void ShowChecBoxErrorDialog()
		{
			MessageBox.Show(CheckBoxErrorMessageText, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
