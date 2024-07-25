using System.Reflection;

namespace NewTestHashavimWeb.Helper
{
    public class DllService
    {
        private readonly string _assemblyPath;
        private readonly Assembly _assembly;
        private readonly Dictionary<string, object> _instances = new Dictionary<string, object>();

        public DllService(string assemblyPath)
        {
            _assemblyPath = assemblyPath;   
            _assembly = Assembly.LoadFrom(_assemblyPath);
        }

        public object CreateInstance(string className)
        {
            if (_instances.ContainsKey(className))
            {
                return _instances[className];
            }

            Type type = _assembly.GetType(className);
            if (type == null)
            {
                throw new Exception($"Class {className} not found in assembly {_assemblyPath}");
            }

            var instance = Activator.CreateInstance(type);
            _instances[className] = instance;
            return instance;
        }

        public object InvokeMethod(object instance, string methodName, params object[] parameters)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName);
            if (method == null)
            {
                throw new Exception($"Method {methodName} not found in class {instance.GetType().FullName}");
            }

            return method.Invoke(instance, parameters);
        }
    }

}
