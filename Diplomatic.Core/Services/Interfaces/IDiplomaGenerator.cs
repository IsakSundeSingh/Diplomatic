﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomatic.Core
{
    interface IDiplomaGenerator
    {
        IDiploma Generate(Template template);
    }
}
