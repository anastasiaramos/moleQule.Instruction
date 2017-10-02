using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin02;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class NotasAlumnosForm : SelectBaseForm
    {

        #region Bussiness Methods

        protected AlumnoList _alumnos = null;

        public AlumnoList Alumnos
        {
            get { return _alumnos; }
        }

        protected Examen _entity;

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
            nodo.SelectedImageKey = Properties.Settings.Default.SUBMODULO_ICON;

            if (_alumnos == null) _alumnos = AlumnoList.GetListByExamen(true, _entity.Oid);//(_entity.OidModulo, _entity.Desarrollo, _entity.Oid, true);

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
                    //nodo_p.Tag = alumno;

                    foreach (Alumno_Examen item in _entity.Alumnos)
                    {
                        if (item.OidAlumno == alumno.Oid)
                        {
                            string texto = "[" + alumno.NExpediente + "] " + alumno.Apellidos + ", " + alumno.Nombre;
                            if (!item.Presentado)
                                texto += " - NP";
                            else
                            {
                                if (!_entity.Desarrollo)
                                    texto += " - " + item.Calificacion.ToString() + "%";
                                else
                                {
                                    foreach (Respuesta_Alumno_Examen resp in item.Respuestas)
                                        texto += " - " + resp.Calificacion.ToString() + "%";
                                }
                            }
                            TreeNode nodo_p = new TreeNode(texto);
                            nodo_p.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                            nodo_p.ForeColor = System.Drawing.Color.Black;
                            nodo_p.Tag = item;
                            nodo_p.Checked = true;
                            nodo.Nodes.Add(nodo_p);
                            //break;
                        }
                    }
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

        public NotasAlumnosForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            Arbol_TV.ImageList = new ImageList();
            Arbol_TV.ImageList.Images.Add(Properties.Settings.Default.SUBMODULO_ICON, Properties.Resources.Submodulos);

            FormatControls();
        }

        public void SetSourceData(Examen item)
        {
            _entity = item;
            _alumnos = AlumnoList.GetListByExamen(true, _entity.Oid);//.GetAlumnosAdmitidosList(_entity.OidModulo, _entity.Desarrollo, _entity.Oid, true);
            _promociones = PromocionList.GetList(false);//.GetByModuloList(_entity.OidModulo, false);
            this.Text = Resources.Labels.NOTAS_ALUMNOS;
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
            Arbol_TV.ExpandAll();

            PgMng.FillUp();
        }

        public override void RefreshSecondaryData()
        {
            _promociones = PromocionList.GetList(false);//.GetByModuloList(_entity.OidModulo, false);
            _combo_promociones = new Library.Instruction.HComboBoxSourceList(_promociones);
            Datos_Promociones.DataSource = _combo_promociones;
        }


        protected void SetNota(TreeNode node)
        {
            if (node.Level == 0) return;

            int index = _entity.Alumnos.IndexOf((Alumno_Examen)node.Tag);
            AlumnoInfo alumno = _alumnos.GetItem(((Alumno_Examen)node.Tag).OidAlumno);
            if (_entity.Desarrollo)
            {
                if (_entity.Alumnos[index].Respuestas.Count == 0)
                {
                    foreach (PreguntaExamen item in _entity.PreguntaExamens)
                    {
                        Respuesta_Alumno_Examen resp = Respuesta_Alumno_Examen.NewChild(_entity.Alumnos[index]);
                        resp.Orden = item.Orden;
                        resp.OidPreguntaExamen = item.Oid;
                        _entity.Alumnos[index].Respuestas.Add(resp);
                    }
                }

                NotaDesarrolloAlumnoInputForm form = new NotaDesarrolloAlumnoInputForm(true, _entity, index, alumno);
                form.ShowDialog();
            }
            else
            {
                NotaAlumnoInputForm form = new NotaAlumnoInputForm(true, _entity, index, alumno);
                form.ShowDialog();
            }

            for (int i = Arbol_TV.Nodes.Count - 1; i >= 0; i--)
                Arbol_TV.Nodes[i].Remove();

            if (_promociones.Count > 0)
            {
                foreach (PromocionInfo item in _promociones)
                {
                    SetAlumnosValues(null, item);
                }
            }

            Arbol_TV.ExpandAll();

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

        private void Imprimir_BT_Click(object sender, EventArgs e)
        {
            ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

            ExamenInfo info = _entity.GetInfo(true);

            foreach (PromocionInfo promo in _promociones)
            {
                List<Alumno_ExamenInfo> lista = new List<Alumno_ExamenInfo>();

                foreach (Alumno_ExamenInfo item in info.Alumnos)
                {
                    AlumnoInfo alumno = _alumnos.GetItem(item.OidAlumno); 
                    bool pertenece = false;

                    foreach (Alumno_PromocionInfo pr in alumno.Promociones)
                    {
                        if (pr.OidPromocion == promo.Oid)
                        {
                            pertenece = true;
                            break;
                        }
                    }

                    if (alumno != null && pertenece)
                        lista.Add(item);
                }

                if (lista.Count > 0)
                {
                    ReportViewer.SetReport(reportMng.GetDetailReport(info, 
                                                                    lista, promo, 
                                                                    moleQule.Library.Common.CompanyInfo.Get(AppContext.ActiveSchema.Oid)));
                    ReportViewer.ShowDialog();
                }
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
            int left_aceptar = SC1.Panel2.Right - Submit_BT.Width - 5;
            int top_cerrar = (SC2.Panel1.Height - Cerrar_BT.Height) / 2;
            int left_cerrar = SC2.Panel1.Left + 5;
            int top_aceptar = (SC1.Panel2.Height - Submit_BT.Height) / 2;

            Cerrar_BT.SetBounds(left_cerrar, top_cerrar, Cerrar_BT.Width, Cerrar_BT.Height);
            Submit_BT.SetBounds(left_aceptar, top_aceptar, Cerrar_BT.Width, Cerrar_BT.Height);

            int left_titulo = Cerrar_BT.Right + 5;
            int top_titulo = (SC2.Panel1.Height - Titulo.Height) / 2;

            Titulo.SetBounds(left_titulo, top_titulo, Titulo.Width, Titulo.Height);
            BarraDerecha.SetBounds(left_barra, top_titulo, BarraDerecha.Width, BarraDerecha.Height);

        }

        private void Arbol_TV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetNota(e.Node);
        }

        #endregion

    }
}

