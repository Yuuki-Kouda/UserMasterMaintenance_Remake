﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserMasterMaintenance.Model
{
	class UsersEditModel
	{
		/// <summary>
		/// ユーザーリスト
		/// </summary>
		private List<User> Users { get; set; }

		/// <summary>
		/// 編集種類
		/// </summary>
		private Presenter.EditType EditType { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="editType"></param>
		public UsersEditModel(Presenter.EditType editType, List<User> users)
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