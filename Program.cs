using System;
using System.Linq;
using System.Transactions;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

            Console.WriteLine("Type your message to encrypt:");

            char[] secretMessage = Console.ReadLine().ToLower().ToCharArray();

            char[] encryptedMessage = new char[secretMessage.Length]; 

            for (int i = 0; i < secretMessage.Length; i++) 
            {
                char currentChar = secretMessage[i];
                char encryptedChar;
                if (alphabet.Contains(currentChar)) 
                {
                    int currentCharAlphaIndex = Array.IndexOf(alphabet, currentChar);
                    int newAlphaIndex = currentCharAlphaIndex + 3;
                    int alphaIndex = newAlphaIndex < alphabet.Length ? newAlphaIndex : newAlphaIndex - alphabet.Length;
                    encryptedChar = alphabet[alphaIndex];
                }
                else
                {
                    encryptedChar = currentChar;
                }
                
                encryptedMessage[i] = encryptedChar;
            }

            string encryptedMessageString = String.Join("", encryptedMessage);
            Console.WriteLine(encryptedMessageString);
        }
    }
}
