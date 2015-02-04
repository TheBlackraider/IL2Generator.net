﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using IL2Generator;

namespace IL2Viewer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Trace.TraceInformation("Inicializando ventana");
   
            InitializeComponent();

            Trace.TraceInformation("Cargando allClasses.dat....");
            IL2Generator.AllClassesClass theClass = new IL2Generator.AllClassesClass("allClasses.dat");
            theClass.ReadAll();
            Grid1.ItemsSource = from ac in theClass.GetEnumerable() select ac;

            Trace.TraceInformation("Cargando allPlaneDB.dat....");
            IL2Generator.AllPlaneDBClass theClass2 = new IL2Generator.AllPlaneDBClass("allPlaneDB.dat");
            theClass2.ReadAll();
            Grid2.ItemsSource = from ac in theClass2.GetEnumerable() select ac;


            Trace.TraceInformation("Cargando allWeapons.dat....");
            IL2Generator.AllWeaponsClass theClass3 = new IL2Generator.AllWeaponsClass("allWeapons.dat");
            theClass3.ReadAll();
            Grid3.ItemsSource = from ac in theClass3.GetEnumerable() select ac;



            Trace.TraceInformation("Cargando allWings.dat....");
            IL2Generator.AllWingsClass theClass4 = new IL2Generator.AllWingsClass("AllWing.dat");
            theClass4.ReadAll();
            Grid4.ItemsSource = from ac in theClass4.GetEnumerable() select ac;

            Trace.TraceInformation("Carga terminada");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //
            using (MissionClass mc = new MissionClass("Mission01.mis"))
            {
                // Sample Data
                Mission m = new Mission();
            
                m.Map = "Kuban/load.ini";
                m.Time = "10.00";
                m.CloudType = 1;
                m.CloudHeight = 600;
                m.Player = "VF101_SP100";
                m.Side = 1;
                m.PlayerNum = 0;

                m.Year = "2015";
                m.Month = "02";
                m.Day = "03";

                m.WindDirection = 2;
                m.WindSpeed = 300.0;
                m.Gust = 20;
                m.Turbulence = 2;

                mc.Write(m);

                mc.WriteAll();
            }
                
        }
    }
}