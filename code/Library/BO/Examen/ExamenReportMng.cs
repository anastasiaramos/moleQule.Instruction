using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Reports;
using moleQule.Library.Instruction.Reports.Examen;
using moleQule.Library.Instruction.Reports.Preguntas;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class ExamenReportMng : BaseReportMng
    {

        #region Business Methods Examen

        //public ExamenTestRpt GetDetailTestReport(   ExamenInfo item, 
        //                                            CompanyInfo empresa, 
        //                                            Preguntas lista_preguntas)
        //{
        //    if (item == null) return null;
        //    ExamenTestRpt doc = new ExamenTestRpt();
            
        //    List<ExamenPrint> pList = new List<ExamenPrint>();
        //    List<PreguntaExamenInfo> preguntas = new List<PreguntaExamenInfo>();
        //    List<RespuestaExamenPrint> respuestas = new List<RespuestaExamenPrint>();

        //    foreach (PreguntaExamenInfo info in item.PreguntaExamenes)
        //    {
        //        bool imagen = true;
        //        preguntas.Add(info.GetPrintObject(lista_preguntas));
        //        foreach (RespuestaExamenInfo r_info in info.RespuestaExamenes)
        //        {
        //            respuestas.Add(r_info.GetPrintObject(info, lista_preguntas, item, imagen));
        //            imagen = false; //será verdadero sólo en la primera iteración, para que sólo cargue la imagen una vez
        //        }
        //    }

        //    //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
        //    if (preguntas.Count <= 0)
        //        return null;
            
        //    pList.Add(item.GetPrintObject(empresa, string.Empty));

        //    doc.SetDataSource(pList);

        //    doc.Subreports["RespuestaExamenListSubRpt"].SetDataSource(respuestas);
        //    doc.SetParameterValue("Empresa", empresa.Name);

        //    //FormatReport(doc, preguntas);

        //    return doc;
        //}

        public ExamenTestRpt GetDetailTestReport(ExamenInfo item,
                                                CompanyInfo empresa,
                                                PreguntaList lista_preguntas)
        {
            if (item == null) return null;
            ExamenTestRpt doc = new ExamenTestRpt();

            List<ExamenPrint> pList = new List<ExamenPrint>();
            List<PreguntaExamenInfo> preguntas = new List<PreguntaExamenInfo>();
            List<RespuestaExamenPrint> respuestas = new List<RespuestaExamenPrint>();

            foreach (PreguntaExamenInfo info in item.PreguntaExamenes)
            {
                bool imagen = true;
                preguntas.Add(PreguntaExamenPrint.New(info, lista_preguntas));
                foreach (RespuestaExamenInfo r_info in info.RespuestaExamenes)
                {
                    respuestas.Add(RespuestaExamenPrint.New(r_info, info, lista_preguntas, item, imagen));
                    imagen = false; //será verdadero sólo en la primera iteración, para que sólo cargue la imagen una vez
                }
            }

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (preguntas.Count <= 0)
                return null;

            pList.Add(item.GetPrintObject(empresa, string.Empty));

            doc.SetDataSource(pList);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.FieldObject)(doc.Section5.ReportObjects["Empresa1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["RespuestaExamenListSubRpt"].SetDataSource(respuestas);
            doc.SetParameterValue("Empresa", empresa.Name);

            //FormatReport(doc, preguntas);

            return doc;
        }

        public ExamenDesarrolloRpt GetDetailDesarrolloReport(ExamenInfo item, CompanyInfo empresa, PreguntaList lista_preguntas)
        {
            if (item == null) return null;
            ExamenDesarrolloRpt doc = new ExamenDesarrolloRpt();

            List<ExamenPrint> pList = new List<ExamenPrint>();
            List<PreguntaExamenPrint> preguntas = new List<PreguntaExamenPrint>();

            foreach (PreguntaExamenInfo info in item.PreguntaExamenes)
            {
                preguntas.Add(info.GetPrintObject(lista_preguntas));
            }

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (preguntas.Count <= 0)
                return null;

            pList.Add(item.GetPrintObject(empresa, string.Empty));

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["PreguntaExamenListSubRpt"].SetDataSource(preguntas);
            doc.SetParameterValue("Empresa", empresa.Name);

            //FormatReport(doc, empresa.Logo);

            return doc;
        }

        public PreguntasTestRpt GetDetailPreguntasTestReport(PreguntaExamens lista_preguntas, Preguntas preguntas)
        {
            if (lista_preguntas == null) return null;
            PreguntasTestRpt doc = new PreguntasTestRpt();

            List<PreguntaExamenInfo> preguntas_examen = new List<PreguntaExamenInfo>();
            List<RespuestaExamenPrint> respuestas = new List<RespuestaExamenPrint>();

            foreach (PreguntaExamen item in lista_preguntas)
            {
                bool imagen = true;
                PreguntaExamenInfo info = item.GetInfo(true);
                preguntas_examen.Add(info.GetPrintObject(preguntas));
                foreach (RespuestaExamenInfo r_info in info.RespuestaExamenes)
                {
                    respuestas.Add(r_info.GetPrintObject(info, preguntas, null, imagen));
                    imagen = false; //será verdadero sólo en la primera iteración, para que cargue la imagen sólo una vez
                }
            }

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (preguntas_examen.Count <= 0)
                return null;

            doc.Subreports["RespuestaExamenListSubRpt"].SetDataSource(respuestas);

            return doc;
        }

        public PreguntasDesarrolloRpt GetDetailPreguntasDesarrolloReport(PreguntaExamens lista_preguntas, Preguntas preguntas)
        {
            if (lista_preguntas == null) return null;
            PreguntasDesarrolloRpt doc = new PreguntasDesarrolloRpt();

            List<PreguntaExamenInfo> preguntas_examen = new List<PreguntaExamenInfo>();

            foreach (PreguntaExamen item in lista_preguntas)
            {
                PreguntaExamenInfo info = item.GetInfo(true);
                preguntas_examen.Add(info.GetPrintObject(preguntas));
            }

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (preguntas_examen.Count <= 0)
                return null;

           // doc.Subreports["RespuestaExamenListSubRpt"].SetDataSource(preguntas);

            return doc;
        }

        public PreguntasListRpt GetPreguntasListReport(PreguntaList preguntas)
        {
            if (preguntas == null) return null;
            PreguntasListRpt doc = new PreguntasListRpt();

            List<PreguntaPrint> pList = new List<PreguntaPrint>();

            foreach (PreguntaInfo item in preguntas)
            {
                pList.Add(item.GetPrintObject(1));
            }

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (pList.Count <= 0)
                return null;

            doc.SetDataSource(pList);
            // doc.Subreports["RespuestaExamenListSubRpt"].SetDataSource(preguntas);

            return doc;
        }

        public InformePreguntasRpt GetInformePreguntasReport(InformePreguntasList lista)
        {
            if (lista == null) return null;
            InformePreguntasRpt doc = new InformePreguntasRpt();


            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;

            doc.SetDataSource(lista);
            // doc.Subreports["RespuestaExamenListSubRpt"].SetDataSource(preguntas);

            return doc;
        }
         
        public InformePlantillaRpt GetInformePlantillaReport(PlantillaExamenInfo item, InformePlantillaList lista)
        {
            if (lista == null) return null;
            InformePlantillaRpt doc = new InformePlantillaRpt();


            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;

            List<PlantillaExamenInfo> pList = new List<PlantillaExamenInfo>();

            pList.Add(item);

            doc.SetDataSource(pList);
            doc.Subreports[0].SetDataSource(lista);

            return doc;
        }

        public InformeDisponiblesPlantillaRpt GetInformeDisponiblesPlantillaReport(PlantillaExamenInfo item, InformePlantillaList lista)
        {
            if (lista == null) return null;
            InformeDisponiblesPlantillaRpt doc = new InformeDisponiblesPlantillaRpt();


            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;

            List<PlantillaExamenInfo> pList = new List<PlantillaExamenInfo>();

            pList.Add(item);

            doc.SetDataSource(pList);
            doc.Subreports[0].SetDataSource(lista);

            return doc;
        }

        public InformeDisponiblesPlantillaDesarrolloRpt GetInformeDisponiblesPlantillaDesarrolloReport(PlantillaExamenInfo item, InformePlantillaList lista)
        {
            if (lista == null) return null;
            InformeDisponiblesPlantillaDesarrolloRpt doc = new InformeDisponiblesPlantillaDesarrolloRpt();


            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;

            List<PlantillaExamenInfo> pList = new List<PlantillaExamenInfo>();

            pList.Add(item);

            doc.SetDataSource(pList);
            doc.Subreports[0].SetDataSource(lista);

            return doc;
        }

        public PortadaExamenRpt GetPortadaReport(ExamenInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;

            PortadaExamenRpt doc = new PortadaExamenRpt();

            List<ExamenPrint> pList = new List<ExamenPrint>();

            pList.Add(item.GetPrintObject(empresa, string.Empty));

            doc.SetDataSource(pList);

            return doc;
        }

        public PlantillaRespuestasExamenRpt GetPlantillaRespuestasReport(ExamenInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;

            PlantillaRespuestasExamenRpt doc = new PlantillaRespuestasExamenRpt();

            List<ExamenPrint> pList = new List<ExamenPrint>();

            pList.Add(item.GetPrintObject(empresa, string.Empty));

            doc.SetDataSource(pList);

            return doc;
        }

        public PlantillaCorrectoraExamenRpt GetPlantillaCorrectoraReport(ExamenInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;
            
            PlantillaCorrectoraExamenRpt doc = new PlantillaCorrectoraExamenRpt();
            List<ExamenPrint> pList = new List<ExamenPrint>();

            FormatReport(doc, item.PreguntaExamenes);

            pList.Add(item.GetPrintObject(empresa, string.Empty));

            doc.SetDataSource(pList);

            return doc;
        }

        public RegistroNotasExamenRpt GetDetailReport(  ExamenInfo item, 
                                                        List<Alumno_ExamenInfo> _alumnos, 
                                                        PromocionInfo promocion,
                                                        CompanyInfo empresa)
        {
            if (item == null) return null;
            RegistroNotasExamenRpt doc = new RegistroNotasExamenRpt();
            string comentarios = string.Empty;
            AlumnoList lista = AlumnoList.GetOrdenAlfabeticoList(true, _alumnos);

            List<ExamenPrint> pList = new List<ExamenPrint>();
            List<Alumno_ExamenPrint> alumnos = new List<Alumno_ExamenPrint>();

            int i = 1;

            foreach (AlumnoInfo alumno in lista)
            {
                Alumno_ExamenInfo info = null;
                foreach (Alumno_ExamenInfo ae in _alumnos)
                {
                    if (ae.OidAlumno == alumno.Oid)
                    {
                        info = ae;
                        break;
                    }
                }

                if (info != null)
                {
                    Alumno_ExamenPrint obj = info.GetPrintObject(alumno, i++, true);

                    if (item.Desarrollo && info.Presentado)
                    {
                        obj.NotaTest = string.Empty;
                        foreach (Respuesta_Alumno_ExamenInfo resp in info.Respuestas)
                        {
                            if (obj.NotaTest.Length > 0)
                                obj.NotaTest += " - ";
                            obj.NotaTest += resp.Calificacion.ToString() + "%";
                        }
                    }

                    alumnos.Add(obj);
                    if (info.Observaciones != string.Empty)
                        comentarios += alumno.NExpediente + " - " + alumno.Nombre + " " + alumno.Apellidos + " - " + info.Observaciones + Environment.NewLine;
                }
            }

            //foreach (Alumno_ExamenInfo info in _alumnos)
            //{
            //    AlumnoInfo alumno = lista.GetItem(info.OidAlumno);
            //    Alumno_ExamenPrint obj = info.GetPrintObject(alumno, i++, true);
                
            //    if (item.Desarrollo && info.Presentado)
            //    {
            //        obj.NotaTest = string.Empty;
            //        foreach (Respuesta_Alumno_ExamenInfo resp in info.Respuestas)
            //        {
            //            if (obj.NotaTest.Length > 0)
            //                obj.NotaTest += " - ";
            //            obj.NotaTest += resp.Calificacion.ToString() + "%";
            //        }
            //    }

            //    alumnos.Add(obj);
            //    if (info.Observaciones != string.Empty)
            //        comentarios += alumno.NExpediente + " - " + alumno.Nombre + " " + alumno.Apellidos  + " - " + info.Observaciones + Environment.NewLine;
            //}

            pList.Add(item.GetPrintObject(empresa, promocion.Nombre, comentarios));

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (alumnos.Count <= 0)
                return null;

            doc.SetDataSource(pList);
            doc.Subreports["NotasExamenAlumnosListSubRpt"].SetDataSource(alumnos);

            return doc;
        }

        public AsistenciaExamenRpt GetDetailAsistenciaExamenReport(ExamenInfo item, 
                                                                    PromocionList promociones,
                                                                    List<Alumno_ExamenInfo> _alumnos,
                                                                    CompanyInfo empresa,
                                                                    string promocion)
        {
            if (item == null) return null;
            AsistenciaExamenRpt doc = new AsistenciaExamenRpt();
            AlumnoList lista = AlumnoList.GetList(false);

            List<ExamenPrint> pList = new List<ExamenPrint>();
            List<Alumno_ExamenPrint> alumnos = new List<Alumno_ExamenPrint>(); 

            int i = 1;
            bool isIn = false;
            foreach (Alumno_ExamenInfo info in _alumnos)
            {
                isIn = false; 

                foreach(ExamenPrint exam in pList)
                    if (exam.OidPromocionAlumno == info.OidPromocion)
                        isIn = true;

                if (!isIn) pList.Add(item.GetPrintObject(empresa, promocion, string.Empty));

                alumnos.Add(info.GetPrintObject(lista.GetItem(info.OidAlumno), i++, false));
            }

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (alumnos.Count <= 0)
                return null;

            if (pList.Count == 0)
                pList.Add(item.GetPrintObject(empresa, string.Empty));
            doc.SetDataSource(pList);
            doc.Subreports["AsistenciaExamenAlumnosListSubRpt"].SetDataSource(alumnos);

            return doc;
        }

        public ResumenExamenRpt GetDetailResumenExamenReport(   ExamenInfo item, 
                                                                PreguntaList preguntas,
                                                                PromocionInfo promocion,
                                                                CompanyInfo empresa)
        {
            if (item == null) return null;
            ResumenExamenRpt doc = new ResumenExamenRpt();

            List<ExamenPrint> pList = new List<ExamenPrint>();
            List<PreguntaPrint> _preguntas = new List<PreguntaPrint>();

            if (promocion == null)
                pList.Add(item.GetPrintObject(empresa, string.Empty));
            else
                pList.Add(item.GetPrintObject(empresa, promocion.Nombre, string.Empty));

            int i = 1;
            foreach (PreguntaInfo info in preguntas)
                _preguntas.Add(info.GetPrintObject(i++));

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (_preguntas.Count <= 0)
                return null;

            doc.SetDataSource(pList);
            doc.Subreports["ListadoPreguntasExamenListSubRpt"].SetDataSource(_preguntas);

            return doc;
        }


        public ResumenAgrupadoExamenRpt GetDetailResumenExamenReport(ExamenInfo item,
                                                                List<RegistroResumen> registros,
                                                                PromocionInfo promocion,
                                                                CompanyInfo empresa)
        {
            if (item == null) return null;
            ResumenAgrupadoExamenRpt doc = new ResumenAgrupadoExamenRpt();

            List<ExamenPrint> pList = new List<ExamenPrint>();

            if (promocion == null)
                pList.Add(item.GetPrintObject(empresa, string.Empty));
            else
                pList.Add(item.GetPrintObject(empresa, promocion.Nombre, string.Empty));
                        
            doc.SetDataSource(pList);
            doc.Subreports["RegistroResumenListSubRpt"].SetDataSource(registros);

            return doc;
        }


        public EstadisticaExamenRpt GetEstadisticaReport(ExamenInfo item,
                                                        EstadisticaExamenList lista,
                                                        CompanyInfo empresa)
        {
            if (item == null) return null;
            EstadisticaExamenRpt doc = new EstadisticaExamenRpt();

            List<ExamenPrint> pList = new List<ExamenPrint>();
            List<EstadisticaExamenInfo> preguntas = new List<EstadisticaExamenInfo>();

            foreach (EstadisticaExamenInfo info in lista)
                preguntas.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (preguntas.Count <= 0)
                return null;

            pList.Add(item.GetPrintObject(empresa, string.Empty));

            doc.SetDataSource(pList);

            doc.Subreports["EstadisticaExamenListSubRpt"].SetDataSource(preguntas);

            //FormatReport(doc);

            return doc;
        }

        #endregion

        #region Factory Methods

        public ExamenReportMng()
        {

        }

        public ExamenReportMng(ISchemaInfo empresa)
            : base(empresa)
        { }

        #endregion

        #region Style

        //private static void FormatReport(ExamenTestRpt rpt, List<PreguntaExamenInfo> preguntas)
        //{
        //    ReportDefinition report = (ReportDefinition)rpt.Subreports["RespuestaExamenListSubRpt"].ReportDefinition;
            
        //}

        //private static void FormatReport(ExamenDesarrolloRpt rpt, string logo)
        //{
        //    string path = Library.Common.ModuleController.LOGOS_EMPRESAS_PATH + logo;

        //    if (File.Exists(path))
        //    {
        //        Image image = Image.FromFile(path);
        //        int width = rpt.Section1.ReportObjects["Logo"].Width;
        //        int height = rpt.Section1.ReportObjects["Logo"].Height;

        //        rpt.Section1.ReportObjects["Logo"].Width = 15 * image.Width;
        //        rpt.Section1.ReportObjects["Logo"].Height = 15 * image.Height;
        //        rpt.Section1.ReportObjects["Logo"].Left += (width - 15 * image.Width) / 2;
        //        rpt.Section1.ReportObjects["Logo"].Top += (height - 15 * image.Height) / 2;
        //    }
        //}

        private static void FormatReport(PlantillaCorrectoraExamenRpt rpt, PreguntaExamenList list)
        {
            List<ReportObject> lista = new List<ReportObject>();
            
            lista.Add(rpt.Section3.ReportObjects["label1"]);
            lista.Add(rpt.Section3.ReportObjects["label2"]);
            lista.Add(rpt.Section3.ReportObjects["label3"]);
            lista.Add(rpt.Section3.ReportObjects["label4"]);
            lista.Add(rpt.Section3.ReportObjects["label5"]);
            lista.Add(rpt.Section3.ReportObjects["label6"]);
            lista.Add(rpt.Section3.ReportObjects["label7"]);
            lista.Add(rpt.Section3.ReportObjects["label8"]);
            lista.Add(rpt.Section3.ReportObjects["label9"]);
            lista.Add(rpt.Section3.ReportObjects["label10"]);
            lista.Add(rpt.Section3.ReportObjects["label11"]);
            lista.Add(rpt.Section3.ReportObjects["label12"]);
            lista.Add(rpt.Section3.ReportObjects["label13"]);
            lista.Add(rpt.Section3.ReportObjects["label14"]);
            lista.Add(rpt.Section3.ReportObjects["label15"]);
            lista.Add(rpt.Section3.ReportObjects["label16"]);
            lista.Add(rpt.Section3.ReportObjects["label17"]);
            lista.Add(rpt.Section3.ReportObjects["label18"]);
            lista.Add(rpt.Section3.ReportObjects["label19"]);
            lista.Add(rpt.Section3.ReportObjects["label20"]);
            lista.Add(rpt.Section3.ReportObjects["label21"]);
            lista.Add(rpt.Section3.ReportObjects["label22"]);
            lista.Add(rpt.Section3.ReportObjects["label23"]);
            lista.Add(rpt.Section3.ReportObjects["label24"]);
            lista.Add(rpt.Section3.ReportObjects["label25"]);
            lista.Add(rpt.Section3.ReportObjects["label26"]);
            lista.Add(rpt.Section3.ReportObjects["label27"]);
            lista.Add(rpt.Section3.ReportObjects["label28"]);
            lista.Add(rpt.Section3.ReportObjects["label29"]);
            lista.Add(rpt.Section3.ReportObjects["label30"]);
            lista.Add(rpt.Section3.ReportObjects["label31"]);
            lista.Add(rpt.Section3.ReportObjects["label32"]);
            lista.Add(rpt.Section3.ReportObjects["label33"]);
            lista.Add(rpt.Section3.ReportObjects["label34"]);
            lista.Add(rpt.Section3.ReportObjects["label35"]);
            lista.Add(rpt.Section3.ReportObjects["label36"]);
            lista.Add(rpt.Section3.ReportObjects["label37"]);
            lista.Add(rpt.Section3.ReportObjects["label38"]);
            lista.Add(rpt.Section3.ReportObjects["label39"]);
            lista.Add(rpt.Section3.ReportObjects["label40"]);
            lista.Add(rpt.Section3.ReportObjects["label41"]);
            lista.Add(rpt.Section3.ReportObjects["label42"]);
            lista.Add(rpt.Section3.ReportObjects["label43"]);
            lista.Add(rpt.Section3.ReportObjects["label44"]);
            lista.Add(rpt.Section3.ReportObjects["label45"]);
            lista.Add(rpt.Section3.ReportObjects["label46"]);
            lista.Add(rpt.Section3.ReportObjects["label47"]);
            lista.Add(rpt.Section3.ReportObjects["label48"]);
            lista.Add(rpt.Section3.ReportObjects["label49"]);
            lista.Add(rpt.Section3.ReportObjects["label50"]);
            lista.Add(rpt.Section3.ReportObjects["label51"]);
            lista.Add(rpt.Section3.ReportObjects["label52"]);
            lista.Add(rpt.Section3.ReportObjects["label53"]);
            lista.Add(rpt.Section3.ReportObjects["label54"]);
            lista.Add(rpt.Section3.ReportObjects["label55"]);
            lista.Add(rpt.Section3.ReportObjects["label56"]);
            lista.Add(rpt.Section3.ReportObjects["label57"]);
            lista.Add(rpt.Section3.ReportObjects["label58"]);
            lista.Add(rpt.Section3.ReportObjects["label59"]);
            lista.Add(rpt.Section3.ReportObjects["label60"]);
            lista.Add(rpt.Section3.ReportObjects["label61"]);
            lista.Add(rpt.Section3.ReportObjects["label62"]);
            lista.Add(rpt.Section3.ReportObjects["label63"]);
            lista.Add(rpt.Section3.ReportObjects["label64"]);
            lista.Add(rpt.Section3.ReportObjects["label65"]);
            lista.Add(rpt.Section3.ReportObjects["label66"]);
            lista.Add(rpt.Section3.ReportObjects["label67"]);
            lista.Add(rpt.Section3.ReportObjects["label68"]);
            lista.Add(rpt.Section3.ReportObjects["label69"]);
            lista.Add(rpt.Section3.ReportObjects["label70"]);
            lista.Add(rpt.Section3.ReportObjects["label71"]);
            lista.Add(rpt.Section3.ReportObjects["label72"]);
            lista.Add(rpt.Section3.ReportObjects["label73"]);
            lista.Add(rpt.Section3.ReportObjects["label74"]);
            lista.Add(rpt.Section3.ReportObjects["label75"]);
            lista.Add(rpt.Section3.ReportObjects["label76"]);
            lista.Add(rpt.Section3.ReportObjects["label77"]);
            lista.Add(rpt.Section3.ReportObjects["label78"]);
            lista.Add(rpt.Section3.ReportObjects["label79"]);
            lista.Add(rpt.Section3.ReportObjects["label80"]);
            lista.Add(rpt.Section3.ReportObjects["label81"]);
            lista.Add(rpt.Section3.ReportObjects["label82"]);
            lista.Add(rpt.Section3.ReportObjects["label83"]);
            lista.Add(rpt.Section3.ReportObjects["label84"]);
            lista.Add(rpt.Section3.ReportObjects["label85"]);
            lista.Add(rpt.Section3.ReportObjects["label86"]);
            lista.Add(rpt.Section3.ReportObjects["label87"]);
            lista.Add(rpt.Section3.ReportObjects["label88"]);
            lista.Add(rpt.Section3.ReportObjects["label89"]);
            lista.Add(rpt.Section3.ReportObjects["label90"]);
            lista.Add(rpt.Section3.ReportObjects["label91"]);
            lista.Add(rpt.Section3.ReportObjects["label92"]);
            lista.Add(rpt.Section3.ReportObjects["label93"]);
            lista.Add(rpt.Section3.ReportObjects["label94"]);
            lista.Add(rpt.Section3.ReportObjects["label95"]);
            lista.Add(rpt.Section3.ReportObjects["label96"]);
            lista.Add(rpt.Section3.ReportObjects["label97"]);
            lista.Add(rpt.Section3.ReportObjects["label98"]);
            lista.Add(rpt.Section3.ReportObjects["label99"]);
            lista.Add(rpt.Section3.ReportObjects["label100"]);
            lista.Add(rpt.Section3.ReportObjects["label101"]);
            lista.Add(rpt.Section3.ReportObjects["label102"]);
            lista.Add(rpt.Section3.ReportObjects["label103"]);
            lista.Add(rpt.Section3.ReportObjects["label104"]);
            lista.Add(rpt.Section3.ReportObjects["label105"]);
            lista.Add(rpt.Section3.ReportObjects["label106"]);
            lista.Add(rpt.Section3.ReportObjects["label107"]);
            lista.Add(rpt.Section3.ReportObjects["label108"]);
            lista.Add(rpt.Section3.ReportObjects["label109"]);
            lista.Add(rpt.Section3.ReportObjects["label110"]);
            lista.Add(rpt.Section3.ReportObjects["label111"]);
            lista.Add(rpt.Section3.ReportObjects["label112"]);
            lista.Add(rpt.Section3.ReportObjects["label113"]);
            lista.Add(rpt.Section3.ReportObjects["label114"]);
            lista.Add(rpt.Section3.ReportObjects["label115"]);
            lista.Add(rpt.Section3.ReportObjects["label116"]);
            lista.Add(rpt.Section3.ReportObjects["label117"]);
            lista.Add(rpt.Section3.ReportObjects["label118"]);
            lista.Add(rpt.Section3.ReportObjects["label119"]);
            lista.Add(rpt.Section3.ReportObjects["label120"]);
            lista.Add(rpt.Section3.ReportObjects["label121"]);
            lista.Add(rpt.Section3.ReportObjects["label122"]);
            lista.Add(rpt.Section3.ReportObjects["label123"]);
            lista.Add(rpt.Section3.ReportObjects["label124"]);
            lista.Add(rpt.Section3.ReportObjects["label125"]);
            lista.Add(rpt.Section3.ReportObjects["label126"]);
            lista.Add(rpt.Section3.ReportObjects["label127"]);
            lista.Add(rpt.Section3.ReportObjects["label128"]);
            lista.Add(rpt.Section3.ReportObjects["label129"]);
            lista.Add(rpt.Section3.ReportObjects["label130"]);
            lista.Add(rpt.Section3.ReportObjects["label131"]);
            lista.Add(rpt.Section3.ReportObjects["label132"]);
            lista.Add(rpt.Section3.ReportObjects["label133"]);
            lista.Add(rpt.Section3.ReportObjects["label134"]);
            lista.Add(rpt.Section3.ReportObjects["label135"]);
            lista.Add(rpt.Section3.ReportObjects["label136"]);
            lista.Add(rpt.Section3.ReportObjects["label137"]);
            lista.Add(rpt.Section3.ReportObjects["label138"]);
            lista.Add(rpt.Section3.ReportObjects["label139"]);
            lista.Add(rpt.Section3.ReportObjects["label140"]);

            int offset_c = 2160;
            int offset_r = 360;
            int top = 660;
            int lA = 780;
            int lB = lA + 360;
            int lC = lA + 720;

            foreach (PreguntaExamenInfo info in list)
            {
                if (info.Orden > 140) continue;
                int col = (int)(info.Orden - 1) / 28;
                int row = (int)(info.Orden - 1) % 28;
                foreach (RespuestaExamenInfo r_info in info.RespuestaExamenes)
                {
                    lista[(int)info.Orden - 1].Top = top + (offset_r * row);
                    ((BoxObject)lista[(int)info.Orden - 1]).Bottom = top + (offset_r * row) + 240;

                    if (r_info.Correcta)
                    {
                        lista[(int)info.Orden - 1].ObjectFormat.EnableSuppress = false;
                        switch (r_info.Opcion)
                        {
                            case "A":
                                {
                                    lista[(int)info.Orden - 1].Left = lA + (offset_c * col);
                                }
                                break;
                            case "B":
                                {
                                    lista[(int)info.Orden - 1].Left = lB + (offset_c * col);
                                }
                                break;
                            case "C":
                                {
                                    lista[(int)info.Orden - 1].Left = lC + (offset_c * col);
                                }
                                break;
                        }
                        ((BoxObject)lista[(int)info.Orden - 1]).Right = lista[(int)info.Orden - 1].Left + 240;
                    }
                }
            }
        }

        #endregion

    }
}
