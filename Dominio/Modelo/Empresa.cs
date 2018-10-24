using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    
        public abstract class Empresa
        {

            public virtual int idEmpresa { get; set; }
            public virtual string nome { get; set; }
            public virtual string sigla { get; set; }
            public virtual string cnpj { get; set; }
            public virtual string descricao { get; set; }

            public abstract string GetDescricao();
        }
    
}
