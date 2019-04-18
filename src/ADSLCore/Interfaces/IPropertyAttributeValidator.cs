using ADSL.Cache.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ADSL.Interfaces
{
    public interface IPropertyAttributeValidator
    {
        void Validate(IFieldPropertyInfo property, Type parentType, AbstractAttributeContext context);
    }
}
