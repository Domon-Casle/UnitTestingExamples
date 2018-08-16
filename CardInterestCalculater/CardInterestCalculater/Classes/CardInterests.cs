using System;
using System.Collections.Generic;
using System.Text;

namespace CardInterestCalculater.Classes
{
    public static class CardInterests
    {
        #region Properties
        public static Dictionary<CardType, double> CardInterestsRates;
        #endregion

        #region Generator
        public static void BuildCards()
        {
            CardInterestsRates = new Dictionary<CardType, double>();
            CardInterestsRates.Add(CardType.Visa, 0.10);
            CardInterestsRates.Add(CardType.MasterCard, 0.05);
            CardInterestsRates.Add(CardType.Discover, 0.01);
        }
        #endregion
    }
}
