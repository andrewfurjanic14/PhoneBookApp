using ConsoleUI.StateMachine;
using PhoneBookApp.Data.DTOs;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PhoneBookApp.UI
{
    internal class ViewContactsScreen(ContactService contactService) : ScreenState
    {
        public override string Name => "View Contacts";
        private readonly ContactService _contactService = contactService;
        public override async Task<ScreenAction> RunAsync()
        {
            var contacts = await _contactService.GetAllAsync();

            var exitSentinel = Contact.NameOnlySentinel("Exit");
            var backSentinel = Contact.NameOnlySentinel("Back");

            contacts.Insert(0, exitSentinel);
            contacts.Insert(0, backSentinel);
            Contact choice;
            do
            {
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<Contact>()
                        .AddChoices(contacts)
                        .UseConverter(c => ContactDto.DtoFromContact(c).ToString())
                        );
            } while (choice != exitSentinel && choice != backSentinel);

            return choice == exitSentinel
                ? new Exit()
                : new Back();
        }

    }
}
