using System.Reflection;

namespace drinks_info
{
    public class Operations
    {
        public static string[] ApiListToArray<T>(List<T> apiList) where T : IModelEntity
        {
            PropertyInfo nameProperty = typeof(T).GetProperty("Name");

            var resultArray = new string[apiList.Count + 1];

            for (int i = 0; i < apiList.Count; i++)
            {
                resultArray[i] = nameProperty.GetValue(apiList[i]).ToString();
            }
            resultArray[^1] = "Go back";

            return resultArray;
        }

        public static Drink MatchOptionWithDrinkObject(string? optionChoice, List<Drink> drinksList)
        {
            return drinksList.FirstOrDefault(d => d.Name == optionChoice);
        }

        public static string ModifyPropertyName(PropertyInfo property)
        {
            string modProperty;

            if (property.Name.StartsWith("str"))
                modProperty = property.Name[3..];
            else
                modProperty = property.Name;

            if (char.IsDigit(property.Name[^1]))
                if (char.IsDigit(property.Name[^2]))
                    modProperty = modProperty.Insert(modProperty.Length - 2, " ");
                else 
                    modProperty = modProperty.Insert(modProperty.Length - 1, " ");
            
            return modProperty;
        }
    }
}