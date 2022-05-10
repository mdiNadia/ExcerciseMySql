using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Fluents
{
    class ExcerciseEntityFluent: IEntityTypeConfiguration<ExcerciseEntity>
    {


            public void Configure(EntityTypeBuilder<ExcerciseEntity> builder)
            {

            }
        }
    

}

