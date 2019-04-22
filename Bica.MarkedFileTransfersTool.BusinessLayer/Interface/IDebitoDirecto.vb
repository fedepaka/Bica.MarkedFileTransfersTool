Imports Bica.MarkedFileTransfersTool.Model

Public Interface IDebitoDirecto
    Function ObtenerDebitosDirectos(fecha As Date) As Procesos_DebitoDirecto

    Function CopiarArchivosDebitoDirecto(fecha As Date) As Boolean
End Interface
