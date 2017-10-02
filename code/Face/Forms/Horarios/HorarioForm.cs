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
    public partial class HorarioForm : ItemMngSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 15; } }

        protected bool _generado = false;
        protected bool relleno_automatico = false;

        protected Library.Instruction.HComboBoxSourceList _combo_planes;
        protected Library.Instruction.HComboBoxSourceList _combo_clases;
        protected Library.Instruction.HComboBoxSourceList _combo_instructores;
        protected DateTime _day = DateTime.Today;

        // Listas de controles para acceso más simple a los mismos 
        public List<Control> _sesiones = new List<Control>();
        protected List<CheckBox> _impartidas = new List<CheckBox>();
        protected List<ComboBox> _combos = new List<ComboBox>();

        // Lista de sesiones asignadas
        protected ListaSesiones _lista_sesiones;

        // Lista de _profesores 
        protected InstructorList _profesores;

        //lista de parejas profesor-módulo que ya han sido asignados para el plan y promoción actual
        protected ProfesoresModulos profesores_encargados = new ProfesoresModulos();

        // Lista de _profesores asignados
        protected List<ListaSesiones> _instructores_asignados;
        protected SesionAuxiliar _modificada = null;

        //Lista de clases asignadas que se han desechado
        protected List<SesionNoAsignable> _no_asignables = null;

        protected List<ClasePracticaList> _practicas = new List<ClasePracticaList>();
        protected ClaseTeoricaList _teoricas = null;
        protected ClaseExtraList _extras = null;

        //Lista de clave-valor con las disponibilidades de los profesores asociados a la promoción seleccionada
        //en la semana seleccionada
        protected SortedDictionary<long, DisponibilidadInfo> _disponibilidades = null;

        // Listas auxiliares de datos
        protected PlanEstudiosList _planes;
        protected PromocionList _promociones;
        protected ModuloList _modulos = null;
        protected Submodulo_Instructor_PromocionList _submodulos = null;

        protected HDataSourceList _source_list_l;
        protected HDataSourceList _source_list_m;
        protected HDataSourceList _source_list_x;
        protected HDataSourceList _source_list_j;
        protected HDataSourceList _source_list_v;
        protected HDataSourceList _source_list_s;

        public virtual Horario Entity { get { return null; } set { } }
        public virtual HorarioInfo EntityInfo { get { return Entity.GetInfo(true); } }

        /// <summary>
        /// Devuelve el objeto activo de la tabla
        /// </summary>
        /// <returns></returns>
        public SesionAuxiliar CurrentSesion_L { get { return Horario_Lunes_Grid.CurrentRow != null ? ((SesionAuxiliar)Horario_Lunes_Grid.CurrentRow.DataBoundItem) : null; } }


        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveComboClase_L
        {
            get
            {
                return Horario_Lunes_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Clases.Current).Oid : 0;
            }
        }

        /// <summary>
        /// Devuelve el OID del instructor activo seleccionado en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveComboInstructor_L
        {
            get
            {
                return Horario_Lunes_Grid.CurrentRow != null
                    && _source_list_l.CBList.Count > 0
                    && _source_list_l.CombosListCount > Horario_Lunes_Grid.CurrentRow.Index ? _source_list_l.GetCurrentChild(Horario_Lunes_Grid.CurrentRow.Index).Oid : -1;
            }
        }

        /// <summary>
        /// Devuelve el objeto activo de la tabla
        /// </summary>
        /// <returns></returns>
        public SesionAuxiliar CurrentSesion_M { get { return Horario_Martes_Grid.CurrentRow != null ? ((SesionAuxiliar)Horario_Martes_Grid.CurrentRow.DataBoundItem) : null; } }


        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del martes
        /// </summary>
        /// <returns></returns>
        public long ActiveComboClase_M
        {
            get
            {
                return Horario_Martes_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Clases.Current).Oid : 0;
            }
        }

        /// <summary>
        /// Devuelve el OID del instructor activo seleccionado en la fila actual del martes
        /// </summary>
        /// <returns></returns>
        public long ActiveComboInstructor_M
        {
            get
            {
                return Horario_Martes_Grid.CurrentRow != null
                    && _source_list_m.CBList.Count > 0
                    && _source_list_m.CombosListCount > Horario_Martes_Grid.CurrentRow.Index ? _source_list_m.GetCurrentChild(Horario_Martes_Grid.CurrentRow.Index).Oid : -1;
            }
        }

        /// <summary>
        /// Devuelve el objeto activo de la tabla
        /// </summary>
        /// <returns></returns>
        public SesionAuxiliar CurrentSesion_X { get { return Horario_Miercoles_Grid.CurrentRow != null ? ((SesionAuxiliar)Horario_Miercoles_Grid.CurrentRow.DataBoundItem) : null; } }


        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del miercoles
        /// </summary>
        /// <returns></returns>
        public long ActiveComboClase_X
        {
            get
            {
                return Horario_Miercoles_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Clases.Current).Oid : 0;
            }
        }

        /// <summary>
        /// Devuelve el OID del instructor activo seleccionado en la fila actual del miercoles
        /// </summary>
        /// <returns></returns>
        public long ActiveComboInstructor_X
        {
            get
            {
                return Horario_Miercoles_Grid.CurrentRow != null
                    && _source_list_x.CBList.Count > 0
                    && _source_list_x.CombosListCount > Horario_Miercoles_Grid.CurrentRow.Index ? _source_list_x.GetCurrentChild(Horario_Miercoles_Grid.CurrentRow.Index).Oid : -1;
            }
        }

        /// <summary>
        /// Devuelve el objeto activo de la tabla
        /// </summary>
        /// <returns></returns>
        public SesionAuxiliar CurrentSesion_J { get { return Horario_Jueves_Grid.CurrentRow != null ? ((SesionAuxiliar)Horario_Jueves_Grid.CurrentRow.DataBoundItem) : null; } }


        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del jueves
        /// </summary>
        /// <returns></returns>
        public long ActiveComboClase_J
        {
            get
            {
                return Horario_Jueves_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Clases.Current).Oid : 0;
            }
        }

        /// <summary>
        /// Devuelve el OID del instructor activo seleccionado en la fila actual del jueves
        /// </summary>
        /// <returns></returns>
        public long ActiveComboInstructor_J
        {
            get
            {
                return Horario_Jueves_Grid.CurrentRow != null
                    && _source_list_j.CBList.Count > 0
                    && _source_list_j.CombosListCount > Horario_Jueves_Grid.CurrentRow.Index ? _source_list_j.GetCurrentChild(Horario_Jueves_Grid.CurrentRow.Index).Oid : -1;
            }
        }

        /// <summary>
        /// Devuelve el objeto activo de la tabla
        /// </summary>
        /// <returns></returns>
        public SesionAuxiliar CurrentSesion_V { get { return Horario_Viernes_Grid.CurrentRow != null ? ((SesionAuxiliar)Horario_Viernes_Grid.CurrentRow.DataBoundItem) : null; } }


        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del viernes
        /// </summary>
        /// <returns></returns>
        public long ActiveComboClase_V
        {
            get
            {
                return Horario_Viernes_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Clases.Current).Oid : 0;
            }
        }

        /// <summary>
        /// Devuelve el OID del instructor activo seleccionado en la fila actual del viernes
        /// </summary>
        /// <returns></returns>
        public long ActiveComboInstructor_V
        {
            get
            {
                return Horario_Viernes_Grid.CurrentRow != null
                    && _source_list_v.CBList.Count > 0
                    && _source_list_v.CombosListCount > Horario_Viernes_Grid.CurrentRow.Index ? _source_list_v.GetCurrentChild(Horario_Viernes_Grid.CurrentRow.Index).Oid : -1;
            }
        }

        /// <summary>
        /// Devuelve el objeto activo de la tabla
        /// </summary>
        /// <returns></returns>
        public SesionAuxiliar CurrentSesion_S { get { return Horario_Sabado_Grid.CurrentRow != null ? ((SesionAuxiliar)Horario_Sabado_Grid.CurrentRow.DataBoundItem) : null; } }


        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del sabado
        /// </summary>
        /// <returns></returns>
        public long ActiveComboClase_S
        {
            get
            {
                return Horario_Sabado_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Clases.Current).Oid : 0;
            }
        }

        /// <summary>
        /// Devuelve el OID del instructor activo seleccionado en la fila actual del sabado
        /// </summary>
        /// <returns></returns>
        public long ActiveComboInstructor_S
        {
            get
            {
                return Horario_Sabado_Grid.CurrentRow != null
                    && _source_list_s.CBList.Count > 0
                    && _source_list_s.CombosListCount > Horario_Sabado_Grid.CurrentRow.Index ? _source_list_s.GetCurrentChild(Horario_Sabado_Grid.CurrentRow.Index).Oid : -1;
            }
        }


        /// <summary>
        /// Añade una lista de valores de combobox a la lista de combos
        /// </summary>
        protected void AddComboList(string gridName)
        {
            switch (gridName)
            {
                case "Horario_Lunes_Grid":
                    {
                        if (_source_list_l.CombosListCount < Horario_Lunes_Grid.Rows.Count)
                        {
                            for (long i = _source_list_l.CombosListCount; i < Horario_Lunes_Grid.Rows.Count; i++)
                            {
                                SesionAuxiliar aux = (SesionAuxiliar)Horario_Lunes_Grid.Rows[(int)i].DataBoundItem;
                                if (aux.OidClaseTeorica != 0)
                                    _source_list_l.AddCombosList(aux.OidClaseTeorica, this, 0, (int)i, aux.OidSubmodulo);
                                else
                                {
                                    if (aux.OidClasePractica != 0)
                                        _source_list_l.AddCombosList(aux.OidClasePractica, this, 1, (int)i, aux.OidSubmodulo);
                                    else
                                        _source_list_l.AddCombosList(aux.OidClaseExtra, this, 2, (int)i, aux.OidSubmodulo);
                                }
                                ((DataGridViewComboBoxCell)(Horario_Lunes_Grid["Instructor_L_CBC", (int)i])).DataSource = _source_list_l.GetCombosList((int)i);
                                Horario_Lunes_Grid["Instructor_L_CBC", (int)i].Value = aux.OidProfesor;

                            }
                            MarcaCasillas(Horario_Lunes_Grid.Name);
                        }
                    } break;
                case "Horario_Martes_Grid":
                    {
                        if (_source_list_m.CombosListCount < Horario_Martes_Grid.Rows.Count)
                        {
                            for (long i = _source_list_m.CombosListCount; i < Horario_Martes_Grid.Rows.Count; i++)
                            {
                                SesionAuxiliar aux = (SesionAuxiliar)Horario_Martes_Grid.Rows[(int)i].DataBoundItem;

                                if (aux.OidClaseTeorica != 0)
                                    _source_list_m.AddCombosList(aux.OidClaseTeorica, this, 0, (int)i + 14, aux.OidSubmodulo);
                                else
                                {
                                    if (((SesionAuxiliar)Horario_Martes_Grid.Rows[(int)i].DataBoundItem).OidClasePractica != 0)
                                        _source_list_m.AddCombosList(aux.OidClasePractica, this, 1, (int)i + 14, aux.OidSubmodulo);
                                    else
                                        _source_list_m.AddCombosList(aux.OidClaseExtra, this, 2, (int)i + 14, aux.OidSubmodulo);
                                }
                                ((DataGridViewComboBoxCell)(Horario_Martes_Grid["Instructor_M_CBC", (int)i])).DataSource = _source_list_m.GetCombosList((int)i);
                                Horario_Martes_Grid["Instructor_M_CBC", (int)i].Value = aux.OidProfesor;

                            }
                            MarcaCasillas(Horario_Martes_Grid.Name);
                        }
                    } break;
                case "Horario_Miercoles_Grid":
                    {
                        if (_source_list_x.CombosListCount < Horario_Miercoles_Grid.Rows.Count)
                        {
                            for (long i = _source_list_x.CombosListCount; i < Horario_Miercoles_Grid.Rows.Count; i++)
                            {
                                SesionAuxiliar aux = (SesionAuxiliar)Horario_Miercoles_Grid.Rows[(int)i].DataBoundItem;

                                if (((SesionAuxiliar)Horario_Miercoles_Grid.Rows[(int)i].DataBoundItem).OidClaseTeorica != 0)
                                    _source_list_x.AddCombosList(aux.OidClaseTeorica, this, 0, (int)i + 28, aux.OidSubmodulo);
                                else
                                {
                                    if (((SesionAuxiliar)Horario_Miercoles_Grid.Rows[(int)i].DataBoundItem).OidClasePractica != 0)
                                        _source_list_x.AddCombosList(aux.OidClasePractica, this, 1, (int)i + 28, aux.OidSubmodulo);
                                    else
                                        _source_list_x.AddCombosList(aux.OidClaseExtra, this, 2, (int)i + 28, aux.OidSubmodulo);
                                }
                                ((DataGridViewComboBoxCell)(Horario_Miercoles_Grid["Instructor_X_CBC", (int)i])).DataSource = _source_list_x.GetCombosList((int)i);
                                Horario_Miercoles_Grid["Instructor_X_CBC", (int)i].Value = aux.OidProfesor;


                            }
                            MarcaCasillas(Horario_Miercoles_Grid.Name);
                        }
                    } break;
                case "Horario_Jueves_Grid":
                    {
                        if (_source_list_j.CombosListCount < Horario_Jueves_Grid.Rows.Count)
                        {
                            for (long i = _source_list_j.CombosListCount; i < Horario_Jueves_Grid.Rows.Count; i++)
                            {
                                SesionAuxiliar aux = (SesionAuxiliar)Horario_Jueves_Grid.Rows[(int)i].DataBoundItem;

                                if (((SesionAuxiliar)Horario_Jueves_Grid.Rows[(int)i].DataBoundItem).OidClaseTeorica != 0)
                                    _source_list_j.AddCombosList(aux.OidClaseTeorica, this, 0, (int)i + 42, aux.OidSubmodulo);
                                else
                                {
                                    if (((SesionAuxiliar)Horario_Jueves_Grid.Rows[(int)i].DataBoundItem).OidClasePractica != 0)
                                        _source_list_j.AddCombosList(aux.OidClasePractica, this, 1, (int)i + 42, aux.OidSubmodulo);
                                    else
                                        _source_list_j.AddCombosList(aux.OidClaseExtra, this, 2, (int)i + 42, aux.OidSubmodulo);
                                }
                                ((DataGridViewComboBoxCell)(Horario_Jueves_Grid["Instructor_J_CBC", (int)i])).DataSource = _source_list_j.GetCombosList((int)i);
                                Horario_Jueves_Grid["Instructor_J_CBC", (int)i].Value = aux.OidProfesor;

                            }
                            MarcaCasillas(Horario_Jueves_Grid.Name);
                        }
                    } break;
                case "Horario_Viernes_Grid":
                    {
                        if (_source_list_v.CombosListCount < Horario_Viernes_Grid.Rows.Count)
                        {
                            for (long i = _source_list_v.CombosListCount; i < Horario_Viernes_Grid.Rows.Count; i++)
                            {
                                SesionAuxiliar aux = (SesionAuxiliar)Horario_Viernes_Grid.Rows[(int)i].DataBoundItem;

                                if (((SesionAuxiliar)Horario_Viernes_Grid.Rows[(int)i].DataBoundItem).OidClaseTeorica != 0)
                                    _source_list_v.AddCombosList(aux.OidClaseTeorica, this, 0, (int)i + 56, aux.OidSubmodulo);
                                else
                                {
                                    if (((SesionAuxiliar)Horario_Viernes_Grid.Rows[(int)i].DataBoundItem).OidClasePractica != 0)
                                        _source_list_v.AddCombosList(aux.OidClasePractica, this, 1, (int)i + 56, aux.OidSubmodulo);
                                    else
                                        _source_list_v.AddCombosList(aux.OidClaseExtra, this, 2, (int)i + 56, aux.OidSubmodulo);
                                }
                                ((DataGridViewComboBoxCell)(Horario_Viernes_Grid["Instructor_V_CBC", (int)i])).DataSource = _source_list_v.GetCombosList((int)i);
                                Horario_Viernes_Grid["Instructor_V_CBC", (int)i].Value = aux.OidProfesor;

                            }
                            MarcaCasillas(Horario_Viernes_Grid.Name);
                        }
                    } break;
                case "Horario_Sabado_Grid":
                    {
                        if (_source_list_s.CombosListCount < Horario_Sabado_Grid.Rows.Count)
                        {
                            for (long i = _source_list_s.CombosListCount; i < Horario_Sabado_Grid.Rows.Count; i++)
                            {
                                SesionAuxiliar aux = (SesionAuxiliar)Horario_Sabado_Grid.Rows[(int)i].DataBoundItem;

                                if (((SesionAuxiliar)Horario_Sabado_Grid.Rows[(int)i].DataBoundItem).OidClaseTeorica != 0)
                                    _source_list_s.AddCombosList(aux.OidClaseTeorica, this, 0, (int)i + 70, aux.OidSubmodulo);
                                else
                                {
                                    if (((SesionAuxiliar)Horario_Sabado_Grid.Rows[(int)i].DataBoundItem).OidClasePractica != 0)
                                        _source_list_s.AddCombosList(aux.OidClasePractica, this, 1, (int)i + 70, aux.OidSubmodulo);
                                    else
                                        _source_list_s.AddCombosList(aux.OidClaseExtra, this, 2, (int)i + 70, aux.OidSubmodulo);
                                }
                                ((DataGridViewComboBoxCell)(Horario_Sabado_Grid["Instructor_S_CBC", (int)i])).DataSource = _source_list_s.GetCombosList((int)i);
                                Horario_Sabado_Grid["Instructor_S_CBC", (int)i].Value = aux.OidProfesor;

                            }
                            MarcaCasillas(Horario_Sabado_Grid.Name);
                        }
                    } break;
            }
        }

        #endregion

        #region Factory Methods

        public HorarioForm() : this(-1, true, null) { }

        public HorarioForm(bool isModal, Form parent) : this(-1, isModal, parent) { }

        public HorarioForm(long oid, Form parent) : this(oid, true, parent) { }

        public HorarioForm(long oid, bool ismodal, Form parent)
            : base(oid, ismodal)
        {
            InitializeComponent();
            _practicas.Add(new ClasePracticaList());
        }

        #endregion

        #region IBackGroundLauncher

        protected new enum BackJob { GetFormData, NuevoHorario, Refrescar, Promociones, Horario }
        protected new BackJob _back_job = BackJob.GetFormData;

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            NPracticas.Enabled = false;

            List<string> visibles_l = new List<string>();

            visibles_l.Add(Clase_L_CBC.Name);
            visibles_l.Add(Instructor_L_CBC.Name);
            visibles_l.Add(Impartida_L.Name);

            ControlTools.ShowDataGridColumns(Horario_Lunes_Grid, visibles_l);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Horario_Lunes_Grid.Width - vs.Width
                                                - Horario_Lunes_Grid.RowHeadersWidth
                                                - Horario_Lunes_Grid.Columns[Clase_L_CBC.Name].Width
                                                - Horario_Lunes_Grid.Columns[Instructor_L_CBC.Name].Width
                                                - Horario_Lunes_Grid.Columns[Impartida_L.Name].Width);

            CurrencyManager cm = (CurrencyManager)BindingContext[Horario_Lunes_Grid.DataSource];
            cm.SuspendBinding();

            List<string> visibles_m = new List<string>();

            visibles_m.Add(Clase_M_CBC.Name);
            visibles_m.Add(Instructor_M_CBC.Name);
            visibles_m.Add(Impartida_M.Name);

            ControlTools.ShowDataGridColumns(Horario_Martes_Grid, visibles_m);

            rowWidth = (int)(Horario_Martes_Grid.Width - vs.Width
                                                - Horario_Martes_Grid.RowHeadersWidth
                                                - Horario_Martes_Grid.Columns[Clase_M_CBC.Name].Width
                                                - Horario_Martes_Grid.Columns[Instructor_M_CBC.Name].Width
                                                - Horario_Martes_Grid.Columns[Impartida_M.Name].Width);


            cm = (CurrencyManager)BindingContext[Horario_Martes_Grid.DataSource];
            cm.SuspendBinding();

            List<string> visibles_x = new List<string>();

            visibles_x.Add(Clase_X_CBC.Name);
            visibles_x.Add(Instructor_X_CBC.Name);
            visibles_x.Add(Impartida_X.Name);

            ControlTools.ShowDataGridColumns(Horario_Miercoles_Grid, visibles_x);

            rowWidth = (int)(Horario_Miercoles_Grid.Width - vs.Width
                                                - Horario_Miercoles_Grid.RowHeadersWidth
                                                - Horario_Miercoles_Grid.Columns[Clase_X_CBC.Name].Width
                                                - Horario_Miercoles_Grid.Columns[Instructor_X_CBC.Name].Width
                                                - Horario_Miercoles_Grid.Columns[Impartida_X.Name].Width);


            cm = (CurrencyManager)BindingContext[Horario_Miercoles_Grid.DataSource];
            cm.SuspendBinding();

            List<string> visibles_j = new List<string>();

            visibles_j.Add(Clase_J_CBC.Name);
            visibles_j.Add(Instructor_J_CBC.Name);
            visibles_j.Add(Impartida_J.Name);

            ControlTools.ShowDataGridColumns(Horario_Jueves_Grid, visibles_j);

            rowWidth = (int)(Horario_Jueves_Grid.Width - vs.Width
                                                - Horario_Jueves_Grid.RowHeadersWidth
                                                - Horario_Jueves_Grid.Columns[Clase_J_CBC.Name].Width
                                                - Horario_Jueves_Grid.Columns[Instructor_J_CBC.Name].Width
                                                - Horario_Jueves_Grid.Columns[Impartida_J.Name].Width);


            cm = (CurrencyManager)BindingContext[Horario_Jueves_Grid.DataSource];
            cm.SuspendBinding();

            List<string> visibles_v = new List<string>();

            visibles_v.Add(Clase_V_CBC.Name);
            visibles_v.Add(Instructor_V_CBC.Name);
            visibles_v.Add(Impartida_V.Name);

            ControlTools.ShowDataGridColumns(Horario_Viernes_Grid, visibles_v);

            rowWidth = (int)(Horario_Viernes_Grid.Width - vs.Width
                                                - Horario_Viernes_Grid.RowHeadersWidth
                                                - Horario_Viernes_Grid.Columns[Clase_V_CBC.Name].Width
                                                - Horario_Viernes_Grid.Columns[Instructor_V_CBC.Name].Width
                                                - Horario_Viernes_Grid.Columns[Impartida_V.Name].Width);


            cm = (CurrencyManager)BindingContext[Horario_Viernes_Grid.DataSource];
            cm.SuspendBinding();

            List<string> visibles_s = new List<string>();

            visibles_s.Add(Clase_S_CBC.Name);
            visibles_s.Add(Instructor_S_CBC.Name);
            visibles_s.Add(Impartida_S.Name);

            ControlTools.ShowDataGridColumns(Horario_Sabado_Grid, visibles_s);

            rowWidth = (int)(Horario_Sabado_Grid.Width - vs.Width
                                                - Horario_Sabado_Grid.RowHeadersWidth
                                                - Horario_Sabado_Grid.Columns[Clase_S_CBC.Name].Width
                                                - Horario_Sabado_Grid.Columns[Instructor_S_CBC.Name].Width
                                                - Horario_Sabado_Grid.Columns[Impartida_S.Name].Width);

            cm = (CurrencyManager)BindingContext[Horario_Sabado_Grid.DataSource];
            cm.SuspendBinding();
        }

        public override void RefreshSecondaryData()
        {
            _modulos = ModuloList.GetList(false);
            PgMng.Grow(string.Empty, "Modulos");

            _submodulos = Submodulo_Instructor_PromocionList.GetList();
            PgMng.Grow();
        }

        public virtual ComboBoxSourceList RellenaComboInstructores(long oid, long tipo, int index, long oid_submodulo) { return null; }
        
        //private void SetSesion(long oid, long tipo, int index, int grupo)
        //{
        //    string modulo = Horario.ObtieneNombreModulo(oid, tipo, _teoricas, _practicas, _extras, _modulos);

        //    if (_lista_sesiones == null)
        //        MessageBox.Show("Seleccione primero la fecha para la que desea generar el horario.");
        //    else
        //    {
        //        RellenaComboInstructores(oid, tipo, index, 0);

        //        if (_combo_clases.Childs != null && _combo_clases.Childs.Count == 1 && oid != -2)
        //        {
        //            MessageBox.Show("No hay _profesores disponibles para impartir la clase seleccionada.");
        //            _combos[index].SelectedIndex = 0;
        //            return;
        //        }

        //        if (oid != -2 && _lista_sesiones[index].Estado != 1)
        //            Horario.LiberarClase(index, _lista_sesiones, _practicas, _teoricas, _extras);


        //        int cont_index = 0;

        //        if (index % 2 == 0)
        //            cont_index = index + 1;
        //        else
        //            cont_index = index - 1;

        //        if (tipo.Equals(1)) //clase práctica
        //        {

        //            if (_lista_sesiones[cont_index].Grupo == grupo)
        //            {
        //                MessageBox.Show("Ya hay una práctica asignada para el grupo seleccionado el mismo día");
        //                _combos[index].SelectedIndex = 0;
        //                return;
        //            }

        //            if (_lista_sesiones[cont_index].OidClasePractica == 0)
        //            {
        //                Horario.LiberarClase(cont_index, _lista_sesiones, _practicas, _teoricas, _extras);
        //                _lista_sesiones[cont_index].AsignaClaseASesion((ClaseTeoricaInfo)null);
        //            }
        //            Horario.LiberarClase(index, _lista_sesiones, _practicas, _teoricas, _extras);

        //            foreach (ClasePracticaList lista in _practicas)
        //            {
        //                foreach (ClasePracticaInfo clase in lista)
        //                {
        //                    if (clase.Oid == oid)
        //                    {
        //                        clase.Estado = 2;
        //                        _lista_sesiones[index].AsignaClaseASesion(clase);
        //                        _lista_sesiones[index].Forzada = true;
        //                        _lista_sesiones[index].Seleccionada = true;
        //                        _lista_sesiones[index].Grupo = grupo;
        //                    }

        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (_lista_sesiones[cont_index].OidClasePractica != 0)
        //            {
        //                Horario.LiberarClase(cont_index, _lista_sesiones, _practicas, _teoricas, _extras);
        //                _lista_sesiones[cont_index].AsignaClaseASesion((ClaseTeoricaInfo)null);
        //                _lista_sesiones[cont_index].Forzada = true;
        //            }
        //            if (tipo.Equals(0)) //clase teórica
        //            {
        //                if (oid < 0)
        //                {
        //                    _lista_sesiones[index].AsignaClaseASesion((ClaseTeoricaInfo)null);
        //                    if (oid == -1)
        //                    {
        //                        _lista_sesiones[index].Forzada = true;
        //                        _lista_sesiones[index].Estado = 3;
        //                    }
        //                    else
        //                    {
        //                        if (oid == -2) _lista_sesiones[index].Estado = 1;
        //                        _lista_sesiones[index].Forzada = false;
        //                    }
        //                }
        //                else
        //                {
        //                    foreach (ClaseTeoricaInfo clase in _teoricas)
        //                    {
        //                        if (clase.Oid == oid)
        //                        {
        //                            clase.Estado = 2;
        //                            _lista_sesiones[index].AsignaClaseASesion(clase);
        //                            _lista_sesiones[index].Grupo = 3;
        //                            _lista_sesiones[index].Forzada = true;
        //                            _lista_sesiones[index].Seleccionada = true;
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            else //clase extra
        //            {
        //                foreach (ClaseExtraInfo clase in _extras)
        //                {
        //                    if (clase.Oid == oid)
        //                    {
        //                        clase.Estado = 2;
        //                        _lista_sesiones[index].AsignaClaseASesion(clase);
        //                        _lista_sesiones[index].Forzada = true;
        //                        _lista_sesiones[index].Seleccionada = true;
        //                    }
        //                }
        //            }
        //        }

        //        //si la clase que se ha seleccionado manualmente ya estuviera asignada a otra sesión, habrá que liberarla

        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (i != index && _lista_sesiones[i].OidClaseTeorica == _lista_sesiones[index].OidClaseTeorica
        //                && _lista_sesiones[i].OidClasePractica == _lista_sesiones[index].OidClasePractica
        //                && _lista_sesiones[i].OidClaseExtra == _lista_sesiones[index].OidClaseExtra)
        //            {
        //                if (tipo.Equals(1))
        //                {
        //                    if (grupo == _lista_sesiones[i].Grupo)
        //                        _lista_sesiones[i].AsignaClaseASesion((ClaseTeoricaInfo)null);
        //                }
        //                else
        //                    _lista_sesiones[i].AsignaClaseASesion((ClaseTeoricaInfo)null);
        //            }
        //        }

        //        MarcaCasillas("");
        //    }
        //    _combos[index].SelectedIndex = 0;
        //    if (_generado) Completar_BT.Enabled = true;
        //}

        public void RellenaCasillas()
        {
            int i = 0;
            DateTime fecha;
            moleQule.Library.Timer t = new moleQule.Library.Timer();
            t.Start();

            fecha = EntityInfo.FechaInicial;

            if (_profesores == null)
                _profesores = InstructorList.GetInstructoresHorariosList(EntityInfo.OidPromocion, EntityInfo.FechaInicial, EntityInfo.FechaFinal);

            _source_list_l = new HDataSourceList(_combo_clases);
            Datos_Clases.DataSource = _source_list_l.CBList;
            _source_list_m = new HDataSourceList(_combo_clases);
            _source_list_x = new HDataSourceList(_combo_clases);
            _source_list_j = new HDataSourceList(_combo_clases);
            _source_list_v = new HDataSourceList(_combo_clases);
            _source_list_s = new HDataSourceList(_combo_clases);

            ListaSesiones lunes = new ListaSesiones();
            ListaSesiones martes = new ListaSesiones();
            ListaSesiones miercoles = new ListaSesiones();
            ListaSesiones jueves = new ListaSesiones();
            ListaSesiones viernes = new ListaSesiones();
            ListaSesiones sabado = new ListaSesiones();

            i = 0;
            while (i < 14)
                lunes.Add(_lista_sesiones[i++]);
            while (i < 28)
                martes.Add(_lista_sesiones[i++]);
            while (i < 42)
                miercoles.Add(_lista_sesiones[i++]);
            while (i < 56)
                jueves.Add(_lista_sesiones[i++]);
            while (i < 70)
                viernes.Add(_lista_sesiones[i++]);
            while (i < 75)
                sabado.Add(_lista_sesiones[i++]);

            Datos_Lunes.DataSource = lunes;
            Datos_Martes.DataSource = martes;
            Datos_Miercoles.DataSource = miercoles;
            Datos_Jueves.DataSource = jueves;
            Datos_Viernes.DataSource = viernes;
            Datos_Sabado.DataSource = sabado;

            relleno_automatico = true;
            SetUnlinkedGridValues(Horario_Lunes_Grid.Name);
            SetUnlinkedGridValues(Horario_Martes_Grid.Name);
            SetUnlinkedGridValues(Horario_Miercoles_Grid.Name);
            SetUnlinkedGridValues(Horario_Jueves_Grid.Name);
            SetUnlinkedGridValues(Horario_Viernes_Grid.Name);
            SetUnlinkedGridValues(Horario_Sabado_Grid.Name);

            AddComboList(Horario_Lunes_Grid.Name);
            AddComboList(Horario_Martes_Grid.Name);
            AddComboList(Horario_Miercoles_Grid.Name);
            AddComboList(Horario_Jueves_Grid.Name);
            AddComboList(Horario_Viernes_Grid.Name);
            AddComboList(Horario_Sabado_Grid.Name);
            relleno_automatico = false;

            PgMng.FillUp();
        }

        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Horario_Lunes_Grid":
                    {
                        if (Horario_Lunes_Grid.Rows.Count == 0) return;
                        for (int i = 0; i < 14; i++)
                        {
                            DataGridViewRow row = Horario_Lunes_Grid.Rows[i];
                            SesionAuxiliar item = (SesionAuxiliar)row.DataBoundItem;
                            if (item.Forzada && item.Estado == 2 && item.OidClaseTeorica == -1)
                            {
                                Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(-1, 0));
                                row.Cells[Clase_L_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                            }
                            else
                            {
                                if (item.OidClaseTeorica != 0)
                                {
                                    Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseTeorica, 0));
                                    row.Cells[Clase_L_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                }
                                else
                                {
                                    if (item.OidClaseExtra != 0
                                        && (item.OidClaseExtra != _lista_sesiones[i].OidClaseExtra
                                        || row.Cells[Clase_L_CBC.Name].Value == null
                                        || row.Cells[Clase_L_CBC.Name].Value.ToString() == ""))
                                    {
                                        Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseExtra, 2));
                                        row.Cells[Clase_L_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                    }
                                    else
                                    {
                                        if (item.OidClasePractica != 0
                                            && ((item.OidClasePractica != _lista_sesiones[i].OidClasePractica
                                            && item.Grupo != _lista_sesiones[i].Grupo)
                                            || row.Cells[Clase_L_CBC.Name].Value == null
                                            || row.Cells[Clase_L_CBC.Name].Value.ToString() == ""))
                                        {
                                            Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClasePractica, 1, " G" + item.Grupo.ToString()));
                                            row.Cells[Clase_L_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Texto;
                                        }
                                    }
                                }
                            }
                            if (item.Estado == 3)
                                row.Cells[Impartida_L.Name].Value = true;
                            row.Cells[Instructor_L_CBC.Name].Value = _lista_sesiones[i].OidProfesor;
                        }
                    } break;
                case "Horario_Martes_Grid":
                    {
                        if (Horario_Martes_Grid.Rows.Count == 0) return;
                        for (int i = 0; i < 14; i++)
                        {
                            DataGridViewRow row = Horario_Martes_Grid.Rows[i];
                            SesionAuxiliar item = (SesionAuxiliar)row.DataBoundItem;
                            if (item.Forzada && item.Estado == 2 && item.OidClaseTeorica == -1)
                            {
                                Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(-1, 0));
                                row.Cells[Clase_M_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                            }
                            else
                            {
                                if (item.OidClaseTeorica != 0)
                                {
                                    Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseTeorica, 0));
                                    row.Cells[Clase_M_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                }
                                else
                                {
                                    if (item.OidClaseExtra != 0
                                        && (item.OidClaseExtra != _lista_sesiones[i + 14].OidClaseExtra
                                        || row.Cells[Clase_M_CBC.Name].Value == null
                                        || row.Cells[Clase_M_CBC.Name].Value.ToString() == ""))
                                    {
                                        Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseExtra, 2));
                                        row.Cells[Clase_M_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                    }
                                    else
                                    {
                                        if (item.OidClasePractica != 0
                                            && ((item.OidClasePractica != _lista_sesiones[i + 14].OidClasePractica
                                            && item.Grupo != _lista_sesiones[i + 14].Grupo)
                                            || row.Cells[Clase_M_CBC.Name].Value == null
                                            || row.Cells[Clase_M_CBC.Name].Value.ToString() == ""))
                                        {
                                            Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClasePractica, 1, " G" + item.Grupo.ToString()));
                                            row.Cells[Clase_M_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Texto;
                                        }
                                    }
                                }
                            }
                            if (item.Estado == 3)
                                row.Cells[Impartida_M.Name].Value = true;
                            row.Cells[Instructor_M_CBC.Name].Value = _lista_sesiones[i + 14].OidProfesor;
                        }
                    } break;
                case "Horario_Miercoles_Grid":
                    {
                        if (Horario_Miercoles_Grid.Rows.Count == 0) return;
                        for (int i = 0; i < 14; i++)
                        {
                            DataGridViewRow row = Horario_Miercoles_Grid.Rows[i];
                            SesionAuxiliar item = (SesionAuxiliar)row.DataBoundItem;
                            if (item.Forzada && item.Estado == 2 && item.OidClaseTeorica == -1)
                            {
                                Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(-1, 0));
                                row.Cells[Clase_X_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                            }
                            else
                            {
                                if (item.OidClaseTeorica != 0)
                                {
                                    Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseTeorica, 0));
                                    row.Cells[Clase_X_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                }
                                else
                                {
                                    if (item.OidClaseExtra != 0
                                        && (item.OidClaseExtra != _lista_sesiones[i + 28].OidClaseExtra
                                        || row.Cells[Clase_X_CBC.Name].Value == null
                                        || row.Cells[Clase_X_CBC.Name].Value.ToString() == ""))
                                    {
                                        Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseExtra, 2));
                                        row.Cells[Clase_X_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                    }
                                    else
                                    {
                                        if (item.OidClasePractica != 0
                                            && ((item.OidClasePractica != _lista_sesiones[i + 28].OidClasePractica
                                            && item.Grupo != _lista_sesiones[i + 28].Grupo)
                                            || row.Cells[Clase_X_CBC.Name].Value == null
                                            || row.Cells[Clase_X_CBC.Name].Value.ToString() == ""))
                                        {
                                            Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClasePractica, 1, " G" + item.Grupo.ToString()));
                                            row.Cells[Clase_X_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Texto;
                                        }
                                    }
                                }
                            }
                            if (item.Estado == 3)
                                row.Cells[Impartida_X.Name].Value = true;
                            row.Cells[Instructor_X_CBC.Name].Value = _lista_sesiones[i + 28].OidProfesor;
                        }
                    } break;
                case "Horario_Jueves_Grid":
                    {
                        if (Horario_Jueves_Grid.Rows.Count == 0) return;
                        for (int i = 0; i < 14; i++)
                        {
                            DataGridViewRow row = Horario_Jueves_Grid.Rows[i];
                            SesionAuxiliar item = (SesionAuxiliar)row.DataBoundItem;
                            if (item.Forzada && item.Estado == 2 && item.OidClaseTeorica == -1)
                            {
                                Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(-1, 0));
                                row.Cells[Clase_J_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                            }
                            else
                            {
                                if (item.OidClaseTeorica != 0)
                                {
                                    Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseTeorica, 0));
                                    row.Cells[Clase_J_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                }
                                else
                                {
                                    if (item.OidClaseExtra != 0
                                        && (item.OidClaseExtra != _lista_sesiones[i + 42].OidClaseExtra
                                        || row.Cells[Clase_J_CBC.Name].Value == null
                                        || row.Cells[Clase_J_CBC.Name].Value.ToString() == ""))
                                    {
                                        Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseExtra, 2));
                                        row.Cells[Clase_J_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                    }
                                    else
                                    {
                                        if (item.OidClasePractica != 0
                                            && ((item.OidClasePractica != _lista_sesiones[i + 42].OidClasePractica
                                            && item.Grupo != _lista_sesiones[i + 42].Grupo)
                                            || row.Cells[Clase_J_CBC.Name].Value == null
                                            || row.Cells[Clase_J_CBC.Name].Value.ToString() == ""))
                                        {
                                            Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClasePractica, 1, " G" + item.Grupo.ToString()));
                                            row.Cells[Clase_J_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Texto;
                                        }
                                    }
                                }
                            }
                            if (item.Estado == 3)
                                row.Cells[Impartida_J.Name].Value = true;
                            row.Cells[Instructor_J_CBC.Name].Value = _lista_sesiones[i + 42].OidProfesor;
                        }
                    } break;
                case "Horario_Viernes_Grid":
                    {
                        if (Horario_Viernes_Grid.Rows.Count == 0) return;
                        for (int i = 0; i < 14; i++)
                        {
                            DataGridViewRow row = Horario_Viernes_Grid.Rows[i];
                            SesionAuxiliar item = (SesionAuxiliar)row.DataBoundItem;
                            if (item.Forzada && item.Estado == 2 && item.OidClaseTeorica == -1)
                            {
                                Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(-1, 0));
                                row.Cells[Clase_V_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                            }
                            else
                            {
                                if (item.OidClaseTeorica != 0)
                                {
                                    Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseTeorica, 0));
                                    row.Cells[Clase_V_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                }
                                else
                                {
                                    if (item.OidClaseExtra != 0
                                        && (item.OidClaseExtra != _lista_sesiones[i + 56].OidClaseExtra
                                        || row.Cells[Clase_V_CBC.Name].Value == null
                                        || row.Cells[Clase_V_CBC.Name].Value.ToString() == ""))
                                    {
                                        Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseExtra, 2));
                                        row.Cells[Clase_V_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                    }
                                    else
                                    {
                                        if (item.OidClasePractica != 0
                                            && ((item.OidClasePractica != _lista_sesiones[i + 56].OidClasePractica
                                            && item.Grupo != _lista_sesiones[i + 56].Grupo)
                                            || row.Cells[Clase_V_CBC.Name].Value == null
                                            || row.Cells[Clase_V_CBC.Name].Value.ToString() == ""))
                                        {
                                            Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClasePractica, 1, " G" + item.Grupo.ToString()));
                                            row.Cells[Clase_V_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Texto;
                                        }
                                    }
                                }
                            }
                            if (item.Estado == 3)
                                row.Cells[Impartida_V.Name].Value = true;
                            row.Cells[Instructor_V_CBC.Name].Value = _lista_sesiones[i + 56].OidProfesor;
                        }
                    } break;
                case "Horario_Sabado_Grid":
                    {
                        if (Horario_Sabado_Grid.Rows.Count == 0) return;
                        for (int i = 0; i < 5; i++)
                        {
                            DataGridViewRow row = Horario_Sabado_Grid.Rows[i];
                            SesionAuxiliar item = (SesionAuxiliar)row.DataBoundItem;
                            if (item.Forzada && item.Estado == 2 && item.OidClaseTeorica == -1)
                            {
                                Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(-1, 0));
                                row.Cells[Clase_S_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                            }
                            else
                            {
                                if (item.OidClaseTeorica != 0)
                                {
                                    Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseTeorica, 0));
                                    row.Cells[Clase_S_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                }
                                else
                                {
                                    if (item.OidClaseExtra != 0
                                        && (item.OidClaseExtra != _lista_sesiones[i + 70].OidClaseExtra
                                        || row.Cells[Clase_S_CBC.Name].Value == null
                                        || row.Cells[Clase_S_CBC.Name].Value.ToString() == ""))
                                    {
                                        Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClaseExtra, 2));
                                        row.Cells[Clase_S_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Oid;
                                    }
                                    else
                                    {
                                        if (item.OidClasePractica != 0
                                            && ((item.OidClasePractica != _lista_sesiones[i + 70].OidClasePractica
                                            && item.Grupo != _lista_sesiones[i + 70].Grupo)
                                            || row.Cells[Clase_S_CBC.Name].Value == null
                                            || row.Cells[Clase_S_CBC.Name].Value.ToString() == ""))
                                        {
                                            Datos_Clases.Position = _combo_clases.IndexOf(_combo_clases.Buscar(item.OidClasePractica, 1, " G" + item.Grupo.ToString()));
                                            row.Cells[Clase_S_CBC.Name].Value = ((ComboBoxSource)Datos_Clases.Current).Texto;
                                        }
                                    }
                                }
                            }
                            if (item.Estado == 3)
                                row.Cells[Impartida_S.Name].Value = true;
                            row.Cells[Instructor_S_CBC.Name].Value = _lista_sesiones[i + 70].OidProfesor;
                        }
                    } break;
            }
        }

        protected void MarcaCasillas(string gridName)
        {
            DataGridView tabla = null;

            switch (gridName)
            {
                case "Horario_Lunes_Grid":
                    {
                        tabla = Horario_Lunes_Grid;
                    } break;
                case "Horario_Martes_Grid":
                    {
                        tabla = Horario_Martes_Grid;
                    } break;
                case "Horario_Miercoles_Grid":
                    {
                        tabla = Horario_Miercoles_Grid;
                    } break;
                case "Horario_Jueves_Grid":
                    {
                        tabla = Horario_Jueves_Grid;
                    } break;
                case "Horario_Viernes_Grid":
                    {
                        tabla = Horario_Viernes_Grid;
                    } break;
                case "Horario_Sabado_Grid":
                    {
                        tabla = Horario_Sabado_Grid;
                    } break;
            }

            if (tabla.Rows.Count == 0 || tabla == null) return;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataGridViewRow row = tabla.Rows[i];
                SesionAuxiliar item = (SesionAuxiliar)row.DataBoundItem;
                if ((item.Estado == 1 && !item.Forzada)
                    || item.OidClaseTeorica == -1)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    tabla[1, i].Value = "";
                    tabla[2, i].Value = "";
                }
                else
                {
                    if (item.Forzada) row.DefaultCellStyle.BackColor = Color.PowderBlue;
                    else
                    {
                        if (item.Desordenada) row.DefaultCellStyle.BackColor = Color.LightSalmon;
                        else
                        {
                            if (_profesores != null)
                            {
                                if (item.OidProfesor != 0)
                                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                                foreach (InstructorInfo prof in _profesores)
                                {
                                    if (prof.Promociones != null)
                                    {
                                        bool salir = false;
                                        foreach (Instructor_PromocionInfo pr in prof.Promociones)
                                        {
                                            if (pr.OidPromocion == EntityInfo.OidPromocion)
                                            {
                                                foreach (Submodulo_Instructor_PromocionInfo sub in pr.Submodulos)
                                                {
                                                    if (sub.OidSubmodulo == item.OidSubmodulo
                                                        && prof.Oid == item.OidProfesor)
                                                    {
                                                        if (sub.Prioridad != 1)
                                                            row.DefaultCellStyle.BackColor = Color.Orange;
                                                        salir = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (salir) break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void PrintAction()
        {
            PrintObject();
        }

        protected virtual void CleanAction() { }
        protected virtual void ModificarPlanAction() { }
        protected virtual void ModificarInstructoresAction() { }
        protected virtual void VerDisponibilidadesAction() { }

        protected virtual void SelectClasesAction(SesionAuxiliar aux)
        {
            PgMng.Reset(6, 1, Resources.Messages.MODIFICANDO_CLASE, this);
            try
            {
                int index = _lista_sesiones.IndexOf(aux);

                ClasesPromocionSelectForm form = new ClasesPromocionSelectForm(true, this, _teoricas, ClasePracticaList.Merge(_practicas[1], _practicas[2]), _extras);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    List<ClaseGenericaInfo> selected_list = form.Selected as List<ClaseGenericaInfo>;
                    foreach (ClaseGenericaInfo info in selected_list)
                    {
                        aux = _lista_sesiones[index];
                        _modificada = new SesionAuxiliar();
                        _modificada.Copia(aux, false);
                        switch (info.ETipoClase)
                        {
                            case ETipoClase.Teorica:
                                {
                                    ClaseTeoricaInfo item = _teoricas.GetItem(info.Oid);
                                    aux.AsignaClaseASesion(item);
                                    aux.Forzada = true;
                                    item.Estado = 2;
                                } break;
                            case ETipoClase.Practica:
                                {
                                    long oid = Convert.ToInt64(info.Oid.ToString().Substring(2));
                                    ClasePracticaInfo item = _practicas[(int)info.Grupo].GetItem(oid);
                                    aux.AsignaClaseASesion(item);
                                    aux.Forzada = true;
                                    item.Estado = 2;

                                } break;
                            case ETipoClase.Extra:
                                {
                                    long oid = Convert.ToInt64(info.Oid.ToString().Substring(2));
                                    ClaseExtraInfo item = _extras.GetItem(oid);
                                    aux.AsignaClaseASesion(item);
                                    aux.Forzada = true;
                                    item.Estado = 2;
                                } break;
                        }

                        long oid_clase = 0;
                        if (aux.OidClaseTeorica != 0)
                            oid_clase = aux.OidClaseTeorica;
                        else
                        {
                            if (aux.OidClasePractica != 0)
                                oid_clase = aux.OidClasePractica;
                            else
                                oid_clase = aux.OidClaseExtra;
                        }
                        PgMng.Grow();

                        List<int> lista = new List<int>();

                        _lista_sesiones.CambiaClase(index, oid_clase,
                                    ((ComboBoxSource)Datos_Clases.Current).Tipo, aux.Grupo, lista);

                        if (_modificada != null)
                        {
                            oid_clase = 0;
                            long tipo = 0;

                            if (_modificada.OidClaseTeorica > 0)
                            {
                                oid_clase = _modificada.OidClaseTeorica;
                                tipo = 0;
                            }
                            else
                            {
                                if (_modificada.OidClasePractica > 0)
                                {
                                    oid_clase = _modificada.OidClasePractica;
                                    tipo = 1;
                                }
                                else
                                {
                                    if (_modificada.OidClaseExtra > 0)
                                    {
                                        oid_clase = _modificada.OidClaseExtra;
                                        tipo = 2;
                                    }
                                }
                            }

                            if (oid_clase != 0)
                                _lista_sesiones.CambiaClase(index, oid_clase, tipo, _modificada.Grupo, lista);
                        }
                        PgMng.Grow();

                        foreach (int indice in lista)
                        {
                            if (indice < 14)
                            {
                                Horario_Lunes_Grid["Clase_L_CBC", indice].Value = "";
                            }
                            else
                            {
                                if (indice < 28)
                                {
                                    Horario_Martes_Grid["Clase_M_CBC", indice - 14].Value = "";
                                }
                                else
                                {
                                    if (indice < 42)
                                    {
                                        Horario_Miercoles_Grid["Clase_X_CBC", indice - 28].Value = "";
                                    }
                                    else
                                    {
                                        if (indice < 56)
                                        {
                                            Horario_Jueves_Grid["Clase_J_CBC", indice - 42].Value = "";
                                        }
                                        else
                                        {
                                            if (indice < 70)
                                            {
                                                Horario_Viernes_Grid["Clase_V_CBC", indice - 56].Value = "";
                                            }
                                            else
                                            {
                                                Horario_Sabado_Grid["Clase_S_CBC", indice - 70].Value = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        PgMng.Grow();

                        if (lista.Count > 0)
                        {
                            Completar_BT.Enabled = true;
                            if (_lista_sesiones[index].OidClasePractica != 0
                                || _lista_sesiones[index].OidClaseExtra != 0
                                || _lista_sesiones[index].OidClaseTeorica == -1
                                || _lista_sesiones[index].OidClaseTeorica > 0)
                                _lista_sesiones[index].Forzada = true;
                            else _lista_sesiones[index].Forzada = false;
                        }
                        PgMng.Grow();

                        RellenaCasillas();

                        //sigue rellenando el resto de clase siempre que quepan en el mismo día
                        if (index % 14 != 14 && index < 74)
                            index++;
                        else
                            break;

                        PgMng.Grow();

                    }
                }
            }
            finally { PgMng.FillUp(); }
        }

        #endregion

        #region Events

        private void Clean_BT_Click(object sender, EventArgs e)
        {
            CleanAction();
        }

        private void Planes_BT_Click(object sender, EventArgs e)
        {
            ModificarPlanAction();
        }

        private void Disponibilidades_BT_Click(object sender, EventArgs e)
        {
            VerDisponibilidadesAction();
        }

        private void Instructores_BT_Click(object sender, EventArgs e)
        {
            ModificarInstructoresAction();
        }

        private void Plan_CB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetDependentControlSource(Plan_CB.Name);
        }

        private void Promocion_CB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetDependentControlSource(Promocion_CB.Name);
        }

        private void Practicas_CB_CheckedChanged(object sender, EventArgs e)
        {
            NPracticas.Enabled = Practicas_CB.Checked;
        }

        private void Fecha_DTP_CloseUp(object sender, EventArgs e)
        {
            SetDependentControlSource(Fecha_DTP.Name);
        }

        private void CLB_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;

            switch (CLB_1.SelectedIndex)
            {
                case 0:
                    {
                        Entity.H8AM = !Entity.H8AM;
                        CLB_1.SetItemChecked(0, Entity.H8AM);
                    } break;
                case 1:
                    {
                        Entity.H0 = !Entity.H0;
                        CLB_1.SetItemChecked(1, Entity.H0);
                    } break;
                case 2:
                    {
                        Entity.H1 = !Entity.H1;
                        CLB_1.SetItemChecked(2, Entity.H1);
                    } break;
                case 3:
                    {
                        Entity.H2 = !Entity.H2;
                        CLB_1.SetItemChecked(3, Entity.H2);
                    } break;
                case 4:
                    {
                        Entity.H3 = !Entity.H3;
                        CLB_1.SetItemChecked(4, Entity.H3);
                    } break;
                case 5:
                    {
                        Entity.H4 = !Entity.H4;
                        CLB_1.SetItemChecked(5, Entity.H4);
                    } break;
                case 6:
                    {
                        Entity.H5 = !Entity.H5;
                        CLB_1.SetItemChecked(6, Entity.H5);
                    } break;
                case 7:
                    {
                        Entity.H6 = !Entity.H6;
                        CLB_1.SetItemChecked(7, Entity.H6);
                    } break;
                case 8:
                    {
                        Entity.H7 = !Entity.H7;
                        CLB_1.SetItemChecked(8, Entity.H7);
                    } break;
                case 9:
                    {
                        Entity.H8 = !Entity.H8;
                        CLB_1.SetItemChecked(9, Entity.H8);
                    } break;
                case 10:
                    {
                        Entity.H9 = !Entity.H9;
                        CLB_1.SetItemChecked(10, Entity.H9);
                    } break;
                case 11:
                    {
                        Entity.H10 = !Entity.H10;
                        CLB_1.SetItemChecked(11, Entity.H10);
                    } break;
                case 12:
                    {
                        Entity.H11 = !Entity.H11;
                        CLB_1.SetItemChecked(12, Entity.H11);
                    } break;
                case 13:
                    {
                        Entity.H12 = !Entity.H12;
                        CLB_1.SetItemChecked(13, Entity.H12);
                    } break;
            }
        }

        private void CLB_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;
            switch (CLB_2.SelectedIndex)
            {
                case 0:
                    {
                        Entity.HS0 = !Entity.HS0;
                        CLB_2.SetItemChecked(0, Entity.HS0);
                    } break;
                case 1:
                    {
                        Entity.HS1 = !Entity.HS1;
                        CLB_2.SetItemChecked(1, Entity.HS1);
                    } break;
                case 2:
                    {
                        Entity.HS2 = !Entity.HS2;
                        CLB_2.SetItemChecked(2, Entity.HS2);
                    } break;
                case 3:
                    {
                        Entity.HS3 = !Entity.HS3;
                        CLB_2.SetItemChecked(3, Entity.HS3);
                    } break;
                case 4:
                    {
                        Entity.HS4 = !Entity.HS4;
                        CLB_2.SetItemChecked(4, Entity.HS4);
                    } break;
            }
        }

        private void Horario_Lunes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Horario_Lunes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (relleno_automatico) return;

            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex].Estado == 3
                && Horario_Lunes_Grid.Columns[e.ColumnIndex].Name == Clase_L_CBC.Name) return;

            switch (Horario_Lunes_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Clase_L_CBC":
                    {
                        if (ActiveComboClase_L != 0 && Horario_Lunes_Grid["Clase_L_CBC", e.RowIndex].Value != null)
                        {
                            PgMng.Reset(9, 1, Resources.Messages.MODIFICANDO_CLASE, this);

                            try
                            {
                                long grupo = 1;
                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Texto.Contains("G2"))
                                        grupo = 2;
                                }
                                PgMng.Grow();

                                if (ActiveComboClase_L == _lista_sesiones[e.RowIndex].OidClaseTeorica
                                    || ActiveComboClase_L == _lista_sesiones[e.RowIndex].OidClaseExtra
                                    || (ActiveComboClase_L == _lista_sesiones[e.RowIndex].OidClasePractica
                                    && grupo == _lista_sesiones[e.RowIndex].Grupo))
                                    return;
                                PgMng.Grow();

                                //hay que liberar la clase que estaba en esta posicion
                                //y quitar la clase seleccionada de donde estuviera
                                if (_lista_sesiones[e.RowIndex].Estado != 1)
                                {
                                    if (_lista_sesiones[e.RowIndex].OidClaseTeorica != 0)
                                    {
                                        if (_lista_sesiones[e.RowIndex].OidClaseTeorica > 0)
                                            _teoricas.GetItem(_lista_sesiones[e.RowIndex].OidClaseTeorica).Estado = 1;
                                    }
                                    else
                                    {
                                        if (_lista_sesiones[e.RowIndex].OidClasePractica != 0)
                                        {
                                            foreach (ClasePracticaList lista in _practicas)
                                            {
                                                foreach (ClasePracticaInfo info in lista)
                                                {
                                                    if (info.Oid == _lista_sesiones[e.RowIndex].OidClasePractica
                                                        && info.Grupo == _lista_sesiones[e.RowIndex].Grupo)
                                                        info.Estado = 1;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (_lista_sesiones[e.RowIndex].OidClaseExtra != 0)
                                                _extras.GetItem(_lista_sesiones[e.RowIndex].OidClaseExtra).Estado = 1;
                                        }
                                    }
                                }
                                PgMng.Grow();

                                long oid_submodulo = 0;

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (ActiveComboClase_L > 0)
                                        oid_submodulo = _teoricas.GetItem(ActiveComboClase_L).OidSubmodulo;
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 2)
                                        oid_submodulo = _extras.GetItem(ActiveComboClase_L).OidSubmodulo;
                                    else
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_L);
                                            if (info != null) break;
                                        }
                                        oid_submodulo = info.OidSubmodulo;
                                    }
                                }
                                PgMng.Grow();

                                //se está modificando una línea ya existente
                                if (_source_list_l.CombosListCount > e.RowIndex)
                                    _source_list_l.UpdateCombosList(e.RowIndex, ActiveComboClase_L, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, oid_submodulo);
                                else //hay que añadir un nuevo datasource a la lista
                                    _source_list_l.AddCombosList(ActiveComboClase_L, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, e.RowIndex, oid_submodulo);
                                PgMng.Grow();

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Oid > 0)
                                    {
                                        _lista_sesiones[e.RowIndex].AsignaClaseASesion(_teoricas.GetItem(ActiveComboClase_L));
                                        _teoricas.GetItem(ActiveComboClase_L).Estado = 2;
                                    }
                                    else
                                    {
                                        if (ActiveComboClase_L == -2)
                                        {
                                            //se marca la clase que se ha liberado como que no se puede dar en esta hora
                                            //se hace lo mismo con el profesor
                                            _no_asignables.Add(new SesionNoAsignable(e.RowIndex, _lista_sesiones[e.RowIndex].OidModulo, _lista_sesiones[e.RowIndex].OidProfesor));
                                        }
                                        _lista_sesiones[e.RowIndex].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                        if (ActiveComboClase_L == -1) _lista_sesiones[e.RowIndex].Estado = 2;
                                    }
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_L);
                                            if (info != null) break;
                                        }
                                        _lista_sesiones[e.RowIndex].AsignaClaseASesion(info);
                                        info.Estado = 2;
                                    }
                                    else
                                    {
                                        _lista_sesiones[e.RowIndex].AsignaClaseASesion(_extras.GetItem(ActiveComboClase_L));
                                        _extras.GetItem(ActiveComboClase_L).Estado = 2;
                                    }
                                }
                                ((DataGridViewComboBoxCell)(Horario_Lunes_Grid["Instructor_L_CBC", e.RowIndex])).DataSource = _source_list_l.GetCombosList(e.RowIndex);

                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex].OidClaseTeorica != 0
                                    || _lista_sesiones[e.RowIndex].OidClaseExtra != 0)
                                {
                                    List<int> lista = new List<int>();

                                    _lista_sesiones.CambiaClase(e.RowIndex, ActiveComboClase_L,
                                                 ((ComboBoxSource)Datos_Clases.Current).Tipo, grupo, lista);

                                    if (_modificada != null)
                                    {
                                        long oid_clase = 0;
                                        long tipo = 0;

                                        if (_modificada.OidClaseTeorica > 0)
                                        {
                                            oid_clase = _modificada.OidClaseTeorica;
                                            tipo = 0;
                                        }
                                        else
                                        {
                                            if (_modificada.OidClasePractica > 0)
                                            {
                                                oid_clase = _modificada.OidClasePractica;
                                                tipo = 1;
                                            }
                                            else
                                            {
                                                if (_modificada.OidClaseExtra > 0)
                                                {
                                                    oid_clase = _modificada.OidClaseExtra;
                                                    tipo = 2;
                                                }
                                            }
                                        }

                                        if (oid_clase != 0)
                                            _lista_sesiones.CambiaClase(e.RowIndex, oid_clase, tipo, _modificada.Grupo, lista);
                                    }

                                    foreach (int indice in lista)
                                    {
                                        if (indice < 14)
                                        {
                                            Horario_Lunes_Grid["Clase_L_CBC", indice].Value = "";
                                        }
                                        else
                                        {
                                            if (indice < 28)
                                            {
                                                Horario_Martes_Grid["Clase_M_CBC", indice - 14].Value = "";
                                            }
                                            else
                                            {
                                                if (indice < 42)
                                                {
                                                    Horario_Miercoles_Grid["Clase_X_CBC", indice - 28].Value = "";
                                                }
                                                else
                                                {
                                                    if (indice < 56)
                                                    {
                                                        Horario_Jueves_Grid["Clase_J_CBC", indice - 42].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (indice < 70)
                                                        {
                                                            Horario_Viernes_Grid["Clase_V_CBC", indice - 56].Value = "";
                                                        }
                                                        else
                                                        {
                                                            Horario_Sabado_Grid["Clase_S_CBC", indice - 70].Value = "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (lista.Count > 0)
                                        Completar_BT.Enabled = true;
                                }
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex].OidClaseExtra != 0
                                    || _lista_sesiones[e.RowIndex].OidClaseTeorica == -1
                                    || _lista_sesiones[e.RowIndex].OidClaseTeorica > 0
                                    || ActiveComboClase_L == -1)
                                    _lista_sesiones[e.RowIndex].Forzada = true;
                                else _lista_sesiones[e.RowIndex].Forzada = false;

                                if (ActiveComboClase_L == -2) Completar_BT.Enabled = true;
                                PgMng.Grow();

                                SetUnlinkedGridValues(Horario_Lunes_Grid.Name);
                            }
                            finally { PgMng.FillUp(); }
                        }
                    } break;

                case "Instructor_L_CBC":
                    {
                        if (ActiveComboInstructor_L >= 0 /*&& Horario_Lunes_Grid["Instructor_L_CBC", e.RowIndex].Value != null*/)
                            CurrentSesion_L.OidProfesor = ActiveComboInstructor_L;

                    } break;
                case "Impartida_L":
                    {
                        //if (e.RowIndex >= 0)
                        {
                            if (_lista_sesiones[e.RowIndex].Estado != 1
                               && _lista_sesiones[e.RowIndex].OidClaseTeorica != -1
                                /*&& (_lista_sesiones[e.RowIndex].Fecha.Date < DateTime.Today.Date
                                || (_lista_sesiones[e.RowIndex].Fecha.Date.Equals(DateTime.Today.Date)
                                && _lista_sesiones[e.RowIndex].Hora.TimeOfDay < DateTime.Today.TimeOfDay))*/)
                            {
                                if ((bool)Horario_Lunes_Grid["Impartida_L", e.RowIndex].Value == true)
                                    _lista_sesiones[e.RowIndex].Estado = 3;
                                else
                                    _lista_sesiones[e.RowIndex].Estado = 2;

                                if (_lista_sesiones[e.RowIndex].OidClaseTeorica > 0)
                                    _teoricas.GetItem(_lista_sesiones[e.RowIndex].OidClaseTeorica).Estado = _lista_sesiones[e.RowIndex].Estado;
                                if (_lista_sesiones[e.RowIndex].OidClasePractica > 0)
                                    _practicas[(int)_lista_sesiones[e.RowIndex].Grupo].GetItem(_lista_sesiones[e.RowIndex].OidClasePractica).Estado = _lista_sesiones[e.RowIndex].Estado;
                                if (_lista_sesiones[e.RowIndex].OidClaseExtra > 0)
                                    _extras.GetItem(_lista_sesiones[e.RowIndex].OidClaseExtra).Estado = _lista_sesiones[e.RowIndex].Estado;
                            }
                            else
                            {
                                if (Horario_Lunes_Grid["Impartida_L", e.RowIndex].Value.ToString() != ""
                                    && (bool)Horario_Lunes_Grid["Impartida_L", e.RowIndex].Value == true)
                                    Horario_Lunes_Grid["Impartida_L", e.RowIndex].Value = false;
                            }
                        }

                    } break;
            }
            MarcaCasillas(Horario_Lunes_Grid.Name);
        }

        private void Horario_Lunes_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex].Estado == 3
                && (Horario_Lunes_Grid.Columns[e.ColumnIndex].Name == Clase_L_CBC.Name
                || Horario_Lunes_Grid.Columns[e.ColumnIndex].Name == Instructor_L_CBC.Name)) e.Cancel = true;
            else
            {
                if (_lista_sesiones != null && e.RowIndex != -1)
                {
                    _modificada = new SesionAuxiliar();
                    _modificada.Copia(_lista_sesiones[e.RowIndex], false);
                }
                else
                    _modificada = null;
            }
        }

        private void Horario_Martes_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (relleno_automatico) return;

            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 14].Estado == 3
                && Horario_Martes_Grid.Columns[e.ColumnIndex].Name == Clase_M_CBC.Name) return;

            switch (Horario_Martes_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Clase_M_CBC":
                    {
                        if (ActiveComboClase_M != 0 && Horario_Martes_Grid["Clase_M_CBC", e.RowIndex].Value != null)
                        {
                            PgMng.Reset(9, 1, Resources.Messages.MODIFICANDO_CLASE, this);
                            try
                            {
                                long grupo = 1;
                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Texto.Contains("G2"))
                                        grupo = 2;
                                }
                                PgMng.Grow();

                                if (ActiveComboClase_M == _lista_sesiones[e.RowIndex + 14].OidClaseTeorica
                                    || ActiveComboClase_M == _lista_sesiones[e.RowIndex + 14].OidClaseExtra
                                    || (ActiveComboClase_M == _lista_sesiones[e.RowIndex + 14].OidClasePractica
                                    && grupo == _lista_sesiones[e.RowIndex + 14].Grupo))
                                    return;
                                PgMng.Grow();

                                //hay que liberar la clase que estaba en esta posicion
                                //y quitar la clase seleccionada de donde estuviera
                                if (_lista_sesiones[e.RowIndex + 14].Estado != 1)
                                {
                                    if (_lista_sesiones[e.RowIndex + 14].OidClaseTeorica != 0)
                                    {
                                        if (_lista_sesiones[e.RowIndex + 14].OidClaseTeorica > 0)
                                            _teoricas.GetItem(_lista_sesiones[e.RowIndex + 14].OidClaseTeorica).Estado = 1;
                                    }
                                    else
                                    {
                                        if (_lista_sesiones[e.RowIndex + 14].OidClasePractica != 0)
                                        {
                                            foreach (ClasePracticaList lista in _practicas)
                                                foreach (ClasePracticaInfo info in lista)
                                                {
                                                    if (info.Oid == _lista_sesiones[e.RowIndex + 14].OidClasePractica
                                                        && info.Grupo == _lista_sesiones[e.RowIndex + 14].Grupo)
                                                        info.Estado = 1;
                                                }
                                        }
                                        else
                                        {
                                            if (_lista_sesiones[e.RowIndex + 14].OidClaseExtra != 0)
                                                _extras.GetItem(_lista_sesiones[e.RowIndex + 14].OidClaseExtra).Estado = 1;
                                        }
                                    }
                                }
                                PgMng.Grow();

                                long oid_submodulo = 0;

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (ActiveComboClase_M > 0)
                                        oid_submodulo = _teoricas.GetItem(ActiveComboClase_M).OidSubmodulo;
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 2)
                                        oid_submodulo = _extras.GetItem(ActiveComboClase_M).OidSubmodulo;
                                    else
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_M);
                                            if (info != null) break;
                                        }
                                        oid_submodulo = info.OidSubmodulo;
                                    }
                                }
                                PgMng.Grow();

                                //se está modificando una línea ya existente
                                if (_source_list_m.CombosListCount > e.RowIndex)
                                    _source_list_m.UpdateCombosList(e.RowIndex + 14, ActiveComboClase_M, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, oid_submodulo);
                                else //hay que añadir un nuevo datasource a la lista
                                    _source_list_m.AddCombosList(ActiveComboClase_M, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, e.RowIndex, oid_submodulo);
                                PgMng.Grow();

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Oid > 0)
                                    {
                                        _lista_sesiones[e.RowIndex + 14].AsignaClaseASesion(_teoricas.GetItem(ActiveComboClase_M));
                                        _teoricas.GetItem(ActiveComboClase_M).Estado = 2;
                                    }
                                    else
                                    {
                                        if (ActiveComboClase_M == -2)
                                        {
                                            _lista_sesiones[e.RowIndex + 14].Estado = 1;
                                            //se marca la clase que se ha liberado como que no se puede dar en esta hora
                                            //se hace lo mismo con el profesor
                                            _no_asignables.Add(new SesionNoAsignable(e.RowIndex + 14, _lista_sesiones[e.RowIndex + 14].OidModulo, _lista_sesiones[e.RowIndex + 14].OidProfesor));
                                        }
                                        _lista_sesiones[e.RowIndex + 14].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                        if (ActiveComboClase_M == -1) _lista_sesiones[e.RowIndex + 14].Estado = 2;
                                    }
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_M);
                                            if (info != null) break;
                                        }
                                        _lista_sesiones[e.RowIndex + 14].AsignaClaseASesion(info);
                                        info.Estado = 2;
                                    }
                                    else
                                    {
                                        _lista_sesiones[e.RowIndex + 14].AsignaClaseASesion(_extras.GetItem(ActiveComboClase_M));
                                        _extras.GetItem(ActiveComboClase_M).Estado = 2;
                                    }
                                }
                                ((DataGridViewComboBoxCell)(Horario_Martes_Grid["Instructor_M_CBC", e.RowIndex])).DataSource = _source_list_m.GetCombosList(e.RowIndex);
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 14].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 14].OidClaseTeorica != 0
                                    || _lista_sesiones[e.RowIndex + 14].OidClaseExtra != 0)
                                {
                                    List<int> lista = new List<int>();

                                    _lista_sesiones.CambiaClase(e.RowIndex + 14, ActiveComboClase_M,
                                                 ((ComboBoxSource)Datos_Clases.Current).Tipo, grupo, lista);

                                    if (_modificada != null)
                                    {
                                        long oid_clase = 0;
                                        long tipo = 0;

                                        if (_modificada.OidClaseTeorica > 0)
                                        {
                                            oid_clase = _modificada.OidClaseTeorica;
                                            tipo = 0;
                                        }
                                        else
                                        {
                                            if (_modificada.OidClasePractica > 0)
                                            {
                                                oid_clase = _modificada.OidClasePractica;
                                                tipo = 1;
                                            }
                                            else
                                            {
                                                if (_modificada.OidClaseExtra > 0)
                                                {
                                                    oid_clase = _modificada.OidClaseExtra;
                                                    tipo = 2;
                                                }
                                            }
                                        }

                                        if (oid_clase != 0)
                                            _lista_sesiones.CambiaClase(e.RowIndex + 14, oid_clase, tipo, _modificada.Grupo, lista);
                                    }

                                    foreach (int indice in lista)
                                    {
                                        if (indice < 14)
                                        {
                                            Horario_Lunes_Grid["Clase_L_CBC", indice].Value = "";
                                        }
                                        else
                                        {
                                            if (indice < 28)
                                            {
                                                Horario_Martes_Grid["Clase_M_CBC", indice - 14].Value = "";
                                            }
                                            else
                                            {
                                                if (indice < 42)
                                                {
                                                    Horario_Miercoles_Grid["Clase_X_CBC", indice - 28].Value = "";
                                                }
                                                else
                                                {
                                                    if (indice < 56)
                                                    {
                                                        Horario_Jueves_Grid["Clase_J_CBC", indice - 42].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (indice < 70)
                                                        {
                                                            Horario_Viernes_Grid["Clase_V_CBC", indice - 56].Value = "";
                                                        }
                                                        else
                                                        {
                                                            Horario_Sabado_Grid["Clase_S_CBC", indice - 70].Value = "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (lista.Count > 0)
                                        Completar_BT.Enabled = true;
                                }
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 14].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 14].OidClaseExtra != 0
                                    || _lista_sesiones[e.RowIndex + 14].OidClaseTeorica == -1
                                    || _lista_sesiones[e.RowIndex + 14].OidClaseTeorica > 0
                                    || ActiveComboClase_M == -1)
                                    _lista_sesiones[e.RowIndex + 14].Forzada = true;
                                else _lista_sesiones[e.RowIndex + 14].Forzada = false;
                                if (ActiveComboClase_M == -2) Completar_BT.Enabled = true;
                                PgMng.Grow();

                                SetUnlinkedGridValues(Horario_Martes_Grid.Name);
                            }
                            finally { PgMng.FillUp(); }
                        }
                    } break;

                case "Instructor_M_CBC":
                    {
                        if (ActiveComboInstructor_M >= 0 /*&& Horario_Martes_Grid["Instructor_M_CBC", e.RowIndex].Value != null*/)
                            CurrentSesion_M.OidProfesor = ActiveComboInstructor_M;

                    } break;
                case "Impartida_M":
                    {
                        //if (e.RowIndex >= 0)
                        {
                            if (_lista_sesiones[e.RowIndex + 14].Estado != 1
                               && _lista_sesiones[e.RowIndex + 14].OidClaseTeorica != -1
                                /*&& (_lista_sesiones[e.RowIndex + 14].Fecha.Date < DateTime.Today.Date
                                || (_lista_sesiones[e.RowIndex + 14].Fecha.Date.Equals(DateTime.Today.Date)
                                && _lista_sesiones[e.RowIndex + 14].Hora.TimeOfDay < DateTime.Today.TimeOfDay))*/)
                            {
                                if ((bool)Horario_Martes_Grid["Impartida_M", e.RowIndex].Value == true)
                                    _lista_sesiones[e.RowIndex + 14].Estado = 3;
                                else
                                    _lista_sesiones[e.RowIndex + 14].Estado = 2;

                                if (_lista_sesiones[e.RowIndex + 14].OidClaseTeorica > 0)
                                    _teoricas.GetItem(_lista_sesiones[e.RowIndex + 14].OidClaseTeorica).Estado = _lista_sesiones[e.RowIndex + 14].Estado;
                                if (_lista_sesiones[e.RowIndex + 14].OidClasePractica > 0)
                                    _practicas[(int)_lista_sesiones[e.RowIndex + 14].Grupo].GetItem(_lista_sesiones[e.RowIndex + 14].OidClasePractica).Estado = _lista_sesiones[e.RowIndex + 14].Estado;
                                if (_lista_sesiones[e.RowIndex + 14].OidClaseExtra > 0)
                                    _extras.GetItem(_lista_sesiones[e.RowIndex + 14].OidClaseExtra).Estado = _lista_sesiones[e.RowIndex + 14].Estado;
                            }
                            else
                            {
                                if (Horario_Martes_Grid["Impartida_M", e.RowIndex].Value.ToString() != ""
                                    && (bool)Horario_Martes_Grid["Impartida_M", e.RowIndex].Value == true)
                                    Horario_Martes_Grid["Impartida_M", e.RowIndex].Value = false;
                            }
                        }

                    } break;
            }
            MarcaCasillas(Horario_Martes_Grid.Name);
        }

        private void Horario_Martes_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 14].Estado == 3
                && (Horario_Martes_Grid.Columns[e.ColumnIndex].Name == Clase_M_CBC.Name
                || Horario_Martes_Grid.Columns[e.ColumnIndex].Name == Instructor_M_CBC.Name))
                e.Cancel = true;
            else
            {
                if (_lista_sesiones != null && e.RowIndex != -1)
                {
                    _modificada = new SesionAuxiliar();
                    _modificada.Copia(_lista_sesiones[e.RowIndex + 14], false);
                }
                else
                    _modificada = null;
            }
        }

        private void Horario_Miercoles_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (relleno_automatico) return;

            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 28].Estado == 3
                && Horario_Miercoles_Grid.Columns[e.ColumnIndex].Name == Clase_X_CBC.Name) return;

            switch (Horario_Miercoles_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Clase_X_CBC":
                    {
                        if (ActiveComboClase_X != 0 && Horario_Miercoles_Grid["Clase_X_CBC", e.RowIndex].Value != null)
                        {
                            PgMng.Reset(9, 1, Resources.Messages.MODIFICANDO_CLASE, this);

                            try
                            {
                                long grupo = 1;
                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Texto.Contains("G2"))
                                        grupo = 2;
                                }
                                PgMng.Grow();

                                if (ActiveComboClase_X == _lista_sesiones[e.RowIndex + 28].OidClaseTeorica
                                    || ActiveComboClase_X == _lista_sesiones[e.RowIndex + 28].OidClaseExtra
                                    || (ActiveComboClase_X == _lista_sesiones[e.RowIndex + 28].OidClasePractica
                                    && grupo == _lista_sesiones[e.RowIndex + 28].Grupo))
                                    return;
                                PgMng.Grow();
                                //hay que liberar la clase que estaba en esta posicion
                                //y quitar la clase seleccionada de donde estuviera
                                if (_lista_sesiones[e.RowIndex + 28].Estado != 1)
                                {
                                    if (_lista_sesiones[e.RowIndex + 28].OidClaseTeorica != 0)
                                    {
                                        if (_lista_sesiones[e.RowIndex + 28].OidClaseTeorica > 0)
                                            _teoricas.GetItem(_lista_sesiones[e.RowIndex + 28].OidClaseTeorica).Estado = 1;
                                    }
                                    else
                                    {
                                        if (_lista_sesiones[e.RowIndex + 28].OidClasePractica != 0)
                                        {
                                            foreach (ClasePracticaList lista in _practicas)
                                                foreach (ClasePracticaInfo info in lista)
                                                {
                                                    if (info.Oid == _lista_sesiones[e.RowIndex + 28].OidClasePractica
                                                        && info.Grupo == _lista_sesiones[e.RowIndex + 28].Grupo)
                                                        info.Estado = 1;
                                                }
                                        }
                                        else
                                        {
                                            if (_lista_sesiones[e.RowIndex + 28].OidClaseExtra != 0)
                                                _extras.GetItem(_lista_sesiones[e.RowIndex + 28].OidClaseExtra).Estado = 1;
                                        }
                                    }
                                }

                                PgMng.Grow();

                                long oid_submodulo = 0;

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (ActiveComboClase_X > 0)
                                        oid_submodulo = _teoricas.GetItem(ActiveComboClase_X).OidSubmodulo;
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 2)
                                        oid_submodulo = _extras.GetItem(ActiveComboClase_X).OidSubmodulo;
                                    else
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_X);
                                            if (info != null) break;
                                        }
                                        oid_submodulo = info.OidSubmodulo;
                                    }
                                }
                                PgMng.Grow();

                                //se está modificando una línea ya existente
                                if (_source_list_x.CombosListCount > e.RowIndex)
                                    _source_list_x.UpdateCombosList(e.RowIndex + 28, ActiveComboClase_X, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, oid_submodulo);
                                else //hay que añadir un nuevo datasource a la lista
                                    _source_list_x.AddCombosList(ActiveComboClase_X, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, e.RowIndex, oid_submodulo);
                                PgMng.Grow();

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Oid > 0)
                                    {
                                        _lista_sesiones[e.RowIndex + 28].AsignaClaseASesion(_teoricas.GetItem(ActiveComboClase_X));
                                        _teoricas.GetItem(ActiveComboClase_X).Estado = 2;
                                    }
                                    else
                                    {
                                        if (ActiveComboClase_X == -2)
                                        {
                                            //se marca la clase que se ha liberado como que no se puede dar en esta hora
                                            //se hace lo mismo con el profesor
                                            _no_asignables.Add(new SesionNoAsignable(e.RowIndex + 28, _lista_sesiones[e.RowIndex + 26].OidModulo, _lista_sesiones[e.RowIndex + 26].OidProfesor));
                                        }
                                        _lista_sesiones[e.RowIndex + 28].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                        if (ActiveComboClase_X == -1) _lista_sesiones[e.RowIndex + 28].Estado = 2;
                                    }
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_X);
                                            if (info != null) break;
                                        }
                                        _lista_sesiones[e.RowIndex + 28].AsignaClaseASesion(info);
                                        info.Estado = 2;
                                    }
                                    else
                                    {
                                        _lista_sesiones[e.RowIndex + 28].AsignaClaseASesion(_extras.GetItem(ActiveComboClase_X));
                                        _extras.GetItem(ActiveComboClase_X).Estado = 2;
                                    }
                                }
                                PgMng.Grow();

                                ((DataGridViewComboBoxCell)(Horario_Miercoles_Grid["Instructor_X_CBC", e.RowIndex])).DataSource = _source_list_x.GetCombosList(e.RowIndex);

                                if (_lista_sesiones[e.RowIndex + 28].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 28].OidClaseTeorica != 0
                                    || _lista_sesiones[e.RowIndex + 28].OidClaseExtra != 0)
                                {
                                    List<int> lista = new List<int>();

                                    _lista_sesiones.CambiaClase(e.RowIndex + 28, ActiveComboClase_X,
                                                 ((ComboBoxSource)Datos_Clases.Current).Tipo, grupo, lista);

                                    if (_modificada != null)
                                    {
                                        long oid_clase = 0;
                                        long tipo = 0;

                                        if (_modificada.OidClaseTeorica > 0)
                                        {
                                            oid_clase = _modificada.OidClaseTeorica;
                                            tipo = 0;
                                        }
                                        else
                                        {
                                            if (_modificada.OidClasePractica > 0)
                                            {
                                                oid_clase = _modificada.OidClasePractica;
                                                tipo = 1;
                                            }
                                            else
                                            {
                                                if (_modificada.OidClaseExtra > 0)
                                                {
                                                    oid_clase = _modificada.OidClaseExtra;
                                                    tipo = 2;
                                                }
                                            }
                                        }

                                        if (oid_clase != 0)
                                            _lista_sesiones.CambiaClase(e.RowIndex + 28, oid_clase, tipo, _modificada.Grupo, lista);
                                    }

                                    foreach (int indice in lista)
                                    {
                                        if (indice < 14)
                                        {
                                            Horario_Lunes_Grid["Clase_L_CBC", indice].Value = "";
                                        }
                                        else
                                        {
                                            if (indice < 28)
                                            {
                                                Horario_Martes_Grid["Clase_M_CBC", indice - 14].Value = "";
                                            }
                                            else
                                            {
                                                if (indice < 42)
                                                {
                                                    Horario_Miercoles_Grid["Clase_X_CBC", indice - 28].Value = "";
                                                }
                                                else
                                                {
                                                    if (indice < 56)
                                                    {
                                                        Horario_Jueves_Grid["Clase_J_CBC", indice - 42].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (indice < 70)
                                                        {
                                                            Horario_Viernes_Grid["Clase_V_CBC", indice - 56].Value = "";
                                                        }
                                                        else
                                                        {
                                                            Horario_Sabado_Grid["Clase_S_CBC", indice - 70].Value = "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (lista.Count > 0)
                                    {
                                        Completar_BT.Enabled = true;
                                    }
                                }
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 28].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 28].OidClaseExtra != 0
                                    || _lista_sesiones[e.RowIndex + 28].OidClaseTeorica == -1
                                    || _lista_sesiones[e.RowIndex + 28].OidClaseTeorica > 0
                                    || ActiveComboClase_X == -1)
                                    _lista_sesiones[e.RowIndex + 28].Forzada = true;
                                else _lista_sesiones[e.RowIndex + 28].Forzada = false;
                                if (ActiveComboClase_X == -2) Completar_BT.Enabled = true;
                                PgMng.Grow();
                                SetUnlinkedGridValues(Horario_Miercoles_Grid.Name);
                            }
                            finally { PgMng.FillUp(); }
                        }
                    } break;

                case "Instructor_X_CBC":
                    {
                        if (ActiveComboInstructor_X >= 0 /*&& Horario_Miercoles_Grid["Instructor_X_CBC", e.RowIndex].Value != null*/)
                            CurrentSesion_X.OidProfesor = ActiveComboInstructor_X;

                    } break;
                case "Impartida_X":
                    {
                        //if (e.RowIndex >= 0)
                        {
                            if (_lista_sesiones[e.RowIndex + 28].Estado != 1
                               && _lista_sesiones[e.RowIndex + 28].OidClaseTeorica != -1
                                /*&& (_lista_sesiones[e.RowIndex + 28].Fecha.Date < DateTime.Today.Date
                                || (_lista_sesiones[e.RowIndex + 28].Fecha.Date.Equals(DateTime.Today.Date)
                                && _lista_sesiones[e.RowIndex + 28].Hora.TimeOfDay < DateTime.Today.TimeOfDay))*/)
                            {
                                if ((bool)Horario_Miercoles_Grid["Impartida_X", e.RowIndex].Value == true)
                                    _lista_sesiones[e.RowIndex + 28].Estado = 3;
                                else
                                    _lista_sesiones[e.RowIndex + 28].Estado = 2;

                                if (_lista_sesiones[e.RowIndex + 28].OidClaseTeorica > 0)
                                    _teoricas.GetItem(_lista_sesiones[e.RowIndex + 28].OidClaseTeorica).Estado = _lista_sesiones[e.RowIndex + 26].Estado;
                                if (_lista_sesiones[e.RowIndex + 28].OidClasePractica > 0)
                                    _practicas[(int)_lista_sesiones[e.RowIndex + 28].Grupo].GetItem(_lista_sesiones[e.RowIndex + 28].OidClasePractica).Estado = _lista_sesiones[e.RowIndex + 26].Estado;
                                if (_lista_sesiones[e.RowIndex + 28].OidClaseExtra > 0)
                                    _extras.GetItem(_lista_sesiones[e.RowIndex + 28].OidClaseExtra).Estado = _lista_sesiones[e.RowIndex + 26].Estado;
                            }
                            else
                            {
                                if (Horario_Miercoles_Grid["Impartida_X", e.RowIndex].Value.ToString() != ""
                                    && (bool)Horario_Miercoles_Grid["Impartida_X", e.RowIndex].Value == true)
                                    Horario_Miercoles_Grid["Impartida_X", e.RowIndex].Value = false;
                            }
                        }

                    } break;
            }
            MarcaCasillas(Horario_Miercoles_Grid.Name);
        }

        private void Horario_Miercoles_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 28].Estado == 3
                && (Horario_Miercoles_Grid.Columns[e.ColumnIndex].Name == Clase_X_CBC.Name
                || Horario_Miercoles_Grid.Columns[e.ColumnIndex].Name == Instructor_X_CBC.Name)) e.Cancel = true;
            else
            {
                if (_lista_sesiones != null && e.RowIndex != -1)
                {
                    _modificada = new SesionAuxiliar();
                    _modificada.Copia(_lista_sesiones[e.RowIndex + 28], false);
                }
                else
                    _modificada = null;
            }
        }

        private void Horario_Jueves_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (relleno_automatico) return;

            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 42].Estado == 3
                && Horario_Jueves_Grid.Columns[e.ColumnIndex].Name == Clase_J_CBC.Name) return;

            switch (Horario_Jueves_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Clase_J_CBC":
                    {
                        if (ActiveComboClase_J != 0 && Horario_Jueves_Grid["Clase_J_CBC", e.RowIndex].Value != null)
                        {
                            PgMng.Reset(9, 1, Resources.Messages.MODIFICANDO_CLASE, this);

                            try
                            {
                                long grupo = 1;
                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Texto.Contains("G2"))
                                        grupo = 2;
                                }
                                PgMng.Grow();

                                if (ActiveComboClase_J == _lista_sesiones[e.RowIndex + 42].OidClaseTeorica
                                    || ActiveComboClase_J == _lista_sesiones[e.RowIndex + 42].OidClaseExtra
                                    || (ActiveComboClase_J == _lista_sesiones[e.RowIndex + 42].OidClasePractica
                                    && grupo == _lista_sesiones[e.RowIndex + 42].Grupo))
                                    return;
                                PgMng.Grow();

                                //hay que liberar la clase que estaba en esta posicion
                                //y quitar la clase seleccionada de donde estuviera
                                if (_lista_sesiones[e.RowIndex + 42].Estado != 1)
                                {
                                    if (_lista_sesiones[e.RowIndex + 42].OidClaseTeorica != 0)
                                    {
                                        if (_lista_sesiones[e.RowIndex + 42].OidClaseTeorica > 0)
                                            _teoricas.GetItem(_lista_sesiones[e.RowIndex + 42].OidClaseTeorica).Estado = 1;
                                    }
                                    else
                                    {
                                        if (_lista_sesiones[e.RowIndex + 42].OidClasePractica != 0)
                                        {
                                            foreach (ClasePracticaList lista in _practicas)
                                                foreach (ClasePracticaInfo info in lista)
                                                {
                                                    if (info.Oid == _lista_sesiones[e.RowIndex + 42].OidClasePractica
                                                        && info.Grupo == _lista_sesiones[e.RowIndex + 42].Grupo)
                                                        info.Estado = 1;
                                                }
                                        }
                                        else
                                        {
                                            if (_lista_sesiones[e.RowIndex + 42].OidClaseExtra != 0)
                                                _extras.GetItem(_lista_sesiones[e.RowIndex + 42].OidClaseExtra).Estado = 1;
                                        }
                                    }
                                }
                                PgMng.Grow();

                                long oid_submodulo = 0;

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (ActiveComboClase_J > 0)
                                        oid_submodulo = _teoricas.GetItem(ActiveComboClase_J).OidSubmodulo;
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 2)
                                        oid_submodulo = _extras.GetItem(ActiveComboClase_J).OidSubmodulo;
                                    else
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_J);
                                            if (info != null) break;
                                        }
                                        oid_submodulo = info.OidSubmodulo;
                                    }
                                }
                                PgMng.Grow();

                                //se está modificando una línea ya existente
                                if (_source_list_j.CombosListCount > e.RowIndex)
                                    _source_list_j.UpdateCombosList(e.RowIndex + 42, ActiveComboClase_J, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, oid_submodulo);
                                else //hay que añadir un nuevo datasource a la lista
                                    _source_list_j.AddCombosList(ActiveComboClase_J, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, e.RowIndex, oid_submodulo);
                                PgMng.Grow();

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Oid > 0)
                                    {
                                        _lista_sesiones[e.RowIndex + 42].AsignaClaseASesion(_teoricas.GetItem(ActiveComboClase_J));
                                        _teoricas.GetItem(ActiveComboClase_J).Estado = 2;
                                    }
                                    else
                                    {
                                        if (ActiveComboClase_J == -2)
                                        {
                                            //se marca la clase que se ha liberado como que no se puede dar en esta hora
                                            //se hace lo mismo con el profesor
                                            _no_asignables.Add(new SesionNoAsignable(e.RowIndex + 42, _lista_sesiones[e.RowIndex + 42].OidModulo, _lista_sesiones[e.RowIndex + 42].OidProfesor));
                                        }
                                        _lista_sesiones[e.RowIndex + 42].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                        if (ActiveComboClase_J == -1) _lista_sesiones[e.RowIndex + 42].Estado = 2;
                                    }
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_J);
                                            if (info != null) break;
                                        }
                                        _lista_sesiones[e.RowIndex + 42].AsignaClaseASesion(info);
                                        info.Estado = 2;
                                    }
                                    else
                                    {
                                        _lista_sesiones[e.RowIndex + 42].AsignaClaseASesion(_extras.GetItem(ActiveComboClase_J));
                                        _extras.GetItem(ActiveComboClase_J).Estado = 2;
                                    }
                                }
                                ((DataGridViewComboBoxCell)(Horario_Jueves_Grid["Instructor_J_CBC", e.RowIndex])).DataSource = _source_list_j.GetCombosList(e.RowIndex);
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 42].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 42].OidClaseTeorica != 0
                                    || _lista_sesiones[e.RowIndex + 42].OidClaseExtra != 0)
                                {
                                    List<int> lista = new List<int>();

                                    _lista_sesiones.CambiaClase(e.RowIndex + 42, ActiveComboClase_J,
                                                 ((ComboBoxSource)Datos_Clases.Current).Tipo, grupo, lista);

                                    if (_modificada != null)
                                    {
                                        long oid_clase = 0;
                                        long tipo = 0;

                                        if (_modificada.OidClaseTeorica > 0)
                                        {
                                            oid_clase = _modificada.OidClaseTeorica;
                                            tipo = 0;
                                        }
                                        else
                                        {
                                            if (_modificada.OidClasePractica > 0)
                                            {
                                                oid_clase = _modificada.OidClasePractica;
                                                tipo = 1;
                                            }
                                            else
                                            {
                                                if (_modificada.OidClaseExtra > 0)
                                                {
                                                    oid_clase = _modificada.OidClaseExtra;
                                                    tipo = 2;
                                                }
                                            }
                                        }

                                        if (oid_clase != 0)
                                            _lista_sesiones.CambiaClase(e.RowIndex + 42, oid_clase, tipo, _modificada.Grupo, lista);
                                    }

                                    foreach (int indice in lista)
                                    {
                                        if (indice < 14)
                                        {
                                            Horario_Lunes_Grid["Clase_L_CBC", indice].Value = "";
                                        }
                                        else
                                        {
                                            if (indice < 28)
                                            {
                                                Horario_Martes_Grid["Clase_M_CBC", indice - 14].Value = "";
                                            }
                                            else
                                            {
                                                if (indice < 42)
                                                {
                                                    Horario_Miercoles_Grid["Clase_X_CBC", indice - 28].Value = "";
                                                }
                                                else
                                                {
                                                    if (indice < 56)
                                                    {
                                                        Horario_Jueves_Grid["Clase_J_CBC", indice - 42].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (indice < 70)
                                                        {
                                                            Horario_Viernes_Grid["Clase_V_CBC", indice - 56].Value = "";
                                                        }
                                                        else
                                                        {
                                                            Horario_Sabado_Grid["Clase_S_CBC", indice - 70].Value = "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (lista.Count > 0)
                                    {
                                        Completar_BT.Enabled = true;
                                    }
                                }
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 42].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 42].OidClaseExtra != 0
                                    || _lista_sesiones[e.RowIndex + 42].OidClaseTeorica == -1
                                    || _lista_sesiones[e.RowIndex + 42].OidClaseTeorica > 0
                                    || ActiveComboClase_J == -1)
                                    _lista_sesiones[e.RowIndex + 42].Forzada = true;
                                else _lista_sesiones[e.RowIndex + 42].Forzada = false;
                                if (ActiveComboClase_J == -2) Completar_BT.Enabled = true;
                                PgMng.Grow();

                                SetUnlinkedGridValues(Horario_Jueves_Grid.Name);
                            }
                            finally { PgMng.FillUp(); }
                        }
                    } break;

                case "Instructor_J_CBC":
                    {
                        if (ActiveComboInstructor_J >= 0 /*&& Horario_Jueves_Grid["Instructor_J_CBC", e.RowIndex].Value != null*/)
                            CurrentSesion_J.OidProfesor = ActiveComboInstructor_J;

                    } break;
                case "Impartida_J":
                    {
                        //if (e.RowIndex >= 0)
                        {
                            if (_lista_sesiones[e.RowIndex + 42].Estado != 1
                               && _lista_sesiones[e.RowIndex + 42].OidClaseTeorica != -1
                                /*&& (_lista_sesiones[e.RowIndex + 42].Fecha.Date < DateTime.Today.Date
                                || (_lista_sesiones[e.RowIndex + 42].Fecha.Date.Equals(DateTime.Today.Date)
                                && _lista_sesiones[e.RowIndex + 42].Hora.TimeOfDay < DateTime.Today.TimeOfDay))*/)
                            {
                                if ((bool)Horario_Jueves_Grid["Impartida_J", e.RowIndex].Value == true)
                                    _lista_sesiones[e.RowIndex + 42].Estado = 3;
                                else
                                    _lista_sesiones[e.RowIndex + 42].Estado = 2;

                                if (_lista_sesiones[e.RowIndex + 42].OidClaseTeorica > 0)
                                    _teoricas.GetItem(_lista_sesiones[e.RowIndex + 42].OidClaseTeorica).Estado = _lista_sesiones[e.RowIndex + 42].Estado;
                                if (_lista_sesiones[e.RowIndex + 42].OidClasePractica > 0)
                                    _practicas[(int)_lista_sesiones[e.RowIndex + 42].Grupo].GetItem(_lista_sesiones[e.RowIndex + 42].OidClasePractica).Estado = _lista_sesiones[e.RowIndex + 42].Estado;
                                if (_lista_sesiones[e.RowIndex + 42].OidClaseExtra > 0)
                                    _extras.GetItem(_lista_sesiones[e.RowIndex + 42].OidClaseExtra).Estado = _lista_sesiones[e.RowIndex + 42].Estado;
                            }
                            else
                            {
                                if (Horario_Jueves_Grid["Impartida_J", e.RowIndex].Value.ToString() != ""
                                    && (bool)Horario_Jueves_Grid["Impartida_J", e.RowIndex].Value == true)
                                    Horario_Jueves_Grid["Impartida_J", e.RowIndex].Value = false;
                            }
                        }

                    } break;
            }
            MarcaCasillas(Horario_Jueves_Grid.Name);
        }

        private void Horario_Jueves_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 42].Estado == 3
                && (Horario_Jueves_Grid.Columns[e.ColumnIndex].Name == Clase_J_CBC.Name
                || Horario_Jueves_Grid.Columns[e.ColumnIndex].Name == Instructor_J_CBC.Name)) e.Cancel = true;
            else
            {
                if (_lista_sesiones != null && e.RowIndex != -1)
                {
                    _modificada = new SesionAuxiliar();
                    _modificada.Copia(_lista_sesiones[e.RowIndex + 42], false);
                }
                else
                    _modificada = null;
            }
        }

        private void Horario_Viernes_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (relleno_automatico) return;

            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 56].Estado == 3
                && Horario_Viernes_Grid.Columns[e.ColumnIndex].Name == Clase_V_CBC.Name) return;

            switch (Horario_Viernes_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Clase_V_CBC":
                    {
                        if (ActiveComboClase_V != 0 && Horario_Viernes_Grid["Clase_V_CBC", e.RowIndex].Value != null)
                        {
                            PgMng.Reset(9, 1, Resources.Messages.MODIFICANDO_CLASE, this);

                            try
                            {
                                long grupo = 1;
                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Texto.Contains("G2"))
                                        grupo = 2;
                                }
                                PgMng.Grow();

                                if (ActiveComboClase_V == _lista_sesiones[e.RowIndex + 56].OidClaseTeorica
                                    || ActiveComboClase_V == _lista_sesiones[e.RowIndex + 56].OidClaseExtra
                                    || (ActiveComboClase_V == _lista_sesiones[e.RowIndex + 56].OidClasePractica
                                    && grupo == _lista_sesiones[e.RowIndex + 56].Grupo))
                                    return;
                                PgMng.Grow();

                                //hay que liberar la clase que estaba en esta posicion
                                //y quitar la clase seleccionada de donde estuviera
                                if (_lista_sesiones[e.RowIndex + 56].Estado != 1)
                                {
                                    if (_lista_sesiones[e.RowIndex + 56].OidClaseTeorica != 0)
                                    {
                                        if (_lista_sesiones[e.RowIndex + 56].OidClaseTeorica > 0)
                                            _teoricas.GetItem(_lista_sesiones[e.RowIndex + 56].OidClaseTeorica).Estado = 1;
                                    }
                                    else
                                    {
                                        if (_lista_sesiones[e.RowIndex + 56].OidClasePractica != 0)
                                        {
                                            foreach (ClasePracticaList lista in _practicas)
                                                foreach (ClasePracticaInfo info in lista)
                                                {
                                                    if (info.Oid == _lista_sesiones[e.RowIndex + 56].OidClasePractica
                                                        && info.Grupo == _lista_sesiones[e.RowIndex + 56].Grupo)
                                                        info.Estado = 1;
                                                }
                                        }
                                        else
                                        {
                                            if (_lista_sesiones[e.RowIndex + 56].OidClaseExtra != 0)
                                                _extras.GetItem(_lista_sesiones[e.RowIndex + 56].OidClaseExtra).Estado = 1;
                                        }
                                    }
                                }
                                PgMng.Grow();

                                long oid_submodulo = 0;

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (ActiveComboClase_V > 0)
                                        oid_submodulo = _teoricas.GetItem(ActiveComboClase_V).OidSubmodulo;
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 2)
                                        oid_submodulo = _extras.GetItem(ActiveComboClase_V).OidSubmodulo;
                                    else
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_V);
                                            if (info != null) break;
                                        }
                                        oid_submodulo = info.OidSubmodulo;
                                    }
                                }
                                PgMng.Grow();

                                //se está modificando una línea ya existente
                                if (_source_list_v.CombosListCount > e.RowIndex)
                                    _source_list_v.UpdateCombosList(e.RowIndex + 56, ActiveComboClase_V, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, oid_submodulo);
                                else //hay que añadir un nuevo datasource a la lista
                                    _source_list_v.AddCombosList(ActiveComboClase_V, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, e.RowIndex, oid_submodulo);
                                PgMng.Grow();

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Oid > 0)
                                    {
                                        _lista_sesiones[e.RowIndex + 56].AsignaClaseASesion(_teoricas.GetItem(ActiveComboClase_V));
                                        _teoricas.GetItem(ActiveComboClase_V).Estado = 2;
                                    }
                                    else
                                    {
                                        if (ActiveComboClase_V == -2)
                                        {
                                            //se marca la clase que se ha liberado como que no se puede dar en esta hora
                                            //se hace lo mismo con el profesor
                                            _no_asignables.Add(new SesionNoAsignable(e.RowIndex + 56, _lista_sesiones[e.RowIndex + 56].OidModulo, _lista_sesiones[e.RowIndex + 56].OidProfesor));
                                        }
                                        _lista_sesiones[e.RowIndex + 56].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                        if (ActiveComboClase_V == -1) _lista_sesiones[e.RowIndex + 56].Estado = 2;
                                    }
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_V);
                                            if (info != null) break;
                                        }
                                        _lista_sesiones[e.RowIndex + 56].AsignaClaseASesion(info);
                                        info.Estado = 2;
                                    }
                                    else
                                    {
                                        _lista_sesiones[e.RowIndex + 56].AsignaClaseASesion(_extras.GetItem(ActiveComboClase_V));
                                        _extras.GetItem(ActiveComboClase_V).Estado = 2;
                                    }
                                }
                                ((DataGridViewComboBoxCell)(Horario_Viernes_Grid["Instructor_V_CBC", e.RowIndex])).DataSource = _source_list_v.GetCombosList(e.RowIndex);
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 56].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 56].OidClaseTeorica != 0
                                    || _lista_sesiones[e.RowIndex + 56].OidClaseExtra != 0)
                                {
                                    List<int> lista = new List<int>();

                                    _lista_sesiones.CambiaClase(e.RowIndex + 56, ActiveComboClase_V,
                                                 ((ComboBoxSource)Datos_Clases.Current).Tipo, grupo, lista);

                                    if (_modificada != null)
                                    {
                                        long oid_clase = 0;
                                        long tipo = 0;

                                        if (_modificada.OidClaseTeorica > 0)
                                        {
                                            oid_clase = _modificada.OidClaseTeorica;
                                            tipo = 0;
                                        }
                                        else
                                        {
                                            if (_modificada.OidClasePractica > 0)
                                            {
                                                oid_clase = _modificada.OidClasePractica;
                                                tipo = 1;
                                            }
                                            else
                                            {
                                                if (_modificada.OidClaseExtra > 0)
                                                {
                                                    oid_clase = _modificada.OidClaseExtra;
                                                    tipo = 2;
                                                }
                                            }
                                        }

                                        if (oid_clase != 0)
                                            _lista_sesiones.CambiaClase(e.RowIndex + 56, oid_clase, tipo, _modificada.Grupo, lista);
                                    }

                                    foreach (int indice in lista)
                                    {
                                        if (indice < 14)
                                        {
                                            Horario_Lunes_Grid["Clase_L_CBC", indice].Value = "";
                                        }
                                        else
                                        {
                                            if (indice < 28)
                                            {
                                                Horario_Martes_Grid["Clase_M_CBC", indice - 14].Value = "";
                                            }
                                            else
                                            {
                                                if (indice < 42)
                                                {
                                                    Horario_Miercoles_Grid["Clase_X_CBC", indice - 28].Value = "";
                                                }
                                                else
                                                {
                                                    if (indice < 56)
                                                    {
                                                        Horario_Jueves_Grid["Clase_J_CBC", indice - 42].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (indice < 70)
                                                        {
                                                            Horario_Viernes_Grid["Clase_V_CBC", indice - 56].Value = "";
                                                        }
                                                        else
                                                        {
                                                            Horario_Sabado_Grid["Clase_S_CBC", indice - 70].Value = "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (lista.Count > 0)
                                    {
                                        Completar_BT.Enabled = true;
                                    }
                                }
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 56].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 56].OidClaseExtra != 0
                                    || _lista_sesiones[e.RowIndex + 56].OidClaseTeorica == -1
                                    || _lista_sesiones[e.RowIndex + 56].OidClaseTeorica > 0
                                    || ActiveComboClase_V == -1)
                                    _lista_sesiones[e.RowIndex + 56].Forzada = true;
                                else _lista_sesiones[e.RowIndex + 56].Forzada = false;
                                if (ActiveComboClase_V == -2) Completar_BT.Enabled = true;
                                PgMng.Grow();

                                SetUnlinkedGridValues(Horario_Viernes_Grid.Name);
                            }
                            finally { PgMng.FillUp(); }
                        }
                    } break;

                case "Instructor_V_CBC":
                    {
                        if (ActiveComboInstructor_V >= 0 /*&& Horario_Viernes_Grid["Instructor_V_CBC", e.RowIndex].Value != null*/)
                            CurrentSesion_V.OidProfesor = ActiveComboInstructor_V;
                    } break;
                case "Impartida_V":
                    {
                        //if (e.RowIndex >= 0)
                        {
                            if (_lista_sesiones[e.RowIndex + 56].Estado != 1
                               && _lista_sesiones[e.RowIndex + 56].OidClaseTeorica != -1
                                /* && (_lista_sesiones[e.RowIndex + 56].Fecha.Date < DateTime.Today.Date
                                 || (_lista_sesiones[e.RowIndex + 56].Fecha.Date.Equals(DateTime.Today.Date)
                                 && _lista_sesiones[e.RowIndex + 56].Hora.TimeOfDay < DateTime.Today.TimeOfDay))*/)
                            {
                                if ((bool)Horario_Viernes_Grid["Impartida_V", e.RowIndex].Value == true)
                                    _lista_sesiones[e.RowIndex + 56].Estado = 3;
                                else
                                    _lista_sesiones[e.RowIndex + 56].Estado = 2;

                                if (_lista_sesiones[e.RowIndex + 56].OidClaseTeorica > 0)
                                    _teoricas.GetItem(_lista_sesiones[e.RowIndex + 56].OidClaseTeorica).Estado = _lista_sesiones[e.RowIndex + 56].Estado;
                                if (_lista_sesiones[e.RowIndex + 56].OidClasePractica > 0)
                                    _practicas[(int)_lista_sesiones[e.RowIndex + 56].Grupo].GetItem(_lista_sesiones[e.RowIndex + 56].OidClasePractica).Estado = _lista_sesiones[e.RowIndex + 56].Estado;
                                if (_lista_sesiones[e.RowIndex + 56].OidClaseExtra > 0)
                                    _extras.GetItem(_lista_sesiones[e.RowIndex + 56].OidClaseExtra).Estado = _lista_sesiones[e.RowIndex + 56].Estado;
                            }
                            else
                            {
                                if (Horario_Viernes_Grid["Impartida_V", e.RowIndex].Value.ToString() != ""
                                    && (bool)Horario_Viernes_Grid["Impartida_V", e.RowIndex].Value == true)
                                    Horario_Viernes_Grid["Impartida_V", e.RowIndex].Value = false;
                            }
                        }

                    } break;
            }
            MarcaCasillas(Horario_Viernes_Grid.Name);
        }

        private void Horario_Viernes_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 56].Estado == 3
                && (Horario_Viernes_Grid.Columns[e.ColumnIndex].Name == Clase_V_CBC.Name
                || Horario_Viernes_Grid.Columns[e.ColumnIndex].Name == Instructor_V_CBC.Name)) e.Cancel = true;
            else
            {
                if (_lista_sesiones != null && e.RowIndex != -1)
                {
                    _modificada = new SesionAuxiliar();
                    _modificada.Copia(_lista_sesiones[e.RowIndex + 56], false);
                }
                else
                    _modificada = null;
            }
        }

        private void Horario_Sabado_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (relleno_automatico) return;

            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 70].Estado == 3
                && Horario_Sabado_Grid.Columns[e.ColumnIndex].Name == Clase_S_CBC.Name) return;

            switch (Horario_Sabado_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Clase_S_CBC":
                    {
                        if (ActiveComboClase_S != 0 && Horario_Sabado_Grid["Clase_S_CBC", e.RowIndex].Value != null)
                        {
                            PgMng.Reset(9, 1, Resources.Messages.MODIFICANDO_CLASE, this);

                            try
                            {
                                long grupo = 1;
                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Texto.Contains("G2"))
                                        grupo = 2;
                                }
                                PgMng.Grow();

                                if (ActiveComboClase_S == _lista_sesiones[e.RowIndex + 70].OidClaseTeorica
                                    || ActiveComboClase_S == _lista_sesiones[e.RowIndex + 70].OidClaseExtra
                                    || (ActiveComboClase_S == _lista_sesiones[e.RowIndex + 70].OidClasePractica
                                    && grupo == _lista_sesiones[e.RowIndex + 70].Grupo))
                                    return;
                                PgMng.Grow();

                                //hay que liberar la clase que estaba en esta posicion
                                //y quitar la clase seleccionada de donde estuviera
                                if (_lista_sesiones[e.RowIndex + 70].Estado != 1)
                                {
                                    if (_lista_sesiones[e.RowIndex + 70].OidClaseTeorica != 0)
                                    {
                                        if (_lista_sesiones[e.RowIndex + 70].OidClaseTeorica > 0)
                                            _teoricas.GetItem(_lista_sesiones[e.RowIndex + 70].OidClaseTeorica).Estado = 1;
                                    }
                                    else
                                    {
                                        if (_lista_sesiones[e.RowIndex + 70].OidClasePractica != 0)
                                        {
                                            foreach (ClasePracticaList lista in _practicas)
                                                foreach (ClasePracticaInfo info in lista)
                                                {
                                                    if (info.Oid == _lista_sesiones[e.RowIndex + 70].OidClasePractica
                                                        && info.Grupo == _lista_sesiones[e.RowIndex + 70].Grupo)
                                                        info.Estado = 1;
                                                }
                                        }
                                        else
                                        {
                                            if (_lista_sesiones[e.RowIndex + 70].OidClaseExtra != 0)
                                                _extras.GetItem(_lista_sesiones[e.RowIndex + 70].OidClaseExtra).Estado = 1;
                                        }
                                    }
                                }
                                PgMng.Grow();

                                long oid_submodulo = 0;

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (ActiveComboClase_S > 0)
                                        oid_submodulo = _teoricas.GetItem(ActiveComboClase_S).OidSubmodulo;
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 2)
                                        oid_submodulo = _extras.GetItem(ActiveComboClase_S).OidSubmodulo;
                                    else
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_S);
                                            if (info != null) break;
                                        }
                                        oid_submodulo = info.OidSubmodulo;
                                    }
                                }
                                PgMng.Grow();

                                //se está modificando una línea ya existente
                                if (_source_list_s.CombosListCount > e.RowIndex)
                                    _source_list_s.UpdateCombosList(e.RowIndex + 70, ActiveComboClase_S, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, oid_submodulo);
                                else //hay que añadir un nuevo datasource a la lista
                                    _source_list_s.AddCombosList(ActiveComboClase_S, this, ((ComboBoxSource)Datos_Clases.Current).Tipo, e.RowIndex, oid_submodulo);
                                PgMng.Grow();

                                if (((ComboBoxSource)Datos_Clases.Current).Tipo == 0)
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Oid > 0)
                                    {
                                        _lista_sesiones[e.RowIndex + 70].AsignaClaseASesion(_teoricas.GetItem(ActiveComboClase_S));
                                        _teoricas.GetItem(ActiveComboClase_S).Estado = 2;
                                    }
                                    else
                                    {
                                        if (ActiveComboClase_S == -2)
                                        {
                                            //se marca la clase que se ha liberado como que no se puede dar en esta hora
                                            //se hace lo mismo con el profesor
                                            _no_asignables.Add(new SesionNoAsignable(e.RowIndex + 70, _lista_sesiones[e.RowIndex + 70].OidModulo, _lista_sesiones[e.RowIndex + 70].OidProfesor));
                                        }
                                        _lista_sesiones[e.RowIndex + 70].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                        if (ActiveComboClase_S == -1) _lista_sesiones[e.RowIndex + 70].Estado = 2;
                                    }
                                }
                                else
                                {
                                    if (((ComboBoxSource)Datos_Clases.Current).Tipo == 1)
                                    {
                                        ClasePracticaInfo info = null;
                                        foreach (ClasePracticaList lista in _practicas)
                                        {
                                            info = lista.GetItem(ActiveComboClase_S);
                                            if (info != null) break;
                                        }
                                        _lista_sesiones[e.RowIndex + 70].AsignaClaseASesion(info);
                                        info.Estado = 2;
                                    }
                                    else
                                    {
                                        _lista_sesiones[e.RowIndex + 70].AsignaClaseASesion(_extras.GetItem(ActiveComboClase_S));
                                        _extras.GetItem(ActiveComboClase_S).Estado = 2;
                                    }
                                }
                                ((DataGridViewComboBoxCell)(Horario_Sabado_Grid["Instructor_S_CBC", e.RowIndex])).DataSource = _source_list_s.GetCombosList(e.RowIndex);
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 70].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 70].OidClaseTeorica != 0
                                    || _lista_sesiones[e.RowIndex + 70].OidClaseExtra != 0)
                                {
                                    List<int> lista = new List<int>();

                                    _lista_sesiones.CambiaClase(e.RowIndex + 70, ActiveComboClase_S,
                                                 ((ComboBoxSource)Datos_Clases.Current).Tipo, grupo, lista);

                                    if (_modificada != null)
                                    {
                                        long oid_clase = 0;
                                        long tipo = 0;

                                        if (_modificada.OidClaseTeorica > 0)
                                        {
                                            oid_clase = _modificada.OidClaseTeorica;
                                            tipo = 0;
                                        }
                                        else
                                        {
                                            if (_modificada.OidClasePractica > 0)
                                            {
                                                oid_clase = _modificada.OidClasePractica;
                                                tipo = 1;
                                            }
                                            else
                                            {
                                                if (_modificada.OidClaseExtra > 0)
                                                {
                                                    oid_clase = _modificada.OidClaseExtra;
                                                    tipo = 2;
                                                }
                                            }
                                        }

                                        if (oid_clase != 0)
                                            _lista_sesiones.CambiaClase(e.RowIndex + 70, oid_clase, tipo, _modificada.Grupo, lista);
                                    }

                                    foreach (int indice in lista)
                                    {
                                        if (indice < 14)
                                        {
                                            Horario_Lunes_Grid["Clase_L_CBC", indice].Value = "";
                                        }
                                        else
                                        {
                                            if (indice < 28)
                                            {
                                                Horario_Martes_Grid["Clase_M_CBC", indice - 14].Value = "";
                                            }
                                            else
                                            {
                                                if (indice < 42)
                                                {
                                                    Horario_Miercoles_Grid["Clase_X_CBC", indice - 28].Value = "";
                                                }
                                                else
                                                {
                                                    if (indice < 56)
                                                    {
                                                        Horario_Jueves_Grid["Clase_J_CBC", indice - 42].Value = "";
                                                    }
                                                    else
                                                    {
                                                        if (indice < 70)
                                                        {
                                                            Horario_Viernes_Grid["Clase_V_CBC", indice - 56].Value = "";
                                                        }
                                                        else
                                                        {
                                                            Horario_Sabado_Grid["Clase_S_CBC", indice - 70].Value = "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (lista.Count > 0)
                                    {
                                        Completar_BT.Enabled = true;
                                    }
                                }
                                PgMng.Grow();

                                if (_lista_sesiones[e.RowIndex + 70].OidClasePractica != 0
                                    || _lista_sesiones[e.RowIndex + 70].OidClaseExtra != 0
                                    || _lista_sesiones[e.RowIndex + 70].OidClaseTeorica == -1
                                    || _lista_sesiones[e.RowIndex + 70].OidClaseTeorica > 0
                                    || ActiveComboClase_S == -1)
                                    _lista_sesiones[e.RowIndex + 70].Forzada = true;
                                else _lista_sesiones[e.RowIndex + 70].Forzada = false;
                                if (ActiveComboClase_S == -2) Completar_BT.Enabled = true;
                                PgMng.Grow();

                                SetUnlinkedGridValues(Horario_Sabado_Grid.Name);
                            }
                            finally { PgMng.FillUp(); }
                        }
                    } break;

                case "Instructor_S_CBC":
                    {
                        if (ActiveComboInstructor_S >= 0 /*&& Horario_Sabado_Grid["Instructor_S_CBC", e.RowIndex].Value != null*/)
                            CurrentSesion_S.OidProfesor = ActiveComboInstructor_S;

                    } break;
                case "Impartida_S":
                    {
                        //if (e.RowIndex >= 0)
                        {
                            if (_lista_sesiones[e.RowIndex + 70].Estado != 1
                               && _lista_sesiones[e.RowIndex + 70].OidClaseTeorica != -1
                                /*&& (_lista_sesiones[e.RowIndex + 70].Fecha.Date < DateTime.Today.Date
                                || (_lista_sesiones[e.RowIndex + 70].Fecha.Date.Equals(DateTime.Today.Date)
                                && _lista_sesiones[e.RowIndex + 70].Hora.TimeOfDay < DateTime.Today.TimeOfDay))*/)
                            {
                                if ((bool)Horario_Sabado_Grid["Impartida_S", e.RowIndex].Value == true)
                                    _lista_sesiones[e.RowIndex + 70].Estado = 3;
                                else
                                    _lista_sesiones[e.RowIndex + 70].Estado = 2;

                                if (_lista_sesiones[e.RowIndex + 70].OidClaseTeorica > 0)
                                    _teoricas.GetItem(_lista_sesiones[e.RowIndex + 70].OidClaseTeorica).Estado = _lista_sesiones[e.RowIndex + 70].Estado;
                                if (_lista_sesiones[e.RowIndex + 70].OidClasePractica > 0)
                                    _practicas[(int)_lista_sesiones[e.RowIndex + 70].Grupo].GetItem(_lista_sesiones[e.RowIndex + 70].OidClasePractica).Estado = _lista_sesiones[e.RowIndex + 70].Estado;
                                if (_lista_sesiones[e.RowIndex + 70].OidClaseExtra > 0)
                                    _extras.GetItem(_lista_sesiones[e.RowIndex + 70].OidClaseExtra).Estado = _lista_sesiones[e.RowIndex + 70].Estado;
                            }
                            else
                            {
                                if (Horario_Sabado_Grid["Impartida_S", e.RowIndex].Value.ToString() != ""
                                    && (bool)Horario_Sabado_Grid["Impartida_S", e.RowIndex].Value == true)
                                    Horario_Sabado_Grid["Impartida_S", e.RowIndex].Value = false;
                            }
                        }

                    } break;
            }
            MarcaCasillas(Horario_Sabado_Grid.Name);
        }

        private void Horario_Sabado_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_lista_sesiones != null && e.RowIndex != -1
                && _lista_sesiones[e.RowIndex + 70].Estado == 3
                && (Horario_Sabado_Grid.Columns[e.ColumnIndex].Name == Clase_S_CBC.Name
                || Horario_Sabado_Grid.Columns[e.ColumnIndex].Name == Instructor_S_CBC.Name)) e.Cancel = true;
            else
            {
                if (_lista_sesiones != null && e.RowIndex != -1)
                {
                    _modificada = new SesionAuxiliar();
                    _modificada.Copia(_lista_sesiones[e.RowIndex + 70], false);
                }
                else
                    _modificada = null;
            }
        }

        private void Horario_Sabado_Grid_DoubleClick(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == Impartida_S.Name
                || ((DataGridView)sender).CurrentCell.OwningColumn.Name == Instructor_S_CBC.Name)
                return;

            if (CurrentSesion_S.Estado == 3) return;
            SesionAuxiliar aux = CurrentSesion_S;

            SelectClasesAction(aux);
        }

        private void Horario_Lunes_Grid_DoubleClick(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == Impartida_L.Name
                || ((DataGridView)sender).CurrentCell.OwningColumn.Name == Instructor_L_CBC.Name)
                return;

            if (CurrentSesion_L.Estado == 3) return;
            SesionAuxiliar aux = CurrentSesion_L;

            SelectClasesAction(aux);
        }

        private void Horario_Martes_Grid_DoubleClick(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == Impartida_M.Name
                || ((DataGridView)sender).CurrentCell.OwningColumn.Name == Instructor_M_CBC.Name)
                return;

            if (CurrentSesion_M.Estado == 3) return;
            SesionAuxiliar aux = CurrentSesion_M;

            SelectClasesAction(aux);
        }

        private void Horario_Miercoles_Grid_DoubleClick(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == Impartida_X.Name
                || ((DataGridView)sender).CurrentCell.OwningColumn.Name == Instructor_X_CBC.Name)
                return;

            if (CurrentSesion_X.Estado == 3) return;
            SesionAuxiliar aux = CurrentSesion_X;

            SelectClasesAction(aux);
        }

        private void Horario_Jueves_Grid_DoubleClick(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == Impartida_J.Name
                || ((DataGridView)sender).CurrentCell.OwningColumn.Name == Instructor_J_CBC.Name)
                return;

            if (CurrentSesion_J.Estado == 3) return;
            SesionAuxiliar aux = CurrentSesion_J;

            SelectClasesAction(aux);

        }

        private void Horario_Viernes_Grid_DoubleClick(object sender, EventArgs e)
        {
            if (this is HorarioViewForm) return;

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == Impartida_V.Name
                || ((DataGridView)sender).CurrentCell.OwningColumn.Name == Instructor_V_CBC.Name)
                return;

            if (CurrentSesion_V.Estado == 3) return;
            SesionAuxiliar aux = CurrentSesion_V;

            SelectClasesAction(aux);
        }

        #endregion

    }
}