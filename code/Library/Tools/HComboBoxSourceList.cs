using System;
using System.Collections.Generic;
using System.Text;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    public class HComboBoxSourceList : ComboBoxSourceList
    {
        public HComboBoxSourceList() { }

        public HComboBoxSourceList(SubmoduloList lista)
        {
            AddEmptyItem();

            foreach (SubmoduloInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Codigo + " " + item.Texto;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidModulo;

                this.Add(combo);
            }
        }

        public HComboBoxSourceList(TemaList lista)
        {
            AddEmptyItem();

            foreach (TemaInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Codigo + " " + item.Nombre;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidSubmodulo;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(Csla.SortedBindingList<SubmoduloInfo> lista)
        {
            AddEmptyItem();

            foreach (SubmoduloInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Codigo;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidModulo;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(Submodulos lista)
        {
            AddEmptyItem();

            foreach (Submodulo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Codigo;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidModulo;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(ModuloList lista) : this (lista, true) {}

        public HComboBoxSourceList(ModuloList lista, bool empty_item)
        {
            if (empty_item) this.AddEmptyItem();

            foreach (ModuloInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.NumeroModulo + " " + item.Texto;
                combo.Oid = item.Oid;

                this.Add(combo);
            }
        }

        public HComboBoxSourceList(Csla.SortedBindingList<ModuloInfo> lista)
        {
            this.AddEmptyItem();
            foreach (ModuloInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Texto;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(AlumnoList lista)
        {
            AddEmptyItem();

            foreach (AlumnoInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Apellidos + ", " + item.Nombre;
                combo.Oid = item.Oid;
                combo.OidAjeno = 0;// item.OidPromocion;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(PromocionList lista)
        {
            AddEmptyItem();

            foreach (PromocionInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidPlan;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(Csla.SortedBindingList<PromocionInfo> lista)
        {
            AddEmptyItem();

            foreach (PromocionInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidPlan;

                this.Add(combo);
            }

        }

        //combo para semanas
        public HComboBoxSourceList(HorarioList lista)
        {

            foreach (HorarioInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = "Desde " + item.FechaInicial.ToShortDateString() + " a " + item.FechaFinal.ToShortDateString();
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidPromocion;

                this.Add(combo);
            }

        }

        //combo para fechas asociadas a una sesión
        public HComboBoxSourceList(SesionList lista)
        {
            foreach (SesionInfo item in lista)
            {
                if (!EstaFecha(item, this))
                {
                    ComboBoxSource combo = new ComboBoxSource();

                    combo.Texto = item.Fecha.ToShortDateString();
                    combo.Oid = item.Oid;
                    combo.OidAjeno = item.OidHorario;

                    this.Add(combo);
                }
            }
        }

        public HComboBoxSourceList(SesionList lista, SesionInfo sesion)
        {
            string fecha = sesion.Fecha.ToShortDateString();

            AddEmptyItem();

            foreach (SesionInfo item in lista)
            {
                if (!EstaHora(item, this) && (item.Fecha.ToShortDateString() == fecha) && item.OidHorario == sesion.OidHorario)
                {
                    ComboBoxSource combo = new ComboBoxSource();

                    combo.Texto = item.Hora.ToShortTimeString();
                    combo.Oid = item.Oid;

                    this.Add(combo);
                }
            }
        }

        private bool EstaFecha(SesionInfo item, HComboBoxSourceList lista)
        {
            foreach (ComboBoxSource combo in lista)
            {
                if (combo.Texto == item.Fecha.ToShortDateString() && combo.OidAjeno == item.OidHorario)
                    return true;
            }
            return false;
        }

        private bool EstaHora(SesionInfo item, HComboBoxSourceList lista)
        {
            foreach (ComboBoxSource combo in lista)
            {
                if (combo.Texto == item.Hora.ToShortTimeString())
                    return true;
            }
            return false;
        }

        public HComboBoxSourceList(CursoList lista)
        {
            AddEmptyItem();

            foreach (CursoInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(PlanEstudiosList lista)
        {
            AddEmptyItem();

            foreach (PlanEstudiosInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(PlanExtraList lista)
        {
            AddEmptyItem();

            foreach (PlanExtraInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(RevisionMaterialList lista)
        {
            AddEmptyItem();

            foreach (RevisionMaterialInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Version;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidMaterial;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(MaterialDocenteList lista)
        {

            foreach (MaterialDocenteInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(InstructorList lista)
        {
            AddEmptyItem();

            foreach (InstructorInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Apellidos + ", " + item.NombrePropio;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }
        
        public HComboBoxSourceList(Csla.SortedBindingList<InstructorInfo> lista)
        {
            AddEmptyItem();

            foreach (InstructorInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Apellidos + ", " + item.NombrePropio;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(Submodulo_Instructor_PromocionList lista, InstructorList instructores)
        {
            AddEmptyItem();

            foreach (Submodulo_Instructor_PromocionInfo item in lista)
            {
                if (item.OidInstructor != 0)
                {
                    ComboBoxSource combo = new ComboBoxSource();
                    InstructorInfo instructor = instructores.GetItem(item.OidInstructor);
                    if (instructor != null)
                    {
                        combo.Texto = instructor.Alias;
                        combo.Oid = item.OidInstructor;
                        combo.OidAjeno = item.OidSubmodulo;

                        this.Add(combo);
                    }
                }
            }

        }

        public HComboBoxSourceList(ExamenList lista)
        {
            AddEmptyItem();

            foreach (ExamenInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Titulo;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(ClasePracticaList lista)
        {
            AddEmptyItem();

            foreach (ClasePracticaInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Alias;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }
        
    }
}
