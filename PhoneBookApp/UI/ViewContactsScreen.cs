using ConsoleUI.StateMachine;
using PhoneBookApp.Data.DTOs;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using Spectre.Console;

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

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<Contact>()
                    .AddChoices(contacts)
                    .UseConverter(c => ContactDto.DtoFromContact(c).ToString())
                    );

            if (choice == exitSentinel)
            {
                return new Exit();
            }
            else if (choice == backSentinel)
            {
                return new Back();
            }
            else
            {
                return new GoTo(new EditContactScreen(_contactService, contact: choice));
            }
        }

    }
}
