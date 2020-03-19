using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Gender
{
	Men,
	Women
}

namespace UserMasterMaintenance.Model
{
	class User
	{
		/// <summary>
		/// ID
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// 名前
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 年齢
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// 性別
		/// </summary>
		public Gender Gender { get; set; }

		/// <summary>
		/// 所属部門
		/// </summary>
		public Department Department { get; set; }
	}
}
