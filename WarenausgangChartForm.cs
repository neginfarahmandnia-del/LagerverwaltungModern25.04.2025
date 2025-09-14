using System;
using System.Linq;
using System.Windows.Forms;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LagerverwaltungModern25._04._2025.Data;
using LiveChartsCore.SkiaSharpView.Painting;

namespace LagerverwaltungModern25._04._2025
{
    public partial class WarenausgangChartForm : Form
    {
        private readonly ApplicationDbContext _context;

        public WarenausgangChartForm()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();

            LoadChart();
        }
        public static class UIStyler
        {
            public static void ApplyModernStyle(Form form)
            {
                form.BackColor = Color.WhiteSmoke;

                foreach (Control ctrl in form.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.BackColor = Color.LightSlateGray;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }

                    if (ctrl is Label lbl)
                    {
                        lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    }
                }
            }
        }
        private void LoadChart()
        {
            var topArtikel = _context.Warenausgaenge
                .GroupBy(w => w.Artikel.Name)
                .Select(g => new
                {
                    Artikelname = g.Key,
                    Anzahl = g.Sum(w => w.Menge)
                })
                .OrderByDescending(x => x.Anzahl)
                .Take(5)
                .ToList();

            cartesianChart1.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = topArtikel.Select(x => x.Anzahl).ToArray(),
                    Fill = new SolidColorPaint(SKColors.SkyBlue)
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = topArtikel.Select(x => x.Artikelname).ToArray()
                }
            };
        }

        private void WarenausgangChartForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);

        }
    }
}
