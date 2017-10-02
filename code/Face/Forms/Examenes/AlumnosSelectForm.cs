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
using moleQule.Library.Common;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class AlumnosSelectForm : SelectBaseForm
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
            nodo.SelectedImageKey = "submodulo";
            
            if (_alumnos == null) _alumnos = AlumnoList.GetAlumnosAdmitidosList(_entity.OidModulo, _entity.Desarrollo, _entity.Oid, ExamenPromocionList.GetChildList(_entity.Promociones), _entity.FechaExamen, true);

            foreach (AlumnoInfo alumno in _alumnos)
            {
                bool pertenece = false;

                if (alumno.Promociones == null)
                    alumno.LoadChilds(typeof(Alumno_Promocion), false);
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

                    foreach (Alumno_Examen item in _entity.Alumnos)
                    {
                        if (item.OidAlumno == alumno.Oid)
                        {
                            nodo_p.Checked = true;
                            break;
                        }
                    }

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

        public AlumnosSelectForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            FormatControls();
        }

        public void SetSourceData(Examen item)
        {
            _entity = item;
            _alumnos = AlumnoList.GetAlumnosAdmitidosList(item.OidModulo, _entity.Desarrollo, _entity.Oid, ExamenPromocionList.GetChildList(_entity.Promociones), _entity.FechaExamen, false);
            _promociones = PromocionList.GetList(false);//.GetByModuloList(item.OidModulo, false);
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
                if (_entity.FechaEmision.Date != DateTime.MaxValue.Date && _entity.Promociones.Count == 0)
                {
                    foreach (PromocionInfo info in _promociones)
                        SetAlumnosValues(null, info);
                }
                else
                {
                    foreach (ExamenPromocion item in _entity.Promociones)
                        SetAlumnosValues(null, _promociones.GetItem(item.OidPromocion));
                }
            }

            PgMng.FillUp();
        }

        public override void RefreshSecondaryData()
        {
            _promociones = PromocionList.GetList(false);//.GetByModuloList(_entity.OidModulo, false);
            _combo_promociones = new Library.Instruction.HComboBoxSourceList(_promociones);
            Datos_Promociones.DataSource = _combo_promociones;
        }

        protected void InsertarRegistros()
        {
            foreach (TreeNode promocion in Arbol_TV.Nodes)
            {
                foreach (TreeNode alumno in promocion.Nodes)
                {
                    if (alumno.Checked)
                    {
                        long oid = ((AlumnoInfo)alumno.Tag).Oid;
                        bool esta = false;
                        foreach (Alumno_Examen item in _entity.Alumnos)
                        {
                            if (oid == item.OidAlumno)
                            {
                                esta = true;
                                //_entity.Alumnos.AddItem(item);
                                break;
                            }
                        }
                        if (!esta)
                        {
                            Alumno_Examen al = Alumno_Examen.NewChild(_entity);
                            al.OidAlumno = oid;
                            al.Presentado = false;
                            al.Calificacion = 0;
                            _entity.Alumnos.AddItem(al);
                        }
                    }
                    else
                    {
                        long oid = ((AlumnoInfo)alumno.Tag).Oid;
                        for(int i = _entity.Alumnos.Count - 1; i >= 0; i--)
                        {
                            Alumno_Examen item = _entity.Alumnos[i];
                            if (oid == item.OidAlumno)
                            {
                                _entity.Alumnos.Remove(item);
                                //break;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Buttons

        private void Aceptar_Button_Click(object sender, EventArgs e)
        {
            InsertarRegistros();
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
                int count = Arbol_TV.Nodes.Count - 1;
                for(int i = count ; i>=0; i--)
                    Arbol_TV.Nodes.Remove(Arbol_TV.Nodes[i]);
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
            InsertarRegistros();
            ExamenInfo EntityInfo = _entity.GetInfo(true);
            ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);
                        
            //List<Alumno_ExamenInfo> lista = new List<Alumno_ExamenInfo>();

            //foreach (AlumnoInfo alumno in _alumnos)
            //{
            //    Alumno_ExamenInfo item = EntityInfo.Alumnos.GetItemByProperty("OidAlumno", alumno.Oid);
            //    if (item != null)
            //        lista.Add(item);
            //}

            foreach (TreeNode promocion in Arbol_TV.Nodes)
            {
                List<Alumno_ExamenInfo> lista = new List<Alumno_ExamenInfo>();

                foreach (TreeNode alumno in promocion.Nodes)
                {
                    if (alumno.Checked)
                    {
                        long oid = ((AlumnoInfo)alumno.Tag).Oid;
                        Alumno_ExamenInfo item = EntityInfo.Alumnos.GetItemByProperty("OidAlumno", oid);
                        if (item != null)
                            lista.Add(item);
                    }
                } 
                
                if (lista.Count > 0)
                {
                    bool defecto = moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultBoolSetting();
                    CompanyInfo empresa = null;

                    if (defecto)
                        empresa = CompanyInfo.Get(moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultOidSetting(), false);
                    while (empresa == null)
                    {
                        moleQule.Face.Common.CompanySelectForm form = new Common.CompanySelectForm(this);
                        DialogResult result = form.ShowDialog();

                        try
                        {
                            if (result == DialogResult.OK)
                                empresa = form.Selected as CompanyInfo;
                        }
                        catch
                        { empresa = null; }
                    }

                    ISchemaInfo schema = AppContext.ActiveSchema;
                    try
                    {
                        schema = empresa as ISchemaInfo;
                        if (schema == null) schema = AppContext.ActiveSchema;
                    }
                    catch
                    {
                    }

                    ReportViewer.SetReport(reportMng.GetDetailAsistenciaExamenReport(EntityInfo,
                                                                                    _promociones, lista,
                                                                                    empresa,
                                                                                    ((PromocionInfo)promocion.Tag).Nombre));
                    ReportViewer.ShowDialog();
                }
            }

            /*foreach (Alumno_ExamenInfo item in EntityInfo.Alumnos)
            {
                AlumnoInfo alumno = _alumnos.GetItem(item.OidAlumno);
                if (alumno != null)
                {
                    //item.OidPromocion = alumno.OidPromocion;
                    lista.Add(item);
                }
            }*/

            //if (lista.Count > 0)
            //{
            //    ReportViewer.SetReport(reportMng.GetDetailAsistenciaExamenReport(EntityInfo, 
            //                                                                    _promociones, lista,
            //                                                                    moleQule.Library.Common.EmpresaInfo.Get(AppContext.ActiveSchema.Oid)));
            //    ReportViewer.ShowDialog();
            //}
        }

        #endregion

        #region Events


        private void AlumnosSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void Arbol_TV_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                foreach (TreeNode t in e.Node.Nodes)
                    t.Checked = e.Node.Checked;
            }
            else
            {
                if (e.Node.Level == 1)
                {
                    AlumnoInfo alumno = e.Node.Tag as AlumnoInfo;
                    foreach (Alumno_PromocionInfo item in alumno.Promociones)
                    {
                        foreach (TreeNode t in Arbol_TV.Nodes)
                        {
                            PromocionInfo promocion = t.Tag as PromocionInfo;
                            if (promocion.Oid == item.OidPromocion)
                            {
                                foreach (TreeNode n in t.Nodes)
                                {
                                    if ((n.Tag as AlumnoInfo).Oid == alumno.Oid && n.Checked != e.Node.Checked)
                                        n.Checked = e.Node.Checked;
                                }
                                break;
                            }
                        }
                    }
                }
            }
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
            //if (e.Node.Level > 0)
            //{
            //    Alumno_Examen item = null;

            //    foreach(Alumno_Examen obj in _entity.Alumnos)
            //    {
            //        if (obj.OidAlumno == ((AlumnoInfo)e.Node.Tag).Oid)
            //        {
            //            item = obj;
            //            break;
            //        }
            //    }

            //    if (item != null)
            //    {
            //        Alumno_ExamenAddActionForm form = new Alumno_ExamenAddActionForm(true);
            //        form.SetSourceData(Alumno.Get(((AlumnoInfo)e.Node.Tag).Oid), item);
            //        form.ShowDialog();
            //    }
            //}

        }

        #endregion

    }
}

