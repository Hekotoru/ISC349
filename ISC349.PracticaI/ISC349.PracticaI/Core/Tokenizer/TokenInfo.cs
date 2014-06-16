using System;

namespace ISC349.PracticaI.Core.Tokenizer
{
  public class TokenInfo {
    public String Regex { get; private set; }
    public int Token { get; private set; }

    public TokenInfo(String regex, int token) {
        this.Regex = regex;
        this.Token = token;
    }
  }
}
