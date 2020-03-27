using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserMasterMaintenance.Model
{
	class EditFormModel
	{
		/// <summary>
		/// EditFormPresenter
		/// </summary>
		private Presenter.EditFormPresenter EditFormPresenter { get; set; }

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		private BindingList<Model.User> Users { get; set; }

		/// <summary>
		/// 編集種類
		/// </summary>
		private Presenter.EditType EditType { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="editType"></param>
		public EditFormModel(Presenter.EditFormPresenter editFormPresenter)
		{
			EditFormPresenter = editFormPresenter;
			EditType = editFormPresenter.EditType;
			Users = EditFormPresenter.Users;
		}

		/// <summary>
		/// 編集する
		/// </summary>
		public void EditUsers(Model.User user)
		{
			switch (EditType)
			{
				case Presenter.EditType.Register:
					Register(user);
					break;

				case Presenter.EditType.Update:
					Update(user);
					break;

				case Presenter.EditType.Delete:
					Delete(user);
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

			user.Name = inputUser.Name;
			user.Age = inputUser.Age;
			user.Gender = inputUser.Gender;
			user.Department = inputUser.Department;
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
		/// 入力にエラーがあるか
		/// </summary>
		/// <returns></returns>
		public Presenter.ErrorType HasInputError(Dictionary<Presenter.EditItems, string> inputItems)
		{
			if (EditType == Presenter.EditType.Delete)
				return Presenter.ErrorType.None;

			//入力チェック
			var inputError = ValidateInputItems(inputItems);
			if (inputError != Presenter.ErrorType.None)
				return inputError;

			if (EditType == Presenter.EditType.Update)
				return Presenter.ErrorType.None;

			//重複データチェック
			var dupulicationError = ValidateData(EditFormPresenter.GetConvertedInputUser(inputItems));
			if (dupulicationError == Presenter.ErrorType.DataDuplication)
				return dupulicationError;

			return Presenter.ErrorType.None;
		}

		/// <summary>
		/// 入力エラーチェック
		/// </summary>
		/// <returns></returns>
		public Presenter.ErrorType ValidateInputItems(Dictionary<Presenter.EditItems, string> inputUser)
		{
			//未入力チェック
			if (string.IsNullOrEmpty(inputUser[Presenter.EditItems.ID]))
				return Presenter.ErrorType.NotInput;

			if (string.IsNullOrEmpty(inputUser[Presenter.EditItems.Name]))
				return Presenter.ErrorType.NotInput;

			if (string.IsNullOrEmpty(inputUser[Presenter.EditItems.Age]))
				return Presenter.ErrorType.NotInput;

			//数値チェック
			if (!(new Regex("^[0-9]+$").IsMatch(inputUser[Presenter.EditItems.ID])))
				return Presenter.ErrorType.NotNumber;

			if (!(new Regex("^[0-9]+$").IsMatch(inputUser[Presenter.EditItems.Age])))
				return Presenter.ErrorType.NotNumber;

			return Presenter.ErrorType.None;
		}

		/// <summary>
		/// 重複エラーチェック
		/// </summary>
		/// <returns></returns>
		public Presenter.ErrorType ValidateData(User inputUser)
		{
			//重複チェック
			if (HasDupulicationData(inputUser))
				return Presenter.ErrorType.DataDuplication;

			return Presenter.ErrorType.None;
		}

		/// <summary>
		/// 重複データがあるかどうか
		/// </summary>
		/// <returns></returns>
		private bool HasDupulicationData(Model.User selectedUser)
		{
			//重複すればtrue
			return Users.Any(x => x.ID == selectedUser.ID);
		}
	}
}
