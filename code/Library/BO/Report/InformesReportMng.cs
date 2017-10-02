using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using Csla;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Reports;
using moleQule.Library.Instruction.Reports.Alumno;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class InformesReportMng : BaseReportMng
    {

        #region Business Methods Examen

        public FaltasAlumnosRpt GetDetailReport(   CompanyInfo empresa, 
                                                   SortedBindingList<FaltaAlumnoInfo> registros)
        {
            if (registros == null) return null;
            FaltasAlumnosRpt doc = new FaltasAlumnosRpt();

            List<CompanyInfo> pList = new List<CompanyInfo>();
            List<FaltaAlumnoInfo> faltas = new List<FaltaAlumnoInfo>();

            foreach (FaltaAlumnoInfo info in registros)
                faltas.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (faltas.Count <= 0)
                return null;

            pList.Add(empresa);

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["FaltaAlumnoListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        public FaltasByAlumnoRpt GetDetailReport(CompanyInfo empresa, AlumnoInfo alumno, string promo,
                                                   FaltaAlumnoList registros)
        {
            if (registros == null) return null;
            FaltasByAlumnoRpt doc = new FaltasByAlumnoRpt();

            List<CompanyInfo> pList = new List<CompanyInfo>();
            List<FaltaAlumnoInfo> faltas = new List<FaltaAlumnoInfo>();

            foreach (FaltaAlumnoInfo info in registros)
                faltas.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (faltas.Count <= 0)
                return null;

            pList.Add(empresa);

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            doc.SetParameterValue("Alumno", alumno.Nombre + " " + alumno.Apellidos);
            doc.SetParameterValue("Promocion", promo);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["FaltaAlumnoListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        public RegistroFaltasRpt GetDetailReport(CompanyInfo empresa,
                                                   SortedBindingList<RegistroFaltasInfo> registros)
        {
            if (registros == null) return null;
            RegistroFaltasRpt doc = new RegistroFaltasRpt();

            List<CompanyInfo> pList = new List<CompanyInfo>();
            List<RegistroFaltasInfo> faltas = new List<RegistroFaltasInfo>();

            foreach (RegistroFaltasInfo info in registros)
                faltas.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (faltas.Count <= 0)
                return null;

            pList.Add(empresa);

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["RegistroFaltasListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        public NotaPracticasRpt GetDetailReport(CompanyInfo empresa,
                                                   SortedBindingList<NotaPracticasInfo> registros)
        {
            if (registros == null) return null;
            NotaPracticasRpt doc = new NotaPracticasRpt();

            List<CompanyInfo> pList = new List<CompanyInfo>();
            List<NotaPracticasInfo> faltas = new List<NotaPracticasInfo>();

            foreach (NotaPracticasInfo info in registros)
                faltas.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (faltas.Count <= 0)
                return null;

            pList.Add(empresa);

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["NotaPracticasListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        public NotaPracticasAlumnoRpt GetDetailReport(CompanyInfo empresa, AlumnoPrint alumno, string promos,
                                                   NotaPracticasList registros)
        {
            if (registros == null) return null;
            NotaPracticasAlumnoRpt doc = new NotaPracticasAlumnoRpt();

            List<CompanyInfo> pList = new List<CompanyInfo>();
            List<NotaPracticasInfo> faltas = new List<NotaPracticasInfo>();

            foreach (NotaPracticasInfo info in registros)
                faltas.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (faltas.Count <= 0)
                return null;

            pList.Add(empresa);

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            doc.SetParameterValue("Alumno", alumno.Nombre + " " + alumno.Apellidos);
            doc.SetParameterValue("Promoción", promos);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            doc.Subreports["NotaPracticasListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        #endregion

        #region Factory Methods

        public InformesReportMng()
        {

        }

        public InformesReportMng(ISchemaInfo empresa)
            : base(empresa)
        { }

        #endregion

        #region Style

        #endregion

    }
}
