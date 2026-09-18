using ConsoleUI.StateMachine;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBookApp.UI
{
    internal class AddContactScreen(ContactService contactService) : ScreenState
    {
        public override string Name => "Add New Contact";
        private readonly ContactService _contactService = contactService;
        public override async Task<ScreenAction> RunAsync()
        {
            var contact = PromptService.ContactCreationPrompt();
            await _contactService.AddAsync(contact);
            return new Back();
        }
        
    }
}
