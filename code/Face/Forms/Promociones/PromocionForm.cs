using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;
using moleQule.Face.Common;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PromocionForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 14; } }

        private PlanEstudiosList _planes = null;
        private PlanExtraList _planes_extra = null;
        protected AlumnoList _alumnos = null;
        protected CronogramaInfo _cronograma = null;

        public virtual Promocion Entity { get { return null; } set { } }
        public virtual PromocionInfo EntityInfo { get { return null; } }

        public virtual Alumno CurrentAlumno
        {
            get
            {
                return Datos_Alumnos.Current != null ? (Alumno)(Datos_Alumnos.Current) : null;
            }
        }

        #endregion

        #region Factory Methods

        public PromocionForm() : this(-1, true) { }

        public PromocionForm(bool isModal) : this(-1, isModal) { }

        public PromocionForm(long oid) : this(oid, true) { }

        public PromocionForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            List<string> visibles = new List<string>();

            visibles.Add(NExpediente.Name);
            visibles.Add(Nombre.Name);
            visibles.Add(Ident.Name);

            ControlTools.ShowDataGridColumns(Alumnos_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Alumnos_Grid.Width - vs.Width
                                                - Alumnos_Grid.RowHeadersWidth
                                                - Alumnos_Grid.Columns[NExpediente.Name].Width
                                                - Alumnos_Grid.Columns[Ident.Name].Width);

            Alumnos_Grid.Columns[Nombre.Name].Width = (int)(rowWidth * 0.995);
        }

        public override void RefreshSecondaryData()
        {
            moleQule.Library.HComboBoxSourceList lista_horas = new moleQule.Library.HComboBoxSourceList();

            lista_horas.Add(new ComboBoxSource(1, "08:00"));
            lista_horas.Add(new ComboBoxSource(2, "09:00"));
            lista_horas.Add(new ComboBoxSource(3, "10:00"));
            lista_horas.Add(new ComboBoxSource(4, "11:00"));
            lista_horas.Add(new ComboBoxSource(5, "12:00"));
            lista_horas.Add(new ComboBoxSource(6, "13:00"));
            lista_horas.Add(new ComboBoxSource(7, "14:00"));
            lista_horas.Add(new ComboBoxSource(8, "15:00"));
            lista_horas.Add(new ComboBoxSource(9, "16:00"));
            lista_horas.Add(new ComboBoxSource(10, "17:00"));
            lista_horas.Add(new ComboBoxSource(11, "18:00"));
            lista_horas.Add(new ComboBoxSource(12, "19:00"));
            lista_horas.Add(new ComboBoxSource(13, "20:00"));
            lista_horas.Add(new ComboBoxSource(14, "21:00"));

            Datos_Horas.DataSource = lista_horas;

            _planes = PlanEstudiosList.GetList(false);
            moleQule.Library.Instruction.HComboBoxSourceList combo_planes = new moleQule.Library.Instruction.HComboBoxSourceList(_planes);
            Datos_Planes.DataSource = combo_planes;
            PgMng.Grow();

            _planes_extra = PlanExtraList.GetList(false);
            moleQule.Library.Instruction.HComboBoxSourceList combo_planes_extra = new moleQule.Library.Instruction.HComboBoxSourceList(_planes_extra);
            Datos_Extra.DataSource = combo_planes_extra;

            PgMng.Grow();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos_Alumnos.DataSource = AlumnoList.GetListByPromocion(EntityInfo.Oid, false);
            PgMng.FillUp();
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Semana_GB":
                    {
                        CLB_1.Items[0] = "8:00 - 9:00";
                        CLB_1.Items[1] = "9:00 - 10:00";
                        CLB_1.Items[2] = "10:00 - 11:00";
                        CLB_1.Items[3] = "11:00 - 12:00";
                        CLB_1.Items[4] = "12:00 - 13:00";
                        CLB_1.Items[5] = "13:00 - 14:00";
                        CLB_1.Items[6] = "14:00 - 15:00";
                        CLB_1.Items[7] = "15:00 - 16:00";
                        CLB_2.Items[0] = "16:00 - 17:00";
                        CLB_2.Items[1] = "17:00 - 18:00";
                        CLB_2.Items[2] = "18:00 - 19:00";
                        CLB_2.Items[3] = "19:00 - 20:00";
                        CLB_2.Items[4] = "20:00 - 21:00";
                        CLB_2.Items[5] = "21:00 - 22:00";

                        CLB_1.SetItemChecked(0, EntityInfo.H8AM);
                        CLB_1.SetItemChecked(1, EntityInfo.H0);
                        CLB_1.SetItemChecked(2, EntityInfo.H1);
                        CLB_1.SetItemChecked(3, EntityInfo.H2);
                        CLB_1.SetItemChecked(4, EntityInfo.H3);
                        CLB_1.SetItemChecked(5, EntityInfo.H4);
                        CLB_1.SetItemChecked(6, EntityInfo.H5);
                        CLB_1.SetItemChecked(7, EntityInfo.H6);
                        CLB_2.SetItemChecked(0, EntityInfo.H7);
                        CLB_2.SetItemChecked(1, EntityInfo.H8);
                        CLB_2.SetItemChecked(2, EntityInfo.H9);
                        CLB_2.SetItemChecked(3, EntityInfo.H10);
                        CLB_2.SetItemChecked(4, EntityInfo.H11);
                        CLB_2.SetItemChecked(5, EntityInfo.H12);
                    } break;
                case "Sabado_GB":
                    {
                        CLB_3.Items[0] = "9:00 - 10:00";
                        CLB_3.Items[1] = "10:00 - 11:00";
                        CLB_3.Items[2] = "11:00 - 12:00";
                        CLB_3.Items[3] = "12:00 - 13:00";
                        CLB_3.Items[4] = "13:00 - 14:00";

                        CLB_3.SetItemChecked(0, EntityInfo.HS0);
                        CLB_3.SetItemChecked(1, EntityInfo.HS1);
                        CLB_3.SetItemChecked(2, EntityInfo.HS2);
                        CLB_3.SetItemChecked(3, EntityInfo.HS3);
                        CLB_3.SetItemChecked(4, EntityInfo.HS4);
                    } break;
            }
        }


        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Alumnos_Grid":
                    {
                        foreach (DataGridViewRow row in Alumnos_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            AlumnoInfo info = (AlumnoInfo)row.DataBoundItem;
                            if (info != null)
                                row.Cells["Nombre"].Value = info.Apellidos + ", " + info.Nombre;
                        }

                    } break;
            }
        }

        protected virtual void EditPlanExtraAction() { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //    ClienteReportMng reportMng = new ClienteReportMng(AppContext.ActiveSchema);
        //    ReportViewer.SetReport(reportMng.GetPromocionReport(EntityInfo, _proveedores.GetItem(EntityInfo.ProveedorN)));
        //    ReportViewer.ShowDialog();
        //}

        #endregion

        #region Actions

        protected virtual void EditarAlumnoAction() { }

        #endregion

        #region Buttons

        private void Clases_BT_Click(object sender, EventArgs e)
        {
            SelectEnumInputForm form = new SelectEnumInputForm(true);

            form.SetDataSource(Library.Instruction.EnumText<ETipoListadoClases>.GetList(false, false, true));

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ComboBoxSource combo = form.Selected as ComboBoxSource;
                ETipoListadoClases tipo = (ETipoListadoClases)combo.Oid;

                switch (tipo)
                {
                    case ETipoListadoClases.Todas:
                        {
                            ClasesOrdenadasViewForm cform = new ClasesOrdenadasViewForm(EntityInfo.OidPlan);
                            EntityMngForm mng = new EntityMngForm();
                            mng.AddForm(cform);
                        }
                        break;
                    case ETipoListadoClases.Restantes:
                        {
                            RestantesOrdenadasViewForm cform = new RestantesOrdenadasViewForm(EntityInfo.OidPlan, EntityInfo.Oid);
                            EntityMngForm mng = new EntityMngForm();
                            mng.AddForm(cform);
                        }
                        break;
                    case ETipoListadoClases.TeoricasImpartidas:
                        {
                            ClaseTeoricaList lista = null;
                            PgMng.Reset(2, 1, Resources.Messages.LOADING_DATA, this);
                            try
                            {
                                PgMng.Grow();
                                lista = ClaseTeoricaList.GetProgramadasList(EntityInfo.OidPlan,
                                    EntityInfo.Oid);

                            }
                            finally
                            {
                                PgMng.FillUp();
                            }

                            if (lista != null && lista.Count > 0)
                            {
                                ClasesTeoricasProgramadasForm cform = new ClasesTeoricasProgramadasForm(true, this, lista, EntityInfo);
                                cform.ShowDialog();
                            }

                        }
                        break;
                    case ETipoListadoClases.TeoricasNoImpartidas:
                        {
                            ClaseTeoricaList lista = null;
                            PgMng.Reset(2, 1, Resources.Messages.LOADING_DATA, this);
                            try
                            {
                                PgMng.Grow();
                                lista = ClaseTeoricaList.GetNoImpartidasList(EntityInfo.OidPlan, EntityInfo.OidPlanExtra, 
                                    EntityInfo.Oid);

                            }
                            finally
                            {
                                PgMng.FillUp();
                            }

                            if (lista != null && lista.Count > 0)
                            {
                                ClasesTeoricasDisponiblesForm cform = new ClasesTeoricasDisponiblesForm(true, this, lista, EntityInfo);
                                cform.ShowDialog();
                            }

                        }
                        break;
                    case ETipoListadoClases.PracticasImpartidas:
                        {
                            ClasePracticaList lista = null;
                            PgMng.Reset(2, 1, Resources.Messages.LOADING_DATA, this);
                            try
                            {
                                PgMng.Grow();
                                lista = ClasePracticaList.GetProgramadasList(EntityInfo.OidPlan,
                                    EntityInfo.Oid);

                            }
                            finally
                            {
                                PgMng.FillUp();
                            }

                            if (lista != null && lista.Count > 0)
                            {
                                ClasesPracticasProgramadasForm cform = new ClasesPracticasProgramadasForm(true, this, lista, EntityInfo);
                                cform.ShowDialog();
                            }

                        }
                        break;
                    case ETipoListadoClases.PracticasNoImpartidas:
                        {
                            ClasePracticaList lista = null;
                            PgMng.Reset(2, 1, Resources.Messages.LOADING_DATA, this);
                            try
                            {
                                PgMng.Grow();
                                lista = ClasePracticaList.GetNoImpartidasList(EntityInfo.OidPlan,
                                    EntityInfo.Oid);

                            }
                            finally
                            {
                                PgMng.FillUp();
                            }

                            if (lista != null && lista.Count > 0)
                            {
                                ClasesPracticasDisponiblesForm cform = new ClasesPracticasDisponiblesForm(true, this, lista, EntityInfo);
                                cform.ShowDialog();
                            }

                        }
                        break;
                    case ETipoListadoClases.TodasCronograma:
                        {
                            GeneraCronogramaAction(false);
                        }
                        break;
                    case ETipoListadoClases.RestantesCronograma:
                        {
                            GeneraCronogramaAction(false, true);
                        }
                        break;
                    case ETipoListadoClases.ComparativaCronograma:
                        {
                            GeneraCronogramaAction(true);
                        }
                        break;
                }
            }
        }

        private int DoGeneraCronograma(bool comparativa, DateTime fecha_fin, bool restantes = false)
        {
            int clases_dia = 0;
            int clases_sabado = 0;
            int total_dias = 5;
            PgMng.Grow();

            List<bool> activas_dia = new List<bool>();

            if (CLB_1.CheckedIndices.Contains(0))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_1.CheckedIndices.Contains(1))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_1.CheckedIndices.Contains(2))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_1.CheckedIndices.Contains(3))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_1.CheckedIndices.Contains(4))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_1.CheckedIndices.Contains(5))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_1.CheckedIndices.Contains(6))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_1.CheckedIndices.Contains(7))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_2.CheckedIndices.Contains(0))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_2.CheckedIndices.Contains(1))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_2.CheckedIndices.Contains(2))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_2.CheckedIndices.Contains(3))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_2.CheckedIndices.Contains(4))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            if (CLB_2.CheckedIndices.Contains(5))
            {
                clases_dia++;
                activas_dia.Add(true);
            }
            else
            {
                activas_dia.Add(false);
            }
            PgMng.Grow();

            List<bool> activas_sabado = new List<bool>();

            if (CLB_3.CheckedIndices.Contains(0))
            {
                clases_sabado++;
                activas_sabado.Add(true);
            }
            else
            {
                activas_sabado.Add(false);
            }
            if (CLB_3.CheckedIndices.Contains(1))
            {
                clases_sabado++;
                activas_sabado.Add(true);
            }
            else
            {
                activas_sabado.Add(false);
            }
            if (CLB_3.CheckedIndices.Contains(2))
            {
                clases_sabado++;
                activas_sabado.Add(true);
            }
            else
            {
                activas_sabado.Add(false);
            }
            if (CLB_3.CheckedIndices.Contains(3))
            {
                clases_sabado++;
                activas_sabado.Add(true);
            }
            else
            {
                activas_sabado.Add(false);
            }
            if (CLB_3.CheckedIndices.Contains(4))
            {
                clases_sabado++;
                activas_sabado.Add(true);
            }
            else
            {
                activas_sabado.Add(false);
            }
            PgMng.Grow();

            if (clases_sabado > 0) total_dias = 6;

            _cronograma = Cronograma.GeneraCronograma(EntityInfo, clases_dia, clases_sabado, total_dias, activas_dia, activas_sabado, fecha_fin, restantes);
                
            PgMng.Grow();

            return total_dias;
        }

        private void GeneraCronogramaAction(bool comparativa, bool restantes = false)
        {
            if (!comparativa)
            {
                PgMng.Reset(10, 1, Resources.Messages.GENERANDO_CRONOGRAMA, this);

                try
                {
                    int total_dias = DoGeneraCronograma(false, DateTime.MaxValue, restantes);

                    if (_cronograma != null && _cronograma.Sesiones != null && _cronograma.Sesiones.Count > 0)
                    {
                        ClasesRestantesCronogramaMngForm cform = new ClasesRestantesCronogramaMngForm(true, this, _cronograma, total_dias);
                        cform.ShowDialog();
                    }
                }
                catch { }
                finally { PgMng.FillUp(); }
            }
            else
            {
                DateSelectForm form = new DateSelectForm(EntityInfo, true, this);
                form.ShowDialog();

                if (form.ActionResult == DialogResult.OK)
                {
                    PgMng.Reset(10, 1, Resources.Messages.GENERANDO_CRONOGRAMA, this);


                    try
                    {
                        DoGeneraCronograma(true, form.Fecha);

                        if (_cronograma != null && _cronograma.Sesiones != null && _cronograma.Sesiones.Count > 0)
                        {
                            CronogramaReportMng reportMng = new CronogramaReportMng(AppContext.ActiveSchema);

                            List<RegistroResumenPlanDocente> teoricas = RegistroResumenPlanDocente.GetComparativaTeoricasCronogramaHorarios(_cronograma, form.Fecha);

                            if (teoricas.Count > 0)
                            {
                                ReportViewer.SetReport(reportMng.GetComparativaClases(EntityInfo, form.Fecha, teoricas));
                                ReportViewer.ShowDialog();
                            }

                            List<RegistroResumenPlanDocente> practicas1 = RegistroResumenPlanDocente.GetComparativaPracticasCronogramaHorarios(_cronograma, form.Fecha, 1);

                            if (practicas1.Count > 0)
                            {
                                ReportViewer.SetReport(reportMng.GetComparativaClases(EntityInfo, form.Fecha, practicas1, 1));
                                ReportViewer.ShowDialog();
                            }

                            List<RegistroResumenPlanDocente> practicas2 = RegistroResumenPlanDocente.GetComparativaPracticasCronogramaHorarios(_cronograma, form.Fecha, 2);

                            if (practicas2.Count > 0)
                            {
                                ReportViewer.SetReport(reportMng.GetComparativaClases(EntityInfo, form.Fecha, practicas2, 2));
                                ReportViewer.ShowDialog();
                            }
                        }
                    }
                    catch { }
                    finally { PgMng.FillUp(); }
                }
            }
        }

        //protected override void PrintAction()
        //{
        //    switch (TabControl.SelectedTab.Name)
        //    {
        //        case "General_TP":
        //            {
        //                PrintObject();
        //            } break;

        //        default:
        //            {
        //                PrintSelectSkinForm psform = new PrintSelectSkinForm(true);
        //                psform.EnableDetail(false);
        //                psform.ShowDialog();
        //                if (psform.DialogResult == DialogResult.Cancel) return;

        //                switch (TabControl.SelectedTab.Name)
        //                {
        //                    case "Alumnos_TP":
        //                        {
        //                            PrintData(Entidad.Historia, psform.Source, psform.Type);
        //                        } break;

        //                }
        //            } break;
        //    }
        //}

        #endregion

        #region Events

        private void Alumnos_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Alumnos_Grid.Name);
            Alumnos_Grid.Enabled = true;
        }

        private void Alumnos_Grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                EditarAlumnoAction();
        }

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Semana_GB.Name);
            SetDependentControlSource(Sabado_GB.Name);
        }
        
        private void Sesiones_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void PlanExtra_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditPlanExtraAction();
        }

        #endregion





    }
}
