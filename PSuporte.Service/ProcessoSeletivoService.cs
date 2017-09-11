using PSuporte.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSuporte.Domain.Models;

namespace PSuporte.Service
{
    public class ProcessoSeletivoService
    {
        private readonly IRepository<ProcessoSeletivo> _processoSeletivoRepo;

        public ProcessoSeletivoService(IRepository<ProcessoSeletivo> processoSeletivoRepo)
        {
            _processoSeletivoRepo = processoSeletivoRepo;
        }

        public List<ProcessoSeletivo> GetProcessosSeletivos()
        {
            return _processoSeletivoRepo.GetAll().ToList();
        }

        public ProcessoSeletivo GetProcessoSeletivo(long id)
        {
            return _processoSeletivoRepo.Get(id);
        }
    }
}
