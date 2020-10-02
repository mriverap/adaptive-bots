using System.Collections.Generic;
using System.IO;
using Microsoft.Bot.Builder.Dialogs.Adaptive;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Actions;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Conditions;
using Microsoft.Bot.Builder.Dialogs.Adaptive.Generators;
using Microsoft.Bot.Builder.LanguageGeneration;

namespace EmptyBotAdaptive.Dialogs
{
    public class RootDialog : AdaptiveDialog
    {
        private readonly Templates _templates;
        public RootDialog() : base(nameof(RootDialog))
        {
            string[] paths = { ".", "Dialogs", $"RootDialog.lg" };
            var fullPath = Path.Combine(paths);
            _templates = Templates.ParseFile(fullPath);
            
            Triggers = new List<OnCondition>
            {
                new OnUnknownIntent
                {
                    Actions =
                    {
                        new SendActivity("${WelcomeMessage()}"),
                    }
                },
            };

            Generator = new TemplateEngineLanguageGenerator(_templates);
        }
    }
}
