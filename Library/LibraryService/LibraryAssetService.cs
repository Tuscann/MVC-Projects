using System.Collections.Generic;
using LibraryData.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryData;

namespace LibraryService
{
    public class LibraryAssetService : ILibraryAsset
    {
        public LibraryContext _context;

        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                 .Include(asset => asset.Status)
                 .Include(asset => asset.Location);
        }

        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets
                 .Include(asset => asset.Status)
                 .Include(asset => asset.Location)
                 .FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return _context.LibraryAssets
                  .Include(asset => asset.Status)
                  .Include(asset => asset.Location)
                  .FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.
                    FirstOrDefault(book => book.Id == id)
                    .DeweyIndex;
            }
            else return "";
        }

        public string GetIsbn(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.
                    FirstOrDefault(book => book.Id == id)
                    .ISBN;
            }
            else return "";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            IQueryable<Book> book = _context.LibraryAssets.OfType<Book>().Where(b => b.Id == id);

            return book.Any() ? "Book" : "Video";
        }

        public string GetAuthorOrDirector(int id)
        {
            bool isBook = _context.LibraryAssets.OfType<Book>().Where(asset => asset.Id == id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author :
                _context.Videos.FirstOrDefault(video => video.Id == id).Director
                ?? "Unkwown";
        }       
    }
}