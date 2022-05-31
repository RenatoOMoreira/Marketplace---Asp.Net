﻿using Marketplace.Mvc.Models;
using Marketplace.Repositorios.SqlServer.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Marketplace.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        ClienteRepositorio repositorio = new ClienteRepositorio();

        // GET: Clientes
        public ActionResult Index()
        {

            return View(Mapear(repositorio.Selecionar()));
        }

        private List<ClienteViewModel> Mapear(List<Cliente> clientes)
        {
            var viewModel = new List<ClienteViewModel>();

            foreach (var cliente in clientes) 
            {
                viewModel.Add(Mapear(cliente));
            }   

            return viewModel;
        }

        private ClienteViewModel Mapear(Cliente cliente)
        {
            var viewModel = new ClienteViewModel();
            viewModel.Telefone = cliente.Telefone;
            viewModel.Nome = cliente.Nome;
            viewModel.Documento = Convert.ToUInt64(new Regex("[^\\d]").Replace(cliente.Documento,"")).ToString(@"000\.000\.000-00");
            viewModel.Id = cliente.Id;            
            viewModel.Email = cliente.Email;

            return viewModel;
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapear(repositorio.Selecionar(id)));
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                repositorio.Inserir(Mapear(viewModel));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Cliente Mapear(ClienteViewModel viewModel)
        {
            var cliente = new Cliente();

            cliente.Telefone = viewModel.Telefone;
            cliente.Email = viewModel.Email;
            cliente.Documento = viewModel.Documento.Replace(".","").Replace("-",String.Empty);
            cliente.Nome = viewModel.Nome;
            cliente.Id = viewModel.Id;

            return cliente;
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapear(repositorio.Selecionar(id)));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel viewModel)
        {
            try
            {
                if (id != viewModel.Id) 
                {
                    ModelState.AddModelError("","Operação não realizada, o Id especificado não confere com a requisição enviada ao servidor!");
                }
                if (!ModelState.IsValid) 
                {
                    return View(viewModel);
                }

                //collection ["Documento"];
                repositorio.Atualizar(Mapear(viewModel));
                              
                return RedirectToAction("Index");
            }
            catch
            {
                //Logar o erro
                return View("Error");
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapear(repositorio.Selecionar(id))); 
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                repositorio.Excluir(id);

                return RedirectToAction("Index");
            }
            catch
            {
                //logar;
                return View("Error");
            }
        }
    }
}
