using FolderMonitor.Converters;
using FolderMonitor.Pages;
using FolderMonitor.Validators;
using FolderMonitor.Warnings;
using System.Collections.Generic;

namespace FolderMonitor.Handlers.MainMenu.TemplateMethod
{
    public abstract class AddOrUpdateTrackerTemplateMethod
    {
        protected MainMenuPage itsMainMenuPage;
        protected List<string> itsFilters;

        public MainMenuPage MainMenuPage { set { itsMainMenuPage = value; } }

        public void AddOrUpdate()
        {
            itsFilters = FiltersConverter.ToFiltersStringList(itsMainMenuPage.itsFilterController.FiltersStackPanel);
            if (FiltersValidator.CheckFilters(itsFilters).GetType() == typeof(None))
            {
                if (AddOrUpdateTracker() == false)
                    WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock, new SameFilter());
                else
                {
                    // if a tracker is added or updated, clears filters in stackpanel, because we don't need them anymore
                    itsMainMenuPage.itsFilterController.ClearFilters();
                }
            }
            else
                WarningView.ShowStackPanelWarningByType(itsMainMenuPage.warningStackPanel, itsMainMenuPage.warningTextBlock, new IncorrectFilter());
        }
        protected abstract bool AddOrUpdateTracker();
    }
}