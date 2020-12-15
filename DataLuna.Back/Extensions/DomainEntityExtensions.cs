using System;
using System.Net;
using System.Linq;
using DataLuna.Back.Common.Exceptions;

namespace DataLuna.Back.Extensions
{
    public static class DomainEntityExtensions
    {
        public static void UpdateEntityPropValue<T>(string property, string value, ref T instance)
        {
            var props = typeof(T).GetProperties();
            
            var propToChange = props.FirstOrDefault(f => f.Name.ToLower() == property.ToLower());
            if (propToChange == null)
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Requested property wasn`t found.");

            var propValue = propToChange.GetValue(instance);

            switch (propValue)
            {
                case string stringValue:
                {
                    propToChange.SetValue(instance, value);
                    break;
                }
                case long longValue:
                {
                    if (!long.TryParse(value, out long settingValue))
                        throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Wrong value for long type.");

                    propToChange.SetValue(instance, settingValue);
                    break;
                }
                default:
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Unsupported propery type.");
            }
        }
    }
}