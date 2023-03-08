using System;
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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Railway_System
{
    /// <summary>
    /// Interaction logic for ModifyRouteDialog.xaml
    /// </summary>
    public partial class ModifyRouteDialog : Window
    {
        static DataClasses1DataContext dataClasses = new DataClasses1DataContext();
        public ModifyRouteDialog()
        {
            InitializeComponent();
        }

        private void InsertStationBtn_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmldocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Creating an XML tree using Linq to Xml"));

            XElement baza = new XElement("Mersul_Trenurilor");

            XElement pasageri = new XElement("Pasageri");
            var psg = (from Pasageri in dataClasses.Pasageris
                       select new 
                       {   Pasageri.IDPasager,
                           Pasageri.Nume,
                           Pasageri.Prenume,
                           Pasageri.Email,
                           Pasageri.Parola
                       }).ToList();
            foreach (var aux in psg)
            {
                XElement pasager = new XElement("Pasager", new XAttribute("IDPasager", aux.IDPasager.ToString()),
                          new XElement("Nume", aux.Nume.ToString()),
                          new XElement("Prenume", aux.Prenume.ToString()),
                          new XElement("Email", aux.Email.ToString()),
                          new XElement("Parola", aux.Parola.ToString()));
                pasageri.Add(pasager);
            }
            baza.Add(pasageri);


            XElement bilete = new XElement("Bilete");
            var bil = (from Bilete in dataClasses.Biletes
                       select new
                       {
                           Bilete.IDBilet,
                           Bilete.IDPasager,
                           Bilete.IDTren,
                           Bilete.Pret,
                           Bilete.Statie_plecare,
                           Bilete.Statie_destinatie,
                           Bilete.Loc_pasager,
                           Bilete.Vagon
                       }).ToList();
            foreach (var aux in bil)
            {
                XElement bilet = new XElement("Bilet", new XAttribute("IDBilet", aux.IDBilet.ToString()),
                          new XElement("IDPasager", aux.IDPasager.ToString()),
                          new XElement("IDTren", aux.IDTren.ToString()),
                          new XElement("Pret", aux.Pret.ToString()),
                          new XElement("Statie_plecare", aux.Statie_plecare.ToString()),
                          new XElement("Statie_destinatie", aux.Statie_destinatie.ToString()),
                          new XElement("Loc_pasager", aux.Loc_pasager.ToString()),
                          new XElement("Vagon", aux.Vagon.ToString()));
                bilete.Add(bilet);
            }
            baza.Add(bilete);

            XElement trenuri = new XElement("Trenuri");
            var train = (from Trenuri in dataClasses.Trenuris
                         select new
                         {
                             Trenuri.IDTren,
                             Trenuri.Tip_Tren,
                             Trenuri.Numar_vagoane
                         }).ToList();
            foreach (var aux in train)
            {
                XElement tren = new XElement("Tren", new XAttribute("IDTren", aux.IDTren.ToString()),
                        new XElement("TipTren", aux.Tip_Tren.ToString()),
                        new XElement("NumarVagoane", aux.Numar_vagoane.ToString()));
                trenuri.Add(tren);
            }
            baza.Add(trenuri);

            XElement rute = new XElement("Rute");
            var rut = (from Rute in dataClasses.Rutes
                       select new
                       {
                           Rute.IDRuta,
                           Rute.IDTren,
                           Rute.IDStatie
                       }).ToList();
            foreach (var aux in rut)
            {
                XElement ruta = new XElement("Ruta", new XAttribute("IDRuta", aux.IDRuta.ToString()),
                          new XElement("IDPasager", aux.IDTren.ToString()),
                          new XElement("IDTren", aux.IDStatie.ToString()));
                rute.Add(ruta);
            }
            baza.Add(rute);

            XElement programe = new XElement("Programe");
            var prog = (from Program in dataClasses.Programs
                       select new
                       {
                           Program.Ziua,
                           Program.IDRuta,
                           Program.Ora_sosire,
                           Program.Ora_plecare,
                           Program.Intarzieri
                       }).ToList();
            foreach (var aux in prog)
            {
                string ora_s, ora_p, intarz;
                if (aux.Ora_sosire == null)
                    ora_s = "";
                else
                    ora_s= aux.Ora_sosire.ToString();
                if (aux.Ora_plecare == null)
                    ora_p = "";
                else
                    ora_p = aux.Ora_plecare.ToString();
                if (aux.Intarzieri == null)
                    intarz = "";
                else
                    intarz = aux.Intarzieri.ToString();


                XElement program = new XElement("Program", new XAttribute("Ziua", aux.Ziua.ToString()),
                          new XElement("IDRuta", aux.IDRuta.ToString()),
                          new XElement("Ora_sosire", ora_s),
                          new XElement("Ora_plecare", ora_p),
                          new XElement("Ora_plecare", intarz));
                programe.Add(program);
            }
            baza.Add(programe);

            XElement vagoane = new XElement("Vagoane");
            var vag = (from Vagon in dataClasses.Vagoanes
                        select new
                        {
                            Vagon.IDVagon,
                            Vagon.IDTren,
                            Vagon.Tip_vagon,
                            Vagon.Numar_locuri,
                            Vagon.Numar_vagon
                        }).ToList();
            foreach (var aux in vag)
            {
                XElement vagon = new XElement("Vagon", new XAttribute("IDVagon", aux.IDVagon.ToString()),
                          new XElement("IDTren", aux.IDTren.ToString()),
                          new XElement("Tip_vagon", aux.Tip_vagon.ToString()),
                          new XElement("Numar_locuri", aux.Numar_locuri.ToString()),
                          new XElement("Numar_vagon", aux.Numar_vagon.ToString()));
                vagoane.Add(vagon);
            }
            baza.Add(vagoane);

            XElement statii = new XElement("Statii");
            var stations = (from Statii in dataClasses.Statiis
                            select new
                            {
                                Statii.IDStatie,
                                Statii.Nume_statie
                            }).ToList();
            foreach (var aux in stations)
            {
                XElement statie = new XElement("Statie", new XAttribute("IDStatie", aux.IDStatie.ToString()),
                        new XElement("NumeStatie", aux.Nume_statie.ToString()));
                statii.Add(statie);
            }
            baza.Add(statii);

            xmldocument.Add(baza);
            xmldocument.Save("MersulTrenurilor.xml");

            MessageBox.Show("Baza de date a fost exportata in fisierul (MersulTrenurilor.xml)!");
            this.Close();
        }

        private void DeleteStationBtn_Click(object sender, RoutedEventArgs e)
        {
            Chose chose = new Chose();
            chose.Show();
            this.Close();
        }
    }
}
