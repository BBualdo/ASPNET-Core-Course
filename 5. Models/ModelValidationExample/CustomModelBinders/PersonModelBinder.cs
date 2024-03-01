using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationExample.Models;

namespace ModelValidationExample.CustomModelBinders
{
  public class PersonModelBinder : IModelBinder
  {

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      Person person = new Person();

      // Name
      if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
      {
        string? firstName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
        person.Name = firstName;

        if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
        {
          string? lastName = bindingContext.ValueProvider.GetValue("LastName").FirstValue;
          person.Name = person.Name + " " + lastName;
        }
      };

      //Email
      if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
      {
        string? email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
        person.Email = email;
      }

      //Phone
      if (bindingContext.ValueProvider.GetValue("Phone").Length > 0)
      {
        string? phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
        person.Phone = phone;
      }

      //Password
      if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
      {
        string? password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
        person.Password = password;
      }

      //ConfirmPassword
      if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Length > 0)
      {
        string? confirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;
        person.ConfirmPassword = confirmPassword;
      }

      //Price
      if (bindingContext.ValueProvider.GetValue("Price").Length > 0)
      {
        double? price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);
        person.Price = price;
      }

      //DateOfBirth
      if (bindingContext.ValueProvider.GetValue("DateOfBirth").Length > 0)
      {
        DateTime? dateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue);
        person.DateOfBirth = dateOfBirth;
      }

      bindingContext.Result = ModelBindingResult.Success(person);

      return Task.CompletedTask;
    }
  }
}
