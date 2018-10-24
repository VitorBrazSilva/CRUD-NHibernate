using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
 
        public class EmpresaTipo : Empresa
        {
            public virtual TipoEmpresa tipoEmpresa { get; set; }

            public override string descricao { get; set; }




            public override string GetDescricao()
            {

                return tipoEmpresa + ": " + descricao;


            }
        }

        public enum TipoEmpresa
        {
            Holding,
            Geração,
            Distribuição,
            Transmissão
        }
    
}
