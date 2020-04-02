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
	class JsonFileEditModel
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
		public BindingList<User> GetUsers()
		{
			var usersJsonText = TryGetUsersJsonText();
			if (usersJsonText == null)
				return null;

			return Deserialize<BindingList<User>>(usersJsonText);
		}

		/// <summary>
		/// 部門リストを取得する
		/// </summary>
		/// <returns></returns>
		public List<Department> GetDepartments()
		{
			var departmentsJsonText = TryGetDepartmentsJsonText();
			if (departmentsJsonText == null)
				return null;

			return Deserialize<List<Department>>(departmentsJsonText);
		}

		/// <summary>
		/// ユーザー情報を保存する
		/// </summary>
		/// <param name="users"></param>
		public bool TrySaveUsers(Collection<User> users)
		{
			var jsontext = Selialize(users);
			try
			{
				using (StreamWriter stream = new StreamWriter(UsersJsonFilePath, false, Encoding.UTF8))
				{
					stream.Write(jsontext);
				}
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 部門情報を保存する
		/// </summary>
		/// <param name="departments"></param>
		public bool TrySaveDepartments(List<Department> departments)
		{
			var jsontext = Selialize(departments);
			try
			{
				using (StreamWriter stream = new StreamWriter(DepartmentsJsonFilePath, false, Encoding.UTF8))
				{
					stream.Write(jsontext);
				}
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// ユーザーのjsonテキストを取得する
		/// </summary>
		/// <returns></returns>
		private string TryGetUsersJsonText()
		{
            // todo : ファイルの存在チェックから、読込の間にファイルがなくなったら？外部アクセスの場合はチェック＋TryCatchで処置するのが定石。

			if (!File.Exists(UsersJsonFilePath))
				return null;

			using (StreamReader stream = new StreamReader(UsersJsonFilePath, Encoding.GetEncoding("shift_jis")))
			{
				var jsonFileText = stream.ReadToEnd();
				return jsonFileText;
			}
		}

        // todo : パス渡せばTryGetUsersJsonTextと一緒

        /// <summary>
        /// 部門のjsonテキストを取得する
        /// </summary>
        /// <returns></returns>
        private string TryGetDepartmentsJsonText()
		{
			if (!File.Exists(DepartmentsJsonFilePath))
				return null;

			using (StreamReader stream = new StreamReader(DepartmentsJsonFilePath, Encoding.GetEncoding("shift_jis")))
			{
				var jsonFileText = stream.ReadToEnd();
				return jsonFileText;
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
