using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2223_4G_INF_Cangiotti_RubricaCSVMAUI
{
    internal class Contatto
    {
        string nome;
        string cognome;
        string citta;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Cognome
        {
            get { return cognome; }
            set { cognome = value; }
        }

        public string Citta
        {
            get { return citta; }
            set { citta = value; }
        }

        public Contatto(string record)
        {
            string[] supporto = record.Split(",");
            cognome = supporto[0];
            nome = supporto[1];
            citta = supporto[2];
        }

        public Contatto(string nome, string cognome, string citta)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.citta = citta;
        }
    }
}
