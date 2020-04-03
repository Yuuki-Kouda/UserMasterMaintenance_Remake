using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
		public readonly string RegiterText = "登録";

		public readonly string UpdateText = "更新";

		public readonly string DeleteText = "削除";

		public readonly string ConfirmationText = "確認";

		public readonly string ErrorText = "エラー";

		public readonly string RegisterConfirmationMessage = "登録してよろしいですか？";

		public readonly string UpdateConfirmationMessage = "更新してよろしいですか？";

		public readonly string DeleteConfirmationMessage = "削除してよろしいですか？";

		public readonly string NotInputErrorMessage = "未入力の項目があります";

		public readonly string NotNumberErrorMessage = "IDと年齢は半角数字(符号や小数点を除く)で入力してください";

		public readonly string DataDupulicationErrorMessage = "そのIDは既に登録されています";

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		public List<Model.User> Users { get; set; }

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
		public EditFormPresenter(List<Model.User> users, List<Model.Department> departments, EditType editType, Model.User selectedUser)
		{
			Users = users ;
			Departments = departments;
			EditType = editType;

			if (EditType == EditType.Register)
				return;

			//更新・削除の場合は選択したユーザーを設定する
			SelectedUser = selectedUser;
		}

		/// <summary>
		/// ユーザーを編集する
		/// </summary>
		/// <param name="inputItems"></param>
		public void EditUser(Dictionary<EditItems, string> inputItems)
		{
			var inputUser = GetConvertedInputUser(inputItems);
			switch (EditType)
			{
				case EditType.Register:
					Register(inputUser);
					break;

				case EditType.Update:
					Update(inputUser);
					break;

				case EditType.Delete:
					Delete(inputUser);
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// 登録する
		/// </summary>
		/// <param name="inputUser"></param>
		private void Register(Model.User inputUser)
		{
			Users.Add(inputUser);
		}

		/// <summary>
		/// 更新する
		/// </summary>
		/// <param name="inputUser"></param>
		private void Update(Model.User inputUser)
		{
			var user = Users.First(x => x.ID == inputUser.ID);
			user.OverrideUser(inputUser);
		}

		/// <summary>
		/// 削除する
		/// </summary>
		/// <param name="inputUser"></param>
		private void Delete(Model.User inputUser)
		{
			var user = Users.First(x => x.ID == inputUser.ID);
			Users.Remove(user);
		}

		/// <summary>
		/// 未入力エラーチェック
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public bool ValidateInputed(string text)
		{
			if (!string.IsNullOrWhiteSpace(text))
				return true;

			ShowErrorDialog(ErrorType.NotInput);
			return false;
		}

        /// <summary>
        /// 数値エラーチェック
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool ValidateNumbers(string text)
		{
			if (new Regex("^[0-9]+$").IsMatch(text))
				return true;

			ShowErrorDialog(ErrorType.NotNumber);
			return false;
		}

        /// <summary>
        /// 重複エラーチェック
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool ValidateDupulicationData(string text)
		{
			var iD = int.Parse(text);
			if (!Users.Any(x => x.ID == iD))
				return false;

			ShowErrorDialog(ErrorType.DataDuplication);
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
				case EditType.Register:
					editconfirmationMessage = RegisterConfirmationMessage;
					break;

				case EditType.Update:
					editconfirmationMessage = UpdateConfirmationMessage; ;
					break;

				case EditType.Delete:
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
		/// 編集名を取得する
		/// </summary>
		/// <returns></returns>
		public string GetEditName()
		{
			switch (EditType)
			{
				case EditType.Register:
					return RegiterText;

				case EditType.Update:
					return UpdateText;

				case EditType.Delete:
					return DeleteText;

				default:
					return null;
			}
		}

		/// <summary>
		/// 部門リストの部門名をリストにして取得する
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> GetDepartmentNames()
		{
			return Departments.Select(x => x.Name);
		}

		/// <summary>
		/// 入力項目を変換して取得する
		/// </summary>
		public Model.User GetConvertedInputUser(Dictionary<EditItems, string> inputItems)
		{
			var inputUser = new Model.User();
			inputUser.ID = int.Parse(inputItems[EditItems.ID]);
			inputUser.Name = inputItems[EditItems.Name];
			inputUser.Age = int.Parse(inputItems[EditItems.Age]);
			inputUser.Gender = inputItems[EditItems.Gender];
			inputUser.Department = inputItems[EditItems.Department];
			return inputUser;
		}
	}
}
