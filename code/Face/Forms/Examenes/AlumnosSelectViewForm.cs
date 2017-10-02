using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Csla;
using CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class AlumnosSelectViewForm : Skin01.SelectSkinForm
    {

        #region Bussiness Methods

        protected AlumnoList _alumnos = null;

        public AlumnoList Alumnos
        {
            get { return _alumnos; }
        }

        protected ExamenInfo _entity;

        protected PromocionList _promociones = null;
        protected Library.Instruction.HComboBoxSourceList _combo_promociones;

        /// <summary>
        /// Función recursiva que va creando el árbol de submódulos y preguntas
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="apartado"></param>
        private void SetAlumnosValues(TreeNode padre, PromocionInfo promocion)
        {
            TreeNode nodo = new TreeNode(promocion.Numero + " - " + promocion.Nombre);
            nodo.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
            nodo.ForeColor = System.Drawing.Color.Black;
            nodo.Tag = promocion;
            nodo.SelectedImageKey = "submodulo";
            
            if (_alumnos == null) _alumnos = AlumnoList.GetAlumnosAdmitidosList(_entity.OidModulo, _entity.Desarrollo, true);

            foreach (AlumnoInfo alumno in _alumnos)
            {
                bool pertenece = false;

                foreach (Alumno_PromocionInfo item in alumno.Promociones)
                {
                    if (item.OidPromocion == promocion.Oid)
                    {
                        pertenece = true;
                        break;
                    }
                }

                if (pertenece)
                {
                    TreeNode nodo_p = new TreeNode("[" + alumno.NExpediente + "] " + alumno.Apellidos + ", " + alumno.Nombre);
                    nodo_p.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                    nodo_p.ForeColor = System.Drawing.Color.Black;
                    nodo_p.Tag = alumno;

                    foreach (Alumno_ExamenInfo item in _entity.Alumnos)
                    {
                        if (item.OidAlumno == alumno.Oid)
                        {
                            nodo_p.Checked = true;
                            break;
                        }
                    }
                    if (nodo_p.Checked)
                        nodo.Nodes.Add(nodo_p);
                }
            }

            if (nodo.Nodes.Count > 0)
            {
                if (padre == null)
                {
                    Arbol_TV.Nodes.Add(nodo);
                }
                else
                {
                    padre.Nodes.Add(nodo);
                }
            }
        }

        #endregion

        #region Factory Methods

        public AlumnosSelectViewForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            Arbol_TV.ImageList = new ImageList();
            //Arbol_TV.ImageList.Images.Add("submodulo", new Icon(Resources.Paths.SUBMODULOS));

            FormatControls();
        }

        public void SetSourceData(ExamenInfo item)
        {
            _entity = item;
            _alumnos = AlumnoList.GetAlumnosAdmitidosList(_entity.OidModulo, _entity.Desarrollo, true);
            _promociones = PromocionList.GetByModuloList(_entity.OidModulo, false);
            this.Text = Resources.Labels.SELECT_ALUMNOS;
            RefreshSecondaryData();
            RefreshMainData();
        }

        #endregion

        #region Style & Source


        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity.Alumnos;
            PgMng.Grow();

            if (_promociones.Count > 0)
            {
                foreach (PromocionInfo item in _promociones)
                {
                    SetAlumnosValues(null, item);
                }
            }

            PgMng.FillUp();
        }

        public override void RefreshSecondaryData()
        {
            _promociones = PromocionList.GetList(false);
            _combo_promociones = new Library.Instruction.HComboBoxSourceList(_promociones);
            Datos_Promociones.DataSource = _combo_promociones;
        }

        #endregion

        #region Buttons

        private void Aceptar_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cerrar_BT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Filtrar_BT_Click(object sender, EventArgs e)
        {

            while (Arbol_TV.Nodes.Count != 0)
            {
                foreach (TreeNode t in Arbol_TV.Nodes)
                    Arbol_TV.Nodes.Remove(t);
            }

            if (((ComboBoxSource)Promocion_CB.SelectedItem).Oid == 0)
            {
                foreach (PromocionInfo item in _promociones)
                    SetAlumnosValues(null, item);
            }
            else
            {
                PromocionInfo p = _promociones.GetItem(((ComboBoxSource)Promocion_CB.SelectedItem).Oid);
                if (p != null)
                    SetAlumnosValues(null, p);
            }

        }

        #endregion

        #region Events

        private void AlumnosSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        /// <summary>
        /// Maximiza la ventana porque si utilizamos el Maximize lo aplica
        /// a todos los formularios abiertos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlumnosSelectForm_Load(object sender, EventArgs e)
        {
            this.MaximizeForm();

            Panel1.SplitterDistance = 124;
            SC2.SplitterDistance = 49;
            SC1.SplitterDistance = SC1.Height - 67;

            int left_barra = SC2.Panel1.Right - 5;
            int left_aceptar = SC1.Panel2.Right - OK_BT.Width - 5;
            int top_cerrar = (SC2.Panel1.Height - Cerrar_BT.Height) / 2;
            int left_cerrar = SC2.Panel1.Left + 5;
            int top_aceptar = (SC1.Panel2.Height - OK_BT.Height) / 2;

            Cerrar_BT.SetBounds(left_cerrar, top_cerrar, Cerrar_BT.Width, Cerrar_BT.Height);
            OK_BT.SetBounds(left_aceptar, top_aceptar, Cerrar_BT.Width, Cerrar_BT.Height);

            int left_titulo = Cerrar_BT.Right + 5;
            int top_titulo = (SC2.Panel1.Height - Titulo.Height) / 2;

            Titulo.SetBounds(left_titulo, top_titulo, Titulo.Width, Titulo.Height);
            BarraDerecha.SetBounds(left_barra, top_titulo, BarraDerecha.Width, BarraDerecha.Height);

        }

        #endregion

    }
}

