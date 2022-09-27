using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    internal static class TypeTreeUtility
    {
        public static object TypeTreeToType(Type targetType, object typeTree)
        {
            object targetObject = Activator.CreateInstance(targetType);

            foreach (DictionaryEntry dataProperty in (OrderedDictionary)typeTree)
            {
                PropertyInfo matchingProperty = targetType.GetProperties()
                    .FirstOrDefault(p => p.Name.ToLower().Equals(dataProperty.Key.ToString().ToLower()));

                object propertyValue = dataProperty.Value;

                if (matchingProperty is not null)
                {
                    object value = null;

                    if (propertyValue.GetType() == typeof(List<object>))
                    {
                        List<object> list = (List<object>)propertyValue;

                        Type elementType;
                        if (list?.Count > 0)
                        {
                            elementType = list[0].GetType();

                            Array newArray = null;

                            if (elementType == typeof(OrderedDictionary))
                            {
                                newArray = Array.CreateInstance(matchingProperty.PropertyType.GetElementType(), list.Count);

                                for (int i = 0; i < newArray.Length; i++)
                                {
                                    newArray.SetValue(TypeTreeToType(matchingProperty.PropertyType.GetElementType(), list[i]), i);
                                }
                            }
                            else
                            {
                                newArray = Array.CreateInstance(elementType, list.Count);
                                list.ToArray().CopyTo(newArray, 0);
                            }

                            value = newArray;
                        }
                    }
                    else if (propertyValue.GetType() == typeof(OrderedDictionary))
                    {
                        value = TypeTreeToType(matchingProperty.PropertyType, propertyValue);
                    }
                    else
                    {
                        value = propertyValue;
                    }

                    matchingProperty.SetValue(targetObject, value);
                }
            }

            return targetObject;
        }
    }
}
