using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMasterMaintenance.Model
{
	class ListFormModel
	{
		private readonly int IDCellNumber = 1;

		/// <summary>
		/// ListFormPresenter
		/// </summary>
		private Presenter.ListFormPresenter ListFormPresenter { get; set; }

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		private BindingList<User> Users { get; set; }

		/// <summary>
		/// 部門リスト
		/// </summary>
		private List<Department> Departments { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="listFormPresenter"></param>
		public ListFormModel(Presenter.ListFormPresenter listFormPresenter)
		{
			ListFormPresenter = listFormPresenter;
			Users = ListFormPresenter.Users;
			Departments = ListFormPresenter.Departments;
		}

		/// <summary>
		/// チェックボックスエラーがあるか
		/// </summary>
		/// <returns></returns>
		public Presenter.ErrorType ValidateCheckBox(List<DataGridViewRow> dataGridViewRows)
		{
			//1件以外はエラー
			if (dataGridViewRows.Count != 1)
				return Presenter.ErrorType.CheckBox;

			return Presenter.ErrorType.None;
		}

		/// <summary>
		/// 選択されたユーザーを取得する
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		public Model.User GetSelctedUser(List<DataGridViewRow> dataGridViewRows)
		{
			var selectedUser = Users.First(x => x.ID == (int)dataGridViewRows.First().Cells[IDCellNumber].Value);
			return selectedUser;
		}
	}
}
