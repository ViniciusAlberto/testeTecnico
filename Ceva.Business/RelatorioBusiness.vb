Imports Ceva.Dados
Imports Newtonsoft.Json
Public Class RelatorioBusiness
    Implements IRelatorioBusiness

    Private ReadOnly _apiClient As ICevaApi

    Public Sub New(apiClient As ICevaApi)
        _apiClient = apiClient
    End Sub


    Private Async Function GetBuscarDadosAsync(viagem As String) As Task(Of Relatorio) Implements IRelatorioBusiness.GetBuscarDadosAsync

        Dim jsonData As String = Await _apiClient.BuscarDados(viagem)
        Return JsonConvert.DeserializeObject(Of RetornoApi)(jsonData).Relatorio
    End Function
End Class

Public Class RetornoApi
    <JsonProperty("SincronizarCutOffResult")>
    Public Property Relatorio As Relatorio
End Class
