using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISC349.PracticaI.Core.Tokenizer;

namespace ISC349.PracticaI.Core.Parser
{
    public class QueryParser
    {
        public LinkedList<Token> Tokens { get; private set; }
        private Token Lookahead { get; set; }

        public void Parse(List<Token> tokens)
        {
            Tokens = new LinkedList<Token>(tokens);
            Lookahead = this.Tokens.First();
            Expression();
        }

        private void Expression()
        {
            //TODO:Terminar Implementacion

            if (Lookahead.TokenType == Token.CREATE)
            {
                NextToken();
                Expression();
            }
            else if (Lookahead.TokenType == Token.SELECT)
            {
                NextToken();
                Expression();
            }
            else if (Lookahead.TokenType == Token.TABLE)
            {
                argument();
                NextToken();
                Expression();
                
            }
            else if (Lookahead.TokenType == Token.INSERT)
            {
                NextToken();
                Expression();
            }
            else if (Lookahead.TokenType == Token.INTO)
            {
                NextToken();
                Expression();
            }
            else if (Lookahead.TokenType == Token.VALUES)
            {
                argument();
                NextToken();
                Expression();
            }
            else if (Lookahead.TokenType == Token.FROM)
            {
                NextToken();
                Expression();
            }
                
        }

        private void NextToken()
        {
            Tokens.RemoveFirst();
            if (Tokens.Count <= 0)
                Lookahead = new Token(Token.TERMINAL, "");
            else
                Lookahead = Tokens.First();
        }

        private void argument()
        {
           
            if (Lookahead.TokenType == Token.OPEN_BRACKET)
            {
                // argument -> OPEN_BRACKET sum CLOSE_BRACKET
                NextToken();
                Expression();

                if (Lookahead.TokenType != Token.CLOSE_BRACKET)
                    throw new Exception("Closing brackets expected and "
                      + Lookahead.Sequence + " found instead");

                NextToken();
            }
            else
            {
                // argument -> value
                value();
            }
        }
        private void value()
        {
            
            if (Lookahead.TokenType == Token.STRING)
            {
                // argument -> VARIABLE
                NextToken();
            }
            else
            {
                throw new Exception(
                  "Unexpected symbol " + Lookahead.Sequence + " found");
            }
        }
    }
}
