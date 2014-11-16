using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCalculator;
using ClassLibraryCalculator.NumberClass;
using NUnit.Framework;

namespace ClassLibraryCalculatorTests
{
    class OperatorsAndNumbersTest
    {
        [Test]
        public void DivisionOperator_5division0_Exception()
        {
            IOperator division = new divisionOperator();
            INumber five = new Number() { Value = (double)5 };
            INumber zero = new Number(){ Value = 0 };
            var res = Assert.Throws<Exception>(() => division.Expression(five, zero));
            Assert.That(res.Message, Is.EqualTo("you can not divide by zero"));
        }

        [Test]
        public void DivisionOperator_5division2_2point5()
        {
            IOperator division = new divisionOperator();
            INumber five = new Number(){Value = (double)5};
            INumber two = new Number(){Value = (double)2};
            var res = division.Expression(five, two);
            Assert.That(res.Value, Is.EqualTo(2.5));
        }

        [Test]
        public void MinusOperator_5minus2_3()
        {
            IOperator minus = new minusOperator();
            INumber five = new Number(){Value = 5};
            INumber two = new Number(){Value = 2};
            var res = minus.Expression(five, two);
            Assert.That(res.Value, Is.EqualTo(3));
        }

        [Test]
        public void MultiplicationOperator_5multiplication2_10()
        {
            IOperator multiplication = new multiplicationOperator();
            INumber five = new Number(){Value = 5};
            INumber two = new Number(){Value = 2};
            var res = multiplication.Expression(five, two);
            Assert.That(res.Value,Is.EqualTo(10));
        }

        [Test]
        public void PlusOperator_5plus2_7()
        {
            IOperator plus = new plusOperator();
            INumber five = new Number(){Value = 5};
            INumber two = new Number(){Value = 2};
            var res = plus.Expression(five, two);
            Assert.That(res.Value,Is.EqualTo(7));
        }
    }
}
