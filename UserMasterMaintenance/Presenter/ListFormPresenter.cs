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
		UsersFileNotFound,
		DepartmentsFileNotFound,
		UsersCanNotSaveToFile,
		DepartmentsCanNotSaveToFile,
		NotInput,
		NotNumber,
		DataDuplication,
	}

	public class ListFormPresenter
	{
		private readonly string ErrorText = "エラー";

		private readonly string CheckBoxErrorMessage = "1行だけチェックしてからボタンを押してください";

		private readonly string UsersFileNotFoundErrorMessage = "ユーザー情報を記録したファイルが存在しません";

		private readonly string DepartmentsFileNotFoundErrorMessage = "部門情報を記録したファイルが存在しません";

		private readonly string UsersCanNotSaveToFileErrorMessage = "ユーザー情報が保存できませんでした";

		private readonly string DepartmentsCanNotSaveToFileErrorMessage = "部門情報が保存できませんでした";

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
		/// バインド用ユーザーリスト
		/// </summary>
		public BindingList<Model.User> UsersForBind { get; set; }

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		public List<Model.User> Users { get; set; }

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
		}

		/// <summary>
		/// 編集ダイアログを表示する
		/// </summary>
		/// <param name="editType"></param>
		public void ShowEditDialog(EditType editType)
		{
			switch (editType)
			{
				case EditType.Register:
					SelectedEditType = EditType.Register;

					break;

				case EditType.Update:
					SelectedUser = GetSelctedUser(ListForm.GetSelectedRow());
					SelectedEditType = EditType.Update;

					break;

				case EditType.Delete:
					SelectedUser = GetSelctedUser(ListForm.GetSelectedRow());
					SelectedEditType = EditType.Delete;

					break;
			}

			View.EditForm editForm = new View.EditForm(Users, Departments, SelectedEditType, SelectedUser);
			editForm.ShowDialog();

			//編集したユーザー情報をIDの昇順にに並べバインドリストに
			UsersForBind = new BindingList<Model.User>(Users.OrderBy(x => x.ID).ToList());
		}

		/// <summary>
		/// データの保存を始める
		/// </summary>
		public void BeginSaveData()
		{
			if (!JsonFileModel.TrySaveUsers(Users))
				ShowErrorDialog(ErrorType.UsersCanNotSaveToFile);

            // todo : 所属のほうでエラーが起きたら、中途半端なデータが登録される

			if (!JsonFileModel.TrySaveDepartments(Departments))
				ShowErrorDialog(ErrorType.DepartmentsCanNotSaveToFile);
		}

		/// <summary>
		/// データを取得できるか確認する
		/// </summary>
		/// <returns></returns>
		public bool ConfirmGetData()
		{
			var hasError = false;

			Users = JsonFileModel.GetUsers();
			if(Users == null)
			{
				ShowErrorDialog(ErrorType.UsersFileNotFound);
				hasError = true;
			}
			UsersForBind = new BindingList<Model.User>(Users);

			Departments = JsonFileModel.GetDepartments();
			if(Departments == null)
			{
				ShowErrorDialog(ErrorType.DepartmentsFileNotFound);
				hasError = true;
			}

			return hasError;
		}

		/// <summary>
		/// チェックボックスエラーを確認する
		/// </summary>
		/// <returns></returns>
		public bool ConfirmCheckBoxError()
		{
			if (ValidateCheckBox(ListForm.GetSelectedRows()) == ErrorType.None)
				return false;

			ShowErrorDialog(ErrorType.CheckBox);
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
		private Model.User GetSelctedUser(DataGridViewRow selectedRow)
		{
			var selectedUser = Users.First(x => x.ID == (int)selectedRow.Cells[IDCellNumber].Value);
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
