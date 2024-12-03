using System;
using System.Runtime.InteropServices;

namespace Obfuscar
{
    internal static class MsNetSigner
    {
        /// <summary>
        /// Generates a strong name signature for the specified assembly.
        /// </summary>
        /// <param name="wzFilePath">The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.</param>
        /// <param name="wzKeyContainer">The name of the key container that contains the public/private key pair.</param>
        /// <param name="pbKeyBlob">
        /// A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function.
        /// If pbKeyBlob is null, the key container specified by wszKeyContainer is assumed to contain the key pair.
        /// </param>
        /// <param name="cbKeyBlob">The size, in bytes, of pbKeyBlob.</param>
        /// <param name="ppbSignatureBlob">
        /// A pointer to the location to which the common language runtime returns the signature.
        /// If ppbSignatureBlob is null, the runtime stores the signature in the file specified by wszFilePath.
        /// </param>
        /// <param name="pcbSignatureBlob">The size, in bytes, of the returned signature.</param>
        /// <returns>true on successful completion; otherwise, false.</returns>
        [DllImport("mscoree.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool StrongNameSignatureGeneration
            ( [MarshalAs(UnmanagedType.LPWStr)]
              string wzFilePath
            , [MarshalAs(UnmanagedType.LPWStr)]
              string? wzKeyContainer
            , byte[]? pbKeyBlob
            , uint cbKeyBlob
            , IntPtr ppbSignatureBlob // not supported, always pass 0.
            , [Out] out uint pcbSignatureBlob
            );

        public static void StrongNameSignAssemblyFromKeyContainer(string assemblyname, string keyname)
        {
            if (!StrongNameSignatureGeneration(assemblyname, keyname, null, 0, IntPtr.Zero, out _))
            {
                throw new ObfuscarException(MessageCodes.dbr017, "Unable to sign assembly using key from key container - " + keyname);
            }
        }
    }
}
