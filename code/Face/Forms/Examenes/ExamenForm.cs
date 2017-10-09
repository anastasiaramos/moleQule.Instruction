using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ExamenForm : Skin01.ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public virtual Examen Entity { get { return null; } set { } }
        public virtual ExamenInfo EntityInfo { get { return null; } }

        protected bool _cerrado = true;
        //protected Preguntas _preguntas = null;
        protected ModuloInfo _modulo = null;
        protected SubmoduloList _submodulos = null;
        protected TemaList _temas = null;
        protected List<long> preguntas_mismo_dia = null;
        protected List<long> preguntas_reservadas = null;

        protected PromocionList promociones = null;
        protected Dictionary<string, PromocionInfo> _promociones_select = new Dictionary<string, PromocionInfo>();
        protected Dictionary<string, PromocionInfo> _promociones_todas = new Dictionary<string, PromocionInfo>();

        //Mantiene una lista actualizada con todas las preguntas del módulo al que pertenece el examen
        protected PreguntaList _preguntas_modulo = null;
        //Mantiene una lista actualizada con todas las respuestas a las preguntas del módulo al que pertenece el examen
        protected RespuestaList _respuestas_modulo = null;

        protected PreguntaList PreguntasModulo { get { return _preguntas_modulo; } set { _preguntas_modulo = value; } }
        protected RespuestaList RespuestasModulo { get { return _respuestas_modulo; } set { _respuestas_modulo = value; } }

        #endregion

        #region Factory Methods

        public ExamenForm() : this(-1, true) { }

        public ExamenForm(bool isModal) : this(-1, isModal) { }

        public ExamenForm(long oid) : this(oid, true) { }

        public ExamenForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            RefreshChildren = false;

        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            List<string> visibles = new List<string>();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Texto.Tag = "1";

            cols.Add(Texto);

            ControlsMng.MaximizeColumns(Preguntas_Grid, cols);
            ControlsMng.MarkGridColumn(Preguntas_Grid, ControlsMng.GetCurrentColumn(Preguntas_Grid));
        }

        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);
            Datos_Modulos.DataSource = _combo_modulos;
            PgMng.Grow(string.Empty, "_combo_modulos");

            InstructorList instructores = InstructorList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_instructores = new Library.Instruction.HComboBoxSourceList(instructores);
            Datos_Instructores.DataSource = _combo_instructores;
            PgMng.Grow(string.Empty, "_combo_instructores");

            PromocionList promociones = PromocionList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_promociones = new Library.Instruction.HComboBoxSourceList(promociones);
            ComboBoxSource combo = new ComboBoxSource(-1, "No especificado");
            _combo_promociones.Add(combo);
            Datos_Promociones.DataSource = _combo_promociones;
            PgMng.Grow(string.Empty, "_combo_promociones");

            //_respuestas = RespuestaList.GetList();
        }

        protected void GetPreguntasReservadas()
        {
            preguntas_mismo_dia = ExamenList.GetPreguntasReservadas(Entity);
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected virtual void RellenaPreguntas() { }
        protected virtual void RellenaPromociones() { }
        protected virtual void QuitarAction() { }
        protected virtual void SetPreguntasAction() { }
        protected virtual void EmitirAction() { }
        protected virtual void Liberar_Button() { }
        protected virtual void ResumenAction() { }
        protected virtual void ProponerAction() { }
        protected virtual void CellContentClick(int column, int row) { }
        protected virtual void Desarrollo_Check() { }
        protected virtual void AlumnosAction() { }
        protected virtual void ResumenPreguntasAction() { }

        #endregion

        #region Buttons

        private void Quitar_BT_Click(object sender, EventArgs e)
        {
            QuitarAction();
        }

        private void Preguntas_BT_Click(object sender, EventArgs e)
        {
            SetPreguntasAction();
        }

        private void Cerrar_BT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Emitir_BT_Click(object sender, EventArgs e)
        {
            EmitirAction();
        }

        private void Resumen_BT_Click(object sender, EventArgs e)
        {
            ResumenAction();
        }

        private void Proponer_BT_Click(object sender, EventArgs e)
        {
            ProponerAction();
        }

        private void Print_BT_Click(object sender, EventArgs e)
        {
            PrintAction();
        }

        private void Alumnos_BT_Click(object sender, EventArgs e)
        {
            AlumnosAction();
        }

        private void ResumenPreguntas_BT_Click(object sender, EventArgs e)
        {
            ResumenPreguntasAction();
        }

        private void Promocion_BT_Click(object sender, EventArgs e)
        {
            if (promociones == null) return;
            if (this is ExamenViewForm) return;

            try
            {
                PromocionSelectForm form = new PromocionSelectForm(this, promociones);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.Selected is PromocionInfo)
                    {
                        PromocionInfo info = form.Selected as PromocionInfo;

                        ExamenPromocion item = Entity.Promociones.GetItem(new FCriteria<long>("OidPromocion", info.Oid));
                        if (item == null)
                        {
                            ExamenPromocion nuevo = Entity.Promociones.NewItem(Entity);
                            nuevo.OidPromocion = info.Oid;
                        }

                    }
                    else if (form.Selected is SortedBindingList<PromocionInfo>)
                    {
                        SortedBindingList<PromocionInfo> promos = form.Selected as SortedBindingList<PromocionInfo>;

                        foreach (PromocionInfo info in promos)
                        {
                            ExamenPromocion item = Entity.Promociones.GetItem(new FCriteria<long>("OidPromocion", info.Oid));
                            if (item == null)
                            {
                                ExamenPromocion nuevo = Entity.Promociones.NewItem(Entity);
                                nuevo.OidPromocion = info.Oid;
                            }
                        }
                    }

                    RellenaPromociones();
                }
            }
            catch { throw new iQException("Promocion_BT_Click"); }
        }

        private void ClearPromociones_BT_Click(object sender, EventArgs e)
        {
            if (this is ExamenViewForm) return;

            try
            {
                Entity.Promociones.RemoveAll();
                RellenaPromociones();
            }
            catch { throw new iQException("ClearPromociones_BT_Click"); }
        }

        private void Promociones_CLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this is ExamenViewForm) return;

            if (e.NewValue == e.CurrentValue) return;

            try
            {
                PromocionInfo promo = _promociones_todas[Promociones_CLB.Items[e.Index].ToString()];

                if (e.NewValue == CheckState.Unchecked)
                {
                    ExamenPromocion item = Entity.Promociones.GetItem(new FCriteria<long>("OidPromocion", promo.Oid));
                    Entity.Promociones.Remove(item);
                    RellenaPromociones();
                }
                else if (e.NewValue == CheckState.Checked)
                {
                    ExamenPromocion esta = Entity.Promociones.GetItem(new FCriteria<long>("OidPromocion", promo.Oid));
                    if (esta == null)
                    {
                        ExamenPromocion item = Entity.Promociones.NewItem(Entity);
                        item.OidPromocion = promo.Oid;
                        RellenaPromociones();
                    }
                }

            }
            catch { throw new iQException("Promociones_CLB_ItemCheck"); }

        }

        #endregion

        #region Events

        private void Preguntas_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Preguntas_Grid.Name);
        }

        private void Preguntas_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CellContentClick(e.ColumnIndex, e.RowIndex);
        }

        /// <summary>
        /// si se cambia el tipo de examen, habrá que eliminar de la lista las preguntas que no sean del mismo tipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void desarrolloCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Desarrollo_Check();
        }

        private void FExamen_DTP_ValueChanged(object sender, EventArgs e)
        {
            if (this is ExamenViewForm) return;

            if (FExamen_DTP.Value.Date.Equals(EntityInfo.FechaExamen.Date)
                && FExamen_DTP.Checked) return;

            if (FExamen_DTP.Checked)
            {
                GetPreguntasReservadas();

                Entity.FechaExamen = FExamen_DTP.Value;

                for (int i = Entity.Pregunta_Examens.Count - 1; i >= 0; i--)
                {
                    if (preguntas_mismo_dia.Contains(Entity.Pregunta_Examens[i].OidPregunta))
                        Entity.Pregunta_Examens.RemoveAt(i);
                }

                RellenaPreguntas();
            }
            else
                Entity.FechaExamen = DateTime.MaxValue;
        }


        #endregion

    }
}


