using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using Csla;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Reports;
using moleQule.Library.Instruction.Reports.Instructor;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class InstructorReportMng : BaseReportMng
    {

        #region Business Methods Examen

        public CapacitacionInstructorRpt GetDetailReport(   CompanyInfo empresa, 
                                                    InstructorInfo instructor, 
                                                   Submodulo_Instructor_PromocionList registros)
        {
            if (registros == null) return null;
            CapacitacionInstructorRpt doc = new CapacitacionInstructorRpt();

            List<InstructorInfo> pList = new List<InstructorInfo>();
            List<Submodulo_Instructor_PromocionPrint> capacitaciones = new List<Submodulo_Instructor_PromocionPrint>();

            foreach (Submodulo_Instructor_PromocionInfo info in registros)
                capacitaciones.Add(info.GetPrintObject());

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (capacitaciones.Count <= 0)
                return null;

            pList.Add(instructor);

            doc.SetDataSource(pList);

            doc.Subreports["CapacitacionInstructorSubListRpt"].SetDataSource(registros);

            //FormatReport(doc);

            return doc;
        }
                
        #endregion

        #region Factory Methods

        public InstructorReportMng()
        {

        }

        public InstructorReportMng(ISchemaInfo empresa)
            : base(empresa)
        { }

        #endregion

        #region Style

        #endregion

    }
}
