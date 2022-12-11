using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseRentingSystem.ModelBinders;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ValueProviderResult valueResult = bindingContext.ValueProvider
            .GetValue(bindingContext.ModelName); // getting the value of what we are trying to bind

        if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue)) // we are checking if we got anything
        {
            decimal actualValue = 0M;
            bool success = false;

            try
            {

                
                // the value of the what we are trying to bind is saved in a string variable
                string decValue = valueResult.FirstValue;
                
                // we replace the . and the , on the decValue with the correct decimal separator for the specific machine
                decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                // we convert the decValue from string to decimal
                actualValue = Convert.ToDecimal(decValue, CultureInfo.CurrentCulture);
                success = true;


            }
            catch (FormatException fe)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
            }


            if (success)
            {
                bindingContext.Result = ModelBindingResult.Success(actualValue);

                return Task.CompletedTask;
            }
            

        }

        return Task.CompletedTask;
    }
}