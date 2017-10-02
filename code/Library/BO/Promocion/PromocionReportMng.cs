using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using Csla;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Reports;
using moleQule.Library.Instruction.Reports.Promocion;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class PromocionReportMng : BaseReportMng
    {

        #region Business Methods Examen

        public ClasesTeoricasDisponiblesRpt GetDetailReport(   CompanyInfo empresa, 
                                                    PromocionInfo promocion, 
                                                   SortedBindingList<ClaseTeoricaInfo> registros)
        {
            if (registros == null) return null;
            ClasesTeoricasDisponiblesRpt doc = new ClasesTeoricasDisponiblesRpt();

            List<PromocionInfo> pList = new List<PromocionInfo>();
            List<ClaseTeoricaInfo> clases = new List<ClaseTeoricaInfo>();

            foreach (ClaseTeoricaInfo info in registros)
                clases.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (clases.Count <= 0)
                return null;

            pList.Add(promocion);

            doc.SetDataSource(pList);
            ((TextObject)doc.Section5.ReportObjects["Empresa"]).Text = empresa.Name;

            doc.Subreports["TeoricasNoImpartidasListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        public ClasesTeoricasImpartidasRpt GetDetailImpartidasReport(CompanyInfo empresa,
                                                    PromocionInfo promocion,
                                                   SortedBindingList<ClaseTeoricaInfo> registros)
        {
            if (registros == null) return null;
            ClasesTeoricasImpartidasRpt doc = new ClasesTeoricasImpartidasRpt();

            List<PromocionInfo> pList = new List<PromocionInfo>();
            List<ClaseTeoricaInfo> clases = new List<ClaseTeoricaInfo>();

            foreach (ClaseTeoricaInfo info in registros)
                clases.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (clases.Count <= 0)
                return null;

            pList.Add(promocion);

            doc.SetDataSource(pList);
            ((TextObject)doc.Section5.ReportObjects["Empresa"]).Text = empresa.Name;

            doc.Subreports["TeoricasImpartidasListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        public ClasesPracticasDisponiblesRpt GetDetailReport(CompanyInfo empresa,
                                                    PromocionInfo promocion,
                                                   SortedBindingList<ClasePracticaInfo> registros)
        {
            if (registros == null) return null;
            ClasesPracticasDisponiblesRpt doc = new ClasesPracticasDisponiblesRpt();

            List<PromocionInfo> pList = new List<PromocionInfo>();
            List<ClasePracticaInfo> clases = new List<ClasePracticaInfo>();

            foreach (ClasePracticaInfo info in registros)
                clases.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (clases.Count <= 0)
                return null;

            pList.Add(promocion);

            doc.SetDataSource(pList);
            ((TextObject)doc.Section5.ReportObjects["Empresa"]).Text = empresa.Name;

            doc.Subreports["PracticasNoImpartidasListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }

        public ClasesPracticasImpartidasRpt GetDetailImpartidasReport(CompanyInfo empresa,
                                                PromocionInfo promocion,
                                               SortedBindingList<ClasePracticaInfo> registros)
        {
            if (registros == null) return null;
            ClasesPracticasImpartidasRpt doc = new ClasesPracticasImpartidasRpt();

            List<PromocionInfo> pList = new List<PromocionInfo>();
            List<ClasePracticaInfo> clases = new List<ClasePracticaInfo>();

            foreach (ClasePracticaInfo info in registros)
                clases.Add(info);

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (clases.Count <= 0)
                return null;

            pList.Add(promocion);

            doc.SetDataSource(pList);
            ((TextObject)doc.Section5.ReportObjects["Empresa"]).Text = empresa.Name;

            doc.Subreports["PracticasImpartidasListSubRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }
                
        #endregion

        #region Factory Methods

        public PromocionReportMng()
        {

        }

        public PromocionReportMng(ISchemaInfo empresa)
            : base(empresa)
        { }

        #endregion

        #region Style

        #endregion

    }
}
