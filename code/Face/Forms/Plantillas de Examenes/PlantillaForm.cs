using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PlantillaForm : moleQule.Face.Skin01.ItemMngSkinForm
    {

        #region Business Methods

        protected ModuloInfo _modulo = null;
        protected SubmoduloList _submodulos = null;
        protected TemaList _temas = null;

        public virtual PlantillaExamen Entity { get { return null; } set { } }
        public virtual PlantillaExamenInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public PlantillaForm() : this(-1, true) { }

        public PlantillaForm(bool isModal) : this(-1, isModal) { }

        public PlantillaForm(long oid) : this(oid, true) { }

        public PlantillaForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        /// <summary>
        /// Función que se debe definir en el EditForm, que mostrará un formulario para cambiar el número 
        /// de pregutnas de un submódulo determinado
        /// </summary>
        /// <param name="node">Nodo que representa la preguntas_plantilla que se quiere modificar</param>
        protected virtual void SetNPreguntas(TreeNode node) { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void Arbol_TV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetNPreguntas(e.Node);
        }

        #endregion

    }
}


