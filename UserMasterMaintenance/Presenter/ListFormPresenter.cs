﻿using System;
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
		DataDuplication
	}

	public class ListFormPresenter
	{
		private readonly string ErrorText = "エラー";

		private readonly string CheckBoxErrorMessageText = "1行だけチェックしてからボタンを押してください";

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
		}

        // todo  誤 Bigin  正 Begin

		/// <summary>
		/// データの保存を始める
		/// </summary>
		public void BiginSaveData()
		{
			JsonFileModel.SaveUsersInJsonFile(Users);
			JsonFileModel.SaveDepartmentsInJsonFile(Departments);
		}

		/// <summary>
		/// 登録ダイアログを表示する
		/// </summary>
		public void ShowRegisterDialog()
		{
			SelectedEditType = EditType.Register;

            // todo View が 他のPresenter を知っているのはNG
            // 伝達するならModelをやりとりすべき。

			View.EditForm editForm = new View.EditForm(this);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 更新ダイアログを表示する
		/// </summary>
		public void ShowUpdateDialog()
		{
			SelectedUser = ListFormModel.GetSelctedUser(ListForm.GetSelectedRows());
			SelectedEditType = EditType.Update;
			View.EditForm editForm = new View.EditForm(this);
			editForm.ShowDialog();
		}

		/// <summary>
		/// 削除ダイアログを表示する
		/// </summary>
		public void ShowDeleteDialog()
		{
			SelectedUser = ListFormModel.GetSelctedUser(ListForm.GetSelectedRows());
			SelectedEditType = EditType.Delete;
			View.EditForm editForm = new View.EditForm(this);
			editForm.ShowDialog();
		}

		/// <summary>
		/// チェックボックスエラーを確認する
		/// </summary>
		/// <returns></returns>
		public bool ConfirmCheckBoxError()
		{
			if (ListFormModel.ValidateCheckBox(ListForm.GetSelectedRows()) == ErrorType.CheckBox)
			{
				ShowCheckBoxErrorDialog();
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
		/// チェックボックスエラーダイアログを表示する
		/// </summary>
		private void ShowCheckBoxErrorDialog()
		{
			MessageBox.Show(CheckBoxErrorMessageText, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// ユーザー情報が存在しないエラーダイアログを表示する
		/// </summary>
		private void ShowNotExistUsersDataErrorDialog()
		{
			MessageBox.Show(CheckBoxErrorMessageText, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 部門情報が存在しないエラーダイアログを表示する
		/// </summary>
		private void ShowNotExistDepartmentsDataErrorDialog()
		{
			MessageBox.Show(CheckBoxErrorMessageText, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// ユーザー情報が保存できないエラーダイアログを表示する
		/// </summary>
		private void ShowCanNotSaveUsersData()
		{
			MessageBox.Show(CheckBoxErrorMessageText, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 部門情報が保存できないエラーダイアログを表示する
		/// </summary>
		private void ShowCanNotSaveDepartmentsData()
		{
			MessageBox.Show(CheckBoxErrorMessageText, ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
