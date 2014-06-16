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
            if (Lookahead.TokenType == Token.SELECT)
            {
            }
            else if (Lookahead.TokenType == Token.INSERT)
            {
            }
            else if (Lookahead.TokenType == Token.CREATE)
            {
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
    }
}
