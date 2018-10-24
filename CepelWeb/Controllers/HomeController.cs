using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using Data.Nhibernate;
using Dominio.Repositorios;
using Data.Repositorios;
using Dominio.Modelo;

namespace CepelWeb.Controllers
{
    public class HomeController : Controller
    {

        EmpresaRepositorio repository = new EmpresaRepositorio();

        // GET: Home
        public ActionResult Index(string Pesquisa = "")
        {

            if (Pesquisa == "")
            {
                
                {
                   var empresa =  repository.ObterTodasEmpresas();
                    return View(empresa);
                }
            }

            if (Request.IsAjaxRequest())
            {
                var empresa = repository.PesquisarEmpresa(Pesquisa);
                return PartialView("_Empresas", empresa);
            }



            return View();

        }

     

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {

            var empresa = repository.ObterEmpresa(id);
            return View(empresa);
            
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(EmpresaTipo empresa)
        {

            try
            {
                repository.Salvar(empresa);                       
                
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                var erro = e;
                return View();
            }

           
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var empresa = repository.ObterEmpresa(id);
            return View(empresa);
            
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmpresaTipo empresa)
        {
            try
            {


                var empresaupdate = repository.ObterEmpresa(id);
                    empresaupdate.cnpj = empresa.cnpj;
                    empresaupdate.descricao = empresa.descricao;
                    empresaupdate.nome = empresa.nome;
                    empresaupdate.sigla = empresa.sigla;
                    empresaupdate.tipoEmpresa = empresa.tipoEmpresa;

                repository.Editar(empresaupdate);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {

            var empresa = repository.ObterEmpresa(id);
                return View(empresa);
            
        }
        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmpresaTipo empresa)
        {
            try
            {
               
                    
                        var empresadelete = repository.ObterEmpresa(id);
                repository.Excluir(empresadelete);
                        
                    
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
