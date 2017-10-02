using System;
using System.Collections;
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
    /// <summary>
    /// Search Form
    /// </summary>
    public partial class AlumnoLocalizeForm : LocalizeSkinForm
    {

        #region Bussiness Methods

        AlumnoList _lista;

        public AlumnoList Lista
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
                return ((AlumnoInfo)(Datos.Current)).Oid;
            else
                return -1;
        }

        #endregion

        #region Factory Methods

        public AlumnoLocalizeForm()
        {
            InitializeComponent();
            this.Text = Resources.Labels.ALUMNO_FIND_TITLE;
        }

        #endregion

        #region Buttons

        protected override bool DoSearch()
        {
            bool promo = false;
            PromocionList sublist = null;

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
                        case "Apellidos_RB":
                            {
                                criteria = new FCriteria<string>("Apellidos", Valor_TB.Text);
                                break;
                            }
                        case "Promocion_RB":
                            {
                                CriteriaEx criteriaex = Promocion.GetCriteria(Promocion.OpenSession());
                                criteriaex.AddContains("Nombre", Valor_TB.Text);
                                sublist = PromocionList.GetList(criteriaex);
                                // No existe el plan
                                if (sublist.Count == 0)
                                {
                                    MessageBox.Show(Resources.Messages.NO_RESULTS);
                                    return false;
                                }
                                promo = true;
                                break;
                            }
                    }
                }
            }

            // Consulta en la bd 
            SortedBindingList<AlumnoInfo> lista;

            if (SortProperty != string.Empty)
            {
                if (!promo)
                    lista = _lista.GetSortedSubList(criteria, SortProperty, SortDirection);
                else
                {
                    AlumnoList list = AlumnoList.GetList(AlumnoList.GetFilteredList(_lista, sublist, "OidPromocion"));
                    lista = list.ToSortedList(SortProperty, SortDirection);
                }
            }
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
            bool promo = false;
            PromocionList sublist = null;

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
                        case "Apellidos_RB":
                            {
                                criteria = new FCriteria<string>("Apellidos", Valor_TB.Text);
                                break;
                            }
                        case "Promocion_RB":
                            {
                                CriteriaEx criteriaex = Promocion.GetCriteria(Promocion.OpenSession());
                                criteriaex.AddContains("Nombre", Valor_TB.Text);

                                sublist = PromocionList.GetList(criteriaex);
                                // No existe el proveedor
                                if (sublist.Count == 0)
                                {
                                    MessageBox.Show(Resources.Messages.NO_RESULTS);
                                    return false;
                                }
                                promo = true;
                                break;
                            }
                    }
                }
            }

            // Consulta en la bd 
            AlumnoList lista = null;

            if (!promo)
                lista = AlumnoList.GetList(_lista.GetSubList(criteria));
            else
                lista = AlumnoList.GetList(AlumnoList.GetFilteredList(_lista, sublist, "OidPromocion"));

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

