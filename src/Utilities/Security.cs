using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PatchSentry.Utilities; 

internal static class Security {
    const string PasswordSymbols   = "!@#$%^&*()_+{}|:<>?~`-=[]\\\";',./";
    const string PasswordNumbers   = "0123456789";
    const string PasswordUppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string PasswordLowercase = "abcdefghijklmnopqrstuvwxyz";
    const string PasswordAll       = PasswordSymbols + PasswordNumbers + PasswordUppercase + PasswordLowercase;

    public static byte[] SecureRandomBytes(int length) {
        var bytes = new byte[length];

        using var csprng = System.Security.Cryptography.RandomNumberGenerator.Create();
        csprng.GetBytes(bytes, 0, length);

        return bytes;
    }

    public static byte SecureRandomByte() => SecureRandomBytes(1)[0];

    public static int SecureRandomRange(byte min, byte max) => SecureRandomByte() % (max - min) + min;

    public static string Generate() {
        // A secure password is 14 or more characters long,
        // contains at least one uppercase letter, one lowercase letter, one number, and one special character.

        // Create the password buffer
        var pwLength = SecureRandomRange(14, 20);
        var pwBuilder = new StringBuilder();

        // Calculate the amount of each character type
        var numSymbols   = SecureRandomRange(1, 4); // At least one of each type
        var numNumbers   = SecureRandomRange(1, 4);
        var numUpperCase = SecureRandomRange(1, 4);
        var numLowerCase = SecureRandomRange(1, 4);
        var numRest = pwLength - numSymbols - numNumbers - numUpperCase - numLowerCase;

        // Auxiliary function to push random chars to the buffer
        void PushRandom(string refStr, int length) {
            for (var i = 0; i < length; i++)
                pwBuilder.Append(refStr[SecureRandomByte() % refStr.Length]);
        }

        // Push characters to password buffer
        PushRandom(PasswordSymbols, numSymbols);
        PushRandom(PasswordNumbers, numNumbers);
        PushRandom(PasswordUppercase, numUpperCase);
        PushRandom(PasswordLowercase, numLowerCase);
        PushRandom(PasswordAll, numRest);

        // Shuffle password using fisher-yates
        var pwChars = pwBuilder.ToString().ToCharArray();
        for (var i = pwLength - 1; i > 0; i--) {
            var j = SecureRandomRange(0, (byte)(i + 1));
            (pwChars[i], pwChars[j]) = (pwChars[j], pwChars[i]);
        }

        return new(pwChars);
    }
}