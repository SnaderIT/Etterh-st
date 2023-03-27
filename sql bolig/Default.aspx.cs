using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DataTableSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBLayer layer = new DBLayer();
            LabelNumBoliger.Text = GetNumOfBoliger().ToString();//hvorfor ToString her?
            //ShowEiereWithPostStedUsingLINQ();//tester ut datatable og linq

           

        }

        /// <summary>
        /// Teller hvor mange boliger det er i tabellen Bolig. Returnerer kun et tall. Er det OK å ha en slik metode i her?
        /// </summary>
        private int GetNumOfBoliger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(BoligId) from Bolig", conn);
                cmd.CommandType = CommandType.Text;
                int num = (Int32)cmd.ExecuteScalar();//returner den første raden og den første kolonnen. sjekk i sql manager. Unboxing eksempel.

                conn.Close();
                return num;
            }
            
        }

        /// <summary>
        /// LINQ-utfordring, anonyme typer (classes)
        /// </summary>
        private void ShowEiereWithPostStedUsingLINQ()
        {
            //dette prosjektet kjører på vår databaseserver, så dere trenger ikke mekke noen database selv
            //La oss anta at vi ikke har noen klasser, kun et databaselag som gir oss datatables.
            //alt fra alle tabellene, som er select *  from tablename
            //så hvordan kan vi da få ut info på tvers av tabeller, når vi ikke har noe sql med JOIN?
            //det vi er ute etter er å vise alle eiere, men også med poststed. Poststed ligger i postnummertabellen
            //så vi må bruke linq til å joine 2 tabeller, på samme måte som i sql
            //select Eier.EierId,Eier.Adresse,Eier.EtterNavn,Eier.ForNavn,PostNummer.PostSted,PostNummer.PostNummer
            //from Eier
            //INNER JOIN PostNummer ON PostNummer.PostNummer = Eier.PostNummer

            DBLayer layer = new DBLayer();
            //Hente alt fra tabellen Eier
            var eiereDataTable = layer.GetAllEier().AsEnumerable();
            //alt fra postnummertabellen
            var postNummerDataTable = layer.GetAllPostNummer();

            //Anonymous Type postNummers. Vil da inneholde alt fra postnummertabellen https://www.tutorialsteacher.com/csharp/csharp-anonymous-type
            var postNummers = (from DataRow row in postNummerDataTable.Rows
                               select new
                               {
                                   PostNummer = row["PostNummer"].ToString(),
                                   PostSted = row["PostSted"].ToString()
                               }).ToList();//denne gjør om alt til en liste av anonymous types
            //todo
            //nok en liste, som over, med eiere
            //bruke linq til å joine, slik at vi får ut alle eiere, pluss stedsnavn fra postnummer tabellen
            //koble de til GridViewen under.

            //litt eksempelkode

            //List<ObjectA> listOfA = ...;
            //List<ObjectB> listOfB = ...;
            //var all = from a in listOfA
            //          join b in listOfB on a.code equals b.code
            //          select new { a, b };

            //List<ObjectA> listA = ...;
            //List<ObjectB> listB = ...;
            //var all = listB.Where(b => listA.Any(a => a.code == b.code));

            //https://dotnettutorials.net/lesson/inner-join-in-linq/
            //https://www.geeksforgeeks.org/linq-join-inner-join/

            //GridViewBoligEiere.DataSource = <dinListe>;
            //GridViewBoligEiere.DataBind();

            //*************  om dere fikk taket på den over, hva med å koble sammen 3 lister slik at vi får ut boliger og hvem den eies av
        }

        protected void ButtonSearchByPhone_Click(object sender, EventArgs e)
        {
            DBLayer dbl = new DBLayer();
            GridViewBoligEiere.DataSource=dbl.GetBoligAndOwnersByTelefon(TextBoxSearchByPhone.Text);
            GridViewBoligEiere.DataBind();  
        }
    }
}