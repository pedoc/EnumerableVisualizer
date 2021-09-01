using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ICSharpCode.AvalonEdit;

namespace CodeCapital.EnumerableVisualizer
{
    public partial class StringVisualizerForm : XtraForm
    {
        public StringVisualizerForm(string value)
        {
            InitializeComponent();
            // var codeEditor = new MainControl()
            // {
            //     Dock = DockStyle.Fill
            // };
            var sw = Stopwatch.StartNew();
            var codeEditor = new LiteMainControl()
            {
                Dock = DockStyle.Fill
            };
            sw.Stop();
            Console.WriteLine();
            codeEditor.SetText(value);
            this.Controls.Add(codeEditor);
        }

        public StringVisualizerForm():this(string.Empty)
        {
            
        }
    }
}
