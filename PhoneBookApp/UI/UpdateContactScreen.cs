using ConsoleUI;
using ConsoleUI.StateMachine;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.UI
{
    internal class UpdateContactScreen(ContactService contactService, Contact contact) : ScreenState
    {
        public override string Name => "Update Contact";
        private readonly ContactService _contactService = contactService;
        private readonly Contact _contact = contact;
        public override async Task<ScreenAction> RunAsync()
        {
            var choices = new UserChoice<string>[] 
            {
                new() { Label = "Save Changes", Value = "save" },
                new() { Label = _contact.FirstName, Value = "fname" },
                new() { Label = _contact.LastName, Value = "lname" },
                new() { Label = $"Email: {_contact.Email}", Value = "email" },
                new() { Label = $"Phone Number: {_contact.PhoneNumber}", Value = "pnum" }
            }; 

            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<UserChoice<string>>()
                    .AddChoices(choices)
                    );

                switch (choice.Value)
                {
                    case "fname":
                        _contact.FirstName = PromptService.NamePrompt("Enter First Name: ");
                        break;
                    case "lname":
                        _contact.LastName = PromptService.NamePrompt("Enter Last Name: ");
                        break;
                    case "email":
                        _contact.Email = PromptService.EmailPrompt();
                        break;
                    case "pnum":
                        _contact.PhoneNumber = PromptService.PhoneNumberPrompt();
                        break;
                    case "save":
                        await _contactService.UpdateAsync(_contact);
                        return new Back();
                }
            }
        }
    }
}
