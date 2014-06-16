using System;

namespace ISC349.PracticaI.Core.Tokenizer
{
    public class Token
    {
        public static int TERMINAL { get { return -1; } }
        public static int EQUAL { get { return 1; } }
        public static int OPEN_BRACKET { get { return 2; }}
        public static int CLOSE_BRACKET { get { return 3; } }

        public static int STRING { get { return 4; } }
        public static int SELECT { get { return 5; } }
        public static int FROM { get { return 6; } }
        public static int CREATE { get { return 7; } }
        public static int WHERE { get { return 8; } }
        public static int TABLE { get { return 9; } }
        public static int INSERT { get { return 10; } }
        public static int INTO { get { return 11; } }
        public static int VALUES { get { return 12; } }
        public static int VARIABLE { get { return 13; } }


        public int TokenType { get; private set; }
        public String Sequence{ get; private set; }

        public Token(int token, String sequence){

            this.TokenType = token;
            this.Sequence = sequence;
        }
    }
}
