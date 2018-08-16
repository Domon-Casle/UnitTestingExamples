using System;
using System.Collections.Generic;
using System.Text;

namespace CardInterestCalculater.Classes
{
    public class CreditCard
    {
        #region Properties
        public CardType Type { get; set; }
        public double Balance { get; set; }
        #endregion

        #region Constructors
        public CreditCard()
        {

        }
        #endregion

        #region Methods
        public double Interest()
        {
            return Balance * CardInterests.CardInterestsRates[Type];
        }
        #endregion 
    }
}
