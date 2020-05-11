using LibraryData.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ILibraryAssetsServices
    {
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset GetById(int id);
        void LibraryAsset(LibraryAsset asset);

        string GetDeweyIndex(int id);
        string GetIsbn(int id);
        string GetAuthorOrDirector(int id);
        string GetTitle(int id);
        string GetType(int id);
    }    
}
