//https://goo.gl/TT3Csr
//http://csharp.net-informations.com/excel/csharp-excel-chart.htm
//https://stackoverflow.com/questions/40579489/
//https://stackoverflow.com/questions/12492434/
//https://stackoverflow.com/questions/15638830/
//how-to-label-excel-x-and-y-axes-in-2d-graph
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace PrintExcel
{
  public partial class Form1 : Form
  {
    double[] x = new double[] { 1, 2.1, 3, 4, 5, 6, 7, 8, 9, 10 };
    double[] y = new double[] { 10, 21, 30, 42, 53, 64, 70, 81, 90, 102 };
    string path = Directory.GetCurrentDirectory();
    public Form1()
    {
      InitializeComponent();
      
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Excel.Application xlApp;
      Excel.Workbook xlWorkBook;
      Excel.Worksheet xlWorkSheet;
      xlApp = new Excel.Application();
      object misValue = System.Reflection.Missing.Value;
      xlWorkBook = xlApp.Workbooks.Add(misValue);
      xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
      for (int i = 0; i < 10; i++)
      {
        xlWorkSheet.Cells[i + 2, 1] = x[i];
        xlWorkSheet.Cells[i + 2, 2] = y[i];
      }

      Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.
        ChartObjects(Type.Missing);

      Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(100, 100, 300, 250);
      Excel.Chart chartPage = myChart.Chart;

      Excel.Range yRange;
      Excel.Range xRange;
      yRange = xlWorkSheet.get_Range("B2:B11");
      xRange = xlWorkSheet.get_Range("A2:A11");
      chartPage.SetSourceData(yRange, Excel.XlRowCol.xlColumns);
      chartPage.SeriesCollection(1).XValues = xRange;
      chartPage.SeriesCollection(1).Name = "y1-var";
      chartPage.ChartType = Excel.XlChartType.xlXYScatter;

      Excel.Axis xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.
        xlCategory, Excel.XlAxisGroup.xlPrimary);
      Excel.Axis yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.
        xlValue, Excel.XlAxisGroup.xlPrimary);

      xAxis.HasTitle = true;
      xAxis.AxisTitle.Text = "x-axis";

      yAxis.HasTitle = true;
      yAxis.AxisTitle.Text = "y-axis";

      chartPage.HasTitle = true;
      chartPage.ChartTitle.Text = "Example";

      chartPage.HasLegend = true;

      xlWorkBook.SaveAs(path + "\\out.xls", Excel.XlFileFormat.xlWorkbookNormal,
          misValue, misValue, misValue, misValue,
          Excel.XlSaveAsAccessMode.xlExclusive, misValue,
          misValue, misValue, misValue, misValue);
      xlWorkBook.Close(true, misValue, misValue);
      xlApp.Quit();

      Marshal.ReleaseComObject(xlWorkSheet);
      Marshal.ReleaseComObject(xlWorkBook);
      Marshal.ReleaseComObject(xlApp);

      MessageBox.Show("Excel file created");
      MessageBox.Show(path);
    }
  }
}
