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
    public partial class MaterialViewForm : MaterialForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private MaterialDocenteInfo _entity;

        public override MaterialDocenteInfo EntityInfo { get { return _entity; } }


        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private MaterialViewForm() : this(-1) { }

        public MaterialViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.MATERIAL_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = MaterialDocenteInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            base.FormatControls();
        }

        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;

            Datos_Alumnos.DataSource = _entity.Alumnos;

            Datos_Revisiones.DataSource = _entity.Revisiones;

            PgMng.Grow();
        }

        public override void RefreshSecondaryData()
        {
            base.RefreshSecondaryData();
            PgMng.Grow();

            if (EntityInfo.OidCurso != 0)
                Tipo_CB.SelectedIndex = Datos_Tipo.IndexOf(_combo_tipo.Buscar(1));
            else
                Tipo_CB.SelectedIndex = Datos_Tipo.IndexOf(_combo_tipo.Buscar(2));
            PgMng.Grow();
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            //switch (gridName)
            //{
            //    case "Alumnos_Grid":
            //        {
            //            foreach (DataGridViewRow row in Alumnos_Grid.Rows)
            //            {
            //                if (row.IsNewRow) continue;
            //                Material_AlumnoInfo info = (Material_AlumnoInfo)row.DataBoundItem;
            //                if (info != null)
            //                {
            //                    AlumnoInfo alumno = _alumnos.GetItem(info.OidAlumno);
            //                    if (alumno != null)
            //                        row.Cells["Promocion_CBC"].Value = alumno.OidPromocion;
            //                }
            //            }
            //        } break;
            //}
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Tipo_CB":
                    {
                        if (Datos_Tipo.Current != null)
                        {
                            if (((ComboBoxSource)Tipo_CB.SelectedItem).Oid == 1)
                            {
                                long oid = EntityInfo.OidCurso;
                                CursoList cursos = CursoList.GetList(false);
                                Library.Instruction.HComboBoxSourceList _combo_cursos = new Library.Instruction.HComboBoxSourceList(cursos);
                                Datos_Curso.DataSource = _combo_cursos;
                                Nombre_CB.SelectedIndex = Datos_Curso.IndexOf(_combo_cursos.Buscar(oid));
                            }
                            if (((ComboBoxSource)Tipo_CB.SelectedItem).Oid == 2)
                            {
                                long oid = EntityInfo.OidModulo;
                                ModuloList modulos = ModuloList.GetList(false);
                                Library.Instruction.HComboBoxSourceList _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);
                                Datos_Curso.DataSource = _combo_modulos;
                                Nombre_CB.SelectedIndex = Datos_Curso.IndexOf(_combo_modulos.Buscar(oid));
                            }
                        }
                    } break;
            }
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion
    }

}
