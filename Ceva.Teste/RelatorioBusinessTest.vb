Imports NUnit.Framework
Imports Moq
Imports Newtonsoft.Json
Imports Ceva.Business
Imports Ceva.Dados

<TestFixture>
Public Class RelatorioBusinessTests
    Private _apiClientMock As Mock(Of ICevaApi)
    Private _relatorioBusiness As RelatorioBusiness

    <SetUp>
    Public Sub SetUp()
        _apiClientMock = New Mock(Of ICevaApi)()
        _relatorioBusiness = New RelatorioBusiness(_apiClientMock.Object)
    End Sub

    <Test>
    Public Async Function GetViagemDataAsync_Returns_Relatorio() As Task

        Dim viagem As String = "NumeroViagem"
        Dim relatorioEsperado As New Relatorio()
        Dim retornoApi As New RetornoApi() With {.Relatorio = relatorioEsperado}
        Dim jsonData As String = JsonConvert.SerializeObject(retornoApi)

        _apiClientMock.Setup(Function(api) api.BuscarDados(viagem)).ReturnsAsync(jsonData)

        Dim actualRelatorio As Relatorio = Await _relatorioBusiness.GetViagemDataAsync(viagem)

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actualRelatorio)
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(relatorioEsperado.Acao, actualRelatorio.Acao)
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(relatorioEsperado.Erro, actualRelatorio.Erro)
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(relatorioEsperado.Viagem, actualRelatorio.Viagem)
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(relatorioEsperado.ExecutouOK, actualRelatorio.ExecutouOK)
    End Function
End Class
