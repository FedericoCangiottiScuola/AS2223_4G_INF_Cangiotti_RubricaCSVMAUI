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

        public string getNome()
        {
            return nome;
        }

        public string getCognome()
        {
            return cognome;
        }

        public string getCitta()
        {
            return citta;
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
