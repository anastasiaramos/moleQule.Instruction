using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Examen;

namespace moleQule.Face.Instruction
{
    public partial class ExamenTestReportForm : Skin01.ActionSkinForm
    {

        #region Attributes & Properties

        public const string ID = "ExamenTestReportForm";
        public static Type Type { get { return typeof(ExamenTestReportForm); } }

        private ExamenInfo _entity;
        private PreguntaList _preguntas = null;
        private Pregunta_Examens _preguntas_examen = null;
        public ExamenInfo Entity { get { return _entity; } set { _entity = value; } }

        #endregion

        #region Factory Methods

        public ExamenTestReportForm()
            : base(true) { }

        public ExamenTestReportForm(bool IsModal,
                                    ExamenInfo item,
                                    PreguntaList preguntas,
                                    Pregunta_Examens preguntas_examen)
            : base(IsModal)
        {
            InitializeComponent();
            _entity = item;
            _preguntas = preguntas;
            _preguntas_examen = preguntas_examen;
            SetFormData();
            this.Text = Resources.Labels.PRINT_TITLE;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
        }

        #endregion

        #region Business Methods

        protected void ExportaCR(ETipoPagina pagina, CompanyInfo empresa)
        {
            ISchemaInfo schema = AppContext.ActiveSchema;
            try
            {
                schema = empresa as ISchemaInfo;
                if (schema == null) schema = AppContext.ActiveSchema;
            }
            catch
            {
            }
            ExamenReportMng reportMng = new ExamenReportMng(schema);

            switch (pagina)
            {
                case ETipoPagina.Portada:

                    PortadaExamenRpt portada = reportMng.GetPortadaReport(Entity,
                                                        empresa);
                    ReportViewer.SetReport(portada);
                    ReportViewer.ShowDialog();

                    break;

                case ETipoPagina.Preguntas:

                    ExamenTestRpt examen = reportMng.GetDetailTestReport(Entity,
                        empresa, _preguntas);

                    examen.SetParameterValue("Empresa", empresa.Name);
                    if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(examen.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                    ReportViewer.SetReport(examen);
                    ReportViewer.ShowDialog();

                    if (Directory.Exists(".\\Temp"))
                        Directory.Delete(".\\Temp", true);

                    break;

                case ETipoPagina.Respuestas:

                    PlantillaRespuestasExamenRpt plantilla = reportMng.GetPlantillaRespuestasReport(Entity,
                                                                        empresa);

                    ReportViewer.SetReport(plantilla);
                    ReportViewer.ShowDialog();

                    break;

                case ETipoPagina.PlantillaCorrectora:

                    PlantillaCorrectoraExamenRpt respuestas = reportMng.GetPlantillaCorrectoraReport(Entity,
                                                                        empresa);

                    respuestas.SetParameterValue("Empresa", empresa.Name);
                    if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(respuestas.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                    ReportViewer.SetReport(respuestas);
                    ReportViewer.ShowDialog();

                    break;
            }
        }

        protected void ExportaPDF(ETipoPagina pagina, CompanyInfo empresa)
        {
            ISchemaInfo schema = AppContext.ActiveSchema;
            try
            {
                 schema = empresa as ISchemaInfo;
                 if (schema == null) schema = AppContext.ActiveSchema; 
            }
            catch 
            { 
            }
            ExamenReportMng reportMng = new ExamenReportMng(schema);
            string ruta = string.Empty;

            switch (pagina)
            {
                case ETipoPagina.Portada:

                    PortadaExamenRpt portada = reportMng.GetPortadaReport(Entity, empresa);
                    Dialogo.FileName = "portada.pdf";
                    Dialogo.ShowDialog();
                    ruta = Dialogo.FileName;
                    portada.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ruta);

                    break;

                case ETipoPagina.Preguntas:

                    ExamenTestRpt examen = reportMng.GetDetailTestReport(Entity, empresa, _preguntas);

                    Dialogo.FileName = "examen.pdf";
                    Dialogo.ShowDialog();
                    ruta = Dialogo.FileName;
                    examen.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ruta);

                    break;

                case ETipoPagina.Respuestas:

                    PlantillaRespuestasExamenRpt plantilla = reportMng.GetPlantillaRespuestasReport(Entity, empresa);

                    Dialogo.FileName = "plantilla.pdf";
                    Dialogo.ShowDialog();
                    ruta = Dialogo.FileName;
                    plantilla.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ruta);

                    break;

                case ETipoPagina.PlantillaCorrectora:

                    PlantillaCorrectoraExamenRpt respuestas = reportMng.GetPlantillaCorrectoraReport(Entity,
                        empresa);

                    Dialogo.FileName = "respuestas.pdf";
                    Dialogo.ShowDialog();
                    ruta = Dialogo.FileName;
                    respuestas.SetParameterValue("Empresa", empresa.Name);
                    if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(respuestas.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                    respuestas.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ruta);

                    break;
            }
        }

        private void ExportaDOC(CompanyInfo empresa)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            ExamenPrint examen = null;

            try
            {
                WordExporter.InitWordExporter();

                examen = Entity.GetPrintObject(empresa, string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            PgMng.Reset(_entity.PreguntaExamenes.Count + 7, 1, Resources.Messages.LOADING_DATA, this);
            
            try
            {
                Word.Document oDoc = WordExporter.NewDocument();
                PgMng.Grow();

                foreach (Word.Section wordSection in oDoc.Sections)
                {
                    wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
                  .Range.Text = empresa.Name;
                    wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary]
                  .Range.Borders.DistanceFromTop = 10;
                    wordSection.Footers[
                        Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.ShowFirstPageNumber = true;
                    wordSection.Range.ParagraphFormat.SpaceAfter = 0;
                    wordSection.Range.ParagraphFormat.SpaceBefore = 0;
                }
                PgMng.Grow();

                //Márgenes (1cm aprox.)
                oDoc.PageSetup.TopMargin = 15;
                oDoc.PageSetup.BottomMargin = 0;
                oDoc.PageSetup.LeftMargin = 30;
                oDoc.PageSetup.RightMargin = 30;

                //Tabla de encabezado
                Word.Table oTable;
                Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable = oDoc.Tables.Add(wrdRng, 5, 4, ref oMissing, ref oMissing);

                oTable.Range.ParagraphFormat.SpaceAfter = 6;
                oTable.Range.ParagraphFormat.SpaceBefore = 6;

                oTable.Columns[1].Cells.Merge();
                oTable.Borders.Enable = 1;
                oTable.Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;
                oTable.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;

                oTable.Columns[2].Cells[1].Merge(oTable.Columns[2].Cells[2]);

                oTable.Columns[1].Width = 108.44F;
                oTable.Columns[3].Width = 81.33F;
                oTable.Columns[4].Width = 81.33F;
                oTable.Columns[2].Width = 271.1F;

                oTable.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
                PgMng.Grow();

                string logo = CompanyInfo.GetLogoPath(empresa.Oid);
                if (!File.Exists(logo)) MessageBox.Show("No se ha encontrado la imagen: " + logo);
                else oTable.Cell(1, 1).Range.InlineShapes.AddPicture(logo, ref oMissing, ref oMissing, ref oMissing);
                oTable.Cell(1, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                PgMng.Grow();

                oTable.Cell(1, 2).Range.Text = "HOJA DE PREGUNTAS";
                oTable.Cell(1, 2).Range.Font.Bold = 1;
                oTable.Cell(1, 2).Range.Font.Size = 16;
                oTable.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[2].Cells[1].Range.Font.Name = "Arial";

                oTable.Columns[2].Cells[2].Range.Text = examen.Modulo;
                oTable.Columns[2].Cells[2].Range.Font.Bold = 1;
                oTable.Columns[2].Cells[2].Range.Font.Size = 11;
                oTable.Columns[2].Cells[2].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[2].Cells[2].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[2].Cells[2].Range.Font.Name = "Arial";

                oTable.Columns[2].Cells[3].Range.Text = "CURSO : " + examen.Promocion;
                oTable.Columns[2].Cells[3].Range.Font.Bold = 1;
                oTable.Columns[2].Cells[3].Range.Font.Size = 11;
                oTable.Columns[2].Cells[3].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[2].Cells[3].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[2].Cells[3].Range.Font.Name = "Arial";

                oTable.Columns[2].Cells[4].Range.Text =
                    "Deberá utilizar la plantilla que se le entregará para responder a las preguntas del examen.";
                oTable.Columns[2].Cells[4].Range.Font.Size = 11;
                oTable.Columns[2].Cells[4].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[2].Cells[4].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[2].Cells[4].Range.Font.Name = "Arial";

                oTable.Columns[3].Cells[1].Range.Text = "Nº EXAMEN";
                oTable.Columns[3].Cells[1].Range.Font.Bold = 1;
                oTable.Columns[3].Cells[1].Range.Font.Size = 11;
                oTable.Columns[3].Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[3].Cells[1].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[3].Cells[1].Range.Font.Name = "Arial";

                oTable.Columns[3].Cells[2].Range.Text = "FECHA";
                oTable.Columns[3].Cells[2].Range.Font.Bold = 1;
                oTable.Columns[3].Cells[2].Range.Font.Size = 11;
                oTable.Columns[3].Cells[2].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[3].Cells[2].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[3].Cells[2].Range.Font.Name = "Arial";

                oTable.Columns[3].Cells[3].Range.Text = "TIPO EXAMEN";
                oTable.Columns[3].Cells[3].Range.Font.Bold = 1;
                oTable.Columns[3].Cells[3].Range.Font.Size = 11;
                oTable.Columns[3].Cells[3].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[3].Cells[3].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[3].Cells[3].Range.Font.Name = "Arial";

                oTable.Columns[3].Cells[4].Range.Text = "Nº PREGUNTAS";
                oTable.Columns[3].Cells[4].Range.Font.Bold = 1;
                oTable.Columns[3].Cells[4].Range.Font.Size = 11;
                oTable.Columns[3].Cells[4].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[3].Cells[4].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[3].Cells[4].Range.Font.Name = "Arial";

                oTable.Columns[3].Cells[5].Range.Text = "TIEMPO";
                oTable.Columns[3].Cells[5].Range.Font.Bold = 1;
                oTable.Columns[3].Cells[5].Range.Font.Size = 11;
                oTable.Columns[3].Cells[5].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[3].Cells[5].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[3].Cells[5].Range.Font.Name = "Arial";

                oTable.Columns[4].Cells[1].Range.Text = examen.Numero.ToString().Trim();
                oTable.Columns[4].Cells[1].Range.Font.Size = 11;
                oTable.Columns[4].Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[4].Cells[1].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[4].Cells[1].Range.Font.Name = "Arial";

                oTable.Columns[4].Cells[2].Range.Text = examen.FechaExamen.ToShortDateString().Trim();
                oTable.Columns[4].Cells[2].Range.Font.Size = 11;
                oTable.Columns[4].Cells[2].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[4].Cells[2].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[4].Cells[2].Range.Font.Name = "Arial";

                oTable.Columns[4].Cells[3].Range.Text = examen.Tipo.Trim();
                oTable.Columns[4].Cells[3].Range.Font.Size = 11;
                oTable.Columns[4].Cells[3].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[4].Cells[3].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[4].Cells[3].Range.Font.Name = "Arial";

                oTable.Columns[4].Cells[4].Range.Text = examen.NPreguntas.ToString().Trim();
                oTable.Columns[4].Cells[4].Range.Font.Size = 11;
                oTable.Columns[4].Cells[4].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[4].Cells[4].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[4].Cells[4].Range.Font.Name = "Arial";

                oTable.Columns[4].Cells[5].Range.Font.Name = "Arial";
                oTable.Columns[4].Cells[5].Range.Font.Size = 11;
                oTable.Columns[4].Cells[5].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Columns[4].Cells[5].Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Columns[4].Cells[5].Range.Text = examen.Duracion.ToShortTimeString().Trim();
                PgMng.Grow();

                ////Add some text after the table.
                Word.Paragraph oParaAux;
                object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
                oParaAux.Range.Text = string.Empty;
                oParaAux.Range.InsertParagraph();

                //Nombre y apellidos
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = "NOMBRE Y APELLIDOS:";
                oPara1.Range.Font.Size = 12;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphBefore();

                //DNI/NIE, FIRMA
                Word.Paragraph oPara2;
                oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara2.Range.Text = "DNI/NIE:                                                           FIRMA:";
                oPara2.Range.Font.Size = 12;
                oPara2.Range.Font.Name = "Arial";
                oPara2.Range.InsertParagraphAfter();
                oPara2.Range.InsertParagraphBefore();
                PgMng.Grow();

                PreguntaList lista_preguntas = null;

                //Origen de las preguntas en función de si el examen está emitido o no
                if (_entity.Emitido)
                    lista_preguntas = PreguntaList.GetList(_entity.PreguntaExamenes);
                else
                    lista_preguntas = _preguntas;

                if (lista_preguntas != null)
                {
                    int i = 1;
                    PreguntaInfo item;

                    foreach (PreguntaExamenInfo pex in _entity.PreguntaExamenes)
                    {
                        item = lista_preguntas.GetItem(pex.OidPregunta);

                        //Para cada pregunta se inserta una tabla
                        wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        Word.Range newRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        int paginas_antes = (int)(oTable.Range.get_Information(
                            Word.WdInformation.wdNumberOfPagesInDocument));
                        oTable = oDoc.Tables.Add(wrdRng, 5, 3, ref oMissing, ref oMissing);

                        oTable.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightAuto;

                        oTable.Columns[1].Width = 30;
                        oTable.Cell(1, 1).Range.Text = i.ToString();
                        oTable.Cell(1, 1).Range.Font.Size = 10;
                        oTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        oTable.Cell(1, 1).Range.Font.Bold = 1;
                        oTable.Cell(1, 1).Range.Font.Name = "Arial";

                        oTable.Cell(1, 2).Merge(oTable.Columns[3].Cells[1]);
                        oTable.Cell(1, 2).BottomPadding = 8;
                        oTable.Cell(1, 2).Width = 510;
                        oTable.Cell(1, 2).Range.Text = item.Texto;
                        oTable.Cell(1, 2).Range.Font.Size = 10;
                        oTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                        oTable.Cell(1, 2).Range.Font.Bold = 1;
                        oTable.Cell(1, 2).Range.Font.Name = "Arial";

                        oTable.Cell(2, 2).Merge(oTable.Cell(2, 3));
                        oTable.Cell(2, 1).Merge(oTable.Cell(2, 2));
                        oTable.Cell(2, 1).Width = 540;

                        oTable.Cell(3, 2).Width = 20;
                        oTable.Cell(3, 2).Range.Text = "A";
                        oTable.Cell(3, 2).Range.Font.Size = 10;
                        oTable.Cell(3, 2).Range.Paragraphs.Alignment =
                            Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        oTable.Cell(3, 2).Range.Font.Name = "Arial";

                        oTable.Cell(4, 2).Width = 20;
                        oTable.Cell(4, 2).Range.Text = "B";
                        oTable.Cell(4, 2).Range.Font.Size = 10;
                        oTable.Cell(4, 2).Range.Paragraphs.Alignment =
                            Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        oTable.Cell(4, 2).Range.Font.Name = "Arial";

                        oTable.Cell(5, 2).Width = 20;
                        oTable.Cell(5, 2).Range.Text = "C";
                        oTable.Cell(5, 2).Range.Font.Size = 10;
                        oTable.Cell(5, 2).Range.Paragraphs.Alignment =
                            Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        oTable.Cell(5, 2).Range.Font.Name = "Arial";

                        foreach (RespuestaInfo obj in item.Respuestas)
                        {
                            switch (obj.Opcion)
                            {
                                case "A":
                                    {
                                        oTable.Cell(3, 3).Width = 490;
                                        oTable.Cell(3, 3).Range.Text = obj.Texto;
                                        oTable.Cell(3, 3).Range.Font.Size = 10;
                                        oTable.Cell(3, 3).Range.Paragraphs.Alignment =
                                            Word.WdParagraphAlignment.wdAlignParagraphJustify;
                                        oTable.Cell(3, 3).Range.Font.Name = "Arial";
                                        break;
                                    }
                                case "B":
                                    {
                                        oTable.Cell(4, 3).Width = 490;
                                        oTable.Cell(4, 3).Range.Text = obj.Texto;
                                        oTable.Cell(4, 3).Range.Font.Size = 10;
                                        oTable.Cell(4, 3).Range.Paragraphs.Alignment =
                                            Word.WdParagraphAlignment.wdAlignParagraphJustify;
                                        oTable.Cell(4, 3).Range.Font.Name = "Arial";
                                        break;
                                    }
                                case "C":
                                    {
                                        oTable.Cell(5, 3).Width = 490;
                                        oTable.Cell(5, 3).Range.Text = obj.Texto;
                                        oTable.Cell(5, 3).Range.Font.Size = 10;
                                        oTable.Cell(5, 3).Range.Paragraphs.Alignment =
                                            Word.WdParagraphAlignment.wdAlignParagraphJustify;
                                        oTable.Cell(5, 3).Range.Font.Name = "Arial";
                                        break;
                                    }
                            }
                        }

                        if (item.Imagen != string.Empty)
                        {
                            string path = _entity.Emitido ?
                                Library.Application.AppController.FOTOS_PREGUNTAS_EXAMEN_PATH + _entity.Oid.ToString("00000") + "\\" + item.Imagen :
                                item.ImagenWithPath;

                            if (File.Exists(path))
                            {
                                oTable.Cell(2, 1).Range.InlineShapes.AddPictureBullet(path, ref oMissing);
                                oTable.Cell(2, 1).VerticalAlignment =
                                    Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                oTable.Cell(2, 1).Range.Paragraphs.Alignment =
                                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            }
                            else
                            {
                                MessageBox.Show("No se ha encontrado la imagen: " + path);
                                oTable.Rows[2].Delete();
                            }
                        }
                        else
                            oTable.Rows[2].Delete();

                        ////Add some text after the table.
                        oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oParaAux = oDoc.Content.Paragraphs.Add(ref oRng);
                        oParaAux.Range.Text = string.Empty;
                        oParaAux.Range.InsertParagraph();

                        int paginas_despues = (int)(oParaAux.Range.get_Information(
                            Word.WdInformation.wdNumberOfPagesInDocument));
                        if (paginas_antes < paginas_despues)
                            newRng.InsertBreak(ref oMissing);

                        i++;
                    }
                    PgMng.Grow();
                    oDoc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdPromptToSaveChanges,
                                Microsoft.Office.Interop.Word.WdOriginalFormat.wdPromptUser,
                                true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            finally
            {
                WordExporter.Close();
                PgMng.FillUp();
            }
        }

        #endregion

        #region Action

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            this.Enabled = false;

            bool defecto = moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultBoolSetting();
            CompanyInfo empresa = null;

            if (defecto)
                empresa = CompanyInfo.Get(moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultOidSetting(), false);
            while (empresa == null)
            {
                moleQule.Face.Common.CompanySelectForm form = new Common.CompanySelectForm(this);
                DialogResult result = form.ShowDialog();

                try
                {
                    if (result == DialogResult.OK)
                        empresa = form.Selected as CompanyInfo;
                }
                catch
                { empresa = null; }
            }

            try
            {
                if (CReports_CkB.CheckState == CheckState.Checked)
                {
                    if (Portada_CB.Checked) ExportaCR(ETipoPagina.Portada, empresa);

                    if (Preguntas_CB.Checked) ExportaCR(ETipoPagina.Preguntas, empresa);

                    if (Respuestas_CB.Checked) ExportaCR(ETipoPagina.Respuestas, empresa);

                    if (Correctora_CB.Checked) ExportaCR(ETipoPagina.PlantillaCorrectora, empresa);
                }
                else if (PDF_CkB.CheckState == CheckState.Checked)
                {
                    if (Portada_CB.Checked) ExportaPDF(ETipoPagina.Portada, empresa);

                    if (Preguntas_CB.Checked) ExportaPDF(ETipoPagina.Preguntas, empresa);

                    if (Respuestas_CB.Checked) ExportaPDF(ETipoPagina.Respuestas, empresa);

                    if (Correctora_CB.Checked) ExportaPDF(ETipoPagina.PlantillaCorrectora, empresa);
                }
                else if (Doc_CkB.CheckState == CheckState.Checked)
                {
                    if (Portada_CB.Checked) ExportaCR(ETipoPagina.Portada, empresa);

                    if (Preguntas_CB.Checked) ExportaDOC(empresa);

                    if (Respuestas_CB.Checked) ExportaCR(ETipoPagina.Respuestas, empresa);

                    if (Correctora_CB.Checked) ExportaCR(ETipoPagina.PlantillaCorrectora, empresa);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.Enabled = true; }

            _action_result = DialogResult.Ignore;
            Close();
        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            Cerrar();
        }

        #endregion

    }
}