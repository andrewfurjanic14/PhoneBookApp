using ConsoleUI.StateMachine;
using PhoneBookApp.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.UI
{
    internal class MainMenu(ContactService contactService) : ScreenState
    {
        private readonly ContactService _contactService = contactService;
        public override Task<ScreenAction> RunAsync()
        {
            ScreenState exitSentinel = new ExitScreenSentinel();
            ScreenState[] choices =
            {
                exitSentinel,
                new ViewContactsScreen(_contactService)
            };

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<ScreenState>()
                    .AddChoices(choices)
                    );

            return Task.FromResult<ScreenAction>(
                choice == exitSentinel
                ? new Exit()
                : new GoTo(choice));
        }
    }
}
