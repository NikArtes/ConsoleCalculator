using System;
using ClassLibraryCalculator;
using ClassLibraryCalculator.NumberClass;
using NUnit.Framework;

namespace ClassLibraryCalculatorTests
{
    class OperatorsAndNumbersTest
    {
        private INumber _five;
        private INumber _two;

        [SetUp]
        public void Init()
        {
            _five = new Number{Value = 5d};
            _two = new Number{Value = 2d};
        }

        [Test]
        public void DivisionOperator_5division0_Exception()
        {
            IOperator division = new DivisionOperator();
            INumber zero = new Number{ Value = 0 };
            var res = Assert.Throws<Exception>(() => division.Expression(_five, zero));
            Assert.That(res.Message, Is.EqualTo("you can not divide by zero"));
        }

        [Test]
        public void DivisionOperator_5division2_2point5()
        {
            IOperator division = new DivisionOperator();
            var res = division.Expression(_five, _two);
            Assert.That(res.Value, Is.EqualTo(2.5));
        }

        [Test]
        public void MinusOperator_5minus2_3()
        {
            IOperator minus = new MinusOperator();
            var res = minus.Expression(_five, _two);
            Assert.That(res.Value, Is.EqualTo(3));
        }

        [Test]
        public void MultiplicationOperator_5multiplication2_10()
        {
            IOperator multiplication = new MultiplicationOperator();
            var res = multiplication.Expression(_five, _two);
            Assert.That(res.Value,Is.EqualTo(10));
        }

        [Test]
        public void PlusOperator_5plus2_7()
        {
            IOperator plus = new PlusOperator();
            var res = plus.Expression(_five, _two);
            Assert.That(res.Value,Is.EqualTo(7));
        }
    }
}
