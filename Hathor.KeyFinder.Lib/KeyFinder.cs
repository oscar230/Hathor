using libKeyFinder.NET;

namespace Hathor.KeyFinder.Lib
{
    public class KeyFinder : IDisposable
    {
        private readonly KeyDetector _keyDetector;

        public KeyFinder(int frameRate, int channels, int frameLength)
        {
            _keyDetector = new KeyDetector(frameRate, channels, frameLength);
        }

        public void Dispose()
        {
            _keyDetector.Dispose();
        }
    }
}