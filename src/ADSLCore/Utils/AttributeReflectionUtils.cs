using ADSL.Cache.Context;
using ADSL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ADSL.Utils
{
    public class AttributeReflectionUtils
    {
        public static T GetCustomAttribute<T>(IReadOnlyCollection<IAttributeMarker> attributes)
        {
            return (T)attributes
                        .Where((IAttributeMarker attribute) => attribute is T)
                        .FirstOrDefault();
        }

        public static T GetCustomAttribute<T>(AbstractAttributeContext context)
        {
            return (T)context.Attributes
                        .Where((IAttributeMarker attribute) => attribute is T)
                        .FirstOrDefault();
        }
    }
}
