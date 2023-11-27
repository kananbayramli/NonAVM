namespace ECommerse.WebUI.Services;

public class PhotoHandlerService
{
    public async Task<string?> SavePhotoAsync(IFormFile? photo)
    {
        string? name = $"{Guid.NewGuid()}{Path.GetExtension(photo?.FileName)}";
        string? path = string.Empty;
        if (photo is not null && photo.Length > 0)
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", name);
            using var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream);
        }
        return name;
    }

    public bool DeletePhoto(string photoUrl)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
        if (File.Exists(path) is false)
        {
            return false;
        }
        File.Delete(path);
        return true;
    }
}
