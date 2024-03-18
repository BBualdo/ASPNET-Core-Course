﻿using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.Helpers
{
  public class ValidationHelper
  {
    internal static void ModelValidation(object obj)
    {
      ValidationContext validationContext = new ValidationContext(obj);
      List<ValidationResult> results = new List<ValidationResult>();
      bool isValid = Validator.TryValidateObject(obj, validationContext, results, true);
      if (!isValid)
      {
        throw new ArgumentException(results.FirstOrDefault()?.ErrorMessage);
      }
    }
  }
}
