using PhoneBookApp.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBookApp.UI
{
    internal class PromptService
    {
        public static Contact ContactCreationPrompt()
        {
            var firstName = NamePrompt("Enter First Name:");
            var lastName = NamePrompt("Enter Last Name:");
            var email = EmailPrompt();
            var phoneNumber = PhoneNumberPrompt();
            return new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = NormalizePhoneNumber(phoneNumber)
            };
        }

        public static string NamePrompt(string instruction)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>(instruction)
                    .Validate(name =>
                    {
                        if (string.IsNullOrWhiteSpace(name))
                            return ValidationResult.Error("[red]Name cannot be empty[/]");
                        return ValidationResult.Success();
                    }));
        }

        public static string EmailPrompt()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter email:")
                    .Validate(email =>
                    {
                        if (string.IsNullOrWhiteSpace(email))
                            return ValidationResult.Error("[red]Email cannot be empty[/]");
                        if (!email.Contains("@"))
                            return ValidationResult.Error("[red]Email must contain '@'[/]");
                        return ValidationResult.Success();
                    }));
        }

        public static string PhoneNumberPrompt()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter phone number:")
                    .Validate(pnum =>
                    {
                        if (!Regex.IsMatch(pnum, @"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$"))
                        {
                            return ValidationResult.Error("Try again. " +
                                "Phone number must be in one of the following formats:\n" +
                                "(123) 456-7890\n" +
                                "123-456-7890\n" +
                                "1234567890\n" +
                                "123 456 7890\n" +
                                "123.456.7890");
                        }
                        else
                            return ValidationResult.Success();
                    }));
        }

        private static string NormalizePhoneNumber(string phoneNumber)
        {
            var digits = Regex.Replace(phoneNumber, @"\D", "");
            return $"{digits[..3]}-{digits[3..6]}-{digits[6..]}";
        }
    }
}
