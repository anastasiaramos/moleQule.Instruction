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
	public class FaltaAlumnoInfo : ReadOnlyBaseEx<FaltaAlumnoInfo>
	{
	
		#region Business Methods
		
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private string _n_expediente = string.Empty;
        private string _codigo = string.Empty;
        private long _duracion;
        private string _promocion = string.Empty;
        private string _modulo = string.Empty;
        private long _total_clases;
        private decimal _porcentaje = 0;
        private long _total_faltas;
        private long _total_clases_curso;
        private decimal _porcentaje_total = 0;
        private long _recuperaciones;
        private decimal _faltas_modulo = 0;
        private decimal _recuperaciones_pendientes = 0;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public string NExpediente { get { return _n_expediente; } set { _n_expediente = value; } }
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public long Duracion { get { return _duracion; } set { _duracion = value; } }
        public string Promocion { get { return _promocion; } set { _promocion = value; } }
        public string Modulo { get { return _modulo; } set { _modulo = value; } }
        public long TotalClases { get { return _total_clases; } set { _total_clases = value; } }
        public decimal Porcentaje { get { return _porcentaje; } set { _porcentaje = value; } }
        public long TotalFaltas { get { return _total_faltas; } set { _total_faltas = value; } }
        public long TotalClasesCurso { get { return _total_clases_curso; } set { _total_clases_curso = value; } }
        public decimal PorcentajeTotal { get { return _porcentaje_total; } set { _porcentaje_total = value; } }
        public long Recuperaciones { get { return _recuperaciones; } set { _recuperaciones = value; } }
        public long FaltasModulo 
        { 
            get
            {
                if (((Convert.ToDecimal(Duracion) - Recuperaciones) / TotalClases * 100) > 15)
                    //return _duracion - _recuperaciones; 
                    return Convert.ToInt64(Convert.ToDecimal(_duracion) - (15 * TotalClases / 100)) - _recuperaciones;
                else
                    return 0;
            } 
        }

        public decimal RecuperacionesPendientes
        {
            get
            {
                //if ((FaltasModulo / TotalClases *  100) > 15)
                //{
                //    long max_faltas = TotalClases * 15 / 100;
                //    return (Duracion - Recuperaciones) - max_faltas;
                //}
                //else
                //    return 0;
                return _recuperaciones_pendientes; ;
            }
        } 

        public string Alumno { get { return _nombre + " " + _apellidos; } }
	
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (FaltaAlumno source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
			_nombre = source.Nombre;
            _apellidos = source.Apellidos;
            _codigo = source.Codigo;
            _n_expediente = source.NExpediente;
            _duracion = source.Duracion;
            _promocion = source.Promocion;
            _modulo = source.Modulo;
            _total_clases = source.TotalClases;
            _porcentaje = source.Porcentaje;
            _total_faltas = source.TotalFaltas;
            _total_clases_curso = source.TotalClasesCurso;
            _porcentaje_total = source.PorcentajeTotal;
            _recuperaciones = source.Recuperaciones;
            _recuperaciones_pendientes = source.RecuperacionesPendientes;
			
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues(IDataReader reader)
		{
			if (reader == null) return;

            _nombre = DBNull.Value.Equals(reader["NOMBRE_ALUMNO"]) ? string.Empty : reader["NOMBRE_ALUMNO"].ToString();
            _apellidos = DBNull.Value.Equals(reader["APELLIDO_ALUMNO"]) ? string.Empty : reader["APELLIDO_ALUMNO"].ToString();
            _n_expediente = DBNull.Value.Equals(reader["EXP_ALUMNO"]) ? string.Empty : reader["EXP_ALUMNO"].ToString();
            _codigo = DBNull.Value.Equals(reader["CODIGO_ALUMNO"]) ? string.Empty : reader["CODIGO_ALUMNO"].ToString();
            _duracion = Format.DataReader.GetInt64(reader, "DURACION");
            _promocion = DBNull.Value.Equals(reader["PROMOCION"]) ? string.Empty : reader["PROMOCION"].ToString();
            _modulo = DBNull.Value.Equals(reader["MODULO"]) ? string.Empty : reader["MODULO"].ToString();
            _total_clases = DBNull.Value.Equals(reader["TOTAL"]) ? 0 : Convert.ToInt32(reader["TOTAL"]);
            _total_faltas = DBNull.Value.Equals(reader["DURACION_TOTAL"]) ? 0 : Convert.ToInt32(reader["DURACION_TOTAL"]);
            _total_clases_curso = DBNull.Value.Equals(reader["TOTAL_CURSO"]) ? 0 : Convert.ToInt32(reader["TOTAL_CURSO"]);
            _porcentaje = Decimal.Round(((decimal)_duracion + (decimal)_recuperaciones) / _total_clases * 100, 2);
            _porcentaje_total = Decimal.Round((decimal)_total_faltas / _total_clases_curso * 100, 2);
            _recuperaciones = Format.DataReader.GetInt64(reader, "RECUPERACIONES");
            long porcentaje_maximo = moleQule.Library.Instruction.ModulePrincipal.GetPorcentajeMaximoFaltasModuloSetting();
            _recuperaciones_pendientes = _duracion - (_total_clases * porcentaje_maximo / 100);
            if (_recuperaciones_pendientes < 0) _recuperaciones_pendientes = 0;
            Oid = Convert.ToInt64(Format.DataReader.GetInt64(reader, "OID_PROMOCION").ToString("0000") +
                                    Format.DataReader.GetInt64(reader, "OID_ALUMNO").ToString("0000") +
                                    Format.DataReader.GetInt64(reader, "OID_MODULO").ToString("0000"));
		}

        public void CopyFrom(FaltaAlumno source)
        {
            CopyValues(source);
        }
			
		#endregion		
		
		#region Factory Methods
		
		private FaltaAlumnoInfo() { /* require use of factory methods */ }
		
		private FaltaAlumnoInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de AreaInfo a partir de un Area
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal FaltaAlumnoInfo(FaltaAlumno item)
			: this(item, false)
		{
		}

        internal FaltaAlumnoInfo(FaltaAlumno item, bool childs)
		{
            Oid = item.Oid;
            _nombre = item.Nombre;
            _apellidos = item.Apellidos;
            _codigo = item.Codigo;
            _n_expediente = item.NExpediente;
            _duracion = item.Duracion;
            _promocion = item.Promocion;
            _modulo = item.Modulo;
            _total_clases = item.TotalClases;
            _porcentaje = item.Porcentaje;
            _recuperaciones = item.Recuperaciones;
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>

        public static FaltaAlumnoInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
        public static FaltaAlumnoInfo Get(long oid, bool childs)
		{
            CriteriaEx criteria = FaltaAlumno.GetCriteria(FaltaAlumno.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
                criteria.Query = FaltaAlumno.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
            FaltaAlumnoInfo obj = DataPortal.Fetch<FaltaAlumnoInfo>(criteria);
            FaltaAlumno.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
        public static FaltaAlumnoInfo Get(IDataReader reader, bool childs)
        {
            return new FaltaAlumnoInfo(reader, childs);
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



