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
    public partial class ModuloViewForm : ModuloForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private ModuloInfo _entity;

        public override ModuloInfo EntityInfo { get { return _entity; } }

        public virtual SubmoduloInfo CurrentSubmodulo
        {
            get
            {
                return
            Datos_Submodulos.Current != null ? (SubmoduloInfo)(
            Datos_Submodulos.Current) : null;
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
                return Datos_Submodulos.Current != null ? ((SubmoduloInfo)
            Datos_Submodulos.Current).Oid : 0;
            }
        }

        protected override void SetTemas()
        {
            SubmoduloInfo submodulo = _entity.Submodulos.GetItem(ActiveOIDSubmodulo);
            if (submodulo != null)
            {
                TemaViewActionForm form = new TemaViewActionForm(submodulo);
                form.ShowDialog();
            } 
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private ModuloViewForm() : this(-1) { }

        public ModuloViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.MODULO_EDIT_TITLE + " " + EntityInfo.Codigo.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = ModuloInfo.Get(oid, true);
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

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            Datos_Submodulos.DataSource = SubmoduloList.SortList(_entity.Submodulos, "CodigoOrden", ListSortDirection.Ascending);
            PgMng.Grow();

            Datos_Material.DataSource = _entity.Materiales;
            PgMng.Grow();

            base.RefreshMainData();
        }

        public override void RefreshSecondaryData()
        {
           base.RefreshSecondaryData();
            PgMng.Grow();

            if (Submodulos_Grid.CurrentRow != null && ActiveOIDSubmodulo > 0)
            {
                SubmoduloInfo submodulo = _entity.Submodulos.GetItem(ActiveOIDSubmodulo);
                if (submodulo.Temas != null)
                    Datos_Temas.DataSource = TemaList.SortList(submodulo.Temas,
                                                    "CodigoOrden", ListSortDirection.Ascending);
            }
            PgMng.Grow();
        }


        protected override void SetCellsDataSource(string gridName)
        {
            switch (gridName)
            {
                case "Material_Grid":
                    {
                        foreach (DataGridViewRow row in Material_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (lista_sources.Count >= row.Index + 1) continue;
                            Material_PlanInfo info = (Material_PlanInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                RevisionMaterialInfo revision = _revisiones.GetItem(info.OidRevision);
                                if (revision != null)
                                {
                                    lista_sources.Add(_combo_materiales.GetFilteredChilds(revision.OidMaterial));
                                    ((DataGridViewComboBoxCell)row.Cells["Version_CBC"]).DataSource = lista_sources[row.Index];
                                }
                            }
                        }

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
                case "Material_Grid":
                    {
                        SetCellsDataSource(Material_Grid.Name);
                        foreach (DataGridViewRow row in Material_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Material_PlanInfo info = (Material_PlanInfo)row.DataBoundItem;
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
