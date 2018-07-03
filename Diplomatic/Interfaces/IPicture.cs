using System;
namespace Diplomatic.Interfaces
{
    public interface IPicture
    {
        void SavePictureToDisk(string filename, byte[] imageArray);
    }
}
