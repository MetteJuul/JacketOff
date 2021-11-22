using System.Linq;
using System.Reflection;

namespace API.DTOs.Converters {
    public static class ConverterExtensionMethods {

        //This method takes 1 object and reflects it into another
        //It is used to reflect a generic Model layer class to its respective DTO
        //or vice versa, reflect a DTO to its respective Model layer class
        public static T CopyPropertiesTo<T>(this object sourceObject, T destinationObject)
        {
            //Using the lambda, we determine which properties of the object is writable,
            //since only these should be copied. This helps us exclude things like password
            foreach (PropertyInfo destinationProperty in destinationObject.GetType().GetProperties().Where(p => p.CanWrite))
            {
                //Using this if statement we determine whether the name of the property 
                //as well as the type
                if (!sourceObject.GetType().GetProperties().Any(sourceProperty => sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)) continue;
                var sourceProperty = sourceObject.GetType().GetProperty(destinationProperty.Name);
                destinationProperty.SetValue(destinationObject, sourceProperty.GetValue(sourceObject, null), null);
            }
            return destinationObject;
        }
    }
}
