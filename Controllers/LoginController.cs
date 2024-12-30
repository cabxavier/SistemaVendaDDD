using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Helpers;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers;

public class LoginController : Controller
{
    private readonly IServicoAplicacaoUsuario servicoAplicacaoUsuario;
    private readonly IHttpContextAccessor httpContextAccessor;    

    public LoginController(IServicoAplicacaoUsuario servicoAplicacaoUsuario, IHttpContextAccessor httpContextAccessor)
    {
        this.servicoAplicacaoUsuario = servicoAplicacaoUsuario;
        this.httpContextAccessor = httpContextAccessor;
    }
    
    // GET
    public IActionResult Index(int? id)
    {
        if (id != null)
        {
            if (id == 0)
            {
                this.httpContextAccessor.HttpContext.Session.Clear();
            }
        }
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginViewModel model)
    {
        ViewData["ErrorLogin"] = string.Empty;
        
        if (ModelState.IsValid)
        {
            var senha = Criptografia.GetMd5Hash(model.Senha);
            var usuario = this.servicoAplicacaoUsuario.RetornarDadosUsuario(model.Email, senha);
            
            if (!(this.servicoAplicacaoUsuario.ValidarLogin(model.Email, senha)))
            {
                ViewData["ErrorLogin"] = "E-email e/ou senha incorreto";
                return View(model);
            }
            else
            {
                this.httpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                this.httpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                this.httpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                this.httpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                
                return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            return View(model);
        }
    }
}