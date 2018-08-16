using CardInterestCalculater.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardInterestCalculaterTewst
{
    [TestClass]
    public class UnitTest1
    {
        #region Tests for classes
        [TestMethod]
        public void TestCardRates()
        {
            CardInterests.BuildCards();

            foreach(var card in CardInterests.CardInterestsRates)
            {
                switch(card.Key)
                {
                    case CardType.Visa:
                        Assert.IsTrue(card.Value == 0.10);
                        break;

                    case CardType.MasterCard:
                        Assert.IsTrue(card.Value == 0.05);
                        break;

                    case CardType.Discover:
                        Assert.IsTrue(card.Value == 0.01);
                        break;

                    default:
                        Assert.Fail();
                        break;
                }
            }
        }

        [TestMethod]
        public void TestCreditCard()
        {
            CardInterests.BuildCards();

            CreditCard discoverCard = new CreditCard()
            {
                Type = CardType.Discover,
                Balance = 100
            };

            CreditCard undefinedCard = new CreditCard();

            Assert.IsTrue(discoverCard.Interest() == 1);
            Assert.IsTrue(undefinedCard.Interest() == 0);
        }

        [TestMethod]
        public void TestWallet()
        {
            CardInterests.BuildCards();

            Wallet oneCardWallet = new Wallet()
            {
                Cards = new List<CreditCard>()
                {
                    new CreditCard()
                    {
                        Type = CardType.Visa,
                        Balance = 100
                    }
                }
            };

            Wallet twoCardWallet = new Wallet()
            {
                Cards = new List<CreditCard>()
                {
                    new CreditCard()
                    {
                        Type = CardType.Visa,
                        Balance = 100
                    },
                    new CreditCard()
                    {
                        Type = CardType.Discover,
                        Balance = 100
                    }
                }
            };

            Wallet emtpyWallet = new Wallet();

            Assert.IsTrue(oneCardWallet.Interest() == 10);
            Assert.IsTrue(twoCardWallet.Interest() == 11);
            Assert.IsTrue(emtpyWallet.Interest() == 0);
        }

        [TestMethod]
        public void TestPerson()
        {
            CardInterests.BuildCards();

            Person oneWalletPerson = new Person()
            {
                Wallets = new List<Wallet>()
                {
                    new Wallet()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.Visa,
                                Balance = 100
                            }
                        }
                    }
                }
            };

            Person twoWalletPerson = new Person()
            {
                Wallets = new List<Wallet>()
                {
                    new Wallet()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.Visa,
                                Balance = 100
                            }
                        }
                    }, 
                    new Wallet()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.Discover,
                                Balance = 100
                            }
                        }
                    }
                }
            };

            Person noPerson = new Person();

            Assert.IsTrue(oneWalletPerson.Interest() == 10);
            Assert.IsTrue(twoWalletPerson.Interest() == 11);
            Assert.IsTrue(noPerson.Interest() == 0);
        }
        #endregion

        #region Overall tests
        [TestMethod]
        public void TestCase1()
        {
            CardInterests.BuildCards();

            Person personA = new Person()
            {
                Wallets = new List<Wallet>()
                {
                    new Wallet ()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.Visa,
                                Balance = 100
                            }, 
                            new CreditCard()
                            {
                                Type = CardType.Discover,
                                Balance = 100
                            },
                            new CreditCard()
                            {
                                Type = CardType.MasterCard,
                                Balance = 100
                            }
                        }
                    }
                }
            };

            Assert.IsTrue(personA.Interest() == 16);
            foreach (var wallet in personA.Wallets)
            {
                foreach (var card in wallet.Cards)
                {
                    if (card.Type == CardType.Discover)
                    {
                        Assert.IsTrue(card.Interest() == (card.Balance * CardInterests.CardInterestsRates[card.Type]));
                    }
                }
            }
        }

        [TestMethod]
        public void TestCase2()
        {
            CardInterests.BuildCards();

            Person personA = new Person()
            {
                Wallets = new List<Wallet>()
                {
                    new Wallet ()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.Visa,
                                Balance = 100
                            },
                            new CreditCard()
                            {
                                Type = CardType.Discover,
                                Balance = 100
                            }
                        }
                    }, 
                    new Wallet()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.MasterCard,
                                Balance = 100
                            }
                        }
                    }
                }
            };

            Assert.IsTrue(personA.Interest() == 16);
            Assert.IsTrue(personA.Wallets[0].Interest() == 11);
            Assert.IsTrue(personA.Wallets[1].Interest() == 5);
        }

        [TestMethod]
        public void TestCase3()
        {
            CardInterests.BuildCards();

            Person personA = new Person()
            {
                Wallets = new List<Wallet>()
                {
                    new Wallet ()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.MasterCard,
                                Balance = 100
                            },
                            new CreditCard()
                            {
                                Type = CardType.MasterCard,
                                Balance = 100
                            },
                            new CreditCard()
                            {
                                Type = CardType.Visa,
                                Balance = 100
                            }
                        }
                    }
                }
            };

            Assert.IsTrue(personA.Interest() == 20);
            Assert.IsTrue(personA.Wallets[0].Interest() == 20);

            Person personB = new Person()
            {
                Wallets = new List<Wallet>()
                {
                    new Wallet ()
                    {
                        Cards = new List<CreditCard>()
                        {
                            new CreditCard()
                            {
                                Type = CardType.MasterCard,
                                Balance = 100
                            },
                            new CreditCard()
                            {
                                Type = CardType.Visa,
                                Balance = 100
                            }
                        }
                    }
                }
            };

            Assert.IsTrue(personB.Interest() == 15);
            Assert.IsTrue(personB.Wallets[0].Interest() == 15);
        }
        #endregion
    }
}
