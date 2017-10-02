using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face.Skin01;

using moleQule.Library.Application;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class ImagenPreguntaViewForm : moleQule.Face.ImageViewSkinForm
    {
        
        #region Bussiness Methods

        #endregion

        #region Factory Methods

        /// <summary>
        /// Constructor para formularios de insercion (AddForms)
        /// No se le especifica Oid asociado al formulario
        /// </summary>
        public ImagenPreguntaViewForm() : this(false, string.Empty) { }

        /// <summary>
        /// Constructor para formularios asociados a un objeto (ViewForms & EditForms) modales
        /// </summary>
        /// <param name="oid">Oid del objeto que se va a editar</param>
        public ImagenPreguntaViewForm(bool isModal, string path)
            : base(isModal, path)
        {
            InitializeComponent();
            this.Text = Resources.Labels.IMAGEN_PREGUNTA_VIEW_TITLE;
            _path = path;
            Images.Show(_path, Image_PB);
        }

        /// <summary>
        /// Constructor para formularios asociados a un objeto (ViewForms & EditForms) modales
        /// </summary>
        /// <param name="oid">Oid del objeto que se va a editar</param>
        public ImagenPreguntaViewForm(bool isModal, string path, string fileName)
            : base(isModal, path)
        {
            InitializeComponent();
            this.Text = Resources.Labels.IMAGEN_PREGUNTA_VIEW_TITLE;
            _path = path;
            Images.Show(fileName, path, Image_PB);
        }
        
        #endregion

        #region Style & Source

        #endregion

        #region Validation & Format

        #endregion

        #region Buttons

        #endregion

        #region Events

        #endregion
    }
}

