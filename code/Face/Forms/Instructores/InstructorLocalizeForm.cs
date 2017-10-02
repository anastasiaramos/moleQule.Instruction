using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class InstructorLocalizeForm : LocalizeSkinForm
    {

        #region Bussiness Methods

        InstructorList _lista;

        public InstructorList Lista
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
                return ((InstructorInfo)(Datos.Current)).Oid;
            else
                return -1;
        }

        #endregion

        #region Factory Methods

        public InstructorLocalizeForm()
        {
            InitializeComponent();
            this.Text = Resources.Labels.INSTRUCTOR_FIND_TITLE;

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

            FCriteria criteria = null;

            foreach (Control ctl in this.Campos_Groupbox.Controls)
            {
                if (((System.Windows.Forms.RadioButton)ctl).Checked)
                {
                    switch (ctl.Name)
                    {
                        case "Nombre_RB":
                            {
                                criteria = new FCriteria<string>("Nombre", Valor_TB.Text);
                                break;
                            }

                        case "ID_RB":
                            {
                                criteria = new FCriteria<string>("Id", Valor_TB.Text);
                                break;
                            }
                        case "Alias_RB":
                            {
                                criteria = new FCriteria<string>("Alias", Valor_TB.Text);
                                break;
                            }
                    }
                }
            }

            // Consulta en la bd 
            SortedBindingList<InstructorInfo> lista = null;

            if (SortProperty != string.Empty)
                lista = _lista.GetSortedSubList(criteria, SortProperty, SortDirection);
            else
                lista = _lista.GetSortedSubList(criteria, "Oid", SortDirection);

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

            FCriteria criteria = null;

            foreach (Control ctl in this.Campos_Groupbox.Controls)
            {
                if (((System.Windows.Forms.RadioButton)ctl).Checked)
                {
                    switch (ctl.Name)
                    {
                        case "Nombre_RB":
                            {
                                criteria = new FCriteria<string>("Nombre", Valor_TB.Text);
                                break;
                            }

                        case "ID_RB":
                            {
                                criteria = new FCriteria<string>("Id", Valor_TB.Text);
                                break;
                            }
                        case "Alias_RB":
                            {
                                criteria = new FCriteria<string>("Alias", Valor_TB.Text);
                                break;
                            }
                    }
                }
            }

            // Consulta en la bd 
            InstructorList lista = null;

            lista = InstructorList.GetList(_lista.GetSubList(criteria));

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

    }
}

