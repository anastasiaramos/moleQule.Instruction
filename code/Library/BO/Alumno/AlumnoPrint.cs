using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using moleQule.Library;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    public class TIdioma
    {
        public long Oid;
        public string Idioma;
        public string NHablado;
        public string NEscrito;
    }

    public class TFormacion
    {
        public long Oid;
        public string Titulo;
        public string Centro;
        public string Fecha;
    }

    [Serializable()]
    public class AlumnoPrint : AlumnoInfo
    {

        #region Business Methods

        private string _texto = string.Empty;
        private string _numero = string.Empty;
        System.Byte[] _foto_alumno;
        private List<TIdioma> _idiomas_list = new List<TIdioma>();
        private List<TFormacion> _formacion_list = new List<TFormacion>();

        public string Texto { get { return _texto; } }
        public string Numero { get { return _numero; } }
        public System.Byte[] FotoAlumno { get { return _foto_alumno; } }
        private List<TIdioma> IdiomasList { get { return _idiomas_list; } }
        private List<TFormacion> FormacionList { get { return _formacion_list; } }


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
            _numero = source.NExpediente;
            _texto = _base.Record.Apellidos + ", " + _base.Record.Nombre;
            
            char[] delimiterChars = {';'};
            string[] words = source.Idiomas.Split(delimiterChars);
            long pos = 0;

            TIdioma itemI;
            while (pos < words.Length)
            {
                itemI = new TIdioma();
                itemI.Idioma = pos < words.Length ? words[pos++] : string.Empty;
                itemI.NHablado = pos < words.Length ? words[pos++] : string.Empty;
                itemI.NEscrito = pos < words.Length ? words[pos++] : string.Empty;
                _idiomas_list.Add(itemI);
            }

            words = source.Formacion.Split(delimiterChars);
            pos = 0;
            TFormacion itemF;
            while (pos < words.Length)
            {
                itemF = new TFormacion();
                itemF.Titulo = pos < words.Length ? words[pos++] : string.Empty;
                itemF.Centro = pos < words.Length ? words[pos++] : string.Empty;
                itemF.Fecha = pos < words.Length ? words[pos++] : string.Empty;
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

        private AlumnoPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static AlumnoPrint New(AlumnoInfo source)
        {
            AlumnoPrint item = new AlumnoPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
