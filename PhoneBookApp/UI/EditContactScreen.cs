using ConsoleUI.StateMachine;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.UI
{
    internal class EditContactScreen(ContactService contactService, Contact contact) : ScreenState
    {
        private readonly ContactService _contactService = contactService;
        private readonly Contact _contact = contact ?? throw new ArgumentNullException();

        public override async Task<ScreenAction> RunAsync()
        {
            Console.WriteLine(_contact);

            ScreenState exitSentinel = new ExitScreenSentinel();
            ScreenState backSentinel = new BackScreenSentinel();
            ScreenState deleteSentinel = new DeleteScreenSentinel();

            ScreenState[] choices =
            {
                exitSentinel,
                backSentinel,
                deleteSentinel,
                new UpdateContactScreen(_contactService, _contact)
            };

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<ScreenState>()
                    .AddChoices(choices)
                    );

            if (choice == exitSentinel)
            {
                return new Exit();
            }
            else if (choice == backSentinel)
            {
                return new Back();
            }
            else if (choice == deleteSentinel)
            {
                await _contactService.DeleteAsync(_contact);
                return new Back();
            }
            else
            {
                return new GoTo(choice);
            }
        }
    }

    public class DeleteScreenSentinel : ScreenState
    {
        public override string Name => "Delete";
        public override Task<ScreenAction> RunAsync() => throw new NotSupportedException();
    }
}
