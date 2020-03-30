﻿using System;
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
		public BindingList<User> TryGetUsers()
		{
			try
			{
				return Deserialize<BindingList<User>>(GetUsersJsonText());
			}
			catch (FileNotFoundException)
			{
				return null;
			}
		}

		/// <summary>
		/// 部門リストを取得する
		/// </summary>
		/// <returns></returns>
		public List<Department> TryGetDepartments()
		{
			try
			{
				return Deserialize<List<Department>>(GetDepartmentsJsonText());
			}
			catch (FileNotFoundException)
			{
				return null;
			}
		}

        // todo 書き込めなかったら死なない？

		/// <summary>
		/// ユーザー情報を保存する
		/// </summary>
		/// <param name="users"></param>
		public Presenter.ErrorType TrySaveUsers(Collection<User> users)
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
				return Presenter.ErrorType.SaveFailure;
			}

			return Presenter.ErrorType.None;
		}

		/// <summary>
		/// 部門情報を保存する
		/// </summary>
		/// <param name="departments"></param>
		public Presenter.ErrorType TrySaveDepartments(List<Department> departments)
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
				return Presenter.ErrorType.SaveFailure;
			}

			return Presenter.ErrorType.None;
		}

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
