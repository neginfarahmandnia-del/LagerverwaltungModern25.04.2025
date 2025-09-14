using System;
using System.Linq;
using System.Windows.Forms;
using LagerverwaltungModern25._04._2025.Models;
using LagerverwaltungModern25._04._2025.Data;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.EntityFrameworkCore;

namespace LagerverwaltungModern25._04._2025
{

    public partial class BerichtForm : Form
    {
        private readonly ApplicationDbContext _context;

        public BerichtForm(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;

            LadeStatistiken();
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
        private void LadeStatistiken()
        {
            // Beispiel: Artikel mit geringem Bestand
            var artikelMitNiedrigemBestand = _context.Artikel
                .Where(a => a.Bestand < 10)
                .Select(a => new { a.Name, a.Bestand })
                .ToList();

            // Beispiel: Top 5 meistverkaufte Artikel (vereinfachte Annahme)
            var topArtikel = _context.Bestellungen
                .GroupBy(bp => bp.Artikel.Name)
                .Select(g => new
                {
                    Artikelname = g.Key,
                    Menge = g.Sum(bp => bp.Menge)
                })
                .OrderByDescending(g => g.Menge)
                .Take(5)
                .ToList();

            cartesianChart1.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Top 5 Artikel",
                    Values = topArtikel.Select(a => a.Menge).ToArray()
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = topArtikel.Select(a => a.Artikelname).ToArray(),
                    LabelsRotation = 15
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Verkäufe"
                }
            };
        }

        private void BerichtForm_Load(object sender, EventArgs e)
        {
            UIStyler.ApplyModernStyle(this);

        }
    }
}
