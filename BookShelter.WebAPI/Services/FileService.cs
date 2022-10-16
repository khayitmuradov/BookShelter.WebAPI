using BookShelter.WebAPI.Commons.Helpers;
using BookShelter.WebAPI.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;

namespace BookShelter.WebAPI.Services;

public class FileService : IFileService
{
    private readonly string _basePath = string.Empty;
    private const string _imageFolderName = "images";
    public FileService(IWebHostEnvironment env)
    {
        _basePath = env.WebRootPath;
    }

    public async Task<string> SaveImageAsync(IFormFile image)
    {
        string fileName = ImageHelper.MakeImageName(image.FileName);
        string partPath = Path.Combine(_imageFolderName, fileName);
        string path = Path.Combine(_basePath, partPath);
        await image.CopyToAsync(new FileStream(path, FileMode.Create));

        return partPath;
    }
}
