using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class Automata
    {
       string _textoIma;
       int _edoAct;
       char SigCar(ref int i)
       {
        if (i == _textoIma.Length)
        {
            i++;
            return '\0';
        }
        else
        return _textoIma[i++];
       }
    public bool Reconoce(string texto,int iniToken,ref int i,int noAuto)
    {
        char c;
        _textoIma = texto;
        string lenguaje;
        switch (noAuto)
        {
            //-------------- Automata delim--------------
            case 0 : _edoAct = 0;
            break;
            //-------------- Automata Id--------------
            case 1 : _edoAct = 3;
            break;
            //-------------- Automata real--------------
            case 2 : _edoAct = 6;
            break;
            //-------------- Automata entero--------------
            case 3 : _edoAct = 11;
            break;
            //-------------- Automata cad--------------
            case 4 : _edoAct = 14;
                break;
            //-------------- Automata otros--------------
            case 5 : _edoAct = 17;
            break;
        }
        while(i<=_textoIma.Length)
            switch (_edoAct)
            {
              //-------------- Automata delim--------------
                case 0 : c=SigCar(ref i);
                if ((lenguaje=" \n\r\t").IndexOf(c)>=0) _edoAct=1; 
                else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 1 : c=SigCar(ref i);
                if ((lenguaje=" \n\r\t").IndexOf(c)>=0) _edoAct=1; 
                else
                if ((lenguaje="!\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ı€ı‚ƒ„…†‡ˆ‰Š‹OEıŽıı‘’“”•–—˜™š›oeıžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\f").IndexOf(c)>=0) _edoAct=2;
                else
                { 
                    i=iniToken;
                    return false;   
                }
                break;
                case 2 : i--;
                return true;
                break;
                //-------------- Automata Id--------------
                case 3 : c=SigCar(ref i);
                if ((lenguaje="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c)>=0)_edoAct=4; 
                else
                { 
                    i=iniToken;
                    return false;   
                }
                break;
                case 4 : c=SigCar(ref i);
                if ((lenguaje="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c)>=0)_edoAct=4; 
                else
                if ((lenguaje="0123456789").IndexOf(c)>=0) _edoAct=4; 
                else
                if ((lenguaje="_").IndexOf(c)>=0) _edoAct=4; 
                else
                if ((lenguaje=" !\"#$%&\'()*+,-./:;<=>?@[\\]^`{|}~ı€ı‚ƒ„…†‡ˆ‰Š‹OEıŽıı‘’“”•–—˜™š›oeıžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) _edoAct=5; 
                else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 5 : i--;
                return true;
                break;
                //-------------- Automata real--------------
                case 6 : c=SigCar(ref i);
                if ((lenguaje="0123456789").IndexOf(c)>=0) _edoAct=7; 
                else
                if ((lenguaje=".").IndexOf(c)>=0) _edoAct=8;
                else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 7 : c=SigCar(ref i);
                if ((lenguaje="0123456789").IndexOf(c)>=0) _edoAct=7; 
                else
                if ((lenguaje=".").IndexOf(c)>=0) _edoAct=9;
                else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 8 : c=SigCar(ref i);
                if ((lenguaje="0123456789").IndexOf(c)>=0) _edoAct=9; 
                else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 9 : c=SigCar(ref i);
                if ((lenguaje="0123456789").IndexOf(c)>=0) _edoAct=9; else
                if ((lenguaje=".").IndexOf(c)>=0) _edoAct=10; else
                if ((lenguaje=" !\"#$%&\'()*+,-/:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ı€ı‚ƒ„…†‡ˆ‰Š‹OEıŽıı‘’“”•–—˜™š›oeıžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) _edoAct=10; 
                else
                {               
                    i=iniToken;
                    return false; 
                }
                break;
                case 10 : i--;
                return true;
                    break;
                //-------------- Automata entero--------------
                case 11 : c=SigCar(ref i);
                if ((lenguaje="0123456789").IndexOf(c)>=0) _edoAct=12; else
                {
                    i=iniToken;
                    return false; 
                }
                break;
                case 12 : c=SigCar(ref i);
                if ((lenguaje="0123456789").IndexOf(c)>=0) _edoAct=12;
                else
                if ((lenguaje=" !\"#$%&\'()*+,-./:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ı€ı‚ƒ„…†‡ˆ‰Š‹OEıŽıı‘’“”•–—˜™š›oeıžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) _edoAct=13;
                else
                { 
                    i=iniToken;
                    return false;
                }
                break;
                case 13 : i--;
                return true;
                break;
                //-------------- Automata cad--------------
                case 14 : c=SigCar(ref i);
                if ((lenguaje="\"").IndexOf(c)>=0) _edoAct=15;
                else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 15 : c=SigCar(ref i);
                if ((lenguaje="\"").IndexOf(c)>=0) _edoAct=16; else
                if ((lenguaje=" !#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ı€ı‚ƒ„…†‡ˆ‰Š‹OEıŽıı‘’“”•–—˜™š›oeıžŸ ¡¢£¤¥¦§¨©ª«¬-®¯°±²³´μ¶·¸¹º»¼½¾¿\n\t\r\f").IndexOf(c)>=0) _edoAct=15;
                else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 16 : return true;
                break;
                //-------------- Automata otros--------------
                case 17 : c=SigCar(ref i);
                if ((lenguaje="=").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje=";").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje=",").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje="+").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje="-").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje="*").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje="/").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje="(").IndexOf(c)>=0) _edoAct=18; else
                if ((lenguaje=")").IndexOf(c)>=0) _edoAct=18; else
                { 
                    i=iniToken;
                    return false; 
                }
                break;
                case 18 : return true;
                break;
                }
                switch (_edoAct)
                {
                    case 2 : // Autómata delim
                    case 5 : // Autómata Id
                    case 10 : // Autómata real
                    case 13 : // Autómata entero
                    --i;
                    return true;
                }
        return false;
        }
    } // fin de la clase Automata
}
