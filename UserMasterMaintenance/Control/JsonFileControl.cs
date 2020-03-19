using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMasterMaintenance.Control
{
	class JsonFileControl
	{
		/// <summary>
		/// ユーザーリスト
		/// </summary>
		public List<Model.User> Users { get; set; }

		/// <summary>
		/// 部門リスト
		/// </summary>
		public List<Model.Department> Departments { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public JsonFileControl()
		{
			Selialize();
		}

		/// <summary>
		/// シリアライズ
		/// </summary>
		public void Selialize()
		{
			
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		public void Desilialize()
		{

		}
	}
}
