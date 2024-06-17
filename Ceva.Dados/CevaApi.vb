Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Configuration

Public Class CevaApi
    Implements ICevaApi

    Private Async Function ICevaApi_BuscarDados(viagem As String) As Task(Of String) Implements ICevaApi.BuscarDados
        Using client As New HttpClient()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            client.DefaultRequestHeaders.Add("viagem", viagem)

            Dim content As New StringContent("", Encoding.UTF8, "application/json")


            Dim response As HttpResponseMessage =
            Await client.PostAsync(ConfigurationManager.AppSettings("ApiUrl"), content)


            If response.IsSuccessStatusCode Then

                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Return responseString
            Else

                Throw New Exception($"Falha na requisição: {response.StatusCode}")
            End If
        End Using
    End Function
End Class
