Public Interface IRelatorioBusiness

    Function GetBuscarDadosAsync(viagem As String) As Task(Of Relatorio)

End Interface
