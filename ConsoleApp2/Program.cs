using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CurriculumVitae CV = new CurriculumVitae();
            InfoPersonali infoCurriculum = new InfoPersonali("Luigi", "Crisci", "3661593103", "luigicr95@gmail.com");
            //Console.WriteLine(infoCurriculum.Email);
            Studi studiCurriculum = new Studi("Diploma Liceo Classico", "Liceo Classico V.Imbriani", "Scuola Secondaria Secondo grado", new DateTime(2009, 09,02), new DateTime(2014, 06, 20));
            //Console.WriteLine(studiCurriculum.Dal);
            Esperienza esperienzaCurriculum1 = new Esperienza("Università Federico II", "Assistente di scavo e laboratorio", "Analisi e classificazione reperti", "Analisi e classificazione reperti", new DateTime(2016, 04, 12), new DateTime(2017, 08, 23));
            Esperienza esperienzaCurriculum2 = new Esperienza("Pret-a-Manger", "Team manager", "Settore cucina", "Coordinamento staff cucine", new DateTime(2018, 02, 21), new DateTime(2019, 05, 27));
            Impiego impieghiCurriculum1 = new Impiego(esperienzaCurriculum1);
            Impiego impieghiCurriculum2 = new Impiego(esperienzaCurriculum2);
            CV.InformazioniPersonali = infoCurriculum;
            CV.StudiEffettuati = studiCurriculum;
            CV.Impieghi.Add(impieghiCurriculum1);
            CV.Impieghi.Add(impieghiCurriculum2);
            //Console.WriteLine(CV.Impieghi[0].Esperienza.azienda);

            CV.StampaDettagliCVaSchermo(CV);


            Console.ReadLine();
        }

        public class CurriculumVitae
        {
            public InfoPersonali InformazioniPersonali { get; set; }
            public Studi StudiEffettuati { get; set; }
            public List<Impiego> Impieghi { get; set; } = new List<Impiego>();

            public void StampaDettagliCVaSchermo(CurriculumVitae curriculum)
            {
                Console.WriteLine($"++++ Informazioni Personali: ++++ \r\nNome: {curriculum.InformazioniPersonali.Nome} \r\nCognome: {curriculum.InformazioniPersonali.Cognome} \r\n" +
                    $"Email: {curriculum.InformazioniPersonali.Email} \r\nTelefono:{curriculum.InformazioniPersonali.Telefono}\r\n \r\n" +
                    $"++++ Studi e Formazione: ++++ \r\nIstituto: {curriculum.StudiEffettuati.Istituto} \r\nQualifica: {curriculum.StudiEffettuati.Qualifica} \r\n" +
                    $"Tipo: {curriculum.StudiEffettuati.Tipo} \r\nDal: {curriculum.StudiEffettuati.Dal} al: {curriculum.StudiEffettuati.Al} \r\n \r\n++++ Esperienze professionali: ++++");

                foreach(Impiego item in curriculum.Impieghi)
                {
                    Console.WriteLine($"Presso: {item.Esperienza.azienda} \r\nTipo di lavoro: {item.Esperienza.JobTitle} \r\nCompito: {item.Esperienza.Compito} \r\n" +
                        $"Dal: {item.Esperienza.Dal} al: {item.Esperienza.Al}");
                }
            }
        }


        public class InfoPersonali
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }

            public InfoPersonali(string nome, string cognome, string telefono, string email) 
            {
                Nome = nome;
                Cognome = cognome;
                Telefono = telefono;
                Email = email;
            }
        }

        public class Studi
        {
            public string Qualifica { get; set; }
            public string Istituto { get; set; }
            public string Tipo { get; set; }
            public DateTime Dal { get; set; }
            public DateTime Al { get; set; }

            public Studi(string qualifica, string istituto, string tipo, DateTime dal, DateTime al)
            {
                Qualifica = qualifica;
                Istituto = istituto;
                Tipo = tipo;
                Dal = dal;
                Al = al;
            }
        }

        public class Impiego
        {
            public Esperienza Esperienza { get; set; }

            public Impiego(Esperienza esperienza)
            {
                Esperienza = esperienza;
            }
        }

        public class Esperienza
        {
            public string azienda { get; set; }
            public string JobTitle { get; set; }
            public string Descrizione { get; set; }
            public string Compito { get; set; }
            public DateTime Dal { get; set; }
            public DateTime Al { get; set; }

            public Esperienza(string azienda, string jobTitle, string descrizione, string compito, DateTime dal, DateTime al)
            {
                this.azienda = azienda;
                JobTitle = jobTitle;
                Descrizione = descrizione;
                Compito = compito;
                Dal = dal;
                Al = al;
            }
        }
    }
}
