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
            if (FolderBrowserDialogValidator.CheckFolderBrowserDialog(itsMainMenuPage.itsChosenFolder).GetType() != typeof(None))
                warning = new IncorrectFilePath();
            else if (FiltersValidator.CheckFilters(itsFilters).GetType() != typeof(None))
                warning = new IncorrectFilter();
            else
            {
                if (AddOrUpdateTracker() == false)
                    warning = new SameFilter();
                else
                {
                    // if a tracker is added or updated, clears filters in stackpanel, because we don't need them anymore
                    itsMainMenuPage.itsFilterController.ClearFilters();
                    itsMainMenuPage.itsChosenFolder = string.Empty; // clear file path in FolderBrowserDialog
                    warning = new None();
                }
            }
            
            if (warning is not None)
                WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock, warning);
        }
        protected abstract bool AddOrUpdateTracker();
    }
}