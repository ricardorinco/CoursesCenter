using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace RR.CoursesCenter.UI.WebApp.App_Start
{
    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext)
        {
            ValueProviderResult valueResult = modelBindingContext.ValueProvider
                .GetValue(modelBindingContext.ModelName);

            ModelState modelState = new ModelState { Value = valueResult };

            object actualValue = null;

            try
            {
                if (Regex.Match(valueResult.AttemptedValue, @"^\d+(\.\d{1,2})?$").Success)
                {
                    actualValue = Convert.ToDecimal(
                        valueResult.AttemptedValue,
                        CultureInfo.InvariantCulture
                    );
                }
                else if (Regex.Match(valueResult.AttemptedValue, @"^\d+(\,\d{1,2})?$").Success)
                {
                    actualValue = Convert.ToDecimal(
                        valueResult.AttemptedValue,
                        CultureInfo.CurrentCulture
                    );
                }
                else
                {
                    actualValue = Convert.ToDecimal(
                        valueResult.AttemptedValue,
                        CultureInfo.CurrentCulture
                    );
                }
            }
            catch (FormatException ex)
            {
                modelState.Errors.Add(ex);
            }

            modelBindingContext.ModelState.Add(modelBindingContext.ModelName, modelState);

            return actualValue;
        }
    }
}