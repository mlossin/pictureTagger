using PictureTagger.Common.Models;
using PictureTagger.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PictureTagger.Viewmodels
{
    public class SearchTagViewModel : ViewmodelBase
    {


        private ICollection<SearchTag> _searchTagsFiltered;
        public ICollection<SearchTag> SearchTagsFiltered { get => _searchTagsFiltered; set => SetField(ref _searchTagsFiltered, value); }

        private SearchTag _selectedSearchTag;
        public SearchTag SelectedSearchTag { get => _selectedSearchTag; set => SetField(ref _selectedSearchTag, value); }

        private string _filter;
        public string Filter { get => _filter;
            set { SetField(ref _filter, value);
                FilterAnwenden(null);
            } }

        public IEnumerable<SearchTag> AllTags;


        public void Refresh(Object o)
        {
            AllTags = PictureTagger.DataAccess.Sqlite.DataAccess.TagGet();
            FilterAnwenden(null);
        }

        private void FilterAnwenden(Object o)
        {
            if (!String.IsNullOrWhiteSpace(Filter))
            {
                SearchTagsFiltered.Clear();
                AllTags.Where(x => x.Name.ToLower().ToString().Contains(Filter)).ToList().ForEach(y => SearchTagsFiltered.Add(y));
            }
            else
            {
                SearchTagsFiltered.Clear();
                AllTags.ToList().ForEach(x => SearchTagsFiltered.Add(x));
            }
        }

        public ICommand cmdFilter { get; set; }
        public ICommand cmdRefresh { get; set; }

        public bool AlwaysCanDo(Object o)
        {
            return true;
        }

        public SearchTagViewModel()
        {
            SearchTagsFiltered = new ObservableCollection<SearchTag>();
            cmdRefresh = new DelegateCommand(Refresh, AlwaysCanDo);
            cmdFilter = new DelegateCommand(FilterAnwenden,AlwaysCanDo);
        }
    }
}
