﻿using System;
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
			ListFormPresenter.BiginSaveData();
		}

		/// <summary>
		/// 登録ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RegisterButton_Click(object sender, EventArgs e)
		{
			ListFormPresenter.ShowRegisterDialog();
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

			ListFormPresenter.ShowUpdateDialog();
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

			ListFormPresenter.ShowDeleteDialog();
		}

		/// <summary>
		/// 画面を表示する
		/// </summary>
		private void ShowDisplay()
		{
			UsersDataGridView.DataSource = ListFormPresenter.Users;
		}

		/// <summary>
		/// 選択した行を取得する
		/// </summary>
		/// <returns></returns>
		public List<DataGridViewRow> GetSelectedRows()
		{
			return UsersDataGridView.Rows.Cast<DataGridViewRow>().Where(x => (string)x.Cells[CheckBoxCellNumber].Value == CheckBoxTrueValue).ToList();
		}
	}
}
