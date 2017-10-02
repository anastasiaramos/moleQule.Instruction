using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Alumno;

namespace moleQule.Face.Instruction
{
    public partial class MatriculasActionForm : ActionSkinForm
    {

        #region Atributes & Properties

        protected override int BarSteps { get { return base.BarSteps; } }

        public const string ID = "MatriculasActionForm";
        public static Type Type { get { return typeof(MatriculasActionForm); } }

        AlumnoInfo _alumno = null;
        PromocionInfo _promocion = null;

        #endregion

        #region Business Methods

        private string GetFilterValues()
        {
            string filtro = string.Empty;

            if (!TodosAlumno_CkB.Checked)
                filtro += "Cliente " + moleQule.Library.CslaEx.EnumText.GetOperator(moleQule.Library.CslaEx.Operation.Equal) + " " + _alumno.Nombre + "; ";

            if (!TodosPromocion_CkB.Checked)
                filtro += "Producto " + moleQule.Library.CslaEx.EnumText.GetOperator(moleQule.Library.CslaEx.Operation.Equal) + " " + _promocion.Nombre + "; ";

            return filtro;
        }

        #endregion

        #region Factory Methods

        public MatriculasActionForm()
            : this(true) { }

        public MatriculasActionForm(Form parent)
            : this(false, parent) { }

        public MatriculasActionForm(bool IsModal)
            : this(IsModal, null) { }

        public MatriculasActionForm(bool IsModal, Form parent)
            : base(IsModal, parent)
        {
            InitializeComponent();
            SetFormData();
        }

        #endregion

        #region Style & Source

        public override void RefreshSecondaryData()
        {
            ComboBoxList<EDocumentoAlumno> docs = moleQule.Library.Instruction.EnumText<EDocumentoAlumno>.GetList();

            foreach (ComboBoxSource item in docs)
                Documentos_CLB.Items.Add(item.Texto); 
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            AlumnoInfo alumno = TodosAlumno_CkB.Checked ? null : _alumno;
            PromocionInfo promocion = TodosPromocion_CkB.Checked ? null : _promocion;

            string filtro = GetFilterValues();

            AlumnoReportMng reportMng = new AlumnoReportMng(AppContext.ActiveSchema, string.Empty, filtro);

            AlumnoList alumnos = GetAlumnoList(alumno, promocion);
            PromocionList promos = GetPromocionList(promocion);

            if (Documentos_CLB.GetItemCheckState(0) == CheckState.Checked)
            {
                MatriculaPromocionRpt rpt = reportMng.GetMatriculaPromocionReport(alumnos, promos);

                if (rpt != null)
                {
                    ReportViewer.SetReport(rpt);
                    ReportViewer.ShowDialog();
                }
                else
                    MessageBox.Show(moleQule.Face.Resources.Messages.NO_DATA_REPORTS);
            }

            /*if (Documentos_CLB.GetItemCheckState(1) == CheckState.Checked)
            {
                MatriculaPromocionRpt rpt = reportMng.GetMatriculaPromocionReport(list, promocion);

                if (rpt != null)
                {
                    ReportViewer.SetReport(rpt);
                    ReportViewer.ShowDialog();
                }
                else
                    MessageBox.Show(moleQule.Face.Resources.Messages.NO_DATA_REPORTS);
            }*/

            if (Documentos_CLB.GetItemCheckState(2) == CheckState.Checked)
            {
                DocumentacionRpt rpt = reportMng.GetDocumentacionReport(alumnos, promos);

                if (rpt != null)
                {
                    ReportViewer.SetReport(rpt);
                    ReportViewer.ShowDialog();
                }
                else
                    MessageBox.Show(moleQule.Face.Resources.Messages.NO_DATA_REPORTS);
            }
            _action_result = DialogResult.OK;

        }

        protected AlumnoList GetAlumnoList(AlumnoInfo alumno, PromocionInfo promocion)
        {
            List<AlumnoInfo> alumnos = new List<AlumnoInfo>();
            AlumnoList list;

            if (alumno != null)
            {
                alumnos.Add(alumno);
                list = AlumnoList.GetList(alumnos);
            }
            else
            {
                if (promocion != null)
                    list = AlumnoList.GetListByPromocion(promocion.Oid, false);                
                else
                    list = AlumnoList.GetList(false);
            }

            return list;
        }
        
        protected PromocionList GetPromocionList(PromocionInfo promocion)
        {
            List<PromocionInfo> promociones = new List<PromocionInfo>();
            PromocionList list;

            if (promocion != null)
            {
                promociones.Add(promocion);
                list = PromocionList.GetList(promociones);
            }
            else
            {
                list = PromocionList.GetList(false);                
            }

            return list;
        }
                

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Events

        private void SanidadAnimalActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
            }

            Cerrar();
        }

        private void TodosCliente_CkB_CheckedChanged(object sender, EventArgs e)
        {
            Alumno_BT.Enabled = !TodosAlumno_CkB.Checked;
        }

        private void TodosProducto_CkB_CheckedChanged(object sender, EventArgs e)
        {
            Promocion_BT.Enabled = !TodosPromocion_CkB.Checked;
        }

        #endregion

        #region Buttons

        private void Cliente_BT_Click(object sender, EventArgs e)
        {
            AlumnoSelectForm form = new AlumnoSelectForm(this);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _alumno = form.Selected as AlumnoInfo;
                Alumno_TB.Text = _alumno.Nombre;
            }
        }

        private void Producto_BT_Click(object sender, EventArgs e)
        {
            PromocionSelectForm form = new PromocionSelectForm(this);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _promocion = form.Selected as PromocionInfo;
                Promocion_TB.Text = _promocion.Nombre;
            }
        }

        private void Serie_BT_Click(object sender, EventArgs e)
        {
        /*    SerieSelectForm form = new SerieSelectForm(this);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _serie = form.Selected as SerieInfo;
                Serie_TB.Text = _serie.Nombre;
            }*/
        }

        #endregion

    }
}

