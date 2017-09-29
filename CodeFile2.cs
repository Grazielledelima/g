using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste_Online2;

namespace Teste_Online
{
    public class MercadoriaU
    {
        int _codigo;
        String _tipo;
        String _nome;
        int _quantidade;
        Decimal _preco;
        Decimal _total;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public String Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public String Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public Decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        public Decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
    }
}