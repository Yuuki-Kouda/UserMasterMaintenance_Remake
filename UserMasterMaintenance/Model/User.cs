using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

public enum GenderType
{
	Nonn,
	Men,
	Women
}

namespace UserMasterMaintenance.Model
{
	[DataContract]
	public class User
	{
		/// <summary>
		/// ID
		/// </summary>]
		[DataMember(Name = "Id")]
		public int ID { get; set; }

		/// <summary>
		/// 名前
		/// </summary>
		[DataMember(Name = "Name")]
		public string Name { get; set; }

		/// <summary>
		/// 年齢
		/// </summary>
		[DataMember(Name = "Age")]
		public int Age { get; set; }

		/// <summary>
		/// 性別
		/// </summary>
		[DataMember(Name = "Gender")]
		public string Gender { get; set; }

		/// <summary>
		/// 所属部門
		/// </summary>
		[DataMember(Name = "Department")]
		public string Department { get; set; }
	}
}
