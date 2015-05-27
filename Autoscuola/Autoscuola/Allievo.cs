using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoscuola
{
    class Allievo
    {
        private static int _MAXQUOTAGUIDA = 100;        //massimo importo "da pagare"
        private static int _COSTOGUIDA = 20;            //costo di una guida


        private String _nome;
        private String _cognome;
        private DateTime _dataNascita;
        private List<Patente> _patentiPossedute = new List<Patente>();
        private Patente _patenteDaConseguire;
        private int _quotaGuide;                        //quota delle guide DA PAGARE
        private int _quotaPagata;                       //quota delle guide PAGATA
        private Boolean _visitaMedica;
        
        public Allievo(String nome,String cognome,DateTime dataNascita,Patente patenteDaConseguire)
        {
            _nome = nome;
            _cognome = cognome;
            _dataNascita = dataNascita;
            _patenteDaConseguire = patenteDaConseguire;
            _quotaGuide = 0;
            _quotaPagata = 0;
        }

        public Allievo(String nome,String cognome,DateTime dataNascita,Patente patenteDaConseguire,List<Patente> patenti) 
            : this (nome, cognome, dataNascita,patenteDaConseguire)
        {
            _patentiPossedute = patenti;
        }

        #region proprieta
        public List<Patente> Patente
        {
            set
            {
                _patentiPossedute = value;
            }
            get
            {
                return _patentiPossedute;
            }
        }

        public String Nome
        {
            get
            {
                return _nome;
            }
        }

        public String Cognome
        {
            get
            {
                return _cognome;
            }
        }

        public DateTime DataNascita
        {
            get
            {
                return _dataNascita;
            }
        }

        public Patente PatenteDaConseguire
        {
            get
            {
                return _patenteDaConseguire;
            }
            set
            {
                _patenteDaConseguire = value;
            }
        }

        public int QuotaGuide
        {
            get
            {
                return _quotaGuide;
            }
        }

        public int QuotaPagata
        {
            get
            {
                return _quotaPagata;
            }
        }

        public Boolean VisitaMedica
        {
            get
            {
                return _visitaMedica;
            }
            set
            {
                _visitaMedica = value;
            }
        }
        #endregion

        public void AggiungiPatente(Patente patente)
        {
            if(!_patentiPossedute.Contains(patente))
                _patentiPossedute.Add(patente);

            else
            Console.WriteLine("Patente " + patente + " gia posseduta da " + _nome);
        }

        public Boolean AggiungiGuida()
        {
            if ((_quotaGuide + _COSTOGUIDA) < _MAXQUOTAGUIDA)
            {
                _quotaGuide += _COSTOGUIDA;
                return true;
            }
            else
            {
                Console.WriteLine("ERRORE: !(_quotaGuide + _COSTOGUIDA) < _MAXQUOTAGUIDA)");
                return false;
            }
        }

        public void AggiungiPagamento(int pagamento)
        {
            if (pagamento > 0 && pagamento < _quotaGuide)
            {
                _quotaPagata -= pagamento;
                return;
            }
            else
                Console.WriteLine("!pagamento > 0 && pagamento<_quotaGuide");
        }

    }
}
