using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Instruction; 


namespace moleQule.Face.Instruction
{
    public partial class CursoUIForm : CursoForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Curso _entity;

        public override Curso Entity { get { return _entity; } set { _entity = value; } }
        public override CursoInfo EntityInfo
        {
            get
            {
                return (_entity != null) ? _entity.GetInfo(false) : null;
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected CursoUIForm() : this(-1, true) { }

        public CursoUIForm(bool isModal) : this(-1, isModal) { }

        public CursoUIForm(long oid) : this(oid, true) { }

        public CursoUIForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {
                this.Datos.RaiseListChangedEvents = false;

                Curso temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }
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

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            base.RefreshMainData();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        public override void RefreshSecondaryData()
        {
            Datos_Convocatorias.DataSource = _entity.Convocatorias;
            PgMng.Grow();
        }

        #endregion

        #region Validation & Format
 
        #endregion

        #region Print

        //public override void PrintData(long entidad, PrintSource source, PrintType type)
        //{
        //    switch (entidad)
        //    {
        //        case Entidad.Red:
        //            {
        //                CursoReportMng rptMng = new CursoReportMng(AppContext.ActiveSchema);
        //                List<RedInfo> list = new List<RedInfo>();

        //                switch (source)
        //                {
        //                    case PrintSource.All:
        //                        {
        //                            foreach (DataGridViewRow row in Redes_Grid.Rows)
        //                                if (!row.IsNewRow)
        //                                    list.Add(((Red)(row.DataBoundItem)).GetInfo());

        //                        } break;

        //                    case PrintSource.Selection:
        //                        {
        //                            foreach (DataGridViewRow row in Redes_Grid.SelectedRows)
        //                                list.Add(((Red)(row.DataBoundItem)).GetInfo());

        //                        } break;
        //                }

        //                if (list.Count == 0) return;

        //                ReportViewer.SetReport(rptMng.GetRedListReport(EntityInfo,
        //                                                                RedList.GetChildList(list),
        //                                                                _Alumnos));

        //            } break;
        //    }

        //    ReportViewer.ShowDialog();
        //}

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void SelectAlumnos()
        {
            if (Datos_Convocatorias.Current == null) return;

            Convocatoria_Curso item = Datos_Convocatorias.Current as Convocatoria_Curso;
            Datos_Alumnos_Convocatorias.DataSource = item.Alumnos;
        }

        protected void EditarConvocatoriaAction()
        {
            if (Datos_Convocatorias.Current == null) return;

            ConvocatoriaEditForm form = new ConvocatoriaEditForm(_entity, (Convocatoria_Curso)Datos_Convocatorias.Current, true);
            form.ShowDialog();
            PgMng.FillUp();
            SelectAlumnos();
        }
        
        #endregion

        #region Buttons

        private void Add_BT_Click(object sender, EventArgs e)
        {
            ConvocatoriaAddForm add_form = new ConvocatoriaAddForm(_entity);
            add_form.ShowDialog();
            PgMng.FillUp();
            SelectAlumnos();
        }

        private void Edit_BT_Click(object sender, EventArgs e)
        {
            EditarConvocatoriaAction();
        }

        private void Delete_BT_Click(object sender, EventArgs e)
        {
            if (Datos_Convocatorias.Current == null) return;

            //if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
            //                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
            //                    MessageBoxButtons.YesNoCancel,
            //                    MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                _entity.Convocatorias.Remove((Convocatoria_Curso)Datos_Convocatorias.Current);
                SelectAlumnos();
            //}
        }

        private void Convocatorias_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarConvocatoriaAction();
        }

        #endregion


    }
}

