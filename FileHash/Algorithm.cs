// ReSharper disable InconsistentNaming
using System.ComponentModel;
using System.Security.Cryptography;

namespace FileHash
{
    internal enum Algorithm
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512,
        RIPEMD160
    }

    internal static class AlgorithmExtensions
    {
        internal static HashAlgorithm Create(this Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.MD5:
                    return new MD5CryptoServiceProvider();
                case Algorithm.SHA1:
                    return new SHA1CryptoServiceProvider();
                case Algorithm.SHA256:
                    return new SHA256CryptoServiceProvider();
                case Algorithm.SHA384:
                    return new SHA384CryptoServiceProvider();
                case Algorithm.SHA512:
                    return new SHA512CryptoServiceProvider();
                case Algorithm.RIPEMD160:
                    return new RIPEMD160Managed();
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
