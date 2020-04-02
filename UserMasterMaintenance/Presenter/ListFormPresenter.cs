using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMasterMaintenance.Presenter
{
	public enum ErrorType
	{
		None,
		CheckBox,
		NotInput,
		NotNumber,
		DataDuplication,
		AcquisitionFailure,
		SaveFailure
	}

	public class ListFormPresenter
	{
		private readonly string ErrorText = "エラー";

		private readonly string CheckBoxErrorMessageText = "1行だけチェックしてからボタンを押してください";

		private readonly string NotExistUsersDataFileErrorMessageText = "ユーザー情報を記録したファイルが存在しません";

		private readonly string NotExistDepartmentsDataFileErrorMessageText = "部門情報を記録したファイルが存在しません";

		private readonly string CantSaveUsersDataErrorMessageText = "ユーザー情報が保存できませんでした";

		private readonly string CantSaveDepartmentsDataErrorMessageText = "ユーザー情報が保存できませんでした";

		private readonly int IDCellNumber = 1;

		/// <summary>
		/// ListForm
		/// </summary>
		private View.ListForm ListForm { get; set; }

		/// <summary>
		/// JsonFileModel
		/// </summary>
		private Model.JsonFileEditModel JsonFileModel { get; set; }

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
		public EditType SelectedEditType { get; set; }

		/// <summary>
		/// 選択したユーザー
		/// </summary>
		public Model.User SelectedUser { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="listForm"></param>
		public ListFormPresenter(View.ListForm listForm)
		{
			ListForm = listForm;
			JsonFileModel = new Model.JsonFileEditModel();
			Users = JsonFileModel.TryGetUsers();
			Departments = JsonFileModel.TryGetDepartments();
		}

		/// <summary>
		/// データの保存を始める
		/// </summary>
		public void BeginSaveData()
		{
			ConfirmSaved();
		}

		/// <summary>
		/// 登録ダイアログを表示する
		/// </summary>
		public void ShowRegisterDialog()
		{
			SelectedEditType = EditType.Register;

			View.EditForm editForm = new View.EditForm(Users, Departments, SelectedEditType, SelectedUser);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 更新ダイアログを表示する
		/// </summary>
		public void ShowUpdateDialog()
		{
			SelectedUser = GetSelctedUser(ListForm.GetSelectedRows());
			SelectedEditType = EditType.Update;
			View.EditForm editForm = new View.EditForm(Users, Departments, SelectedEditType, SelectedUser);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 削除ダイアログを表示する
		/// </summary>
		public void ShowDeleteDialog()
		{
			SelectedUser = GetSelctedUser(ListForm.GetSelectedRows());
			SelectedEditType = EditType.Delete;
			View.EditForm editForm = new View.EditForm(Users, Departments, SelectedEditType, SelectedUser);
			editForm.ShowDialog();
		}

		/// <summary>
		/// データが存在するか確認する
		/// </summary>
		/// <returns></returns>
		public bool ConfirmExistData()
		{
			if (Users == null)
			{
				ShowNotExistUsersDataErrorDialog();
				return true;
			}

			if (Departments == null)
			{
				ShowNotExistDepartmentsDataErrorDialog();
				return true;
			}

			return false;
		}

		/// <summary>
		/// セーブできたか確認する
		/// </summary>
		public void ConfirmSaved()
		{
			if (JsonFileModel.TrySaveUsers(Users) == ErrorType.SaveFailure)
				ShowCanNotSaveUsersData();

			if (JsonFileModel.TrySaveDepartments(Departments) == ErrorType.SaveFailure)
				ShowCanNotSaveDepartmentsData();
		}

		/// <summary>
		/// チェックボックスエラーを確認する
		/// </summary>
		/// <returns></returns>
		public bool ConfirmCheckBoxError()
		{
			if (ValidateCheckBox(ListForm.GetSelectedRows()) == ErrorType.None)
				return false;

			ShowCheckBoxErrorDialog();
			return true;
		}

		/// <summary>
		/// チェックボックスエラーがあるか
		/// </summary>
		/// <returns></returns>
		private ErrorType ValidateCheckBox(List<DataGridViewRow> dataGridViewRows)
		{
			//1件以外はエラー
			if (dataGridViewRows.Count != 1)
				return ErrorType.CheckBox;

			return ErrorType.None;
		}

		/// <summary>
		/// 選択されたユーザーを取得する
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		private Model.User GetSelctedUser(List<DataGridViewRow> dataGridViewRows)
		{
			var selectedUser = Users.First(x => x.ID == (int)dataGridViewRows.First().Cells[IDCellNumber].Value);
			return selectedUser;
		}

		/// <summary>
		/// エラーダイアログを表示する
		/// </summary>
		/// <param name="errorType"></param>
		public void ShowErrorDialog(ErrorType errorType)
		{
			switch (errorType)
			{
				case ErrorType.CheckBox:
					MessageBox.Show(CheckBoxErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case ErrorType.UsersFileNotFound:
					MessageBox.Show(UsersFileNotFoundErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case ErrorType.DepartmentsFileNotFound:
					MessageBox.Show(DepartmentsFileNotFoundErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case ErrorType.UsersCanNotSaveToFile:
					MessageBox.Show(UsersCanNotSaveToFileErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case ErrorType.DepartmentsCanNotSaveToFile:
					MessageBox.Show(DepartmentsCanNotSaveToFileErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				default:
					break;
			}
		}
	}
}
