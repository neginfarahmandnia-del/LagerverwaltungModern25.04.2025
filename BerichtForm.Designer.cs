namespace LagerverwaltungModern25._04._2025
{
    partial class BerichtForm
    {
        private System.ComponentModel.IContainer components = null;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            SuspendLayout();
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(18, 15);
            cartesianChart1.Margin = new Padding(3, 2, 3, 2);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(656, 300);
            cartesianChart1.TabIndex = 0;
            // 
            // BerichtForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 338);
            Controls.Add(cartesianChart1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BerichtForm";
            Text = "Top 10 meistverkaufte Artikel";
            Load += BerichtForm_Load;
            ResumeLayout(false);
        }
    }
}
