using System.Collections.Generic;

namespace FolderMonitor.Controllers.PageController
{
    public enum ArrowState { Left, Right }
    public class PageController
    {
        private List<string> itsPages;
        private int itsCurrentPageIndex;

        public int NumberOfPages { get { return itsPages.Count; } }

        public PageController(List<string> pages) { itsPages = pages; itsCurrentPageIndex = 0; }

        // Getting pages
        public string GetPageByArrowState(ArrowState arrowState)
        {
            SetCurrentPage(arrowState);
            return itsPages[itsCurrentPageIndex];
        }
        private void SetCurrentPage(ArrowState arrowState)
        {
            if (arrowState == ArrowState.Left)
            {
                if (itsCurrentPageIndex > 0)
                    itsCurrentPageIndex--;
            }
            else // Right
            {
                if (itsCurrentPageIndex + 1 != itsPages.Count)
                    itsCurrentPageIndex++;
            }
        }
        public string GetPageByNumber(int pageNumber)
        {
            return itsPages[pageNumber - 1];
        }

        public bool PagesExist()
        {
            return itsPages.Count > 0;
        }
    }
}
