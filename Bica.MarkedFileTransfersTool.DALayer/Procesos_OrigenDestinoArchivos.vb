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

Partial Public Class Procesos_OrigenDestinoArchivos
    Public Property Id As Long
    Public Property NumeroProceso As Nullable(Of Integer)
    Public Property Procesos_TipoDireccionArchivoId As Long
    Public Property UbicacionDesde As String
    Public Property UbicacionNTFTPImportar As String
    Public Property UbicacionNTFTPEnviar As String
    Public Property UbicacionNTFTPRecibir As String
    Public Property UbicacionDestino As String
    Public Property UsuarioCreacion As String
    Public Property FechaCreacion As Date
    Public Property UsuarioModificacion As String
    Public Property FechaModificacion As Nullable(Of Date)
    Public Property Eliminado As Nullable(Of Boolean)

    Public Overridable Property Procesos_MovimientoArchivos As ICollection(Of Procesos_MovimientoArchivos) = New HashSet(Of Procesos_MovimientoArchivos)
    Public Overridable Property Procesos_TipoDireccionArchivo As Procesos_TipoDireccionArchivo

End Class
