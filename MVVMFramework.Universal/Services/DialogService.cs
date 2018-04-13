using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MVVMFramework.Services
{
    /// <summary>
    /// Service for dialogs
    /// </summary>
    public static class DialogService
    {
        /// <summary>
        /// Shows a message dialog
        /// </summary>
        /// <param name="text">The message text</param>
        /// <returns>Async task</returns>
        public static async Task ShowMessageDialog(string text)
        {
            var diag = new MessageDialog(text);
            var result = await diag.ShowAsync();
        }

        /// <summary>
        /// Shows a DecisionDialog
        /// </summary>
        /// <param name="text">The message text</param>
        /// <param name="positivText">Primary button text</param>
        /// <param name="negativText">Secondary button text</param>
        /// <returns>Async task</returns>
        public static async Task<bool> ShowDecisionDialog(string text, string positivText, string negativText)
        {
            var diag = new ContentDialog();
            diag.Content = text;
            diag.PrimaryButtonText = positivText;
            diag.SecondaryButtonText = negativText;
            var result = await diag.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
