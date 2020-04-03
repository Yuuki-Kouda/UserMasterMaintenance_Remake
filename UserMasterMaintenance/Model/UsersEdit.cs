using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserMasterMaintenance.Model
{
    // todo : ユーザーの一覧は、ListFormPresenterが持つべきと思う。ユーザー情報の操作用のクラスは必要？
    // UserクラスにStaticメソッドで実装すれば良いと思うけれど。

	class UsersEdit
	{
		/// <summary>
		/// ユーザーリスト
		/// </summary>
		private List<User> Users { get; set; }

        // todo : これを保持しておく必要性を感じない。
        // 登録するか、上書きするか、削除するかを分岐するのはPresenterの役目だと思う。
        // presenterの状態をmodelが意識し続ける設計は、疎結合になっていないのでNG

		/// <summary>
		/// 編集種類
		/// </summary>
		private Presenter.EditType EditType { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="editType"></param>
		public UsersEdit(Presenter.EditType editType, List<User> users)
		{
			EditType = editType;
			Users = users;
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
		}

		/// <summary>
		/// 更新する
		/// </summary>
		/// <param name="inputUser"></param>
		private void Update(User inputUser)
		{
			var user = Users.First(x => x.ID == inputUser.ID);
			user.OverrideUser(inputUser);
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
