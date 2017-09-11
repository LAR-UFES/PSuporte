using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSuporte.Service;
using PSuporte.Domain.Models;
using PSuporte.Domain.Extensions;
using PSuporte.Domain.Models.Enuns;

namespace PSuporte.Web.Controllers
{
    public class ProcessoSeletivoController : Controller
    {
        private readonly ProcessoSeletivoService _processoSeletivoService;
        private readonly CandidatoService _candidatoService;

        public ProcessoSeletivoController(ProcessoSeletivoService processoSeletivoService, 
            CandidatoService candidatoService)
        {
            _processoSeletivoService = processoSeletivoService;
            _candidatoService = candidatoService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inscricao(long id)
        {
            var ps = _processoSeletivoService.GetProcessoSeletivo(id);

            return View("Inscricao", ps);
        }

        [HttpPost]
        public IActionResult InscreverCandidato(Candidato candidato)
        {
            var _candidato = candidato;
            _candidato.ProcessoSeletivo = _processoSeletivoService.GetProcessoSeletivo(candidato.ProcessoSeletivoId);

            var resposta = new JsonResponse();

            if (_candidato.Nome.IsNullOrEmpty())
            {
                resposta.Mensagens.Add("O Nome é obrigatório.");
            } else
            {
                if (_candidato.Nome.Length > 45)
                    resposta.Mensagens.Add("O Nome não pode conter mais que 45 caracteres.");
            }

            if (_candidato.Email.IsNullOrEmpty())
            {
                resposta.Mensagens.Add("O Email é obrigatório.");
            } else
            {
                if (!_candidato.Email.IsValidEmail())
                    resposta.Mensagens.Add("O Email informado é inválido.");
            }

            if (_candidato.Curso == 0)
                resposta.Mensagens.Add("O Curso é obrigatório.");

            if (Request.Form.Files.Count == 0)
            {
                resposta.Mensagens.Add("O Horário Individual é obrigatório.");
            } else
            {
                _candidato.HorarioIndividual = Request.Form.Files[0].ToBytes();

                if (Request.Form.Files[0].ContentType != "application/pdf" || Request.Form.Files[0].ContentType != "application/x-pdf")
                    resposta.Mensagens.Add("O arquivo deve ser do tipo PDF.");
            }

            if (Request.Form.Files.Count > 1)
                resposta.Mensagens.Add("É permitido enviar somente um arquivo.");

            if (resposta.Mensagens.Count > 0)
                return Json(resposta);

            _candidatoService.SalvarCandidato(_candidato);
            resposta.Sucesso = true;

            return Json(resposta);
        }
    }
}