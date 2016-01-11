using SistemaAgendaORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAgendaWeb.Controllers
{
    public class ArquivoController : Controller
    {
        // GET: Arquivo
        public ActionResult ExibirImagem(int id)
        {
            using (Contexto db = new Contexto())
            {
                var arquivoRetorno = db.Contatos.Find(id);
                return File(arquivoRetorno.Imagem, arquivoRetorno.ImagemTipo);
            }
        }
    }
}