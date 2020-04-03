using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace UserMasterMaintenance.Model
{
	public enum FileType
	{
		None,
		User,
		Department
	}

	class JsonFileEdit
	{
		/// <summary>
		/// users.jsonのファイルパス
		/// </summary>
		private readonly string UsersJsonFilePath = @"..\..\JsonFile\users.json";

		/// <summary>
		/// departments.jsonのファイルパス
		/// </summary>
		private readonly string DepartmentsJsonFilePath = @"..\..\JsonFile\departments.json";

        /// <summary>
        /// ユーザーリストを取得する
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
		{
			var usersJsonText = TryGetJsonText(UsersJsonFilePath);
			if (usersJsonText == null)
				return new List<User>();

			return Deserialize<List<User>>(usersJsonText);
		}

		/// <summary>
		/// 部門リストを取得する
		/// </summary>
		/// <returns></returns>
		public List<Department> GetDepartments()
		{
			var departmentsJsonText = TryGetJsonText(DepartmentsJsonFilePath);
			if (departmentsJsonText == null)
				return new List<Department>();

			return Deserialize<List<Department>>(departmentsJsonText);
		}

		/// <summary>
		/// データを保存する
		/// </summary>
		/// <param name="users"></param>
		public bool TrySaveData(object list, FileType fileType)
		{
			var filePath = string.Empty;
			switch (fileType)
			{
				case FileType.User:
					filePath = UsersJsonFilePath;
					break;

				case FileType.Department:
					filePath = DepartmentsJsonFilePath;
					break;

				default:
					return false;
			}

			var jsonText = Selialize(list);
			try
			{
				using (StreamWriter Stream = new StreamWriter(filePath, false, Encoding.UTF8))
				{
					Stream.Write(jsonText);
				}
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// jsonテキストを取得する
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private string TryGetJsonText(string filePath)
		{
			try
			{
				using (StreamReader stream = new StreamReader(filePath, Encoding.GetEncoding("shift_jis")))
				{
					var jsonFileText = stream.ReadToEnd();
					return jsonFileText;
				}
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// シリアライズ
		/// </summary>
		private string Selialize(object list)
		{
			return JsonConvert.SerializeObject(list, Formatting.Indented);
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
