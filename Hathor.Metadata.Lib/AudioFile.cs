using Hathor.Common.Models;
using Hathor.Metadata.Lib.Helpers.Mappers;

namespace Hathor.Metadata.Lib
{
    public class AudioFile
    {
        private readonly string[] supportedFileExtension = new string[] { "mp3" };
        public Track Read(string filePath) => Read(new FileInfo(filePath));
        
        public Track Read(FileInfo fileInfo)
        {
            CheckIfFileExists(fileInfo);
            CheckIfFileTypeIsSupported(fileInfo);
            using (TagLib.File audioFile = TagLib.File.Create(fileInfo.FullName))
            {
                return TagMapper.ToTrack(audioFile);
            }
        }

        public void Write(string filePath, Track track) => Write(new FileInfo(filePath), track);

        public void Write(FileInfo fileInfo, Track track)
        {
            CheckIfFileExists(fileInfo);
            CheckIfFileTypeIsSupported(fileInfo);
            CheckIfFileIsReadOnly(fileInfo);
            using (TagLib.File audioFile = TagLib.File.Create(fileInfo.FullName))
            {
                TagMapper.TrackToFile(audioFile, track);
                audioFile.Save();
            }
        }

        private void CheckIfFileTypeIsSupported(FileInfo fileInfo)
        {
            if (supportedFileExtension.Contains(fileInfo.Extension))
            {
                throw new InvalidOperationException($"Cannot read file {fileInfo.FullName}, the file type with extension {fileInfo.Extension} is not supported. The only supported file type extensions are: {string.Join(", ", supportedFileExtension)}.");
            }
        }

        private void CheckIfFileIsReadOnly(FileInfo fileInfo)
        {
            if (fileInfo.IsReadOnly)
            {
                throw new FileLoadException("Cannot write to file, the is read only.", fileInfo.FullName);
            }
        }

        private void CheckIfFileExists(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException($"Cannot read metadata from a file that does not exist.", fileInfo.FullName);
            }
        }
    }
}