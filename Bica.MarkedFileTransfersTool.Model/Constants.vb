Public Module Constants
    Public BCO_Envio_Debito_Directo_Code As Long = 354
    Public BCO_Envio_Rechazos_Orden_Debito_Code As Long = 359
    Public BCO_Camara_Recepcion_Rejects_Code As Long = 364
    Public BCO_Debito_Directo_Recepcion_Rechazos_Code As Long = 363
    Public BCO_Camara_Recepcion_Orden_Debito_Code As Long = 355


    '364 BCO - Camara - Recepcion Rejects_VsN
    '363 BCO - Deb. Directo - Recepcion Rechazos_VsN
    '359 BCO - Camara - Envio Rechazos Orden Debito
    '355 BCO - Camara - Recepcion Orden Debito_VsN
    '354 BCO - Envio Debito Directo


    Public Procesos_TipoDireccionArchivo_ENVIO As String = "Entidad-Coelsa"
    Public Procesos_TipoDireccionArchivo_RECEPCION As String = "Coelsa-Entidad"

    'Configuración de pantalla de formulario
    Public Formulario_Titulo_DebitoDirectoEnvio As String = "Débitos Directos - Marcar archivos para enviar"
    Public Formulario_Titulo_DebitoDirectoRecepcion As String = "Débitos Directos - Información de recepción de archivos"
    Public Formulario_Error_Titulo As String = "Mensaje de error"

    'Mensajes para Diálogos Si/No
    Public Dialogo_SiNo_Pregunta As String = "Desea efectuar carga de archivos"
    Public Dialogo_SiNo_Titulo As String = "Mensaje"

    Public Formulario_Msg_SinDatos As String = "No existen datos de archivos para la fecha de proceso actual."
    Public Formulario_Msg_SinDatosRecepcion As String = "No existen datos de archivos recibidos/procesados para la fecha de proceso actual."


End Module
