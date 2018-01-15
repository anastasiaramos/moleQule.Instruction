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
    public partial class PreguntasSelectForm : SelectBaseForm
    {

        #region Bussiness Methods

        protected SubmoduloList _submodulos = null;
        protected TemaList _temas = null;
        List<long> preguntas_incluidas = null;
        List<long> _preguntas_mismo_dia = null;

        protected PreguntaList _preguntas = null;

        public SubmoduloList SubModulos
        {
            get { return _submodulos; }
        }

        public TemaList Temas
        {
            get { return _temas; }
        }

        public PreguntaList Preg
        {
            get { return _preguntas; }
        }

        //protected string _memo_preguntas;
        protected Examen _entity;
        protected ModuloInfo _modulo;
        private int _disponibles = 0;
        private int _examen = 0;
        private int _seleccionadas = 0;
        Library.Instruction.HComboBoxSourceList _combo_submodulos;

        public List<long> lista_preguntas = null;

        /// <summary>
        /// Función recursiva que va creando el árbol de submódulos y preguntas
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="apartado"></param>
        private void SetPreguntasValues(TreeNode padre, TemaInfo tema)
        {
            TreeNode nodo = new TreeNode(tema.Codigo + " - " + tema.Nombre + " - Nivel: " + tema.Nivel.ToString());
            nodo.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
            nodo.ForeColor = System.Drawing.Color.Black;
            nodo.Tag = tema;
            nodo.SelectedImageKey = Properties.Settings.Default.SUBMODULO_ICON;

            if (padre == null)
            {
                Arbol_TV.Nodes.Add(nodo);
            }
            else
            {
                padre.Nodes.Add(nodo);
            }

            string idioma = string.Empty;

            if (Idioma_CB.SelectedItem != null && ((ComboBoxSource)Idioma_CB.SelectedItem).Oid == 0)
            {
                if (((ComboBoxSource)Idioma_CB.SelectedItem).Oid == 1)
                    idioma = Library.Common.EIdioma.Spanish.ToString();
                else
                    idioma = Library.Common.EIdioma.English.ToString();
            }

                foreach (PreguntaInfo p in _preguntas)
                {
                    Library.Instruction.EnumText<ETipoPregunta>.GetLabel(ETipoPregunta.Desarrollo);
                    if ( p.OidTema == tema.Oid
                        && (Tema_CB.SelectedItem == null
                        || ((((ComboBoxSource)Tema_CB.SelectedItem).Oid == 0
                        || ((ComboBoxSource)Tema_CB.SelectedItem).Oid == p.OidTema)
                        && (((ComboBoxSource)Idioma_CB.SelectedItem).Oid == 0
                        || Idioma_CB.SelectedItem == null
                        || p.Idioma == idioma)))
                        && ((_entity.Desarrollo && p.Tipo == ETipoPregunta.Desarrollo.ToString())
                        || (!_entity.Desarrollo && p.Tipo == ETipoPregunta.Test.ToString()/*"Test"*/))
                        && p.Activa)
                    {
                        //Pregunta p_actualizada = _preguntas.GetItem(p.Oid);

                        TreeNode nodo_p = new TreeNode("[" + p.Serial + "] " + p.Texto);
                        nodo_p.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                        nodo_p.ForeColor = System.Drawing.Color.Black;
                        nodo_p.Tag = p;

                        if (Esta(p.Oid))
                        {
                            nodo_p.ImageKey = Properties.Settings.Default.PREGUNTA_DISPONIBLE_ICON;
                            nodo_p.Checked = true;
                            _examen++;
                            _seleccionadas++;
                        }
                        else
                        {
                            if (p.FechaDisponibilidad.Date <= _entity.FechaExamen.Date && !p.Reservada)
                            {
                                nodo_p.ImageKey = Properties.Settings.Default.PREGUNTA_DISPONIBLE_ICON;
                                _disponibles++;
                            }
                            else
                            {
                                if (p.Reservada)
                                {
                                    if (preguntas_incluidas.Contains(p.Oid)
                                        || _preguntas_mismo_dia.Contains(p.Oid))
                                    {
                                        nodo_p.ImageKey = Properties.Settings.Default.PREGUNTA_DISPONIBLE_ICON;
                                        _disponibles++;
                                    }
                                    else
                                        nodo_p.ImageKey = Properties.Settings.Default.PREGUNTA_RESERVADA_ICON;
                                }
                                else
                                {
                                    if (preguntas_incluidas.Contains(p.Oid))
                                    {
                                        nodo_p.ImageKey = Properties.Settings.Default.PREGUNTA_DISPONIBLE_ICON;
                                        _disponibles++;
                                    }
                                    else
                                        nodo_p.ImageKey = Properties.Settings.Default.PREGUNTA_BLOQUEADA_ICON;
                                }
                            }
                        }

                        nodo.Nodes.Add(nodo_p);
                    }
                }
        }

        #endregion

        #region Factory Methods

        public PreguntasSelectForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            Arbol_TV.ImageList = new ImageList();
            Arbol_TV.ImageList.Images.Add(Properties.Settings.Default.SUBMODULO_ICON, Properties.Resources.Submodulos);
            Arbol_TV.ImageList.Images.Add(Properties.Settings.Default.PREGUNTA_DISPONIBLE_ICON, Properties.Resources.Disponible);
            Arbol_TV.ImageList.Images.Add(Properties.Settings.Default.PREGUNTA_RESERVADA_ICON, Properties.Resources.Reservada);
            Arbol_TV.ImageList.Images.Add(Properties.Settings.Default.PREGUNTA_BLOQUEADA_ICON, Properties.Resources.Bloqueada);

            FormatControls();
        }

        public void SetSourceData(Examen item, ModuloInfo modulo, SubmoduloList submodulos, 
                    TemaList temas, PreguntaList preguntas, List<long> preguntas_mismo_dia, bool propuesto)
        {
            lista_preguntas = new List<long>();
            //_memo_preguntas = item.MemoPreguntas;
            _entity = item;
            //if (propuesto) _entity.MemoPreguntas = string.Empty;
            _modulo = modulo;
            _preguntas = preguntas;
            _submodulos = submodulos;
            _temas = temas;
            _preguntas_mismo_dia = preguntas_mismo_dia;
            this.Text = Resources.Labels.SELECT_PREGUNTAS;

            foreach (Pregunta_Examen pregunta in _entity.Pregunta_Examens)
                lista_preguntas.Add(pregunta.OidPregunta);

            //while (_memo_preguntas != string.Empty)
            //{
            //    long pregunta;
            //    int index = _memo_preguntas.IndexOf(";");
            //    pregunta = Convert.ToInt64(_memo_preguntas.Substring(0, index));
            //    _memo_preguntas = _memo_preguntas.Substring(index + 1);
            //    Pregunta p = _preguntas.GetItem(pregunta);
            //    lista_preguntas.Add(pregunta);
            //}
            RefreshMainData();
            RefreshSecondaryData();
        }

        #endregion

        #region Style & Source


        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = SubModulos;
            PgMng.Grow();

            GetPreguntasReservadas();
            PgMng.Grow();

            if (Datos.Count > 0)
            {
                _examen = 0;
                _disponibles = 0;
                _seleccionadas = 0;

                foreach (SubmoduloInfo sub in _submodulos)
                {
                    foreach (TemaInfo item in _temas)
                    {
                        if (item.OidSubmodulo == sub.Oid)
                            SetPreguntasValues(null, item);
                    }
                }

                //se eliminan los nodos que no tengan preguntas asociadas
                for (int t = Arbol_TV.Nodes.Count - 1; t >= 0; t--)
                {
                    if (Arbol_TV.Nodes[t].Nodes.Count == 0)
                        Arbol_TV.Nodes[t].Remove();
                }
            }
            PgMng.Grow();

            Disponibles_TB.Text = _disponibles.ToString();
            Seleccionadas_TB.Text = "0";
            Examen_TB.Text = _examen.ToString();
            PgMng.FillUp();
        }

        public override void RefreshSecondaryData()
        {
            _combo_submodulos = new Library.Instruction.HComboBoxSourceList(SubModulos);
            Datos_Submodulos.DataSource = _combo_submodulos;
            _combo_submodulos.Childs = new Library.Instruction.HComboBoxSourceList(TemaList.GetList(false));

            //HComboBoxSourceList combo_nivel = new Library.Instruction.HComboBoxSourceList();
            //combo_nivel.Add(new ComboBoxSource(0, "TODOS"));
            //combo_nivel.Add(new ComboBoxSource(1, "1"));
            //combo_nivel.Add(new ComboBoxSource(2, "2"));
            //combo_nivel.Add(new ComboBoxSource(3, "3"));
            //Datos_Temas.DataSource = combo_nivel;

            //Library.Instruction.HComboBoxSourceList combo_idioma = new Library.Instruction.HComboBoxSourceList();
            //combo_idioma.Add(new ComboBoxSource(0, "TODOS"));
            //combo_idioma.Add(new ComboBoxSource(1, "Español"));
            //combo_idioma.Add(new ComboBoxSource(2, "Inglés"));
            Datos_Idiomas.DataSource = Library.Common.EnumText<EIdioma>.GetList();//combo_idioma;
        }

        private bool Esta(long oid_pregunta)
        {
            foreach (long oid in lista_preguntas)
            {
                if (oid == oid_pregunta)
                    return true;
            }
            return false;
        }

        private void GetPreguntasReservadas()
        {
            preguntas_incluidas = ExamenList.GetPreguntasReservadas(_entity);
        }

        #endregion

        #region Buttons

        private void Aceptar_Button_Click(object sender, EventArgs e)
        {
            _entity.Pregunta_Examens = Pregunta_Examens.NewChildList();

            foreach (TreeNode t in Arbol_TV.Nodes)
            {
                foreach (TreeNode preg in t.Nodes)
                {
                    if (preg.Checked && preg.ImageKey == Properties.Settings.Default.PREGUNTA_DISPONIBLE_ICON)
                    {
                        PreguntaInfo p = Preg.GetItem(((PreguntaInfo)preg.Tag).Oid);

                        //if (!Esta(((PreguntaInfo)preg.Tag).Oid))
                        //{ 
                            Pregunta_Examen pregunta = Pregunta_Examen.NewChild(_entity);
                            pregunta.OidPregunta = p.Oid;
                            _entity.Pregunta_Examens.AddItem(pregunta);
                        //}
                        //if (_entity.FechaExamen.Date.Equals(DateTime.MaxValue.Date))
                        //    p.FechaDisponibilidad = DateTime.MaxValue;
                        //else
                        //    p.FechaDisponibilidad = _entity.FechaExamen.Date.AddYears(1);
                        //p.Reservada = true;
                        //p.Bloqueada = false; // se libera porque sino se podría confundir con una pregunta que está en un examen emitido
                        //_memo_preguntas += ((Pregunta)preg.Tag).Oid.ToString() + ";";
                    }
                    //else
                    //{
                    //    //si estaba pero se ha deseleccionado hay que marcarla como disponible
                    //    if (Esta(((PreguntaInfo)preg.Tag).Oid))
                    //    {
                    //        PreguntaInfo p = Preg.GetItem(((PreguntaInfo)preg.Tag).Oid);

                    //        //hay que buscar el indice de la Pregunta_Examen y quitarla de la lista
                    //        int index = 0;
                    //        foreach (Pregunta_Examen item in _entity.Pregunta_Examens)
                    //        {
                    //            if (item.OidPregunta == p.Oid)
                    //                break;
                    //            index++;
                    //        }

                    //        _entity.Pregunta_Examens.RemoveAt(index);

                    //        //p.FechaDisponibilidad = DateTime.Today;
                    //        //p.Reservada = false;
                    //    }
                    //}
                }
            }
            //_entity.MemoPreguntas = _memo_preguntas;
            //_modulo.Preguntas = Preg;
            Close();
        }

        private void Cerrar_BT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Filtrar_BT_Click(object sender, EventArgs e)
        {

            _examen = 0;
            _disponibles = 0;
            _seleccionadas = 0;

            GetPreguntasReservadas();

            while (Arbol_TV.Nodes.Count != 0)
            {
                foreach (TreeNode t in Arbol_TV.Nodes)
                    Arbol_TV.Nodes.Remove(t);
            }

            if ((ComboBoxSource)Submodulo_CB.SelectedItem != null 
                && (ComboBoxSource)Idioma_CB.SelectedItem != null)
            {
                if (((ComboBoxSource)Submodulo_CB.SelectedItem).Oid == 0)
                {
                    foreach (SubmoduloInfo sub in _submodulos)
                    {
                        foreach (TemaInfo item in _temas)
                        {
                            if (item.OidSubmodulo == sub.Oid)
                                SetPreguntasValues(null, item);
                        }
                    }
                    //Arbol_TV.ExpandAll();

                    //se eliminan los nodos que no tengan preguntas asociadas
                    foreach (TreeNode t in Arbol_TV.Nodes)
                    {
                        if (t.Nodes.Count == 0)
                            t.Remove();
                    }
                }
                else
                {
                    SubmoduloInfo submodulo = _submodulos.GetItem(((ComboBoxSource)Submodulo_CB.SelectedItem).Oid);

                    if (Tema_CB.SelectedItem != null && ((ComboBoxSource)Tema_CB.SelectedItem).Oid == 0)
                    {
                        foreach (TemaInfo t in _temas)
                        {
                            if (t.OidSubmodulo == submodulo.Oid)
                                SetPreguntasValues(null, t);
                        }
                    }
                    else
                    {
                        TemaInfo t = _temas.GetItem(((ComboBoxSource)Tema_CB.SelectedItem).Oid);
                        SetPreguntasValues(null, t);

                    }
                    //se eliminan los nodos que no tengan preguntas asociadas
                    foreach (TreeNode t in Arbol_TV.Nodes)
                    {
                        if (t.Nodes.Count == 0)
                            t.Remove();
                    }
                }
            }
            //else
            //{
            //    TemaInfo t = _temas.GetItem(((ComboBoxSource)Tema_CB.SelectedItem).Oid);
            //    if (t != null)
            //    {
            //        SetPreguntasValues(null, t);

            //        //se eliminan los nodos que no tengan pregutas asociadas
            //        foreach (TreeNode n in Arbol_TV.Nodes)
            //        {
            //            if (n.Nodes.Count == 0)
            //                n.Remove();
            //        }
            //    }
            //    else
            //        MessageBox.Show("No existen preguntas asociadas al tema seleccionado");
            //}

            Disponibles_TB.Text = _disponibles.ToString();
            Seleccionadas_TB.Text = "0";
            Examen_TB.Text = _examen.ToString();

        }

        #endregion

        #region Events


        private void PreguntasSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void Submodulo_CB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Submodulo_CB.SelectedItem != null && ((ComboBoxSource)Submodulo_CB.SelectedItem).Oid != 0)
                Datos_Temas.DataSource = _combo_submodulos.GetFilteredChilds(((ComboBoxSource)Submodulo_CB.SelectedItem).Oid);
        }

        private void Arbol_TV_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level < 1)
            {
                if (!e.Node.Checked) return;
                e.Node.Checked = false;
                return;
            }
            else
            {
                if (((((PreguntaInfo)e.Node.Tag).Reservada
                    && !preguntas_incluidas.Contains(((PreguntaInfo)e.Node.Tag).Oid))
                    && !Esta(((PreguntaInfo)e.Node.Tag).Oid))
                    || (((PreguntaInfo)e.Node.Tag).Bloqueada)
                    && ((PreguntaInfo)e.Node.Tag).FechaDisponibilidad.Date > _entity.FechaExamen.Date)
                {
                    if (e.Node.Checked)
                        e.Node.Checked = false;
                    return;
                }
            }
            if (e.Node.Checked)
            {
                _seleccionadas++;
                _examen++;
                _disponibles--;
            }
            else
            {
                _seleccionadas--;
                _examen--;
                _disponibles++;
            }

            Seleccionadas_TB.Text = _seleccionadas.ToString();
            Examen_TB.Text = _examen.ToString();
            Disponibles_TB.Text = _disponibles.ToString();

        }

        /// <summary>
        /// Maximiza la ventana porque si utilizamos el Maximize lo aplica
        /// a todos los formularios abiertos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreguntasSelectForm_Load(object sender, EventArgs e)
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

            int top_datos = (SC2.Panel2.Height - Datos_GB.Height) / 2;
            int left_datos = SC2.Panel2.Right - Datos_GB.Width - 5;

            Datos_GB.SetBounds(left_datos, top_datos, Datos_GB.Width, Datos_GB.Height);

        }

        #endregion



    }
}

