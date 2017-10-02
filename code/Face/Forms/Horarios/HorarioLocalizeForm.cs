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
    public partial class HorarioLocalizeForm : LocalizeSkinForm
    {

        #region Bussiness Methods

        HorarioList _lista;

        public HorarioList Lista
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
                return ((HorarioInfo)(Datos.Current)).Oid;
            else
                return -1;
        }

        #endregion

        #region Factory Methods

        public HorarioLocalizeForm()
        {
            InitializeComponent();
            this.Text = Resources.Labels.HORARIO_FIND_TITLE;
            Valor_TB.Text = " ";
        }

        #endregion

        #region Buttons

        protected override bool DoSearch()
        {
            bool promo = false;
            bool plan = false;
            PromocionList sublist = null;
            PlanEstudiosList sublist_plan = null;

            DateTime inicio = DateTime.MinValue;
            DateTime fin = DateTime.MaxValue;

            if (Desde_DTP.Checked)
                inicio = Desde_DTP.Value;

            if (Hasta_DTP.Checked)
                fin = Hasta_DTP.Value;

            if (_lista == null)
            {
                MessageBox.Show(Resources.Messages.NO_RESULTS);
                return false;
            }

            FCriteria criteria = null;

            if (Valor_TB.Text != " ")
            {
                foreach (Control ctl in this.Campos_Groupbox.Controls)
                {
                    if (((System.Windows.Forms.RadioButton)ctl).Checked)
                    {
                        switch (ctl.Name)
                        {
                            case "Promocion_RB":
                                {
                                    CriteriaEx criteriaex = Promocion.GetCriteria(Promocion.OpenSession());
                                    criteriaex.AddContains("Nombre", Valor_TB.Text);
                                    criteriaex.Childs = false;
                                    sublist = PromocionList.GetList(criteriaex);
                                    // No existe la promoción
                                    if (sublist.Count == 0)
                                    {
                                        MessageBox.Show(Resources.Messages.NO_RESULTS);
                                        return false;
                                    }
                                    promo = true;
                                    break;
                                }
                            case "Plan_RB":
                                {
                                    CriteriaEx criteriaex = PlanEstudios.GetCriteria(PlanEstudios.OpenSession());
                                    criteriaex.AddContains("Nombre", Valor_TB.Text);
                                    criteriaex.Childs = false;
                                    sublist_plan = PlanEstudiosList.GetList(criteriaex);
                                    // No existe la promoción
                                    if (sublist_plan.Count == 0)
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
            }

            // Consulta en la bd 
            SortedBindingList<HorarioInfo> lista = null;

            if (SortProperty != string.Empty)
            {
                if (promo)
                {
                    HorarioList list = HorarioList.GetList(HorarioList.GetFilteredList(HorarioList.GetFilteredFechaList(_lista, inicio, fin),
                                                            sublist, "OidPromocion"));
                    lista = list.ToSortedList(SortProperty, SortDirection);
                }
                else
                {
                    if (plan)
                    {
                        HorarioList list = HorarioList.GetList(HorarioList.GetFilteredList(HorarioList.GetFilteredFechaList(_lista, inicio, fin),
                                                                sublist_plan, "OidPlan"));
                        lista = list.ToSortedList(SortProperty, SortDirection);
                    }
                    else
                        lista = HorarioList.SortList(HorarioList.GetFilteredFechaList(_lista, inicio, fin), SortProperty, SortDirection); ;
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
            bool plan = false;
            PromocionList sublist = null;
            PlanEstudiosList sublist_plan = null;

            DateTime inicio = DateTime.MinValue;
            DateTime fin = DateTime.MaxValue;

            if (Desde_DTP.Checked)
                inicio = Desde_DTP.Value;

            if (Hasta_DTP.Checked)
                fin = Hasta_DTP.Value;

            if (_lista == null)
            {
                MessageBox.Show(Resources.Messages.NO_RESULTS);
                return false;
            }

            if (Valor_TB.Text != " ")
            {
                foreach (Control ctl in this.Campos_Groupbox.Controls)
                {
                    if (((System.Windows.Forms.RadioButton)ctl).Checked)
                    {
                        switch (ctl.Name)
                        {
                            case "Promocion_RB":
                                {
                                    CriteriaEx criteriaex = Promocion.GetCriteria(Promocion.OpenSession());
                                    criteriaex.AddContains("Nombre", Valor_TB.Text);
                                    criteriaex.Childs = false;
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
                            case "Plan_RB":
                                {
                                    CriteriaEx criteriaex = PlanEstudios.GetCriteria(PlanEstudios.OpenSession());
                                    criteriaex.AddContains("Nombre", Valor_TB.Text);
                                    criteriaex.Childs = false;
                                    sublist_plan = PlanEstudiosList.GetList(criteriaex);
                                    // No existe el plan
                                    if (sublist_plan.Count == 0)
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
            }

           // Consulta en la bd 
            HorarioList lista = null;

            if (promo)
                lista = HorarioList.GetList(HorarioList.GetFilteredList(HorarioList.GetFilteredFechaList(_lista, inicio, fin),
                                                                        sublist, "OidPromocion"));
            else
            {
                if (plan)
                    lista = HorarioList.GetList(HorarioList.GetFilteredList(HorarioList.GetFilteredFechaList(_lista, inicio, fin),
                                                                            sublist_plan, "OidPlan"));
                else
                    lista = HorarioList.GetFilteredFechaList(_lista, inicio, fin);
            }
                
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

