using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Globalization;
using System.Runtime.ExceptionServices;

namespace McKingApp.Binders
{
    public class DecimalModelBinder : IModelBinder
    {
        private readonly NumberStyles _supportedStyles;

        public DecimalModelBinder(NumberStyles supportedStyles)
        {
            this._supportedStyles = supportedStyles;
        }

        /// <inheritdoc />
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
            string modelName = bindingContext.ModelName;
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(modelName);
            if (value == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            ModelStateDictionary modelState = bindingContext.ModelState;
            modelState.SetModelValue(modelName, value);
            ModelMetadata modelMetadata = bindingContext.ModelMetadata;
            Type underlyingOrModelType = modelMetadata.UnderlyingOrModelType;
            Task completedTask;
            try
            {
                string firstValue = value.FirstValue;
                CultureInfo culture = value.Culture;
                object obj;
                if (string.IsNullOrWhiteSpace(firstValue))
                {
                    obj = null;
                }
                else
                {
                    if (!(underlyingOrModelType == typeof(decimal)))
                    {
                        throw new NotSupportedException();
                    }
                    //TODO mandatory => culture invariant (.NET Core bug for other culture)
                    //obj = decimal.Parse(firstValue, this._supportedStyles, culture);
                    obj = decimal.Parse(firstValue, this._supportedStyles, CultureInfo.InvariantCulture);
                }
                if (obj == null && !modelMetadata.IsReferenceOrNullableType)
                {
                    modelState.TryAddModelError(modelName, modelMetadata.ModelBindingMessageProvider.ValueMustNotBeNullAccessor.Invoke(value.ToString()));
                    completedTask = Task.CompletedTask;
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Success(obj);
                    completedTask = Task.CompletedTask;
                }
            }
            catch (Exception sourceException)
            {
                if (!(sourceException is FormatException) && sourceException.InnerException != null)
                {
                    sourceException = ExceptionDispatchInfo.Capture(sourceException.InnerException).SourceException;
                }
                modelState.TryAddModelError(modelName, sourceException, modelMetadata);
                completedTask = Task.CompletedTask;
            }
            return completedTask;
        }
    }
}