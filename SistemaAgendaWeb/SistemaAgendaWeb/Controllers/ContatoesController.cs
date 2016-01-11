using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaAgendaDominio;
using SistemaAgendaORM;
using System.IO;
using PagedList;




namespace SistemaAgendaWeb.Controllers
{
    public class ContatoesController : Controller
    {
        private Contexto db = new Contexto();
      
        // GET: Contatoes
        public ActionResult Index(int? pagina)
        {
            int tamanhoPagina = 8; // Quantidade de Anuncio por pagina      
            int numeroPagina = pagina ?? 1; // Se a Pagina for NULL inicia com valor 1.
            var contatos = db.Contatos.OrderBy(c => c.Nome).ToList();
            return View(contatos.ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Contatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: Contatoes/Create
        public ActionResult Create()
        {
            
            
            return View();
        }

        // POST: Contatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContatoId,Nome,Sobrenome,TelefoneFixo,Celular,Email,Imagem,ImagemTipo,Masculino,Feminino")] Contato contato, HttpPostedFileBase upload)
        {
           
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new Contato { ImagemTipo = upload.ContentType };

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }

                    contato.Imagem = arqImagem.Imagem;
                    contato.ImagemTipo = arqImagem.ImagemTipo;

                }

                db.Contatos.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            
            return View(contato);
        }

        // GET: Contatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            
            return View(contato);
        }

        // POST: Contatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContatoId,Nome,Sobrenome,TelefoneFixo,Celular,Email,Imagem,ImagemTipo,Masculino,Feminino")] Contato contato, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength >= 0)
                {
                    var arqImagem = new Contato { ImagemTipo = upload.ContentType };

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }

                    contato.Imagem = arqImagem.Imagem;
                    contato.ImagemTipo = arqImagem.ImagemTipo;

                }
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(contato);
        }

        // GET: Contatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contato contato = db.Contatos.Find(id);
            db.Contatos.Remove(contato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Filtro de Busca de Contato
        /// </summary>
        /// <param name="Pesquisa"></param>
        /// <param name="pagina"></param>
        /// <returns>O Contato que digitou no campo de pesquisa</returns>
        [HttpGet]
        public ActionResult Buscar(string Pesquisa, int? pagina)
        {

            int tamanhoPagina = 8; // Quantidade de Anuncio por pagina      
            int numeroPagina = pagina ?? 1; // Se a Pagina for NULL inicia com valor 1.
            var q = db.Contatos.AsQueryable();

            if (!string.IsNullOrEmpty(Pesquisa))
            
                q = q.Where(c => c.Nome.Contains(Pesquisa));
                q = q.OrderBy(c => c.Nome);

                return View(q.ToPagedList(numeroPagina, tamanhoPagina));
        }

        /// <summary>
        /// Metodo para conferir de este Telefone já existe no banco de dados
        /// </summary>
        /// <param name="telefone"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ValidaCelular(string celular)
        {
            var contato = new Contato();
            var filtraCelular = celular.Trim();
            if (!String.IsNullOrEmpty(filtraCelular))
            {
                contato = db.Contatos.FirstOrDefault(x => x.Celular == filtraCelular);
                if (contato!= null && contato.ContatoId > 0)
                {
                    return Json(new { contato.Celular }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { ContatoId = 1 }, JsonRequestBehavior.AllowGet);
        }
    }
}
