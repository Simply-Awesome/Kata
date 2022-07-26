namespace Kata.Core.Tests
{
    public class KataConsoleTests : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutputStream;

        public KataConsoleTests()
        {
            _stringWriter = new StringWriter();
            _originalOutputStream = Console.Out;
            Console.SetOut(_stringWriter);
        }

        [Fact]
        public void KataConsole_RequiresAlphabetCharacter_ToWriteToConsole()
        {
            Assert.Throws<ArgumentException>(() => new KataConsole(It.IsAny<IFormProvider>()).Write(It.IsAny<char>()));
        }

        [Theory]

        [InlineData('a', "kata")]
        [InlineData('b', "kata")]
        [InlineData('c', "kata")]
        [InlineData('d', "kata")]
        [InlineData('e', "kata")]
        [InlineData('f', "kata")]
        [InlineData('g', "kata")]
        [InlineData('h', "kata")]
        [InlineData('i', "kata")]
        [InlineData('j', "kata")]
        [InlineData('k', "kata")]
        [InlineData('l', "kata")]
        [InlineData('m', "kata")]
        [InlineData('n', "kata")]
        [InlineData('o', "kata")]
        [InlineData('p', "kata")]
        [InlineData('q', "kata")]
        [InlineData('r', "kata")]
        [InlineData('s', "kata")]
        [InlineData('t', "kata")]
        [InlineData('u', "kata")]
        [InlineData('v', "kata")]
        [InlineData('w', "kata")]
        [InlineData('x', "kata")]
        [InlineData('y', "kata")]
        [InlineData('z', "kata")]

        [InlineData('A', "kata")]
        [InlineData('B', "kata")]
        [InlineData('C', "kata")]
        [InlineData('D', "kata")]
        [InlineData('E', "kata")]
        [InlineData('F', "kata")]
        [InlineData('G', "kata")]
        [InlineData('H', "kata")]
        [InlineData('I', "kata")]
        [InlineData('J', "kata")]
        [InlineData('K', "kata")]
        [InlineData('L', "kata")]
        [InlineData('M', "kata")]
        [InlineData('N', "kata")]
        [InlineData('O', "kata")]
        [InlineData('P', "kata")]
        [InlineData('Q', "kata")]
        [InlineData('R', "kata")]
        [InlineData('S', "kata")]
        [InlineData('T', "kata")]
        [InlineData('U', "kata")]
        [InlineData('V', "kata")]
        [InlineData('W', "kata")]
        [InlineData('X', "kata")]
        [InlineData('Y', "kata")]
        [InlineData('Z', "kata")]

        public void KataConsole_GivenAlphabetCharacter_WritesContentToConsole(char value, string kata)
        {
            // arrange

            var formProviderMock = new Mock<IFormProvider>();
            var formProvider = formProviderMock.Object;
            formProviderMock
                .Setup(psm => psm.GenerateForm(It.IsAny<char>()))
                .Returns(kata);

            // act

            new KataConsole(formProvider).Write(value);

            // assert

            formProviderMock.Verify(fpm => fpm.GenerateForm(It.IsAny<char>()), Times.Once);
            Assert.NotNull(_stringWriter.ToString());
            Assert.NotEmpty(_stringWriter.ToString());
            Assert.Equal(kata, _stringWriter.ToString());
        }

        public void Dispose()
        {
            Console.SetOut(_originalOutputStream);
            _stringWriter.Dispose();
        }
    }
}
