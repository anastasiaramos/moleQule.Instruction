using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
	public class ClaseGenericaInfo : ReadOnlyBaseEx<ClaseGenericaInfo>
    {
        #region Attributes

        private string _titulo = string.Empty;
        private long _oid_submodulo = 0;
        private long _oid_modulo = 0;
        private long _tipo = 0;
        private long _orden_primario = 0;
        private long _orden_secundario = 0;
        private long _orden_terciario = 0;
        private long _estado = 1;
        private long _incompatible;
        private long _grupo = 3;
        private string _modulo = string.Empty;
        private string _submodulo = string.Empty;
        private string _alias = string.Empty;

        #endregion

        #region Properties

        public virtual string Titulo { get { return _titulo; } }
        public virtual long OidSubmodulo { get { return _oid_submodulo; } }
        public virtual long OidModulo { get { return _oid_modulo; } }
        public virtual long Tipo { get { return _tipo; } }
        public virtual long OrdenPrimario { get { return _orden_primario; } }
        public virtual long OrdenSecundario { get { return _orden_secundario; } }
        public virtual long OrdenTerciario { get { return _orden_terciario; } }
        public virtual long Estado { get { return _estado; } }
        public virtual long Incompatible { get { return _incompatible; } }
        public virtual long Grupo { get { return _grupo; } }
        public virtual string Modulo { get { return _modulo; } }
        public virtual string Submodulo { get { return _submodulo; } }
        public virtual string Alias { get { return _alias; } }

        public virtual ETipoClase ETipoClase { get { return (ETipoClase)_tipo; } }
        public virtual string TipoClase { get { return Instruction.EnumText<ETipoClase>.GetLabel(ETipoClase); } }
        public virtual EEstadoClase EEstadoClase { get { return (EEstadoClase)_estado; } }
        public virtual string EstadoClaseLabel { get { return Instruction.EnumText<EEstadoClase>.GetLabel(EEstadoClase); } }

        #endregion
	
		#region Business Methods
	
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (ClaseGenerica source)
		{
            if (source == null) return;

            Oid = source.Oid;
            _titulo = source.Titulo;
            _oid_submodulo = source.OidSubmodulo;
            _oid_modulo = source.OidModulo;
            _tipo = source.Tipo;
            _orden_primario = source.OrdenPrimario;
            _orden_secundario = source.OrdenSecundario;
            _orden_terciario = source.OrdenTerciario;
            _estado = source.Estado;
            _incompatible = source.Incompatible;
            _grupo = source.Grupo;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _alias = source.Alias;
			
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues(IDataReader source)
		{
            if (source == null) return;
            CopyValues(source);
		}

        public void CopyFrom(ClaseGenerica source)
        {
            CopyValues(source);
        }

        public void CopyFrom(ClaseTeoricaInfo source)
        { 
            Oid = Convert.ToInt64(source.Tipo.ToString() + source.Oid.ToString("000000"));
            _titulo = source.Titulo;
            _oid_submodulo = source.OidSubmodulo;
            _oid_modulo = source.OidModulo;
            _tipo = (long)ETipoClase.Teorica;
            _orden_primario = source.OrdenPrimario;
            _orden_secundario = source.OrdenSecundario;
            _orden_terciario = source.OrdenTerciario;
            _estado = source.Estado;
            _incompatible = 0;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _alias = source.Alias;
            _grupo = 0;
        }

        public void CopyFrom(ClasePracticaInfo source)
        {
            Oid = Convert.ToInt64(source.Tipo.ToString() + source.Grupo.ToString() + source.Oid.ToString("000000"));
            _titulo = source.Titulo;
            _oid_submodulo = source.OidSubmodulo;
            _oid_modulo = source.OidModulo;
            _tipo = (long)ETipoClase.Practica;
            _orden_primario = source.OrdenPrimario;
            _orden_secundario = source.OrdenSecundario;
            _orden_terciario = source.OrdenTerciario;
            _estado = source.Estado;
            _incompatible = source.Incompatible;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _alias = source.Alias;
            _grupo = source.Grupo;
        }

        public void CopyFrom(ClaseExtraInfo source)
        {
            Oid = Convert.ToInt64(source.Tipo.ToString() + source.Oid.ToString("000000"));
            _titulo = source.Titulo;
            _oid_submodulo = source.OidSubmodulo;
            _oid_modulo = source.OidModulo;
            _tipo = (long)ETipoClase.Extra;
            _orden_primario = 0;
            _orden_secundario = 0;
            _orden_terciario = 0;
            _estado = source.Estado;
            _incompatible = 0;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _alias = source.Alias;
            _grupo = 0;
        }
			
		#endregion		
		
		#region Factory Methods
		
		public ClaseGenericaInfo() { /* require use of factory methods */ }

        internal ClaseGenericaInfo(ClaseGenerica source)
        {
            CopyFrom(source);
		}

        internal ClaseGenericaInfo(ClaseTeoricaInfo source)
        {
            CopyFrom(source);
        }

        internal ClaseGenericaInfo(ClasePracticaInfo source)
        {
            CopyFrom(source);
        }

        internal ClaseGenericaInfo(ClaseExtraInfo source)
        {
            CopyFrom(source);
        }
		
		private ClaseGenericaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
					
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>

        public static ClaseGenericaInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
        public static ClaseGenericaInfo Get(long oid, bool childs)
		{
            CriteriaEx criteria = ClaseGenerica.GetCriteria(ClaseGenerica.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ClaseGenerica.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
            ClaseGenericaInfo obj = DataPortal.Fetch<ClaseGenericaInfo>(criteria);
            ClaseGenerica.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
        public static ClaseGenericaInfo Get(IDataReader reader, bool childs)
        {
            return new ClaseGenericaInfo(reader, childs);
		}
		
 		#endregion
		 
		#region Data Access
		 
		// called to retrieve data from db
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;
			try
			{
				if (nHMng.UseDirectSQL)
				{
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					if (reader.Read())
						CopyValues(reader);
					
                    if (Childs)
					{
						string query = string.Empty;
						
                        
                    }
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		//called to copy data from IDataReader
		private void Fetch(IDataReader source)
		{
			try
			{
				CopyValues(source);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		#endregion
	}
}



