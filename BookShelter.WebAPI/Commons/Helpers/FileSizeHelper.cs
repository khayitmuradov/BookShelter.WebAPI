namespace BookShelter.WebAPI.Commons.Helpers;

public class FileSizeHelper
{
    public static double ByteToMegabyte(double @byte)
    {
        return @byte / 1024 / 1024;
    }
}
