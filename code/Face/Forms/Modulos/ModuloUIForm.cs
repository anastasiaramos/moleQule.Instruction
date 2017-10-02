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
    public partial class ModuloUIForm : ModuloForm
    {
        #region Attributes & Properties

        protected override int BarSteps { get { return base.BarSteps + 5; } }

        #endregion

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Modulo _entity;

        public override Modulo Entity { get { return _entity; } set { _entity = value; } }
        public override ModuloInfo EntityInfo
        {
            get
            {
                return (_entity != null) ? _entity.GetInfo(false) : null;
            }
        }

        public virtual Submodulo CurrentSubmodulo
        {
            get
            {
                return Datos_Submodulos.Current != null ? (Submodulo)(Datos_Submodulos.Current) : null;
            }
        }

        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public override long ActiveOIDSubmodulo
        {
            get
            {
                return Datos_Submodulos.Current != null ? ((Submodulo)Datos_Submodulos.Current).Oid : 0;
            }
        }

        protected override void SetTemas()
        {
            Submodulo item = Entity.Submodulos.GetItem(ActiveOIDSubmodulo);
            if (item != null)
            {
                if (item.Temas.Count == 0)
                    item.Temas.Add(new Tema(item.Codigo, item.Texto));
                else
                {
                    item.Temas[0].Codigo = item.Codigo + ".0";
                    item.Temas[0].Nombre = item.Texto;
                }
                TemaActionForm form = new TemaActionForm(item);
                form.ShowDialog();
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected ModuloUIForm() : this(-1, true) { }

        public ModuloUIForm(bool isModal) : this(-1, isModal) { }

        public ModuloUIForm(long oid) : this(oid, true) { }

        public ModuloUIForm(long oid, bool ismodal)
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
                
                Modulo temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    if (MaterialRepetido())
                    {
                        MessageBox.Show("No se puede incluir el mismo material más de una vez.");
                        return false;
                    }

                    if (SubmoduloRepetido())
                    {
                        MessageBox.Show("No se puede incluir dos veces el mismo código de submódulo");
                        return false;
                    }
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

            Datos_Submodulos.DataSource = Submodulos.SortList(_entity.Submodulos, "CodigoOrden", ListSortDirection.Ascending);
            PgMng.Grow();

            Datos_Material.DataSource = _entity.Materiales;
            PgMng.Grow();

            base.RefreshMainData();
        }

        public override void RefreshSecondaryData()
        {
            base.RefreshSecondaryData();
            PgMng.Grow();

            if (Submodulos_Grid.CurrentRow/*Datos_Submodulos.Current*/ != null && ActiveOIDSubmodulo > 0)
                Datos_Temas.DataSource = Temas.SortList(_entity.Submodulos.GetItem(ActiveOIDSubmodulo).Temas, "CodigoOrden",ListSortDirection.Ascending);
            PgMng.Grow();
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Material_Grid":
                    {
                        SetCellsDataSource(Material_Grid.Name);
                        foreach (DataGridViewRow row in Material_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Material_Plan info = (Material_Plan)row.DataBoundItem;
                            if (info != null)
                            {
                                RevisionMaterialInfo revision = _revisiones.GetItem(info.OidRevision);
                                if (revision != null)
                                {
                                    row.Cells["Material_CBC"].Value = revision.OidMaterial;
                                    row.Cells["Autor"].Value = revision.Autor;
                                }
                            }
                        }

                    } break;
            }
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Material_CBC":
                    {
                        Datos_Versiones.DataSource = _combo_materiales.GetFilteredChilds(((ComboBoxSource)Datos_MaterialesD.Current).Oid);
                    } break;
            }
        }

        private bool MaterialRepetido()
        {
            for (int i = 0; i < _entity.Materiales.Count-1; i++)
            {
                for (int j = i + 1; j < _entity.Materiales.Count; j++)
                {
                    if (_entity.Materiales[i].OidRevision == _entity.Materiales[j].OidRevision)
                        return true;
                }
            }
            return false;
        }

        private bool SubmoduloRepetido()
        {
            for (int i = 0; i < _entity.Submodulos.Count - 1; i++)
            {
                for (int j = i + 1; j < _entity.Submodulos.Count; j++)
                {
                    if (_entity.Submodulos[i].Codigo == _entity.Submodulos[j].Codigo)
                        return true;
                }
            }
            return false;
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
        //                ModuloReportMng rptMng = new ModuloReportMng(AppContext.ActiveSchema);
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
            if (_entity.Alias == string.Empty) 
            {
                //if (_entity.Texto.Length > 9) _entity.Alias = _entity.Texto.Substring(0, 10).ToUpper();
                //else 
                _entity.Alias = _entity.Texto.ToUpper();
            }
            else 
                _entity.Alias = _entity.Alias.ToUpper();
            
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
            _cerrado = (_action_result == DialogResult.OK);
        }

        #endregion

        #region Events

        private void Submodulos_Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Submodulo item = Submodulos_Grid.CurrentRow.DataBoundItem as Submodulo;
            ClaseTeoricaList listaT = ClaseTeoricaList.GetListBySubmodulo(item.Oid);

            if (listaT.Count > 0)
            {
                MessageBox.Show("No es posible borrar un submódulo que ha sido incluido en un plan de estudios");
                e.Cancel = true;
                return;
            }

            ClasePracticaList listaP = ClasePracticaList.GetListBySubmodulo(item.Oid);

            if (listaP.Count > 0)
            {
                MessageBox.Show("No es posible borrar un submódulo que ha sido incluido en un plan de estudios");
                e.Cancel = true;
            }

        }

        #endregion

    }
}

