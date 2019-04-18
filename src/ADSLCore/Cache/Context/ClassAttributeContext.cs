using System;

namespace ADSL.Cache.Context
{
    public class ClassAttributeContext : AbstractAttributeContext
    {
        private readonly Type _classType;

        public ClassAttributeContext(Type classType)
            : base(classType)
        {
            _classType = classType;
        }

        public Type Type { get { return _classType; } }
    }  
}
