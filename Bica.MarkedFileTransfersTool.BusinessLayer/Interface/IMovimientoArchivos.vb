Imports Bica.MarkedFileTransfersTool.Model

Public Interface IMovimientoArchivos
    Function ObtenerMovimientosArchivos(IdProceso As Long, fecha As Date) As List(Of Procesos_MovimientoArchivos)
    Function ObtenerMovimientoArchivosPendientesEnviar(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos)
    Function ObtenerMovimientoArchivosPendientesRecibir(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos)
    Function ObtenerMovimientoArchivosCopiadosNTFTP(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos)
    Function ObtenerMovimientoArchivoPorNombre(Nombre As String) As Procesos_MovimientoArchivos
    Function ObtenerMovimientoArchivoPorId(Id As Long) As Procesos_MovimientoArchivos
    Function ExisteRegistroArchivo(Nombre As String) As Boolean
    Function InsertarRegistroMovimientoArchivo(IdProcesoOrigen As Long, NombreArchivo As String, FechaPresentacion As Date, IdArchivo As Long, UserName As String) As Long
    Function ActualizarRegistroMovimientoArchivo(IdMovimientoArchivo As Long, Transferred As Boolean, DoBackup As Boolean, ToBeTransfer As Boolean, Copied As Boolean, UserName As String) As Boolean
    Function ActualizarRegistroASerTransferido(IdMovimientoArchivo As Long, UserName As String) As Boolean
    Function ActualizarRegistroTransferido(IdMovimientoArchivo As Long, UserName As String) As Boolean
    Function ActualizarRegistroCopiado(IdMovimientoArchivo As Long, UserName As String) As Boolean
End Interface
