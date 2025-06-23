using System.Security.Cryptography;
using System.Text;

namespace MinhaPrimeiraApi.Infrastructure;

public class Criptografia
{
    
    public static string Criptografar(string textoClaro)
    {
        var salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }; // Should be random
        var rfc = new Rfc2898DeriveBytes(textoClaro, salt, 10000);
        byte[] key = rfc.GetBytes(32); // 256-bit AES key
        return BitConverter.ToString(key).Replace("-", "").ToLower();
    }
}

