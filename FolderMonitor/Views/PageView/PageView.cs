using FolderMonitor.Controllers.PageController;

namespace FolderMonitor.Views.PageView
{
    public class PageView
    {
        private PageController itsAboutPageController;

        public PageView(PageController aboutPageController) { itsAboutPageController = aboutPageController; }

        public string ShowPageByArrowState(ArrowState arrowState)
        {
            return itsAboutPageController.GetPageByArrowState(arrowState);
        }
        public string ShowPageByNumber(int number)
        {
            return itsAboutPageController.GetPageByNumber(number);
        }
    }
}