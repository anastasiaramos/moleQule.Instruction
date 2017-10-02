using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using moleQule.Library;
using moleQule.Library.Reports;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class FestivoReportMng : BaseReportMng
    {
	
        #region Factory Methods

        public FestivoReportMng() {}

        public FestivoReportMng(ISchemaInfo empresa)
            : this(empresa, string.Empty) { }

        public FestivoReportMng(ISchemaInfo empresa, string title)
            : this(empresa, title, string.Empty) {}

        public FestivoReportMng(ISchemaInfo empresa, string title, string filter)
            : base(empresa, title, filter) { }
			
        #endregion
        
        #region Style

        /*private static void FormatReport(FestivoRpt rpt, string logo)
        {
            string path = Images.GetRootPath() + "\\" + Resources.Paths.LOGO_EMPRESAS + logo;

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
        }*/

        #endregion

        #region Business Methods Festivo
		
        //public FestivoRpt GetDetailReport(FestivoInfo item)
        //{
        //    if (item == null) return null;
			
        //    FestivoRpt doc = new FestivoRpt();
            
        //    List<FestivoPrint> pList = new List<FestivoPrint>();

        //    pList.Add(FestivoPrint.New(item));
        //    doc.SetDataSource(pList);
        //    doc.SetParameterValue("Empresa", Schema.Name);
			
			

        //    //FormatReport(doc, empresa.Logo);

        //    return doc;
        //}

        //public FestivoListRpt GetListReport(FestivoList list)
        //{
        //    if (list.Count == 0) return null;

        //    FestivoListRpt doc = new ClienteListRpt();

        //    List<FestivoPrint> pList = new List<FestivoPrint>();
			
        //    foreach (FestivoInfo item in list)
        //    {
        //        pList.Add(FestivoPrint.New(item));;
        //    }
			
        //    doc.SetDataSource(pList);
			
        //    FormatHeader(doc);

        //    return doc;
        //}
		
        #endregion

    }
}
