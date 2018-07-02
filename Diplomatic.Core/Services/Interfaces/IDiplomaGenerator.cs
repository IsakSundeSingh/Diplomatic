using System.Collections.Generic;

namespace Diplomatic.Core
{
    interface IDiplomaGenerator
    {
        IDiploma Generate(Template template, byte[] imageData);
    }
}
