using LibraryData;
using LibraryData.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAssets
    {
        private readonly LibraryContext _context;

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
            return _context.LibraryAssets;
            //return await _context.LibraryAssets;
        }

        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets.Include(assets => assets.Status).Include(assets => assets.Location)
                  .FirstOrDefault(assets => assets.Id == id);
        }
        public LibraryBranch GetCurrentLocation(int Id)
        {
            return
            GetById(Id).Location;
        }


        /// <summary>
        /// This returns the dewey Index of an asset of type book if it matches the Id that is passed to this method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(books => books.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(books => books.Id == id)
                    .DeweyIndex;
            }

            else
            {
                return "";
            }
        }

        public string GetIsbn(int id)
        {
            if (_context.Books.Any(a => a.Id == id))
            {
                return _context.Books
                       .FirstOrDefault(a => a.Id == id).ISBN;
            }

            else
            {
                return "";
            }
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(a => a.Id == id).Title;
        }

        /// <summary>
        /// Method gets type of asset whether it is a book or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetType(int id)
        {
            var book = _context.Books.OfType<Book>().Where(b => b.Id == id);
            return book.Any() ? "Books" : "Videos";
        }

        /// <summary>
        /// Returns the Author of the asset of either video or book if the Id matches the id passed to the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAuthorOrDirector(int id)
        {

            var isBook = _context.LibraryAssets.OfType<Book>()
                 .Where(asset => asset.Id == id).Any();
            var isVideo = _context.LibraryAssets.OfType<Video>()
               .Where(asset => asset.Id == id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(books => books.Id == id).Author :
                _context.Videos.FirstOrDefault(videos => videos.Id == id).Director ?? "Unknown";
        }

    }
}
