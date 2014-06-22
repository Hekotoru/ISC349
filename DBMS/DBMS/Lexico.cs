using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class Lexico
    {
        const int TOKREC = 6;
        const int MAXTOKENS = 500;
        string[] _lexemas;
        string[] _tokens;
        string _lexema;
        int _noTokens;
        int _i;
        int _iniToken;
        Automata oAFD;

        public Lexico() // constructor por defecto
        {
            _lexemas = new string[MAXTOKENS];
            _tokens = new string[MAXTOKENS];
            oAFD = new Automata();
            _i = 0;
            _iniToken = 0;
            _noTokens = 0;
        }
        public void Inicia()
        {
            _i = 0;
            _iniToken = 0;
            _noTokens = 0;
        }
        public void Analiza(string texto)
        {
            bool recAuto;
            int noAuto;
            while (_i < texto.Length)
            {
                recAuto = false;
                noAuto = 0;
                for (; noAuto < TOKREC && !recAuto; )
                    if (oAFD.Reconoce(texto, _iniToken, ref _i, noAuto))
                        recAuto = true;
                    else
                        noAuto++;
                if (recAuto)
                {
                    _lexema = texto.Substring(_iniToken, _i - _iniToken);
                    switch (noAuto)
                    {
                        //-------------- Automata delim--------------
                        case 0:// _tokens[_noTokens] = "delim";
                            break;
                        //-------------- Automata Id--------------
                        case 1: if (EsId())
                                _tokens[_noTokens] = "id";
                            else
                                _tokens[_noTokens] = _lexema;
                            break;
                        //-------------- Automata real--------------
                        case 2: _tokens[_noTokens] = "real";
                            break;
                        //-------------- Automata entero--------------
                        case 3: _tokens[_noTokens] = "num";
                            break;
                        //-------------- Automata cad--------------
                        case 4: _tokens[_noTokens] = "cad";
                            break;
                        //-------------- Automata otros--------------
                        case 5: _tokens[_noTokens] = _lexema;
                            break;
                    }
                    if (noAuto != 0)
                        _lexemas[_noTokens++] = _lexema;
                }
                else
                    _i++;
                _iniToken = _i;
            }
        }
        private bool EsId()
        {
            string[] palres = { "SELECT", "FROM", "WHERE", "TABLE", "INSERT", "INTO", "VALUES", "CREATE"};
            for (int i = 0; i < palres.Length; i++)
                if (_lexema.Equals(palres[i]))
                    return false;
            return true;
        }
        public int NoTokens
        {
            get { return _noTokens; }
        }
        public string[] Lexema
        {
            get { return _lexemas; }
        }
        public string[] Token
        {
            get { return _tokens; }
        }
    }
}
