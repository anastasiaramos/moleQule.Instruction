using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Reports;
using moleQule.Library.Instruction;

using Csla;
using moleQule.Library.Instruction.Reports.Alumno;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class AlumnoReportMng : BaseReportMng
    {

        #region Business Methods Alumno

        public CertificadoNotasRpt GetDetailReport(AlumnoInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;

            CertificadoNotasRpt doc = new CertificadoNotasRpt();
            List<AlumnoPrint> pList = new List<AlumnoPrint>();

            pList.Add(item.GetPrintObject());
            doc.SetDataSource(pList);

            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            FormatReport(doc, empresa);

            return doc;
        }

        public RegistroNotasAlumnoRpt GetDetailNotasReport(AlumnoInfo item, SortedBindingList<Alumno_ExamenInfo> list, CompanyInfo empresa)
        {
            if (item == null) return null;

            RegistroNotasAlumnoRpt doc = new RegistroNotasAlumnoRpt();
            List<AlumnoPrint> pList = new List<AlumnoPrint>();
            List<Alumno_ExamenInfo> aList = new List<Alumno_ExamenInfo>();

            pList.Add(item.GetPrintObject());
            doc.SetDataSource(pList);

            foreach (Alumno_ExamenInfo info in list)
            {
                aList.Add(info);
            }

            doc.SetDataSource(pList);

            doc.SetParameterValue("Empresa", empresa.Name); 
            //if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.FieldObject)(doc.Section5.ReportObjects["Empresa1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["NotasAlumnoListSubRpt"].SetDataSource(aList);
            
            return doc;
        }

        public MatriculaPromocionRpt GetMatriculaPromocionReport(AlumnoList list, PromocionList promociones)
        {
            if (list == null) return null;

            MatriculaPromocionRpt doc = new MatriculaPromocionRpt();
            List<MatriculaPrint> pList = new List<MatriculaPrint>();
            List<TIdioma> idiomas = new List<TIdioma>();
            List<TFormacion> formaciones = new List<TFormacion>();
            PromocionInfo promo;
            MatriculaPrint print;
        
            foreach (AlumnoInfo item in list)
            {
                //promo = promociones.GetItem(item.OidPromocion);
                if (promociones != null)
                {
                    print = MatriculaPrint.New(item);//, promo);
                    pList.Add(print);
                    foreach (TIdioma item2 in print.IdiomasList)
                        idiomas.Add(item2);
                    foreach (TFormacion item3 in print.FormacionList)
                        formaciones.Add(item3);
                }
            }
            
            doc.SetDataSource(pList);
            doc.Subreports["IdiomasRpt"].SetDataSource(idiomas);
            doc.Subreports["FormacionRpt"].SetDataSource(formaciones);
            
            FormatReport(doc);

            return doc;
        }

        public DocumentacionRpt GetDocumentacionReport(AlumnoList list, PromocionList promociones)
        {
            if (list == null) return null;

            DocumentacionRpt doc = new DocumentacionRpt();
            List<MatriculaPrint> pList = new List<MatriculaPrint>();
            PromocionInfo promo;

            foreach (AlumnoInfo item in list)
            {
                //promo = promociones.GetItem(item.OidPromocion);
                if (promociones != null)
                    pList.Add(MatriculaPrint.New(item));//, promo));
            }

            doc.SetDataSource(pList);

            FormatReport(doc);

            return doc;
        }

        public AlumnosAdmitidosExamenRpt GetAlumnosAdmitidosReport(Alumno_PromocionList list, ModuloInfo modulo, CompanyInfo empresa)
        {
            if (list == null) return null;

            AlumnosAdmitidosExamenRpt doc = new AlumnosAdmitidosExamenRpt();
            List<Alumno_PromocionInfo> pList = new List<Alumno_PromocionInfo>();

            foreach (Alumno_PromocionInfo item in list)
            {
                pList.Add(item);
            }

            doc.SetDataSource(pList);

            doc.SetParameterValue("Empresa", empresa.Name);
            doc.SetParameterValue("Modulo", modulo.Codigo + " " + modulo.Texto);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }


        #endregion

        #region Factory Methods

        public AlumnoReportMng() {}

        public AlumnoReportMng(ISchemaInfo empresa)
            : this(empresa, string.Empty) {}

        public AlumnoReportMng(ISchemaInfo empresa, string title)
            : this(empresa, title, string.Empty) { }

        public AlumnoReportMng(ISchemaInfo empresa, string title, string filter)
            : base(empresa, title, filter) { }

        #endregion
        
        #region Style

        private void FormatReport(CertificadoNotasRpt rpt, CompanyInfo empresa)
        {
            string path = CompanyInfo.GetLogoPath(empresa.Oid);

            if (File.Exists(path))
            {
                Image image = Image.FromFile(path);
                int width = rpt.Section1.ReportObjects["Logo"].Width;
                int height = rpt.Section1.ReportObjects["Logo"].Height;

                rpt.Section1.ReportObjects["Logo"].Width = 15 * image.Width;
                rpt.Section1.ReportObjects["Logo"].Height = 15 * image.Height;
                rpt.Section1.ReportObjects["Logo"].Left += (width - 15 * image.Width) / 2;
                rpt.Section1.ReportObjects["Logo"].Top += (height - 15 * image.Height) / 2;
            }
        }

        private void FormatReport(MatriculaPromocionRpt rpt)
        {
            string path = CompanyInfo.GetLogoPath(Schema.Oid);

            if (File.Exists(path))
            {
                Image image = Image.FromFile(path);
                int width = rpt.Section1.ReportObjects["Logo"].Width;
                int height = rpt.Section1.ReportObjects["Logo"].Height;

                rpt.Section1.ReportObjects["Logo"].Width = 15 * image.Width;
                rpt.Section1.ReportObjects["Logo"].Height = 15 * image.Height;
                rpt.Section1.ReportObjects["Logo"].Left += (width - 15 * image.Width) / 2;
                rpt.Section1.ReportObjects["Logo"].Top += (height - 15 * image.Height) / 2;
            }
        }

        private void FormatReport(DocumentacionRpt rpt)
        {
            string path = CompanyInfo.GetLogoPath(Schema.Oid);

            if (File.Exists(path))
            {
                Image image = Image.FromFile(path);
                int width = rpt.Section1.ReportObjects["Logo"].Width;
                int height = rpt.Section1.ReportObjects["Logo"].Height;

                rpt.Section1.ReportObjects["Logo"].Width = 15 * image.Width;
                rpt.Section1.ReportObjects["Logo"].Height = 15 * image.Height;
                rpt.Section1.ReportObjects["Logo"].Left += (width - 15 * image.Width) / 2;
                rpt.Section1.ReportObjects["Logo"].Top += (height - 15 * image.Height) / 2;
            }
        }

        #endregion

    }
}
