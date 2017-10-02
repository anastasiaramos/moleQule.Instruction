using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class MatriculaPrint : AlumnoInfo
    {

        #region Business Methods

        private string _texto = string.Empty;
        private string _numero = string.Empty;
        private DateTime _fecha_promocion;
        private string _curso = string.Empty;
        private System.Byte[] _foto_alumno;
        private List<TIdioma> _idiomas_list = new List<TIdioma>();
        private List<TFormacion> _formacion_list = new List<TFormacion>();

        public string Texto { get { return _texto; } }
        public string Numero { get { return _numero; } }
        public DateTime FechaPromocion { get { return _fecha_promocion; } }
        public string Curso { get { return _curso; } }
        public string Edad { get { return Convert.ToString(DateTime.Today.Year - _base.Record.FechaNacimiento.Year); } }
        public bool Estudia { get { return _base.Record.LugarEstudio != string.Empty; } }
        public bool Trabaja { get { return _base.Record.LugarTrabajo != string.Empty; } }
        public System.Byte[] FotoAlumno { get { return _foto_alumno; } }
        public List<TIdioma> IdiomasList { get { return _idiomas_list; } }
        public List<TFormacion> FormacionList { get { return _formacion_list; } }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(AlumnoInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.NExpediente = source.NExpediente;
            _base.Record.Serial = source.Serial;
            _base.Record.Codigo = source.Codigo;
            _base.Record.Nombre = source.Nombre;
            _base.Record.Apellidos = source.Apellidos;
            _base.Record.Identificador = source.Id;
            _base.Record.TipoId = source.TipoId;
            _base.Record.FechaNacimiento = source.FechaNacimiento;
            _base.Record.Email = source.Email;
            _base.Record.Direccion = source.Direccion;
            _base.Record.CodPostal = source.CodPostal;
            _base.Record.Localidad = source.Localidad;
            _base.Record.Municipio = source.Municipio;
            _base.Record.Provincia = source.Provincia;
            _base.Record.Telefono = source.Telefono;
            _base.Record.NivelEstudios = source.NivelEstudios;
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.Foto = source.Foto;
            _base.Record.Grupo = source.Grupo;
            _base.Record.LugarEstudio = source.LugarEstudio;
            _base.Record.LugarTrabajo = source.LugarTrabajo;
            _base.Record.Requisitos = source.Requisitos;
            _base.Record.PruebaAcceso = source.PruebaAcceso;

            /*_promocion = promo.Nombre;
            _fecha_promocion = promo.FechaInicio;
            _curso = promo.FechaInicio.Year.ToString() + "/" + promo.FechaInicio.AddYears(2).Year.ToString();*/
            
            char[] delimiterChars = {';'};
            string[] words = source.Idiomas.Split(delimiterChars);
            long pos = 0;

            TIdioma itemI;
            while (pos + 2 < words.Length)
            {
                itemI = new TIdioma();
                itemI.Oid = source.Oid;
                itemI.Idioma = words[pos++];
                if (pos < words.Length) itemI.NHablado = words[pos++];
                if (pos < words.Length) itemI.NEscrito = words[pos++];
                _idiomas_list.Add(itemI);
            }

            words = source.Formacion.Split(delimiterChars);
            pos = 0;
            TFormacion itemF;
            while (pos + 2 < words.Length)
            {
                itemF = new TFormacion();
                itemF.Oid = source.Oid;
                itemF.Titulo = words[pos++];
                if (pos < words.Length) itemF.Centro = words[pos++];
                if (pos < words.Length) itemF.Fecha = words[pos++];
                _formacion_list.Add(itemF);
            }

            if (Foto != string.Empty)
            {
                string path = ModuleController.FOTOS_ALUMNOS_PATH + Foto;

                // Cargamos la imagen en el buffer
                if (File.Exists(path))
                {
                    //Declaramos fs para poder abrir la imagen.
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                    // Declaramos un lector binario para pasar la imagen a bytes
                    BinaryReader br = new BinaryReader(fs);
                    _foto_alumno = new byte[(int)fs.Length];
                    br.Read(FotoAlumno, 0, (int)fs.Length);
                    br.Close();
                    fs.Close();
                }
            }
        }

        #endregion

        #region Factory Methods

        private MatriculaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static MatriculaPrint New(AlumnoInfo source)//, PromocionInfo promo)
        {
            MatriculaPrint item = new MatriculaPrint();
            item.CopyValues(source);//, promo);

            return item;
        }

        #endregion

    }
}
