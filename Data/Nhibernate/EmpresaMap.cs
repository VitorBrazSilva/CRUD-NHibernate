using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Data.Nhibernate
{
    class EmpresaMap : ClassMap<EmpresaTipo>
    {

        public EmpresaMap()
        {
            Id(x => x.idEmpresa);
            Map(x => x.nome);
            Map(x => x.descricao);
            Map(x => x.sigla);
            Map(x => x.cnpj);
            Map(x => x.tipoEmpresa);
            Table("Empresa");
        }
    }
}
