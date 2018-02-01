using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    public class RespuestaExamenPrint : RespuestaExamenInfo
    {
        #region Business Methods

        private string _pregunta = string.Empty;
        private long _orden;
        private string _imagen = string.Empty;
        private bool _imagen_grande;
        //private System.Byte[] _imagen_pregunta;

        public string Pregunta { get { return _pregunta; } }
        public long Orden { get { return _orden; } }
        public string Imagen { get { return _imagen; } }
        public bool ImagenGrande { get { return _imagen_grande; } }
        //public System.Byte[] ImagenPregunta { get { return _imagen_pregunta; } }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(RespuestaExamenInfo source, 
                                    PreguntaExamenInfo pregunta, 
                                    Preguntas preguntas, 
                                    ExamenInfo examen, 
                                    bool imagen)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidPregunta = source.OidPregunta;
            _base.Record.Texto = source.Texto;
            _base.Record.Opcion = source.Opcion;
            _base.Record.Correcta = source.Correcta;

            if (pregunta == null) return;

            _pregunta = pregunta.Texto;
            _orden = pregunta.Orden;
            _imagen = pregunta.Imagen;
            _imagen_grande = pregunta.ImagenGrande;

            if (imagen)
            {
                if (pregunta.Imagen != string.Empty)
                {
                    if (File.Exists(pregunta.ImagenWithPath))
                        _imagen = Resize(pregunta.ImagenWithPath, pregunta.Imagen);
                    else
                        _imagen = string.Empty;
                }
                else
                {
                    if (preguntas != null)
                    {
                        Pregunta p = preguntas.GetItem(pregunta.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            if (File.Exists(p.ImagenWithPath))
                                _imagen = Resize(p.ImagenWithPath, p.Imagen);
                            else
                                _imagen = string.Empty;
                        }
                    }
                }
            }
        }

        protected void CopyValues(RespuestaExamenInfo source,
                             PreguntaExamenInfo pregunta,
                             PreguntaList preguntas,
                             ExamenInfo examen,
                             bool imagen)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidPregunta = source.OidPregunta;
            _base.Record.Texto = source.Texto;
            _base.Record.Opcion = source.Opcion;
            _base.Record.Correcta = source.Correcta;

            if (pregunta == null) return;

            _pregunta = pregunta.Texto;
            _orden = pregunta.Orden;
            _imagen = pregunta.Imagen;

            if (imagen)
            {
                if (pregunta.Imagen != string.Empty)
                {
                    if (File.Exists(pregunta.ImagenWithPath))
                        _imagen = Resize(pregunta.ImagenWithPath, pregunta.Imagen);
                    else
                        _imagen = string.Empty;
                }
                else
                {
                    if (preguntas != null)
                    {
                        PreguntaInfo p = preguntas.GetItem(pregunta.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            if (File.Exists(p.ImagenWithPath))
                                _imagen = Resize(p.ImagenWithPath, p.Imagen);
                            else
                                _imagen = string.Empty;
                        }
                    }
                }
            }
        }

        #endregion

        #region Factory Methods

        private RespuestaExamenPrint() { /* require use of factory methods */ }

        public static RespuestaExamenPrint New( RespuestaExamenInfo source, 
                                                PreguntaExamenInfo pregunta, 
                                                Preguntas preguntas, 
                                                ExamenInfo examen,
                                                bool imagen)
        {
            RespuestaExamenPrint item = new RespuestaExamenPrint();
            item.CopyValues(source, pregunta, preguntas, examen, imagen);

            return item;
        }

        public static RespuestaExamenPrint New(RespuestaExamenInfo source,
                                        PreguntaExamenInfo pregunta,
                                        PreguntaList preguntas,
                                        ExamenInfo examen,
                                        bool imagen)
        {
            RespuestaExamenPrint item = new RespuestaExamenPrint();
            item.CopyValues(source, pregunta, preguntas, examen, imagen);

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
