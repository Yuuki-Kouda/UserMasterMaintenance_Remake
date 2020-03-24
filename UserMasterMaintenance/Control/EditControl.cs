using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMasterMaintenance.Control
{
	public enum EditType
	{
		None,
		Register,
		Update,
		Delete
	}

	class EditControl
	{
		/// <summary>
		/// ユーザーリスト
		/// </summary>
		private BindingList<Model.User> Users { get; set; }

		/// <summary>
		/// 編集種類
		/// </summary>
		private EditType EditType { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="editType"></param>
		public EditControl(View.ListForm listForm)
		{
			EditType = listForm.SelectedEditType;
			Users = listForm.Users;
		}

		/// <summary>
		/// 編集する
		/// </summary>
		public void Edit(Model.User user)
		{
			switch (EditType)
			{
				case EditType.Register:
					Register(user);
					break;

				case EditType.Update:
					Update(user);
					break;

				case EditType.Delete:
					Delete(user);
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// 登録する
		/// </summary>
		/// <param name="user"></param>
		private void Register(Model.User user)
		{
			Users.Add(user);
		}

		/// <summary>
		/// 更新する
		/// </summary>
		/// <param name="selectedUser"></param>
		private void Update(Model.User selectedUser)
		{
			Users.Where(x => x.ID == selectedUser.ID).Select(x => x = selectedUser).ToList();
		}

		/// <summary>
		/// 削除する
		/// </summary>
		/// <param name="selectedUser"></param>
		private void Delete(Model.User selectedUser)
		{
			foreach(var user in Users)
			{
				if(user.ID == selectedUser.ID)
					Users[]
			}
			Users.re(x => x.ID == selectedUser.ID);
		}

		/// <summary>
		/// 重複データがあるかどうか
		/// </summary>
		/// <returns></returns>
		public bool HasDupulicationData(Model.User selectedUser)
		{
			//重複すればtrue
			return Users.Any(x => x.ID == selectedUser.ID);
		}
	}
}
