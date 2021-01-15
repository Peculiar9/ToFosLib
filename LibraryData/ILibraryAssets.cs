using LibraryData.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryData
{
    public interface ILibraryAssets
    {
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset GetById(int id);


        void Add(LibraryAsset newAsset);
        string GetAuthorOrDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);


        LibraryBranch GetCurrentLocation(int Id);
    }    
}
