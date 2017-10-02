using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using moleQule.Library.CslaEx;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class PlantillaEditForm : PlantillaForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 8; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected PlantillaExamen _entity;

        public override PlantillaExamen Entity { get { return _entity; } set { _entity = value; } }
        public override PlantillaExamenInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(true) : null; } }

        /// <summary>
        /// Función recursiva que va creando el árbol de preguntas por submódulo
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="apartado"></param>
        private void SetSubmodulosValues(TreeNode padre, ModuloInfo modulo, SubmoduloList submodulos, TemaList temas)
        {
            TreeNode nodo = new TreeNode(modulo.NumeroModulo + " - " + modulo.Texto);
            nodo.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
            nodo.ForeColor = System.Drawing.Color.Black;
            nodo.Tag = Entity;
            nodo.SelectedImageKey = "modulo";

            if (padre == null)
            {
                while (Arbol_TV.Nodes.Count != 0)
                {
                    foreach (TreeNode t in Arbol_TV.Nodes)
                        Arbol_TV.Nodes.Remove(t);
                }

                Arbol_TV.Nodes.Add(nodo);
            }
            else
            {
                padre.Nodes.Add(nodo);
            }

            foreach (TemaInfo tema in temas)
            {
                TreeNode pregunta = null;
                Preguntas_Plantilla p = null;

                foreach (Preguntas_Plantilla obj in Entity.Preguntas)
                {
                    if (obj.OidTema == tema.Oid)
                    {
                        p = obj;
                        break;
                    }
                }

                if (p != null)
                {
                    pregunta = new TreeNode(tema.Codigo + " - " + tema.Nombre + " - Nivel : " + tema.Nivel.ToString() + " | Nº Preguntas : " + p.NPreguntas.ToString());
                    pregunta.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                    pregunta.ForeColor = System.Drawing.Color.Black;
                    pregunta.Tag = p;
                    if (p.NPreguntas == 0)
                        pregunta.ImageKey = "submodulo_verde";
                    else
                        pregunta.ImageKey = "submodulo";

                    nodo.Nodes.Add(pregunta);
                }
                else
                {
                    p = Entity.Preguntas.AddNew();
                    p.OidTema = tema.Oid;
                    p.OidSubmodulo = tema.OidSubmodulo;
                    p.NPreguntas = 0;
                    pregunta = new TreeNode(tema.Codigo + " - " + tema.Nombre + " - Nivel : " + tema.Nivel.ToString() + " | Nº Preguntas : " + p.NPreguntas.ToString());
                    pregunta.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                    pregunta.ForeColor = System.Drawing.Color.Black;
                    pregunta.Tag = p;
                    if (p.NPreguntas == 0)
                        pregunta.ImageKey = "submodulo_verde";
                    else
                        pregunta.ImageKey = "submodulo";

                    nodo.Nodes.Add(pregunta);
                }
            }

            Arbol_TV.ExpandAll();
        }

        #endregion

        #region Factory Methods

        public PlantillaEditForm() : this(-1, true) { }

        public PlantillaEditForm(long oid)
            : this(oid, true) { }

        public PlantillaEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();

            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PLANTILLA_EXAMEN_EDIT_TITLE;
            }

            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlantillaExamen.Get(oid);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                PlantillaExamen temp = _entity.Clone();
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

        public override void RefreshSecondaryData()
        {
            _modulo = ModuloInfo.Get(_entity.OidModulo);
            PgMng.Grow();

            Modulo_TB.Text = _modulo.Codigo + " " + _modulo.Texto;
            PgMng.Grow();

            NPreguntas_TB.Text = _entity.NPreguntas.ToString();
            PgMng.Grow(string.Empty, "NPreguntas");

            _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
            PgMng.Grow();

            _temas = TemaList.GetModuloList(_modulo.Oid, false);
            PgMng.Grow();

            Datos_Idiomas.DataSource = Library.Common.EnumText<EIdioma>.GetList(false);
            PgMng.Grow();
            
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            SetSubmodulosValues(null, _modulo, _submodulos, _temas);
            PgMng.Grow();
        }

        protected override void SetNPreguntas(TreeNode node)
        {
            if (node.Level == 0) return;

            int index = Entity.Preguntas.IndexOf((Preguntas_Plantilla)node.Tag);
            PreguntasPlantillaInputForm form = new PreguntasPlantillaInputForm(true, Entity, index);
            form.ShowDialog();

            SetSubmodulosValues(null, _modulo, _submodulos, _temas);

            long n_preguntas = 0;
            foreach (Preguntas_Plantilla p in Entity.Preguntas)
                n_preguntas += p.NPreguntas;

            Entity.NPreguntas = n_preguntas;
            NPreguntas_TB.Text = _entity.NPreguntas.ToString();
        }

        #endregion

        #region Buttons

        protected override void SaveAction()
        {
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        #endregion

        #region Events
        
        private void PlantillaEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
        }

        #endregion

    }
}

