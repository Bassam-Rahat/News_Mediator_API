using News_Mediator_API.FilteringSorting;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using System.Web.Http.Filters;

namespace News_Mediator_API.Repository
{
    public class NewsRepository : INewsRepository
    {
        PaginationResult _paginationResult = new PaginationResult();
        Filtering _filtering = new Filtering();
        Sorting<News> _sorting = new Sorting<News>();

        private readonly NewsApiContext _context;
        public NewsRepository(NewsApiContext context)
        {
            _context = context;
        }

        public string Add(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
            return ("News added successfully!");
        }

        public string Delete(int id)
        {
            var _News = _context.News.FirstOrDefault(x => x.Id == id);
            var _Bookmark = _context.BookMarks.FirstOrDefault(x => x.NewsId == id);

            if (_News == null)
            {
                return null;
            }

            _context.News.Remove(_News);
            _context.BookMarks.RemoveRange(_Bookmark);

            _context.SaveChanges();
            return "News Deleted Successfully";
        }

        public PaginationDTO<News> Get(int page, float pageSize)
        {
            var query = _context.News.AsQueryable();
            var result = _paginationResult.GetPagination(page,pageSize, query);
            _context.SaveChanges();
            return result;
        }

        public News? GetById(int id)
        {
            var _News = _context.News.FirstOrDefault(x => x.Id == id);

            if (_News == null)
            {
                return null;
            }
            _context.SaveChanges();
            return _News;
        }

        public News? Update(int id, News updateRequest)
        {
            var _News = _context.News.FirstOrDefault(x => x.Id == id);

            if (_News == null)
            {
                return null;
            }

            _News.Title = updateRequest.Title;
            _News.Aurthor = updateRequest.Aurthor;
            _News.Content = updateRequest.Content;

            _context.SaveChanges();
            return _News;
        }

        public List<News> GetAll()
        {
            _context.SaveChanges();
            return _context.News.ToList();
        }

        public PaginationDTO<News> GetFilterAndSorting(FilterData data)
        {
            var query = _context.News.AsQueryable();
            var filter = _filtering.Filter<News>(data.columnName, data.find, query);
            var sort = _sorting.Sort(data.sortOrder, data.columnName, filter.AsQueryable());
            var result = _paginationResult.GetPagination(data.page,data.pageSize, sort.AsQueryable());
            _context.SaveChanges();
            return result;
        }
    }
}

