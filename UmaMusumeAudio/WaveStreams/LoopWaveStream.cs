using NAudio.Wave;

namespace UmaMusumeAudio.WaveStreams
{
    public class LoopWaveStream : WaveStream
    {
        private readonly WaveStream sourceStream;

        private readonly long startPosition;
        private readonly long endPosition;

        public LoopWaveStream(WaveStream waveStream, long start, long end)
        {
            sourceStream = waveStream;

            // Convert samples to bytes
            startPosition = start * WaveFormat.BlockAlign;
            endPosition = end * WaveFormat.BlockAlign;

            if (startPosition < 0) startPosition = 0;
            if (endPosition <= 0) endPosition = Length;
        }

        public bool Loop { get; set; } = false;

        public long StartSample => startPosition / WaveFormat.BlockAlign;

        public long EndSample => endPosition / WaveFormat.BlockAlign;

        public override WaveFormat WaveFormat => sourceStream.WaveFormat;

        public override long Length => sourceStream.Length;

        public override long Position { get => sourceStream.Position; set => sourceStream.Position = value; }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;
            int advanced = (int)(sourceStream.Position + count); // Get read-ahead position

            // Keep on reading until the appropriate byte count has been read
            while (totalBytesRead < count)
            {
                // Check if next position passes over the end position
                if (advanced > endPosition && Loop)
                {
                    // Edge case
                    if (endPosition > startPosition)
                    {
                        // Get remaining bytes between the current position and the loop end
                        int byteDifference = (int)(endPosition - sourceStream.Position);

                        // Read the remaining bytes into the buffer
                        if (byteDifference > 0) totalBytesRead += sourceStream.Read(buffer, offset, byteDifference);

                        // Set position back to the beginning
                        sourceStream.Position = startPosition;
                    }
                }

                // Read and account for read bytes that is less than expected
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);

                // No bytes read means we reached end of stream
                if (bytesRead == 0)
                {
                    // Reset stream to start position
                    if (Loop) { sourceStream.Position = startPosition; }
                    else break;
                }

                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }
    }
}