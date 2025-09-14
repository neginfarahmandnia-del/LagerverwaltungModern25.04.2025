namespace LagerverwaltungModern25._04._2025
{
    partial class WarenausgangChartForm
    {
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;

        private void InitializeComponent()
        {
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            SuspendLayout();
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(10, 9);
            cartesianChart1.Margin = new Padding(3, 2, 3, 2);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(665, 338);
            cartesianChart1.TabIndex = 0;
            // 
            // WarenausgangChartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 361);
            Controls.Add(cartesianChart1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "WarenausgangChartForm";
            Text = "Top 5 Warenausgänge";
            Load += WarenausgangChartForm_Load;
            ResumeLayout(false);
        }
    }
}
