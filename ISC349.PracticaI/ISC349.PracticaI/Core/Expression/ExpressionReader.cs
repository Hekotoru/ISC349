using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISC349.PracticaI.Core.Functions;
using ISC349.PracticaI.Core.Tokenizer;

namespace ISC349.PracticaI.Core.Expression
{
    public class ExpressionReader
    {
        private readonly IHandleDBMSFunctions dbmpsFunctionsHandler;

        public ExpressionReader(IHandleDBMSFunctions dbmpsFunctionsHandler)
        {
            this.dbmpsFunctionsHandler = dbmpsFunctionsHandler;
        }

        public void Read(LinkedList<Token> tokens)
        {
            if (tokens.First.Value.TokenType == Token.CREATE)
            {
                tokens.RemoveFirst(); 
                tokens.RemoveFirst();
                var tablename = tokens.First.Value.Sequence;
                tokens.RemoveFirst();
                var fields = new List<string>();
                if (tokens.First.Value.TokenType == Token.OPEN_BRACKET)
                {
                    tokens.RemoveFirst();
                    while (tokens.First.Value.TokenType == Token.VARIABLE ||
                           tokens.First.Value.TokenType == Token.STRING)
                    {
                        fields.Add(tokens.First.Value.Sequence);
                        tokens.RemoveFirst();
                        if (tokens.First.Value.TokenType == Token.SEPARATOR)
                        {
                            tokens.RemoveFirst();
                        }
                    }
                }
                dbmpsFunctionsHandler.CreateTable(tablename, fields.ToArray());
                return;
            }
            if (tokens.First.Value.TokenType == Token.INSERT)
            {
                tokens.RemoveFirst();
                tokens.RemoveFirst();
                var tablename = tokens.First.Value.Sequence;
                tokens.RemoveFirst();
                tokens.RemoveFirst();

                var fields = new List<string>();
                if (tokens.First.Value.TokenType == Token.OPEN_BRACKET)
                {
                    tokens.RemoveFirst();
                    while (tokens.First.Value.TokenType == Token.VARIABLE ||
                           tokens.First.Value.TokenType == Token.STRING)
                    {
                        fields.Add(tokens.First.Value.Sequence);
                        tokens.RemoveFirst();
                        if (tokens.First.Value.TokenType == Token.SEPARATOR)
                        {
                            tokens.RemoveFirst();
                        }
                    }
                }
                dbmpsFunctionsHandler.Insert(tablename, fields.ToArray());
            }
        }
    }
}
