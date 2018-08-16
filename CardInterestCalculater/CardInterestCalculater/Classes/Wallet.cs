using System;
using System.Collections.Generic;
using System.Text;

namespace CardInterestCalculater.Classes
{
    public class Wallet
    {
        #region Properties
        public List<CreditCard> Cards { get; set; }
        #endregion

        #region Constructors
        public Wallet()
        {
            Cards = new List<CreditCard>();
        }
        #endregion

        #region Methods
        public double Interest()
        {
            double total = 0;
            foreach(var card in Cards)
            {
                total += card.Interest();
            }

            return total;
        }
        #endregion
    }
}
