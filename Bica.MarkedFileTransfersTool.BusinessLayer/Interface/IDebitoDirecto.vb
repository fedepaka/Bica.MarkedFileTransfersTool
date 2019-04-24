Imports Bica.MarkedFileTransfersTool.Model

Public Interface IDebitoDirecto
    Function ObtenerDebitosDirectos(fecha As Date) As List(Of Procesos_DebitoDirecto)

    Function CopiarArchivosDebitoDirecto(fecha As Date, UserName As String) As Boolean
End Interface
