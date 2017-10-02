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
    public partial class PromocionLocalizeForm : LocalizeSkinForm
    {

        #region Bussiness Methods

        PromocionList _lista;

        public PromocionList Lista
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
                return ((PromocionInfo)(Datos.Current)).Oid;
            else
                return -1;
        }

        #endregion

        #region Factory Methods

        public PromocionLocalizeForm()
        {
            InitializeComponent();
            this.Text = Resources.Labels.PROMOCION_FIND_TITLE;

        }

        #endregion

        #region Buttons

        protected override bool DoSearch()
        {
            bool plan = false;
            PlanEstudiosList sublist = null;

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

                        case "Plan_RB":
                            {
                                CriteriaEx criteriaex = PlanEstudios.GetCriteria(PlanEstudios.OpenSession());
                                criteriaex.AddContains("Nombre", Valor_TB.Text);
                                sublist = PlanEstudiosList.GetList(criteriaex);
                                // No existe el plan
                                if (sublist.Count == 0)
                                {
                                    MessageBox.Show(Resources.Messages.NO_RESULTS);
                                    return false;
                                }
                                plan = true;
                                break;
                            }
                    }
                }
            }

            // Consulta en la bd 
            SortedBindingList<PromocionInfo> lista;

            if (SortProperty != string.Empty)
            {
                if (!plan)
                    lista = _lista.GetSortedSubList(criteria, SortProperty, SortDirection);
                else
                {
                    PromocionList list = PromocionList.GetList(PromocionList.GetFilteredList(_lista, sublist, "OidPlan"));
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
            bool plan = false;
            PlanEstudiosList sublist = null;

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

                        case "Plan_RB":
                            {
                                CriteriaEx criteriaex = PlanEstudios.GetCriteria(PlanEstudios.OpenSession());
                                criteriaex.AddContains("Nombre", Valor_TB.Text);

                                sublist = PlanEstudiosList.GetList(criteriaex);
                                // No existe el proveedor
                                if (sublist.Count == 0)
                                {
                                    MessageBox.Show(Resources.Messages.NO_RESULTS);
                                    return false;
                                }
                                plan = true;
                                break;
                            }
                    }
                }
            }

            // Consulta en la bd 
            PromocionList lista = null;

            if (!plan)
                lista = PromocionList.GetList(_lista.GetSubList(criteria));
            else
                lista = PromocionList.GetList(PromocionList.GetFilteredList(_lista, sublist, "OidPlan"));

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

