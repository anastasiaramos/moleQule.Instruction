using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

using CslaEx;
using moleQule.Library;
using moleQule.Library.Security;
using moleQule.Library.Instruction.Resources;

namespace moleQule.Library.Instruction
{

    [Serializable()]
    public class AutorizationRulesControler
    {
        #region Business Methods

        public static bool CanGetObject(string secure_item)
        {
            List<ItemLicences> permisos_comprobados = new List<ItemLicences>();

            return CanGetObject(secure_item, permisos_comprobados);
        }

        public static bool CanAddObject(string secure_item)
        {
            List<ItemLicences> permisos_comprobados = new List<ItemLicences>();

            return CanAddObject(secure_item, permisos_comprobados);
        }

        public static bool CanEditObject(string secure_item)
        {
            List<ItemLicences> permisos_comprobados = new List<ItemLicences>();

            return CanEditObject(secure_item, permisos_comprobados);
        }

        public static bool CanDeleteObject(string secure_item)
        {
            List<ItemLicences> permisos_comprobados = new List<ItemLicences>();

            return CanDeleteObject(secure_item, permisos_comprobados);
        }

        public static bool CanGetObject(string secure_item, List<ItemLicences> permisos_comprobados)
        {
            bool creado = false;

            for (int i = 0; i < permisos_comprobados.Count; i++)
            {
                if (permisos_comprobados[i].Item == Convert.ToInt64(secure_item))
                {
                    if (permisos_comprobados[i].Read)
                        return true;
                    else
                        permisos_comprobados[i].Read = true;

                    creado = true;
                    break;
                }
            }

            if (!creado)
            {
                ItemLicences nuevo = new ItemLicences();
                nuevo.Item = Convert.ToInt64(secure_item);
                nuevo.Read = true;
                permisos_comprobados.Add(nuevo);
            }

            switch (secure_item)
            {
                //Resources.ElementosSeguros.ALUMNO:              
                case "401":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.AUXILIARES, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO:
                case "402":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MATERIAL_DOCENTE, permisos_comprobados)
                        && Invoice.AutorizationRulesControler.CanGetObject(Invoice.Resources.ElementosSeguros.CLIENTE, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO_FORMACION:
                case "403":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.EXAMEN:
                case "404":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.HORARIO:
                case "405":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PARTE_ASISTENCIA, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.INSTRUCTOR:
                case "406":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.AUXILIARES, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.CURSO_FORMACION, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanGetObject(Store.Resources.ElementosSeguros.FACTURA_RECIBIDA, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanGetObject(Store.Resources.ElementosSeguros.PROVEEDOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MATERIAL_DOCENTE:
                case "407":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MODULO:
                case "408":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MATERIAL_DOCENTE, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PARTE_ASISTENCIA:
                case "409":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.HORARIO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_ESTUDIOS:
                case "410":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_EXTRA:
                case "411":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PROMOCION:
                case "412":
                    return (ApplicationContextEx.User.CanReadObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.HORARIO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));

            }

            return false;

        }

        public static bool CanAddObject(string secure_item, List<ItemLicences> permisos_comprobados)
        {
            bool creado = false;

            for (int i = 0; i < permisos_comprobados.Count; i++)
            {
                if (permisos_comprobados[i].Item == Convert.ToInt64(secure_item))
                {
                    if (permisos_comprobados[i].Create)
                        return true;
                    else
                        permisos_comprobados[i].Create = true;

                    creado = true;
                    break;
                }
            }

            if (!creado)
            {
                ItemLicences nuevo = new ItemLicences();
                nuevo.Item = Convert.ToInt64(secure_item);
                nuevo.Create = true;
                permisos_comprobados.Add(nuevo);
            }

            switch (secure_item)
            {
                //Resources.ElementosSeguros.ALUMNO:              
                case "401":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.AUXILIARES, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO:
                case "402":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.MATERIAL_DOCENTE, permisos_comprobados)
                        && Invoice.AutorizationRulesControler.CanGetObject(Invoice.Resources.ElementosSeguros.CLIENTE, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO_FORMACION:
                case "403":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.EXAMEN:
                case "404":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanAddObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.HORARIO:
                case "405":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && Store.AutorizationRulesControler.CanGetObject(Store.Resources.ElementosSeguros.FACTURA_RECIBIDA, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.PARTE_ASISTENCIA, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.INSTRUCTOR:
                case "406":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.AUXILIARES, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.CURSO_FORMACION, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanAddObject(Store.Resources.ElementosSeguros.FACTURA_RECIBIDA, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanAddObject(Store.Resources.ElementosSeguros.PROVEEDOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MATERIAL_DOCENTE:
                case "407":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.CURSO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MODULO:
                case "408":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MATERIAL_DOCENTE, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PARTE_ASISTENCIA:
                case "409":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.HORARIO, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_ESTUDIOS:
                case "410":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_EXTRA:
                case "411":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PROMOCION:
                case "412":
                    return (ApplicationContextEx.User.CanCreateObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanAddObject(Resources.ElementosSeguros.HORARIO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));

            }

            return false;

        }

        public static bool CanEditObject(string secure_item, List<ItemLicences> permisos_comprobados)
        {
            bool creado = false;

            for (int i = 0; i < permisos_comprobados.Count; i++)
            {
                if (permisos_comprobados[i].Item == Convert.ToInt64(secure_item))
                {
                    if (permisos_comprobados[i].Modify)
                        return true;
                    else
                        permisos_comprobados[i].Modify = true;

                    creado = true;
                    break;
                }
            }

            if (!creado)
            {
                ItemLicences nuevo = new ItemLicences();
                nuevo.Item = Convert.ToInt64(secure_item);
                nuevo.Modify = true;
                permisos_comprobados.Add(nuevo);
            }

            switch (secure_item)
            {
                //Resources.ElementosSeguros.ALUMNO:              
                case "401":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.AUXILIARES, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO:
                case "402":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.MATERIAL_DOCENTE, permisos_comprobados)
                        && Invoice.AutorizationRulesControler.CanGetObject(Invoice.Resources.ElementosSeguros.CLIENTE, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO_FORMACION:
                case "403":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.EXAMEN:
                case "404":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanEditObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.HORARIO:
                case "405":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && Store.AutorizationRulesControler.CanGetObject(Store.Resources.ElementosSeguros.FACTURA_RECIBIDA, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.PARTE_ASISTENCIA, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.INSTRUCTOR:
                case "406":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.AUXILIARES, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.CURSO_FORMACION, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanEditObject(Store.Resources.ElementosSeguros.FACTURA_RECIBIDA, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanEditObject(Store.Resources.ElementosSeguros.PROVEEDOR, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MATERIAL_DOCENTE:
                case "407":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.CURSO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MODULO:
                case "408":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MATERIAL_DOCENTE, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PARTE_ASISTENCIA:
                case "409":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.HORARIO, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_ESTUDIOS:
                case "410":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PROMOCION, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_EXTRA:
                case "411":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.MODULO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PROMOCION:
                case "412":
                    return (ApplicationContextEx.User.CanModifyObject(Convert.ToInt64(secure_item))
                        && CanGetObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanEditObject(Resources.ElementosSeguros.HORARIO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));

            }

            return false;
        }

        public static bool CanDeleteObject(string secure_item, List<ItemLicences> permisos_comprobados)
        {
            bool creado = false;

            for (int i = 0; i < permisos_comprobados.Count; i++)
            {
                if (permisos_comprobados[i].Item == Convert.ToInt64(secure_item))
                {
                    if (permisos_comprobados[i].Remove)
                        return true;
                    else
                        permisos_comprobados[i].Remove = true;

                    creado = true;
                    break;
                }
            }

            if (!creado)
            {
                ItemLicences nuevo = new ItemLicences();
                nuevo.Item = Convert.ToInt64(secure_item);
                nuevo.Remove = true;
                permisos_comprobados.Add(nuevo);
            }

            switch (secure_item)
            {
                //Resources.ElementosSeguros.ALUMNO:              
                case "401":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO:
                case "402":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanDeleteObject(Resources.ElementosSeguros.INSTRUCTOR, permisos_comprobados)
                        && CanDeleteObject(Resources.ElementosSeguros.MATERIAL_DOCENTE, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.CURSO_FORMACION:
                case "403":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.EXAMEN:
                case "404":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.HORARIO:
                case "405":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.PARTE_ASISTENCIA, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.INSTRUCTOR:
                case "406":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.CURSO_FORMACION, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanDeleteObject(Store.Resources.ElementosSeguros.FACTURA_RECIBIDA, permisos_comprobados)
                        && Store.AutorizationRulesControler.CanDeleteObject(Store.Resources.ElementosSeguros.PROVEEDOR, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MATERIAL_DOCENTE:
                case "407":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanDeleteObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.MODULO:
                case "408":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.PLAN_ESTUDIOS, permisos_comprobados)
                        && CanDeleteObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PARTE_ASISTENCIA:
                case "409":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_ESTUDIOS:
                case "410":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PLAN_EXTRA:
                case "411":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));
                //Resources.ElementosSeguros.PROMOCION:
                case "412":
                    return (ApplicationContextEx.User.CanRemoveObject(Convert.ToInt64(secure_item))
                        && CanDeleteObject(Resources.ElementosSeguros.ALUMNO, permisos_comprobados)
                        && CanDeleteObject(Resources.ElementosSeguros.EXAMEN, permisos_comprobados)
                        && CanDeleteObject(Resources.ElementosSeguros.HORARIO, permisos_comprobados)
                        && Common.AutorizationRulesControler.CanGetObject(Common.Resources.ElementosSeguros.EMPRESA, permisos_comprobados)
                        && moleQule.Library.AutorizationRulesControler.CanGetObject(moleQule.Library.Resources.SecureItems.VARIABLE, permisos_comprobados));

            }

            return false;

        }

        #endregion
        
    }
}