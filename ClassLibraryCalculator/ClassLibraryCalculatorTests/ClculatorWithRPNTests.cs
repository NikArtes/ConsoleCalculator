using System;
using System.Collections.Generic;
using NUnit.Framework;
using ClassLibraryCalculator;
using ClassLibraryCalculator.NumberClass;

namespace ClassLibraryCalculatorTests
{
    [TestFixture]
    public class ClculatorWithRPNTests
    {
        private CalculationWithRPN _calculator;
        [SetUp]
        public void Init()
        {
            _calculator = new CalculationWithRPN();
            _calculator.AddOperator(new PlusOperator())
                .AddOperator(new MinusOperator())
                .AddOperator(new MultiplicationOperator())
                .AddOperator(new DivisionOperator());
        }

        [Test]
        public void GetExpression_CheckExpression()
        {
            const string expression = "(4*2.3-5/2)+(2+4-3/1,5)-1";
            IEnumerable<ITerm> checkResult = new List<ITerm>
            {
                new Number{Value = 4d},
                new Number{Value = 2.3},
                new MultiplicationOperator(),
                new Number{Value = 5d},
                new Number{Value = 2d},
                new DivisionOperator(),
                new MinusOperator(),
                new Number{Value = 2d},
                new Number{Value = 4d},
                new PlusOperator(),
                new Number{Value = 3d},
                new Number{Value = 1.5},
                new DivisionOperator(),
                new MinusOperator(),
                new PlusOperator(),
                new Number{Value = 1d},
                new MinusOperator()
            };
            var myComprer = new TermComparer();
            IEnumerable<ITerm> result = _calculator.GetExpression(expression);
            Assert.That(result, Is.EqualTo(checkResult).Using(myComprer));
        }

        [Test]
        public void GetExpression_InvalidSymbols_ExceptionInvalidSimbols()
        {
            const string expression = "1+2qwerty*3";
            var res = Assert.Throws<Exception>(()=>_calculator.GetExpression(expression));
            Assert.That(res.Message, Is.EqualTo("Invalid symbols in the mathematical expression"));
        }

        [Test]
        public void GetExpression_ExpressionWithImproperPlacementParentheses_Exception()
        {
            const string expression = ")9+1";
            var res = Assert.Throws<Exception>(() => _calculator.GetExpression(expression));
            Assert.That(res.Message, Is.EqualTo("improper placement of parentheses"));
        }

        [Test]
        public void CalculateOnString_CheckCalculateToExpression()
        {
            IEnumerable<ITerm> expression = new List<ITerm>
            {
                new Number{Value = 4d},
                new Number{Value = 2.3},
                new MultiplicationOperator(),
                new Number{Value = 5d},
                new Number{Value = 2d},
                new DivisionOperator(),
                new MinusOperator(),
                new Number{Value = 2d},
                new Number{Value = 4d},
                new PlusOperator(),
                new Number{Value = 3d},
                new Number{Value = 1.5},
                new DivisionOperator(),
                new MinusOperator(),
                new PlusOperator(),
                new Number{Value = 1d},
                new MinusOperator()
            };
            var result = _calculator.CalculateOnString(expression);
            Assert.That(result.Value,Is.EqualTo(9.7));
        }

        [Test]
        public void Calculation_CheckCalculate()
        {
            const string expression = "(4*2.3-5/2)+(2+4-3/1,5)-1";
            var result = _calculator.Calculation(expression);
            Assert.That(result.Value, Is.EqualTo(9.7));
        }
    }
}
