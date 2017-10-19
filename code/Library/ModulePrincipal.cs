using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using moleQule.Library;
using moleQule.Library.Instruction.Properties;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class ModulePrincipal
	{
		#region Application Settings

		public static void SaveSettings() { Settings.Default.Save(); }

		public static void UpgradeSettings()
		{
			Assembly ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
			Version ver = ensamblado.GetName().Version;

			if (Properties.Settings.Default.MODULE_VERSION != ver.ToString())
			{
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.MODULE_VERSION = ver.ToString();
			}
		}

		public static string GetDBVersion() { return Settings.Default.DB_VERSION; }

		#endregion

		#region Schema Settings

        public static bool GetMostrarInstructoresAutorizadosSetting()
        {
            try { return Convert.ToBoolean(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_MOSTRAR_INSTRUCTORES_AUTORIZADOS)); }
            catch { return false; }
        }
        public static void SetMostrarInstructoresAutorizadosSetting(bool value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_MOSTRAR_INSTRUCTORES_AUTORIZADOS, value.ToString());
        }

        public static bool GetImpresionEmpresaDefaultBoolSetting()
        {
            try { return Convert.ToBoolean(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_IMPRESION_EMPRESA_DEFAULT_BOOL)); }
            catch { return false; }
        }
        public static void SetImpresionEmpresaDefaultBoolSetting(bool value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_IMPRESION_EMPRESA_DEFAULT_BOOL, value.ToString());
        }

        public static long GetImpresionEmpresaDefaultOidSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_IMPRESION_EMPRESA_DEFAULT_OID)); }
            catch { return -1; }
        }
        public static void SetImpresionEmpresaDefaultOidSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_IMPRESION_EMPRESA_DEFAULT_OID, value.ToString());
        }

        public static long GetPorcentajeMaximoFaltasModuloSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PORCENTAJE_MAXIMO_FALTAS_MODULO)); }
            catch { return 0; }
        }
        public static void SetPorcentajeMaximoFaltasModuloSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PORCENTAJE_MAXIMO_FALTAS_MODULO, value.ToString());
        }
        public static bool GetCriterioPorcentajeMaximoFaltasModuloSetting()
        {
            try { return Convert.ToBoolean(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_CRITERIO_PORCENTAJE_MAXIMO_FALTAS_MODULO)); }
            catch { return false; }
        }
        public static void SetCriterioPorcentajeMaximoFaltasModuloSetting(bool value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_CRITERIO_PORCENTAJE_MAXIMO_FALTAS_MODULO, value.ToString());
        }

        public static long GetPorcentajeMinimoExamenAprobadoSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PORCENTAJE_MINIMO_EXAMEN_APROBADO)); }
            catch { return 0; }
        }
        public static void SetPorcentajeMinimoExamenAprobadoSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PORCENTAJE_MINIMO_EXAMEN_APROBADO, value.ToString());
        }

        public static bool GetCriterioPorcentajeMinimoExamenAprobadoSetting()
        {
            try { return Convert.ToBoolean(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_CRITERIO_PORCENTAJE_MINIMO_EXAMEN_APROBADO)); }
            catch { return false; }
        }
        public static void SetCriterioPorcentajeMinimoExamenAprobadoSetting(bool value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_CRITERIO_PORCENTAJE_MINIMO_EXAMEN_APROBADO, value.ToString());
        }

        //Tiempo Preguntas
        public static DateTime GetTiempoPreguntasTipoDesarrolloSetting()
        {
            try { return Convert.ToDateTime(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_TIEMPO_PREGUNTA_DESARROLLO)); }
            catch { return Convert.ToDateTime(false); }
        }
        public static void SetTiempoPreguntasTipoDesarrolloSetting(DateTime value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_TIEMPO_PREGUNTA_DESARROLLO, value.ToString());
        }
        public static DateTime GetTiempoPreguntasTipoTestSetting()
        {
            try { return Convert.ToDateTime(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_TIEMPO_PREGUNTA_TEST)); }
            catch { return Convert.ToDateTime(false); }
        }
        public static void SetTiempoPreguntasTipoTestSetting(DateTime value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_TIEMPO_PREGUNTA_TEST, value.ToString());
        }

        //Cuadro de Disponibilidad
        public static long GetHoraInicioDisponibilidadMananaSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_HORA_INICIO_DISPONIBILIDAD_MANANA)); }
            catch { return 1; }
        }
        public static void SetHoraInicioDisponibilidadMananaSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_HORA_INICIO_DISPONIBILIDAD_MANANA, value.ToString());
        }
        public static long GetHoraInicioDisponibilidadTarde1Setting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_HORA_INICIO_DISPONIBILIDAD_TARDE1)); }
            catch { return 1; }
        }
        public static void SetHoraInicioDisponibilidadTarde1Setting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_HORA_INICIO_DISPONIBILIDAD_TARDE1, value.ToString());
        }
        public static long GetHoraInicioDisponibilidadTarde2Setting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_HORA_INICIO_DISPONIBILIDAD_TARDE2)); }
            catch { return 1; }
        }
        public static void SetHoraInicioDisponibilidadTarde2Setting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_HORA_INICIO_DISPONIBILIDAD_TARDE2, value.ToString());
        }
        public static long GetHoraFinDisponibilidadMananaSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_HORA_FIN_DISPONIBILIDAD_MANANA)); }
            catch { return 1; }
        }
        public static void SetHoraFinDisponibilidadMananaSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_HORA_FIN_DISPONIBILIDAD_MANANA, value.ToString());
        }
        public static long GetHoraFinDisponibilidadTarde1Setting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_HORA_FIN_DISPONIBILIDAD_TARDE1)); }
            catch { return 1; }
        }
        public static void SetHoraFinDisponibilidadTarde1Setting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_HORA_FIN_DISPONIBILIDAD_TARDE1, value.ToString());
        }
        public static long GetHoraFinDisponibilidadTarde2Setting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_HORA_FIN_DISPONIBILIDAD_TARDE2)); }
            catch { return 1; }
        }
        public static void SetHoraFinDisponibilidadTarde2Setting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_HORA_FIN_DISPONIBILIDAD_TARDE2, value.ToString());
        }


		#endregion

		#region User Settings
        
		#endregion
    }
}