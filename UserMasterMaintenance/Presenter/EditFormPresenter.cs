using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMasterMaintenance.Presenter
{
	enum EditItems
	{
		ID,
		Name,
		Age,
		Gender,
		Department
	}

	public enum EditType
	{
		None,
		Register,
		Update,
		Delete
	}

	class EditFormPresenter
	{
		public readonly string ConfirmationText = "確認";

		public readonly string ErrorText = "エラー";

		public readonly string RegisterConfirmationMessage = "登録してよろしいですか？";

		public readonly string UpdateConfirmationMessage = "更新してよろしいですか？";

		public readonly string DeleteConfirmationMessage = "削除してよろしいですか？";

		public readonly string NotInputErrorMessage = "未入力の項目があります";

		public readonly string NotNumberErrorMessage = "半角数字(符号や小数点を除く)を入力してください";

		public readonly string DataDupulicationErrorMessage = "そのIDは既に登録されています";

		/// <summary>
		/// EditFormModel
		/// </summary>
		private Model.EditFormModel EditFormModel { get; set; }

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		public BindingList<Model.User> Users { get; set; }

		/// <summary>
		/// 部門リスト
		/// </summary>
		public List<Model.Department> Departments { get; set; }

		/// <summary>
		/// 選択されたユーザー
		/// </summary>
		public Model.User SelectedUser { get; set; }

		/// <summary>
		/// 入力されたユーザー
		/// </summary>
		public Model.User InputUser { get; set; }

		/// <summary>
		/// 編集タイプ
		/// </summary>
		public EditType EditType { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="editForm"></param>
		/// <param name="listFormPresenter"></param>
		public EditFormPresenter(ListFormPresenter listFormPresenter)
		{
			Users = listFormPresenter.Users ;
			Departments = listFormPresenter.Departments;
			EditType = listFormPresenter.SelectedEditType;
			EditFormModel = new Model.EditFormModel(this);

			if (EditType == EditType.Register)
				return;

			//更新・削除の場合は選択したユーザーを設定する
			SelectedUser = listFormPresenter.SelectedUser;
		}

		/// <summary>
		/// 編集を始める
		/// </summary>
		/// <param name="inputItems"></param>
		public void BeginEdit(Dictionary<EditItems, string> inputItems)
		{
			InputUser = GetConvertedInputUser(inputItems);
			EditFormModel.EditUsers(InputUser);
		}

		/// <summary>
		/// 入力エラーを確認する
		/// </summary>
		/// <param name="inputItems"></param>
		/// <returns></returns>
		public bool ConfirmInputError(Dictionary<EditItems, string> inputItems)
		{
			var errorType = EditFormModel.HasInputError(inputItems);
			if (errorType == ErrorType.None)
				return false;

			ShowErrorDialog(errorType);
			return true;
		}

		/// <summary>
		/// 編集するか確認する
		/// </summary>
		public DialogResult ConfirmEdit()
		{
			var editconfirmationMessage = string.Empty;
			switch (EditType)
			{
				case Presenter.EditType.Register:
					editconfirmationMessage = RegisterConfirmationMessage;
					break;

				case Presenter.EditType.Update:
					editconfirmationMessage = UpdateConfirmationMessage; ;
					break;

				case Presenter.EditType.Delete:
					editconfirmationMessage = DeleteConfirmationMessage;
					break;

				default:
					break;
			}
			return MessageBox.Show(editconfirmationMessage, ConfirmationText, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
		}

		/// <summary>
		/// エラーダイアログを表示する
		/// </summary>
		/// <param name="errorType"></param>
		public void ShowErrorDialog(ErrorType errorType)
		{
			switch (errorType)
			{
				case ErrorType.NotInput:
					MessageBox.Show(NotInputErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case ErrorType.NotNumber:
					MessageBox.Show(NotNumberErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case ErrorType.DataDuplication:
					MessageBox.Show(DataDupulicationErrorMessage, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// 部門リストの部門名をリストにして取得する
		/// </summary>
		/// <returns></returns>
		public List<string> GetDepartmentNames()
		{
			return Departments.Select(x => x.Name).ToList();
		}

		/// <summary>
		/// 入力項目を変換して取得する
		/// </summary>
		public Model.User GetConvertedInputUser(Dictionary<EditItems, string> inputItems)
		{
			var inputUser = new Model.User();
			inputUser.ID = int.Parse(inputItems[Presenter.EditItems.ID]);
			inputUser.Name = inputItems[Presenter.EditItems.Name];
			inputUser.Age = int.Parse(inputItems[Presenter.EditItems.Age]);
			inputUser.Gender = inputItems[Presenter.EditItems.Gender];
			inputUser.Department = inputItems[Presenter.EditItems.Department];
			return inputUser;
		}
	}
}
