using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class Form1 : Form
    {
        Lexico oAnaLex = new Lexico();
        Parser Validacion = new Parser();
       /// SintAscSLR oAnaSintAscSLR = new SintAscSLR();
        string test;
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonAnalisis_Click(object sender, EventArgs e)
        {
            oAnaLex.Inicia();
            oAnaLex.Analiza(txtInput.Text);
            dataGridView1.Rows.Clear();
            if (oAnaLex.NoTokens >= 0)
                dataGridView1.Rows.Add(oAnaLex.NoTokens);
            for (int i = 0; i < oAnaLex.NoTokens; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = oAnaLex.Token[i];
                dataGridView1.Rows[i].Cells[1].Value = oAnaLex.Lexema[i];
                test = test +" "+ oAnaLex.Lexema[i]; 
            }
            MessageBox.Show(test);
            Validacion.Expresion(test);
          ///  oAnaSintAscSLR.Inicia();
          /*  if (oAnaSintAscSLR.Analiza(oAnaLex) == 0)
                label2.Text = "ANALISIS SINTACTICO EXITOSO";
            else
                label2.Text = "ERROR DE SINTAXIS";*/
        }
    }
}
