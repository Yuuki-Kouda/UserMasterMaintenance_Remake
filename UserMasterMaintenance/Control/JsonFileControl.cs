using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;

namespace UserMasterMaintenance.Control
{
	class JsonFileControl
	{
		/// <summary>
		/// users.jsonのファイルパス
		/// </summary>
		private readonly string UserJsonFilePath = @".\JsonFile\users.json";

		/// <summary>
		/// departments.jsonのファイルパス
		/// </summary>
		private readonly string DepartmentJsonFilePath = @".\JsonFile\departments.json";

		/// <summary>
		/// ユーザーリストを取得する
		/// </summary>
		/// <returns></returns>
		public List<Model.User> GetUsers()
		{
			return Deserialize<List<Model.User>>(GetUserJsonText());
		}

		/// <summary>
		/// 部門リストを取得する
		/// </summary>
		/// <returns></returns>
		public List<Model.Department> GetDepartments()
		{
			return Deserialize<List<Model.Department>>(GetDepartmentJsonText());
		}

		/// <summary>
		/// ユーザー情報を保存する
		/// </summary>
		/// <param name="users"></param>
		public void SaveUsersInFile(List<Model.User> users)
		{
			using (StreamWriter stream = new StreamWriter(UserJsonFilePath))
			{
				stream.Write(users);
			}
		}

		/// <summary>
		/// 部門情報を保存する
		/// </summary>
		/// <param name="departments"></param>
		public void SaveDepartmentsInFile(List<Model.Department> departments)
		{
			var jsontext = Selialize(departments);
			using (StreamWriter stream = new StreamWriter(UserJsonFilePath))
			{
				stream.Write(jsontext);
			}
		}

		/// <summary>
		/// ユーザーのjsonテキストを取得する
		/// </summary>
		/// <returns></returns>
		private string GetUserJsonText()
		{
			try
			{
				using (StreamReader stream = new StreamReader(UserJsonFilePath, Encoding.GetEncoding("shift_jis")))
				{
					var jsonFileText = stream.ReadToEnd();
					return jsonFileText;
				}
			}
			catch (FileNotFoundException)
			{
				throw;
			}
		}

		/// <summary>
		/// 部門のjsonテキストを取得する
		/// </summary>
		/// <returns></returns>
		private string GetDepartmentJsonText()
		{
			try
			{
				using (StreamReader stream = new StreamReader(DepartmentJsonFilePath, Encoding.GetEncoding("shift_jis")))
				{
					var jsonFileText = stream.ReadToEnd();
					return jsonFileText;
				}
			}
			catch (FileNotFoundException)
			{
				throw;
			}
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
