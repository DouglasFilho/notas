using System;
using System.Globalization;
using notas.Server.Backend.Domain.Entities;
using notas.Server.Backend.Domain.Enums;
using notas.Server.Backend.Domain.ValueObjects;
using Xunit;

namespace notas.Tests
{
    public class TestNotaFiscal
    {
        private Endereco DummyEndereco() => new Endereco("Rua A", "", "123", "Centro", "Cidade", UF.MG, "30110-020");
        private Empresa DummyEmpresa(string razao, string cnpj) => new Empresa(razao, razao, cnpj, DummyEndereco());

        [Fact]
        public void CriarNotaFiscal_ComOrigemNula_DeveLancarExcecao()
        {
            var destino = DummyEmpresa("Destino", "10987654321011");
            Assert.Throws<ArgumentNullException>(() => new NotaFiscal(null!, destino, "1", "", "", TipoNota.NFS, 10, DateTime.Now, DateTime.Now, ""));
        }

        [Fact]
        public void CriarNotaFiscal_ComValorTotalInvalido_DeveLancarExcecao()
        {
            var origem = DummyEmpresa("Origem", "12345678910111");
            var destino = DummyEmpresa("Destino", "10987654321011");
            Assert.Throws<ArgumentException>(() => new NotaFiscal(origem, destino, "1", "", "", TipoNota.NFS, 0, DateTime.Now, DateTime.Now, ""));
        }

        [Fact]
        public void ToString_DeveRetornarFormatoCorreto()
        {
            var origem = DummyEmpresa("Origem", "12345678910111");
            var destino = DummyEmpresa("Destino", "10987654321011");
            var nota = new NotaFiscal(origem, destino, "1", "chave", "1", TipoNota.NFE, 50m, new DateTime(2024, 1, 2), new DateTime(2024, 1, 3), "desc");
            var texto = nota.ToString();
            Assert.Contains("NFE 1", texto);
            Assert.Contains("02/01/2024", texto);
        }
    }
}
