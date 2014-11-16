using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClassLibraryCalculator;
using ClassLibraryCalculator.NumberClass;

namespace ClassLibraryCalculatorTests
{
    public class ClculatorWithRPNTests
    {
        [Test]
        public void GetExpression_CheckExpression()
        {
            var calculator = new CalculationWithRPN();
            plusOperator plus = new plusOperator();
            minusOperator minus = new minusOperator();
            multiplicationOperator multiplication = new multiplicationOperator();
            divisionOperator division = new divisionOperator();
            calculator.AddOperator(plus).AddOperator(minus).AddOperator(division).AddOperator(multiplication);
            string expression = "(4*2.3-5/2)+(2+4-3/1,5)-1";
            IEnumerable<ITerm> checkResult = new List<ITerm>()
            {
                new Number(){Value = (double)4},
                new Number(){Value = 2.3},
                multiplication,
                new Number(){Value = (double)5},
                new Number(){Value = (double)2},
                division,
                minus,
                new Number(){Value = (double)2},
                new Number(){Value = (double)4},
                plus,
                new Number(){Value = (double)3},
                new Number(){Value = 1.5},
                division,
                minus,
                plus,
                new Number(){Value = (double)1},
                minus
            };
            Class1 myComprer = new Class1();
            IEnumerable<ITerm> result = calculator.GetExpression(expression);
            Assert.That(result, Is.EqualTo(checkResult).Using(myComprer));
        }

        [Test]
        public void GetExpression_InvalidSymbols_ExceptionInvalidSimbols()
        {
            var calculator = new CalculationWithRPN();
            plusOperator plus = new plusOperator();
            minusOperator minus = new minusOperator();
            multiplicationOperator multiplication = new multiplicationOperator();
            divisionOperator division = new divisionOperator();
            calculator.AddOperator(plus).AddOperator(minus).AddOperator(division).AddOperator(multiplication);
            string expression = "1+2qwerty*3";
            var res = Assert.Throws<Exception>(()=>calculator.GetExpression(expression));
            Assert.That(res.Message, Is.EqualTo("Invalid symbols in the mathematical expression"));
        }

        [Test]
        public void GetExpression_ExpressionWithImproperPlacementParentheses_Exception()
        {
            var calculator = new CalculationWithRPN();
            plusOperator plus = new plusOperator();
            minusOperator minus = new minusOperator();
            multiplicationOperator multiplication = new multiplicationOperator();
            divisionOperator division = new divisionOperator();
            calculator.AddOperator(plus).AddOperator(minus).AddOperator(division).AddOperator(multiplication);
            string expression = ")9+1";
            var res = Assert.Throws<Exception>(() => calculator.GetExpression(expression));
            Assert.That(res.Message, Is.EqualTo("improper placement of parentheses"));
        }

        [Test]
        public void CalculateOnString_CheckCalculateToExpression()
        {
            var calculator = new CalculationWithRPN();
            plusOperator plus = new plusOperator();
            minusOperator minus = new minusOperator();
            multiplicationOperator multiplication = new multiplicationOperator();
            divisionOperator division = new divisionOperator();
            calculator.AddOperator(plus).AddOperator(minus).AddOperator(division).AddOperator(multiplication);
            IEnumerable<ITerm> expression = new List<ITerm>()
            {
                new Number(){Value = (double)4},
                new Number(){Value = 2.3},
                multiplication,
                new Number(){Value = (double)5},
                new Number(){Value = (double)2},
                division,
                minus,
                new Number(){Value = (double)2},
                new Number(){Value = (double)4},
                plus,
                new Number(){Value = (double)3},
                new Number(){Value = 1.5},
                division,
                minus,
                plus,
                new Number(){Value = (double)1},
                minus
            };
            var result = calculator.CalculateOnString(expression);
            Assert.That(result.Value,Is.EqualTo(9.7));
        }

        [Test]
        public void Calculation_CheckCalculate()
        {
            var calculator = new CalculationWithRPN();
            plusOperator plus = new plusOperator();
            minusOperator minus = new minusOperator();
            multiplicationOperator multiplication = new multiplicationOperator();
            divisionOperator division = new divisionOperator();
            calculator.AddOperator(plus).AddOperator(minus).AddOperator(division).AddOperator(multiplication);
            string expression = "(4*2.3-5/2)+(2+4-3/1,5)-1";
            var result = calculator.Calculation(expression);
            Assert.That(result.Value, Is.EqualTo(9.7));
        }
    }
}
