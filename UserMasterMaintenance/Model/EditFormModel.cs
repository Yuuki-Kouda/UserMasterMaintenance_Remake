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
        // todo : ModelがPresenterを知るのはおかしい
        // todo : Edit Form の Model？それはモデルじゃない。

		/// <summary>
		/// EditFormPresenter
		/// </summary>
		private Presenter.EditFormPresenter EditFormPresenter { get; set; }

        // todo : モデルがBindingListを提供するのは違和感がある。Viewを意識しちゃってる。

		/// <summary>
		/// ユーザーリスト
		/// </summary>
		private BindingList<User> Users { get; set; }

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
		public void EditUsers(User user)
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
		private void Register(User inputUser)
		{
			Users.Add(inputUser);
			Users = new BindingList<User>(Users.OrderBy(x => x.ID).ToList());
		}

		/// <summary>
		/// 更新する
		/// </summary>
		/// <param name="inputUser"></param>
		private void Update(User inputUser)
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
		private void Delete(User inputUser)
		{
			var user = Users.First(x => x.ID == inputUser.ID);
			Users.Remove(user);
		}

		/// <summary>
		/// 重複データがあるかどうか
		/// </summary>
		/// <returns></returns>
		public bool HasDupulicationData(int iD)
		{
			//重複すればtrue
			return Users.Any(x => x.ID == iD);
		}
	}
}
