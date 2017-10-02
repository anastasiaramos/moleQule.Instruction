using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face.Common;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Library.Store;
using moleQule.Face.Store;

namespace moleQule.Face.Instruction
{
    public partial class InstructorUIForm : InstructorForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Instructor _entity;

        public override Instructor Entity { get { return _entity; } set { _entity = value; } }
        public override InstructorInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        private bool SubmoduloRepetido()
        {
            for (int i = 0; i < Entity.Submodulos.Count - 1; i++)
            {
                for (int j = i + 1; j < Entity.Submodulos.Count; j++)
                {
                    if (Entity.Submodulos[i].OidSubmodulo == Entity.Submodulos[j].OidSubmodulo
                        && ((Entity.Submodulos[i].FechaInicio <= Entity.Submodulos[j].FechaInicio 
                        && Entity.Submodulos[j].FechaInicio <= Entity.Submodulos[i].FechaFin)
                        || (Entity.Submodulos[i].FechaInicio <= Entity.Submodulos[j].FechaFin
                        && Entity.Submodulos[j].FechaFin <= Entity.Submodulos[i].FechaFin)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected InstructorUIForm() : this(-1, true) { }

        public InstructorUIForm(bool isModal) : this(-1, isModal) { }

        public InstructorUIForm(long oid) : this(oid, true) { }

        public InstructorUIForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                if (SubmoduloRepetido())
                {
                    MessageBox.Show("Sólo se puede incluir un profesor titular por submódulo y periodo");
                    return false;
                }

                Instructor temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    if (CapacidadRepetida())
                    {
                        MessageBox.Show("Se está añadiendo varias veces el mismo submódulo");
                        return false;
                    }
                    if (PromocionRepetida())
                    {
                        MessageBox.Show("Se está añadiendo varias veces la misma promoción");
                        return false;
                    }

                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    // Se modifica el nombre de la foto
                    if (_entity.Foto != string.Empty)
                    {
                        Bitmap imagen = new Bitmap(AppController.FOTOS_INSTRUCTORES_PATH + _entity.Foto);

                        string ext = string.Empty;

                        if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                            ext = ".jpg";
                        else
                        {
                            if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                                ext = ".bmp";
                            else
                            {
                                if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                    ext = ".png";
                            }
                        }

                        imagen.Dispose();

                        if (_entity.Foto != _entity.Oid.ToString("000") + ext)
                        {
                            File.Copy(AppController.FOTOS_INSTRUCTORES_PATH + _entity.Foto,
                                        AppController.FOTOS_INSTRUCTORES_PATH + _entity.Oid.ToString("000") + ext,
                                true);
                            File.Delete(AppController.FOTOS_INSTRUCTORES_PATH + _entity.Foto);

                            _entity.Foto = _entity.Oid.ToString("000") + ext;
                            _entity.Save();
                        }
                    }

                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }
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
		
		public override void RefreshSecondaryData()
        {
            base.RefreshSecondaryData();
    	} 

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow("Datos");

            //Ini_Contrato_DTP.Value = _entity.InicioContrato;
            //Fin_Contrato_DTP.Value = _entity.FinContrato;

            Datos_ProductoProveedor.DataSource = _entity.Productos;

            Datos_CursosFormacion.DataSource = CursoFormacions.SortList(_entity.CursosFormacion, "Fecha", ListSortDirection.Ascending);
            PgMng.Grow(string.Empty, "Datos_CursosFormacion");

            base.RefreshMainData();
		}

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "ID_GB":
                    {
                        NIF_RB.Checked = (Entity.TipoId == (long)TipoId.NIF);
                        NIE_RB.Checked = (Entity.TipoId == (long)TipoId.NIE);
                        DNI_RB.Checked = (Entity.TipoId == (long)TipoId.DNI);
                        Auto_RB.Checked = (Entity.TipoId == (long)TipoId.OTROS || EntityInfo.TipoId == 0);

                    } break;
                case "Perfil_GB":
                    {
                        RExamenes_CB.Checked = (EntityInfo.Perfil >> 2) % 2 == 1; 
                        Instructor_CB.Checked = (EntityInfo.Perfil >> 1) % 2 == 1;
                        Examinador_CB.Checked = EntityInfo.Perfil % 2 == 1;
                        Instructor_P_CB.Checked = (EntityInfo.Perfil >> 3) % 2 == 1;
                        RespInstruccion_CB.Checked = (EntityInfo.Perfil >> 4) % 2 == 1;
                        Resp_Calidad_CB.Checked = (EntityInfo.Perfil >> 5) % 2 == 1;
                        Evaluador_P_CB.Checked = (EntityInfo.Perfil >> 6) % 2 == 1; 
                        Gerente_CB.Checked = (EntityInfo.Perfil >> 8) % 2 == 1;
                        Administrador_CB.Checked = (EntityInfo.Perfil >> 9) % 2 == 1;
                        Auditor_CB.Checked = (EntityInfo.Perfil >> 7) % 2 == 1;
                    } break;
                case "Modulo_CBC":
                    {
                        Datos_Submodulos.DataSource = _combo_modulos.GetFilteredChilds(((ComboBoxSource)Datos_Modulos.Current).Oid);
                    } break;
            }
        }


        protected override void SetCellsDataSource(string gridName)
        {
            switch (gridName)
            {
                case "Submodulo_Instructor_Grid":
                    {
                        foreach (DataGridViewRow row in Submodulo_Instructor_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (lista_sources.Count >= row.Index + 1) continue;
                            Submodulo_Instructor_Promocion info = (Submodulo_Instructor_Promocion)row.DataBoundItem;
                            if ((info != null) && (_combo_modulos != null))
                            {
                                lista_sources.Add(_combo_modulos.GetFilteredChilds(info.OidModulo));
                                ((DataGridViewComboBoxCell)row.Cells["Submodulo_CBC"]).DataSource = lista_sources[row.Index];
                            }
                        }

                    } break;
                case "Autorizados_Grid":
                    {
                        foreach (DataGridViewRow row in Autorizados_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (lista_sources_a.Count >= row.Index + 1) continue;
                            Submodulo_Instructor info = (Submodulo_Instructor)row.DataBoundItem;
                            if ((info != null) && (_combo_modulos != null))
                            {
                                lista_sources_a.Add(_combo_modulos.GetFilteredChilds(info.OidModulo));
                                ((DataGridViewComboBoxCell)row.Cells["SubmoduloA_CBC"]).DataSource = lista_sources_a[row.Index];
                            }
                        }

                    } break;
            }
        }

        private bool CapacidadRepetida()
        {
            foreach (Instructor_Promocion pr in _entity.Promociones)
            {
                if (pr.IsDirty)
                {
                    for (int i = 0; i < pr.Submodulos.Count - 1; i++)
                    {
                        for (int j = i + 1; j < pr.Submodulos.Count; j++)
                        {
                            if (pr.Submodulos[i].OidSubmodulo == pr.Submodulos[j].OidSubmodulo
                                && pr.Submodulos[i].OidPromocion == pr.Submodulos[j].OidPromocion)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool PromocionRepetida()
        {
            for (int i = 0; i < _entity.Promociones.Count - 1; i++)
            {
                for (int j = i + 1; j < _entity.Promociones.Count; j++)
                {
                    if (_entity.Promociones[i].OidPromocion == _entity.Promociones[j].OidPromocion)
                        return true;
                }
            }
            return false;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            try
            {
                ValidateInput();
            }
            catch (iQValidationException ex)
            {
                MessageBox.Show(ex.Message,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                _action_result = DialogResult.Ignore;
                return;
            }

            if (_entity.Alias == string.Empty) _entity.Alias = _entity.Nombre;

            if (_entity.ExisteAlias(_entity.Alias, _entity.Oid))
                _entity.Alias = _entity.Alias + _entity.Apellidos.Substring(0, 3);

            if (_entity.ExisteAlias(_entity.Alias, _entity.Oid))
            {
                MessageBox.Show("Ya existe un usuario con el mismo alias.\nIntroduzca uno nuevo");
                
                _action_result = DialogResult.Ignore;
                return;
            }

            _entity.Alias = _entity.Alias.ToUpper();

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void LoadChildsAction(Type type)
        {
            if (type == typeof(Submodulo_Instructor_Promocion))
            {
                Datos_Promociones.DataSource = _entity.Promociones;

                if (Datos_Promociones.Current != null && ((Instructor_Promocion)Datos_Promociones.Current).OidPromocion > 0)
                {
                    _modulos = ModuloList.GetListByPromocion(false, ((Instructor_Promocion)Datos_Promociones.Current).OidPromocion);
                    _combo_modulos = new Library.Instruction.HComboBoxSourceList(ModuloList.SortList(_modulos, "NumeroOrden", ListSortDirection.Ascending));
                    Datos_Modulos.DataSource = _combo_modulos;

                    //_submodulos = SubmoduloList.GetList(false);
                    _combo_modulos.Childs = new Library.Instruction.HComboBoxSourceList(SubmoduloList.SortList(_submodulos, "CodigoOrden", ListSortDirection.Ascending));
                    Datos_Submodulos.DataSource = _combo_modulos.Childs;

                    Instructor_Promocion promo = Datos_Promociones.Current as Instructor_Promocion;
                    Datos_Submodulo_Instructor_Promocion.DataSource = promo.Submodulos;
                    SetCellsDataSource(Submodulo_Instructor_Grid.Name);
                }
            }
            if (type == typeof(Submodulo_Instructor))
            {
                Datos_Submodulo_Instructor.DataSource = _entity.Submodulos;
                PgMng.Grow(string.Empty, "Datos_Submodulo_Instructor");
            }
        }

        protected override void ChangeFicha()
        {
            if ((Ficha_TP.SelectedTab == Capacitacion_TP) ||
                   (Ficha_TP.SelectedTab == Autorizados_TP))
            {
                if (_modulos == null)
                {
                    PgMng.Reset(4, 1, Resources.Messages.LOADING_DATA, this);

                    _modulos = ModuloList.GetList(false);
                    _combo_modulos = new Library.Instruction.HComboBoxSourceList(ModuloList.SortList(_modulos, "NumeroOrden", ListSortDirection.Ascending));
                    Datos_Modulos.DataSource = _combo_modulos;
                    PgMng.Grow(string.Empty, "Modulos");

                    _submodulos = SubmoduloList.GetList(false);
                    _combo_modulos.Childs = new Library.Instruction.HComboBoxSourceList(SubmoduloList.SortList(_submodulos, "CodigoOrden", ListSortDirection.Ascending));
                    Datos_Submodulos.DataSource = _combo_modulos.Childs;
                    PgMng.Grow(string.Empty, "Submodulos");

                    _promociones = PromocionList.GetList(false);
                    Library.Instruction.HComboBoxSourceList _combo_promociones = new Library.Instruction.HComboBoxSourceList(PromocionList.SortList(_promociones, "Nombre", ListSortDirection.Ascending));
                    Datos_Promociones_CB.DataSource = _combo_promociones;
                    PgMng.Grow(string.Empty, "Promociones");

                    _instructores = InstructorList.GetList(false);
                    Library.Instruction.HComboBoxSourceList _combo_instructores = new Library.Instruction.HComboBoxSourceList(InstructorList.SortList(_instructores, "Apellidos", ListSortDirection.Ascending));
                    Datos_Instructores.DataSource = _combo_instructores;
                    PgMng.FillUp(string.Empty, "Instructores");
                }

                if (Ficha_TP.SelectedTab == Capacitacion_TP) LoadChildsAction(typeof(Submodulo_Instructor_Promocion));
                if (Ficha_TP.SelectedTab == Autorizados_TP) LoadChildsAction(typeof(Submodulo_Instructor));
            }
        }

        protected override void SetImpuestoAction()
        {
            ImpuestoSelectForm form = new ImpuestoSelectForm(this);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ImpuestoInfo item = form.Selected as ImpuestoInfo;
                Entity.SetImpuesto(item);
                Impuesto_TB.Text = Entity.Impuesto;
            }
        }

        protected override void SetImpuestoDefectoAction()
        {
            Entity.SetImpuesto(null);
            Impuesto_TB.Text = Entity.Impuesto;
        }

        protected override void SetCuentaAsociadaAction()
        {
            BankAccountSelectForm form = new BankAccountSelectForm(this);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                BankAccountInfo item = form.Selected as BankAccountInfo;

                _entity.OidCuentaBAsociada = item.Oid;
                _entity.CuentaAsociada = item.Valor;
            }
        }

        protected override void AddProductoAction()
        {
            ProductSelectForm form = new ProductSelectForm(this);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ProductInfo item = form.Selected as ProductInfo;

                _entity.Productos.NewItem(_entity, item);
                Datos_ProductoProveedor.ResetBindings(true);
            }
        }

        protected override void DeleteProductoAction()
        {
            if (Datos_ProductoProveedor.Current == null) return;

            //if (MessageBox.Show(Face.Resources.Messages.DELETE_CONFIRM,
            //                    Face.Resources.Labels.ADVISE_TITLE,
            //                    MessageBoxButtons.YesNoCancel,
            //                    MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                ProductoProveedor pp = (ProductoProveedor)Datos_ProductoProveedor.Current;
                _entity.Productos.Remove(pp.Oid);

                Datos_ProductoProveedor.ResetBindings(false);
            //}
        }

        protected override void SetImpuestoProductoAction()
        {
            if (Datos_ProductoProveedor.Current == null) return;

            ProductoProveedor item = (ProductoProveedor)Datos_ProductoProveedor.Current;

            ImpuestoSelectForm form = new ImpuestoSelectForm(this);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ImpuestoInfo impuesto = form.Selected as ImpuestoInfo;

                item.OidImpuesto = impuesto.Oid;
                item.Impuesto = impuesto.Nombre;
                item.PImpuestos = impuesto.Porcentaje;

                Datos_ProductoProveedor.ResetBindings(false);
            }
        }
        
        #endregion

        #region Buttons

        private void MunicipioP_Button_Click(object sender, EventArgs e)
        {
            MunicipioSelectForm form = new MunicipioSelectForm(this);
            form.ShowDialog();
        }

        private void MunicipioF_Button_Click(object sender, EventArgs e)
        {
            MunicipioSelectForm form = new MunicipioSelectForm(this);
            form.ShowDialog();
        }

        private void Examinador_RB_Click(object sender, EventArgs e)
        {
            Entity.Perfil = (long)moleQule.Library.Instruction.Perfil.Examinador;
        }

        private void Instructor_RB_Click(object sender, EventArgs e)
        {
            Entity.Perfil = (long)moleQule.Library.Instruction.Perfil.Instructor;
        }

        private void RExamenes_RB_Click(object sender, EventArgs e)
        {
            Entity.Perfil = (long)moleQule.Library.Instruction.Perfil.RExamenes;
        }


        private void Examinar_Button_Click(object sender, EventArgs e)
        {
            if (this is InstructorEditForm)
            {
                try
                {
                    if (Browser.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap imagen = new Bitmap(Browser.FileName);

                        string ext = string.Empty;

                        if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                            ext = ".jpg";
                        else
                        {
                            if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                                ext = ".bmp";
                            else
                            {
                                if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                    ext = ".png";
                            }
                        }

                        imagen.Dispose();

                        _entity.Foto = _entity.Oid.ToString("000") + ext;
                        File.Copy(Browser.FileName, AppController.FOTOS_INSTRUCTORES_PATH + _entity.Foto, true);
                    }

                    Images.Show(Entity.Foto, AppController.FOTOS_INSTRUCTORES_PATH, Logo_PictureBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Debe guardar la ficha del instructor actual antes de poder insertar una imagen");
        }

        private void Ninguno_Button_Click(object sender, EventArgs e)
        {
            Images.Delete(Entity.Foto, AppController.FOTOS_INSTRUCTORES_PATH);
            Entity.Foto = string.Empty;
            Images.Show(Entity.Foto, AppController.FOTOS_INSTRUCTORES_PATH, Logo_PictureBox);
        }


        private void Disponibilidad_BT_Click(object sender, EventArgs e)
        {
            /*DialogResult result = DialogResult.Yes; ;
            if (this is InstructorAddForm)
                result = MessageBox.Show("Es necesario que guarde el instructor para poder crearle su disponibilidad.\n¿Desea guardar?",
                                        "Aviso", MessageBoxButtons.YesNo);
            else
            {
                if (_entity.IsDirty)
                    result = MessageBox.Show("Para editar la disponibilidad del profesor es necesario cerrar el formulario actual.\n ¿Desea guardar antes de cerrar?",
                                "Aviso", MessageBoxButtons.YesNoCancel);
            }

            if (result == DialogResult.Yes)
                SaveAction();
            else
            {
                if (result == DialogResult.No)
                {
                    if (this is InstructorAddForm)
                        return;
                    else
                    {
                        if (!this.IsModal)
                            Entity.CancelEdit();
                        Entity.CloseSession();
                        Cerrar();
                        _cerrado = true;
                    }
                }
                else return;
            }

            if (_cerrado)
            {
                int sessCode = Disponibilidad.OpenSession();
                DisponibilidadEditForm edit_form = new DisponibilidadEditForm();
                edit_form.SeleccionaInstructor(Entity.Oid);
                edit_form.ShowDialog();
                nHManager.Instance.CloseSession(sessCode);
            }*/

            DisponibilidadEditForm edit_form = new DisponibilidadEditForm();
            edit_form.SeleccionaInstructor(Entity.Oid, Entity.SessionCode);
            edit_form.ShowDialog();

            if (edit_form.ActionResult == DialogResult.OK)
                _entity.UpdateDisponibilidades(edit_form.Entity);
        }


        #endregion

        #region Events

        private void FormaPago_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormaPago_CB.SelectedItem == null) return;

            ComboBoxSource item = FormaPago_CB.SelectedItem as ComboBoxSource;

            switch ((EFormaPago)item.Oid)
            {
                case EFormaPago.Contado:
                    DiasPago_NTB.Enabled = false;
                    _entity.DiasPago = 0;
                    break;
                case EFormaPago.XDiasFechaFactura:
                    DiasPago_NTB.Enabled = true;
                    break;
                case EFormaPago.XDiasMes:
                    DiasPago_NTB.Enabled = true;
                    break;
            }
        }

        private void MunicipioP_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MunicipioP_CB.SelectedItem != null)
            {
                MunicipioInfo municipio = _municipios.GetItem(((ComboBoxSource)MunicipioP_CB.SelectedItem).Oid);
                if (municipio != null)
                {
                    _entity.Municipio = municipio.Nombre;
                    _entity.Provincia = municipio.Provincia;
                    _entity.CodPostal = municipio.CodPostal;
                    Provincia_TextBox.Text = _entity.Provincia;
                    CodPostal_TextBox.Text = _entity.CodPostal;
                }
            }
        }

        private void MunicipioP_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Add) || e.KeyCode.Equals(Keys.Oemplus))
            {
                MunicipioSelectForm form = new MunicipioSelectForm(this);
                form.ShowDialog();
                MunicipioP_CB.ResetText();
            }
        }
        
        #endregion

    }
}
