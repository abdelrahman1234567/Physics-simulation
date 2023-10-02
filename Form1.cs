<<<<<<< HEAD
using System.Windows.Forms;

namespace Physics_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var webBrowser1 = new WebBrowser();
            webBrowser1.Navigate(new Uri(@"file:///E:/Work/Physics project/test.html"));
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace physics_project_2
{
    public partial class Form1 : Form
    {
        private Rectangle FormRec;
        private Rectangle TitleRec;
        private float TitleSz;
        private Rectangle logoRec;
        private float logoSz;
        private Rectangle stripRec;
        private float stripSz;
        private Rectangle grade10Rec;
        private float grade10Sz;
        private Rectangle grade11Rec;
        private float grade11Sz;
        private Rectangle grade12Rec;
        private float grade12Sz;
        private Rectangle return1Rec;
        private float return1Sz;
        private Rectangle return2Rec;
        private float return2Sz;
        private Rectangle return3Rec;
        private float return3Sz;
        private Rectangle return4Rec;
        private float return4Sz;
        private Rectangle return5Rec;
        private float return5Sz;
        private float[] Szs = new float[1000];
        private Control[] ctrs = new Control[1000];
        private Rectangle[] Recs = new Rectangle[1000];
        private int IDX = 0;
        private string[] LO12Name = { "Harmonic Motion and Waves", "Oscillatory Motion", "Reflection of Light", "Communication", "Communication", "Refraction of Light", "Electromagnetic Waves & Light", "Electromagnetic Waves & Light", "Harmonic Motion and Waves", "Quantum Nature of Light", "Quantum Nature of Light", "Thermal & Electrical Properties", "Low Temperature Physics", "Nanoparticles"};
        private string[] LO11Name = {"General Law of Gravity", "Electric Fields and Forces", "Direct Current Circuits", "Direct Current Circuits", "Capacitors & Inductors", "Magnetic Fields & Forces", "Magnetic Fields & Forces", "Electromagnetic Induction", "Electromagnetic Induction", "Electromagnetic Induction", "Transformers", "AC Circuits", "AC Circuits", "Semiconductors", "AC & DC with Diodes", "Transistors" };
        private string[] LO10Name = { "Measurement And Units","Newtonian Physics", "Newtonian Physics", "Newtonian Physics", "Center of mass, torque, and general equilibrium", "Restoring Forces", "Restoring Forces", "Fluid Mechanics", "Fluid Dynamics", "Thermodynamics", "Thermodynamics", "" };
        private float fontScale = 1f;
        public Form1()
        {
            for(int i = 0; i < 1000; i++)
            {
                Szs[i] = -1;
            }
            InitializeComponent();
            
            webView.EnsureCoreWebView2Async();
            this.grade12Tab.BackgroundImage = Properties.Resources.im;
            this.grade11Tab.BackgroundImage = Properties.Resources.im10;
            this.grade10Tab.BackgroundImage = Properties.Resources.im11;
            this.Resize += new System.EventHandler(this.Form_Resize);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (tabs.SelectedIndex == 4)
            {
                this.MaximizeBox = true;
            }
            else
            {
                this.MaximizeBox = false;
            }
            foreach (Control ctr in this.tabs.Controls)
            {
                ctrs[IDX] = ctr;
                Szs[IDX] = ctr.Font.Size;
                Recs[IDX] = new Rectangle(ctr.Location, ctr.Size);
                IDX++;
            }
            foreach (Control ctr in this.MainPageTab.Controls)
            {
                ctrs[IDX] = ctr;
                Szs[IDX] = ctr.Font.Size;
                Recs[IDX] = new Rectangle(ctr.Location, ctr.Size);
                IDX++;
            }
            foreach (Control ctr in this.grade10Tab.Controls)
            {
                ctrs[IDX] = ctr;
                Szs[IDX] = ctr.Font.Size;
                Recs[IDX] = new Rectangle(ctr.Location, ctr.Size);
                IDX++;
            }
            foreach (Control ctr in this.grade11Tab.Controls)
            {
                ctrs[IDX] = ctr;
                Szs[IDX] = ctr.Font.Size;
                Recs[IDX] = new Rectangle(ctr.Location, ctr.Size);
                IDX++;
            }
            foreach (Control ctr in this.grade12Tab.Controls)
            {
                ctrs[IDX] = ctr;
                Szs[IDX] = ctr.Font.Size;
                Recs[IDX] = new Rectangle(ctr.Location, ctr.Size);
                IDX++;
            }
            foreach (Control ctr in this.simTab.Controls)
            {
                ctrs[IDX] = ctr;
                Szs[IDX] = ctr.Font.Size;
                Recs[IDX] = new Rectangle(ctr.Location, ctr.Size);
                IDX++;
            }
            foreach (Control ctr in this.HelpTab.Controls)
            {
                ctrs[IDX] = ctr;
                Szs[IDX] = ctr.Font.Size;
                Recs[IDX] = new Rectangle(ctr.Location, ctr.Size);
                IDX++;
            }
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            for (int i= 0;i < 1000;i++)
            {
                if (Szs[i] == -1)
                {
                    break;
                }
                ResizeLabel(ctrs[i], Recs[i], Szs[i]);
            }
            if (tabs.SelectedIndex == 4)
            {
                this.MaximizeBox = true;
            }
            else
            {
                this.MaximizeBox = false;
            }
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            tabs.Size = this.ClientSize - new System.Drawing.Size(tabs.Location);
        }

        private void ResizeLabel(Control control, Rectangle LabelRect, float fontSz)
        {
            float xRatio = (float)this.ClientRectangle.Width / (float)FormRec.Width;
            float yRatio = (float)this.ClientRectangle.Height / (float)FormRec.Height;

            float newX = LabelRect.Location.X * xRatio;
            float newY = LabelRect.Location.Y * yRatio;

            control.Location = new Point((int)newX, (int)newY);
            control.Width = (int)(LabelRect.Width * xRatio);
            control.Height = (int)(LabelRect.Height * yRatio);

            float ratio = xRatio;
            if (xRatio >= yRatio)
            {
                ratio = yRatio;
            }
            float newFontSize = fontSz * ratio * fontScale;
            Font newFont = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);
            control.Font = newFont;
        }

        private void grade12_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 3;
        }

        private void grade11_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 2;
        }

        private void grade10_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 1;
        }

        private void Return1_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 0;
        }

        private void Return2_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 0;
        }

        private void Return3_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 0;
        }

        private void Return4_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 0;
        }

        private void Return5_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = 0;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Mecahnical waves", "Transverse waves", "Longitudinal waves", "Waves speed in a medium", "Wavelength" };
            string[] sims = {"Wave on a string", "Waves"};
            string[][] topics = {new string[]{"Frequency","Waves","Amplitude"},
                                 new string[]{"Wave Speed", "Sound", "Wavelength", "Water", "Frequency", "Amplitude"}};
            string[] link = {"waveOnString.html", "waves.html" };
            ShowLO12(1, concepts, sims, topics,link, 2);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Oscillation as aperiodic motion", "Parameters of oscillatory motion", "Longitudinal waves", "Applications of oscillation"};
            string[] sims = { "Springs (Basic edition)", "Springs (Advanced edition)", "Pendulum"};
            string[][] topics = {new string[]{"Periodic Motion", "Hooke's Law"},
                                 new string[]{"Periodic Motion", "Hooke's Law", "Conservation of Energy", "Newton's Laws"},
                                 new string[]{"Simple Harmonic Motion", "Period", "Conservation of Energy"} };
            string[] link = { "springs basics.html", "springs.html", "pendulum.html" };
            ShowLO12(2, concepts, sims, topics, link, 3);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Light rays", "Law of Reflection", 
                                  "Real & Virtual Image", 
                                  "Image Formation in Plane Mirror", 
                                  "Focus & Optical Axix", 
                                  "Convex & Concave Mirros", 
                                  "Magnification" };
            string[] sims = { "Geometric Optics (Basic edition)", "Geometric Optics (Advanced edition)" };
            string[][] topics = {new string[]{"Optics", "Plane Mirror"},
                                 new string[]{"Concave Mirror", "Convex Mirror", "Focal Length", "Optics"}};
            string[] link = { "GObasics.html", "GOadvanced.html" };
            ShowLO12(3, concepts, sims, topics, link, 2);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Elements of Communication", 
                                  "Wave Propgation", 
                                  "Antennas", 
                                  "Transmitting Tower", 
                                  "Maximum Usable Frequency", 
                                  "Satellite Communication", 
                                  "Mobile Phones", 
                                  "Optical Fiber" };
            string[] sims = { };
            string[][] topics = {};
            string[] link = { };
            ShowLO12(4, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Encoding", "Ampliture Modulation", "Frequency Modulation" ,"Digital vs Analog Data", "Digital vs Analog Transmission", "Wi-Fi", "Sampling"};
            string[] sims = {};
            string[][] topics = {};
            string[] link = {  };
            ShowLO12(5, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Index of Refraction", "Snell's Law", "Total Internal Reflection", "Focus & Optical Axis", "Real & Virtual Image", "Convex & Concave Lenses", "Magnification" };
            string[] sims = { "Geometric optics (Advanced edition)" };
            string[][] topics = { new string[] { "Concave Lens", "Convex Lens", "Concave Mirror", "Convex Mirror" } };
            string[] link = { "GOadvanced.html" };
            ShowLO12(6, concepts, sims, topics, link, 1);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Superposition", "Constructive/Destructive Interference", "Slits & Interference Patterns", "DIffraction Gratings", "Resolution of Optical Instruments"};
            string[] sims = { "Wave Interference"};
            string[][] topics = {new string[]{"Interference", "Double Split", "Diffraction", "Waves"}};
            string[] link = { "WaveInter.html" };
            ShowLO12(7, concepts, sims, topics, link, 1);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Electromagnetic waves", "Polarized and un-Polarized light", "Electromagnetic Spectrum", "Energy in Electromagnetic Waves"};
            string[] sims = { "Blackbody Spectrum"};
            string[][] topics = {new string[]{"Blackbody", "Planck's Law", "Electromagnetic Radiation", "Different EM spectrum"}};
            string[] link = { "blackbody.html" };
            ShowLO12(8, concepts, sims, topics, link, 1);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Superposition of Waves", "Interference", "Diffraction"};
            string[] sims = { "Wave Interferance and Superposition"};
            string[][] topics = {new string[]{"Interference", "Double Split", "Diffraction", "Waves" } };
            string[] link = { "WaveInter.html"};
            ShowLO12(9, concepts, sims, topics, link, 1);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Blackbody Radiation", "Energy Quantization", "Planck's Constant", "Photon", "X-rays", "Inelastic Scattering (Compton effect)"};
            string[] sims = { "Blackbody Spectrum" };
            string[][] topics = { new string[] { "Blackbody", "Planck's Law", "Electromagnetic Radiation", "Different EM spectrum" } };
            string[] link = { "blackbody.html" };
            ShowLO12(10, concepts, sims, topics, link, 1);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Photoelectric Effect", "Work Function", "Intensity", "Cut-off Frequency", "LED", "Laser", "Photocell"};
            string[] sims = {};
            string[][] topics = {};
            string[] link = {};
            ShowLO12(11, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Solid-state Phsyics", "Crystal Structure", "Coulom Forces", "Phonos", "Energy Bands"};
            string[] sims = {};
            string[][] topics = {};
            string[] link = { };
            ShowLO12(12, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Cooling Processes", "Van Der Walls Effect", "Super Fluidity", "Viscosity", "Bose-Einstein Condensates", "Superconductivity", "Cooper Pairs"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO12(13, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Nanoparticles", "Nanofabrication", "Atomic Force Microscope", "Nanotube"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO12(14, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Newton's Law of Universal Gravitation",
"Gravitation Constant",
"Gravitational Field",
"Field Force & Inverse Square Law",
"Launching & Orbital & Escape Velocities of Satellites"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(1, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Static Electricity",
"Coulomb's Law",
"Electric Field",
"Conservation of Electric Charge",
"Repulsion and Attraction",
"Methods of Electrification",
"Electroscope",
"Electric Field Lines",
"Electric Potential"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(2, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Dynamic Electricity",
"Electric Current",
"Current Density",
"Potential Difference",
"Electrical Resistors",
"Resistivity & Conductivity",
"Electromotive Force",
"Internal Resistance",
"Terminal Voltage",
"Ohm's Law"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(3, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Connections of Resistors (Series & Parallel)",
"Kirchoff's Current Law",
"Kirchoff's Voltage Law"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(4, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Capacitor Charging & Discharging",
"Energy Storage",
"Dielectric Material",
"Time Constant",
"Exponential Charge/Discharge",
"Connection and Capacitance \r\nof Capacitors (Series & Parallel)" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(5, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Magnetic Field",
"Magnetic Flux",
"Magnetic Domain",
"Magnetic Flux Density",
"Polarity of Solenoid",
"Direction of Magnetic Field (Ampere's Rule)",
"Magnetic Field from Straight Wire",
"Magnetic Field from Loop",
"Magnetic Field from Solenoid"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(6, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Force on Moving Charge in Magnetic Field",
"Force on Current-carrying Wire in Magnetic Field",
"Magnetic Torque and Motors",
"Measuring Devices: (Galvanometer, Ammeter, Voltmeter, Ohmmeter)"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(7, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Electromagnetic Induction",
"Faraday's Law",
"Lenz’s Law",
"Loops and Solenoids" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(8, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Inductor",
"Back emf",
"RL Circuit",
"Energy Storage",
"Time Constant",
"Inductor Charging/Discharging",
"Exponential Charge/Discharge" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(9, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            string[] concepts = { "AC Generator",
"Effective Value of emf (rms)",
"D.C Generator",
"D.C Motor"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(10, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Mutual Induction",
"Factors Affecting the Mutual Induction",
"Coefficient of Mutual Induction",
"Transformer (Step-up & Step-down)",
"Eddy Currents" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(11, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            string[] concepts = {"AC Circuits",
"Hot Wire Ammeter",
"Reactance of Capacitor & Inductor",
"Impedance",
"rms Voltage, Current, Power"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(12, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            string[] concepts = {"LCR Circuit",
"Resonance & Resonance Circuits",
"Band-pass Filter",
"Lowpass Filter",
"High Pass Filter" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(13, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Classification of Elements According to Electric Conductivity",
"Doping with Donors and Acceptors",
"Energy Band Gap"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(14, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            string[] concepts = {"The P-N Junction",
"Breakdown voltage",
"Non-ohmic Device",
"Threshold Voltage",
"Diodes as One-way devices",
"Voltage Rectification",
"Forward/Reverse Bias Connection"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(15, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Logic Gates",
"Truth Table",
"Binary Numbers",
"DC Current Gain",
"Base-emitter Current",
"Bipolar Transistor (P-N-P, N-P-N)",
"Transistor as Digital Switch",
"Use of Transistor as Amplifier",
"Collector-emitter Current"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO11(16, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Systems of Measurements",
"International System of Units",
"Prefixes",
"Measurement Errors",
"Accuracy vs. Precision",
"Dimensional Analysis" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(1, concepts, sims, topics, link, 0);
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Forces",
"Static Equilibrium",
"Dynamic Equilibrium",
"System of Forces",
"Newton's Third Law",
"Free Body Diagram",
"Action-Reaction Pairs",
"Point Particle" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(2, concepts, sims, topics, link, 0);
        }
        
        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Force as a Vector",
"Net Force on a Free Body",
"Newton's Laws of Motion",
"Centripetal Acceleration",
"Centripetal Force",
"Inertial Reference Frame" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(3, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Mass",
"Gravity",
"Gravitational Field",
"Weight",
"General Law of Gravitation",
"Newton's Second Law",
"Free Fall",
"Apparent Weight" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(4, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            string[] concepts = {"Center of mass",
"Torque",
"Static equilibrium",
"Translational Equilibrium",
"Rotational Equilibrium",
"The Equilibrium Torque Condition",
"Simple Machines",
"Simple Machines",
"Stability of Extended Rigid Bodies"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(5, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Elasticity & Hooke's Law",
"Range of Validity for Hooke's Law",
"Stress and Strain",
"Young's Modulus"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(6, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Hooke's Law & Linear Springs",
"The Spring Constant",
"Yield Point",
"Tension and Compression"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(7, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Fluids",
"Pressure",
"Manometer",
"Pressure Gauge",
"Units of Pressure",
"Effect of Atmospheric Pressure",
"Atmospheric Pressure and Altitude",
"Pressure Difference and Force",
"Archimedes Principle" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(8, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            string[] concepts = { "General Properties of Fluids",
"Continuity Equation",
"Laminar vs Turbulent Flow",
"Pascal's Principle",
"pdV = Work",
"Work-Energy Theorem",
"Conservation of Energy in Fluids",
"Bernoulli Equation"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(9, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Temperature and Heat",
"Thermal Energy",
"Conduction, Convection, Radiation",
"Blackbody Radiation",
"Solar Heat Collector",
"Natural Sources of Heat",
"Latent Heat" };
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(10, concepts, sims, topics, link, 0);
        }
        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            string[] concepts = { "Conservation of Thermal Energy",
"Energy Graphs",
"Low Temperature Physics",
"Thermodynamic Processes",
"Phase Changes"};
            string[] sims = { };
            string[][] topics = { };
            string[] link = { };
            ShowLO10(11, concepts, sims, topics, link, 0);
        }
        private void ShowLO10(int LO, string[] concepts, string[] sims, string[][] topics, string[] link, int numSims)
        {
            this.MaximizeBox = false;
            List<Control> lst = new List<Control> { };
            foreach (Control ctr in this.grade10Tab.Controls)
            {
                if (ctr is Panel || (ctr is Label && ctr.Name != "choose10"))
                {
                    lst.Add(ctr);
                }
            }
            foreach (Control ctr in lst)
            {
                this.grade10Tab.Controls.Remove(ctr);
            }
            this.grade10Tab.Controls.Add(new Label
            {
                Location = new Point(41, 191),
                AutoSize = true,
                Name = "LO" + LO + "_12",
                Text = "LO. " + LO + ": " + LO10Name[LO - 1],
                ForeColor = Color.OrangeRed,
                Font = new Font("Agency FB", 20, FontStyle.Bold)
            });
            char letter = 'A';
            string newLine = "";
            int idx3 = 0;
            int mult = 1;
            foreach (string x in concepts)
            {
                this.grade10Tab.Controls.Add(new Label
                {
                    Location = new Point(84 * mult, 251),
                    AutoSize = true,
                    Name = "concepts" + LO + "_12" + x,
                    Text = newLine + letter + ". " + x,
                    ForeColor = Color.Black,
                    Font = new Font("Agency FB", 20, FontStyle.Bold)
                });
                letter++;
                idx3++;
                newLine += "\r\n";
                if (idx3 == 5)
                {
                    newLine = "";
                    mult += 4;
                }
            }
            this.grade10Tab.Controls.Add(new Label
            {
                Location = new Point(458, 443),
                AutoSize = true,
                Name = "AVsims1_12",
                Text = "Available simulations",
                ForeColor = Color.OrangeRed,
                Font = new Font("Agency FB", 20, FontStyle.Bold)
            });
            Label[] lbl = new Label[numSims];
            string newLine2 = "";
            int[] index = new int[numSims];
            int sum = 0;
            foreach (string x in sims)
            {
                sum += x.Length;
            }
            int WIDTH = (this.ClientRectangle.Width - 4 * (3 * sum + 4 * numSims + 9 * (numSims - 1))) / 2;
            for (int i = 0; i < numSims; i++)
            {
                Label LABEL = new Label
                {
                    Location = new Point(WIDTH, 529),
                    AutoSize = true,
                    Name = "sim" + LO + "_" + sims[i],
                    Text = newLine2 + "[" + (i + 1) + "] " + sims[i],
                    ForeColor = Color.Black,
                    Font = new Font("Agency FB", 20, FontStyle.Bold)
                };
                int sz = sims[i].Length;
                for (int j = 0; j < sz; j++)
                {
                    newLine2 += "  ";
                }
                newLine2 += "         ";
                lbl[i] = LABEL;
                index[i] = i;
            }
            int idx = 0;
            foreach (string x in sims)
            {
                int idx2 = 0;
                foreach (string[] y in topics)
                {
                    if (idx2 != idx)
                    {
                        idx2++;
                        continue;
                    }
                    lbl[idx].Click += (sender, EventArgs) => { simClick(sender, EventArgs, x, y); };
                    break;
                }
                idx++;
            }
            idx = 0;
            foreach (string x in link)
            {
                lbl[idx].DoubleClick += (sender, EventArgs) => { simDClick(sender, EventArgs, "Grade 11/" + x); };
                this.grade10Tab.Controls.Add(lbl[idx]);
                idx++;
            }
        }
        private void ShowLO11(int LO, string[] concepts, string[] sims, string[][] topics, string[] link, int numSims)
        {
            this.MaximizeBox = false;
            List<Control> lst = new List<Control> { };
            foreach (Control ctr in this.grade11Tab.Controls)
            {
                if (ctr is Panel || (ctr is Label && ctr.Name != "choose11"))
                {
                    lst.Add(ctr);
                }
            }
            foreach (Control ctr in lst)
            {
                this.grade11Tab.Controls.Remove(ctr);
            }
            this.grade11Tab.Controls.Add(new Label
            {
                Location = new Point(41, 191),
                AutoSize = true,
                Name = "LO" + LO + "_12",
                Text = "LO. " + LO + ": " + LO11Name[LO - 1],
                ForeColor = Color.OrangeRed,
                Font = new Font("Agency FB", 20, FontStyle.Bold)
            });
            char letter = 'A';
            string newLine = "";
            int idx3 = 0;
            int mult = 1;
            foreach (string x in concepts)
            {
                this.grade11Tab.Controls.Add(new Label
                {
                    Location = new Point(84 * mult, 251),
                    AutoSize = true,
                    Name = "concepts" + LO + "_12" + x,
                    Text = newLine + letter + ". " + x,
                    ForeColor = Color.Black,
                    Font = new Font("Agency FB", 20, FontStyle.Bold)
                });
                letter++;
                idx3++;
                newLine += "\r\n";
                if (idx3 == 5)
                {
                    newLine = "";
                    mult += 4;
                }
            }
            this.grade11Tab.Controls.Add(new Label
            {
                Location = new Point(458, 443),
                AutoSize = true,
                Name = "AVsims1_12",
                Text = "Available simulations",
                ForeColor = Color.OrangeRed,
                Font = new Font("Agency FB", 20, FontStyle.Bold)
            });
            Label[] lbl = new Label[numSims];
            string newLine2 = "";
            int[] index = new int[numSims];
            int sum = 0;
            foreach (string x in sims)
            {
                sum += x.Length;
            }
            int WIDTH = (this.ClientRectangle.Width - 4 * (3 * sum + 4 * numSims + 9 * (numSims - 1))) / 2;
            for (int i = 0; i < numSims; i++)
            {
                Label LABEL = new Label
                {
                    Location = new Point(WIDTH, 529),
                    AutoSize = true,
                    Name = "sim" + LO + "_" + sims[i],
                    Text = newLine2 + "[" + (i + 1) + "] " + sims[i],
                    ForeColor = Color.Black,
                    Font = new Font("Agency FB", 20, FontStyle.Bold)
                };
                int sz = sims[i].Length;
                for (int j = 0; j < sz; j++)
                {
                    newLine2 += "  ";
                }
                newLine2 += "         ";
                lbl[i] = LABEL;
                index[i] = i;
            }
            int idx = 0;
            foreach (string x in sims)
            {
                int idx2 = 0;
                foreach (string[] y in topics)
                {
                    if (idx2 != idx)
                    {
                        idx2++;
                        continue;
                    }
                    lbl[idx].Click += (sender, EventArgs) => { simClick(sender, EventArgs, x, y); };
                    break;
                }
                idx++;
            }
            idx = 0;
            foreach (string x in link)
            {
                lbl[idx].DoubleClick += (sender, EventArgs) => { simDClick(sender, EventArgs, "Grade 11/" + x); };
                this.grade11Tab.Controls.Add(lbl[idx]);
                idx++;
            }
        }
        private void simClick11(object sender, EventArgs e, string sim, string[] topics)
        {
            Panel info = new Panel
            {
                Location = new Point(731, 146),
                BackColor = Color.SkyBlue,
                Size = new Size(300, 275)
            };

            string Topics = "";
            foreach (string x in topics)
            {
                Topics += "- " + x + "\r\n";
            }
            info.Controls.Add(new Label
            {
                Location = new Point(16, 20),
                AutoSize = true,
                Name = "panelSim_" + sim,
                Text = "Topics available in simulation:\r\n" + Topics,
                ForeColor = Color.Black,
                Font = new Font("Agency FB", 20)
            });
            foreach (Control ctr in this.grade11Tab.Controls)
            {
                if (ctr is Panel)
                {
                    this.grade11Tab.Controls.Remove(ctr);
                    break;
                }
            }
            this.grade11Tab.Controls.Add(info);
        }
        private void ShowLO12(int LO, string[] concepts, string[] sims,string[][] topics, string[] link, int numSims) {
            this.MaximizeBox = false;
            List<Control> lst = new List<Control> { };
            foreach (Control ctr in this.grade12Tab.Controls)
            {
                if (ctr is Panel || (ctr is Label && ctr.Name!="choose12"))
                {
                    lst.Add(ctr);
                }
            }
            foreach(Control ctr in lst)
            {
                this.grade12Tab.Controls.Remove(ctr);
            }
            this.grade12Tab.Controls.Add(new Label
            {
                Location = new Point(41, 191),
                AutoSize = true,
                Name = "LO"+LO+"_12",
                Text = "LO. "+LO+": " + LO12Name[LO - 1],
                ForeColor = Color.OrangeRed,
                Font = new Font("Agency FB", 20, FontStyle.Bold)
            });
            char letter = 'A';
            string newLine = "";
            int idx3 = 0;
            int mult = 1;
            foreach (string x in concepts)
            {
                this.grade12Tab.Controls.Add(new Label
                {
                    Location = new Point(84*mult , 251),
                    AutoSize = true,
                    Name = "concepts"+LO+"_12" + x,
                    Text = newLine + letter + ". " + x,
                    ForeColor = Color.Black,
                    Font = new Font("Agency FB", 20, FontStyle.Bold)
                });
                letter++;
                idx3++;
                newLine += "\r\n";
                if(idx3 == 5)
                {
                    newLine = "";
                    mult+=4;
                }
            }
            this.grade12Tab.Controls.Add(new Label
            {
                Location = new Point(458, 443),
                AutoSize = true,
                Name = "AVsims1_12",
                Text = "Available simulations",
                ForeColor = Color.OrangeRed,
                Font = new Font("Agency FB", 20, FontStyle.Bold)
            });
            Label[] lbl = new Label[numSims];
            string newLine2 = "";
            int[] index = new int[numSims];
            int sum = 0;
            foreach(string x in sims)
            {
                sum += x.Length;
            }
            int WIDTH = (this.ClientRectangle.Width - 4*(3*sum + 4*numSims + 9*(numSims-1))) / 2;
            for (int i= 0;i<numSims;i++)
            {
                Label LABEL = new Label
                {
                    Location = new Point(WIDTH, 529),
                    AutoSize = true,
                    Name = "sim" + LO + "_" + sims[i],
                    Text = newLine2 + "["+(i+1)+"] " + sims[i],
                    ForeColor = Color.Black,
                    Font = new Font("Agency FB", 20, FontStyle.Bold)
                };
                int sz = sims[i].Length;
                for (int j = 0; j < sz; j++) {
                    newLine2 += "  ";
                }
                newLine2 += "         ";
                lbl[i] = LABEL;
                index[i] = i; 
            }
            int idx = 0;
            foreach (string x in sims)
            {
                int idx2 = 0;
                foreach (string[] y in topics)
                {
                    if (idx2 != idx)
                    {
                        idx2++;
                        continue;
                    }
                    lbl[idx].Click += (sender, EventArgs) => { simClick(sender, EventArgs, x,y); };
                    break;
                }
                idx++;
            }
            idx = 0;
            foreach(string x in link)
            {
                lbl[idx].DoubleClick += (sender, EventArgs) => {simDClick(sender, EventArgs, "Grade 12/" + x); };
                this.grade12Tab.Controls.Add(lbl[idx]);
                idx++;
            }
        }
        private void simClick(object sender, EventArgs e, string sim, string[] topics)
        {
            Panel info = new Panel{
                Location = new Point(731, 146),
                BackColor = Color.SkyBlue,
                Size = new Size(300, 275)
            };
            
            string Topics = "";
            foreach(string x in topics)
            {
                Topics += "- " + x + "\r\n";
            }
            info.Controls.Add(new Label
            {
                Location = new Point(16, 20),
                AutoSize = true,
                Name = "panelSim_" + sim,
                Text = "Topics available in simulation:\r\n" + Topics,
                ForeColor = Color.Black,
                Font = new Font("Agency FB", 20)
            });
            foreach(Control ctr in this.grade12Tab.Controls)
            {
                if(ctr is Panel)
                {
                    this.grade12Tab.Controls.Remove(ctr);
                    break;
                }
            }
            this.grade12Tab.Controls.Add(info);
        }
        private void simDClick(object sender, EventArgs e, string x)
        {
            string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string myFile = Path.Combine(applicationDirectory, "Sim/" + x);
            Console.WriteLine(myFile);
            webView.CoreWebView2.Navigate("file:///" + myFile);
            tabs.SelectedIndex = 4;
            this.MaximizeBox = true;
        }
    }
}
>>>>>>> 7f9bf89 (First commit)
