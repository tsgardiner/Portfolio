using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrayScottSimulator
{
    public partial class Form1 : Form
    {

        Graphics g;
        Grid grid;
        Simulation simulation;
        Equation equation;
        ColourGenerator colourGenerator;
        Bitmap buffer;
        Graphics gBuffer;
        string fileName = "";
        double feedA;
        double killB;
        int timeSteps;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           lbDisplayTimeSteps.Text = timeSteps++.ToString();
           simulation.RunSimulation();
           simulation.DrawSimulation();
        }

        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            try
            {
                feedA = Double.Parse(tbFeedA.Text);
                killB = Double.Parse(tbKillB.Text);
                LoadColourGenerator();
                grid = new Grid(g, colourGenerator); //Reset Grid and all Cells on pattern change
                g.Clear(SystemColors.Control);
                LoadEquation();
                simulation = new Simulation(grid, equation);

                timer1.Enabled = true;  
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter vaid feed and kill rates in the format of 0.0XX");
            }           
                      
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to run an automated simulation?", "Confirmation", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            { 
                //feedA = 0.020;
                //killB = 0.046;
                timeSteps = 5000;
                //CreateImageBuffer();
                IncrementSimulation();
            }           
        }

        private void LoadColourGenerator()
        {            
            if (rbGreenBlack.Checked)
                colourGenerator = new GreenBlack();
            if (rbRedBlack.Checked)
                colourGenerator = new RedBlack();
            if (rbGreyScale.Checked)
                colourGenerator = new GreyScale();
        }

        private void LoadEquation()
        {
            if (rbConvolution.Checked) 
                equation = new Convolution(feedA, killB);
            else if (rbPerpendicular.Checked) 
                equation = new Perpendicular(feedA, killB);
            else if (rbDeltaMeans.Checked) 
                equation = new DeltaMeans(feedA, killB);                      
        }

        private void CreateImageBuffer()
        {
            int imageSize = Cell.GetCELL_SIZE * Grid.GetGRID_SIZE;
            buffer = new Bitmap(imageSize, imageSize);
            gBuffer = Graphics.FromImage(buffer);
            LoadColourGenerator();
            grid = new Grid(gBuffer, colourGenerator);
            LoadEquation();
            simulation = new Simulation(grid, equation);
        }

        private void GenerateFileName()
        {
            if (rbConvolution.Checked)
                fileName += rbConvolution.Text;
            else if (rbPerpendicular.Checked)
                fileName += rbPerpendicular.Text;
            else if (rbDeltaMeans.Checked)
                fileName += rbDeltaMeans.Text;
            fileName += "fA" + feedA.ToString();
            fileName += "kB" + killB.ToString();
        }

        //Was working now completely broken and doesn't save images
        private void IncrementSimulation()
        {
            for (double i = 0.046; i < 0.080; i += 0.001)
            {
                killB = i;
                for (double j = 0.020; j < 0.080; j += 0.001)
                {
                    feedA = j;
                    CreateImageBuffer();

                    for (int k = 0; k < timeSteps; k++)
                    {
                        simulation.RunSimulation();
                    }

                    simulation.DrawSimulation();
                    GenerateFileName();
 
                    buffer.Save(fileName += ".jpeg");
                    fileName = "";
                                
                }
                
            }

        }

        //This works and save files. No idea why the above method doesn't as the save is exactly the same.
        //private void IncrementSimulation()
        //{
        //    while (feedA != 0.099 || killB != 0.099)
        //    {
        //        CreateImageBuffer();
 
        //        for (int i = 0; i < timeSteps; i++)
        //        {
        //            simulation.RunSimulation();
        //        }
 
        //        feedA = feedA + 0.001;
        //        killB = killB - 0.001;
 
        //        simulation.DrawSimulation();
        //        GenerateFileName();
 
        //        buffer.Save(fileName += ".jpeg");
        //        fileName = "";
        //    }            
        //}
 

        
    }
}
