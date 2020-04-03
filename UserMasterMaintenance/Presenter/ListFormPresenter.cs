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
		FileNotFound,
		DataCanNotSaveToFile,
		NotInput,
		NotNumber,
		DataDuplication,
	}

	public class ListFormPresenter
	{
		private readonly string ErrorText = "エラー";

		private readonly string CheckBoxErrorMessage = "1行だけチェックしてからボタンを押してください";

		private readonly string FileNotFoundErrorMessage = "情報を記録したファイルが存在しません";

		private readonly string DataCanNotSaveToFileErrorMessage = "保存できませんでした";

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

			//編集したユーザー情報をIDの昇順に並べバインドリストに
			UsersForBind = new BindingList<Model.User>(Users.OrderBy(x => x.ID).ToList());
		}

		/// <summary>
		/// データの保存を始める
		/// </summary>
		public void BeginSaveData()
		{
			if (!JsonFileModel.TrySaveData(Users, Departments))
				ShowErrorDialog(ErrorType.DataCanNotSaveToFile);
		}

		/// <summary>
		/// データを取得できるか確認する
		/// </summary>
		/// <returns></returns>
		public bool ConfirmGetData()
		{
			Users = JsonFileModel.GetUsers();
			Departments = JsonFileModel.GetDepartments();
			if (Users == null || Departments == null)
			{
				ShowErrorDialog(ErrorType.FileNotFound);
				return true;
			}

			UsersForBind = new BindingList<Model.User>(Users);

			return false;
		}

		/// <summary>
		/// チェックボックスエラーを確認する
		/// </summary>
		/// <returns></returns>
		public bool ConfirmCheckBoxError()
		{
			if (ValidateCheckBox(ListForm.GetSelectedRows()))
				return false;

			ShowErrorDialog(ErrorType.CheckBox);
			return true;
		}

		/// <summary>
		/// チェックボックスエラーがあるか
		/// </summary>
		/// <returns></returns>
		private bool ValidateCheckBox(List<DataGridViewRow> dataGridViewRows)
		{
			//1件以外はエラー
			if (dataGridViewRows.Count != 1)
				return false;

			return true;
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

				case ErrorType.FileNotFound:
					MessageBox.Show(FileNotFoundErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case ErrorType.DataCanNotSaveToFile:
					MessageBox.Show(DataCanNotSaveToFileErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				default:
					break;
			}
		}
	}
}
