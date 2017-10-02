using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using Csla;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Reports;
using moleQule.Library.Instruction;

using moleQule.Library.Instruction.Reports.Horario;
using moleQule.Library.Instruction.Reports.Examen;
using moleQule.Library.Instruction.Reports.PlanEstudios;
using moleQule.Library.Instruction.Reports.Promocion;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class CronogramaReportMng : BaseReportMng
    {

        #region Business Methods Cronograma

        public CronogramaRpt GetCronogramaReport(CronogramaInfo item, CompanyInfo empresa, ModuloList modulos,
            ClaseTeoricaList teoricas, ClasePracticaList practicas)
        {
            if (item == null) return null;

            CronogramaRpt doc = new CronogramaRpt();

            List<CronogramaPrint> pList = new List<CronogramaPrint>();
            List<SesionCronogramaInfo> sesiones = new List<SesionCronogramaInfo>();

            foreach (SesionCronogramaInfo ses in item.Sesiones)
                sesiones.Add(ses.GetPrintObject(modulos, teoricas, practicas));

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (sesiones.Count <= 0)
                return null;


            pList.Add(item.GetPrintObject(empresa));
            doc.Subreports["SesionCronogramaListSubRpt.rpt"].SetDataSource(sesiones);

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        public CronogramaRpt GetCronogramaReport(CronogramaInfo item, CompanyInfo empresa, ModuloList modulos,
            ClaseTeoricaList teoricas, ClasePracticaList practicas, SortedBindingList<SesionCronogramaInfo> lista)
        {
            if (item == null) return null;

            CronogramaRpt doc = new CronogramaRpt();

            List<CronogramaPrint> pList = new List<CronogramaPrint>();
            //List<SesionCronogramaInfo> sesiones = new List<SesionCronogramaInfo>();

            //foreach (SesionCronogramaInfo ses in item.Sesiones)
            //    sesiones.Add(ses.GetPrintObject(modulos, teoricas, practicas));

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;


            pList.Add(item.GetPrintObject(empresa));
            doc.Subreports["SesionCronogramaListSubRpt.rpt"].SetDataSource(lista);

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        public ComparativaCronogramaRpt  GetComparativaClases(PromocionInfo promocion, DateTime fecha, List<RegistroResumenPlanDocente> lista, long grupo = 0)
        {
            if (lista.Count == 0) return null;

            ComparativaCronogramaRpt doc = new ComparativaCronogramaRpt();

            doc.SetDataSource(lista);
            doc.SetParameterValue("Promocion", promocion.Nombre);
            doc.SetParameterValue("Fecha", fecha.ToString("dd/MM/yyyy"));
            if (grupo > 0)
                doc.SetParameterValue("Grupo", grupo.ToString());
            else
                doc.SetParameterValue("Grupo", "");

            return doc;
        }

        #endregion

        #region Business Methods SesionCronograma

        public SesionCronogramaListSubRpt GetSesionCronogramaListReport(CronogramaInfo cronograma,
                                    SesionCronogramaList sesiones, ModuloList modulos,
            ClaseTeoricaList teoricas, ClasePracticaList practicas)
        {
            if (cronograma == null) return null;
            if (sesiones.Count == 0) return null;

            SesionCronogramaListSubRpt doc = new SesionCronogramaListSubRpt();

            List<SesionCronogramaPrint> pList = new List<SesionCronogramaPrint>();

            foreach (SesionCronogramaInfo sesion in sesiones)
                pList.Add(sesion.GetPrintObject(modulos, teoricas, practicas));

            doc.SetDataSource(pList);
            doc.SetParameterValue("Empresa", Schema.Name);
            if (Schema.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        #endregion

        #region Business Methods Sesion Teoria

        public HojaFirmasTeoriaRpt GetDetailTeoricasReport(SesionInfo item, AlumnoList lista, string duracion,
            ClaseTeoricaList teoricas, ClasePracticaList practicas, ClaseExtraList extras, string clases, long oidPromocion, bool print_alumno)
        {
            if (item == null) return null;

            HojaFirmasTeoriaRpt doc = new HojaFirmasTeoriaRpt();
            List<SesionPrint> pList = new List<SesionPrint>();

            long grupo = 0;
            List<AlumnoInfo> alumnos = new List<AlumnoInfo>();

            foreach (AlumnoInfo alumno in lista)
            {
                if (alumno.Grupo != grupo && grupo < 3)
                    grupo += alumno.Grupo;
                alumnos.Add(alumno.GetPrintObject());
            }

            pList.Add(item.GetPrintObject(teoricas, practicas, extras, clases, grupo, print_alumno));

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (alumnos.Count <= 0)
                return null;

            doc.SetDataSource(pList);
            ((TextObject)(doc.Section1.ReportObjects["Duracion_TB"])).Text = duracion;

            PromocionInfo promo = PromocionInfo.Get(oidPromocion, false);
            if (promo != null)
                ((TextObject)(doc.Section1.ReportObjects["Promocion_TB"])).Text = promo.Nombre;
            doc.Subreports["AlumnosListSubRpt.rpt"].SetDataSource(alumnos);

            return doc;
        }

        #endregion

        #region Business Methods Sesion Practica

        public HojaFirmasPracticaRpt GetDetailPracticasReport(SesionInfo item, AlumnoList lista, string duracion,
            ClaseTeoricaList teoricas, ClasePracticaList practicas, ClaseExtraList extras, string clases, long oidPromocion, bool print_alumno)
        {
            if (item == null) return null;

            HojaFirmasPracticaRpt doc = new HojaFirmasPracticaRpt();
            List<SesionPrint> pList = new List<SesionPrint>();

            long grupo = 0;
            List<AlumnoInfo> alumnos = new List<AlumnoInfo>();

            foreach (AlumnoInfo alumno in lista)
            {
                if (alumno.Grupo != grupo && grupo < 3)
                    grupo += alumno.Grupo;
                alumnos.Add(alumno.GetPrintObject());
            }

            pList.Add(item.GetPrintObject(teoricas, practicas, extras, clases, grupo, print_alumno));

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (alumnos.Count <= 0)
                return null;

            PromocionInfo promo = PromocionInfo.Get(oidPromocion, false);


            doc.SetDataSource(pList);
            ((TextObject)(doc.Section1.ReportObjects["Duracion_TB"])).Text = duracion;
            if (promo != null)
                ((TextObject)(doc.Section1.ReportObjects["Promocion_TB"])).Text = promo.Nombre;
            doc.Subreports["AlumnosListSubRpt.rpt"].SetDataSource(alumnos);

            return doc;
        }

        #endregion

        #region Business Methods Horario

        public HorarioRpt GetHorarioReport(HorarioInfo item,
                                            bool alumno,
            /*bool autorizado,*/
                                            ClaseTeoricaList teoricas,
                                            List<ClasePracticaList> practicas,
                                            ClaseExtraList extras,
                                            InstructorList instructores,
                                            ModuloList modulos,
                                            ListaSesiones sesiones,
                                            bool print_timestamp,
                                            DateTime timestamp)
        {
            if (item == null) return null;

            HorarioRpt doc = new HorarioRpt();

            if (instructores == null)
                instructores = InstructorList.GetList(false);
            if (modulos == null)
                modulos = ModuloList.GetList(false);

            List<HorarioPrint> pList = new List<HorarioPrint>();

            pList.Add(item.GetPrintObject(instructores, modulos));

            doc.SetDataSource(pList);

            FormatReport(doc, sesiones, alumno/*, autorizado*/, teoricas, practicas, extras/*, instructores*/);

            if (print_timestamp)
                doc.SetParameterValue("Timestamp", timestamp.ToString("dd/MM/yy HH:mm:ss"));
            else
                doc.SetParameterValue("Timestamp", string.Empty);
                

            return doc;
        }

        #endregion

        #region Business Methods ClasesPromocion

        public ClasesRpt GetDetailReport(ListaClases lista, CompanyInfo empresa)
        {
            if (lista == null) return null;

            ClasesRpt doc = new ClasesRpt();

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;


            doc.SetDataSource(lista);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        public ClasesRpt GetDetailReport(ClaseTeoricas list) { return GetDetailReport(ClaseTeoricaList.GetChildList(list)); }
        public ClasesRpt GetDetailReport(ClaseTeoricaList list)
        {
            if (list == null) return null;

            System.ComponentModel.BindingList<Clase> lista = ListaClases.GetList(list, null, null);

            ClasesRpt doc = new ClasesRpt();

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;


            doc.SetDataSource(lista);
            doc.SetParameterValue("Empresa", Schema.Name);
            if (Schema.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        public ClasesRpt GetDetailReport(ClasePracticas list) { return GetDetailReport(ClasePracticaList.GetChildList(list)); }
        public ClasesRpt GetDetailReport(ClasePracticaList list)
        {
            if (list == null) return null;

            System.ComponentModel.BindingList<Clase> lista = ListaClases.GetList(null, list, null);

            ClasesRpt doc = new ClasesRpt();

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;


            doc.SetDataSource(lista);
            doc.SetParameterValue("Empresa", Schema.Name);
            if (Schema.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        public ClasesRpt GetDetailReport(ClaseExtras list) { return GetDetailReport(ClaseExtraList.GetChildList(list)); }
        public ClasesRpt GetDetailReport(ClaseExtraList list)
        {
            if (list == null) return null;

            System.ComponentModel.BindingList<Clase> lista = ListaClases.GetList(null, null, list);

            ClasesRpt doc = new ClasesRpt();

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;


            doc.SetDataSource(lista);
            doc.SetParameterValue("Empresa", Schema.Name);
            if (Schema.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        public ResumenRpt GetDetailReport(List<RegistroResumenPlanDocente> lista, CompanyInfo empresa)
        {
            if (lista == null) return null;

            ResumenRpt doc = new ResumenRpt();

            //Si no existen conceptos, no tiene sentido un informe detallado. Además, falla en Crystal Reports
            if (lista.Count <= 0)
                return null;


            doc.SetDataSource(lista);
            doc.SetParameterValue("Empresa", empresa.Name);
            if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(doc.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);

            return doc;
        }

        public FestivosRpt GetCalendarioFestivos(SortedBindingList<FestivoInfo> list, DateTime desde, DateTime hasta)
        {
            if (list.Count == 0) return null;

            FestivosRpt doc = new FestivosRpt();

            doc.SetDataSource(list);
            doc.SetParameterValue("Desde", desde.ToShortDateString());
            doc.SetParameterValue("Hasta", hasta.ToShortDateString());

            return doc;
        }

        #endregion

        #region Factory Methods

        public CronogramaReportMng()
        {

        }

        public CronogramaReportMng(ISchemaInfo empresa)
            : base(empresa)
        { }

        #endregion

        #region Style

        private static void FormatReport(HorarioRpt rpt,
                                            ListaSesiones list,
                                            bool alumnos,
            /*bool autorizado,*/
                                            ClaseTeoricaList teoricas,
                                            List<ClasePracticaList> practicas,
                                            ClaseExtraList extras/*, 
                                            InstructorList instructores*/)
        {
            List<string> lista = new List<string>();

            lista.Add("Lunes8AM");
            lista.Add("Lunes");
            lista.Add("Lunes2");
            lista.Add("Lunes3");
            lista.Add("Lunes4");
            lista.Add("Lunes5");
            lista.Add("Lunes6");
            lista.Add("Lunes7");
            lista.Add("Lunes8");
            lista.Add("Lunes9");
            lista.Add("Lunes10");
            lista.Add("Lunes11");
            lista.Add("Lunes12");
            lista.Add("Lunes13");

            lista.Add("Martes8AM");
            lista.Add("Martes");
            lista.Add("Martes2");
            lista.Add("Martes3");
            lista.Add("Martes4");
            lista.Add("Martes5");
            lista.Add("Martes6");
            lista.Add("Martes7");
            lista.Add("Martes8");
            lista.Add("Martes9");
            lista.Add("Martes10");
            lista.Add("Martes11");
            lista.Add("Martes12");
            lista.Add("Martes13");

            lista.Add("Miercoles8AM");
            lista.Add("Miercoles");
            lista.Add("Miercoles2");
            lista.Add("Miercoles3");
            lista.Add("Miercoles4");
            lista.Add("Miercoles5");
            lista.Add("Miercoles6");
            lista.Add("Miercoles7");
            lista.Add("Miercoles8");
            lista.Add("Miercoles9");
            lista.Add("Miercoles10");
            lista.Add("Miercoles12");
            lista.Add("Miercoles11");
            lista.Add("Miercoles13");

            lista.Add("Jueves8AM");
            lista.Add("Jueves");
            lista.Add("Jueves2");
            lista.Add("Jueves3");
            lista.Add("Jueves4");
            lista.Add("Jueves5");
            lista.Add("Jueves6");
            lista.Add("Jueves7");
            lista.Add("Jueves8");
            lista.Add("Jueves9");
            lista.Add("Jueves10");
            lista.Add("Jueves11");
            lista.Add("Jueves12");
            lista.Add("Jueves13");

            lista.Add("Viernes8AM");
            lista.Add("Viernes");
            lista.Add("Viernes2");
            lista.Add("Viernes3");
            lista.Add("Viernes4");
            lista.Add("Viernes5");
            lista.Add("Viernes6");
            lista.Add("Viernes7");
            lista.Add("Viernes8");
            lista.Add("Viernes9");
            lista.Add("Viernes10");
            lista.Add("Viernes11");
            lista.Add("Viernes12");
            lista.Add("Viernes13");

            lista.Add("Sabado");
            lista.Add("Sabado2");
            lista.Add("Sabado3");
            lista.Add("Sabado4");
            lista.Add("Sabado5");

            InstructorList instructores = InstructorList.GetList(true);

            int ultimo = 0;
            int n_clases = 0;
            string aux = string.Empty;

            foreach (SesionAuxiliar info in list)
            {
                int indice = list.IndexOf(info);

                //si la sesión no tienen ninguna clase asignada, se elimina la etiqueta
                if (info.OidClaseTeorica <= 0
                    && info.OidClasePractica == 0
                    && info.OidClaseExtra == 0)
                {
                    rpt.SetParameterValue(lista[indice], "");
                    ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = true;
                }
                else
                {
                    //si la sesión tiene una clase asignada una clase teórica
                    if (info.OidClaseTeorica != 0)
                    {
                        ClaseTeoricaInfo teorica = teoricas.GetItem(info.OidClaseTeorica);
                        //si no es la primera clase del día
                        //se comprueba si pertenece a la misma clase que la hora anterior
                        if (indice % 14 != 0 && list[indice - 1].OidClaseTeorica > 0)
                        {
                            bool misma_clase = false;
                            if (teorica.OidModulo ==
                                teoricas.GetItem(list[indice - 1].OidClaseTeorica).OidModulo
                                && teorica.OidSubmodulo ==
                                teoricas.GetItem(list[indice - 1].OidClaseTeorica).OidSubmodulo
                                && info.OidProfesor == list[indice - 1].OidProfesor)
                            {
                                misma_clase = true;
                                rpt.SetParameterValue(lista[indice], "");
                                ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = true;
                                if (!alumnos)
                                {
                                    InstructorInfo item = instructores.GetItem(info.OidProfesor);
                                    string instructor = item.Alias;
                                    instructor += Environment.NewLine;
                                    int ind = aux.IndexOf(instructor);
                                    if (ind == -1)
                                        misma_clase = false;
                                }
                                else
                                    aux = Environment.NewLine + aux;
                                if (misma_clase)
                                {
                                    ((FieldObject)(rpt.Section3.ReportObjects[lista[ultimo]])).Height = ((FieldObject)(rpt.Section3.ReportObjects[lista[ultimo]])).Height + 720;
                                    rpt.SetParameterValue(lista[ultimo], aux);
                                    if (n_clases == 1)
                                        ((FieldObject)(rpt.Section3.ReportObjects[lista[ultimo]])).Top += 80;
                                    n_clases++;
                                }
                            }
                            if (!misma_clase)
                            {
                                ModuloInfo modulo = ModuloInfo.Get(teorica.OidModulo, false);
                                aux = Environment.NewLine + modulo.Alias + Environment.NewLine;
                                aux += teorica.Submodulo + Environment.NewLine;
                                if (!alumnos)
                                {
                                    InstructorInfo item = instructores.GetItem(info.OidProfesor);
                                    string instructor = item.Alias;
                                    instructor += Environment.NewLine;
                                    aux += instructor;
                                }
                                ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = false;
                                ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Top -= 80;
                                rpt.SetParameterValue(lista[indice], aux);
                                ultimo = indice;
                                n_clases = 1;
                            }
                        }
                        else
                        {
                            ModuloInfo modulo = ModuloInfo.Get(teorica.OidModulo, false);
                            aux = Environment.NewLine + modulo.Alias + Environment.NewLine;
                            aux += teorica.Submodulo + Environment.NewLine;
                            if (!alumnos)
                            {
                                InstructorInfo item = instructores.GetItem(info.OidProfesor);
                                string instructor = item.Alias;
                                instructor += Environment.NewLine;
                                aux += instructor;
                            }
                            ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = false;
                            ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Top -= 80;
                            rpt.SetParameterValue(lista[indice], aux);
                            ultimo = indice;
                            n_clases = 1;
                        }
                    }
                    else
                    {
                        if (info.OidClasePractica != 0)
                        {
                            ClasePracticaInfo practica = practicas[(int)info.Grupo].GetItem(info.OidClasePractica);
                            //if (indice % 14 != 0)
                            {
                                int ind_aux = 1;
                                bool esta = false;
                                bool anterior = false;

                                //if (indice % 14 != 0)
                                //{
                                    while (ind_aux < 5 && (indice - ind_aux) >= 0 && (indice - ind_aux) % 14 < indice % 14)
                                    {
                                        if (list[indice - ind_aux].OidClasePractica != 0
                                            && practica.OidModulo ==
                                            practicas[(int)list[indice - ind_aux].Grupo].GetItem(list[indice - ind_aux].OidClasePractica).OidModulo
                                            && info.OidProfesor == list[indice - ind_aux].OidProfesor
                                            && info.Grupo == list[indice - ind_aux].Grupo)//comprobación de grupo por si fuera la misma práctica para los dos grupos
                                        {
                                            esta = true;
                                            break;
                                        }
                                        if (list[indice - ind_aux].OidClasePractica != 0)
                                            anterior = true;
                                        ind_aux++;
                                    }

                                    ind_aux = 1;
                                    bool posterior = false;
                                    while (ind_aux < 5 && (indice + ind_aux) % 14 > indice % 14 && (indice + ind_aux) < 75)
                                    {
                                        if (list[indice + ind_aux].OidClasePractica != 0
                                            && list[indice + ind_aux].OidClasePractica != list[indice].OidClasePractica)
                                            posterior = true;
                                        ind_aux++;
                                    }
                                //}

                                if (!esta)
                                {
                                    aux = Environment.NewLine + practica.Modulo + Environment.NewLine;
                                    aux += practica.Alias + " G" + list[indice].Grupo.ToString() + Environment.NewLine;
                                    if (!alumnos)
                                    {
                                        InstructorInfo item = instructores.GetItem(info.OidProfesor);
                                        string instructor = item.Alias;
                                        instructor += Environment.NewLine;
                                        aux += instructor;
                                        aux += Environment.NewLine;
                                        aux += "5H";
                                    }
                                    rpt.SetParameterValue(lista[indice], aux);
                                    if (!anterior)
                                    {
                                        if (posterior)
                                            ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Height = 1560;
                                        else
                                            ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Height = 3200;
                                    }
                                    else
                                    {
                                        int top = 0;
                                        int i = 1;
                                        while (i < 5 && indice - i >= 0)
                                        {
                                            if (!((FieldObject)(rpt.Section3.ReportObjects[lista[indice - i]])).ObjectFormat.EnableSuppress)
                                            {
                                                top = ((FieldObject)(rpt.Section3.ReportObjects[lista[indice - i]])).Top + 1560 + 240;
                                                break;
                                            }
                                            i++;
                                        }
                                        ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Height = 1560;
                                        ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Top = top;


                                    }
                                    ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = false;

                                }
                                else
                                {
                                    rpt.SetParameterValue(lista[indice], "");
                                    ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = true;
                                }
                            }
                        }
                        else
                        {
                            ClaseExtraInfo extra = extras.GetItem(info.OidClaseExtra);
                            //si no es la primera clase del día
                            //se comprueba si pertenece a la misma clase que la hora anterior
                            if (indice % 14 != 0 && list[indice - 1].OidClaseExtra > 0)
                            {
                                bool misma_clase = false;
                                if (extra.OidModulo ==
                                    extras.GetItem(list[indice - 1].OidClaseExtra).OidModulo
                                    && extra.OidSubmodulo ==
                                    extras.GetItem(list[indice - 1].OidClaseExtra).OidSubmodulo
                                    && info.OidProfesor == list[indice - 1].OidProfesor)
                                {
                                    misma_clase = true;
                                    rpt.SetParameterValue(lista[indice], "");
                                    ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = true;
                                    if (!alumnos)
                                    {
                                        InstructorInfo item = instructores.GetItem(info.OidProfesor);
                                        string instructor = item.Alias;
                                        instructor += Environment.NewLine;
                                        int ind = aux.IndexOf(instructor);
                                        if (ind == -1)
                                            misma_clase = false;
                                    }
                                    else
                                        aux = Environment.NewLine + aux;

                                    if (misma_clase)
                                    {
                                        ((FieldObject)(rpt.Section3.ReportObjects[lista[ultimo]])).Height = ((FieldObject)(rpt.Section3.ReportObjects[lista[ultimo]])).Height + 720;
                                        rpt.SetParameterValue(lista[ultimo], aux);
                                        if (n_clases == 1)
                                            ((FieldObject)(rpt.Section3.ReportObjects[lista[ultimo]])).Top += 80;
                                        n_clases++;
                                    }
                                }
                                if (!misma_clase)
                                {
                                    ModuloInfo modulo = ModuloInfo.Get(extra.OidModulo, false);
                                    aux = Environment.NewLine + modulo.Alias + Environment.NewLine;
                                    aux += extra.Submodulo + Environment.NewLine;
                                    if (!alumnos)
                                    {
                                        InstructorInfo item = instructores.GetItem(info.OidProfesor);
                                        string instructor = item.Alias;
                                        instructor += Environment.NewLine;
                                        aux += instructor;
                                    }
                                    ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = false;
                                    ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Top -= 80;
                                    rpt.SetParameterValue(lista[indice], aux);
                                    ultimo = indice;
                                    n_clases = 1;
                                }
                            }
                            else
                            {
                                ModuloInfo modulo = ModuloInfo.Get(extra.OidModulo, false);
                                aux = Environment.NewLine + modulo.Alias + Environment.NewLine;
                                aux += extra.Submodulo + Environment.NewLine;
                                if (!alumnos)
                                {
                                    InstructorInfo item = instructores.GetItem(info.OidProfesor);
                                    string instructor = item.Alias;
                                    instructor += Environment.NewLine;
                                    aux += instructor;
                                }
                                ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).ObjectFormat.EnableSuppress = false;
                                ((FieldObject)(rpt.Section3.ReportObjects[lista[indice]])).Top -= 80;
                                rpt.SetParameterValue(lista[indice], aux);
                                ultimo = indice;
                                n_clases = 1;
                            }
                        }
                    }
                }
            }
        }

        #endregion

    }
}