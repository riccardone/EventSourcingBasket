using System;
using System.Linq;
using Domain.Aggregates;
using Domain.Messages.Commands;
using Domain.Services;
using Xunit;

namespace Tests
{
    public class BasketTests
    {
        [Fact]
        public void ShouldCreateAValidBasket()
        {
            // set up
            var basketId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var cmd = new CreateBasket(basketId.ToString(), clientId.ToString());

            // act
            var results = Basket.Create(cmd);

            // verify
            Assert.True(results.First().Id.Equals(basketId.ToString()));
        }

        [Fact]
        public void Given_the_basket_has_2_butter_and_2_bread_when_I_total_the_basket_then_the_total_should_be_3_10()
        {
            // set up
            var basketId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var createCommand = new CreateBasket(basketId.ToString(), clientId.ToString());
            var buyButterCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Butter", 0.80m);
            var buyButterCommand2 = new AddProduct(createCommand.Id, basketId.ToString(), "Butter", 0.80m);
            var buyBreadCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Bread", 1.00m);
            var buyBreadCommand2 = new AddProduct(createCommand.Id, basketId.ToString(), "Bread", 1.00m);
            var inMemoryModel = new TestModel();

            // act
            inMemoryModel.Save(
                Basket.CheckOut(
                    Basket.Buy(
                        Basket.Buy(
                            Basket.Buy(Basket.Buy(Basket.Create(createCommand), buyButterCommand1), buyButterCommand2),
                            buyBreadCommand1), buyBreadCommand2), new SimpleDiscountService()));

            // verify
            Assert.True(inMemoryModel.GetBasketTotal().Equals(3.10m), $"expected £3.10 but was {inMemoryModel.GetBasketTotal()}");
        }

        [Fact]
        public void Given_the_basket_has_1_butter_and_1_bread_and_1_Milk_when_I_total_the_basket_then_the_total_should_be_2_95()
        {
            // set up
            var basketId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var createCommand = new CreateBasket(basketId.ToString(), clientId.ToString());
            var buyButterCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Butter", 0.80m);
            var buyBreadCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Bread", 1.00m);
            var buyMilkCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var inMemoryModel = new TestModel();

            // act
            inMemoryModel.Save(
                Basket.CheckOut(
                    Basket.Buy(
                        Basket.Buy(Basket.Buy(Basket.Create(createCommand), buyButterCommand1), buyBreadCommand1),
                        buyMilkCommand1), new SimpleDiscountService()));

            // verify
            Assert.True(inMemoryModel.GetBasketTotal().Equals(2.95m), $"expected £2.95 but was {inMemoryModel.GetBasketTotal()}");
        }

        [Fact]
        public void Given_the_basket_has_4_milk_when_I_total_the_basket_then_the_total_should_be_3_45()
        {
            // set up
            var basketId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var createCommand = new CreateBasket(basketId.ToString(), clientId.ToString());
            var buyMilkCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand2 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand3 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand4 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var inMemoryModel = new TestModel();

            // act
            inMemoryModel.Save(
                Basket.CheckOut(
                    Basket.Buy(
                        Basket.Buy(
                            Basket.Buy(Basket.Buy(Basket.Create(createCommand), buyMilkCommand1), buyMilkCommand2),
                            buyMilkCommand3), buyMilkCommand4), new SimpleDiscountService()));

            // verify
            Assert.True(inMemoryModel.GetBasketTotal().Equals(3.45m), $"expected £3.45 but was {inMemoryModel.GetBasketTotal()}");
        }

        [Fact]
        public void Given_the_basket_has_2_butter_1_bread_and_8_milk_when_I_total_the_basket_then_the_total_should_be_9_00()
        {
            // set up
            var basketId = Guid.NewGuid();
            var clientId = Guid.NewGuid();
            var createCommand = new CreateBasket(basketId.ToString(), clientId.ToString());
            var buyButterCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Butter", 0.80m);
            var buyButterCommand2 = new AddProduct(createCommand.Id, basketId.ToString(), "Butter", 0.80m);
            var buyMilkCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand2 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand3 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand4 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand5 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand6 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand7 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyMilkCommand8 = new AddProduct(createCommand.Id, basketId.ToString(), "Milk", 1.15m);
            var buyBreadCommand1 = new AddProduct(createCommand.Id, basketId.ToString(), "Bread", 1.00m);
            var inMemoryModel = new TestModel();

            // act
            inMemoryModel.Save(
                Basket.CheckOut(
                    Basket.Buy(
                        Basket.Buy(
                            Basket.Buy(
                                Basket.Buy(
                                    Basket.Buy(
                                        Basket.Buy(
                                            Basket.Buy(
                                                Basket.Buy(
                                                    Basket.Buy(
                                                        Basket.Buy(
                                                            Basket.Buy(Basket.Create(createCommand), buyMilkCommand1),
                                                            buyMilkCommand2), buyMilkCommand3), buyMilkCommand4),
                                                buyMilkCommand5), buyMilkCommand6), buyMilkCommand7), buyMilkCommand8),
                                buyButterCommand1), buyBreadCommand1), buyButterCommand2), new SimpleDiscountService()));

            // verify
            Assert.True(inMemoryModel.GetBasketTotal().Equals(9.00m), $"expected £9.00 but was {inMemoryModel.GetBasketTotal()}");
        }

    }
}
