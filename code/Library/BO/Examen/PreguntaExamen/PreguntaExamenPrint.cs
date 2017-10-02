using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class PreguntaExamenPrint : PreguntaExamenInfo
    {
        #region Business Methods

        System.Byte[] _imagen_pregunta;
        string _indicacion_a = string.Empty;
        string _indicacion_b = string.Empty;
        string _indicacion_c = string.Empty;

        public System.Byte[] ImagenPregunta { get { return _imagen_pregunta; } }
        public string IndicacionA { get { return _indicacion_a; } }
        public string IndicacionB { get { return _indicacion_b; } }
        public string IndicacionC { get { return _indicacion_c; } }
        
        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(PreguntaExamenInfo source, Preguntas preguntas)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidExamen = source.OidExamen;
            _base.Record.OidModulo = source.OidModulo;
            _base.Record.OidTema = source.OidTema;
            _base.Record.Nivel = source.Nivel;
            _base.Record.FechaAlta = source.FechaAlta;
            _base.Record.FechaPublicacion = source.FechaPublicacion;
            _base.Record.Texto = source.Texto;
            _base.Record.Tipo = source.Tipo;
            _base.Record.Imagen = source.Imagen;
            _base.Record.Idioma = source.Idioma;
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.ImagenGrande = source.ImagenGrande;
            _base.Record.Orden = source.Orden;
            _base.Record.OidPregunta = source.OidPregunta;

            if (_base.Record.Tipo == "Desarrollo") //si la pregunta es de tipo test, las imágenes se cargan en las respuestas
            {
                //if (source.RespuestaExamens != null)
                //{
                //    foreach (RespuestaExamenInfo respuesta in source.RespuestaExamens)
                //    {
                //        if (respuesta.Opcion == "A")
                //            _indicacion_a = respuesta.Texto;
                //        if (respuesta.Opcion == "B")
                //            _indicacion_b = respuesta.Texto;
                //        if (respuesta.Opcion == "C")
                //            _indicacion_c = respuesta.Texto;
                //    }
                //}

                if (source.Imagen != string.Empty)
                {
                    string path =  source.ImagenWithPath;
                    
                    // Cargamos la imagen en el buffer
                    if (File.Exists(path))
                    {
                        Bitmap bitmap = new Bitmap(path);
                        string ext = string.Empty;

                        if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                            ext = ".jpg";
                        else
                        {
                            if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                                ext = ".bmp";
                            else
                            {
                                if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                    ext = ".png";
                            }
                        }

                        if (_base.Record.ImagenGrande)
                        {
                            Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                            path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                        }
                        else
                        {
                            if (bitmap.Width > 750 || bitmap.Height > 850)
                            {
                                Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                                path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                            }
                            else
                            {
                                File.Copy(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext, true);
                                path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                            }
                        }

                        bitmap.Dispose();

                        //Declaramos fs para poder abrir la imagen.
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                        // Declaramos un lector binario para pasar la imagen a bytes
                        BinaryReader br = new BinaryReader(fs);
                        _imagen_pregunta = new byte[(int)fs.Length];
                        br.Read(ImagenPregunta, 0, (int)fs.Length);
                        br.Close();
                        fs.Close();
                    }
                }
                else
                {
                    if (preguntas != null)
                    {
                        Pregunta p = preguntas.GetItem(source.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            string path = p.ImagenWithPath;
                            _base.Record.Imagen = p.Imagen;

                            // Cargamos la imagen en el buffer
                            if (File.Exists(path))
                            {
                                Bitmap bitmap = new Bitmap(path);
                                string ext = string.Empty;

                                if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                                    ext = ".jpg";
                                else
                                {
                                    if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                                        ext = ".bmp";
                                    else
                                    {
                                        if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                            ext = ".png";
                                    }
                                }

                                if (_base.Record.ImagenGrande)
                                {
                                    Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                                    path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                }
                                else
                                {
                                    if (bitmap.Width > 750 || bitmap.Height > 850)
                                    {
                                        Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                                        path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                    }
                                    else
                                    {
                                        File.Copy(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext, true);
                                        path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                    }
                                }

                                //Declaramos fs para poder abrir la imagen.
                                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                                // Declaramos un lector binario para pasar la imagen a bytes
                                BinaryReader br = new BinaryReader(fs);
                                _imagen_pregunta = new byte[(int)fs.Length];
                                br.Read(ImagenPregunta, 0, (int)fs.Length);
                                br.Close();
                                fs.Close();
                            }
                        }
                    }
                }
            }
            _base.Record.ImagenGrande = false;
        }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(PreguntaExamenInfo source, PreguntaList preguntas)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidExamen = source.OidExamen;
            _base.Record.OidModulo = source.OidModulo;
            _base.Record.OidTema = source.OidTema;
            _base.Record.Nivel = source.Nivel;
            _base.Record.FechaAlta = source.FechaAlta;
            _base.Record.FechaPublicacion = source.FechaPublicacion;
            _base.Record.Texto = source.Texto;
            _base.Record.Tipo = source.Tipo;
            _base.Record.Imagen = source.Imagen;
            _base.Record.Idioma = source.Idioma;
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.ImagenGrande = source.ImagenGrande;
            _base.Record.Orden = source.Orden;
            _base.Record.OidPregunta = source.OidPregunta;

            if (_base.Record.Tipo == "Desarrollo") //si la pregunta es de tipo test, las imágenes se cargan en las respuestas
            {
                //if (source.RespuestaExamens != null)
                //{
                //    foreach (RespuestaExamenInfo respuesta in source.RespuestaExamens)
                //    {
                //        if (respuesta.Opcion == "A")
                //            _indicacion_a = respuesta.Texto;
                //        if (respuesta.Opcion == "B")
                //            _indicacion_b = respuesta.Texto;
                //        if (respuesta.Opcion == "C")
                //            _indicacion_c = respuesta.Texto;
                //    }
                //}

                if (source.Imagen != string.Empty)
                {
                    string path = source.ImagenWithPath;

                    // Cargamos la imagen en el buffer
                    if (File.Exists(path))
                    {
                        Bitmap bitmap = new Bitmap(path);
                        string ext = string.Empty;

                        if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                            ext = ".jpg";
                        else
                        {
                            if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                                ext = ".bmp";
                            else
                            {
                                if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                    ext = ".png";
                            }
                        }

                        if (_base.Record.ImagenGrande)
                        {
                            Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                            path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                        }
                        else
                        {
                            if (bitmap.Width > 750 || bitmap.Height > 850)
                            {
                                Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                                path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                            }
                            else
                            {
                                File.Copy(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext, true);
                                path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                            }
                        }

                        bitmap.Dispose();

                        //Declaramos fs para poder abrir la imagen.
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                        // Declaramos un lector binario para pasar la imagen a bytes
                        BinaryReader br = new BinaryReader(fs);
                        _imagen_pregunta = new byte[(int)fs.Length];
                        br.Read(ImagenPregunta, 0, (int)fs.Length);
                        br.Close();
                        fs.Close();
                    }
                }
                else
                {
                    if (preguntas != null)
                    {
                        PreguntaInfo p = preguntas.GetItem(source.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            string path = p.ImagenWithPath;
                            _base.Record.Imagen = p.Imagen;

                            // Cargamos la imagen en el buffer
                            if (File.Exists(path))
                            {
                                Bitmap bitmap = new Bitmap(path);
                                string ext = string.Empty;

                                if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                                    ext = ".jpg";
                                else
                                {
                                    if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                                        ext = ".bmp";
                                    else
                                    {
                                        if (bitmap.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                            ext = ".png";
                                    }
                                }

                                if (_base.Record.ImagenGrande)
                                {
                                    Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                                    path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                }
                                else
                                {
                                    if (bitmap.Width > 750 || bitmap.Height > 850)
                                    {
                                        Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, 750, 850, true, bitmap.RawFormat);
                                        path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                    }
                                    else
                                    {
                                        File.Copy(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext, true);
                                        path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                    }
                                }

                                //Declaramos fs para poder abrir la imagen.
                                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                                // Declaramos un lector binario para pasar la imagen a bytes
                                BinaryReader br = new BinaryReader(fs);
                                _imagen_pregunta = new byte[(int)fs.Length];
                                br.Read(ImagenPregunta, 0, (int)fs.Length);
                                br.Close();
                                fs.Close();
                            }
                        }
                    }
                }
            }
            _base.Record.ImagenGrande = false;
        }

        #endregion

        #region Factory Methods

        private PreguntaExamenPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static PreguntaExamenPrint New(PreguntaExamenInfo source, Preguntas preguntas)
        {
            PreguntaExamenPrint item = new PreguntaExamenPrint();
            item.CopyValues(source, preguntas);

            return item;
        }

        public static PreguntaExamenPrint New(PreguntaExamenInfo source, PreguntaList preguntas)
        {
            PreguntaExamenPrint item = new PreguntaExamenPrint();
            item.CopyValues(source, preguntas);

            return item;
        }

        #endregion
    }
}
