using Dominio.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IEmpresaRepositorio
    {
        void Salvar(EmpresaTipo empresa);
        void Editar(EmpresaTipo empresa);
        void Excluir(EmpresaTipo empresa);
        EmpresaTipo ObterEmpresa(int id);
        IEnumerable ObterTodasEmpresas();
        List<EmpresaTipo> PesquisarEmpresa(string pesquisar);
    }
}
