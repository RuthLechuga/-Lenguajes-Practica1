using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TablaSimbolos : Form
    {
        List<Token> tokens;
       
        public TablaSimbolos(List<Token> ListaTokens)
        {
            InitializeComponent();
            tokens = ListaTokens;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("token", tokens));

            reportViewer1.RefreshReport();

        }
    }
}
