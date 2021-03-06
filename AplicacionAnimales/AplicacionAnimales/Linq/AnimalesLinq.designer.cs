﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionAnimales.Linq
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Animlaes")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertAnimal(Animal instance);
    partial void UpdateAnimal(Animal instance);
    partial void DeleteAnimal(Animal instance);
    partial void InsertFamilia(Familia instance);
    partial void UpdateFamilia(Familia instance);
    partial void DeleteFamilia(Familia instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["AnimlaesConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Animal> Animal
		{
			get
			{
				return this.GetTable<Animal>();
			}
		}
		
		public System.Data.Linq.Table<Familia> Familia
		{
			get
			{
				return this.GetTable<Familia>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Animal")]
	public partial class Animal : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdAnimal;
		
		private string _Nombre;
		
		private int _IdFamilia;
		
		private EntityRef<Familia> _Familia;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdAnimalChanging(int value);
    partial void OnIdAnimalChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnIdFamiliaChanging(int value);
    partial void OnIdFamiliaChanged();
    #endregion
		
		public Animal()
		{
			this._Familia = default(EntityRef<Familia>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdAnimal", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdAnimal
		{
			get
			{
				return this._IdAnimal;
			}
			set
			{
				if ((this._IdAnimal != value))
				{
					this.OnIdAnimalChanging(value);
					this.SendPropertyChanging();
					this._IdAnimal = value;
					this.SendPropertyChanged("IdAnimal");
					this.OnIdAnimalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdFamilia", DbType="Int NOT NULL")]
		public int IdFamilia
		{
			get
			{
				return this._IdFamilia;
			}
			set
			{
				if ((this._IdFamilia != value))
				{
					if (this._Familia.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdFamiliaChanging(value);
					this.SendPropertyChanging();
					this._IdFamilia = value;
					this.SendPropertyChanged("IdFamilia");
					this.OnIdFamiliaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Familia_Animal", Storage="_Familia", ThisKey="IdFamilia", OtherKey="IdFamilia", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Familia Familia
		{
			get
			{
				return this._Familia.Entity;
			}
			set
			{
				Familia previousValue = this._Familia.Entity;
				if (((previousValue != value) 
							|| (this._Familia.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Familia.Entity = null;
						previousValue.Animal.Remove(this);
					}
					this._Familia.Entity = value;
					if ((value != null))
					{
						value.Animal.Add(this);
						this._IdFamilia = value.IdFamilia;
					}
					else
					{
						this._IdFamilia = default(int);
					}
					this.SendPropertyChanged("Familia");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Familia")]
	public partial class Familia : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdFamilia;
		
		private string _Nombre;
		
		private EntitySet<Animal> _Animal;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdFamiliaChanging(int value);
    partial void OnIdFamiliaChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    #endregion
		
		public Familia()
		{
			this._Animal = new EntitySet<Animal>(new Action<Animal>(this.attach_Animal), new Action<Animal>(this.detach_Animal));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdFamilia", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdFamilia
		{
			get
			{
				return this._IdFamilia;
			}
			set
			{
				if ((this._IdFamilia != value))
				{
					this.OnIdFamiliaChanging(value);
					this.SendPropertyChanging();
					this._IdFamilia = value;
					this.SendPropertyChanged("IdFamilia");
					this.OnIdFamiliaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Familia_Animal", Storage="_Animal", ThisKey="IdFamilia", OtherKey="IdFamilia")]
		public EntitySet<Animal> Animal
		{
			get
			{
				return this._Animal;
			}
			set
			{
				this._Animal.Assign(value);
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
		
		private void attach_Animal(Animal entity)
		{
			this.SendPropertyChanging();
			entity.Familia = this;
		}
		
		private void detach_Animal(Animal entity)
		{
			this.SendPropertyChanging();
			entity.Familia = null;
		}
	}
}
#pragma warning restore 1591
