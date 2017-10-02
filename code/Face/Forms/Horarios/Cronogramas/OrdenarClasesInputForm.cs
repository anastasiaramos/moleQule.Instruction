using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 


namespace moleQule.Face.Instruction
{
    public partial class OrdenarClasesInputForm : InputSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "OrdenarClasesInputForm";
        public static Type Type { get { return typeof(OrdenarClasesInputForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Cronograma _entity;
        private int _index;
        private int _count;
        private int _destino;

        public Cronograma Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        ClaseTeoricaList _teoricas = null;
        ClasePracticaList _practicas = null;

        #endregion

        #region Factory Methods

        public OrdenarClasesInputForm()
            : this(true, 0) { }

        public OrdenarClasesInputForm(bool IsModal, int pos)
            : this(IsModal, 0, null) { }

        public OrdenarClasesInputForm(bool IsModal, int pos, Form parent)
            : base(IsModal, parent)
        {
            InitializeComponent();
            _index = pos - 1;
            SetFormData();
            this.Text = Resources.Labels.ORDENAR_CLASES_TITLE;
        }

        public void SetSourceData(Cronograma item, int count, ClaseTeoricaList teoricas, ClasePracticaList practicas)
        {
            _entity = item;
            _count = count;
            _teoricas = teoricas;
            _practicas = practicas;
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

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            OrdenViejo_TB.Text = (_index + 1).ToString();
            PgMng.FillUp();
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (OrdenNuevo_TB.Text != string.Empty)
            {
                if (Convert.ToInt64(OrdenNuevo_TB.Text) > _count)
                {
                    MessageBox.Show("El valor introducido es menor que el número de clases del cronograma.");
                    return;
                }

                _destino = Convert.ToInt32(OrdenNuevo_TB.Text) - 1;

                if (_destino < 0)
                {
                    MessageBox.Show("El valor introducido debe ser mayor que 0.");
                    return;
                }

                if (_index != _destino)
                {                    
                    /*int lim_inf = 0;
                    int lim_sup = 0;
                    long oid_lim_inf = 0, oid_lim_sup = 0;

                    if (_index < _destino)
                    {
                        lim_inf = _index;
                        lim_sup = _destino;
                    }
                    else
                    {
                        lim_inf = _destino;
                        lim_sup = _index;
                    }

                    if (_entity.Sesiones[lim_inf].OidClaseTeorica != 0)
                        oid_lim_inf = _teoricas.GetItem(_entity.Sesiones[lim_inf].OidClaseTeorica).OidModulo;
                    else
                        oid_lim_inf = _practicas.GetItem(_entity.Sesiones[lim_inf].OidClasePractica).OidModulo;

                    if (_entity.Sesiones[lim_sup].OidClaseTeorica != 0)
                        oid_lim_sup = _teoricas.GetItem(_entity.Sesiones[lim_sup].OidClaseTeorica).OidModulo;
                    else
                        oid_lim_sup = _practicas.GetItem(_entity.Sesiones[lim_sup].OidClasePractica).OidModulo;

                    //para el que baja
                    for (int i = lim_inf + 1; i <= lim_sup; i++)
                    {
                        if (_entity.Sesiones[lim_inf].OidClaseTeorica != 0)
                        {
                            if (oid_lim_inf == _teoricas.GetItem(_entity.Sesiones[i].OidClaseTeorica).OidModulo)
                            {
                                _entity.Sesiones[lim_inf].Numero++;
                                _entity.Sesiones[i].Numero--;
                            }
                        }
                        else
                        {
                            if (oid_lim_inf == _practicas.GetItem(_entity.Sesiones[i].OidClasePractica).OidModulo)
                            {
                                _entity.Sesiones[lim_inf].Numero++;
                                _entity.Sesiones[i].Numero--;
                            }
                        }
                    }

                    //para el que baja
                    for (int i = lim_sup - 1; i >= lim_inf; i--)
                    {
                        if (_entity.Sesiones[lim_sup].OidClaseTeorica != 0)
                        {
                            if (oid_lim_sup == _teoricas.GetItem(_entity.Sesiones[i].OidClaseTeorica).OidModulo)
                            {
                                _entity.Sesiones[lim_sup].Numero--;
                                _entity.Sesiones[i].Numero++;
                            }
                        }
                        else
                        {
                            if (oid_lim_sup == _practicas.GetItem(_entity.Sesiones[i].OidClasePractica).OidModulo)
                            {
                                _entity.Sesiones[lim_sup].Numero--;
                                _entity.Sesiones[i].Numero++;
                            }
                        }
                    }*/

                    SesionCronograma aux = _entity.Sesiones[_index];
                    long aux_semana = _entity.Sesiones[_destino].Semana;
                    long aux_dia = _entity.Sesiones[_destino].Dia;
                    long aux_turno = _entity.Sesiones[_destino].Turno;
                    _entity.Sesiones[_index] = _entity.Sesiones[_destino];
                    _entity.Sesiones[_index].Semana = aux.Semana;
                    _entity.Sesiones[_index].Dia = aux.Dia;
                    _entity.Sesiones[_index].Turno = aux.Turno;
                    _entity.Sesiones[_destino] = aux;
                    _entity.Sesiones[_destino].Semana = aux_semana;
                    _entity.Sesiones[_destino].Dia = aux_dia;
                    _entity.Sesiones[_destino].Turno = aux_turno;

                    ListaContadores lista_count = new ListaContadores();

                    long oid_modulo_index = _entity.Sesiones[_index].OidClaseTeorica > 0 ?
                        _teoricas.GetItem(_entity.Sesiones[_index].OidClaseTeorica).OidModulo :
                        _practicas.GetItem(_entity.Sesiones[_index].OidClasePractica).OidModulo;

                    long oid_modulo_destino = _entity.Sesiones[_destino].OidClaseTeorica > 0 ?
                        _teoricas.GetItem(_entity.Sesiones[_destino].OidClaseTeorica).OidModulo :
                        _practicas.GetItem(_entity.Sesiones[_destino].OidClasePractica).OidModulo;

                    for (int i = 0; i < _entity.Sesiones.Count; i++)
                    {
                        if (_entity.Sesiones[i].Modulo == _entity.Sesiones[_index].Modulo)
                            _entity.Sesiones[i].Numero = lista_count.NuevoContador(oid_modulo_index);

                        if (_entity.Sesiones[i].Modulo == _entity.Sesiones[_destino].Modulo)
                            _entity.Sesiones[i].Numero = lista_count.NuevoContador(oid_modulo_destino);
                    }
                }

                _action_result = DialogResult.OK;
                Close();
            }

        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            if (!IsModal)
                _entity.CancelEdit();
            _action_result = DialogResult.Cancel;

            Cerrar();
        }

        #endregion

        #region Events

        private void OrdenarClasesInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
                Entity.CancelEdit();
            }

            Cerrar();

        }

        #endregion

    }
}

