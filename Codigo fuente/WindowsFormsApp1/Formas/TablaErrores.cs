using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Clases;

namespace WindowsFormsApp1.Formas
{
    public partial class TablaErrores : Form
    {
        List<Errores> errores;

        public TablaErrores(List<Errores> listaErrores)
        {
            InitializeComponent();
            errores = listaErrores; 
        }

        private void TablaErrores_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Errores", errores));

            reportViewer1.RefreshReport();
        }
        
    }
}
