using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;


namespace CodeCapital.EnumerableVisualizer
{
    public partial class VisualizerForm : XtraForm, IDisposable
    {
        private readonly DataTable _dataTable;

        public VisualizerForm(DataTable dataTable)
        {
            InitializeComponent();
            if (dataTable == null)
            {
                return;
            }
            _dataTable = dataTable;

            gridControl.DataSource = _dataTable;

            // var column = gridView.Columns.FirstOrDefault();
            // if (column != null)
            // {
            //     column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            //     column.SummaryItem.DisplayFormat = @"合计：{0：n2}";
            // }
        }


        private void ExportToExcelButton_Click(object sender, System.EventArgs e)
        {
            var myDocumentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var saveDialog = new SaveFileDialog
            {
                InitialDirectory = myDocumentsFolderPath,
                RestoreDirectory = true,
                Filter = @"Excel files (*.xlsx)|*.xlsx",
                Title = @"Export Excel File To"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            var path = saveDialog.FileName;
            var ext = Path.GetExtension(path);
            gridView.Export(ext.Equals("xlsx", StringComparison.OrdinalIgnoreCase) ? ExportTarget.Xlsx : ExportTarget.Xls, path);
        }

        public new void Dispose()
        {
            _dataTable?.Clear();
            base.Dispose();
        }
    }
}
