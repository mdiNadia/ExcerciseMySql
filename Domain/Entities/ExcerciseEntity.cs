﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExcerciseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string SerialNumber{ get; set; }
        public int DeviceId { get; set; }
        public int RefId { get; set; }
        public int IdMachine { get; set; }
        public int IdEvent { get; set; }

    }
}
