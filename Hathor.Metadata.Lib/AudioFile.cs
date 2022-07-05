using Hathor.Common.Models;
using Hathor.Metadata.Lib.Helpers.Mappers;

namespace Hathor.Metadata.Lib
{
    public class AudioFile
    {
        public Track ReadTrack(FileInfo fileInfo) => ReadTrack(fileInfo.FullName);
        
        public Track ReadTrack(string filePath)
        {
            TagLib.File audioFile = TagLib.File.Create(filePath);
            return TagLibCommonMapper.MapTagLibFileToTrack(audioFile);
        }
    }
}