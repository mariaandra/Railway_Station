using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


namespace Railway_System
{
    /// <summary>
    /// Interaction logic for Chose.xaml
    /// </summary>
    public partial class Chose : Window
    {
        string filename;
        static DataClasses1DataContext dataClasses = new DataClasses1DataContext();

        public Chose()
        {
            InitializeComponent();
        }

        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Alegeti un fisier xml";
            openFileDialog.Filter = "XML File| *.xml";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.filename = openFileDialog.FileName;
            }
        }

        private void StationBtn_Click(object sender, RoutedEventArgs e)
        {
            openFile();

            XDocument document = XDocument.Load(filename);

            var statie_id = (from trains in document.Element("Statii").Elements("Statie")
                             select trains.Attribute("IDStatie").Value).ToList();
            var statie_nume = (from trains in document.Element("Statii").Elements("Statie")
                               select trains.Element("NumeStatie").Value).ToList();

            for (int i = 0; i < statie_id.Count; i++)
            {
                Statii statie = new Statii
                {
                    IDStatie = Convert.ToInt32(statie_id[i]),
                    Nume_statie = statie_nume[i]
                };

                dataClasses.Statiis.InsertOnSubmit(statie);
            }

            dataClasses.SubmitChanges();

            System.Windows.MessageBox.Show("Datele au fost adaugate!");

            this.Close();
        }

        private void TrainBtn_Click(object sender, RoutedEventArgs e)
        {
            openFile();

            XDocument document = XDocument.Load(filename);

            var tren_id = (from trains in document.Element("Trenuri").Elements("Tren")
                           select trains.Attribute("IDTren").Value).ToList();
            var tren_tip = (from trains in document.Element("Trenuri").Elements("Tren")
                            select trains.Element("TipTren").Value).ToList();
            var tren_nr = (from trains in document.Element("Trenuri").Elements("Tren")
                           select trains.Element("NumarVagoane").Value).ToList();

            for(int i = 0;i< tren_id.Count; i++)
            {
                Trenuri tren = new Trenuri
                {
                    IDTren = Convert.ToInt32(tren_id[i]),
                    Tip_Tren = tren_tip[i],
                    Numar_vagoane = Convert.ToInt32(tren_nr[i])
                };

                dataClasses.Trenuris.InsertOnSubmit(tren);
            }

            dataClasses.SubmitChanges();

            System.Windows.MessageBox.Show("Datele au fost adaugate!");

            this.Close();

        }
    }
}
