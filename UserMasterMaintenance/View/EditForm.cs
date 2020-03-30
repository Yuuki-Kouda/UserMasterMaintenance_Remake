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
		public readonly string MenText = "男性";

		public readonly string WomenText = "女性";

		/// <summary>
		/// EditFormPresenter
		/// </summary>
		private Presenter.EditFormPresenter EditFormPresenter { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="listForm"></param>
		public EditForm(BindingList<Model.User> users, List<Model.Department> departments, Presenter.EditType editType, Model.User selectedUser)
		{
			InitializeComponent();

			EditFormPresenter = new Presenter.EditFormPresenter(users, departments, editType, selectedUser); 

			ShowDisplay();
		}

		/// <summary>
		/// OKボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OKButton_Click(object sender, EventArgs e)
		{
			if (EditFormPresenter.ConfirmInputError(GetInputItems()))
				return;
			
			if (EditFormPresenter.ConfirmEdit() == DialogResult.Cancel)
				return;

			EditFormPresenter.BeginEdit(GetInputItems());

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
		/// 画面を表示する
		/// </summary>
		private void ShowDisplay()
		{
			SetDisplayItems();

			if (EditFormPresenter.EditType == Presenter.EditType.Register)
				return;

			if (EditFormPresenter.EditType == Presenter.EditType.Update)
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
			DepartmentCombBox.DataSource = EditFormPresenter.GetDepartmentNames().ToList();

			if (EditFormPresenter.EditType == Presenter.EditType.Register)
				return;

			IdTextBox.Text = string.Format("{0}", EditFormPresenter.SelectedUser.ID);
			NameTextBox.Text = EditFormPresenter.SelectedUser.Name;
			AgeTextBox.Text = string.Format("{0}", EditFormPresenter.SelectedUser.Age);

			if (EditFormPresenter.SelectedUser.Gender == MenText)
			{
				MenRadioButton.Checked = true;
				WomenRadioButton.Checked = false;
			}
			else
			{
				MenRadioButton.Checked = false;
				WomenRadioButton.Checked = true;
			}

			DepartmentCombBox.Text = EditFormPresenter.SelectedUser.Department;
		}

		/// <summary>
		/// 入力項目を取得する
		/// </summary>
		private Dictionary<Presenter.EditItems, string> GetInputItems()
		{
			var inputGender = string.Empty;
			if (MenRadioButton.Checked)
				inputGender = MenText;
			else
				inputGender = WomenText;

			var inputItems = new Dictionary<Presenter.EditItems, string>()
			{
				{Presenter.EditItems.ID, IdTextBox.Text},
				{Presenter.EditItems.Name ,NameTextBox.Text},
				{Presenter.EditItems.Age, AgeTextBox.Text},
				{Presenter.EditItems.Gender, inputGender},
				{Presenter.EditItems.Department, DepartmentCombBox.Text}
			};
			return inputItems;
		}

		/// <summary>
		/// 入力エラーを確認する
		/// </summary>
		/// <returns></returns>
		private bool ConfirmInputError()
		{
			if (EditFormPresenter.ValidateNotInput(IdTextBox.Text))
				return true;
			if (EditFormPresenter.ValidateNotNumber(IdTextBox.Text))
				return true;

			if (EditFormPresenter.ValidateNotInput(NameTextBox.Text))
				return true;

			if (EditFormPresenter.ValidateNotInput(AgeTextBox.Text))
				return true;
			if (EditFormPresenter.ValidateNotNumber(AgeTextBox.Text))
				return true;

			if (EditFormPresenter.ValidateDupulicationData(IdTextBox.Text))
				return true;

			return false;
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
