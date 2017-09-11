using System;
using System.Collections.Generic;
using System.Text;
using PSuporte.Domain.Models;
using PSuporte.Domain.Data;
using System.Linq;
using PSuporte.Domain.Commons;

namespace PSuporte.Service
{
    public class UsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario GetUsuario(string nomeUsuario)
        {
            return _usuarioRepository.GetAll().FirstOrDefault(u => u.Nome == nomeUsuario);
        }

        public Usuario GetUsuarioById(long id)
        {
            return _usuarioRepository.GetAll().FirstOrDefault(u => u.Id == id);
        }

        public void ValidarUsuario(string usuario, string senha)
        {
            var usuarioEncontrado = GetUsuario(usuario);

            if (usuarioEncontrado == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            if (!usuarioEncontrado.Senha.Equals(HashUtil.EncryptString(senha)))
            {
                throw new Exception("Senha incorreta");
            }
        }
    }
}
