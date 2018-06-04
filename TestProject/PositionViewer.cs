using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TestProject.Models;

namespace TestProject.GUI
{
    public partial class Form1 : Form
    {
        private const int WindowSizeX = 900;
        private const int WindowSizeY = 900;
        private const int DotSize = 12;
        private const int FontSize = 6;

        /// <remarks>
        /// This is business logic in the GUI. No no
        /// </remarks>
        private const int CoordinateMaxValue = 816000;

        private List<LogPlayerPosition> Locations;

        public Form1(List<LogPlayerPosition> locations)
        {
            InitializeComponent();
            this.Locations = locations;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Paint += new PaintEventHandler(Form1_Paint);
        }
        private void DrawMap(PaintEventArgs e)
        {
            Image image = Image.FromFile("../../../Data/Erangel.jpg");

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            int i = 1;

            using (Graphics graphicsObj = e.Graphics)
            {
                graphicsObj.DrawImage(image, 0, 0, WindowSizeX, WindowSizeY);
                foreach (LogPlayerPosition location in Locations)
                {
                    // Also business logic in the GUI.
                    graphicsObj.FillEllipse(Brushes.AliceBlue, ((location.Character.Location.X / CoordinateMaxValue) * WindowSizeX) - (DotSize / 2), ((location.Character.Location.Y / CoordinateMaxValue) * WindowSizeY) - (DotSize / 2), DotSize, DotSize);
                    graphicsObj.DrawEllipse(Pens.Black, ((location.Character.Location.X / CoordinateMaxValue) * WindowSizeX) - (DotSize / 2), ((location.Character.Location.Y / CoordinateMaxValue) * WindowSizeY) - (DotSize / 2), DotSize, DotSize);
                    graphicsObj.DrawString(i.ToString(), new Font("Arial", FontSize), Brushes.Black, (location.Character.Location.X / CoordinateMaxValue) * WindowSizeX, (location.Character.Location.Y / CoordinateMaxValue) * WindowSizeY, format);
                    i++;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.Size = new System.Drawing.Size(WindowSizeX, WindowSizeY);
            DrawMap(e);
        }
    }
}
