Imports Ceva.Business
Imports Ceva.Dados
Public Class BuscaDados
    Inherits System.Web.UI.Page

    Private ReadOnly _relatorioBusiness As IRelatorioBusiness

    Public Sub New()
        _relatorioBusiness = New RelatorioBusiness(New CevaApi())
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Async Sub btnBuscar_Click(sender As Object, e As EventArgs)

        If Page.IsValid Then

            Dim viagemId As String = txtViagem.Text

            If Not String.IsNullOrEmpty(viagemId) Then
                'Dim businessLogic As New RelatorioBusiness(New Dados.CevaApi())
                Dim viagemData As Relatorio = Await _relatorioBusiness.GetBuscarDadosAsync(viagemId)

                If viagemData IsNot Nothing AndAlso viagemData.Viagem IsNot Nothing Then
                    BindRelatorio(viagemData.Viagem)
                End If
            End If
        End If

    End Sub

    Private Sub BindRelatorio(viagemList As List(Of Viagem))

        If viagemList.Count > 0 Then
            rptViagem.DataSource = viagemList
            rptViagem.DataBind()
            pnlReport.Visible = True
            lblMessage.Visible = False
        Else
            pnlReport.Visible = False
            lblMessage.Text = "Nenhum registro encontrado."
            lblMessage.Visible = True

        End If


    End Sub

    Protected Function ModulandoLista(items As List(Of String)) As String
        Dim html As String = ""
        For Each item As String In items
            html &= $"<li>{item}</li>"
        Next
        Return html
    End Function


End Class