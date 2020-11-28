using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> propertyCustomAttribute = property.GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in propertyCustomAttribute)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }

                }
            }

            return true;
        }
    }
}
