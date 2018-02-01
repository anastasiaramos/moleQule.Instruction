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
            _base.Record.Texto = source.Texto;
            _base.Record.Tipo = source.Tipo;
            _base.Record.Imagen = source.Imagen;
            _base.Record.ModeloRespuesta = source.ModeloRespuesta;
            _base.Record.Idioma = source.Idioma;
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.ImagenGrande = source.ImagenGrande;
            _base.Record.Orden = source.Orden;
            _base.Record.OidPregunta = source.OidPregunta;

            if (_base.Record.Tipo == "Desarrollo") //si la pregunta es de tipo test, las imágenes se cargan en las respuestas
            {
                if (source.Imagen != string.Empty)
                {
                    if (File.Exists(source.ImagenWithPath))
                        _base.Record.Imagen = Resize(source.ImagenWithPath, source.Imagen);
                    else
                        _base.Record.Imagen = string.Empty;
                }
                else
                {
                    if (preguntas != null)
                    {
                        Pregunta p = preguntas.GetItem(source.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            if (File.Exists(p.ImagenWithPath))
                                _base.Record.Imagen = Resize(p.ImagenWithPath, p.Imagen);
                            else
                                _base.Record.Imagen = string.Empty;
                        }
                    }
                }
            }
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
                if (source.Imagen != string.Empty)
                {
                    if (File.Exists(source.ImagenWithPath))
                        _base.Record.Imagen = Resize(source.ImagenWithPath, source.Imagen);
                    else
                        _base.Record.Imagen = string.Empty;
                }
                else
                {
                    if (preguntas != null)
                    {
                        PreguntaInfo p = preguntas.GetItem(source.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            if (File.Exists(p.ImagenWithPath))
                                _base.Record.Imagen = Resize(p.ImagenWithPath, p.Imagen);
                            else
                                _base.Record.Imagen = string.Empty;
                        }
                    }
                }
            }
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


        public static string Resize(string path, string name)
        {
            Image imagen = Image.FromFile(path);
            int width = 550;//ancho de página
            int height = imagen.Height;

            if (imagen.Width >= width)
                height = imagen.Height * width / imagen.Width;
            else
                width = imagen.Width;
                //return path;

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(96, 96);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(imagen, destRect, 0, 0, imagen.Width, imagen.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            if (!Directory.Exists(".\\Temp"))
                Directory.CreateDirectory(".\\Temp");

            string resized_path = Directory.GetCurrentDirectory() + "\\Temp\\" + name;
                
                //path.Substring(0, path.LastIndexOf(".")) + "_resized" + path.Substring(path.LastIndexOf("."));

            imagen.Dispose();
            destImage.Save(resized_path);

            return resized_path;
        }
    }
}
