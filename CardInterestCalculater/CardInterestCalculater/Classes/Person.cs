using System;
using System.Collections.Generic;
using System.Text;

namespace CardInterestCalculater.Classes
{
    public class Person
    {
        #region Properties
        public List<Wallet> Wallets { get; set; }
        #endregion

        #region Constructors
        public Person()
        {
            Wallets = new List<Wallet>();
        }
        #endregion

        #region Methods
        public double Interest()
        {
            double total = 0;
            foreach(var wallet in Wallets)
            {
                total += wallet.Interest();
            }

            return total;
        }
        #endregion
    }
}
