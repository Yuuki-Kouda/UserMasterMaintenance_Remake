using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UserMasterMaintenance.Model
{
	[DataContract]
	public class User : INotifyPropertyChanged
	{
		private int _iD = 0;

		private string _name = string.Empty;

		private int _age = 0;

		private string _gender = string.Empty;

		private string _department = string.Empty;

		/// <summary>
		/// プロパティ変更イベント
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// プロパティの変更通知をする
		/// </summary>
		/// <param name="propertyName"></param>
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		/// <summary>
		/// ID
		/// </summary>]
		[DataMember(Name = "Id")]
		public int ID
		{
			get
			{
				return this._iD;
			}
			set
			{
				this._iD = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// 名前
		/// </summary>
		[DataMember(Name = "Name")]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// 年齢
		/// </summary>
		[DataMember(Name = "Age")]
		public int Age
		{
			get
			{
				return this._age;
			}
			set
			{
				this._age = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// 性別
		/// </summary>
		[DataMember(Name = "Gender")]
		public string Gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				this._gender = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// 所属部門
		/// </summary>
		[DataMember(Name = "Department")]
		public string Department
		{
			get
			{
				return this._department;
			}
			set
			{
				this._department = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// ユーザーを上書きする	
		/// </summary>
		/// <param name="user"></param>
		public void OverrideUser(User user)
		{
			this.ID = user.ID;
			this.Name = user.Name;
			this.Age = user.Age;
			this.Gender = user.Gender;
			this.Department = user.Department;
		}
	}
}
