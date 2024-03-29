﻿using ADSL.Cache.Context;
using ADSL.Exceptions;
using ADSL.Interfaces;
using ADSL.Utils;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using ConcurrentDictionaryTypeContext = System.Collections.Concurrent.ConcurrentDictionary<System.Type, ADSL.Cache.Context.AbstractAttributeContext>;

namespace ADSL.Cache
{
    public class ClassMetaData
    {
        private ConcurrentDictionary<IFieldPropertyInfo, ConcurrentDictionaryTypeContext> _propertyContexts;
        private ClassAttributeContext _classAttributeContext;
        private Type _classType;
        private IFieldPropertyInfo[] _properties;

        public ClassMetaData(Type type)
        {
            _classType = type;
            _classAttributeContext = new ClassAttributeContext(type);
            _properties = type.GetFieldsAndProperties(ReflectionUtils.GetPublicBindingFlags());
            _propertyContexts = new ConcurrentDictionary<IFieldPropertyInfo, ConcurrentDictionaryTypeContext>();
            
            foreach (IFieldPropertyInfo property in _properties)
            {
                ConcurrentDictionaryTypeContext propertyDictionary = new ConcurrentDictionaryTypeContext();

                foreach(MetaDataEntry entry in MetaDataRegistry.Entries)
                {
                    if (ReflectionUtils.HasCustomAttributeType(entry.Interface, property))
                    {
                        AbstractAttributeContext context = (AbstractAttributeContext)Activator.CreateInstance(entry.Type, new object[] { property });
                        if (entry.Validator != null)
                        {
                            IPropertyAttributeValidator validatorInstance = (IPropertyAttributeValidator)Activator.CreateInstance(entry.Validator);
                            validatorInstance.Validate(property, _classType, context);
                        }
                        if (!propertyDictionary.TryAdd(entry.Type, context))
                            throw new ReflectionCacheException($"Type {type.AssemblyQualifiedName} could not be added to the cache because property {property.Name} could not be added to cache");
                    }                
                }

                if (!_propertyContexts.TryAdd(property, propertyDictionary))
                    throw new ReflectionCacheException($"Type {type.AssemblyQualifiedName} could not be added to the cache");
            }        
        }

        public Type Type { get { return _classType; } }

        public IFieldPropertyInfo[] Properties { get { return _properties; } }

        public ClassAttributeContext ClassAttributeContext { get { return _classAttributeContext; } }

        public AttributeContextType GetAttributeContextForProperty<AttributeContextType>(IFieldPropertyInfo property) where AttributeContextType : AbstractAttributeContext
        {
            return (AttributeContextType)_propertyContexts[property][typeof(AttributeContextType)];
        }

        public bool HasPropertyAttributeContext<AttributeContextType>(IFieldPropertyInfo property)
        {
            return _propertyContexts.ContainsKey(property) && _propertyContexts[property].ContainsKey(typeof(AttributeContextType));
        }

        public ConcurrentDictionaryTypeContext GetContextsForProperty(IFieldPropertyInfo property)
        {
            return _propertyContexts[property];
        }
    }
}
