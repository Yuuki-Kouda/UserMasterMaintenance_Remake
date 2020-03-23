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
		}

		/// <summary>
		/// シリアライズ
		/// </summary>
		private string Selialize(object someting)
		{
			try
			{
				return JsonConvert.SerializeObject(someting, Formatting.Indented);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		private T Deserialize<T>(string jsonText)
		{
			using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonText)))
			{
				var serializer = new DataContractJsonSerializer(typeof(T));
				return (T)serializer.ReadObject(stream);
			}
		}
	}
}
