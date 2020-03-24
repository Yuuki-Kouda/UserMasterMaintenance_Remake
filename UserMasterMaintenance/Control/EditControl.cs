using System;
using System.Collections.Generic;
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
		public EditControl(EditType editType)
		{
			EditType = editType;
		}

		/// <summary>
		/// 編集する
		/// </summary>
		public void DoEdit()
		{
			switch (EditType)
			{
				case EditType.Register:
					break;
				case EditType.Update:
					break;
				case EditType.Delete:
					break;
				default:
					break;
			}
		}

		private void Register()
		{

		}

		private void Update()
		{

		}

		private void Delete()
		{

		}
	}
}
