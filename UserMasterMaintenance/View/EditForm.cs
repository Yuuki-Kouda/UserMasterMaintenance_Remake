using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMasterMaintenance.View
{

	public partial class EditForm : Form
	{
		private readonly string MenText = "男性";

		private readonly string WomenText = "女性";

		private readonly string ConfirmationText = "確認";

		private readonly string ErrorText = "エラー";

		private readonly string RegisterConfirmationMessage = "登録してよろしいですか？";

		private readonly string UpdateConfirmationMessage = "更新してよろしいですか？";

		private readonly string DeleteConfirmationMessage = "削除してよろしいですか？";

		private readonly string NotInputErrorMessage = "未入力の項目があります";

		private readonly string NotNumberErrorMessage = "半角数字(符号や小数点を除く)を入力してください";

		private readonly string DataDupulicationErrorMessage = "そのIDは既に登録されています";

		/// <summary>
		/// 編集タイプ
		/// </summary>
		private Control.EditType EditType { get; set; }

		/// <summary>
		/// 選択ユーザー
		/// </summary>
		private Model.User SelectedUser { get; set; }

		/// <summary>
		/// 部門リスト
		/// </summary>
		private List<Model.Department> Departments { get; set; }

		/// <summary>
		/// 編集コントローラ
		/// </summary>
		private Control.EditControl EditControl { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="listForm"></param>
		public EditForm(ListForm listForm)
		{
			InitializeComponent();

			EditType = listForm.SelectedEditType;
			SelectedUser = listForm.SelectedUser;
			Departments = listForm.Departments;
			EditControl = new Control.EditControl(listForm);

			ShowDisplay();
		}

		/// <summary>
		/// OKボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OKButton_Click(object sender, EventArgs e)
		{
			if (HasInputError())
				return;

			if (ConfirmEdit() == DialogResult.Cancel)
				return;

			EditControl.Edit(GetInputUser());

			Close();
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
		/// 入力にエラーがあるか
		/// </summary>
		/// <returns></returns>
		private bool HasInputError()
		{
			if (EditType == Control.EditType.Delete)
				return false;

			switch (ValidateInputItems())
			{
				case ErrorType.NotInput:
					ShowNotInputErrorDialog();
					return true;

				case ErrorType.NotNumber:
					ShowNotNumberErrorDialog();
					return true;

				default:
					break;
			}

			if (EditType == Control.EditType.Update)
				return false;

			if (ValidateData() == ErrorType.DataDuplication)
			{
				ShowDataDupulicationErrorDialog();
				return true;
			}

			return false;
		}

		/// <summary>
		/// 編集するか確認する
		/// </summary>
		private DialogResult ConfirmEdit()
		{
			var editconfirmationMessage = string.Empty;
			switch (EditType)
			{
				case Control.EditType.Register:
					editconfirmationMessage = RegisterConfirmationMessage;
					break;

				case Control.EditType.Update:
					editconfirmationMessage = UpdateConfirmationMessage; ;
					break;

				case Control.EditType.Delete:
					editconfirmationMessage = DeleteConfirmationMessage;
					break;

				default:
					break;
			}

			return MessageBox.Show(editconfirmationMessage, ConfirmationText, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
		}

		/// <summary>
		/// 未入力エラーダイアログを表示する
		/// </summary>
		private void ShowNotInputErrorDialog()
		{
			MessageBox.Show(NotInputErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 半角数字でないエラーダイアログを表示する
		/// </summary>
		private void ShowNotNumberErrorDialog()
		{
			MessageBox.Show(NotNumberErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 重複エラーダイアログを表示する
		/// </summary>
		private void ShowDataDupulicationErrorDialog()
		{
			MessageBox.Show(DataDupulicationErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 画面を表示する
		/// </summary>
		private void ShowDisplay()
		{
			SetDisplayItems();

			if (EditType == Control.EditType.Register)
				return;

			if (EditType == Control.EditType.Update)
			{
				IdTextBox.Enabled = false;
				return;
			}

			DisableAllItems();
		}

		/// <summary>
		/// 画面項目を設定する
		/// </summary>
		private void SetDisplayItems()
		{
			DepartmentCombBox.DataSource = Departments.Select(x => x.Name).ToList();

			if (EditType == Control.EditType.Register)
				return;

			IdTextBox.Text = string.Format("{0}", SelectedUser.ID);
			NameTextBox.Text = SelectedUser.Name;
			AgeTextBox.Text = string.Format("{0}", SelectedUser.Age);

			if (SelectedUser.Gender == MenText)
			{
				MenRadioButton.Checked = true;
				WomenRadioButton.Checked = false;
			}
			else
			{
				MenRadioButton.Checked = false;
				WomenRadioButton.Checked = true;
			}

			DepartmentCombBox.Text = SelectedUser.Department;
		}

		/// <summary>
		/// 入力項目を取得する
		/// </summary>
		private Model.User GetInputUser()
		{
			var inputUser = new Model.User();
			inputUser.ID = int.Parse(IdTextBox.Text);
			inputUser.Name = NameTextBox.Text;
			inputUser.Age = int.Parse(AgeTextBox.Text);

			if (MenRadioButton.Checked)
				inputUser.Gender = MenText;
			else
				inputUser.Gender = WomenText;

			inputUser.Department = DepartmentCombBox.Text;
			return inputUser;
		}

		/// <summary>
		/// 画面項目の操作を無効にする
		/// </summary>
		private void DisableAllItems()
		{
			IdTextBox.Enabled = false;
			NameTextBox.Enabled = false;
			AgeTextBox.Enabled = false;
			MenRadioButton.Enabled = false;
			WomenRadioButton.Enabled = false;
			DepartmentCombBox.Enabled = false;
		}
	}
}
