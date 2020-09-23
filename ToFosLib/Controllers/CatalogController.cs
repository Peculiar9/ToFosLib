using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using ToFosLib.Models.Catalog;

namespace ToFosLib.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAssets _assets;

        public CatalogController(ILibraryAssets assets)
        {
            _assets = assets;
        }
        public IActionResult Index()
        {

            var assetModels = _assets.GetAll();
            var listingResult = assetModels.Select(result => new AssetIndexListingModel{
                Id = result.Id,
                ImageUrl = result.ImageUrl, 
                AuthorOrDirector = _assets.GetAuthorOrDirector(result.Id),
                DeweyCallNumber = _assets.GetAuthorOrDirector(result.Id),
                Type = _assets.GetType(result.Id),
                Title = result.Title
            });

            var model = new AssetIndexModel
            {
                Assets = listingResult
            };
            return View(model);
        }
    }
}
