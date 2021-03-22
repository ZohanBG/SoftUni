using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] requestedFields)
        {
            StringBuilder result = new StringBuilder();
            Type type = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = type.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance)
                .Where(t => requestedFields.Contains(t.Name))
                .ToArray();
            Object classInstance = Activator.CreateInstance(type, new object[] { });
            result.AppendLine($"Class under investigation: {classToInvestigate}");
            foreach (var field in classFields)
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return result.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | 
                BindingFlags.Static | 
                BindingFlags.Public);

            MethodInfo[] NonPublicMethods = classType.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.NonPublic)
                .Where(n => n.Name.StartsWith("get"))
                .ToArray();

            MethodInfo[] PublicMethods = classType.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Public)
                .Where(n => n.Name.StartsWith("set"))
                .ToArray();

            StringBuilder result = new StringBuilder();

            foreach (var field in classFields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in NonPublicMethods)
            {
                result.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in PublicMethods)
            {
                result.AppendLine($"{method.Name} have to be private!");
            }

            return result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (var method in nonPublicMethods)
            {
                result.AppendLine(method.Name);
            }
            return result.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.NonPublic | 
                BindingFlags.Static);
            foreach (var method in methods.Where(n=>n.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in methods.Where(n => n.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
