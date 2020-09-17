using System;
using System.Linq;
using System.Net.Http;
using System.Transactions;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

            void Encrypt(string message, int key) 
            {

                char[] secretMessage = message.ToLower().ToCharArray();

                char[] encryptedMessage = new char[secretMessage.Length]; 

                for (int i = 0; i < secretMessage.Length; i++) 
                {
                    char currentChar = secretMessage[i];
                    char encryptedChar;
                    if (alphabet.Contains(currentChar)) 
                    {
                        int currentCharAlphaIndex = Array.IndexOf(alphabet, currentChar);
                        int alphaIndex = (currentCharAlphaIndex + key) % alphabet.Length;
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

            Console.WriteLine("Welcome, Team Hackathon member, to the Encryptor!");
            Console.WriteLine("Type 1 to Encrypt, type 2 to Decrypt, press Enter to confirm.");
            int choice = Int32.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Ready to ENCRYPT");
                Console.WriteLine("What's your message?");
                string message = Console.ReadLine();
                Console.WriteLine("Choose your cypher (0 - 25) to encrypt:");
                int cypher = Int32.Parse(Console.ReadLine());
            
                Encrypt(message, cypher);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Ready to DECRYPT");
                Console.WriteLine("What's your message?");
                string message = Console.ReadLine();
                Console.WriteLine("Choose your cypher (0 - 25) to decrypt:");
                int cypher = 26 - Int32.Parse(Console.ReadLine());
                Encrypt(message, cypher);
            
            }
            else
            {
                Console.WriteLine("Sorry, that response is not valid. Rerun the program to try again.");
            }
        }
    }
}
