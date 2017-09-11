using PSuporte.Domain.Data;
using PSuporte.Domain.Models;
using PSuporte.Repo.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSuporte.Service
{
    public class CandidatoService
    {
        private readonly IRepository<Candidato> _candidatoRepository;

        public CandidatoService(IRepository<Candidato> candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public void SalvarCandidato(Candidato candidato)
        {
            _candidatoRepository.Insert(candidato);
        }
    }
}
