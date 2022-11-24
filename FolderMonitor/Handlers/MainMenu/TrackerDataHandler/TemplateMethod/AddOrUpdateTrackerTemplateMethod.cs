using FolderMonitor.Converters;
using FolderMonitor.Pages;
using FolderMonitor.Validators.TrackerValidators;
using FolderMonitor.Warnings;
using System.Collections.Generic;

namespace FolderMonitor.Handlers.MainMenu.TrackerDataHandlers.TemplateMethod
{
    public abstract class AddOrUpdateTrackerTemplateMethod
    {
        protected MainMenuPage itsMainMenuPage;
        protected List<string> itsFilters;

        public MainMenuPage MainMenuPage { set { itsMainMenuPage = value; } }

        public void AddOrUpdate()
        {
            itsFilters = FiltersConverter.ToFiltersStringList(itsMainMenuPage.itsFilterController.FiltersStackPanel);

            IWarning warning = null;
            if (FolderBrowserDialogValidator.CheckChosenFolderTextBlock(itsMainMenuPage.itsTrackedDirectoryDialog).GetType() != typeof(None))
                warning = new IncorrectFilePath();
            else if (FiltersValidator.CheckFilters(itsFilters).GetType() != typeof(None))
                warning = new IncorrectFilter();
            else
            {
                warning = AddOrUpdateTracker();
                if (warning is None)
                {
                    // if a tracker is added or updated, clears filters in stackpanel, because we don't need them anymore
                    itsMainMenuPage.itsFilterController.ClearFilters();
                    itsMainMenuPage.itsTrackedDirectoryDialog.SelectedPath = string.Empty; // clear chosen folder path
                    itsMainMenuPage.itsMainMenuPageHandler.ClearChosenFolderName(); // clear chosen folder path on UI
                }
            }
            
            if (warning is not None)
                WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock, warning);
        }
        protected abstract IWarning AddOrUpdateTracker();
    }
}