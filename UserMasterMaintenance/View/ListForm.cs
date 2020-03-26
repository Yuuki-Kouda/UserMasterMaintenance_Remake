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
	enum ErrorType
	{
		None,
		CheckBox,
		NotInput,
		NotNumber,
		DataDuplication
	}

	public partial class ListForm : Form
	{
		private readonly string ErrorText = "エラー";

		private readonly string CheckBoxErrorMessageText = "1行だけチェックしてからボタンを押してください";

		private readonly string CheckBoxTrueValue = "1";

		private readonly int CheckBoxCellNumber = 0;

		private readonly int IDCellNumber = 1;

		/// <summary>
		/// 
		/// </summary>
		private Control.JsonFileControl JsonFileControl { get; set; }

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		public BindingList<Model.User> Users { get; set; }

		/// <summary>
		/// 部門リスト
		/// </summary>
		public List<Model.Department> Departments { get; set; }

		/// <summary>
		/// 選択した編集タイプ
		/// </summary>
		public Control.EditType SelectedEditType { get; set; }

		/// <summary>
		/// 選択したユーザー
		/// </summary>
		public Model.User SelectedUser { get; set; }

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
			JsonFileControl.SaveUsersInJsonFile(Users);
			JsonFileControl.SaveDepartmentsInJsonFile(Departments);
		}

		/// <summary>
		/// 登録ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RegisterButton_Click(object sender, EventArgs e)
		{
			SelectedEditType = Control.EditType.Register;
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
			if (ValidateCheckBox() == ErrorType.CheckBox)
			{
				ShowCheckBoxErrorDialog();
				return;
			}

			SelectedEditType = Control.EditType.Update;
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
			if (ValidateCheckBox() == ErrorType.CheckBox)
			{
				ShowCheckBoxErrorDialog();
				return;
			}

			SelectedEditType = Control.EditType.Delete;
			EditForm editForm = new EditForm(this);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 画面を表示する
		/// </summary>
		private void ShowDisplay()
		{
			UsersDataGridView.DataSource = Users;
		}

		/// <summary>
		/// チェックボックスエラーがあるか
		/// </summary>
		/// <returns></returns>
		private ErrorType ValidateCheckBox()
		{
			var users = UsersDataGridView.Rows.Cast<DataGridViewRow>().Where(x => (string)x.Cells[CheckBoxCellNumber].Value == CheckBoxTrueValue).ToList();
			//1件以外はエラー
			if (users.Count != 1)
				return ErrorType.CheckBox;

			SelectedUser = GetSelctedUser((int)users.First().Cells[IDCellNumber].Value);
			return ErrorType.None;
		}

		/// <summary>
		/// チェックボックスエラーダイアログを表示する
		/// </summary>
		private void ShowCheckBoxErrorDialog()
		{
			MessageBox.Show(CheckBoxErrorMessageText, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 選択されたユーザーを取得する
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		private Model.User GetSelctedUser(int iD)
		{
			var selectedUser = Users.First(x => x.ID == iD);
			return selectedUser;
		}
	}
}
