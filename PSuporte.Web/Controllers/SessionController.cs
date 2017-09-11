using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PSuporte.Domain.Models;
using PSuporte.Service;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PSuporte.Web.Controllers
{
    public class SessionController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public SessionController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Login(string nomeUsuario, string senha)
        {
            var resposta = new JsonResponse();

            try
            {
                _usuarioService.ValidarUsuario(nomeUsuario, senha);
            }
            catch (Exception e)
            {
                resposta.Mensagens.Add(e.Message);
                return Json(resposta);
            }

            var usuario = _usuarioService.GetUsuario(nomeUsuario);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nome, ClaimValueTypes.String),
                    new Claim(ClaimTypes.GivenName, usuario.NomeCompleto, ClaimValueTypes.String)
                };

            var identidadeUsuario = new ClaimsIdentity(claims, "Usuario");

            var principalUsuario = new ClaimsPrincipal(identidadeUsuario);

            await HttpContext.SignInAsync("PSuporteScheme", principalUsuario,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                }).ConfigureAwait(false);

            resposta.Sucesso = true;

            return Json(resposta);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("PSuporteScheme");

            return View("Index", "Home");
        }
    }
}