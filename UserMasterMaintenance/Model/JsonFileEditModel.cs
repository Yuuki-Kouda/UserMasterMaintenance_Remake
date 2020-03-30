using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;

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
		public BindingList<Model.User> GetUsers()
		{
			return Deserialize<BindingList<Model.User>>(GetUsersJsonTextFromJsonFile());
		}

		/// <summary>
		/// 部門リストを取得する
		/// </summary>
		/// <returns></returns>
		public List<Model.Department> GetDepartments()
		{
			return Deserialize<List<Model.Department>>(GetDepartmentsJsonTextFromJsonFile());
		}

        // todo Json形式のファイルを扱うクラスなのに InJsonFile は冗長じゃない？

        // todo 書き込めなかったら死なない？

        // todo BindingListを引数に取るのは汎用性が低いからやめたほうがよい。Collection<T>でいいんじゃない？

		/// <summary>
		/// ユーザー情報を保存する
		/// </summary>
		/// <param name="users"></param>
		public void SaveUsersInJsonFile(BindingList<Model.User> users)
		{
			var jsontext = Selialize(users);
			using (StreamWriter stream = new StreamWriter(UsersJsonFilePath, false, Encoding.UTF8))
			{
				stream.Write(jsontext);
			}
		}

		/// <summary>
		/// 部門情報を保存する
		/// </summary>
		/// <param name="departments"></param>
		public void SaveDepartmentsInJsonFile(List<Model.Department> departments)
		{
			var jsontext = Selialize(departments);
			using (StreamWriter stream = new StreamWriter(DepartmentsJsonFilePath, false, Encoding.UTF8))
			{
				stream.Write(jsontext);
			}
		}

        // todo ファイルが見つからなかったら結局死ぬんじゃない？

		/// <summary>
		/// ユーザーのjsonテキストを取得する
		/// </summary>
		/// <returns></returns>
		private string GetUsersJsonText()
		{
			try
			{
				using (StreamReader stream = new StreamReader(UsersJsonFilePath, Encoding.GetEncoding("shift_jis")))
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
		private string GetDepartmentsJsonText()
		{
			try
			{
				using (StreamReader stream = new StreamReader(DepartmentsJsonFilePath, Encoding.GetEncoding("shift_jis")))
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
