﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    interface IEsteria
    {

       int VerificarAsync(Console console);
      Task RecebeConsole(Console console);
      
    }
}
