using DeleteME.Models;
using FluentValidation.Results;

namespace DeleteME
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa en kund
            var customer = new Customer
            {
                Name = "2",
                Email = "invalid-email@gmail",
                PhoneNumber = "12345A",
                DateOfBirth = DateTime.Now.AddYears(-10)
            };

            // Skapa validatorn
            var validator = new CustomerValidator();

            // Validera kunden
            ValidationResult modelState = validator.Validate(customer);

            // Hantera valideringsresultat
            if (!modelState.IsValid)
            {
                foreach (var failure in modelState.Errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error: {failure.ErrorMessage}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Customer is valid!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }

}

