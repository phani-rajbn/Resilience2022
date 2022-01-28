﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleConApp_Day12
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ResilienceDemo")]
	public partial class ExampleDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDept(Dept instance);
    partial void UpdateDept(Dept instance);
    partial void DeleteDept(Dept instance);
    partial void InsertEmpTable(EmpTable instance);
    partial void UpdateEmpTable(EmpTable instance);
    partial void DeleteEmpTable(EmpTable instance);
    #endregion
		
		public ExampleDataContext() : 
				base(global::SampleConApp_Day12.Properties.Settings.Default.ResilienceDemoConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Dept> Depts
		{
			get
			{
				return this.GetTable<Dept>();
			}
		}
		
		public System.Data.Linq.Table<EmpTable> EmpTables
		{
			get
			{
				return this.GetTable<EmpTable>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Dept")]
	public partial class Dept : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DeptID;
		
		private string _DeptName;
		
		private EntitySet<EmpTable> _EmpTables;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDeptIDChanging(int value);
    partial void OnDeptIDChanged();
    partial void OnDeptNameChanging(string value);
    partial void OnDeptNameChanged();
    #endregion
		
		public Dept()
		{
			this._EmpTables = new EntitySet<EmpTable>(new Action<EmpTable>(this.attach_EmpTables), new Action<EmpTable>(this.detach_EmpTables));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DeptID
		{
			get
			{
				return this._DeptID;
			}
			set
			{
				if ((this._DeptID != value))
				{
					this.OnDeptIDChanging(value);
					this.SendPropertyChanging();
					this._DeptID = value;
					this.SendPropertyChanged("DeptID");
					this.OnDeptIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string DeptName
		{
			get
			{
				return this._DeptName;
			}
			set
			{
				if ((this._DeptName != value))
				{
					this.OnDeptNameChanging(value);
					this.SendPropertyChanging();
					this._DeptName = value;
					this.SendPropertyChanged("DeptName");
					this.OnDeptNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Dept_EmpTable", Storage="_EmpTables", ThisKey="DeptID", OtherKey="DeptID")]
		public EntitySet<EmpTable> EmpTables
		{
			get
			{
				return this._EmpTables;
			}
			set
			{
				this._EmpTables.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_EmpTables(EmpTable entity)
		{
			this.SendPropertyChanging();
			entity.Dept = this;
		}
		
		private void detach_EmpTables(EmpTable entity)
		{
			this.SendPropertyChanging();
			entity.Dept = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EmpTable")]
	public partial class EmpTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EmpId;
		
		private string _EmpName;
		
		private string _EmpAddress;
		
		private decimal _EmpSalary;
		
		private int _DeptID;
		
		private EntityRef<Dept> _Dept;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmpIdChanging(int value);
    partial void OnEmpIdChanged();
    partial void OnEmpNameChanging(string value);
    partial void OnEmpNameChanged();
    partial void OnEmpAddressChanging(string value);
    partial void OnEmpAddressChanged();
    partial void OnEmpSalaryChanging(decimal value);
    partial void OnEmpSalaryChanged();
    partial void OnDeptIDChanging(int value);
    partial void OnDeptIDChanged();
    #endregion
		
		public EmpTable()
		{
			this._Dept = default(EntityRef<Dept>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int EmpId
		{
			get
			{
				return this._EmpId;
			}
			set
			{
				if ((this._EmpId != value))
				{
					this.OnEmpIdChanging(value);
					this.SendPropertyChanging();
					this._EmpId = value;
					this.SendPropertyChanged("EmpId");
					this.OnEmpIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string EmpName
		{
			get
			{
				return this._EmpName;
			}
			set
			{
				if ((this._EmpName != value))
				{
					this.OnEmpNameChanging(value);
					this.SendPropertyChanging();
					this._EmpName = value;
					this.SendPropertyChanged("EmpName");
					this.OnEmpNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpAddress", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string EmpAddress
		{
			get
			{
				return this._EmpAddress;
			}
			set
			{
				if ((this._EmpAddress != value))
				{
					this.OnEmpAddressChanging(value);
					this.SendPropertyChanging();
					this._EmpAddress = value;
					this.SendPropertyChanged("EmpAddress");
					this.OnEmpAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpSalary", DbType="Money NOT NULL")]
		public decimal EmpSalary
		{
			get
			{
				return this._EmpSalary;
			}
			set
			{
				if ((this._EmpSalary != value))
				{
					this.OnEmpSalaryChanging(value);
					this.SendPropertyChanging();
					this._EmpSalary = value;
					this.SendPropertyChanged("EmpSalary");
					this.OnEmpSalaryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeptID", DbType="Int NOT NULL")]
		public int DeptID
		{
			get
			{
				return this._DeptID;
			}
			set
			{
				if ((this._DeptID != value))
				{
					if (this._Dept.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDeptIDChanging(value);
					this.SendPropertyChanging();
					this._DeptID = value;
					this.SendPropertyChanged("DeptID");
					this.OnDeptIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Dept_EmpTable", Storage="_Dept", ThisKey="DeptID", OtherKey="DeptID", IsForeignKey=true)]
		public Dept Dept
		{
			get
			{
				return this._Dept.Entity;
			}
			set
			{
				Dept previousValue = this._Dept.Entity;
				if (((previousValue != value) 
							|| (this._Dept.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Dept.Entity = null;
						previousValue.EmpTables.Remove(this);
					}
					this._Dept.Entity = value;
					if ((value != null))
					{
						value.EmpTables.Add(this);
						this._DeptID = value.DeptID;
					}
					else
					{
						this._DeptID = default(int);
					}
					this.SendPropertyChanged("Dept");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
