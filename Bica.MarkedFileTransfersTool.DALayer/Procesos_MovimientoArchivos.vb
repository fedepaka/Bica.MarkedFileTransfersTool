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
    Public Property ID As Long
    Public Property Procesos_OrigenDestinoArchivosId As Long
    Public Property FILENAME As String
    Public Property PRESENTATION_DATE As Date
    Public Property ID_FILE As Long
    Public Property TRANSFERRED As Nullable(Of Boolean)
    Public Property DOBACKUP As Nullable(Of Boolean)
    Public Property CREATED_USER_ID As Nullable(Of Long)
    Public Property MODIFIED_USER_ID As Nullable(Of Long)
    Public Property CREATED_DATE As Date
    Public Property MODIFIED_DATE As Nullable(Of Date)
    Public Property DELETED As Nullable(Of Boolean)

    Public Overridable Property Procesos_OrigenDestinoArchivos As Procesos_OrigenDestinoArchivos

End Class
