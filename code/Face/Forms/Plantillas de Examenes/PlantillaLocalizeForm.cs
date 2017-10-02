using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using CslaEx;

using moleQule.Face.Skin02;

using moleQule.Library.Instruction; 
using moleQule.Library;

namespace moleQule.Face.Instruction
{
    public partial class PlantillaLocalizeForm : moleQule.Face.Skin02.LocalizeSkinForm
    {

        #region Bussiness Methods

        protected HComboBoxSourceList _combo_modulos;
        protected HComboBoxSourceList _combo_tipo;
        protected HComboBoxSourceList _combo_idioma;
        protected SubmoduloList _submodulos;

        PlantillaExamenList _lista;

        public PlantillaExamenList Lista
        {
            set
            {
                _lista = value;
                Datos.DataSource = _lista;
                Datos.MoveFirst();
            }
        }

        override public long ActiveOID()
        {
            if (Datos.Current != null)
                return ((PlantillaExamenInfo)(Datos.Current)).Oid;
            else
                return -1;
        }

        #endregion

        #region Factory Methods

        public PlantillaLocalizeForm()
        {
            InitializeComponent();
            RefreshSecondaryData();
            this.Text = Resources.Labels.PLANTILLA_FIND_TITLE;

        }

        #endregion

        #region Style & Source

        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            _combo_modulos = new HComboBoxSourceList(modulos);

            _submodulos = SubmoduloList.GetList(false);
            _combo_modulos.Childs = new HComboBoxSourceList(_submodulos);
            Datos_Modulos.DataSource = _combo_modulos;

            HComboBoxSourceList _combo_idiomas = new HComboBoxSourceList();
            _combo_idiomas.Add(new ComboBoxSource(0, ""));
            _combo_idiomas.Add(new ComboBoxSource(1, "Español"));
            _combo_idiomas.Add(new ComboBoxSource(2, "Inglés"));
            Datos_Idiomas.DataSource = _combo_idiomas;
        }

        #endregion

        #region Buttons

        protected override bool DoSearch()
        {
            if (_lista == null)
            {
                MessageBox.Show(Resources.Messages.NO_RESULTS);
                return false;
            }

            string idioma = string.Empty;

            if (((ComboBoxSource)Idioma_CB.SelectedItem).Oid > 0)
            {
                if (((ComboBoxSource)Idioma_CB.SelectedItem).Oid == 1)
                    idioma = "Español";
                else
                    idioma = "Inglés";
            }

            PlantillaExamenList lista = null;

            lista = PlantillaExamenList.GetPlantillasFiltradas(((ComboBoxSource)Modulo_CB.SelectedItem).Oid, idioma, Filtro_CB.Checked, Desarrollo_CB.Checked);

            // Consulta en la bd 
            Datos.DataSource = lista;

            if (lista.Count == 0)
            {
                MessageBox.Show(Resources.Messages.NO_RESULTS);
                return false;
            }

            Datos.MoveFirst();

            return true;

        }

        protected override bool DoFilter()
        {
            if (_lista == null)
            {
                MessageBox.Show(Resources.Messages.NO_RESULTS);
                return false;
            }

            // Consulta en la bd 

            string idioma = string.Empty;

            if (((ComboBoxSource)Idioma_CB.SelectedItem).Oid > 0)
            {
                if (((ComboBoxSource)Idioma_CB.SelectedItem).Oid == 1)
                    idioma = "Español";
                else
                    idioma = "Inglés";
            }

            PlantillaExamenList lista = null;

            lista = PlantillaExamenList.GetPlantillasFiltradas(((ComboBoxSource)Modulo_CB.SelectedItem).Oid, idioma, Filtro_CB.Checked, Desarrollo_CB.Checked);

            Datos.DataSource = lista;

            if (lista.Count == 0)
            {
                MessageBox.Show(Resources.Messages.NO_RESULTS);
                return false;
            }

            Datos.MoveFirst();

            _filtered_list = lista;

            return true;

        }

        #endregion

        #region Events

        private void Filtro_CB_CheckedChanged(object sender, EventArgs e)
        {
            Filtros_GB.Enabled = Filtro_CB.Checked;
        }

        #endregion

    }
}

