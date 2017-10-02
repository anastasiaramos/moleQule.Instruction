using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ClaseHorarioSelectForm : Skin01.SelectSkinForm
    {

        #region Bussiness Methods

        private long _tipo;

        public long Tipo { get { return _tipo; } }

        #endregion

        #region Factory Methods

        public ClaseHorarioSelectForm(ListaSesiones sesiones,
                                      ClaseTeoricaList teoricas,
                                      ClasePracticaList practicas,
                                      ClaseExtraList extras)
            : base(true)
        {
            InitializeComponent();

            List<ClaseTeoricaInfo> t_ordenadas = teoricas.OrdenaLista();
            List<ClasePracticaInfo> p_ordenadas = practicas.OrdenaLista();

            List<ClaseTeoricaInfo> lista_teoricas = new List<ClaseTeoricaInfo>();
            List<ClasePracticaInfo> lista_practicas = new List<ClasePracticaInfo>();
            List<ClaseExtraInfo> lista_extras = new List<ClaseExtraInfo>();

            foreach (ClaseTeoricaInfo clase in t_ordenadas)
            {
                bool esta = false;
                foreach (SesionAuxiliar item in sesiones)
                {
                    if (item.OidClaseTeorica == clase.Oid)
                    {
                        if (item.Estado == 3)
                            esta = true;
                        break;
                    }
                }
                if (!esta)
                    lista_teoricas.Add(clase);
            }

            foreach (ClasePracticaInfo clase in p_ordenadas)
            {
                bool esta = false;
                foreach (SesionAuxiliar item in sesiones)
                {
                    if (item.OidClasePractica == clase.Oid && clase.Grupo == item.Grupo)
                    {
                        if (item.Estado == 3)
                            esta = true;
                        break;
                    }
                }
                if (!esta)
                    lista_practicas.Add(clase);
            }

            foreach (ClaseExtraInfo clase in extras)
            {
                bool esta = false;
                foreach (SesionAuxiliar item in sesiones)
                {
                    if (item.OidClaseExtra == clase.Oid)
                    {
                        if (item.Estado == 3)
                            esta = true;
                        break;
                    }
                }
                if (!esta)
                    lista_extras.Add(clase);
            }

            Datos_Teoricas.DataSource = lista_teoricas;

            Datos_Practicas.DataSource = lista_practicas;

            Datos_Extras.DataSource = lista_extras;

            this.Text = Resources.Labels.CLASE_HORARIO_TITLE;
        }

        #endregion

        #region Actions

        protected override void SubmitAction()
        {
            switch (Fichas_TP.SelectedIndex)
            {
                case 0:
                    {
                        if (Tabla_Teoricas.CurrentRow == null)
                            MessageBox.Show(Resources.Messages.NO_SELECTED);
                        else
                        {
                            _selected = Datos_Teoricas.Current;
                            _tipo = ((ClaseTeoricaInfo)_selected).Tipo;
                        }
                    } break;

                case 1:
                    {
                        if (Tabla_Practicas.CurrentRow == null)
                            MessageBox.Show(Resources.Messages.NO_SELECTED);
                        else
                        {
                            _selected = Datos_Practicas.Current;
                            _tipo = ((ClasePracticaInfo)_selected).Tipo;
                        }
                    } break;

                case 2:
                    {
                        if (Tabla_Extras.CurrentRow == null)
                            MessageBox.Show(Resources.Messages.NO_SELECTED);
                        else
                        {
                            _selected = Datos_Extras.Current;
                            _tipo = ((ClaseExtraInfo)_selected).Tipo;
                        }
                    } break;
            }

            _action_result = DialogResult.OK;
            Close();
        }

        #endregion

        #region Events

        private void ClaseHorarioSelectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Bar != null) PgMng.FillUp();
        }

        private void Tabla_Teoricas_DoubleClick(object sender, EventArgs e)
        {
            SubmitAction();
        }

        private void Tabla_Practicas_DoubleClick(object sender, EventArgs e)
        {
            SubmitAction();
        }

        private void Tabla_Extras_DoubleClick(object sender, EventArgs e)
        {
            SubmitAction();
        }

        private void Tabla_Teoricas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        SubmitAction();
                        return;
                    }

                case Keys.Down:
                case Keys.Up:
                    {
                        return;
                    }

                default:
                    {
                        //DataGridViewColumn col;

                        //if (Tabla_Teoricas.CurrentCell == null)
                        //{
                        //    if (Tabla_Teoricas.SortedColumn != null)
                        //        col = Tabla_Teoricas.SortedColumn;
                        //    else
                        //        col = Tabla_Teoricas.Columns[0];
                        //}
                        //else
                        //    col = Tabla_Teoricas.Columns[Tabla_Teoricas.CurrentCell.ColumnIndex];

                        //if (col.ValueType.Name == "Int32") return;
                        //if (col.ValueType.Name == "Int64") return;
                        //if (col.ValueType.Name == "Single") return;
                        //if (col.ValueType.Name == "Double") return;

                        //string car = e.KeyCode.ToString();
                        //FCriteria criteria = new FCriteria<string>(col.DataPropertyName,car);

                        ////criteria
                        //SortedBindingList<ClaseTeoricaInfo> teoricas = (ClaseTeoricaList)Datos_Teoricas.DataSource;

                        //// Buscamos las palabras que empiecen por el caracter
                        //List<ClaseTeoricaInfo> list = teoricas.GetSubList(criteria);

                        //int foundIndex;

                        //// Nos situamos en la primera aparicion de esa lista en la 
                        //// que se muestra. Esto se hace pq se ha consultado la bd y no la lista actual
                        //// lo que puede dar lugar a inconsistencias si otro usuario a cambiado la bd
                        //foreach (ClaseTeoricaInfo alm in list)
                        //{
                        //    foundIndex = Datos_Teoricas.IndexOf(alm);
                        //    if (foundIndex != -1)
                        //    {
                        //        Datos_Teoricas.Position = foundIndex;
                        //        break;
                        //    }
                        //}
                    } break;
            }
        }

        private void Tabla_Practicas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        SubmitAction();
                        return;
                    }

                case Keys.Down:
                case Keys.Up:
                    {
                        return;
                    }

                default:
                    {
                        //DataGridViewColumn col;

                        //if (Tabla_Practicas.CurrentCell == null)
                        //{
                        //    if (Tabla_Practicas.SortedColumn != null)
                        //        col = Tabla_Practicas.SortedColumn;
                        //    else
                        //        col = Tabla_Practicas.Columns[0];
                        //}
                        //else
                        //    col = Tabla_Practicas.Columns[Tabla_Practicas.CurrentCell.ColumnIndex];

                        //if (col.ValueType.Name == "Int32") return;
                        //if (col.ValueType.Name == "Int64") return;
                        //if (col.ValueType.Name == "Single") return;
                        //if (col.ValueType.Name == "Double") return;

                        //string car = e.KeyCode.ToString();
                        //CriteriaEx criteria = Dintel.Library.Certificacion.GetCriteria(Dintel.Library.Certificacion.OpenSession());

                        //criteria.AddStartsWith(col.DataPropertyName, car);

                        //// Buscamos las palabras que empiecen por el caracter
                        //SortedBindingList<CertificacionInfo> list =
                        //    CertificacionList.GetSortedList(criteria, col.DataPropertyName, ListSortDirection.Ascending);

                        //int foundIndex;

                        //// Nos situamos en la primera aparicion de esa lista en la 
                        //// que se muestra. Esto se hace pq se ha consultado la bd y no la lista actual
                        //// lo que puede dar lugar a inconsistencias si otro usuario a cambiado la bd
                        //foreach (CertificacionInfo alm in list)
                        //{
                        //    foundIndex = Datos_Certificaciones.IndexOf(alm);
                        //    if (foundIndex != -1)
                        //    {
                        //        Datos_Certificaciones.Position = foundIndex;
                        //        break;
                        //    }
                        //}
                    } break;
            }
        }
        
        private void Tabla_Extras_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        SubmitAction();
                        return;
                    }

                case Keys.Down:
                case Keys.Up:
                    {
                        return;
                    }

                default:
                    {
                        //DataGridViewColumn col;

                        //if (Tabla_Extras.CurrentCell == null)
                        //{
                        //    if (Tabla_Extras.SortedColumn != null)
                        //        col = Tabla_Extras.SortedColumn;
                        //    else
                        //        col = Tabla_Extras.Columns[0];
                        //}
                        //else
                        //    col = Tabla_Extras.Columns[Tabla_Extras.CurrentCell.ColumnIndex];

                        //if (col.ValueType.Name == "Int32") return;
                        //if (col.ValueType.Name == "Int64") return;
                        //if (col.ValueType.Name == "Single") return;
                        //if (col.ValueType.Name == "Double") return;

                        //string car = e.KeyCode.ToString();
                        //CriteriaEx criteria = Dintel.Library.Certificacion.GetCriteria(Dintel.Library.Certificacion.OpenSession());

                        //criteria.AddStartsWith(col.DataPropertyName, car);

                        //// Buscamos las palabras que empiecen por el caracter
                        //SortedBindingList<CertificacionInfo> list =
                        //    CertificacionList.GetSortedList(criteria, col.DataPropertyName, ListSortDirection.Ascending);

                        //int foundIndex;

                        //// Nos situamos en la primera aparicion de esa lista en la 
                        //// que se muestra. Esto se hace pq se ha consultado la bd y no la lista actual
                        //// lo que puede dar lugar a inconsistencias si otro usuario a cambiado la bd
                        //foreach (CertificacionInfo alm in list)
                        //{
                        //    foundIndex = Datos_Certificaciones.IndexOf(alm);
                        //    if (foundIndex != -1)
                        //    {
                        //        Datos_Certificaciones.Position = foundIndex;
                        //        break;
                        //    }
                        //}
                    } break;
            }
        }

        private void ClaseHorarioSelectForm_Load(object sender, EventArgs e)
        {
            this.MaximizeForm();
            Fichas_TP.SetBounds(Fichas_TP.Left, Fichas_TP.Top, this.Width - 30, this.Height - 80);
        }

        #endregion

    }
}

