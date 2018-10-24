using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelo;
using System.Collections;
using NHibernate;
using Data.Nhibernate;

namespace Data.Repositorios
{
   
        public class EmpresaRepositorio : IEmpresaRepositorio, IDisposable
    {

        protected ISession _session = null;
        protected ITransaction _transaction = null;

        public EmpresaRepositorio(ISession session)
            {
                _session = session;
            }

        public EmpresaRepositorio()
        {
          _session = NHibernateHelper.OpenSession();
    }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            
            _transaction.Commit();
            CloseTransaction();
        }

        public void RollbackTransaction()
        {
            
            _transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
           
        }

        public void Excluir(EmpresaTipo empresa)
        {
          
                _session.Delete(empresa);
           
        }

        public EmpresaTipo ObterEmpresa(int id)
        {            
            return _session.Get<EmpresaTipo>(id);
        }

        public IEnumerable ObterTodasEmpresas()
        {
            return _session.Query<EmpresaTipo>().ToList();
        }

        public void Salvar(EmpresaTipo empresa)
        {

                _session.SaveOrUpdate(empresa);
            
            
        }

        public void Editar(EmpresaTipo empresa)
        {

            _session.Save(empresa);


        }


        public List<EmpresaTipo> PesquisarEmpresa(string busca)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {

                busca = "%" + busca + "%";


                return session.QueryOver<EmpresaTipo>()
                               .WhereRestrictionOn(x => x.nome).IsLike(busca)
                               .List<EmpresaTipo>().ToList();
            }
        }

          public void Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
                CommitTransaction();
            }
            if (_session != null)
            {
                _session.Flush(); // commit session transactions
                CloseSession();
            }
        }
    }
}
