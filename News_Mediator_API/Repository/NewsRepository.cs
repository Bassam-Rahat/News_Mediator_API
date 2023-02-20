using News_Mediator_API.Data;
using News_Mediator_API.FilteringSorting;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using System.Web.Http.Filters;

namespace News_Mediator_API.Repository
{
    public class NewsRepository : INewsRepository
    {
        //PaginationResult _paginationResult = new PaginationResult();
        //Filtering Filtering = new Filtering();
        //Sorting<News> _sorting = new Sorting<News>();

        private readonly NewsApiContext _context;
        public NewsRepository(NewsApiContext context)
        {
            _context = context;
        }

        public News Add(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
            return news;
        }

        public string Delete(int id)
        {
            var _News = _context.News.FirstOrDefault(x => x.Id == id);

            if (_News == null)
            {
                return null;
            }
            var _Bookmark = _context.BookMarks.Where(x => x.NewsId == id);
            _context.News.Remove(_News);
            _context.BookMarks.RemoveRange(_Bookmark);

            _context.SaveChanges();
            return "News Deleted Successfully";
        }

        public PaginationDTO<News> Get(int page, float pageSize)
        {
            var query = _context.News.AsQueryable();
            var result = PaginationResult.GetPagination(page,pageSize, query);
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
            _News.Author = updateRequest.Author;
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
            var filter = Filtering.Filter<News>(data.columnName, data.find, query);
            var sort = Sorting<News>.Sort(data.sortOrder, data.columnName, filter);
            var result = PaginationResult.GetPagination(data.page,data.pageSize, sort);
            _context.SaveChanges();
            return result;
        }
    }
}

