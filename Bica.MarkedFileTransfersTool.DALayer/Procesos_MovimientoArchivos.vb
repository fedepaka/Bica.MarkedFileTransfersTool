'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Procesos_MovimientoArchivos
    Public Property Id As Long
    Public Property Procesos_OrigenDestinoArchivosId As Long
    Public Property NombreArchivo As String
    Public Property FechaPresentacion As Date
    Public Property IdArchivo As Nullable(Of Long)
    Public Property Transferido As Boolean
    Public Property HacerBackup As Boolean
    Public Property ParaTransferir As Boolean
    Public Property Copiado As Boolean
    Public Property Recibido As Boolean
    Public Property Procesado As Boolean
    Public Property UsuarioCreacion As String
    Public Property FechaCreacion As Date
    Public Property UsuarioModificacion As String
    Public Property FechaModificacion As Nullable(Of Date)
    Public Property Eliminado As Boolean

    Public Overridable Property Procesos_OrigenDestinoArchivos As Procesos_OrigenDestinoArchivos

End Class
