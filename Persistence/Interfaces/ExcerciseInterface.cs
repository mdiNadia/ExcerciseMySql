using Domain;
using Persistence.Interfaces.GenericRepo;
using System;
using System.Collections.Generic;

namespace Persistence.Interfaces
{
    public interface IExcerciseService : ICrudEntity<ExcerciseEntity>
    {
        List<T> GetReportData<T>(string serial);

    }
}
