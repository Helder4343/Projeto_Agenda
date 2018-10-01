using Listagem.Domain.Listas.Repository;
using Listagem.Models;
using Listagem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Listagem.Infra.Data.Repository
{
    public class ListaRepository : AzureRepository<Lista>, ListalRepository
    {
    }
}
