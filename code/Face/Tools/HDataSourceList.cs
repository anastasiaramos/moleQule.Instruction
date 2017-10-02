using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public class HDataSourceList : DataSourceList
    {
        
		public HDataSourceList(ComboBoxSourceList cb_list): base(cb_list) {}

        /// <summary>
        /// Añade una nueva lista de valores de un combo
        /// </summary>
        /// <param name="oid"></param>
        public void AddCombosList(long oid, HorarioForm entity, long tipo, int index, long oid_submodulo)
        {
            BindingSource source = new BindingSource();
            source.DataSource = entity.RellenaComboInstructores(oid,tipo,index, oid_submodulo);
            _childs_by_oid.Add(source);
        }

        /// <summary>
        /// Actualiza la lista de valores de un combo
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oid"></param>
        public void UpdateCombosList(int index, long oid, HorarioForm entity, long tipo, long oid_submodulo)
        {
            int indice = index;
            while (index > 13)
                index -= 14;
            _childs_by_oid[index].DataSource = entity.RellenaComboInstructores(oid, tipo, indice, oid_submodulo);
        }

    }
}