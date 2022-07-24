using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();


            foreach(PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);

                foreach(CustomAttributeData customAttributeData in property.CustomAttributes)
                {
                    Type customAttr = customAttributeData.AttributeType;
                    object attrInstance = property.GetCustomAttribute(customAttr);

                    MethodInfo velidationMethod = customAttr.GetMethods().First(m => m.Name == "IsValid");
                    bool result = (bool)velidationMethod.Invoke(attrInstance, new object[] { propValue });

                    if(!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
