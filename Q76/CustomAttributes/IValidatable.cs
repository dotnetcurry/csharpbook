using System.Collections.Generic;

namespace CustomAttributes
{
    public interface IValidatable
    {
        Dictionary<string, string> GetValidationErrors();
    }

}
