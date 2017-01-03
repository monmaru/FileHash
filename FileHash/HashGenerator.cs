using System;
using System.IO;

namespace FileHash
{
    internal class HashGenerator
    {
        internal static string Get(string filePath, Algorithm algorithm)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return Get(stream, algorithm);
            }
        }

        internal static string Get(Stream stream, Algorithm algorithm)
        {
            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);

            using (var hashAlgorithm = algorithm.Create())
            {
                return ConvertHashString(hashAlgorithm.ComputeHash(stream));
            }
        }

        private static string ConvertHashString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).ToLower().Replace("-", string.Empty);
        }
    }
}
