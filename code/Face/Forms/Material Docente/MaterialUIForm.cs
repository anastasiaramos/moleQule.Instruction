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
    public partial class MaterialUIForm : MaterialForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected MaterialDocente _entity;

        public override MaterialDocente Entity { get { return _entity; } set { _entity = value; } }
        public override MaterialDocenteInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected MaterialUIForm() : this(-1, true) { }

        public MaterialUIForm(bool isModal) : this(-1, isModal) { }

        public MaterialUIForm(long oid) : this(oid, true) { }

        public MaterialUIForm(long oid, bool ismodal)
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

                if (AlumnosRepetidos())
                {
                    MessageBox.Show("No se puede entregar más de una vez el mismo material al mismo alumno.");
                    return false;
                }

                MaterialDocente temp = _entity.Clone();
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

        public override void FormatControls()
        {
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

            if (Entity.OidCurso != 0)
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
            //                SetCellsDataSource(Alumnos_Grid.Name);
            //                if (row.IsNewRow) continue;
            //                Material_Alumno info = (Material_Alumno)row.DataBoundItem;
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
                                long oid = Entity.OidCurso;
                                CursoList cursos = CursoList.GetList(false);
                                Library.Instruction.HComboBoxSourceList _combo_cursos = new Library.Instruction.HComboBoxSourceList(cursos);
                                Datos_Curso.DataSource = _combo_cursos;
                                Nombre_CB.SelectedIndex = Datos_Curso.IndexOf(_combo_cursos.Buscar(oid));
                            }
                            if (((ComboBoxSource)Tipo_CB.SelectedItem).Oid == 2)
                            {
                                long oid = Entity.OidModulo;
                                ModuloList modulos = ModuloList.GetList(false);
                                Library.Instruction.HComboBoxSourceList _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);
                                Datos_Curso.DataSource = _combo_modulos;
                                Nombre_CB.SelectedIndex = Datos_Curso.IndexOf(_combo_modulos.Buscar(oid));
                            }
                        }
                    } break;
                case "Nombre_CB":
                    {
                        if (Nombre_CB.SelectedItem != null)
                        {
                            if (((ComboBoxSource)Tipo_CB.SelectedItem).Oid == 1)
                            {
                                Entity.OidModulo = 0;
                                Entity.OidCurso = ((ComboBoxSource)Nombre_CB.SelectedItem).Oid;
                            }
                            else
                            {
                                Entity.OidCurso = 0;
                                Entity.OidModulo = ((ComboBoxSource)Nombre_CB.SelectedItem).Oid;
                            }
                        }
                    } break;
            }
        }

        private bool AlumnosRepetidos()
        {
            for (int i = 0; i < _entity.Alumnos.Count-1; i++)
            {
                for (int j = i+1; j<_entity.Alumnos.Count;j++)
                {
                    if (_entity.Alumnos[i].OidAlumno == _entity.Alumnos[j].OidAlumno)
                        return true;
                }
            }
            return false;
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            if (_entity.Curso == string.Empty)
            {
                CursoInfo curso = CursoInfo.Get(_entity.OidCurso, false);
                if (curso != null)
                    _entity.Curso = curso.Nombre;
            }

            if (_entity.Modulo == string.Empty)
            {
                ModuloInfo modulo = ModuloInfo.Get(_entity.OidModulo, false);
                if (modulo != null)
                    _entity.Modulo = modulo.Texto;
            }

            if (Revisiones_Grid.Rows.Count == 0)
            {
                MessageBox.Show("Para dar de alta un material debe añadir al menos una versión del mismo");
                _action_result = DialogResult.Ignore;
                return;
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void NuevaRevision()
        {
            EntityMngForm mng = new EntityMngForm();
            mng.AddForm(new RevisionAddForm(Entity));

            Datos_Revisiones.ResetBindings(false);
        }

        protected override void EditarRevision()
        {
            if (Datos_Revisiones.Current == null) return;

            RevisionEditForm form = new RevisionEditForm((RevisionMaterial)Datos_Revisiones.Current, _entity, true);
            if (form.Entity != null)
            {
                form.ShowDialog();
                Datos_Revisiones.ResetBindings(false);
            }
        }

        #endregion

    }
}
