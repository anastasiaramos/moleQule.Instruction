using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Alumno;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class AlumnoMngForm : AlumnoMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "AlumnoMngForm";
        public static Type Type { get { return typeof(AlumnoMngForm); } }
        public override Type EntityType { get { return typeof(Alumno); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected Alumno _entity;

        #endregion

        #region Factory Methods

        public AlumnoMngForm() : this(false, null) { }

        public AlumnoMngForm(Form parent) : this(false, parent) { }

        public AlumnoMngForm(bool isModal, Form parent) : this(isModal, parent, null) { }

        public AlumnoMngForm(bool isModal, Form parent, AlumnoList list)
            : base(isModal, parent, list)
        {
            InitializeComponent();
            SetView(molView.Normal);
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            SetMainDataGridView(Tabla);
            Datos.DataSource = AlumnoList.NewList().GetSortedList();
            SortProperty = Codigo.DataPropertyName;

            this.Text = Resources.Labels.ALUMNOS;
        }

        #endregion

        #region Layout

        public override void FitColumns()
		{
			List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
			Nombre.Tag = 0.2;
            Apellidos.Tag = 0.2;
			Observaciones.Tag = 0.6;

			cols.Add(Nombre);
            cols.Add(Apellidos);
			cols.Add(Observaciones);

			ControlsMng.MaximizeColumns(Tabla, cols);
		}

		public override void FormatControls()
		{
			base.FormatControls();
		}

		#endregion

        #region Style & Source
        
        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "Alumno");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = AlumnoList.GetList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }

            PgMng.Grow(string.Empty, "Lista de Alumnos");
        }

        public override void UpdateList()
        {
            switch (_current_action)
            {
                case molAction.Add:
                    if (_entity == null) return;
                    List.AddItem(_entity.GetInfo(false));
                    if (FilterType == IFilterType.Filter)
                    {
                        AlumnoList listA = AlumnoList.GetList(_filter_results);
                        listA.AddItem(_entity.GetInfo(false));
                        _filter_results = listA.GetSortedList();
                    }
                    break;

                case molAction.Edit:
                case molAction.Lock:
                case molAction.Unlock:
                    if (_entity == null) return;
                    ActiveItem.CopyFrom(_entity);
                    break;

                case molAction.Delete:
                    if (ActiveItem == null) return;
                    List.RemoveItem(ActiveOID);
                    if (FilterType == IFilterType.Filter)
                    {
                        AlumnoList listD = AlumnoList.GetList(_filter_results);
                        listD.RemoveItem(ActiveOID);
                        _filter_results = listD.GetSortedList();
                    }
                    break;
            }

            _entity = null;
            RefreshSources();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Abre el formulario para añadir item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenAddForm()
        {
            try
            {
                AlumnoAddForm form = new AlumnoAddForm();
                AddForm(form);
                _entity = form.Entity;
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Abre el formulario para ver item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenViewForm()
        {
            try
            {
                AddForm(new AlumnoViewForm(ActiveOID));
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenEditForm()
        {
            try
            {
                AlumnoEditForm form = new AlumnoEditForm(ActiveOID);
                if (form.Entity != null)
                {
                    AddForm(form);
                    _entity = form.Entity;
                }
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Abre el formulario para borrar item
        /// <returns>void</returns>
        /// </summary>
        public override void DeleteObject(long oid)
        {
            //if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
            //                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
            //                    MessageBoxButtons.YesNoCancel,
            //                    MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                try
                {
                    AlumnoInfo alumno = AlumnoInfo.Get(oid, true);
                    if (alumno.AlumnoPartes.Count > 0)
                    {
                        foreach (Alumno_ParteInfo item in alumno.AlumnoPartes)
                        {
                            if (item.Falta || item.Retraso)
                            {
                                MessageBox.Show(Resources.Messages.ALUMNO_CON_PARTES_DE_FALTAS);
                                _action_result = DialogResult.Ignore;
                                return;
                            }
                        }
                    }
                    if (alumno.AlumnosPracticas.Count > 0)
                    {
                        foreach (Alumno_PracticaInfo item in alumno.AlumnosPracticas)
                        {
                            if (item.Calificacion != "SIN CALIFICAR")
                            {
                                MessageBox.Show(Resources.Messages.ALUMNO_CON_PRACTICAS);
                                _action_result = DialogResult.Ignore;
                                return;
                            }
                        }
                    }
                    if (alumno.AlumnoExamens.Count > 0)
                    {
                        MessageBox.Show(Resources.Messages.ALUMNO_CON_EXAMENES);
                        _action_result = DialogResult.Ignore;
                        return;
                    }

                    //Se elimina la foto					
                    Images.Delete(List.GetItem(oid).Foto, AppController.FOTOS_ALUMNOS_PATH);

                    Alumno.Delete(oid);
                    _action_result = DialogResult.OK;

                    //Se eliminan todos los formularios de ese objeto
                    foreach (ItemMngBaseForm form in _list_active_form)
                    {
                        if (form.Oid == oid)
                        {
                            form.Dispose();
                            break;
                        }
                    }
                }
                catch (Csla.DataPortalException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
                }
            //}
        }

        /// <summary>Duplica un objeto y abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void DuplicateObject(long oid)
        {
            try
            {
                Alumno old = Alumno.Get(oid);
                Alumno dup = old.CloneAsNew();
                old.CloseSession();
                dup.Foto = string.Empty;

                AddForm(new AlumnoAddForm(dup));
            }
            catch (iQException ex)
            {
                MessageBox.Show(ex.Message,
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message,
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

            RefreshList();
        }

        /// <summary>Imprime la lista del objetos
        /// <returns>void</returns>
        /// </summary>
        public override void PrintList()
        {
            /*AlumnoReportMng reportMng = new AlumnoReportMng(AppContext.ActiveSchema);
			
            AlumnoListRpt report = reportMng.GetListReport(list);
			
            if (report != null)
            {
                ReportViewer.SetReport(report);
                ReportViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }*/
        }

        #endregion

    }

    public partial class AlumnoMngBaseForm : Skin06.EntityMngSkinForm<AlumnoList, AlumnoInfo>
    {
        public AlumnoMngBaseForm()
            : this(false, null, null) { }

        public AlumnoMngBaseForm(bool isModal, Form parent, AlumnoList lista)
            : base(isModal, parent, lista) { }
    }
}
