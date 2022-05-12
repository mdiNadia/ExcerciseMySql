using Domain;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.Interfaces;
using Persistence.Interfaces.GenericRepo;
using System;


namespace Persistence.Services
{
    public class ExcerciseService : CrudEntity<ExcerciseEntity>, IExcerciseService
    {
        public ExcerciseService(IConfiguration config, DataContext context) : base(config, context)
        {
        }
    }
}
