namespace dotless.Test.Specs.Functions
{
    using NUnit.Framework;

    public class GrayscaleFixture : SpecFixtureBase
    {
        [Test]
        public void TestGrayscale()
        {
            AssertExpression("#bbbbbb", "grayscale(#abc)");
            AssertExpression("gray", "grayscale(#f00)");
            AssertExpression("gray", "grayscale(#00f)");
            AssertExpression("white", "grayscale(#fff)");
            AssertExpression("black", "grayscale(#000)");
        }

        [Test]
        public void TestGreyscale()
        {
            AssertExpression("#bbbbbb", "greyscale(#abc)");
            AssertExpression("gray", "greyscale(#f00)");
            AssertExpression("gray", "greyscale(#00f)");
            AssertExpression("white", "greyscale(#fff)");
            AssertExpression("black", "greyscale(#000)");
        }

        [Test]
        public void TestEditGrayscaleWarning()
        {
            var alphaWarning = "grayscale(color) is not supported by less.js, so this will work but not compile with other less implementations." +
                " You may want to consider using greyscale(color) which does the same thing and is supported.";

            AssertExpressionLogMessage(alphaWarning, "grayscale(#00f)");
            AssertExpressionNoLogMessage(alphaWarning, "greyscale(#00f)");
        }

        [Test]
        public void TestGrayscaleTestsTypes()
        {
            AssertExpressionError("Expected color in function 'grayscale', found \"foo\"", 10, "grayscale(\"foo\")");
        }
    }
}