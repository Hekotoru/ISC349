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

        private bool IsTerminal {
            get { return this.Lookahead.TokenType == Token.TERMINAL; }
        }

        private void Expression()
        {
            if (Lookahead.TokenType == Token.CREATE)
            {
                NextToken();
                if (Lookahead.TokenType == Token.TABLE)
                {
                    NextToken();
                    ArgumentsInBrackets();
                    if (!IsTerminal)
                    {
                        Abort(Lookahead.Sequence);
                    }
                }
                else
                {
                    Abort(Lookahead.Sequence);
                }
            }
            else if (Lookahead.TokenType == Token.SELECT)
            {
                NextToken();
                while (Lookahead.TokenType == Token.STRING || Lookahead.TokenType == Token.VARIABLE)
                {
                    Value();
                    if (Lookahead.TokenType != Token.SEPARATOR){
                        if(Lookahead.TokenType == Token.FROM) break;
                        Abort(Lookahead.Sequence);
                    }
                    NextToken();
                }

                if (Lookahead.TokenType == Token.FROM)
                {
                    NextToken();
                    Value();
                    if(Lookahead.TokenType == Token.WHERE)
                    {
                        /// ArgumentoWhere
                        NextToken();
                        ArgumentsWhere();
                    }
                    else if (Lookahead.TokenType == Token.STRING || Lookahead.TokenType == Token.VARIABLE)
                    {
                        Abort(Lookahead.Sequence);
                    }
                    //Expression();
                }   
            }
            else if (Lookahead.TokenType == Token.INSERT)
            {
                NextToken();
                if (Lookahead.TokenType == Token.INTO)
                {
                    NextToken();
                    Value();
                    if (Lookahead.TokenType == Token.VALUES)
                    {
                        NextToken();
                        ArgumentsInBrackets();
                    }
                    else
                    {
                        Abort(Lookahead.Sequence);
                    }
                }
                else
                {
                    Abort(Lookahead.Sequence);
                }
            }
        }

        private void ArgumentsWhere()
        {
            if (Lookahead.TokenType == Token.STRING || Lookahead.TokenType == Token.VARIABLE)
            {
                NextToken();
                if (Lookahead.TokenType == Token.EQUAL)
                {
                    NextToken();
                    Value();
                }
                else
                {
                    Abort(Lookahead.Sequence);
                }
                    
            }
            else
            {
                Abort(Lookahead.Sequence);
            }
            
                
        }

        private void ArgumentsInBrackets()
        {
            if (Lookahead.TokenType == Token.OPEN_BRACKET)
            {
                NextToken();
                if (Lookahead.TokenType != Token.CLOSE_BRACKET)
                {
                    while (Lookahead.TokenType == Token.STRING || Lookahead.TokenType == Token.VARIABLE)
                    {
                        NextToken();
                        if (Lookahead.TokenType != Token.SEPARATOR)
                        {
                            if (Lookahead.TokenType == Token.CLOSE_BRACKET) break;
                            Abort(Lookahead.Sequence);
                        }
                        NextToken();
                        if (!(Lookahead.TokenType == Token.STRING || Lookahead.TokenType == Token.VARIABLE))
                        {
                            Abort(Lookahead.Sequence);
                        }
                    }
                    if (Lookahead.TokenType != Token.CLOSE_BRACKET)
                    {
                        Abort(Lookahead.Sequence, "Closing brackets expected and {0} found instead");
                    }
                }
                Expression();
            }
            else
            {
                Value();
            }
        }
        private void Value()
        {
            if (Lookahead.TokenType == Token.STRING || Lookahead.TokenType == Token.VARIABLE)
            {
                NextToken();
            }
            else
            {
                Abort(Lookahead.Sequence);
            }
        }

        private void NextToken()
        {
            Tokens.RemoveFirst();
            Lookahead = Tokens.Count <= 0 ? new Token(Token.TERMINAL, "") : Tokens.First();
        }

        private void Abort(string sequence, string message="Unexpected symbol '{0}' found")
        {
            throw new Exception( String.Format(message, sequence));
        }
    }
}
