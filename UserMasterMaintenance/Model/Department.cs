using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UserMasterMaintenance.Model
{
	[DataContract]
	class Department
	{
		/// <summary>
		/// 部門名
		/// </summary>
		[DataMember(Name = "DepartmentName")]
		public string Name { get; set; } 
	}
}
