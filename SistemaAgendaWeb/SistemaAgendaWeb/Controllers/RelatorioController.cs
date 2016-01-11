using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using SistemaAgendaDominio;
using SistemaAgendaORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAgendaWeb.Controllers
{
    public class RelatorioController : Controller
    {
        private Contexto db = new Contexto();
        private Contato contato = new Contato();

        // GET: Relatorio
        public ActionResult Index()
        {

            /// Total de Contatos
            int i = 0;
            for (i = 0; i < db.Contatos.Count(); )
            {
                i++;

            }

            
            ViewBag.Resultado = i;


            /// Total de Contatos Femininos
            int j = 0;
            foreach (var item in db.Contatos)
            {
                if (item.Feminino == true)
                {
                    j++;
                }
            }

            ViewBag.Feminino = j;

            /// Total de Contatos Masculinos
            int k = 0;
            foreach (var item in db.Contatos)
            {
                if (item.Masculino == true)
                {
                    k++;
                }
            }

            ViewBag.Masculino = k;


            /// Graficos de Contatos
            
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
            .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
            .SetTitle(new Title { Text = "Gráfico de Contatos" })
            .SetXAxis(new XAxis
                        {
                            Categories = new[] { "Masculino", "Feminino", "Total"}
                        })
            .SetYAxis(new YAxis
            {
                Min = 0,
                Title = new YAxisTitle { Text = "Quatidade de Contatos" }
            })
            .SetSeries(new Series
                        {
                            Data = new Data(new object[] { k, j, i })
                        });

            ViewBag.grafico = chart;

            return View();
        }
    }
}