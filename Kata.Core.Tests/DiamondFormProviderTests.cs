using System.Text.RegularExpressions;

namespace Kata.Core.Tests
{
    public class DiamondFormProviderTests
    {
        private const string CarriageReturnAndNewLine = "\r\n";

        private readonly DiamondFormProvider _sut;

        public DiamondFormProviderTests()
        {
            _sut = new DiamondFormProvider();
        }

        [Fact]
        public void DiamondFormProvider_ThrowsExceptions_When_CharIsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => _sut.GenerateForm(It.IsAny<char>()));
        }

        [Fact]
        public void DiamondFormProvider_GeneratesDiamondForm_OfSingleText_WhenCharInputIsA()
        {
            const char charA = 'A';

            var result = _sut.GenerateForm('A');

            Assert.Equal(charA + string.Empty, result);
        }

        [Theory]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('D')]
        [InlineData('E')]
        [InlineData('F')]
        [InlineData('G')]
        [InlineData('H')]
        [InlineData('I')]
        [InlineData('J')]
        [InlineData('K')]
        [InlineData('L')]
        [InlineData('M')]
        [InlineData('N')]
        [InlineData('O')]
        [InlineData('Q')]
        [InlineData('R')]
        [InlineData('S')]
        [InlineData('T')]
        [InlineData('U')]
        [InlineData('V')]
        [InlineData('W')]
        [InlineData('X')]
        [InlineData('Y')]
        [InlineData('Z')]
        public void DiamondFormProvider_GeneratesDiamondForm_WithCharA_Appearing1Time_AtTopAndBottomHorizontalLayers_AtCentre(char value)
        {
            // arrange 

            const char charA = 'A';

            // act

            var result = _sut.GenerateForm(value);

            // assert

            var horizontalLayers = result
                .Split(CarriageReturnAndNewLine)
                .ToList();

            Assert.True(horizontalLayers.Count >= 3, "There SHOULD be a top and bottom (and central) horizontal layer");

            var topLayer = horizontalLayers[0];
            var bottomLayer = horizontalLayers[^1];

            Assert.Single(Regex.Matches(topLayer, charA + string.Empty));
            Assert.Single(Regex.Matches(bottomLayer, charA + string.Empty));

            Assert.Equal(charA, topLayer[topLayer.Length / 2]);
            Assert.Equal(charA, bottomLayer[bottomLayer.Length / 2]);
            
            Assert.Equal(topLayer, bottomLayer);
        }

        [Theory]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('D')]
        [InlineData('E')]
        [InlineData('F')]
        [InlineData('G')]
        [InlineData('H')]
        [InlineData('I')]
        [InlineData('J')]
        [InlineData('K')]
        [InlineData('L')]
        [InlineData('M')]
        [InlineData('N')]
        [InlineData('O')]
        [InlineData('Q')]
        [InlineData('R')]
        [InlineData('S')]
        [InlineData('T')]
        [InlineData('U')]
        [InlineData('V')]
        [InlineData('W')]
        [InlineData('X')]
        [InlineData('Y')]
        [InlineData('Z')]
        public void DiamondFormProvider_GeneratesDiamondForm_WithCharInput_Appearing2Times_InCentreHorizontalLayer_AtEnds(char value)
        {
            // act

            var result = _sut.GenerateForm(value);

            // assert

            var horizontalLayers = result
                .Split(CarriageReturnAndNewLine)
                .ToList();
            
            Assert.True(horizontalLayers.Count % 2 == 1, "There SHOULD be a central horizontal layer");

            var centralLayer = horizontalLayers[horizontalLayers.Count / 2];

            Assert.Equal(2, Regex.Matches(centralLayer, value + string.Empty).Count);

            Assert.Equal(value, centralLayer.First());
            Assert.Equal(value, centralLayer.Last());
            
            Assert.Equal(centralLayer.First(), centralLayer.Last());
        }
        
        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('D')]
        [InlineData('E')]
        [InlineData('F')]
        [InlineData('G')]
        [InlineData('H')]
        [InlineData('I')]
        [InlineData('J')]
        [InlineData('K')]
        [InlineData('L')]
        [InlineData('M')]
        [InlineData('N')]
        [InlineData('O')]
        [InlineData('Q')]
        [InlineData('R')]
        [InlineData('S')]
        [InlineData('T')]
        [InlineData('U')]
        [InlineData('V')]
        [InlineData('W')]
        [InlineData('X')]
        [InlineData('Y')]
        [InlineData('Z')]
        public void DiamondFormProvider_GeneratesDiamondForm_WithChars_InSequenceOfAscendingThenDescending(char value)
        {
            // act

            var result = _sut.GenerateForm(value);

            // assert

            var horizontalChars = result
                .Split(CarriageReturnAndNewLine)
                .Select(hl => hl.Replace(" ", string.Empty).Distinct())
                .ToList();

            foreach (var horizontalChar in horizontalChars)
            {
                Assert.Single(horizontalChar);
            }

            var diamondCentreChar = horizontalChars[horizontalChars.Count / 2].Single();

            var diamondTopChars = horizontalChars.SelectMany(c => c).Take(horizontalChars.Count / 2).ToList();
            var diamondBottomChars = horizontalChars.SelectMany(c => c).Skip(horizontalChars.Count / 2 + 1).Take(horizontalChars.Count / 2).ToList();

            var diamondTopCharsOrderedAscending = diamondTopChars.OrderBy(c => c).ToList();
            var diamondBottomCharsOrderedDescending = diamondTopChars.OrderByDescending(c => c).ToList();

            Assert.True(diamondTopCharsOrderedAscending.SequenceEqual(diamondTopChars));
            Assert.Equal(value, diamondCentreChar);
            Assert.True(diamondBottomCharsOrderedDescending.SequenceEqual(diamondBottomChars));
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('D')]
        [InlineData('E')]
        [InlineData('F')]
        [InlineData('G')]
        [InlineData('H')]
        [InlineData('I')]
        [InlineData('J')]
        [InlineData('K')]
        [InlineData('L')]
        [InlineData('M')]
        [InlineData('N')]
        [InlineData('O')]
        [InlineData('Q')]
        [InlineData('R')]
        [InlineData('S')]
        [InlineData('T')]
        [InlineData('U')]
        [InlineData('V')]
        [InlineData('W')]
        [InlineData('X')]
        [InlineData('Y')]
        [InlineData('Z')]
        public void DiamondFormProvider_GeneratesDiamondForm_WithCharInput_Appearing4Times_ExceptCharInputAndCharA(char value)
        {
            // act

            var result = _sut.GenerateForm(value);

            // assert

            var distinctChars = new string(result.Distinct().ToArray())
                .Replace(" ", string.Empty)
                .Replace(CarriageReturnAndNewLine, string.Empty)
                .Replace(value + string.Empty, string.Empty)
                .Replace("A", string.Empty);

            foreach (var distinctChar in distinctChars)
            {
                Assert.Equal(4, Regex.Matches(result, distinctChar + string.Empty).Count);
            }
        }


        [Fact]
        public void DiamondFormProvider_GeneratesDiamondForm_WithNoWhiteSpace_WhenCharInputIsA()
        {
            // arrange

            char value = 'A';

            // act

            var result = _sut.GenerateForm(value);

            // assert

            var horizontalLayers = result
                .Split(CarriageReturnAndNewLine)
                .ToList();

            foreach (var horizontalLayer in horizontalLayers.Where(hs => hs.Contains(value)))
            {
                var charsInHorizontalLayer = horizontalLayer.Replace(" ", string.Empty);

                var distinctChars = charsInHorizontalLayer.Distinct().ToList();

                Assert.NotNull(distinctChars);
                Assert.Single(distinctChars);

                var firstIndexOccurrence = horizontalLayer.IndexOf(distinctChars.First());
                var secondIndexOccurrence = horizontalLayer.LastIndexOf(distinctChars.Last());

                Assert.Equal(1, charsInHorizontalLayer.Length);

                Assert.Equal(firstIndexOccurrence, secondIndexOccurrence);
            }
        }

        [Theory]
        [InlineData('B', 1)]
        [InlineData('C', 3)]
        [InlineData('D', 5)]
        [InlineData('E', 7)]
        [InlineData('F', 9)]
        [InlineData('G', 11)]
        [InlineData('H', 13)]
        [InlineData('I', 15)]
        [InlineData('J', 17)]
        [InlineData('K', 19)]
        [InlineData('L', 21)]
        [InlineData('M', 23)]
        [InlineData('N', 25)]
        [InlineData('O', 27)]
        [InlineData('P', 29)]
        [InlineData('Q', 31)]
        [InlineData('R', 33)]
        [InlineData('S', 35)]
        [InlineData('T', 37)]
        [InlineData('U', 39)]
        [InlineData('V', 41)]
        [InlineData('W', 43)]
        [InlineData('X', 45)]
        [InlineData('Y', 47)]
        [InlineData('Z', 49)]
        public void DiamondFormProvider_GeneratesDiamondForm_WithCorrectWhiteSpace_InEachHorizontalLayer(char value, int gap)
        {
            // act

            var result = _sut.GenerateForm(value);

            // assert

            var horizontalLayers = result
                .Split(CarriageReturnAndNewLine)
                .ToList();

            foreach (var horizontalLayer in horizontalLayers.Where(hs => hs.Contains(value)))
            {
                var charsInHorizontalLayer = horizontalLayer.Replace(" ", string.Empty);
                
                var distinctChars = charsInHorizontalLayer.Distinct().ToList();

                Assert.NotNull(distinctChars);
                Assert.Single(distinctChars);

                var firstIndexOccurrence = horizontalLayer.IndexOf(distinctChars.First());
                var secondIndexOccurrence = horizontalLayer.LastIndexOf(distinctChars.Last());

                Assert.Equal(2, charsInHorizontalLayer.Length);

                Assert.Equal(horizontalLayer[..(firstIndexOccurrence + 1)].Length * 2 + gap, horizontalLayer.Length);
                Assert.Equal(horizontalLayer.Substring(secondIndexOccurrence, horizontalLayer.Length - secondIndexOccurrence).Length * 2 + gap, horizontalLayer.Length);
            }
        }

        [Theory]
        [InlineData('A', "A")]
        [InlineData('B', " A \r\nB B\r\n A ")]
        [InlineData('C', "  A  \r\n B B \r\nC   C\r\n B B \r\n  A  ")]
        [InlineData('D', "   A   \r\n  B B  \r\n C   C \r\nD     D\r\n C   C \r\n  B B  \r\n   A   ")]
        [InlineData('E', "    A    \r\n   B B   \r\n  C   C  \r\n D     D \r\nE       E\r\n D     D \r\n  C   C  \r\n   B B   \r\n    A    ")]
        [InlineData('F', "     A     \r\n    B B    \r\n   C   C   \r\n  D     D  \r\n E       E \r\nF         F\r\n E       E \r\n  D     D  \r\n   C   C   \r\n    B B    \r\n     A     ")]
        public void DiamondFormProvider_GeneratesDiamondForm_Correctly_When_DiamondContains6CharsOrLess(char value, string output)
        {
            var result = _sut.GenerateForm(value);

            Assert.Equal(output, result);
        }

        [Theory(Skip = "Need test to scale (by avoiding errors of manually specified output asserted as true)")] // todo
        [InlineData('G', "//todo")]
        [InlineData('H', "//todo")]
        [InlineData('I', "//todo")]
        [InlineData('J', "//todo")]
        [InlineData('K', "//todo")]
        [InlineData('L', "//todo")]
        [InlineData('M', "//todo")]
        [InlineData('N', "//todo")]
        [InlineData('O', "//todo")]
        [InlineData('Q', "//todo")]
        [InlineData('R', "//todo")]
        [InlineData('S', "//todo")]
        [InlineData('T', "//todo")]
        [InlineData('U', "//todo")]
        [InlineData('V', "//todo")]
        [InlineData('W', "//todo")]
        [InlineData('X', "//todo")]
        [InlineData('Y', "//todo")]
        [InlineData('Z', "//todo")]
        public void DiamondFormProvider_GeneratesDiamondForm_Correctly_When_DiamondContainsMoreThan6Chars(char value, string output)
        {
            var result = _sut.GenerateForm(value);

            Assert.Equal(output, result);
        }
    }
}
