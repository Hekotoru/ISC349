using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ISC349.PracticaI.Core.Tokenizer
{
    public class Tokenizer
    {
        public LinkedList<TokenInfo> TokenInfos { get; private set; }
        public LinkedList<Token> Tokens { get; private set; }

        public Tokenizer()
        {
            TokenInfos = new LinkedList<TokenInfo>();
            Tokens = new LinkedList<Token>();
        }

        public void Add(String regex, int token)
        {
            TokenInfos.AddLast(new TokenInfo("^\\s*(" + regex + ")", token));
        }

        public void Tokenize(String str)
        {
            Tokens.Clear();
            while (!String.IsNullOrEmpty(str.Trim()))
            {
                var match = false;
                foreach (var info in TokenInfos)
                {
                    var regex = new Regex(info.Regex);
                    var matches = regex.Matches(str);
                    if(matches.Count > 0) 
                    {
                        match = true;
                        var tok = matches[matches.Count-1].Value;;
                        Tokens.AddLast(new Token(info.Token, tok.Trim()));
                        str = str.Remove(str.IndexOf(tok), tok.Length );
                        break;
                    }
                }
                if (!match){
                    throw new Exception("Unexpected character in input: " + str);
                }
            }
        }
    }
}
