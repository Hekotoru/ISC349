using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://wiki.engr.illinois.edu/download/attachments/218399498/lecture20.pdf?version=2&modificationDate=1365020389000
using ISC349.PracticaI.Core.Tokenizer;

namespace ISC349.PracticaI
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenizer = new Tokenizer();
            tokenizer.Add("=", 1); // equivalencia
            tokenizer.Add(@"\(", 2); // open bracket
            tokenizer.Add(@"\)", 3); // close bracket
            tokenizer.Add(@"'[^'\\]*(?:\\.[^'\\]*)*'", 4); 
            tokenizer.Add(@"SELECT", 5);
            tokenizer.Add(@"FROM", 6);
            tokenizer.Add(@"CREATE", 7);
            tokenizer.Add(@"WHERE", 8); 
            tokenizer.Add(@"TABLE", 9);
            tokenizer.Add(@"INSERT", 10);
            tokenizer.Add(@"INTO", 11);
            tokenizer.Add(@"VALUES", 12);
            tokenizer.Add(@"[a-zA-Z][a-zA-Z0-9_]*", 13); // variable
            tokenizer.Add(@"\*", 13);
            tokenizer.Add(@",", 14); 


            try
            {
                tokenizer.Tokenize(" CREATE TABLE example ");
                foreach(var tok in tokenizer.Tokens) {
                    Console.WriteLine(tok.TokenType + " " + tok.Sequence);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            try
            {
                tokenizer.Tokenize(" SELECT * FROM table WHERE a='SELECT * FROM table ' ");
                foreach(var tok in tokenizer.Tokens) {
                    Console.WriteLine(tok.TokenType + " " + tok.Sequence);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                tokenizer.Tokenize(" INSERT INTO table VALUES ('valor1df klng klnms gkns dg', 'efgion inwd inwdfp nvalor2')");
                foreach (var tok in tokenizer.Tokens)
                {
                    Console.WriteLine(tok.TokenType + " " + tok.Sequence);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
