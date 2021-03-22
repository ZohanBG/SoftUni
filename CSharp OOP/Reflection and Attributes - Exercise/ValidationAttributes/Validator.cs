using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {

        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                MyValidationAttribute[] atributes = property.GetCustomAttributes()
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                object? value = property.GetValue(obj);

                foreach (var atribute in atributes)
                {
                    bool isValid = atribute.IsValid(value);
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
