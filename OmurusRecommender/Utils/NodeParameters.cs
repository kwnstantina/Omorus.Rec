﻿namespace OmurusRecommender.Utils
{
    public class NodeParameters<T>
    {
        private readonly T _node;

        public NodeParameters(T node)
        {
            _node = node;
        }

        public Dictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (_node != null)
            {
                var properties = _node.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var value = property.GetValue(_node);

                    // Convert Guid to string if the property type is Guid
                    if (property.PropertyType == typeof(Guid) && value is Guid guidValue)
                    {
                        parameters[property.Name] = guidValue.ToString();
                    }
                    else
                    {
                        parameters[property.Name] = value ?? DBNull.Value;
                    }
                }
            }

            return parameters;
        }
    }

}
