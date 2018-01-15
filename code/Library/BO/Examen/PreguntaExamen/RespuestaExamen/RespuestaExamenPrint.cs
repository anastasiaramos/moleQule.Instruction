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
                        _imagen = Resize(pregunta.ImagenWithPath);
                    else
                        _imagen = string.Empty;

                    /*if (File.Exists(pregunta.ImagenWithPath))
                    {
                        //string path = Images.GetRootPath() + Paths.FOTO_PREGUNTAS_EXAMENES.Substring(2) + pregunta.OidExamen.ToString("00000") + "\\" + pregunta.Imagen;
                        string path = pregunta.ImagenWithPath;

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

                            if (_imagen_grande)
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
                                    Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, bitmap.Width, bitmap.Height, true, bitmap.RawFormat);
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
                    else
                        _imagen = string.Empty;*/
                }
                else
                {
                    if (preguntas != null)
                    {
                        Pregunta p = preguntas.GetItem(pregunta.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            if (File.Exists(p.ImagenWithPath))
                                _imagen = Resize(p.ImagenWithPath);
                            else
                                _imagen = string.Empty;

                            /*if (File.Exists(p.ImagenWithPath))
                            {
                                //string path = Images.GetRootPath() + Paths.FOTO_PREGUNTAS.Substring(2) + p.Imagen;
                                _imagen = p.Imagen;
                                string path = p.ImagenWithPath;

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

                                    if (_imagen_grande)
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
                                            //Images.Save(path, Resources.Paths.FOTO_PREGUNTAS_EXAMENES, "temp" + ext, bitmap.Width, bitmap.Height, true, bitmap.RawFormat);
                                            path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                        }
                                    }

                                    Image prueba = Image.FromFile(path);
                                    MemoryStream stream = new MemoryStream();
                                    prueba.Save(stream, bitmap.RawFormat);
                                    _imagen_pregunta = stream.ToArray();

                                    bitmap.Dispose();
                                    prueba.Dispose();

                                    //Declaramos fs para poder abrir la imagen.
                                    //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                                    //// Declaramos un lector binario para pasar la imagen a bytes
                                    //BinaryReader br = new BinaryReader(fs);
                                    //_imagen_pregunta = new byte[(int)fs.Length];
                                    //br.Read(ImagenPregunta, 0, (int)fs.Length);
                                    //br.Close();
                                    //fs.Close();
                                }
                            }
                            else
                                _imagen = string.Empty;*/
                        }
                    }
                }
            }
            _imagen_grande = false; //trampilla :)
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
            _imagen_grande = pregunta.ImagenGrande;

            if (imagen)
            {
                if (pregunta.Imagen != string.Empty)
                {
                    if (File.Exists(pregunta.ImagenWithPath))
                        _imagen = Resize(pregunta.ImagenWithPath);
                    else
                        _imagen = string.Empty;
                    //string path = Images.GetRootPath() + Paths.FOTO_PREGUNTAS_EXAMENES.Substring(2) + pregunta.OidExamen.ToString("00000") + "\\" + pregunta.Imagen;
                    /*if (File.Exists(pregunta.ImagenWithPath))
                    {
                        string path = pregunta.ImagenWithPath;

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

                            if (_imagen_grande)
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
                                    Images.Save(path, ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH, "temp" + ext, bitmap.Width, bitmap.Height, true, bitmap.RawFormat);
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
                    else
                        _imagen = string.Empty;*/
                }
                else
                {
                    if (preguntas != null)
                    {
                        PreguntaInfo p = preguntas.GetItem(pregunta.OidPregunta);

                        if (p != null && p.Imagen != string.Empty)
                        {
                            if (File.Exists(p.ImagenWithPath))
                                _imagen = Resize(p.ImagenWithPath);
                            else
                                _imagen = string.Empty;

                            /*if (File.Exists(p.ImagenWithPath))
                            {
                                //string path = Images.GetRootPath() + Paths.FOTO_PREGUNTAS.Substring(2) + p.Imagen;
                                _imagen = p.Imagen;
                                string path = p.ImagenWithPath;

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

                                    if (_imagen_grande)
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
                                            //Images.Save(path, Resources.Paths.FOTO_PREGUNTAS_EXAMENES, "temp" + ext, bitmap.Width, bitmap.Height, true, bitmap.RawFormat);
                                            path = ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + "temp" + ext;
                                        }
                                    }

                                    Image prueba = Image.FromFile(path);
                                    MemoryStream stream = new MemoryStream();
                                    prueba.Save(stream, bitmap.RawFormat);
                                    _imagen_pregunta = stream.ToArray();

                                    bitmap.Dispose();
                                    prueba.Dispose();

                                    //Declaramos fs para poder abrir la imagen.
                                    //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                                    //// Declaramos un lector binario para pasar la imagen a bytes
                                    //BinaryReader br = new BinaryReader(fs);
                                    //_imagen_pregunta = new byte[(int)fs.Length];
                                    //br.Read(ImagenPregunta, 0, (int)fs.Length);
                                    //br.Close();
                                    //fs.Close();
                                }
                            }
                            else
                                _imagen = string.Empty;*/
                        }
                    }
                }
            }
            //_imagen_grande = false; //trampilla :)
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

        public static string Resize(string path)
        {
            Image imagen = Image.FromFile(path);
            int width = 550;//ancho de página
            int height = imagen.Height;

            if (imagen.Width >= width)
                height = imagen.Height * width / imagen.Width;
            else
                return path;

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(imagen.HorizontalResolution, imagen.VerticalResolution);

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

            string resized_path = path.Substring(0, path.LastIndexOf(".")) + "_resized" + path.Substring(path.LastIndexOf("."));

            imagen.Dispose();
            destImage.Save(resized_path);

            return resized_path;
        }
    }
}
