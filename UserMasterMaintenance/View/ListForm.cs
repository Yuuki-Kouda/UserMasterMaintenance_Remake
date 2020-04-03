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
		private readonly string CheckBoxTrueValue = "1";

		private readonly int CheckBoxCellNumber = 0;

		/// <summary>
		/// ListFormPresenter
		/// </summary>
		private Presenter.ListFormPresenter ListFormPresenter { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListForm()
		{
			InitializeComponent();

			ListFormPresenter = new Presenter.ListFormPresenter(this);
			if (ListFormPresenter.ConfirmGetData())
				DisableEditButton();
		}

		/// <summary>
		/// ロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListForm_Load(object sender, EventArgs e)
		{
			ShowList();
		}

		/// <summary>
		/// 閉じるボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CloseButton_Click(object sender, FormClosedEventArgs e)
		{
			ListFormPresenter.BeginSaveData();
		}

		/// <summary>
		/// 登録ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RegisterButton_Click(object sender, EventArgs e)
		{
			ListFormPresenter.ShowEditDialog(Presenter.EditType.Register);
			ShowList();
		}

		/// <summary>
		/// 更新ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			if (ListFormPresenter.ConfirmCheckBoxError())
				return;

			ListFormPresenter.ShowEditDialog(Presenter.EditType.Update);
			ShowList();
		}

		/// <summary>
		/// 削除ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (ListFormPresenter.ConfirmCheckBoxError())
				return;

			ListFormPresenter.ShowEditDialog(Presenter.EditType.Delete);
			ShowList();
		}

		/// <summary>
		/// 画面を表示する
		/// </summary>
		private void ShowList()
		{
			UsersDataGridView.DataSource = ListFormPresenter.UsersForBind;
		}

		/// <summary>
		/// 各編集ボタンを無効にする
		/// </summary>
		private void DisableEditButton()
		{
			RegisterButton.Enabled = false;
			UpdateButton.Enabled = false;
			DeleteButton.Enabled = false;
		}

		/// <summary>
		/// 選択した行を取得する
		/// </summary>
		/// <returns></returns>
		public List<DataGridViewRow> GetSelectedRows()
		{
			return UsersDataGridView.Rows.Cast<DataGridViewRow>().Where(x => (string)x.Cells[CheckBoxCellNumber].Value == CheckBoxTrueValue).ToList();
		}

		/// <summary>
		/// 1つだけ選択した行を取得する
		/// </summary>
		/// <returns></returns>
		public DataGridViewRow GetSelectedRow()
		{
			return UsersDataGridView.Rows.Cast<DataGridViewRow>().First(x => (string)x.Cells[CheckBoxCellNumber].Value == CheckBoxTrueValue);
		}
	}
}
