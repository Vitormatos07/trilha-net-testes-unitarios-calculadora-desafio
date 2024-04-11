using NewTalents;

namespace TestesNewTalents
{
    public class UnitTest1
    {
        public Calculadora ConstruirClasse()
        {
            string data = "11/04/2024";
            Calculadora calc = new Calculadora("11/04/2024");

            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TestSomar(int val1, int val2, int res)
        {
            Calculadora calc = ConstruirClasse();

            int resultado = calc.Somar(val1, val2);

            Assert.Equal(res, resultado);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TestMultiplicar(int val1, int val2, int res)
        {
            Calculadora calc = ConstruirClasse();

            int resultado = calc.Multiplicar(val1, val2);

            Assert.Equal(res, resultado);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TestDividir(int val1, int val2, int res)
        {
            Calculadora calc = ConstruirClasse();

            int resultado = calc.Dividir(val1, val2);

            Assert.Equal(res, resultado);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TestSubtrair(int val1, int val2, int res)
        {
            Calculadora calc = ConstruirClasse();

            int resultado = calc.Subtrair(val1, val2);

            Assert.Equal(res, resultado);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = ConstruirClasse();

            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(3, 0));
        }

        [Fact]
        public void TestaHistorico()
        {
            Calculadora calc = ConstruirClasse();

            calc.Somar(1, 4);
            calc.Somar(3, 2);
            calc.Somar(4, 1);
            calc.Somar(2, 3);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count());
        }
    }
}