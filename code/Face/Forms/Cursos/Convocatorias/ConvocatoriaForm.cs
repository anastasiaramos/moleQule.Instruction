using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Library.Invoice;
using moleQule.Face.Invoice; 

namespace moleQule.Face.Instruction
{
    public partial class ConvocatoriaForm : moleQule.Face.Skin01.ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        protected Curso _curso;
        protected Convocatoria_Curso _entity;

        public Convocatoria_Curso Entity { get { return _entity; } set { _entity = value; } }
        public Convocatoria_CursoInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }        

        #endregion

        #region Factory Methods

        public ConvocatoriaForm() : this(-1, true) { }

        public ConvocatoriaForm(bool isModal) : this(-1, isModal) { }

        public ConvocatoriaForm(long oid) : this(oid, true) { }

        public ConvocatoriaForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
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

            visibles.Add(Cliente.Name);
            visibles.Add(Nombre.Name);
            visibles.Add(Fecha.Name);

            ControlTools.ShowDataGridColumns(Alumnos_Grid, visibles);

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Nombre.Tag = 0.5;
            Cliente.Tag = 0.5;
            cols.Add(Nombre);
            cols.Add(Cliente);

            ControlsMng.MaximizeColumns(Alumnos_Grid, cols);
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            Datos_Alumnos.DataSource = _entity.Alumnos;
            PgMng.Grow(string.Empty, "Datos_Alumnos");

            base.RefreshMainData();
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction()
        {
            if (_entity.FechaCaducidad.Date.Equals(DateTime.MinValue.Date))
                _entity.FechaCaducidad = DateTime.Today;

            if (_entity.FechaInicio.Date.Equals(DateTime.MinValue.Date))
                _entity.FechaInicio = DateTime.Today;

            _action_result = DialogResult.OK;
            Close();
        }

        #endregion

        #region Buttons

        private void Matricular_B_Click(object sender, EventArgs e)
        {
            if (_entity.FechaCaducidad < DateTime.Today)
            {
                MessageBox.Show(Resources.Messages.CONVOCATORIA_FINALIZADA);
                return;
            }

            AlumnoSelectForm formAlumno = new AlumnoSelectForm(this);

            if (formAlumno.ShowDialog() == DialogResult.OK)
            {
                AlumnoInfo alumno = formAlumno.Selected as AlumnoInfo;

                if (_entity.Alumnos.GetItemByAlumno(alumno.Oid) != null)
                {
                    MessageBox.Show(Resources.Messages.ALUMNO_YA_MATRICULADO);
                    return;
                }
                
                AlumnoClienteList aclientes = AlumnoClienteList.GetListByAlumno(alumno.Oid, false);

                if (aclientes.Count == 0)
                {
                    MessageBox.Show(Resources.Messages.NO_CLIENT_ASSOCIATED);
                    return;
                }
                else if (aclientes.Count == 1)
                    _entity.Alumnos.NewItem(_entity, aclientes[0]);
                else
                { 
                    List<string> oids = new List<string>();
                    foreach (AlumnoClienteInfo item in aclientes)
                        oids.Add(item.OidCliente.ToString());

                    ClienteList clientes = ClienteList.GetListByList(oids, false);
                    ClientSelectForm formClientes = new ClientSelectForm(this, clientes);

                    if (formClientes.ShowDialog() == DialogResult.OK)
                    {
                        ClienteInfo cliente = formClientes.Selected as ClienteInfo;
                        _entity.Alumnos.NewItem(_entity, alumno, cliente);
                    }
                }
            }
        }

        private void Eliminar_B_Click(object sender, EventArgs e)
        {
            if (Datos_Alumnos.Current == null) return;
            Alumno_Convocatoria alumno = Datos_Alumnos.Current as Alumno_Convocatoria;
            _entity.Alumnos.Remove(alumno);
        }

        #endregion

        #region Events

        private void ConvocatoriaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_curso == null) Entity.CloseSession();
            Cerrar();
        }

        #endregion

    }
}


