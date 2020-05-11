using LibraryData.EntityModels;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ILibraryAssets
    {
        IEnumerable<LibraryAsset> GetAll();

        LibraryAsset GetById(int id);
        void Add(LibraryAsset newAsset);

        string GetDeweyIndex(int id);
        string GetIsbn(int id);
        string GetAuthorOrDirector(int id);
        string GetTitle(int id);

        string GetType(int id);

        LibraryBranch Location(int Id);
    }    
}
