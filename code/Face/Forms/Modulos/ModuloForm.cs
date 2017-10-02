using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class ModuloForm : ItemMngSkinForm
    {

        #region Attributes & Properties

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        public RevisionMaterialList _revisiones;

        protected Library.Instruction.HComboBoxSourceList _combo_materiales;

        protected List<ComboBoxSourceList> lista_sources = new List<ComboBoxSourceList>();
        //bool tema_propio = false;
        //bool submodulo_modificado = false;

        public virtual Modulo Entity { get { return null; } set { } }
        public virtual ModuloInfo EntityInfo { get { return null; } }
        public virtual long ActiveOIDSubmodulo { get { return 0; } }

        protected bool _cerrado = false;

        protected virtual void SetTemas() { }

        #endregion

        #region Factory Methods

        public ModuloForm() : this(-1, true) { }

        public ModuloForm(bool isModal) : this(-1, isModal) { }

        public ModuloForm(long oid) : this(oid, true) { }

        public ModuloForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        public override void RefreshSecondaryData()
        {
            MaterialDocenteList materiales = MaterialDocenteList.GetList(false);
            _combo_materiales = new Library.Instruction.HComboBoxSourceList(materiales);

            Datos_MaterialesD.DataSource = _combo_materiales;
            PgMng.Grow();

            _revisiones = RevisionMaterialList.GetList(false);
            _combo_materiales.Childs = new Library.Instruction.HComboBoxSourceList(_revisiones);

            Datos_Versiones.DataSource = _combo_materiales.Childs;
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
                            Material_Plan info = (Material_Plan)row.DataBoundItem;
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

        #endregion

        #region Validation & Format

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            List<string> visibles = new List<string>();

            visibles.Add(Codigo.Name);
            visibles.Add(Texto.Name);

            ControlTools.ShowDataGridColumns(Submodulos_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Submodulos_Grid.Width - vs.Width
                                                - Submodulos_Grid.RowHeadersWidth
                                                - Submodulos_Grid.Columns[Codigo.Name].Width);

            Submodulos_Grid.Columns[Texto.Name].Width = (int)(rowWidth * 0.995);

            List<string> m_visibles = new List<string>();

            m_visibles.Add(Material_CBC.Name);
            m_visibles.Add(Version_CBC.Name);
            m_visibles.Add(Autor.Name);

            ControlTools.ShowDataGridColumns(Material_Grid, m_visibles);

            rowWidth = (int)(Material_Grid.Width - vs.Width
                                                - Material_Grid.RowHeadersWidth
                                                - Material_Grid.Columns[Material_CBC.Name].Width
                                                - Material_Grid.Columns[Version_CBC.Name].Width);

            Material_Grid.Columns[Autor.Name].Width = (int)(rowWidth * 0.995);

        }

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //}

        //#endregion

        //#region Buttons

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
        //                    case "Redes_TP":
        //                        {
        //                            PrintData(Entidad.Red, psform.Source, psform.Type);
        //                        } break;

        //                }
        //            } break;
        //    }
        //}

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void Material_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Material_Grid.Columns[e.ColumnIndex].Name == "Material_CBC" && Datos_MaterialesD.Current != null && ((ComboBoxSource)
            Datos_MaterialesD.Current).Oid > 0)
            {
                if (Material_Grid["Material_CBC", e.RowIndex].Value != null)
                {
                    //se está modificando una línea ya existente
                    if (lista_sources.Count > e.RowIndex)
                        lista_sources[e.RowIndex] = _combo_materiales.GetFilteredChilds(((ComboBoxSource)Datos_MaterialesD.Current).Oid);
                    else //hay que añadir un nuevo datasource a la lista
                        lista_sources.Add(_combo_materiales.GetFilteredChilds(((ComboBoxSource)Datos_MaterialesD.Current).Oid));
                    ((DataGridViewComboBoxCell)(Material_Grid["Version_CBC", e.RowIndex])).DataSource = lista_sources[e.RowIndex];
                }
            }
            if (Material_Grid.Columns[e.ColumnIndex].Name == "Version_CBC")
            {
                Material_Plan info = (Material_Plan)Material_Grid.Rows[e.RowIndex].DataBoundItem;
                RevisionMaterialInfo revision = RevisionMaterialList.GetList(false).GetItem(info.OidRevision);
                if (info.OidRevision != 0)
                    Material_Grid["Autor", e.RowIndex].Value = revision.Autor;
            }
        }

        private void Material_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Material_Grid.Name);
        }

        private void Material_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //No hace nada
        }

        private void Submodulos_Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            /*if (Entity != null && ActiveOIDSubmodulo > 0)
            {
                Submodulo submodulo = Entity.Submodulos.GetItem(ActiveOIDSubmodulo);

                if (submodulo != null)
                {
                    if (submodulo.Temas.Count == 0)
                    {
                        Tema tema = Tema.NewChild(submodulo);
                        tema.Codigo = submodulo.Codigo + ".0";
                        if (submodulo.Texto != string.Empty)
                            tema.Nombre = submodulo.Texto;
                        else
                            tema.Nombre = Entity.Texto;
                        tema.Nivel = 1;
                        submodulo.Temas.Add(tema);
                    }
                }
            }*/
            RefreshSecondaryData();
        }

        private void Temas_Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Tema current = ((Tema)e.Row.DataBoundItem);
            if (current != null)
            {
                PreguntaList preguntas = PreguntaList.GetPreguntasTema(current.OidModulo, current.Oid);

                if (preguntas.Count > 0)
                {
                    PgMng.ShowErrorException(Resources.Messages.TEMA_CON_PREGUNTAS);
                    e.Cancel = true;
                }
            }
        }

        /*private void Temas_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Temas_Grid.Rows.Count > 0 && e.ColumnIndex == Temas_Grid.Columns.IndexOf(Temas_Grid.Columns[Codigo_T.Name])
                && tema_propio)
            {
                if (((Tema)Temas_Grid.Rows[e.RowIndex].DataBoundItem).Codigo == Entity.Submodulos.GetItem(ActiveOIDSubmodulo).Codigo + ".0")//if (e.RowIndex == 0)
                {
                    MessageBox.Show("No se puede modificar el tema seleccionado");
                    Submodulo submodulo = Entity.Submodulos.GetItem(ActiveOIDSubmodulo);
                    Temas_Grid.Rows[e.RowIndex].Cells[Codigo_T.Name].Value = string.Empty;
                }
                tema_propio = false;
            }
        }

        private void Submodulos_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Submodulos_Grid.Rows.Count > 0)
            {
                Submodulo submodulo = Entity.Submodulos.GetItem(ActiveOIDSubmodulo);
                Temas_Grid.Rows[0].Cells[Codigo_T.Name].Value = submodulo.Codigo + ".0";
                if (submodulo.Texto != string.Empty)
                    Temas_Grid.Rows[0].Cells[Nombre_T.Name].Value = submodulo.Texto;
                else
                    Temas_Grid.Rows[0].Cells[Nombre_T.Name].Value = Entity.Texto;
            }
        }

        private void Temas_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (Temas_Grid.Rows[e.RowIndex].IsNewRow)
            {
                tema_propio = true;
                return;
            }

            if (Temas_Grid.Rows.Count > 0 && e.ColumnIndex != Temas_Grid.Columns.IndexOf(Temas_Grid.Columns[Nivel.Name])
                && e.ColumnIndex != Temas_Grid.Columns.IndexOf(Temas_Grid.Columns[Desarrollo.Name]))
            {
                if (((Tema)Temas_Grid.Rows[e.RowIndex].DataBoundItem).Codigo == Entity.Submodulos.GetItem(ActiveOIDSubmodulo).Codigo + ".0")//if (e.RowIndex == 0)
                {
                    MessageBox.Show("No se puede modificar el tema seleccionado");
                    Submodulo submodulo = Entity.Submodulos.GetItem(ActiveOIDSubmodulo);
                    Temas_Grid.Rows[e.RowIndex].Cells[Codigo_T.Name].Value = submodulo.Codigo + ".0";
                    if (submodulo.Texto != string.Empty)
                        Temas_Grid.Rows[e.RowIndex].Cells[Nombre_T.Name].Value = submodulo.Texto;
                    else
                        Temas_Grid.Rows[e.RowIndex].Cells[Nombre_T.Name].Value = Entity.Texto;
                    e.Cancel = true;
                }
                else
                    tema_propio = true;
            }
        }*/

        #endregion


    }
}

