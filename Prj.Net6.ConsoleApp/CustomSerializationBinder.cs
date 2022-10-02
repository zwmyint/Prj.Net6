using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.ConsoleApp
{
    public class CustomSerializationBinder : ISerializationBinder
    {
        Dictionary<string, Type> AliasToTypeMapping { get; }
        Dictionary<Type, string> TypeToAliasMapping { get; }

        public CustomSerializationBinder()
        {
            TypeToAliasMapping = new Dictionary<Type, string>
            {
                { typeof(Assembly), "A" }
            };

            AliasToTypeMapping = new Dictionary<string, Type>
            {
                { "A", typeof(Assembly) }
            };
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            var alias = TypeToAliasMapping[serializedType];

            assemblyName = null;  // I don't care about the assembly name for this example
            typeName = alias;
            Console.WriteLine("Binding type " + serializedType.Name + " to alias " + alias);
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            var type = AliasToTypeMapping[typeName];
            Console.WriteLine("Binding alias " + typeName + " to type " + type);
            return type;
        }
    }
}
