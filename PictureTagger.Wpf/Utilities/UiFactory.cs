using PictureTagger.Viewmodels;
using PictureTagger.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureTagger.Utilities
{
    /// <summary>
    /// Creates all instances of views and viewmodels
    /// </summary>
    public static class UiFactory
    {

        #region "ViewModels"
        private static SearchTagViewModel SearchTagViewModel;
        public static SearchTagViewModel SearchTagViewModelGet()
        {
            if (SearchTagViewModel == null)
            {
                SearchTagViewModel = new SearchTagViewModel();
            }
            return SearchTagViewModel;
        }
        #endregion

        #region "Views"
        private static SearchTagView SearchTagView;
        public static SearchTagView SearchTagViewGet()
        {
            if (SearchTagView == null)
            {
                SearchTagView = new SearchTagView();
            }
            return SearchTagView;
        }
        #endregion

    }
}
