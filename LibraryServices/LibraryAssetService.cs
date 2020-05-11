using LibraryData;
using LibraryData.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<LibraryAsset>  GetAll() => _context.LibraryAssets.Include(assets => assets.Status)
            .Include(assets => assets.Location);


        public LibraryAsset GetById(int id)
        {
            return _context.LibraryAssets.Include(assets => assets.Status).Include(assets => assets.Location).FirstOrDefault(assets => assets.Id == id);
        }

        public string GetDeweyIndex(int id)
        {
            throw new NotImplementedException();
        }

        public string GetIsbn(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(int id)
        {
            throw new NotImplementedException();
        }

        public string GetType(int id)
        {
            throw new NotImplementedException();
        }

        public void LibraryAsset(LibraryAsset asset)
        {
            throw new NotImplementedException();
        }

        public LibraryBranch Location(int Id)
        {
            throw new NotImplementedException();
        }
        public Func<string> GetAuthorOrDirector(int id)
        {
            throw new NotImplementedException();
        }

        string ILibraryAssets.GetAuthorOrDirector(int id)
        {
            throw new NotImplementedException();
        }
    }
}
