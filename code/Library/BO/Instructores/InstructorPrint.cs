using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using moleQule.Library;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class InstructorPrint : InstructorInfo
    {

        #region Business Methods

        System.Byte[] _foto_instructor;

        public System.Byte[] FotoInstructor { get { return _foto_instructor; } }


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(InstructorInfo source)
        {
            if (source == null) return;

            _base.ProviderBase.CopyValues(source);
            _base.Record.Alias = source.Alias;

            Oid = source.Oid;
            _base.Record.NivelEstudios = source.NivelEstudios;
            _base.Record.Perfil = source.Perfil;
            _base.Record.Foto = source.Foto;
            _base.Record.Activo = source.Activo;

            if (Foto != string.Empty)
            {
                string path = Images.GetRootPath() + Resources.Paths.FOTO_INSTRUCTORES.Substring(2) + Foto;

                // Cargamos la imagen en el buffer
                if (File.Exists(path))
                {
                    //Declaramos fs para poder abrir la imagen.
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                    // Declaramos un lector binario para pasar la imagen a bytes
                    BinaryReader br = new BinaryReader(fs);
                    _foto_instructor = new byte[(int)fs.Length];
                    br.Read(FotoInstructor, 0, (int)fs.Length);
                    br.Close();
                    fs.Close();
                }
            }
        }

        #endregion

        #region Factory Methods

        private InstructorPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static InstructorPrint New(InstructorInfo source)
        {
            InstructorPrint item = new InstructorPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
